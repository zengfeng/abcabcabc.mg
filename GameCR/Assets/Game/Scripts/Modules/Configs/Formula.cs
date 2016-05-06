using UnityEngine;
using System.Collections;
using System;
using LuaInterface;
using CC.Runtime.Utils;
using CC.Runtime;

namespace Games.Cores
{

	[ConfigPath("Config/formula",ConfigType.CSV)]
	public class FormulaConfig : IParseCsv, IKey<int>
	{
		public int id;
		public string name;
		public string description;
		public string script;
		public string parameter;
		
		
		public int Key
		{
			get
			{
				return id;
			}
		}
		
		public void ParseCsv(string[] csv)
		{
			int i = 0;
			id = csv.GetInt32(i++);
			name = csv.GetString(i++);
			description = csv.GetString(i++);
			script = csv.GetString(i++);
			parameter = csv.GetString(i++);
		}
		
		
		public override string ToString ()
		{
			return string.Format ("[FormulaConfig: id={0}, name={1}, description={2}, script={3}, parameter={4}]", id, name, description, script, parameter);
		}
	}

	public class Formula 
	{
		private static Formula _Instance;
		private static Formula Instance
		{
			get
			{
				if(_Instance == null) _Instance = new Formula();
				return _Instance;
			}
		}

		LuaState lua ;
		LuaScriptMgr luaManager;
		public Formula()
		{

			
//			lua = new LuaState();
//			LuaScriptMgr._translator = lua.GetTranslator();
			
//			string script = @"function formula_zf(level) return level * 2  end";
//			lua.DoString(script);

//			string script = @"function formula_11(level, a) return (level < 10 and level * a) or level * a * 2  end";
//			lua.DoString(script);
//			
//			script = @"function formula_12(level)  return formula_11(level, 0.2)  end";
//			lua.DoString(script);
//			
//			script = @"function formula_13(level) return formula_11(level, 0.3)  end";
//			lua.DoString(script);


//			Load();
		}

		private bool _loaded = false;
		private void Load()
		{
			if(_loaded) return;
				_loaded = true;
			
			Debug.Log("Formula.Load");
			luaManager = Coo.luaManager;
			ConfigSet<int, FormulaConfig>  configSet = Coo.configManager.GetConfig<int, FormulaConfig>();
			configSet.Each(DoScript);
		}

		private void DoScript(FormulaConfig config)
		{
//			Debug.Log(config);
			if(!string.IsNullOrEmpty(config.script))
			{
//				lua.DoString(config.script);
				luaManager.DoString(config.script);
			}
		}

		public static void LoadConfig()
		{
			Instance.Load();
		}

		private static object[] CallLua(int id, params object[] args)
		{
//			LuaFunction f = Instance.lua.GetFunction("formula_" + id);
//			object[] r = f.Call(args);
//			return r;
//			return new object[]{1.0};

			object[] r = Instance.luaManager.CallLuaFunction("formula_" + id, args);

			
			if(r == null)
			{
				Debug.Log(string.Format("<color=red>CallFloal id={0} r=null</color>", id));
			}
			return r;

		}
		
		public static object[] Call(int id, params object[] args)
		{
			return CallLua(id, args);
		}
		
		public static float CallFloal(int id, params object[] args)
		{
			object[] results = CallLua(id, args);
			if(results.Length > 0) return Convert.ToSingle((double)results[0]);
			return 0f;
		}
		
		public static int CallInt(int id, params object[] args)
		{
			object[] results = CallLua(id, args);
			if(results.Length > 0) return Convert.ToInt32((double)results[0]);
			return 0;
		}
		
		public static string CallString(int id, params object[] args)
		{
			object[] results = CallLua(id, args);
			if(results.Length > 0) return (string)results[0];
			return "";
		}


	}
}