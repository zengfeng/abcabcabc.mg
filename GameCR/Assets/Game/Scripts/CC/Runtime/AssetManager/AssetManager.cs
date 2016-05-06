using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games;
using System;
using System.IO;
using CC.Runtime.Utils;
using LuaInterface;
using CC.Runtime.signals;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CC.Runtime
{
	public enum ALoadType
	{
		Resource,
		Web
	}
	
	public enum AStatusType
	{
		UnCached,
		Cached,
		Loading,
		Loaded,
		Errored
	}
	
	public class AFileInfo
	{
		public string name;
		public string path;
		public string md5;
		/** 是否是打包的文件 */
		public bool bunld;
		public string assetBundleName;
		/** AssetBundle里主要加载的文件 */
		public string assetName;
		/** 资源清单名称 */
		public string manifestName;
		/** 加载方式 */
		public ALoadType loadType;
		/** 加载状态 */
		public AStatusType status;
		/** 获取资源类型 */
		public Type objType;

		/** 预加载存储对象 */
		public System.Object obj;
		public Dictionary<Type, System.Object> caches = new Dictionary<Type, object>();


		public override string ToString ()
		{
			return string.Format ("[AssetFileInfo] name={0}, path={1}, md5={2}, loadType={3}, status={4}", name, path, md5, loadType, status);
		}
	}



	public partial class AssetManager : MonoBehaviour 
	{

		private static AssetManager _Instance;
		public static AssetManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("GameManagers");
					if(go == null) go = new GameObject("GameManagers");
					
					_Instance = go.GetComponent<AssetManager>();
					if(_Instance == null) _Instance = go.AddComponent<AssetManager>();
				}
				return _Instance;
			}
		}


		private Dictionary<string, AFileInfo> assetFileInfoDict = new Dictionary<string, AFileInfo>();
		private Dictionary<string, AFileInfo> manifestFileInfoDict = new Dictionary<string, AFileInfo>();
		/** manifest里包含的文件 */
		private Dictionary<string, Dictionary<string, AFileInfo>> manifestFileListDict = new Dictionary<string, Dictionary<string, AFileInfo>>();
		private List<AFileInfo> preloads = new List<AFileInfo>();

		public AssetBundle configFileAB;
		
		public bool isPrepare = false;
		public HSignal prepareFinal = new HSignal();

		private bool needUnloadUnusedAssets;

		void Awake()
		{
			_Instance = this;
//			Init();
		}

		public string GetRealURL(string path)
		{
			return PathUtil.DataUrl + path;
		}


		public void Init()
		{
			assetFileInfoDict = new Dictionary<string, AFileInfo>();
#if UNITY_EDITOR
			if (Application.isPlaying == false )
			{
				EditorReadFiles();
				return;
			}
#endif
			StartCoroutine(ReadFiles());
		}


		//==============================================
		// 读取资源文件配置
		//----------------------------------------------
		private IEnumerator ReadFiles()
		{
			TextAsset textAsset = Resources.Load<TextAsset>(GameConst.AssetlistNameForResource);
			if(textAsset != null)
			{
				ParseInfo(textAsset.text, ALoadType.Resource);
			}


			string path = PathUtil.DataUrl + GameConst.Platform_AssetlistNameForStreaming;
			WWW www = new WWW(path);
			yield return www;

			if(string.IsNullOrEmpty(www.error))
			{
				ParseInfo(www.text, ALoadType.Web);
			}

			InitManifest();
		}


		private void ParseInfo(string p, ALoadType loadType)
		{
			using(StringReader stringReader = new StringReader(p))
			{
				bool isEditor = Application.isEditor;
				//stringReader.ReadLine();
				while(stringReader.Peek() >= 0)
				{
					string line = stringReader.ReadLine();
					if(!string.IsNullOrEmpty(line))
					{
						string[] seg = line.Split(';');
						string path = seg[0];
						string md5 = seg[1];
						string name = path.LastIndexOf('.') > 0 ? path.Substring(0, path.LastIndexOf('.')) : path;
						name = name.Replace("{0}/", "").ToLower();
						if(isEditor && !Application.isPlaying)
						{
							path = path.Replace("{0}/", "");
						}
						else
						{
							path = string.Format(path, PathUtil.GetPlatformDirectory(Application.platform));
						}
						if(isEditor)
						{
							if (Application.isPlaying == true)
							{
								if(path.IndexOf("Config/") == 0)
								{
									path = "../Game/" + path;
								}
							}
						}


						AFileInfo fileInfo;
						if(!assetFileInfoDict.TryGetValue(name, out fileInfo))
						{
							fileInfo = new AFileInfo();
							fileInfo.name = name;
							assetFileInfoDict.Add(name, fileInfo);
						}

						fileInfo.path = path;
						fileInfo.md5 = md5;
						fileInfo.loadType = loadType;
						fileInfo.status = AStatusType.UnCached;
						fileInfo.bunld = false;
						if(seg.Length > 2)
						{
							fileInfo.bunld = true;
							fileInfo.assetName = seg[2];
							if(seg.Length > 3) fileInfo.assetBundleName = seg[3];
							if(seg.Length > 4)
							{
								fileInfo.manifestName = seg[4];
								if(!string.IsNullOrEmpty(fileInfo.manifestName))
								{
									Dictionary<string, AFileInfo> manifestFileList;
									if(!manifestFileListDict.TryGetValue(fileInfo.manifestName, out manifestFileList))
									{
										manifestFileList = new Dictionary<string, AFileInfo>();
										manifestFileListDict.Add(fileInfo.manifestName, manifestFileList);
									}

									if(manifestFileList.ContainsKey(fileInfo.assetBundleName))
									{
										Debug.LogFormat("<color=red>manifestFileList[fileInfo.assetBundleName] fileInfo.assetBundleName={0} 已经存在</color>", fileInfo.assetBundleName);
									}

									manifestFileList.Add(fileInfo.assetBundleName, fileInfo);
								}
							}
						}

						if(fileInfo.assetName == "assetbundlemanifest" && !string.IsNullOrEmpty(fileInfo.manifestName))
						{
							manifestFileInfoDict.Add(fileInfo.manifestName, fileInfo);
						}

						if(string.IsNullOrEmpty(fileInfo.assetBundleName))
						{
							fileInfo.assetBundleName = fileInfo.name;
						}

					}
				}
			}
		}

		void PrepareFinal()
		{
			isPrepare = true;
			prepareFinal.Dispatch();
		}




		public void Update () 
		{
			if(needUnloadUnusedAssets)
			{
				needUnloadUnusedAssets = false;
				UnloadUnusedAssets();
			}

			UpdateAssetBundle();
		}
		
		//==============================================
		// 对外加载资源接口
		//----------------------------------------------

		/// <summary>
		/// 卸载没有使用的资源
		/// </summary>
		public void UnloadUnusedAssets()
		{
			for(int i = 0; i < preloads.Count; i ++)
			{
				preloads[i].obj = null;
				preloads[i].caches.Clear();
			}
			preloads.Clear();

			Resources.UnloadUnusedAssets();
			GC.Collect();
		}
		
		/// <summary>
		/// 卸载
		/// </summary>
		/// <param name="filename">文件名.</param>
		public void Unload(string filename)
		{
			Unload(filename, false);
		}

		/// <summary>
		/// 卸载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="force">强制卸载</param>
		public void Unload(string filename, bool force)
		{
			filename = filename.ToLower();
			AFileInfo fileInfo;
			if(!assetFileInfoDict.TryGetValue(filename, out fileInfo) ||  fileInfo.status == AStatusType.Errored)
			{
				return;
			}

			if(fileInfo.loadType == ALoadType.Web && fileInfo.bunld)
			{
				Unload(fileInfo, force);
			}
			else
			{
				fileInfo.obj = null;
				fileInfo.caches.Clear();
			}
			
			needUnloadUnusedAssets = true;
		}

		
		
		/// <summary>
		/// 异步Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		public void LuaLoadAsync(LuaTable table, string filename, LuaFunction callback)
		{
			LuaLoadAsync(table, filename, callback, null, typeof(System.Object));
		}

		
		/// <summary>
		/// 异步Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		public void LuaLoadAsync(LuaTable table, string filename, LuaFunction callback, System.Object arg)
		{
			LuaLoadAsync(table, filename, callback, arg, typeof(System.Object));
		}

		
		/// <summary>
		/// 异步Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		public void LuaLoadAsync(LuaTable table, string filename, LuaFunction callback, System.Object arg, Type type)
		{
			LuaLoad(table, filename, callback, arg, type, true);
		}

		//-----------------------------------

		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		public void LoadAsync(string filename, Action<string, System.Object> callback)
		{
			LoadAsync(filename, (string path, System.Object obj, System.Object arg) => { callback(path, obj); }, null,typeof(System.Object));
		}
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		/// <param name="type">资源类型.</param>
		public void LoadAsync(string filename, Action<string, System.Object> callback, Type type)
		{
			LoadAsync(filename, (string path, System.Object obj, System.Object arg) => { callback(path, obj); }, null,type);
		}
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		public void LoadAsync(string filename, Action<string, System.Object, System.Object> callback)
		{
			LoadAsync(filename, callback, null,typeof(System.Object));
		}
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="type">资源类型.</param>
		public void LoadAsync(string filename, Action<string, System.Object, System.Object> callback, Type type)
		{
			LoadAsync(filename, callback, null,type);
		}
		
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		public void LoadAsync(string filename, Action<string, System.Object, System.Object> callback, System.Object arg)
		{
			LoadAsync(filename, callback, arg, typeof(System.Object));
		}
		
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		public void LoadAsync(string filename, Action<string, System.Object, System.Object> callback, System.Object arg, Type type)
		{
			Load(filename, callback, arg, type, true);
		}


		//-----------------------------------


		/// <summary>
		/// Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		public void LuaLoad(LuaTable table, string filename, LuaFunction callback)
		{
			LuaLoad(table, filename, callback, null,  typeof(System.Object));
		}


		
		/// <summary>
		/// Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		public void LuaLoad(LuaTable table, string filename, LuaFunction callback, System.Object arg)
		{
			LuaLoad(table, filename, callback, arg, typeof(System.Object));
		}

		
		/// <summary>
		/// Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		public void LuaLoad(LuaTable table, string filename, LuaFunction callback, System.Object arg, Type type)
		{
			LuaLoad(table, filename, callback, arg, type, false);
		}

		//-----------------------------------


		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		public void Load(string filename, Action<string, System.Object> callback)
		{
			Load(filename, (string path, System.Object obj, System.Object arg) => { callback(path, obj); }, null,typeof(System.Object));
		}

		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源).</param>
		/// <param name="type">资源类型.</param>
		public void Load(string filename, Action<string, System.Object> callback, Type type)
		{
			Load(filename, (string path, System.Object obj, System.Object arg) => { callback(path, obj); }, null,type);
		}
		
		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		public void Load(string filename, Action<string, System.Object, System.Object> callback)
		{
			Load(filename, callback, null,typeof(System.Object));
		}
		
		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="type">资源类型.</param>
		public void Load(string filename, Action<string, System.Object, System.Object> callback, Type type)
		{
			Load(filename, callback, null,type);
		}

		
		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		public void Load(string filename, Action<string, System.Object, System.Object> callback, System.Object arg)
		{
			Load(filename, callback, arg, typeof(System.Object));
		}

		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		public void Load(string filename, Action<string, System.Object, System.Object> callback, System.Object arg, Type type)
		{
			Load(filename, callback, arg, type, false);
		}

		//--------------------------------------

		/// <summary>
		/// Lua加载
		/// </summary>
		/// <param name="table">模块Table.</param>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		/// <param name="isAsync">异步.</param>
		void LuaLoad(LuaTable table, string filename, LuaFunction callback, System.Object arg, Type type, bool isAsync)
		{
			if(string.IsNullOrEmpty(filename))
			{
				Debug.Log(string.Format("<color=red>AssetManager.LuaLoad filename={0}</color>", filename));
			}
			
			LuaCallback luaCB = new LuaCallback(table, callback);
			Load(filename,  luaCB.AssetLoadCallback, arg, type, isAsync);
		}

		
		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="filename">文件名.</param>
		/// <param name="callback">回调函数(文件名, 资源, 回调参数).</param>
		/// <param name="arg">回调参数.</param>
		/// <param name="type">资源类型.</param>
		/// <param name="isAsync">异步.</param>
		void Load(string filename, Action<string, System.Object, System.Object> callback, System.Object arg, Type type, bool isAsync)
		{
#if UNITY_EDITOR
			if (Application.isPlaying == false )
			{
				EditorLoad(filename, callback, arg, type, isAsync);
				return;
			}
#endif
			
			//			isAsync = true;
			filename = filename.ToLower();
			if(GameConst.DevelopMode == false)
			{
				if(filename.IndexOf("config/") == 0)
				{
					LoadConfig(filename, callback, arg);
					return;
				}
			}


			AFileInfo fileInfo;
			if(!assetFileInfoDict.TryGetValue(filename, out fileInfo) ||  fileInfo.status == AStatusType.Errored)
			{
				Debug.LogWarning("[AssetMananger]\t资源配置不存在或者加载出错 name="+filename + "   fileInfo=" + fileInfo );
				if(callback != null) callback(filename, null, arg);
				return;
			}

			if(fileInfo.bunld)
			{
				Load(fileInfo, callback, arg, type);
			}
			else
			{
				if(type == typeof(System.Object) && fileInfo.obj != null)
				{
                    //Debug.LogFormat("fileInfo.obj={0}  filename={1}", fileInfo.obj, filename);
					callback(filename, fileInfo.obj, arg);
				}
				else if(fileInfo.caches.ContainsKey(type))
				{
					callback(filename, fileInfo.caches[type], arg);
				}
				else
				{
					StartCoroutine(LoadExe(fileInfo, callback, arg, type, isAsync));
				}
			}
		}


		//--------------------------

		IEnumerator LoadExe(AFileInfo fileInfo, Action<string, System.Object, System.Object> callback, System.Object arg, Type type, bool isAsync)
		{

			string filename = fileInfo.name;
			if(fileInfo.loadType == ALoadType.Resource)
			{
				System.Object obj = null;
				if(isAsync == false)
				{
					obj = Resources.Load(fileInfo.path, type);
				}

				else
				{
					ResourceRequest resourceRequest = Resources.LoadAsync(fileInfo.path, type);
					yield return resourceRequest;
					
					obj = resourceRequest.asset;
					resourceRequest = null;
				}

				if(callback != null)
				{
					callback(filename, obj, arg);
				}

				if(!fileInfo.caches.ContainsKey(type)) fileInfo.caches.Add(type, obj);
				obj = null;
				preloads.Add(fileInfo);
			}
			else
			{
				WWW www =  new WWW(GetRealURL(fileInfo.path));
				yield return www;
				if(string.IsNullOrEmpty(www.error))
				{
					if(www.text != null)
					{
						fileInfo.obj = www.text;
					}
					else if(www.texture != null)
					{
						fileInfo.obj = www.texture;
					}
					else if(www.audioClip != null)
					{
						fileInfo.obj = www.audioClip;
					}
					else
					{
						fileInfo.obj = www.bytes;
					}

					if(callback != null) 
					{
						callback(filename, fileInfo.obj, arg);
					}

					preloads.Add(fileInfo);
				}
				else
				{
					fileInfo.status = AStatusType.Errored;
					Debug.LogWarning("[AssetMananger]\t加载资源出错 name="+filename + "   fileInfo=" + fileInfo + "   www.error=" + www.error );
				}

				www.Dispose();
				www = null;
			}
		}


		public void LoadConfig(string filename, Action<string, System.Object, System.Object> callback, System.Object arg)
		{
			if(GameConst.DevelopMode == false)
			{
				if(callback == null) return;

				string assetName = filename.ToLower().Replace("config/", "Assets/Game/ConfigBytes/") + ".txt";
				TextAsset textAsset = (TextAsset)configFileAB.LoadAsset(assetName);
				if(textAsset != null)
				{
					callback(filename, textAsset.text, arg);
				}
				else
				{
					callback(filename, null, arg);
				}
			}
			else
			{
				Load(filename, callback, arg, typeof(System.Object));
			}
		}

#if UNITY_EDITOR

		//==============================================
		// 读取资源文件配置
		//----------------------------------------------
		private void EditorReadFiles()
		{
			TextAsset textAsset = Resources.Load<TextAsset>(GameConst.AssetlistNameForResource);
			if(textAsset != null)
			{
				ParseInfo(textAsset.text, ALoadType.Resource);
			}
			
			
			string path = "Assets/StreamingAssets/" + GameConst.Platform_AssetlistNameForStreaming;
		
			string txt = File.ReadAllText(path);

			if(txt != null)
			{
				ParseInfo(txt, ALoadType.Web);
			}
		}

		void EditorLoad(string filename, Action<string, System.Object, System.Object> callback, System.Object arg, Type type, bool isAsync)
		{

			filename = filename.ToLower();
			AFileInfo fileInfo;
			if(!assetFileInfoDict.TryGetValue(filename, out fileInfo) ||  fileInfo.status == AStatusType.Errored)
			{
				Debug.LogWarning("[AssetMananger]\t资源配置不存在或者加载出错 name="+filename + "   fileInfo=" + fileInfo );
				if(callback != null) callback(filename, null, arg);
				return;
			}

			
			string path = fileInfo.path;
			System.Object obj = null;
			if(path.IndexOf(".") == -1)
			{
				obj = Resources.Load(path, type);
			}
			else
			{
				string root = "";
				if(filename.IndexOf("config/") == 0)
				{
					root = "Assets/Game/";
				}
				else if(filename.IndexOf("unit_prefab/") == 0)
				{
					root = "Assets/Game/Res/";
				}
				else if(filename.IndexOf("war/") == 0)
				{
					root = "Assets/Game/Arts_Modules/Wars/Resources/";
				}
				else
				{
					root = "Assets/Game/Resources/";
				}

				path = root + path;
				path = path.Replace(".assetbundle", ".prefab");

				//Debug.Log(path);
				obj = AssetDatabase.LoadAssetAtPath(path, type);
			}

			if(filename.IndexOf("config/") == 0)
			{
				obj = obj.ToString();
			}
			if(callback != null) callback(filename, obj, arg);
		}
#endif




	}
}