using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Module.Menu;


namespace CC.Runtime
{
	public class SceneModule : MonoBehaviour , IModule
	{
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
		
		public void SetParameter(object obj)
		{
			this.parameter = obj;
		}

		virtual protected void Start()
		{
			Enter();
		}
		
		virtual public void Enter()
		{
			_isExit = false;
			OnEnter();
		}


		virtual public void Exit()
		{
			OnExit();
			Coo.menuManager.OpenMenu(MenuType.MainScene);
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
			GameObject.DestroyImmediate(gameObject);
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
