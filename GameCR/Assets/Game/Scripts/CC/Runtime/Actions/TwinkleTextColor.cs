using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;
using UnityEngine.UI;


public class TwinkleTextColor : MonoBehaviour
{
	public Text text;
	public Color a;
	public Color b;



	public float 	time = 1;
	public int 		count = 2;
	public bool		overIsHide = false;

	private Coroutine coroutiner;
	private float 	_time = 0;
	private float 	_rate = 0;
	private int 	_countHalf = 0;
	private bool 	_isPlaying;
	private bool 	_isback = false;


	void OnEnable()
	{
		Play();
	}

	void OnDisable()
	{
		if(coroutiner != null)
		{
			StopCoroutine(coroutiner);
			coroutiner = null;
			_isPlaying = false;
		}
	}


	public void Play()
	{
		_isPlaying = true;
		_countHalf = 0;
		_time = 0;
		_isback = false;
		text.color= a;
		if(coroutiner != null) StopCoroutine(coroutiner);
		coroutiner = StartCoroutine(OnPlay());
	}

	IEnumerator OnPlay()
	{
		while(_isPlaying)
		{
			_time += Time.deltaTime;
			_rate = _time / time;

			if(_isback)
			{
				text.color = Color.Lerp(a, b, _rate);
			}
			else
			{
				text.color = Color.Lerp(b, a, _rate);
			}

			if(_rate >= 1)
			{
				_time = 0;
				_isback = !_isback;
				_countHalf ++;
				if(count != -1)
				{
					if(_countHalf >= count)
					{
						_isPlaying = false;
						break;
					}
				}
			}

			yield return new WaitForEndOfFrame();
		}

		if(overIsHide)
		{
			gameObject.SetActive(false);
		}
	}
}