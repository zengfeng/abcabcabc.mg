#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;
using System.Collections.Generic;
using System.IO;

public class WE_MapIcon : MonoBehaviour 
{
	
	public MeshRenderer meshRenderer;
	public GameObject map;
	public GameObject terrains;
	public List<MapConfig> list;
	private int index = 0;
	private string root = "Assets/EditorDefaultResources/MapIcon/";

	void Awake()
	{
		map = GameObject.Find("Map");
		terrains = GameObject.Find("Terrains");
		meshRenderer = map.GetComponent<MeshRenderer>();
		
		list = new List<MapConfig>();
		
		TextAsset obj = (TextAsset) AssetDatabase.LoadAssetAtPath("Assets/Game/Config/stage_map.csv", typeof(TextAsset));
		string text = obj.text;
		
		StringReader stringReader = new StringReader(text);
		stringReader.ReadLine();
		stringReader.ReadLine();
		while(true)
		{
			string line = stringReader.ReadLine();
			if (line == null)
			{
				break;
			}
			string[] csv = line.Split(';');
			if (csv.Length != 0 && !string.IsNullOrEmpty(csv[0]))
			{
				MapConfig mapConfig = new MapConfig();
				mapConfig.ParseCsv(csv, false);
				list.Add(mapConfig);
			}
		}
		
		index = 0;
		StartCoroutine(Doing());
	}

	IEnumerator Doing()
	{
		for(int i = 0; i < list.Count; i ++)
		{
			yield return new WaitForEndOfFrame();
			OpenMap(list[i]);
			yield return new WaitForEndOfFrame();
		}

		
		EditorApplication.isPlaying = false;
		AssetDatabase.Refresh();
		Application.OpenURL("file:///" + Application.dataPath + "../Assets/EditorDefaultResources/MapIcon");
	}

	void OpenMap(MapConfig mapConfig)
	{
		Clear();
		
		if(mapConfig.id < 100)
		{
			meshRenderer.sharedMaterial.mainTexture = Resources.Load<Texture2D>(mapConfig.terrain);
			map.SetActive(true);
			terrains.SetActive(false);
		}
		else
		{
			GameObject prefab = Resources.Load<GameObject>(mapConfig.terrain);
			GameObject go = GameObject.Instantiate(prefab);
			go.transform.SetParent(terrains.transform);
			go.transform.position = Vector3.zero;
			map.SetActive(false);
			terrains.SetActive(true);
			
			//				Transform map = go.transform.Find("Map");
			//				if(map != null)
			//				{
			//					MeshRenderer mapRenderer = map.GetComponent<MeshRenderer>();
			//					if(mapRenderer != null)
			//					{
			//						mapRenderer.sharedMaterial.shader = Shader.Find("ihaiu/Terrain_3Texture_1Shade");
			//					}
			//				}
		}
		
		PathUtil.CheckPath(root, false);
		string filename = root + mapConfig.id + ".png";
		ScreenshotTool.Shot(Camera.main, 150, 100, false, filename);
		
	}
	
	
	
	void Clear()
	{
		HUnityUtil.DestroyImmediateChilds(terrains);
		meshRenderer.sharedMaterial.mainTexture = null;
		
		meshRenderer.gameObject.SetActive(true);
		terrains.SetActive(true);
	}



}

#endif