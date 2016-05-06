using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

public class TextEffectNormal : AbstractTextEffect 
{

	
	private static Vector3 BEGION_POSITION = Vector3.zero;
	private static Vector3 IN_POSITION = Vector3.up * 50;
	private static Vector3 OUT_POSITION = Vector3.up * 150;
	public Text text;
	public float inTime = 0.3f;
	public float outTime = 1f;
	public float randomScale = 1;
	private Vector3 beginPosition = Vector3.zero;
	private Vector3 inPosition = Vector3.up * 50;
	private Vector3 outnPosition = Vector3.up * 150;

	private float _t;
	private float _r;
	private Coroutine _coroutine;
	void Start () 
	{
		if(text == null) text = transform.FindChild("Text").GetComponent<Text>();
	}

	override public void Play(object val, Color color)
	{
		text.text = (string) val;
		text.color = color;
		Play();
	}

	[ContextMenu("Play")]
	public void Play()
	{
		_t = 0;
		text.color = text.color.SetAlhpa(0);
		if(_coroutine != null) StopCoroutine(_coroutine);
		if(gameObject.activeInHierarchy)
		{
			_coroutine = StartCoroutine(OnPlay());
		}
	}
	
	IEnumerator OnPlay()
	{
		yield return new WaitForEndOfFrame();
		beginPosition 	= BEGION_POSITION 	+ randomScale * Vector3.left * Random.Range(-10F, 10F);
		inPosition 		= IN_POSITION 		+ randomScale * Vector3.left * Random.Range(-20F, 20F);
		outnPosition 	= OUT_POSITION 		+ randomScale * Vector3.left * Random.Range(-100F, 100F) + Vector3.up *  Random.Range(0F, 50F);


		while(_t < inTime)
		{
			_t += Time.deltaTime;
			_r = _t / inTime;
			text.color = text.color.SetAlhpa(Mathf.Lerp(0, 1, _r));
			text.transform.localPosition = Vector3.Lerp(beginPosition, inPosition, _r);
			yield return new WaitForEndOfFrame();
		}

		_t = 0f;
		while(_t < outTime)
		{
			_t += Time.deltaTime;
			_r = _t / outTime;
			text.color = text.color.SetAlhpa(Mathf.Lerp(1, 0, _r));
			text.transform.localPosition = Vector3.Lerp(inPosition, outnPosition, _r);
			yield return new WaitForEndOfFrame();
		}

		_coroutine = null;
		gameObject.SetActive(false);
		UIFllowWorldPosition uiFllow = gameObject.GetComponent<UIFllowWorldPosition>();
		if(uiFllow != null) uiFllow.enabled = false;

		if(pool != null) pool.Push(this);
	}
}
