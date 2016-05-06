using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using UnityEngine.UI;

public class TextMenu : MonoBehaviour {

	[MenuItem("GameObject/Convert All Text To Prefab Text", false, 10)]
	public static void ConvertAllTextToPrefabText()
	{
		GameObject obj = Selection.activeGameObject;
		if (obj != null)
		{
			Transform trans = obj.transform;
			Action<Transform> func = null;
			func = (Transform nxt)=>
			{
				Text text = nxt.GetComponent<Text>();
				if (text && text.GetType() != typeof(PrefabText))
				{
					DestroyImmediate(text);
					
					PrefabText prefabText = nxt.gameObject.AddComponent<PrefabText>();
					prefabText = nxt.GetComponent<PrefabText>();
					prefabText.usePrefab = false;
					prefabText.text = text.text;
					prefabText.font = text.font;
					prefabText.fontStyle = text.fontStyle;
					prefabText.fontSize = text.fontSize;
					prefabText.lineSpacing = text.lineSpacing;
					prefabText.supportRichText = text.supportRichText;
					prefabText.alignment = text.alignment;
					prefabText.horizontalOverflow = text.horizontalOverflow;
					prefabText.verticalOverflow = text.verticalOverflow;
					prefabText.resizeTextForBestFit = text.resizeTextForBestFit;
					prefabText.color = text.color;
					prefabText.material = text.material;
				}

				for (int i=0; i<nxt.childCount; i++)
				{
					var child = nxt.GetChild(i);
					func(child);
				}
			};
			func.Invoke(trans);
		}
	}
}