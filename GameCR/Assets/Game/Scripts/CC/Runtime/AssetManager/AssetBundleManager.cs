using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System;

namespace CC.Runtime
{

	public interface IAssetBundleManager
	{
		void LoadAsset(AFileInfo fileInfo, Action<string, System.Object, System.Object> callback, System.Object arg, Type type);
		void UnloadAssetBundle(string assetBundleName);
		void UnloadAssetBundle(string assetBundleName, bool force);
		void Update();
		AssetBundleInfo GetLoadedAssetBundle(string assetBundleName, out string error);
	}

	public class AssetBundleManager : IAssetBundleManager
	{
		// 资源管理
		public AssetManager assetManager;

		// ”资源包信息“ 字典
		Dictionary<string, AssetBundleInfo> m_LoadedAssetBundles = new Dictionary<string, AssetBundleInfo>();
		// WWW 字典
		Dictionary<string, WWW> m_DownloadingWWWs = new Dictionary<string, WWW>();
		// 加载出错 字典
		Dictionary<string, string> m_DownloadingErrors = new Dictionary<string, string>();
		// ”资源包操作“列表
		List<AssetBundleLoadAssetOperation> m_InProgressOperations = new List<AssetBundleLoadAssetOperation>();



		public Coroutine StartCoroutine (IEnumerator routine)
		{
			return assetManager.StartCoroutine_Auto (routine);
		}


		public AssetBundleManager(AssetManager assetManager)
		{
			this.assetManager = assetManager;
		}


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
			bool isAlreadyProcessed = LoadAssetBundleInternal(fileInfo);
		}

		
		// 检测是否已经创建了WWW,没有就创建WWW
		// Where we actuall call WWW to download the assetBundle.
		bool LoadAssetBundleInternal(AFileInfo fileInfo) {
			string assetBundleName = fileInfo.assetBundleName;
			// Already loaded.
			AssetBundleInfo bundle = null;
			m_LoadedAssetBundles.TryGetValue(assetBundleName, out bundle);
			if (bundle != null) {
				bundle.referencedCount++;
				return true;
			}
			
			// @TODO: Do we need to consider the referenced count of WWWs?
			// In the demo, we never have duplicate WWWs as we wait LoadAssetAsync()/LoadLevelAsync() to be finished before calling another LoadAssetAsync()/LoadLevelAsync().
			// But in the real case, users can call LoadAssetAsync()/LoadLevelAsync() several times then wait them to be finished which might have duplicate WWWs.
			if (m_DownloadingWWWs.ContainsKey(assetBundleName))
				return true;
			
			WWW download = null;
			string url =  assetManager.GetRealURL(fileInfo.path);
			
			download = WWW.LoadFromCacheOrDownload(url, Hash128.Parse(fileInfo.md5), 0);
			m_DownloadingWWWs.Add(assetBundleName, download);
			
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
			UnloadAssetBundleInternal(assetBundleName, force);
		}

		
		void UnloadAssetBundleInternal(string assetBundleName, bool force) {
			string error;
			AssetBundleInfo bundle = GetLoadedAssetBundle(assetBundleName, out error);
			if (bundle == null)
				return;
			
			if (--bundle.referencedCount == 0 || force) {
				bundle.assetBundle.Unload(false);
				m_LoadedAssetBundles.Remove(assetBundleName);
//				Debug.Log("AssetBundle " + assetBundleName + " has been unloaded successfully");
			}
			else
			{
				Debug.Log("AssetBundle " + assetBundleName + " has been unloaded fail bundle.referencedCount=" + bundle.referencedCount);
			}
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

			
			// 成功加载返回“资源包信息”
			return bundle;
		}
    }
}