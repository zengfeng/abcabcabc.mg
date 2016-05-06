using UnityEngine;
using System.Collections;
using CC.UI;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class LegionHP : MonoBehaviour
	{
		public LegionHPItem[] items;
		public float maxWidth = 920f;
		public float itemMinWidth = 100f;
		private Dictionary<int, float> colorHPs = new Dictionary<int, float>();
		private int itemCount;
		void Awake () 
		{
			itemCount = items.Length;

			if(Setting.TotalHP == false)
			{
				gameObject.SetActive(false);
			}

			War.signal.sBuildComplete += OnBuildComplete;
		}

		void OnDestroy()
		{
			War.signal.sBuildComplete -= OnBuildComplete;
		}

		void OnBuildComplete()
		{
			if(War.vsmode == VSMode.PVE_Expedition && gameObject.activeSelf)
			{
				gameObject.SetActive(false);
			}
		}


		void Update () 
		{
			if(!War.isGameing) return;
			float totalWidth = 0f;
			
			int count = War.scene.legionHP.Count;
			float itemMaxWidth = maxWidth - (count -1) * itemMinWidth;



			colorHPs.Clear();
			foreach(KeyValuePair<int, float> kvp in War.scene.legionHP)
			{
				int colorId = War.GetLegionData(kvp.Key).colorId - 1;
				colorHPs.Add(colorId, kvp.Value);
			}

			for(int i = 0; i < itemCount; i ++)
			{
				LegionHPItem item = items[i];
				if(colorHPs.ContainsKey(i))
				{
					float hp = colorHPs[i];
					item.SetNum(hp);
					item.SetX(totalWidth);
					float rate = hp / War.scene.totalHP;
					float width = rate * maxWidth;
					if(width < itemMinWidth) width = itemMinWidth;
					if(width > maxWidth - totalWidth) width = maxWidth - totalWidth;
					if(width > itemMaxWidth) width = itemMaxWidth;
					totalWidth += width;
					item.SetWidth(width);
					if(!item.gameObject.activeSelf) item.gameObject.SetActive(true);
				}
				else if(item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(false);
				}
			}

		}
	}
}