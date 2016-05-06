using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace CC.Module.DebugLog
{
	public partial class GM : MonoBehaviour 
	{

		void Awake () 
		{
			SignalFactory.GetInstance<GMSignal>().AddListener(OnGM);
		}


//		public void OnGM (GMInfoVO vo, string argstr) 
//		{
//			Debug.Log(vo.ToString() + "\t   arg=" + argstr);
//			switch(vo.enPart)
//			{
//				/** 设置开放关卡 */
//			case "set_dungeon_level":
//				Debug.Log("GM 设置开放关卡");
//				break;
//			}
//		}


	}
}
