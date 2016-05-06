#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;

public class WE_Scene : MonoBehaviour 
{
	
	private static GUIStyle style;
	private static GUIStyle Style{
		get{
			if(style == null){
				style = new GUIStyle( EditorStyles.largeLabel );
				style.alignment = TextAnchor.MiddleCenter;
				style.normal.textColor = new Color(0.9f,0.9f,0.9f);
				style.fontSize = 32;
			}
			return style;
		}
		
	}

	public static bool isShow = true;

	
	void OnDrawGizmos()
	{
		return ;
		if(isShow)
		{
			GameObject root  = GameObject.Find("Scene/Caserns");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = root.transform.GetChild(i);
					
					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					DrawUnit(unitCtl);
				}
			}
			
			root  = GameObject.Find("Scene/Walls");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = root.transform.GetChild(i);
					
					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					DrawUnit(unitCtl);
				}
			}
		}
	}

	void DrawUnit(UnitCtl unitCtl)
	{
		if(unitCtl.gameObject.activeSelf == false) return;

		string text = unitCtl.unitData == null ? unitCtl.gameObject.name : unitCtl.unitData.GetName() ;
		Transform transform = unitCtl.transform;
		RaycastHit hit;
		Ray r = new Ray(transform.position + Camera.current.transform.up * 8f, -Camera.current.transform.up );

		Collider collider = transform.GetComponent<Collider>();
		if(collider == null)
		{
			collider = transform.GetComponentInChildren<Collider>();
		}

		if(collider != null && collider.Raycast( r, out hit, Mathf.Infinity) ){
			
			float dist = (Camera.current.transform.position - hit.point).magnitude;
			
			float fontSize = Mathf.Lerp(64, 12, dist/10f);
			
			Style.fontSize = (int)fontSize;
			
			Vector3 wPos = hit.point ;
			if(Camera.current.orthographic == false)
			{
				wPos += Camera.current.transform.up*dist*0.07f;
			}
			else
			{
				wPos += Camera.current.transform.up*dist*0.01f;
			}

			
			
			Vector3 scPos = Camera.current.WorldToScreenPoint(wPos);
			if(scPos.z <= 0){
				return;
			}
			
			
			
			float alpha = Mathf.Clamp(-Camera.current.transform.forward.y, 0f, 1f);
			alpha = 1f-((1f-alpha)*(1f-alpha));
			
			alpha = Mathf.Lerp(-0.2f,1f,alpha);
			
			Handles.BeginGUI();
			
			
			scPos.y = Screen.height - scPos.y; // Flip Y
			
			
			Vector2 strSize = Style.CalcSize(new GUIContent(text));
			
			Rect rect = new Rect(0f, 0f, strSize.x + 6,strSize.y + 4);
			rect.center = scPos - Vector3.up*rect.height*0.5f;
			GUI.color = new Color(0f,0f,0f,0.8f * alpha);
			GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
			GUI.color = Color.white;
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.Label(rect, text, Style);
			GUI.color = Color.white;
			
			Handles.EndGUI();
		}
	}

}

#endif