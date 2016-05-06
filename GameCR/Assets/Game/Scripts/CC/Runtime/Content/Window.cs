using UnityEngine;
using System.Collections;


namespace CC.Runtime
{
	public class Window : MonoBehaviour , IModule
	{
		private bool _isStart;
		private bool _isEnter;
		private bool _isExit;

		protected object parameter;
		public int MenuId{ set; get; }
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
		
		virtual public void SetParameter(object obj)
		{
			this.parameter = obj;
		}

		virtual protected void Start()
		{
			_isStart = true;
			CheckOnEnter();
		}
		
		virtual public void Enter()
		{
			_isEnter = true;
			_isExit = false;
			CheckOnEnter();
		}


		virtual public void Exit()
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

		virtual public void OnEnter()
		{
		}

		virtual public void OnBack()
		{
		}

		virtual public void OnExit()
		{
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
			GameObject.Destroy(gameObject);
		}

		virtual protected void OnDestroy ()
		{
			CheckOnExit();
		}

		public void Back()
		{
		}

	}
}
