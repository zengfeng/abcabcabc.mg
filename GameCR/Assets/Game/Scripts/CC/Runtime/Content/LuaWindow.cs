using UnityEngine;
using System.Collections;
using SimpleFramework;
using CC.Runtime;
using LuaInterface;


namespace CC.Runtime
{
	public class LuaWindow : LuaBehaviour , IModule
	{
		
		private bool _isStart;
		private bool _isEnter;
		private bool _isExit;

		protected object parameter;
		private int _menuId;
		public int MenuId
		{
			get
			{
				return _menuId;
			}

			set
			{
				_menuId = value;
				SetLuaValue("menuId", value);
			}

		}

		public bool IsActive 
		{
			get
			{
				return gameObject.activeSelf;
			}

			
			set
			{
				gameObject.SetActive(value);
			}
		}


		public RectTransform rectTransform
		{
			get
			{
				return gameObject.GetComponent<RectTransform>();
			}
		}
		
		public void SetParameter(object obj)
		{
			this.parameter = obj;
			SetLuaValue("parameter", obj);
			CallMethod("SetParameter", obj);
		}

		
		protected override void Start ()
		{
			if (LuaManager != null && initialize) {
				LuaState l = LuaManager.lua;
				l[name + ".window"] = this;
			}

			base.Start ();
			_isStart = true;
			CheckOnEnter();
		}
		
		public void Enter()
		{
			_isEnter = true;
			_isExit = false;
			CheckOnEnter();
		}


		public void Exit()
		{
			Coo.menuManager.CloseMenu(MenuId);
		}


		
		private void CheckOnEnter()
		{
			if(_isStart && _isEnter)
			{
				OnEnter();
			}
		}
		
		
		public void OnEnter()
		{
			CallMethod("OnEnter");
		}

		public void OnBack()
		{
			if (_isStart)
				CallMethod("OnBack");
		}
		
		public void OnExit()
		{
			CallMethod("OnExit");
		}

		public void OnOpenSubWindow()
		{
			CallMethod("OnOpenSubWindow");
		}

		public void OnCloseSubWindow()
		{
			CallMethod("OnCloseSubWindow");
		}
		
		virtual public void CheckOnExit()
		{
			if(!_isExit)
			{
				_isExit = true;
				OnExit();
			}
		}
		
		public void DestroyModule()
		{
			CheckOnExit();
			
			if(_isStart) CallMethod("DestroyModule");
			gameObject.SetActive(false);
			GameObject.Destroy(gameObject);
		}

		protected override void OnDestroy ()
		{
			CheckOnExit();
			//CallMethod("DestroyModule");

			base.OnDestroy ();
		}

		public void Back()
		{
			Exit();
			Coo.menuManager.Back(MenuId);
		}

		public int GetBackId()
		{
			return Coo.menuManager.GetBackId(MenuId);
		}
	}
}
