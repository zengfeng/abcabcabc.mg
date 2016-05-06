using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class SceneSwitch : EditorWindow {

    class Scene
    {
        public string path;
        public string name;

        public Scene(string p, string n = "None")
        {
            path = p;
            name = n;
        }
    }

    List<Scene> scenes = new List<Scene>();
	private bool _isAdditive = false;
	private Vector2 _scrollPos = new Vector2(0, 0);

    SceneSwitch()
    {
        scenes.Clear();
        scenes.Add(new Scene("Assets/Game/Scenes/Enter.unity", "Enter"));
		scenes.Add(new Scene("Assets/art/module/Common/Text.unity", "Text"));
		scenes.Add(new Scene("Assets/art/module/Common/Card.unity", "Card"));
		scenes.Add(new Scene("Assets/art/module/Common/Window.unity", "Window"));
		scenes.Add(new Scene("Assets/art/module/MainPanel.unity", "MainPanel"));
		scenes.Add(new Scene("Assets/art/module/Home.unity", "Home"));
		scenes.Add(new Scene("Assets/art/module/EmbattlePanel.unity", "Embattle"));
		scenes.Add(new Scene("Assets/art/module/Recruit.unity", "Recruit"));
		scenes.Add(new Scene("Assets/art/module/OpenChest.unity", "OpenChest"));
		scenes.Add(new Scene("Assets/art/module/CardInfo.unity", "CardInfo"));
		scenes.Add(new Scene("Assets/art/module/Shop.unity", "Shop"));
		scenes.Add(new Scene("Assets/art/module/Task.unity", "Task"));
		scenes.Add(new Scene("Assets/art/module/Rank.unity", "Rank"));
		scenes.Add(new Scene("Assets/art/module/SoldierShop.unity", "Soldier"));
		scenes.Add(new Scene("Assets/art/module/Dungeon.unity", "DungeonPanel"));
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [MenuItem ("CC/SceneSwitch", false, 10)]
    static void OpenWindow ()
    {
        EditorWindow.GetWindow<SceneSwitch>("SceneSwitch");
    }

    void OnGUI() {
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

		if (GUILayout.Toggle(_isAdditive, "Additive Mode"))
		{
			_isAdditive = true;
		}
		else
		{
			_isAdditive = false;
		}

        foreach (var scene in scenes)
        {
            if (scene.path == "")
            {
                GUILayout.Space(30);
            }
            else
            {
                if (GUILayout.Button(scene.name))
                {
                    if(EditorApplication.SaveCurrentSceneIfUserWantsTo()) 
                    {
//                        EditorApplication.OpenScene(scene.path);
						if (!_isAdditive)
							EditorSceneManager.OpenScene(scene.path);
						else
							EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Additive);
                    }
                }
            }
        }

		EditorGUILayout.EndScrollView();
    }
}
