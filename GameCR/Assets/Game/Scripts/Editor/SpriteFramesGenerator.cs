using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using Games.Module.Avatars;


namespace Game.Editors
{
	public class SpriteFramesGenerator : EditorWindow
	{

	    [MenuItem ("CC/序列帧生成器")]
	    static void ShowWindow()
	    {
	        EditorWindow.GetWindow<SpriteFramesGenerator>("序列帧生成器");
	    }

	    private string actorName;
	    private string actionName;
	    private bool flip = false;
	    private float angle = 0f;

	    void OnGUI()
	    {
	        EditorGUILayout.BeginVertical();
	        {
	            actorName = EditorGUILayout.TextField("角色名称", actorName);
	            actionName = EditorGUILayout.TextField("动作名称", actionName);
	            angle = EditorGUILayout.FloatField("面向角度", angle);
	            flip = EditorGUILayout.Toggle("水平翻转", flip);
	                
	         
	            if (GUILayout.Button("生成"))
	            {
	                List<Sprite> sprites = new List<Sprite>();

	                foreach (Object obj in Selection.objects)
	                {
						Sprite sprite = obj as Sprite;
						if(sprite == null)
						{
							string assetPath = AssetDatabase.GetAssetPath(obj);
							sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
						}

						if (sprite != null)
	                    {
							sprites.Add(sprite);
	                    }
	                }

	                string filename = actorName + "_" + actionName + "_" + angle;
	                string path = EditorUtility.SaveFilePanelInProject("Save", filename, "asset", "message");

	                if (path != "")
	                {
	                    SpriteAnimationClip clip = ScriptableObject.CreateInstance<SpriteAnimationClip>();
	                    clip.flip = flip;
	                    clip.angle = angle;
	                    clip.actionName = actionName;
	                    sprites.Sort(
	                    delegate(Sprite s1, Sprite s2)
	                    {
	                        return s1.name.CompareTo(s2.name);
	                    }
	                    );
	                    clip.frames = sprites.ToArray();

	                    AssetDatabase.CreateAsset(clip, path);
	                
	                    AssetDatabase.SaveAssets();
	                    EditorUtility.FocusProjectWindow();
	                    Selection.activeObject = clip;
	                }
	            }
	        }
	        EditorGUILayout.EndVertical();
	    }
	}
}
