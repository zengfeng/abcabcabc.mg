using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using CC.Runtime.Utils;
using LuaInterface;

namespace CC.Runtime
{
    public enum ReadState
    {
        Header,
        Content,
    }
    
    public class ReadData : ISimplePoolItem
    {
        public ReadData()
        {
            state = ReadState.Header;
            buffer = new byte[8192];
            Reset();
        }
        
        public object Pool
        {
            set
            {
                pool = value as SimplePool<ReadData>;
            }
        }
        
        public void Release()
        {
            Reset();
            pool.Put(this);
        }
        
        public void Reset()
        {
            state = ReadState.Header;
            total = 12;
            read = 0;
            proto = 0;
            retcode = 0;
            socket = null;
            stream.SetLength(0);
        }
        
        public ReadState state = ReadState.Header;
        public int proto;
        public int retcode;
        public int total;   //total bytes to read
        public int read;    //already read
        public Socket socket;
        public byte[] buffer;
        public MemoryStream stream = new MemoryStream();
        
        private SimplePool<ReadData> pool;
    }
   
    public enum SocketId{
		Login,
        Main,
        Battle,
        Chat,
        Max,
    }

    internal static class ByteUtil{
        public static byte[] Set( this byte[] src, UInt16 t, int begin ){
            byte[] b = BitConverter.GetBytes(t);
            Array.Copy(b, 0, src, begin, b.Length);
            return src;
        }
    }


    public class SocketManager : MonoBehaviour
    {
//		public ManangerRoot root { get{return ManangerRoot.Instance;} }

		public Action<SocketId> connectedCallback;
		
		private static SocketManager _Instance;
		public static SocketManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("GameManagers");
					if(go == null) go = new GameObject("GameManagers");
					
					_Instance = go.GetComponent<SocketManager>();
					if(_Instance == null) _Instance = go.AddComponent<SocketManager>();
				}
				return _Instance;
			}
		}


        public Action<ReadData> handler;

        public const string OFFLINE = "OFFLINE";


        public void Awake()
        {
			_Instance = this; 
            servers = new ISocketServer[(int)SocketId.Max];
            frametemp = new List<ReadData>();
        }

        public void Stop(SocketId sid)
        {
            int i = (int)sid;
            if( servers[i] != null )
            {
                if (servers[i] is CommonSocketServer)
                {
                    CommonSocketServer s = servers[i] as CommonSocketServer;
                    s.Stop();
                }
            }
        }

		public void StopAll()
		{
			foreach(ISocketServer server in servers)
			{
				if(server != null && server is CommonSocketServer)
				{
					CommonSocketServer s = server as CommonSocketServer;
					s.Stop();
				}
			}
		}

		public void Close(SocketId sid)
		{
			int i = (int)sid;
			if( servers[i] != null )
			{
				if (servers[i] is CommonSocketServer)
				{
					CommonSocketServer s = servers[i] as CommonSocketServer;
					s.Stop();
				}
				servers[i] = null;
			}
		}

		public void CloseAll()
		{
			StopAll();
			servers = new ISocketServer[(int)SocketId.Max];
		}

		public void Connect(SocketId sid, string server)
		{
			string[] arr = server.Split(':');
			string ip = arr[0];
			int port = arr.Length > 1 ? (string.IsNullOrEmpty(arr[1]) ? 80 : Convert.ToInt32(arr[1])) : 80;
			Connect(sid, ip, port);
		}

        public void Connect(SocketId sid, string url, int port)
        {
			Debug.Log(Time.time+ " SocketMananger.Connect sid=" + sid + "  url="+url + "  port=" + port);
            int i = (int)sid;
//			if (servers [i] != null) 
//			{
//				if(Application.isEditor) Debug.LogError ("socket已经连接，之前没有关闭 sid=" + sid );
//				Close (sid);
//			}

            if( servers[i] == null ){
                if( string.IsNullOrEmpty(url) || url.ToUpper() == OFFLINE ){
                    Offline(sid);
                }
                else{
                    var s = new CommonSocketServer(this,sid);
//                    s.root = root;
                    s.URL = url;
                    s.Port = port;
                    s.ReconnSpan = 5;
					if(connectedCallback != null) {
						s.sConnect.AddListener(connectedCallback);
					}

					servers[i] = s;
                    s.Start();
                }
            }
        }

        public void Reconnect(SocketId sid)
        {
            int i = (int)sid;
            if (servers[i] != null)
            {
                if (servers[i] is CommonSocketServer)
                {
                    var s = servers[i] as CommonSocketServer;
                    s.Reconnect();
                }
            }
        }

		public void AddConnectedCallback(Action<SocketId> callback) {
			connectedCallback += callback;
		}

		public void AddLuaConnectedCallback(LuaTable table, LuaFunction callback) {
			LuaCallback luaCB = new LuaCallback(table, callback);
			AddConnectedCallback(luaCB.ServerConnectedCallback);
		}

		public void AddLuaDisconnectCallback(SocketId ssid, LuaFunction callback)
        {
			int idx = (int)ssid;
            if (servers[idx] != null)
            {
                var s = servers[idx] as CommonSocketServer;
                s.sDisconnect.AddListener((SocketId sid)=>
                {
                    callback.Call((int)sid);
                });
            }
        }

		public void AddLuaReconnectCallback(SocketId ssid, LuaFunction callback)
        {
			int idx = (int)ssid;
            if (servers[idx] != null)
            {
                var s = servers[idx] as CommonSocketServer;
                s.sReconnect.AddListener((SocketId sid)=>
                {
                    callback.Call((int)sid);
                });
            }
        }

        public bool isServerConnect(SocketId sid)
        {
            int i = (int)sid;
            return (servers[i] != null);
        }
			
		public void Offline(SocketId sid){
            var s = new OfflineSocketServer(this,sid);
            int i = (int)sid;
//            s.root = root;
            s.Start();
            servers[i] = s;
        }
        
        public void Update(){
            frametemp.Clear();
            foreach( var s in servers ){
                if( s != null ){
                    frametemp.AddRange(s.OnFrame());
                }
            }
            foreach( var rd in frametemp ){
                handler(rd);
            }
        }

        public void SendProtoMessage(SocketId sid, int id, Stream stream)
        {
            int i = (int)sid;
            //byte[] bytes = new byte[stream.Length];
            //stream.Read(bytes, 0, bytes.Length);
            //string StringOut = "";
            //foreach (byte InByte in bytes)
            //{
            //    StringOut = StringOut + String.Format("{0:X2} ", InByte);
            //}
            //Debug.Log("========: " + StringOut);

            if ( servers[i] != null ){
                servers[i].SendProtoMessage(id, stream);
            }
        }

        public void SendEmptyMessage(SocketId sid,int id)
        {
            int i = (int)sid;
            if( servers[i] != null ){
                servers[i].SendEmptyMessage(id);
            }
        }
        private List<ReadData> frametemp;
        private ISocketServer[] servers;
    }
}
