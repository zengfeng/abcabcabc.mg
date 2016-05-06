using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

public class TextEffectSpot : AbstractTextEffect 
{


	public Image image;
	public Sprite[] sprites = new Sprite[3];

	public float time = 2;
	private Coroutine _coroutine;

	override public void Play(object val, Color color)
	{
		image.sprite = sprites[(int)val];
		Play();
	}

	[ContextMenu("Play")]
	public void Play()
	{
		if(_coroutine != null) StopCoroutine(_coroutine);
		if(gameObject.activeInHierarchy)
		{
			_coroutine = StartCoroutine(OnPlay());
		}
	}
	
	IEnumerator OnPlay()
	{
		yield return new WaitForSeconds(time);

		_coroutine = null;
		gameObject.SetActive(false);
		UIFllowWorldPosition uiFllow = gameObject.GetComponent<UIFllowWorldPosition>();
		if(uiFllow != null) uiFllow.enabled = false;

		if(pool != null) pool.Push(this);
	}
}
