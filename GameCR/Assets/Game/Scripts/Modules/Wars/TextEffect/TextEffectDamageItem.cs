using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TextEffectDamageItem : AbstractTextEffect 
{
	public TextEffectDamageContainer container;
	public Text text;
	public float time = 1.2f;
	private Coroutine _coroutiner;


	override public void Play(object val, Color color)
	{
		text.text = (string) val;
		gameObject.SetActive(true);

		if(_coroutiner != null) StopCoroutine(_coroutiner);
		_coroutiner = StartCoroutine(OnEnd());
	}

	IEnumerator OnEnd()
	{
		yield return new WaitForSeconds(time);

		gameObject.SetActive(false);
		if(container != null) container.OnItemEnd(this);
		if(pool != null) pool.Push(this);

	}


}
