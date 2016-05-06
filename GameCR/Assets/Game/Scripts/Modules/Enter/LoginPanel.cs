using UnityEngine;
using System.Collections;
using System;


namespace Games.Enters
{
	public class LoginPanel : MonoBehaviour 
	{
		public Action OnLogin;
		void Start () {
		
		}

		void Update () {
		
		}

		public void OnClickLogin()
		{
			if(OnLogin != null) OnLogin();
		}

		public void OnClickFastLogin()
		{
			if(OnLogin != null) OnLogin();
		}
	}

}