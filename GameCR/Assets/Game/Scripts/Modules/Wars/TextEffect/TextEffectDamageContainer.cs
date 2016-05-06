using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Wars;



public class TextEffectDamageContainer : AbstractTextEffect
{
	public TextEffectPool itemPool;
	public Vector2 offset = new Vector2(20, 0);
	public Vector2 gapOffset = new Vector2(10, 15);
	public List<AbstractTextEffect> actives;



	override public void Play(object val, Color color)
	{
		if(itemPool == null) itemPool = War.textEffect.damageItemPool;

		TextEffectDamageItem item = (TextEffectDamageItem) itemPool.Get();
		item.transform.SetParent(transform, false);
		RectTransform itemRectTransform=(RectTransform) item.transform;
		itemRectTransform.anchoredPosition = offset;
		itemRectTransform.SetAsLastSibling();


		int count = actives.Count;
		for(int i = 0; i < count; i++)
		{
			(actives[i].transform as RectTransform).anchoredPosition =offset + gapOffset * (count - i + 1);
		}
		item.gameObject.name = "TextEffect-Damage-" + actives.Count;
		item.container = this;
		item.Play(val);
		actives.Add(item);
	}

	public void OnItemEnd(AbstractTextEffect item)
	{
		if(actives.Contains(item))
		{
			actives.Remove(item);
		}

		if(actives.Count == 0)
		{
			gameObject.SetActive(false);
			pool.Push(this);
		}
	}
}
