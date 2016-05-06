using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;

namespace CC.Runtime {

//    public enum SocketStatus
//    {
//        None,
//        Ready,
//        Ok,
//        ReReady,
//        Errored,
//        Reconn,
//    }

//    public enum ReadState
//    {
//        Header,
//        Content,
//    }

//    public class ReadData : ISimplePoolItem
//    {
//        public ReadData()
//        {
//            state = ReadState.Header;
//            buffer = new byte[2048];
//            Reset();
//        }
//
//        public object Pool
//        {
//            set
//            {
//                pool = value as SimplePool<ReadData>;
//            }
//        }
//
//        public void Release()
//        {
//            Reset();
//            pool.Put(this);
//        }
//
//        public void Reset()
//        {
//            state = ReadState.Header;
//            total = 4;
//            read = 0;
//            proto = 0;
//            socket = null;
//            stream.SetLength(0);
//        }
//
//        public ReadState state = ReadState.Header;
//        public int proto;
//        public int total;		//total bytes to read
//        public int read;			//already read
//        public Socket socket;
//        public byte[] buffer;
//        public MemoryStream stream = new MemoryStream();
//
//        private SimplePool<ReadData> pool;
//    }

    public abstract class AbstractSocket : MonoBehaviour
    {

        public static AbstractSocket instance;

        public static void CopyBytes(ushort t, byte[] buffer, int begin)
        {
            byte[] b = BitConverter.GetBytes(t);
            Array.Copy(b, 0, buffer, begin, b.Length);
        }

        public virtual void Awake()
        {
            instance = this;
        }

        public delegate void SocketHandler(ReadData rdata);
        public SocketHandler handler;
        public abstract void Connect(string url, int port);
        public abstract void SendProtoMessage(int id, Stream stream);
        public abstract void SendEmptyMessage(int id);
    }
}

