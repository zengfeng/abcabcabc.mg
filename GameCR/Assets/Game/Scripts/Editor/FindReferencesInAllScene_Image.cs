using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FindReferencesInAllScene_Image : EditorWindow
{
	public class SceneVO
	{
		public string path;
		public List<ImageVO> list = new List<ImageVO>();
	}

	public class ImageVO
	{
		public SceneVO scene;
		public string path;
		public string prefabPath;
	}

    public class RefPrefab
    {
        public string prefabPath;
        public List<string> refGameObject = new List<string>();
    }

    public class ImageV1
    {
        public string path;
        public Dictionary<string, RefPrefab> refPrefab = new Dictionary<string, RefPrefab>();
    }
	
	[MenuItem ("CC/查找引用--Image", false, 10)]
	static void ShowWindow ()
	{
		FindReferencesInAllScene_Image tm = EditorWindow.GetWindow<FindReferencesInAllScene_Image>("查找应用--Image");
	}
	

	private string sceneFolderStr = "Assets/Game/Arts_Modules;Assets/Game/Scenes";
//	private string sceneFolderStr = "Assets/_ZF";
	public string[] sceneFolders = new string[]{"Assets/Game/Arts_Modules", "Assets/Game/Scenes"};
	public Sprite findSprite;
	public Sprite replaceSprite;
	public List<SceneVO> sceneList = new List<SceneVO>();
	
	private Vector2 scrollPos;
	private bool isSaveScene;
	
	void OnGUI()
	{
		EditorGUILayout.BeginVertical();


		findSprite = EditorGUILayout.ObjectField("查找 Sprite", findSprite, typeof(Sprite), false) as Sprite;
		replaceSprite = EditorGUILayout.ObjectField("替换 Sprite", replaceSprite, typeof(Sprite), false) as Sprite;
		
		GUILayout.Box("查找目录：(用';'分隔)");
		sceneFolderStr = GUILayout.TextArea(sceneFolderStr, 500, GUILayout.MinHeight(50));
		sceneFolderStr = sceneFolderStr.Trim();
		sceneFolders = sceneFolderStr.Split(';');
		isSaveScene = GUILayout.Toggle(isSaveScene, "是否保存场景");

		if (findSprite != null)
		{
			if (GUILayout.Button("查找"))
			{
				sceneList.Clear();
				if(!EditorApplication.SaveCurrentSceneIfUserWantsTo()) return;
				string editorScenePath = EditorApplication.currentScene;
				
				
				
//				string[] guids = AssetDatabase.FindAssets ("t:scene", new string[] {"Assets/Game/Arts_Modules", "Assets/Game/Scenes"});
				string[] guids = AssetDatabase.FindAssets ("t:scene", sceneFolders);
				string activePath = AssetDatabase.GetAssetPath(findSprite);
				Debug.Log("activePath=" + activePath);
				foreach (string guid in guids)
				{
					string scenePath = AssetDatabase.GUIDToAssetPath(guid);
					SceneVO sceneVO = new SceneVO();
					sceneVO.path = scenePath;

					//打开场景
					EditorApplication.OpenScene(scenePath);
					//获取场景中的所有游戏对象
					Image[] images = (Image[])FindObjectsOfTypeAll(typeof(Image));

					foreach(Image image  in images)
					{
						if(image.sprite == null) continue;
						
						string path = AssetDatabase.GetAssetPath(image.sprite);
						if(path == activePath)
						{
							ImageVO imageVO = new ImageVO();
							imageVO.path = GetGameObjectPath(image.gameObject);
							imageVO.scene = sceneVO;
							sceneVO.list.Add(imageVO);
							PrefabType prefabType = PrefabUtility.GetPrefabType(image.gameObject);
							if(prefabType  == PrefabType.PrefabInstance)
							{
								UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(image.gameObject); 
								imageVO.prefabPath = AssetDatabase.GetAssetPath(parentObject);
							}
							else if(prefabType == PrefabType.Prefab)
							{
								imageVO.prefabPath = AssetDatabase.GetAssetPath(image.gameObject);
							}
						}
					}

					if(sceneVO.list.Count > 0)
					{
						sceneList.Add(sceneVO);
					}
				}
				
				if(!string.IsNullOrEmpty(editorScenePath))
					EditorApplication.OpenScene(editorScenePath);
			}
			
			
			if (replaceSprite != null)
			{
				if (GUILayout.Button("替换所有(注意：确认无误后再点击)"))
				{
					sceneList.Clear();
					if(!EditorApplication.SaveCurrentSceneIfUserWantsTo()) return;
					string editorScenePath = EditorApplication.currentScene;
					
					
					
					//				string[] guids = AssetDatabase.FindAssets ("t:scene", new string[] {"Assets/Game/Arts_Modules", "Assets/Game/Scenes"});
					string[] guids = AssetDatabase.FindAssets ("t:scene", sceneFolders);
					string activePath = AssetDatabase.GetAssetPath(findSprite);
					Debug.Log("activePath=" + activePath);
					foreach (string guid in guids)
					{
						string scenePath = AssetDatabase.GUIDToAssetPath(guid);
						SceneVO sceneVO = new SceneVO();
						sceneVO.path = scenePath;
						
						//打开场景
						if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
						{
							EditorApplication.OpenScene(scenePath);
							//获取场景中的所有游戏对象
							Image[] images = (Image[])FindObjectsOfTypeAll(typeof(Image));
							
							foreach(Image image  in images)
							{
								if(image.sprite == null) continue;
								
								string path = AssetDatabase.GetAssetPath(image.sprite);
								if(path == activePath)
								{
									ImageVO imageVO = new ImageVO();
									imageVO.path = GetGameObjectPath(image.gameObject);
									imageVO.scene = sceneVO;
									sceneVO.list.Add(imageVO);
									PrefabType prefabType = PrefabUtility.GetPrefabType(image.gameObject);
									if(prefabType  == PrefabType.PrefabInstance)
									{
										UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(image.gameObject); 
										imageVO.prefabPath = AssetDatabase.GetAssetPath(parentObject);
									}
									else if(prefabType == PrefabType.Prefab)
									{
										imageVO.prefabPath = AssetDatabase.GetAssetPath(image.gameObject);
									}
									
									image.sprite = replaceSprite;
								}
							}
							
							if(sceneVO.list.Count > 0)
							{
								sceneList.Add(sceneVO);
								if(isSaveScene)
								{
									EditorApplication.SaveScene();
								}
							}
						}
					}
					
					if(!string.IsNullOrEmpty(editorScenePath))
					{
						if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
						{
							EditorApplication.OpenScene(editorScenePath);
						}
					}
				}
			}
		}



		GUILayout.Space(30);
		GUILayout.Box("搜索结果：");
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		
		foreach(SceneVO sceneVO in sceneList)
		{
			
			EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button(sceneVO.path))
			{
				if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
				{
					EditorApplication.OpenScene(sceneVO.path);
				}
			}

			if(EditorApplication.currentScene == sceneVO.path)
			{
				if(replaceSprite != null && GUILayout.Button("替换", GUILayout.Width(50)))
				{
					//获取场景中的所有游戏对象
					Image[] images = (Image[])FindObjectsOfTypeAll(typeof(Image));
					
					string activePath = AssetDatabase.GetAssetPath(findSprite);
					foreach(Image image  in images)
					{
						if(image.sprite == null) continue;
						
						string path = AssetDatabase.GetAssetPath(image.sprite);
						if(path == activePath)
						{
							image.sprite = replaceSprite;
							EditorUtility.SetDirty(image);
						}
					}

					if(isSaveScene)
					{
						EditorApplication.SaveScene();
					}
				}
			}
			EditorGUILayout.EndHorizontal();



			//-------------------------
			foreach(ImageVO imageVO in sceneVO.list)
			{
				
				EditorGUILayout.BeginHorizontal();
				GUILayout.Label(imageVO.path);
				
				
				if(!string.IsNullOrEmpty(imageVO.prefabPath) && GUILayout.Button("Prefab",  GUILayout.Width(50)))
				{
					Selection.activeGameObject = AssetDatabase.LoadAssetAtPath<GameObject>(imageVO.prefabPath);
				}


				if(GUILayout.Button("Find",  GUILayout.Width(50)))
				{
					Debug.Log("imageVO.prefabPath = " + imageVO.prefabPath);

					if(EditorApplication.currentScene != sceneVO.path)
					{
						if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
						{
							EditorApplication.OpenScene(sceneVO.path);

							Selection.activeGameObject = GameObject.Find(imageVO.path) ;
						}
					}
					else
					{
						Selection.activeGameObject = GameObject.Find(imageVO.path) ;
					}
				}
				EditorGUILayout.EndHorizontal();
			}
			
			GUILayout.Space(20);
		}
		
		EditorGUILayout.EndScrollView();

		EditorGUILayout.EndVertical();
	}

	
	public static string GetGameObjectPath(GameObject obj)
	{
		string path = "/" + obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}

    [MenuItem ("Assets/删除目录下未引用到的图片")]
    public static void RemoveAllUnrefImage()
    {
        List<string> selectFolder = new List<string>();
        foreach (string sceneGuid in Selection.assetGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(sceneGuid);
//            Debugger.Log("lua print : {0}", path);
            selectFolder.Add(path);
        }

        Dictionary<string, ImageV1> images = new Dictionary<string, ImageV1>();
        string[] imagesGuid = AssetDatabase.FindAssets ("t:texture", selectFolder.ToArray());
        foreach (string iguid in imagesGuid)
        {
            string path = AssetDatabase.GUIDToAssetPath(iguid);
            ImageV1 iv0 = new ImageV1();
            iv0.path = path;
            images.Add(path, iv0);
//            Debugger.Log("lua print: {0}", path);
        }

        string[] prefabFolder = new string[]{"Assets/Game/Arts_Modules", "Assets/Game/Resources"};
        string[] prefabGuid = AssetDatabase.FindAssets("t:prefab", prefabFolder);
        foreach (string iguid in prefabGuid)
        {
            string path = AssetDatabase.GUIDToAssetPath(iguid);
//            images.Add(path);
//            Debugger.Log("lua print: {0}", path);
            GameObject prefabObj = (GameObject)AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
            GameObject insObj = GameObject.Instantiate(prefabObj);
            Component[] imageComps = insObj.GetComponentsInChildren<Image>(true);
            foreach (Component c in imageComps)
            {
                Image img = (Image)c;
                string spritePath = AssetDatabase.GetAssetPath(img.sprite);
                if (images.ContainsKey(spritePath))
                {
                    ImageV1 v = images[spritePath];
                    if (v.refPrefab.ContainsKey(path))
                    {
                        RefPrefab prefab = v.refPrefab[path];
                        prefab.refGameObject.Add(GetGameObjectPath(img.gameObject));
                    }
                    else
                    {
                        RefPrefab prefab = new RefPrefab();
                        prefab.prefabPath = path;
                        prefab.refGameObject.Add(GetGameObjectPath(img.gameObject));
                        v.refPrefab.Add(path, prefab);
                    }
                }
            }
            GameObject.DestroyImmediate(insObj);
        }

        foreach (ImageV1 img in images.Values)
        {
            Debug.LogFormat("lua print : path:{0}", img.path);
            Debug.LogFormat("lua print :   |count:{0}", img.refPrefab.Count);
            foreach(RefPrefab p in img.refPrefab.Values)
            {
                Debug.LogFormat("lua print :     |trefPath:{0}", p.prefabPath);
                foreach(string str in p.refGameObject)
                {
                    Debug.LogFormat("lua print :       |gameObject:{0}", str);
                }
            }
            Debug.Log("lua print : ------------------------------");
        }
        foreach (ImageV1 img in images.Values)
        {
            if (img.refPrefab.Count <= 0)
            {
                Debug.LogWarningFormat("delete file : {0}", img.path);
                AssetDatabase.DeleteAsset(img.path);
            }
        }
    }
}
