using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using CC.Runtime.Utils;
using CC.Runtime.signals;

namespace CC.Runtime
{
    public class ChatSocketManager : MonoBehaviour
    {

        public static ChatSocketManager instance;
        
        public const float ReconnSpan = 5;
        private IPEndPoint endp;
        private Socket socket;
        private SocketStatus status = SocketStatus.None;
        private ReadData rdata;
        private byte[] outbuffer;
        public string url;
        public int port;
        
        public delegate void SocketHandler(ReadData rdata);

        public SocketHandler handler;

		public HSignal sConnect = new HSignal();
		public HSignal sReconnect = new HSignal();
		public HSignal sDisconnect = new HSignal();
        
        void Awake()
        {
            instance = this;

            readpool = SimplePool<ReadData>.Instance;
            outbuffer = new byte[1024];
            tempolist = new List<Pair<int, Stream>>();
            frametemp = new List<ReadData>();
        }
        
        public void Connect(string url, int port)
        {
            IPAddress[] addrs = Dns.GetHostAddresses(url);
            if (addrs.Length > 0)
            {
                endp = new IPEndPoint(addrs [0], port);
                #if UNITY_WEBPLAYER
                if( !Security.PrefetchSocketPolicy(addrs[0].ToString(),port,3000) ){
                    Debug.LogError("Get Socket Polily Failed");
                    return;
                }
                #endif
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                StartCoroutine(ConnectFrame(socket, endp));
            }
        }
        // 
        //         public void ConnectSocket()
        //         {
        //             Connect(url, port);
        //         }
        
        public IEnumerator ConnectFrame(Socket sock, IPEndPoint ep)
        {
            bool conn = false;
            while (!conn)
            {
                try
                {
                    sock.Connect(ep);
                    conn = true;
                    break;
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    conn = false;
                }
                
                yield return new WaitForSeconds(ReconnSpan);
            }
            status = SocketStatus.Ok;
            rdata = readpool.Get();
            rdata.socket = sock;
			sConnect.Dispatch();
        }
        
        public IEnumerator ReconnectFrame(Socket sock, IPEndPoint ep)
        {
            bool conn = false;
            while (!conn)
            {
                try
                {
                    sock.Connect(ep);
                    conn = true;
                    break;
                }
                catch (Exception)
                {
                }
                yield return new WaitForSeconds(ReconnSpan);
            }
			sReconnect.Dispatch();
            status = SocketStatus.Ok;
            
            while (tempolist.Count > 0)
            {
                var p = tempolist [0];
                bool b = false;
                if (p.second == null)
                {
                    b = SendEmptyMessageImpl(p.first);
                }
                else
                {
                    b = SendProtoMessageImpl(p.first, p.second);
                }
                if (!b)
                {
                    break;
                }
                else
                {
                    tempolist.RemoveAt(0);
                }
            }
        }
        
        public void Update()
        {
            if (status == SocketStatus.Ok)
            {
                frametemp.Clear();
                if (!socket.Connected)
                {
					sDisconnect.Dispatch();
                    status = SocketStatus.Errored;
                }
                else
                {
                    try
                    {
                        int avail = socket.Available;
                        while (avail > 0)
                        {
                            int byt = socket.Receive(rdata.buffer, rdata.read, rdata.total - rdata.read, SocketFlags.None);
                            avail -= byt;
                            rdata.read += byt;
                            if (rdata.read == rdata.total)
                            {
                                if (rdata.state == ReadState.Header)
                                {
                                    int l = BitConverter.ToUInt16(rdata.buffer, 0);
                                    int id = BitConverter.ToUInt16(rdata.buffer, 2);
                                    rdata.proto = id;
                                    rdata.read = 0;
                                    rdata.total = l;
                                    rdata.state = ReadState.Content;
                                    //
                                    if (rdata.total == 0)
                                    {
                                        rdata.stream.SetLength(0);
                                        frametemp.Add(rdata);
                                        rdata = readpool.Get();
                                        rdata.socket = socket;
                                    }
                                    
                                    
                                    print("id  " + id.ToString() + "len  " + l.ToString());
                                }
                                else
                                {
                                    rdata.stream.Seek(0, SeekOrigin.Begin);
                                    rdata.stream.Write(rdata.buffer, 0, rdata.total);
                                    frametemp.Add(rdata);
                                    rdata = readpool.Get();
                                    rdata.socket = socket;
                                }
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Debug.LogException(ex);
                        Reconnect(endp);
                    }
                }
                foreach (var d in frametemp)
                {
                    handler(d);
                }
            }
        }
        
        public bool Send(byte[] buffer, int offset, int size)
        {
            if (socket.Connected)
            {
                SocketError sr;
                int i = socket.Send(buffer, offset, size, SocketFlags.None, out sr);
                
                if (i == -1 || sr != SocketError.Success)
                {
                    Reconnect(endp);
                    return false;
                }
                return true;
            }
            return false;
        }
        
        private bool SendProtoMessageImpl(int id, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            int len = stream.Read(outbuffer, 4, (int)stream.Length);
            AbstractSocket.CopyBytes((UInt16)len, outbuffer, 0);
            AbstractSocket.CopyBytes((UInt16)id, outbuffer, 2);
            return Send(outbuffer, 0, (int)len + 4);
        }
        
        private bool SendEmptyMessageImpl(int id)
        {
            AbstractSocket.CopyBytes(0, outbuffer, 0);
            AbstractSocket.CopyBytes((UInt16)id, outbuffer, 2);
            return Send(outbuffer, 0, 4);
        }
        
        public void SendProtoMessage(int id, Stream stream)
        {
            print(status);
            if (status == SocketStatus.Ok)
            {
                if (!SendProtoMessageImpl(id, stream))
                {
                    tempolist.Add(new Pair<int, Stream>(id, stream));
                }
            }
            else
            {
                tempolist.Add(new Pair<int, Stream>(id, stream));
            }
        }
        
        public void SendEmptyMessage(int id)
        {
            if (status == SocketStatus.Ok)
            {
                if (!SendEmptyMessageImpl(id))
                {
                    tempolist.Add(new Pair<int, Stream>(id, null));
                }
            }
            else
            {
                tempolist.Add(new Pair<int, Stream>(id, null));
            }
        }
        
        private void Reconnect(IPEndPoint endp)
        {
            Debug.Log("SocketManager Reconnect ......");
            
            rdata.Reset();
            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(true);
            status = SocketStatus.Errored;
            StartCoroutine(ReconnectFrame(socket, endp));
        }
        
        private SimplePool<ReadData> readpool;
        private List<Pair<int, Stream>> tempolist;
        private List<ReadData> frametemp;
    }
}
