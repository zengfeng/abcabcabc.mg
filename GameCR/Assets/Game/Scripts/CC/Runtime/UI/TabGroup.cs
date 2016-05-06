using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using LuaInterface;
using System.Collections.Generic;
using SimpleFramework;

namespace CC.UI
{
//	[AddComponentMenu("CC/UI/TabGroup", 36)]
//	[RequireComponent(typeof(RectTransform))]
	public class TabGroup : BaseUI 
	{

		public bool Interactable = true;

		public Action<TabButton> onChange;
		public TabButton select;
		public bool  everySendEvent = false;
		public bool mustSelectOne = false;
		private TabButton _select;
		private bool runUpdate = false;
		
		
		[Serializable]
		public class OnChangeEvent : UnityEvent<TabButton> { }

		[SerializeField]
		private OnChangeEvent m_OnValueChange = new OnChangeEvent();
		
		public OnChangeEvent onValueChange { get { return m_OnValueChange; }  }

	
		void Update () 
		{
			if(_select != select || runUpdate)
			{
				runUpdate = false;
				if(_select != null) _select.IsSelect = false;
				_select =  select;
				if(_select != null) _select.IsSelect = true;

				if(onChange != null) onChange(_select);

				m_OnValueChange.Invoke(_select);
			}
			
		}
		
		public void SetSelect(TabButton val)
		{
			if (!Interactable)
				return;
			
			select = val;
			if(everySendEvent)
			{
				runUpdate = true;
			}
		}

		public TabButton GetSelect()
		{
			return select;
		}

		public void SetMustSelectOne(bool val)
		{
			mustSelectOne = val;
		}

		public bool GetMustSelectOne()
		{
			return mustSelectOne;
		}


		
		private List<LuaFunction> buttons = new List<LuaFunction>();
		/// 添加单击事件
		public void AddChange(LuaFunction luafunc) {

			buttons.Add(luafunc);
			onValueChange.AddListener(
				delegate(TabButton select) {
				luafunc.Call(select);
			}
			);
		}

		/// 清除单击事件
		public void ClearChange() {
			for (int i = 0; i < buttons.Count; i++) {
				if (buttons[i] != null) {
					buttons[i].Dispose();
					buttons[i] = null;
				}
			}
		}

		
		//-----------------------------------------------------------------
		virtual protected void OnDestroy() {
			ClearChange();
			Util.ClearMemory();
		}
	}
}
