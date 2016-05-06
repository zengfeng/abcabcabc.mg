using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using System;
using CC.Module.Menu;

namespace CC.Module.Loads
{
	public class LoadManager : MonoBehaviour
	{

		public Action prepareFinal;
		public bool isPrepare = false;
		private int index = 0;
		private int count = 0;

		public Dictionary<LoadType, GameObject> prefabDict = new Dictionary<LoadType, GameObject>();
		public Dictionary<LoadType, ProgressPanel> progressPanelDict = new Dictionary<LoadType, ProgressPanel>();
		private Dictionary<string, LoadType> pathDict = new Dictionary<string, LoadType>();
		private Dictionary<string, LoadType> pathDict2 = new Dictionary<string, LoadType>();
		private Dictionary<int, Loader> loaderDict = new Dictionary<int, Loader>();

		
		private Transform root2d
		{
			get
			{
				return GameObject.Find("Canvas").transform;
			}
		}

		public void Init()
		{
			pathDict2.Add("module/Load/CircleLoadPanel", LoadType.Circle);
			pathDict2.Add("module/Load/DarkCircleLoadPanel", LoadType.DarkCircle);
			pathDict2.Add("module/Load/ScreenLoadPanel", LoadType.Screen);

			index = 0;
			count = pathDict2.Count;
			foreach(KeyValuePair<string, LoadType> kvp in pathDict2)
			{
				pathDict.Add(kvp.Key.ToLower(), kvp.Value);
				Coo.assetManager.Load(kvp.Key, OnLoad);
			}

		}

		void OnLoad(string path, System.Object obj)
		{
			LoadType loadType;
			pathDict.TryGetValue(path, out loadType);
			prefabDict.Add(loadType, (GameObject) obj);
			//Debug.Log("LoadManager loadType=" +loadType + "  obj=" + obj + "  path=" + path);

			


			index ++;
			if(index >= count)
			{
				InitProgressPanel();

				isPrepare = true;
				if(prepareFinal != null) prepareFinal();
			}
		}

		void InitProgressPanel()
		{
			foreach(KeyValuePair<string, LoadType> kvp in pathDict2)
			{
				CreateProgressPanel(kvp.Value);
			}
		}

		ProgressPanel CreateProgressPanel(LoadType loadType)
		{
			GameObject prefab = prefabDict[loadType];
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "");
			go.transform.SetParent(root2d, false);
			RectTransform rt = go.transform as RectTransform;
			rt.offsetMin = Vector2.zero;
			rt.offsetMax = Vector2.zero;
			rt.localScale = Vector3.one;
			
			
			ProgressPanel progress = go.GetComponent<ProgressPanel>();
			progressPanelDict.Add(loadType, progress);
			go.gameObject.SetActive(false);
			return progress;
		}


		public Loader LoadPanel(bool isPreInstance, LoadType loadType, List<string> list, Action<Loader> doneCall, Action<Loader> cancelCall, int uid=-1, object bindData = null)
		{

			if(loaderDict.ContainsKey(uid))
			{
				loaderDict[uid].Cancel();
			}

			Loader loader = new Loader();

			if(isPreInstance == false)
			{
				switch(loadType)
				{
				case LoadType.Circle:
				case LoadType.DarkCircle:
				case LoadType.Screen:
					
					ProgressPanel progress;
					if(progressPanelDict.TryGetValue(loadType, out progress) == false && progress == null)
					{
						progress = CreateProgressPanel(loadType);
					}
					progress.Show();
					progress.SetLoader(loader);
					loader.sProgress += progress.SetProgress;
					loader.sDone += progress.Close;
					loader.sCancel += progress.Close;
					break;
				}
			}
			
			loader.uid = uid;
			loader.bindData = bindData;
			loader.list = list;
			if(doneCall != null) loader.sDone += doneCall;
			if(cancelCall != null) loader.sCancel += cancelCall;

			if(uid >= 0)
			{
				loader.sDone += OnDone;
				loader.sCancel += OnDone;
				loaderDict.Add(uid, loader);
			}
			loader.Begin();

			return loader;
		}

		private void OnDone(Loader loader)
		{
			if(loaderDict.ContainsKey(loader.uid))
			{
				loaderDict.Remove(loader.uid);
			}
		}
		
		public void Close(int uid)
		{
			Loader loader;
			if(loaderDict.TryGetValue(uid, out loader))
			{
				loader.Cancel();
			}
		}

		public string preSceneName;
		public string sceneName;
		public int sceneMenuId;
		public bool sceneAutoClose;
		public List<string> sceneList;
		public void LoadScene(string scene,  bool autoClose, int menuId, object parameter, LoadType loadType)
		{
			//			if (GameScene.IsEnter () && GameScene.IsMain (scene))
			if ( GameScene.IsMain (scene))
			{
				if(Coo.loadManager.preSceneName != GameScene.Enter)
				{
					Coo.menuManager.CloseAll();
					Coo.assetManager.UnloadUnusedAssets();
				}
				Application.LoadLevel (scene);
				return;
			}

			preSceneName = Application.loadedLevelName;
			sceneName = scene;
			sceneAutoClose = autoClose;
			sceneMenuId = menuId;
			sceneList = Coo.menuManager.GetPreloadFiles(menuId, parameter);

			Application.LoadLevel(GameScene.GetLoadSceneName(loadType));
		}


		
		public void CloseSceneLoader()
		{
//			Debug.Log("CloseSceneLoader");
			GameObject go = GameObject.Find("ScreenLoadPanel");
			if(go != null)
			{
				SceneLoader loader = go.GetComponent<SceneLoader>();
				loader.Close();
			}
			else
			{
//				Debug.LogError("CloseSceneLoader ScreenLoadPanel = null");
			}
		}

		public void SetSceneLoaderState(string state)
		{
			GameObject go = GameObject.Find("ScreenLoadPanel");
			if(go != null)
			{
				SceneLoader loader = go.GetComponent<SceneLoader>();
				loader.SetState(state);
			}
		}


		public void SetSceneLoaderProgress(float progress)
		{
			GameObject go = GameObject.Find("ScreenLoadPanel");
			if(go != null)
			{
				SceneLoader loader = go.GetComponent<SceneLoader>();
				loader.SetInstallProgress(progress);
			}
		}


	}
}