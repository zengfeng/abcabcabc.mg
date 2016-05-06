using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using SimpleFramework;

namespace CC.UI
{
	public class LuaUIEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler 
	{

		
		private List<LuaFunction> clickFuns = new List<LuaFunction>();
		private List<LuaFunction> downFuns = new List<LuaFunction>();
		private List<LuaFunction> upFuns = new List<LuaFunction>();
		private List<LuaFunction> enterFuns = new List<LuaFunction>();
		
		//-----------------------------------------------------------------
		public void OnPointerDown (PointerEventData eventData)
		{
			foreach(LuaFunction luafunc in downFuns)
			{
				luafunc.Call(this);
			}
		}
		
		public void AddDown(LuaFunction luafunc)
		{
			downFuns.Add(luafunc);
		}
		
		public void ClearDown()
		{
			ClearFuns(downFuns);
		}


		//-----------------------------------------------------------------
		public void OnPointerUp (PointerEventData eventData)
		{
			foreach(LuaFunction luafunc in upFuns)
			{
				luafunc.Call(this);
			}
		}
		
		public void AddUp (LuaFunction luafunc)
		{
			upFuns.Add(luafunc);
		}
		
		public void ClearUp()
		{
			ClearFuns(upFuns);
		}
		

		
		//-----------------------------------------------------------------
		public void OnPointerClick (PointerEventData eventData)
		{
			foreach(LuaFunction luafunc in clickFuns)
			{
				luafunc.Call(this);
			}
		}

		public void AddClick(LuaFunction luafunc)
		{
			clickFuns.Add(luafunc);
		}

		public void ClearClick()
		{
			ClearFuns(clickFuns);
		}

		//-----------------------------------------------------------------
		public void OnEnable ()
		{
			foreach(LuaFunction luafunc in enterFuns)
			{
				luafunc.Call(this);
			}
		}
		
		public void AddEnable(LuaFunction luafunc)
		{
			enterFuns.Add(luafunc);
		}
		
		public void ClearEnable()
		{
			ClearFuns(enterFuns);
		}


		
		//-----------------------------------------------------------------
		
		protected void ClearFuns( List<LuaFunction> list)
		{
			for (int i = 0; i < list.Count; i++) 
			{
				if (list[i] != null) {
					list[i].Dispose();
					list[i] = null;
				}
			}
			
			list.Clear();
		}

		//-----------------------------------------------------------------
		protected void OnDestroy()
		{
			ClearClick();
			ClearDown();
			ClearUp();
			ClearEnable();
			Util.ClearMemory();
		}
	}
}
