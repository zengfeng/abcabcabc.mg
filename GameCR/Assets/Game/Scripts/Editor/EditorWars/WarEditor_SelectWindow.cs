using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;


namespace Game.Editors.Wars
{
	public class WarEditor_SelectWindow : EditorWindow
	{
		public static Vector2 windowSize;
		[MenuItem ("关卡/单位选择器 &s", false, 5000)]
		static void Init () {
			WarEditor_SelectWindow window = EditorWindow.GetWindow <WarEditor_SelectWindow>("单位选择器");
			windowSize = window.minSize = window.maxSize = new Vector2(450, 300);
			window.Show();
		}

		
		void OnGUI ()
		{
			if(GameScene.IsWar() == false)
			{
				EditorGUILayout.HelpBox("此窗口只能在“战斗编辑模式”或“战斗”中使用", MessageType.Info);

				return;
			}
			
			Vector2 posrate = windowSize * (1f / 70f);
			Vector2 poscenter = windowSize * 0.5f;

			GameObject caserns  = GameObject.Find("Scene/Caserns");
			if(caserns != null)
			{
				int count = caserns.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = caserns.transform.GetChild(i);

					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					string name = (unitCtl != null && unitCtl.unitData != null) ? "B" + unitCtl.unitData.id : item.gameObject.name;

					Rect position = new Rect(0, 0, 30, 30);
					position.x = item.position.x * posrate.x + poscenter.x - position.width * 0.5f;
					position.y = item.position.z * -1 * posrate.y + poscenter.y - position.height * 0.5f;
					Debug.Log(name + " " + item.position + "  "+ position);
					if (GUI.Button(position, name))
					{
						Selection.activeGameObject = item.gameObject;
					}
				}
			}

			
			GameObject walls  = GameObject.Find("Scene/Walls");

			if(walls != null)
			{
				int count = walls.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = walls.transform.GetChild(i);
					
					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					string name = (unitCtl != null && unitCtl.unitData != null) ? "W" + unitCtl.unitData.id : item.gameObject.name;
					
					Rect position = new Rect(0, 0, 20, 20);
					position.x = item.position.x * posrate.x + poscenter.x - position.width * 0.5f;
					position.y = item.position.z * -1 * posrate.y + poscenter.y - position.height * 0.5f;
					Debug.Log(name + " " + item.position + "  "+ position);
					if (GUI.Button(position, name))
					{
						Selection.activeGameObject = item.gameObject;
					}
				}
			}


		}
	}
}
