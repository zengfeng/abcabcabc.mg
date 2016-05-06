using UnityEngine;
using System.Collections;

public class MiscLuaUtil {

    public static string AssetToString(TextAsset asset)
    {
        return asset.text;
    }

	//不同坐标系下Node1在Node2的本地位置
	public static Vector2 AnchoredPosNode1InNode2Local(RectTransform node1, RectTransform node2)
	{
		Canvas canvas = node1.GetComponentInParent<Canvas>();
		Camera camera = canvas.worldCamera;

		Vector2 screenPos = camera.WorldToScreenPoint(node1.position);
		Vector2 localPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(node2, screenPos, camera, out localPos);
		return localPos;
	}

	public static string FullPathFromCanvas(GameObject obj)
	{
		string path = "/" + obj.transform.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}
}
