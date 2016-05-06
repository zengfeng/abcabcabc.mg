using UnityEngine;
using System.Collections;
using CC.Runtime;
using LuaInterface;
using SimpleFramework;

namespace CC.UI
{
	public class BaseLuaUI : LuaBehaviour
	{
		[HideInInspector]
		public RectTransform rectTransform;
		
		override protected void Awake() 
		{
			rectTransform = GetComponent<RectTransform>();
			base.Awake();
		}

		override protected void Start() 
		{
			if (LuaManager != null) {
				LuaState l = LuaManager.lua;
				l[transform.name + ".rectTransform"] = rectTransform;
			}

			base.Start();
		}

		virtual public void Show() 
		{

		}
	}
}

