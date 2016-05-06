using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;
using SimpleFramework;
using Games.Module.Sysmsgs;

namespace CC.Runtime
{
	public partial class PacketManager : MonoBehaviour
	{
		private Dictionary<int, LuaFunction> sLuaHandlers;

		public void AddLuaProtoCallback(string msgStr, LuaFunction func) {
			int idx = msgStr.LastIndexOf('_');
			string sub = msgStr.Substring(idx + 1);
			int msgId = Convert.ToInt32(sub, 16);

			if (sLuaHandlers.ContainsKey(msgId))
			{
				LuaFunction oldFunc = sLuaHandlers[msgId];
				sLuaHandlers[msgId] = func;
				oldFunc.Dispose();
			} else {
				sLuaHandlers.Add(msgId, func);
			}
		}

		
		
		public void RemoveLuaProtoCallback(int msgId)
		{
			if (sLuaHandlers.ContainsKey(msgId))
			{
				sLuaHandlers.Remove(msgId);
			}
		}

		public void SendMessage(SocketId sid, int msgId, LuaStringBuffer msgContent) {
			Debug.Log("network log : C->S " +  sid + " msgId=0x" + Convert.ToString(msgId, 16));
			Stream stream = new MemoryStream(msgContent.buffer);
			socketManager.SendProtoMessage(sid, msgId, stream);
		}

		internal void LuaHandle(ReadData rdata)
		{
            if (rdata.proto == 0) return;
            if (rdata.retcode != 0)
            {
                Debug.Log("Process protocol 0x" + Convert.ToString(rdata.proto, 16) + " failed. retcode=" + rdata.retcode);
//                SysmsgManager.Execute(rdata.retcode);
                return;
            }

            LuaFunction handler;
			bool b;

			b = sLuaHandlers.TryGetValue(rdata.proto, out handler);
			if (b)
			{
				Debug.Log("network log receive: S->C msgid = 0x" + Convert.ToString(rdata.proto, 16) + " by lua process");
				Util.PushBufferToLua(handler, rdata.stream.ToArray());
//				rdata.Release();
			}

		}
	}
}

