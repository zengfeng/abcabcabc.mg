using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Games.Module.Wars;
using System;
using System.Reflection;
using UnityEditor.AnimatedValues;
using Games.Module.Avatars;
using Games.Cores;
using CC.Runtime;
using Games.Module.Props;
using System.IO;


namespace Game.Editors.Wars
{

	public class WarEditor_MapIcon
	{
		
		public static string ScenePath = "Assets/Game/Scenes/War-Editor-MapIcon.unity";

		
		public static MeshRenderer meshRenderer;
		public static GameObject map;
		public static GameObject terrains;
		public static List<MapConfig> list;
		private static int index = 0;
		private static string root = "Assets/EditorDefaultResources/MapIcon/";

		[MenuItem ("关卡/生成地图缩列图", false, 5000)]
		static void Init () 
		{
			if(EditorApplication.currentScene != ScenePath)
			{
				if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
				{
					EditorApplication.OpenScene(ScenePath);
				}
				else
				{
					return;
				}
			}

			EditorApplication.isPlaying = true;
		
		}






	}
}
