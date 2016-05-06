using UnityEngine;
using System.Collections;
using UnityEditor;
using CC.Runtime.Utils;

namespace CC.Editors
{
	public class Achor 
	{

		[MenuItem("CC/AchorSelf")]
		[CanEditMultipleObjects]
		public static void AchorSelf()
		{
			Transform[] list =  Selection.transforms;
			foreach(Transform transform in list)
			{
				if(transform is RectTransform)
				{
					UIUtil.AchorSelf((RectTransform) transform);
				}
			}
		}
	}
}