using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using LuaInterface;
using Games.Module.Sysmsgs;
using CC.Runtime.PB;

namespace CC.Runtime
{
    public interface IProtoHandler
    {
        void Handle(Stream stream);
    }

	public class ProtoHandler<T> : IProtoHandler
    {
        public void Handle(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            T msg = Serializer.Deserialize<T>(stream);
            Type s = typeof(T);
            if (OnReceive != null)
            {
                OnReceive(msg);
            }

            //HDebugger.Log(HDebuggerModule.Proto, "S --> C : " + s.FullName);
        }
        public Action<T> OnReceive;
    }

    public partial class PacketManager : MonoBehaviour
    {
		private static PacketManager _Instance;
		public static PacketManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("GameManagers");
					if(go == null) go = new GameObject("GameManagers");
					
					_Instance = go.GetComponent<PacketManager>();
					if(_Instance == null) _Instance = go.AddComponent<PacketManager>();
				}
				return _Instance;
			}
		}

		public SocketManager socketManager { get{return SocketManager.Instance;} }
     
        public void Awake()
        {
			_Instance = this;
            cdict = new Dictionary<string, int>();
            sdict = new Dictionary<int, IProtoHandler>();
            sdict_str = new Dictionary<string, IProtoHandler>();
			sLuaHandlers = new Dictionary<int, LuaFunction>();
            InitialCS();
            InitialSC();
			InitialTR();
			InitialRT();

			initialize();
        }

		public void initialize() {
			socketManager.handler += LuaHandle;
            socketManager.handler += Handle;
        }

        private void RegisterCS<T>()
        {
            string s = typeof(T).FullName;
            int idx = s.LastIndexOf('_');
            string sub = s.Substring(idx + 1);
            int n = Convert.ToInt32(sub, 16);
            cdict.Add(s, n);
        }

        private void RegisterSC<T>()
        {
            string s = typeof(T).FullName;
            int idx = s.LastIndexOf('_');
            string sub = s.Substring(idx + 1);
            int n = Convert.ToInt32(sub, 16);
            var ph = new ProtoHandler<T>();
            sdict.Add(n, ph);
            sdict_str.Add(s, ph);
        }

        private void RegisterRT<T>()
		{
			string s = typeof(T).FullName;
			int idx = s.LastIndexOf('_');
			string sub = s.Substring(idx + 1);
			int n = Convert.ToInt32(sub, 16);
			cdict.Add(s, n);
		}
		
        private void RegisterTR<T>()
		{
			string s = typeof(T).FullName;
			int idx = s.LastIndexOf('_');
			string sub = s.Substring(idx + 1);
			int n = Convert.ToInt32(sub, 16);
			var ph = new ProtoHandler<T>();
			sdict.Add(n, ph);
			sdict_str.Add(s, ph);
		}

		public void AddCallback<T>(Action<T> proc)
        {
            string n = typeof(T).FullName;
            IProtoHandler iph;
            bool b = sdict_str.TryGetValue(n, out iph);
            if (b)
            {
                ProtoHandler<T> pht = iph as ProtoHandler<T>;
                pht.OnReceive += proc;
            }
        }

        public void RemoveCallback<T>(Action<T> proc)
        {
            string n = typeof(T).FullName;
            IProtoHandler iph;
            bool b = sdict_str.TryGetValue(n, out iph);
            if (b)
            {
                ProtoHandler<T> pht = iph as ProtoHandler<T>;
                pht.OnReceive -= proc;
            }
        }

        public void SendMessageEmpty<T>()
        {
            string s = typeof(T).FullName;
            int t;
            bool b = cdict.TryGetValue(s, out t);
            if (b)
            {
				string tname = typeof(T).Name;
                switch(tname[0]){
				case 'C':
					socketManager.SendEmptyMessage(SocketId.Main, t);
                    HDebugger.Log(HDebuggerModule.Proto, "C --> S : " + s);
					break;
				case 'R':
                    socketManager.SendEmptyMessage(SocketId.Chat, t);
					break;
				default:
					break;
				}
            }
        }

		
		public void SendMessage<T>(SocketId socketId, T m)
		{
			string s = typeof(T).FullName;
			int t;
			bool b = cdict.TryGetValue(s, out t);
			if (b)
			{
				Stream str = new MemoryStream();
				Serializer.Serialize<T>(str, m);
				string tname = typeof(T).Name;
				
				socketManager.SendProtoMessage(socketId,t, str);
				HDebugger.Log(HDebuggerModule.Proto, "SendMessage network log : C --> S : " + s);
			}
		}

        public void SendMessage<T>(T m)
        {
            string s = typeof(T).FullName;
            int t;
            bool b = cdict.TryGetValue(s, out t);
            if (b)
            {
                Stream str = new MemoryStream();
                Serializer.Serialize<T>(str, m);
				string tname = typeof(T).Name;
				switch(tname[0]){
				case 'C':
					socketManager.SendProtoMessage(SocketId.Main,t, str);
					break;
				case 'R':
                    socketManager.SendProtoMessage(SocketId.Chat,t, str);
					break;
				default:
					break;
				}
                HDebugger.Log(HDebuggerModule.Proto, "SendMessage all network log : C --> S : " + s);
            }
		}

        public int GetMessageId(string protoType)
        {
            int t;
            bool b = cdict.TryGetValue(protoType, out t);
            if (b)
                return t;

            return -1;
        }

        public int reconnectMessage
        {
            get
            {
                return GetMessageId(typeof(C_ReConnect_0x101).FullName);
            }
        }

        private Dictionary<string, int> cdict;
        private Dictionary<int, IProtoHandler> sdict;

        private Dictionary<string, IProtoHandler> sdict_str;

        internal void Handle(ReadData rdata)
        {
			if(rdata.proto == 0) return;
            if(rdata.retcode != 0)
            {
                Debug.Log("Process protocol 0x" + Convert.ToString(rdata.proto, 16) + " failed. retcode=" + rdata.retcode);
                SysmsgManager.Execute(rdata.retcode);
                return;
            }

			IProtoHandler iph;
			Debug.Log("network log receive : S->C msgid = 0x" + Convert.ToString(rdata.proto, 16) + ", retcode=" + rdata.retcode);
            bool b;
            b = sdict.TryGetValue(rdata.proto, out iph);
            if (b)
            {
                iph.Handle(rdata.stream);
            }
            rdata.Release();
            //            throw new NotImplementedException();
        }
    }
}
