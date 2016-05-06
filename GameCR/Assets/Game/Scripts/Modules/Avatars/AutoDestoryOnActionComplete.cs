using UnityEngine;
using System.Collections;
using System;

namespace Games.Module.Avatars
{
	public class AutoDestoryOnActionComplete : MonoBehaviour 
	{
		public Avatara avatar;
		void Start()
		{
			if(avatar == null) avatar = GetComponent<Avatara>();
		}


		void OnEnable()
		{
			if(avatar == null) avatar = GetComponent<Avatara>();
			avatar.sActionComplete += OnActionComplete;
		}

		void OnDisable()
		{
			if(avatar != null) avatar.sActionComplete -= OnActionComplete;
		}

		void OnActionComplete(string action)
		{
			DestroyObject(gameObject);
		}

	}
}