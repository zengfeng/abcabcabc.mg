using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using Games.Module.Wars;
using System;

namespace CC.Module.Loads
{
	public class SceneLoader : MonoBehaviour 
	{
		/** args=[stateText] */
		public Action<string> sSetState;
		/** args=[progress, index, count, file] */
		public Action<float, int, int, string> sSetProgress;

		public List<string> list = new List<string>();
		public int sceneMenuId;
		public string scene;
		public Loader loader;
		public bool autoClose = true;

		private bool _isStart;
		private bool _isBegin;
		private bool loading;

		public float minLoadTimeDelta = 0;
		private float _beginTime = 0;

		void Start () 
		{

			if(Coo.loadManager.preSceneName != GameScene.Enter)
			{
				Coo.assetManager.UnloadUnusedAssets();
			}

			loading = false;
			if(string.IsNullOrEmpty(scene))
			{
				if(Coo.loadManager.preSceneName != GameScene.Enter)
				{
					Coo.menuManager.CloseAll();
				}
				sceneMenuId = Coo.loadManager.sceneMenuId;
				scene = Coo.loadManager.sceneName;
				list = Coo.loadManager.sceneList;
				autoClose = Coo.loadManager.sceneAutoClose;
				Begin();
			}


			if(!autoClose)
			{
				GameObject.DontDestroyOnLoad(transform.parent.gameObject);
			}


			_isStart = true;
			CheckoutBegin();
		}

		protected AsyncOperation ao;
		protected float progress = 0F;
		private int index = 0;
		private int count = 0;
		private float loadRate = 1;
		private float installRate = 0;
		
		public void Begin()
		{
			index = list.Count;
			count = list.Count + 1;

			if(GameScene.IsWar(scene))
			{
				loadRate = 0.5f;
				installRate = 0.5f;
			}

			_isBegin = true;
			CheckoutBegin();
		}


		
		private void CheckoutBegin()
		{
			if(_isStart && _isBegin)
			{
				BeginList();
			}
		}
		
		private void BeginList()
		{
			SetState("加载中({0}/{1})");
			if(loader == null) loader = new Loader();
			loader.uid = sceneMenuId;
			loader.list = list;
			loader.addIndex = 0;
			loader.addCount = 1;
			loader.isShowFile = false;
			loader.sProgress += SetLoadProgress;
			loader.sDone += LoadDone;
			loader.Begin();

			_beginTime = Time.time;
		}

		private void LoadDone(Loader loader)
		{
			StartCoroutine(LoadScene());
		}


		IEnumerator LoadScene()
		{
			SetState("加载中({0}/{1})");
			SetLoadProgress((float)index/(float)count, index, count, string.Empty);
			ao = Application.LoadLevelAsync(scene);
			ao.allowSceneActivation = false;
			loading = true;
			yield return ao;
		}
		
		virtual protected void Update()
		{
			if(loading && progress < 1)
			{
				UpdateLoadScene();
			}
		}

		virtual protected void UpdateLoadScene()
		{
			if(ao.progress < 0.9F)
			{
				progress = ao.progress;
			}
			else
			{
				if (Time.time - _beginTime >= minLoadTimeDelta)
				{
					progress = 1F;
				}
			}

			SetLoadProgress(progress * 1f / (float)count + ((float)index / (float)count), count, count, string.Empty);

			if(progress == 1)
			{
				ao.allowSceneActivation = true;

				if(autoClose)
				{
					Close();
				}
			}
		}

	

		public void Close()
		{
//			Debug.Log("SceneLoader.Close " + transform.parent);
			GameObject.DestroyImmediate(transform.parent.gameObject);
		}

		virtual public void SetState(string txt)
		{
			if(sSetState != null)
			{
				sSetState(txt);
			}
		}
		
		void SetLoadProgress(float progress, int index, int count, string file)
		{
			SetProgress(progress  * loadRate, index, count, file);
		}
		
		
		
		virtual public void SetInstallProgress(float progress)
		{
			SetProgress(loadRate + progress * installRate, 0, -1, string.Empty);
		}

		
		
		
		virtual public void SetProgress(float progress, int index, int count, string file)
		{
			if(GameScene.IsWar(scene) &&  War.requireSynch)
			{
				War.service.C_LoadProgress(progress);
			}

			if(sSetProgress != null)
			{
				sSetProgress(progress, index, count, file);
			}
		}


	}
}