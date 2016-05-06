using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TextEffectPool : MonoBehaviour 
{
	public AbstractTextEffect prefab;
	public TextEffectManager textEffectManager;
	public Stack<AbstractTextEffect> pool = new Stack<AbstractTextEffect>();

	public AbstractTextEffect Get()
	{
		AbstractTextEffect item;
		if(pool.Count > 0)
		{
			item = pool.Pop();
		}
		else
		{
			item = GameObject.Instantiate(prefab).GetComponent<AbstractTextEffect>();
			item.pool = this;
		}
		return item;
	}

	public void Push(AbstractTextEffect item)
	{
		
		UIFllowWorldPosition uiFllow = item.GetComponent<UIFllowWorldPosition>();
		if(uiFllow != null) uiFllow.enabled = false;
		pool.Push(item);

		if(textEffectManager != null) textEffectManager.OnOver(item);
	}


	public void Clear()
	{
		prefab = null;
		pool.Clear();
	}
}
