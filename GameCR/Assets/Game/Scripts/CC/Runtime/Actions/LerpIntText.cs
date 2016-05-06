using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;
using UnityEngine.UI;


public class LerpIntText : MonoBehaviour
{
	public Text text;
	private float _val = 0;
	public float val = 0;

	public float Value
	{
		get 
		{
			return val;
		}

		set
		{
			val = value;

			if (gameObject.activeSelf && val != _val)
			{
				Play ();
			} 
			else 
			{
				_val = val;
				text.text = Mathf.FloorToInt(_val) + "";
			}

		}
	}


	public float 	time = 1;

	private Coroutine coroutiner;
	private float 	_time = 0;
	private float 	_rate = 0;

	void OnDisable()
	{
		if(coroutiner != null)
		{
			StopCoroutine(coroutiner);
			coroutiner = null;
			_val = val;
			if(text != null) text.text = Mathf.FloorToInt(_val) + "";
		}
	}

	void OnEnable()
	{
		if (_val != val)
			Play ();
	}

	[ContextMenu("Play")]
	public void Play()
	{
		_time = 0;
		if(coroutiner != null) StopCoroutine (coroutiner);
		coroutiner = StartCoroutine (OnPlaying());
	}

	IEnumerator OnPlaying()
	{
		while(_time < time)
		{
			yield return new WaitForSeconds (0.1f);

			_time += 0.1f;
			_rate = _time / time;
			_val = Mathf.Lerp (_val, val, _rate);

			text.text = Mathf.FloorToInt(_val) + "";
		}

	}
}