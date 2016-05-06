using UnityEngine;
using System.Collections;
using CC.Runtime.signals;
using CC.Module.DebugLog;
using Games.Cores;
using CC.Runtime.Utils;

namespace CC.Module.DebugLog
{
	public partial class GM 
	{

		public void OnGM (GMInfoVO vo, string argstr) 
		{
			Debug.Log(vo.ToString() + "\t   arg=" + argstr);
			switch(vo.enPart)
			{
			/** 设置开放关卡 */
			case "set_dungeon_level":
				Debug.Log("GM 设置开放关卡");
				break;
			case "item":
				string[] args = argstr.Split(' ');
				int itemId = args.GetInt32(0);
				int itemNum = args.GetInt32(1);
				break;
			}


		}
	}
}