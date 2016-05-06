using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System;
using CC.Runtime.Utils;
using CC.Runtime.signals;
using System.Threading;

namespace CC.Runtime
{
    public class OutData : ISimplePoolItem
    {
        public byte[] data = new byte[1024];
        public int total;

        public object Pool
        {
            set { pool = value as SimplePool<OutData>; }
        }

        public void Release()
        {
            total = 0;
            pool.Put(this);
        }

        private SimplePool<OutData> pool;
    }

    public class SocketManager_Async : AbstractSocket
    {
        public HSignal connectSignal { set; get; }
		public HSignal reconnectSignal { set; get; }
		public HSignal disconnectSignal { set; get; }
        private IPEndPoint endp;
        private Socket socket;
        private SocketStatus status = SocketStatus.None;
        private Queue inqueue;
        private Queue outqueue;
        private SimplePool<ReadData> readpool;
        private SimplePool<OutData> outpool;
        
        //sync sending
        private int sending = 0;


        public override void Awake()
        {
            base.Awake();
            inqueue = Queue.Synchronized(new Queue());
            outqueue = Queue.Synchronized(new Queue());
            readpool = SimplePool<ReadData>.Instance;
            outpool = new SimplePool<OutData>();
        }

        public override void Connect(string url, int port)
        {
            IPAddress[] addrs = Dns.GetHostAddresses(url);
            if (addrs.Length > 0)
            {
                endp = new IPEndPoint(addrs[0], port);
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                status = SocketStatus.None;
                s.BeginConnect(endp, ConnectEnd, s);
            }
        }

        private void ConnectEnd(IAsyncResult ar)
        {
            Socket s = ar.AsyncState as Socket;
            s.EndConnect(ar);
            socket = s;
            status = SocketStatus.Ready;
        }

        private void ReconnectEnd(IAsyncResult ar)
        {
            Socket s = ar.AsyncState as Socket;
            s.EndConnect(ar);
            socket = s;
            status = SocketStatus.ReReady;
        }

        public void Update() {
            switch (status)
            {
                case SocketStatus.Ready:
                    status = SocketStatus.Ok;
                    connectSignal.Dispatch();
                    ReadLoop(socket);
                    break;
                case SocketStatus.Ok:
                    HandlePacket();
                    break;
                case SocketStatus.Errored:
                    status = SocketStatus.Reconn;
                    disconnectSignal.Dispatch();
                    Reconnect();
                    break;
                case SocketStatus.ReReady:
                    status = SocketStatus.Ok;
                    reconnectSignal.Dispatch();
                    ReadLoop(socket);
                    if (outqueue.Count > 0) 
                    {
                        BeginSend();
                    }
                    break;
                default:
                    break;
            }
        }

        private void Reconnect()
        {
//            throw new NotImplementedException();
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            status = SocketStatus.None;
            s.BeginConnect(endp, ConnectEnd, s);
        }

        public override void SendProtoMessage(int id, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            OutData od = outpool.Get();
            int len = stream.Read(od.data, 4, (int)stream.Length);
            CopyBytes((UInt16)len, od.data, 0);
            CopyBytes((UInt16)id, od.data, 2);
            od.total = len + 4;
            outqueue.Enqueue(od);

            if (status == SocketStatus.Ok)
            {
                lock (this)
                {
                    if (sending == 0)
                    {
                        BeginSend();
                    }
                }
            }
        }

        private void BeginSend()
        {
            Interlocked.Exchange(ref sending, 1);
            try
            {
                if (outqueue.Count > 0)
                {
                    OutData od = outqueue.Peek() as OutData;
                    socket.BeginSend(od.data, 0, od.total, SocketFlags.None, EndSend, socket);
                }
                else
                {
                    Interlocked.Exchange(ref sending, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref sending, 0);
                Debug.LogException(ex);
            }
        }

        private void EndSend(IAsyncResult ar)
        {
            Socket s = ar.AsyncState as Socket;
            try
            {
                s.EndSend(ar);
                OutData od = outqueue.Dequeue() as OutData;
                od.Release();
                if (outqueue.Count > 0) {
                    od = outqueue.Dequeue() as OutData;
                    s.BeginSend(od.data, 0, od.total, SocketFlags.None, EndSend, socket);
                }
                else
                {
                    Interlocked.Exchange(ref sending, 0);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref sending, 0);
                Debug.LogException(ex);
            }

            //throw new NotImplementedException();
        }


        public override void SendEmptyMessage(int id)
        {
            OutData od = outpool.Get();
            CopyBytes(0, od.data, 0);
            CopyBytes((UInt16)id, od.data, 2);
            od.total = 4;
            outqueue.Enqueue(od);

            if (status == SocketStatus.Ok)
            {
                lock (this)
                {
                    if (sending == 0)
                    {
                        BeginSend();
                    }
                }
            }
        }

        private void ReadLoop(Socket socket)
        {
            if (socket.Connected) 
            {
                ReadData rd = readpool.Get();
                rd.socket = socket;
                try
                {
                    socket.BeginReceive(rd.buffer, rd.read, rd.total - rd.read, SocketFlags.None, ReadEnd, rd);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    status = SocketStatus.Errored;
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;
                }
            }
            else
            {
                status = SocketStatus.Errored;
                socket = null;
            }
        }

        private void ReadEnd(IAsyncResult ar)
        {
            ReadData rd = ar.AsyncState as ReadData;
            Socket socket = rd.socket;
            try
            {
                int n = rd.socket.EndReceive(ar);
                rd.read += n;
                if (rd.read == rd.total)
                {
                    if (rd.state == ReadState.Header)
                    {
                        int l = BitConverter.ToInt16(rd.buffer, 0);
                        int id = BitConverter.ToInt16(rd.buffer, 2);
                        rd.proto = id;
                        rd.read = 0;
                        rd.total = l;
                        rd.state = ReadState.Content;
                    }
                    else
                    {
                        rd.stream.Seek(0, SeekOrigin.Begin);
                        rd.stream.Write(rd.buffer, 0, rd.total);
                        inqueue.Enqueue(rd);
                        rd = readpool.Get();
                        rd.socket = socket;
                    }
                }
                socket.BeginReceive(rd.buffer, rd.read, rd.total - rd.read, SocketFlags.None, ReadEnd, rd);
            }
            catch(Exception ex)
            {
                Debug.LogException(ex);
                status = SocketStatus.Errored;
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }

        private void HandlePacket()
        {
            if (handler != null) 
            {
                while (inqueue.Count > 0)
                {
                    var rd = inqueue.Dequeue() as ReadData;
                    handler(rd);
                }
            }
        }
    }
}
