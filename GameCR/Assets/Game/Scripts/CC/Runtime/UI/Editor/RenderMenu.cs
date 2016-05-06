using UnityEditor;
using UnityEngine;
using System.Collections;
using System;

public class RenderMenu : MonoBehaviour {

	[MenuItem("GameObject/Render/Add Render Layer To All Children", false, 10)]
	public static void ConvertAllTextToPrefabText()
	{
//		GameObject obj = Selection.activeGameObject;
//		if (obj != null)
//		{
//			Transform trans = obj.transform;
//			Action<Transform> func = null;
//			func = (Transform nxt)=>
//			{
//				Text text = nxt.GetComponent<Text>();
//				if (text)
//				{
//					DestroyImmediate(text);
//					
//					PrefabText prefabText = nxt.gameObject.AddComponent<PrefabText>();
//					prefabText = nxt.GetComponent<PrefabText>();
//					prefabText.usePrefab = false;
//					prefabText.text = text.text;
//					prefabText.font = text.font;
//					prefabText.fontStyle = text.fontStyle;
//					prefabText.fontSize = text.fontSize;
//					prefabText.lineSpacing = text.lineSpacing;
//					prefabText.supportRichText = text.supportRichText;
//					prefabText.alignment = text.alignment;
//					prefabText.horizontalOverflow = text.horizontalOverflow;
//					prefabText.verticalOverflow = text.verticalOverflow;
//					prefabText.resizeTextForBestFit = text.resizeTextForBestFit;
//					prefabText.color = text.color;
//					prefabText.material = text.material;
//				}
//				
//				for (int i=0; i<nxt.childCount; i++)
//				{
//					var child = nxt.GetChild(i);
//					func(child);
//				}
//			};
//			func.Invoke(trans);
//		}
	}
}
