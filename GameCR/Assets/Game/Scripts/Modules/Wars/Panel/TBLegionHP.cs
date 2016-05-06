using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public class TBLegionHP : MonoBehaviour
	{
		public TBLegionHPItem[] items;
		private int itemCount;
		private Dictionary<int, float> colorHPs = new Dictionary<int, float>();

		void Start()
		{
			itemCount = items.Length;
		}

		void Update () 
		{
			if(!War.isGameing) return;

			int count = War.scene.legionHP.Count;

			colorHPs.Clear();
			foreach(KeyValuePair<int, float> kvp in War.scene.legionHP)
			{
				int colorId = War.GetLegionData(kvp.Key).colorId - 1;
				colorHPs.Add(colorId, kvp.Value);
			}

			for(int i = 0; i < itemCount; i ++)
			{
				TBLegionHPItem item = items[i];
				if(colorHPs.ContainsKey(i))
				{
					float hp = colorHPs[i];
					item.SetData (hp, War.sceneData.legionTotalMaxHP);
				}
			}

		}
	}
}