using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System;

namespace CC.Runtime
{

	public class ManifestAssetBundleManager : IAssetBundleManager
	{
		// 资源管理
		public AssetManager assetManager;
		// 清单名称
		public string manifestName;
		// 清单路径
		public string manifestPath;
		/** manifest里包含的文件 */
		public Dictionary<string, AFileInfo> fileDict = new Dictionary<string, AFileInfo>();


		// 资源别名列表
		string[] m_Variants = { };
		// 资源包清单
		AssetBundleManifest m_AssetBundleManifest = null;
		// ”资源包信息“ 字典
		Dictionary<string, AssetBundleInfo> m_LoadedAssetBundles = new Dictionary<string, AssetBundleInfo>();
		// WWW 字典
		Dictionary<string, WWW> m_DownloadingWWWs = new Dictionary<string, WWW>();
		// 加载出错 字典
		Dictionary<string, string> m_DownloadingErrors = new Dictionary<string, string>();
		// ”资源包操作“列表
		List<AssetBundleLoadAssetOperation> m_InProgressOperations = new List<AssetBundleLoadAssetOperation>();
		// ”资源包“依赖列表 字典
		Dictionary<string, string[]> m_Dependencies = new Dictionary<string, string[]>();

		/** 获取FileInfo */
		public AFileInfo GetFileInfo(string assetBundleName)
		{
			AFileInfo fileInfo;
			if(fileDict.TryGetValue(assetBundleName, out fileInfo))
			{
				return fileInfo;
			}

			return null;
		}
		
		// 资源别名列表
		// Variants which is used to define the active variants.
		public string[] Variants {
			get { return m_Variants; }
			set { m_Variants = value; }
		}

		public Coroutine StartCoroutine (IEnumerator routine)
		{
			return assetManager.StartCoroutine_Auto (routine);
		}


		public ManifestAssetBundleManager(AssetManager assetManager, string manifestName, string manifestPath, Dictionary<string, AFileInfo> fileDict)
		{
			this.assetManager = assetManager;
			this.manifestName = manifestName;
			this.manifestPath = manifestPath;
			this.fileDict = fileDict;

		}

		public void LoadManifest()
		{
			StartCoroutine(OnLoadManifest());
		}

		IEnumerator OnLoadManifest()
		{
			WWW www = new WWW(assetManager.GetRealURL(manifestPath));
			yield return www;

			if(!string.IsNullOrEmpty(www.error))
			{
				Debug.Log(string.Format("<color=red>[OnLoadManifest] manifest路径不对，或文件不存在 Error={0},  manifestPath={1}, manifestName={2}</color>", www.error, manifestPath, manifestName));
				yield break;
			}

			AssetBundle assetBundle = www.assetBundle;

			AssetBundleRequest  assetBundleRequest  = assetBundle.LoadAssetAsync<AssetBundleManifest>("AssetBundleManifest");
			yield return assetBundleRequest;
			m_AssetBundleManifest = (AssetBundleManifest) assetBundleRequest.asset;

			assetManager.OnLoadManifest(this);
		}

		/** 加载资源 */
		public void LoadAsset(AFileInfo fileInfo, Action<string, System.Object, System.Object> callback, System.Object arg, Type type)
		{
			StartCoroutine(OnLoadAsset(fileInfo, callback, arg, type));
		}

		IEnumerator OnLoadAsset(AFileInfo fileInfo, Action<string, System.Object, System.Object> callback, System.Object arg, Type type)
		{
			LoadAssetBundle(fileInfo);

			AssetBundleLoadAssetOperation request = new AssetBundleLoadAssetOperation(this, fileInfo.assetBundleName, fileInfo.assetName, type);
			m_InProgressOperations.Add(request);
			yield return StartCoroutine(request);

			if (callback != null)
			{
				System.Object obj = request.GetAsset();
				callback(fileInfo.name, obj, arg);
			}
		}

		
		//  加载”资源包“和他依赖的资源包
		// Load AssetBundle and its dependencies.
		void LoadAssetBundle(AFileInfo fileInfo) 
		{
			// 查找别名
//			string assetBundleName = RemapVariantName(fileInfo.assetBundleName);
			
			// Check if the assetBundle has already been processed.
			bool isAlreadyProcessed = LoadAssetBundleInternal(fileInfo);
			
			// Load dependencies.
			if (!isAlreadyProcessed)
				LoadDependencies(fileInfo.assetBundleName);
		}

		
		// 加载依赖资源
		// Where we get all the dependencies and load them all.
		void LoadDependencies(string assetBundleName) {
			if (m_AssetBundleManifest == null) {
				Debug.LogError("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
				return;
			}
			
			// Get dependecies from the AssetBundleManifest object..
			string[] dependencies = m_AssetBundleManifest.GetAllDependencies(assetBundleName);
			if (dependencies.Length == 0)
				return;

			// 查找别名
//			for (int i = 0; i < dependencies.Length; i++)
//				dependencies[i] = RemapVariantName(dependencies[i]);
			
			// Record and load all dependencies.
			m_Dependencies.Add(assetBundleName, dependencies);
			for (int i = 0; i < dependencies.Length; i++)
			{
				AFileInfo fileInfo = GetFileInfo(dependencies[i]);
				if(fileInfo != null)
				{
					LoadAssetBundleInternal(fileInfo);
				}
				else
				{
					Debug.LogError("没有找到依赖的文件 " + dependencies[i]);
				}

			}
		}

		
		// 获取资源包别名
		// Remaps the asset bundle name to the best fitting asset bundle variant.
		string RemapVariantName(string assetBundleName)
		{
			// 获取所有资源包别名列表
			string[] bundlesWithVariant = m_AssetBundleManifest.GetAllAssetBundlesWithVariant();
			
			// 如果没找到别名，就返回自己的名称
			// If the asset bundle doesn't have variant, simply return.
			if (System.Array.IndexOf(bundlesWithVariant, assetBundleName) < 0)
				return assetBundleName;
			
			string[] split = assetBundleName.Split('.');
			
			int bestFit = int.MaxValue;
			int bestFitIndex = -1;
			// Loop all the assetBundles with variant to find the best fit variant assetBundle.
			for (int i = 0; i < bundlesWithVariant.Length; i++) {
				string[] curSplit = bundlesWithVariant[i].Split('.');
				if (curSplit[0] != split[0])
					continue;
				
				int found = System.Array.IndexOf(m_Variants, curSplit[1]);
				if (found != -1 && found < bestFit) {
					bestFit = found;
					bestFitIndex = i;
				}
			}
			
			if (bestFitIndex != -1)
				return bundlesWithVariant[bestFitIndex];
			else
				return assetBundleName;
		}

		
		// 检测是否已经创建了WWW,没有就创建WWW
		// Where we actuall call WWW to download the assetBundle.
		bool LoadAssetBundleInternal(AFileInfo fileInfo) {
			// Already loaded.
			AssetBundleInfo bundle = null;
			m_LoadedAssetBundles.TryGetValue(fileInfo.assetBundleName, out bundle);
			if (bundle != null) {
				bundle.referencedCount++;
				return true;
			}
			
			// @TODO: Do we need to consider the referenced count of WWWs?
			// In the demo, we never have duplicate WWWs as we wait LoadAssetAsync()/LoadLevelAsync() to be finished before calling another LoadAssetAsync()/LoadLevelAsync().
			// But in the real case, users can call LoadAssetAsync()/LoadLevelAsync() several times then wait them to be finished which might have duplicate WWWs.
			if (m_DownloadingWWWs.ContainsKey(fileInfo.assetBundleName))
				return true;
			
			WWW download = null;
			string url =  assetManager.GetRealURL(fileInfo.path);
			
			download = WWW.LoadFromCacheOrDownload(url, m_AssetBundleManifest.GetAssetBundleHash(fileInfo.assetBundleName), 0);
			m_DownloadingWWWs.Add(fileInfo.assetBundleName, download);
			
			return false;
		}

		
		// 卸载资源包和他依赖的资源包
		// Unload assetbundle and its dependencies.
		public void UnloadAssetBundle(string assetBundleName) {
			UnloadAssetBundle(assetBundleName, false);
		}
		
		
		// 卸载资源包和他依赖的资源包
		// Unload assetbundle and its dependencies.
		public void UnloadAssetBundle(string assetBundleName, bool force) {
			//Debug.Log(m_LoadedAssetBundles.Count + " assetbundle(s) in memory before unloading " + assetBundleName);
			
			// 
			bool isUnload = UnloadAssetBundleInternal(assetBundleName, force);
			if(isUnload)
			{
				UnloadDependencies(assetBundleName);
			}
			else
			{
				Debug.LogFormat("<color=yellow>isUnload = false  assetBundleName={0}</color>", assetBundleName);
			}
			
			//Debug.Log(m_LoadedAssetBundles.Count + " assetbundle(s) in memory after unloading " + assetBundleName);
		}
		
		void UnloadDependencies(string assetBundleName) {
			string[] dependencies = null;
			if (!m_Dependencies.TryGetValue(assetBundleName, out dependencies))
				return;
			
			// Loop dependencies.
			foreach (var dependency in dependencies) {
				UnloadAssetBundleInternal(dependency);
			}
			
			m_Dependencies.Remove(assetBundleName);
		}
		bool UnloadAssetBundleInternal(string assetBundleName) {
			return UnloadAssetBundleInternal(assetBundleName, false);
		}
		
		bool UnloadAssetBundleInternal(string assetBundleName, bool force) {
			string error;
			AssetBundleInfo bundle = GetLoadedAssetBundle(assetBundleName, out error);
			if (bundle == null)
				return false;
			
			if (--bundle.referencedCount == 0 || force) {
				bundle.assetBundle.Unload(false);
				m_LoadedAssetBundles.Remove(assetBundleName);
				return true;
				//Debug.Log("AssetBundle " + assetBundleName + " has been unloaded successfully");
			}
			
			return false;

		}
		
		public void Update() {
			// 将要移除的www列表
			// Collect all the finished WWWs.
			var keysToRemove = new List<string>();
			
			// 遍历www
			foreach (var keyValue in m_DownloadingWWWs) {
				WWW download = keyValue.Value;
				
				// 如果加载出错，添加到出错列表，添加到将要移除的WWW列表
				// If downloading fails.
				if (download.error != null) {
					m_DownloadingErrors.Add(keyValue.Key, download.error);
					keysToRemove.Add(keyValue.Key);
					continue;
				}
				
				// 如果加载完成，创建一个“资源包信息”，并添加到将要移除的WWW列表
				// If downloading succeeds.
				if (download.isDone) {
					//Debug.Log("Downloading " + keyValue.Key + " is done at frame " + Time.frameCount);
					m_LoadedAssetBundles.Add(keyValue.Key, new AssetBundleInfo(download.assetBundle));
					keysToRemove.Add(keyValue.Key);
				}
			}
			
			// 移除的www列表里要移除的文件
			// Remove the finished WWWs.
			foreach (var key in keysToRemove) {
				WWW download = m_DownloadingWWWs[key];
				m_DownloadingWWWs.Remove(key);
				download.Dispose();
			}
			
			// 遍历所有加载读取资源操作，移除资源包加载完成的
			// Update all in progress operations
			for (int i = 0; i < m_InProgressOperations.Count; ) {
				if (!m_InProgressOperations[i].Update()) {
					m_InProgressOperations.RemoveAt(i);
				} else i++;
			}
		}

		
		
		// 获取“资源包信息”
		// Get loaded AssetBundle, only return vaild object when all the dependencies are downloaded successfully.
		public AssetBundleInfo GetLoadedAssetBundle(string assetBundleName, out string error) {
			// 如果加载出错，返回空，并返回错
			if (m_DownloadingErrors.TryGetValue(assetBundleName, out error))
				return null;
			
			// 如果”资源信息包“还没找到说明还没加载完成，返回null，让操作继续等待
			AssetBundleInfo bundle = null;
			m_LoadedAssetBundles.TryGetValue(assetBundleName, out bundle);
			if (bundle == null)
				return null;
			
			// 检查是否有依赖的“资源包”列表, 如果没有依赖，成功加载返回“资源包信息”
			// No dependencies are recorded, only the bundle itself is required.
			string[] dependencies = null;
			if (!m_Dependencies.TryGetValue(assetBundleName, out dependencies))
				return bundle;
			
			// 检测依赖的资源包是否加载完成
			// Make sure all dependencies are loaded
			foreach (var dependency in dependencies) {
				// 检测到依赖的资源加载出错，返回自己的资源，并返回依赖的资源错误,
				if (m_DownloadingErrors.TryGetValue(assetBundleName, out error))
					return bundle;
				
				// 如果依赖的资源还没加载完成，返回null，让操作继续等待
				// Wait all the dependent assetBundles being loaded.
				AssetBundleInfo dependentBundle;
				m_LoadedAssetBundles.TryGetValue(dependency, out dependentBundle);
				if (dependentBundle == null)
					return null;
			}
			
			// 成功加载返回“资源包信息”
			return bundle;
		}
    }
}