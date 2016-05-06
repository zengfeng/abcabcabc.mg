using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace CC.Runtime
{
	public class AssetBundleInfo
	{
		public AssetBundle assetBundle;
		public int referencedCount;

		public AssetBundleInfo(AssetBundle assetBundle)
		{
			this.assetBundle = assetBundle;
			referencedCount = 1;
		}
	}

	public class AssetBundleLoadAssetOperation : IEnumerator
	{
		public IAssetBundleManager		assetBundleManager;
		// 资源包名称
		protected string 				m_AssetBundleName;
		// 资源名
		protected string 				m_AssetName;
		// 加载出错文本
		protected string 				m_DownloadingError;
		// 资源Class类型
		protected System.Type 			m_Type;
		// 从“资源包”加载“资源”的异步请求柄
		protected AssetBundleRequest	m_Request = null;
		
		// 构造（资源包名称, 资源名, 资源Class类型）
		public AssetBundleLoadAssetOperation(IAssetBundleManager assetBundleManager, string bundleName, string assetName, System.Type type)
		{
			this.assetBundleManager = assetBundleManager;
			m_AssetBundleName = bundleName;
			m_AssetName = assetName;
			m_Type = type;
		}
		
		// 获取加载完成的资源
		public System.Object GetAsset()
		{
			if (m_Request != null && m_Request.isDone)
				return m_Request.asset;
			else
				return null;
		}


		//===================
		// 实现IEnumerator接口方法
		//-------------------
		public object Current
		{
			get
			{
				return null;
			}
		}
		public bool MoveNext()
		{
			return !IsDone();
		}
		
		public void Reset()
		{ 
		}

		// 检测“资源包”是否加载完成，加载完成就异步读取"资源"，返回false终止update
		// Returns true if more Update calls are required.
		public bool Update ()
		{
			// 已经存在异步读取"资源"手柄，说明“资源包”加载完成，返回false终止update
			if (m_Request != null)
				return false;
			
			
			// 获取“资源包信息”
			AssetBundleInfo bundle = assetBundleManager.GetLoadedAssetBundle(m_AssetBundleName, out m_DownloadingError);
			if (bundle != null)
			{
				// 从“资源包”异步读取"资源"
				m_Request = bundle.assetBundle.LoadAssetAsync(m_AssetName, m_Type);
				// “资源包”加载完成，返回false终止update
				return false;
			}
			else
			{
				return true;
			}
		}
		
		
		// 检测资源是否加载和读取完成
		public bool IsDone ()
		{
			// 如果加载“资源包”加载出错，抛出一个错误LOG,并返回加载完成
			// Return if meeting downloading error.
			// m_DownloadingError might come from the dependency downloading.
			if (m_Request == null && m_DownloadingError != null)
			{
				Debug.LogError(m_DownloadingError);
				return true;
			}
			
			return m_Request != null && m_Request.isDone;
		}

	}


	public partial class AssetManager
	{
		AssetBundleManager assetBundleManager;
		Dictionary<string, ManifestAssetBundleManager> manifestAssetBundleManagerDict = new Dictionary<string, ManifestAssetBundleManager>();
		List<IAssetBundleManager> assetBundleManagerList = new List<IAssetBundleManager>();
		int assetBundleManagerCount = 0;
		int manifestCount = 0;
		int manifestLoadedCount = 0;


		void InitManifest()
		{
			assetBundleManager = new AssetBundleManager(this);
			assetBundleManagerList.Add(assetBundleManager);

			foreach(KeyValuePair<string, AFileInfo> kvp in manifestFileInfoDict)
			{
				AFileInfo fileInfo = kvp.Value;
				Debug.Log(kvp.Key);
				ManifestAssetBundleManager manifestAssetBundleManager = new ManifestAssetBundleManager(this, fileInfo.manifestName, fileInfo.path, manifestFileListDict[fileInfo.manifestName]);
				manifestAssetBundleManagerDict.Add(manifestAssetBundleManager.manifestName, manifestAssetBundleManager);
				assetBundleManagerList.Add(manifestAssetBundleManager);
			}
			manifestCount = manifestAssetBundleManagerDict.Count;
			assetBundleManagerCount = assetBundleManagerList.Count;

			foreach(KeyValuePair<string, ManifestAssetBundleManager> kvp in manifestAssetBundleManagerDict)
			{
				kvp.Value.LoadManifest();
			}

			if(manifestCount == 0)
			{
				PrepareFinal();
			}
		}

		internal void OnLoadManifest(IAssetBundleManager manifest)
		{
			manifestLoadedCount ++;
			if(manifestLoadedCount == manifestCount)
			{
				PrepareFinal();
			}
		}

		void UpdateAssetBundle()
		{
			for(int i = 0; i < assetBundleManagerCount; i ++)
			{
				assetBundleManagerList[i].Update();
			}
		}

		void Unload(AFileInfo fileInfo)
		{
			Unload(fileInfo, false);
		}

		void Unload(AFileInfo fileInfo, bool force)
		{
			ManifestAssetBundleManager manifest;
			if(!string.IsNullOrEmpty(fileInfo.manifestName) && manifestAssetBundleManagerDict.TryGetValue(fileInfo.manifestName, out manifest))
			{
				manifest.UnloadAssetBundle(fileInfo.assetBundleName, force);
			}
			else
			{
				assetBundleManager.UnloadAssetBundle(fileInfo.assetBundleName, force);
			}
		}

		void Load(AFileInfo fileInfo, Action<string, System.Object, System.Object> callback, System.Object arg, Type type)
		{
			ManifestAssetBundleManager manifest;
			if(!string.IsNullOrEmpty(fileInfo.manifestName) && manifestAssetBundleManagerDict.TryGetValue(fileInfo.manifestName, out manifest))
			{
				manifest.LoadAsset(fileInfo, callback, arg, type);
			}
			else
			{
				assetBundleManager.LoadAsset(fileInfo, callback, arg, type);
			}

		}
 	
	}




}