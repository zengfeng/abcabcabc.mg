using UnityEngine;
using System.Collections;
using LuaInterface;

namespace CC.Runtime.Utils {
	// Notice: LuaFunction need to be disposed manually
	public class LuaCallback 
	{
		LuaTable table;
		LuaFunction luaFunction;

		public LuaCallback(LuaTable table, LuaFunction function) {
			this.table = table;
			this.luaFunction = function;
		}

		public void AssetLoadCallback(string name, System.Object obj, System.Object arg) {
			if(luaFunction == null)  return;
			luaFunction.Call(table, name, obj);

			Dispose();
		}

		public void MenuInstanceCallback(int menuId)
		{
			if(luaFunction == null)  return;
			luaFunction.Call(table, menuId);
			Dispose();
		}

		public void ServerConnectedCallback(SocketId sid) {
			if(luaFunction == null)  return;
			luaFunction.Call(table, sid);
		}


		public void Dispose()
		{
			luaFunction.Dispose();
			table.Dispose();

			luaFunction = null;
			table = null;
		}

	}
}
