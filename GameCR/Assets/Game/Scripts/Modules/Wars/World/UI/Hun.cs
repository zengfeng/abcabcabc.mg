using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

public class Hun : MonoBehaviour 
{
	public HunManager manager;
	public SpriteRenderer spriteRenderer;
	public float delay = 0f;
	public float time = 1f;
	public float delayAlphaTime = 0.5f;
	public float delayPositionTime = 0.5f;
	public float initHeight = 1;
	public float height = 5;
	private float _initWidthScale = 0;
	public float widthScale = 5;
	public float width = 5;
	public Color color = Color.white;

	private float _time = 0;
	private float _rate = 0;
	private float _begionX;
	private float _begionY;
	private Vector3 position;
	private Color _color;
	public Vector3 scaleBegin = Vector3.one;
	public Vector3 scaleEnd = new Vector3(0.5f, 2f, 0.5f);


	void Start () 
	{
		if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
		Play();
	}

	void Update () 
	{
	
	}

	public void Play()
	{
		if(spriteRenderer == null) return;
		transform.position = transform.position.SetY(initHeight);
		position = transform.position;

		//transform.localScale = scaleBegin;
		
		_color = color;
		spriteRenderer.color = _color;
		spriteRenderer.color = spriteRenderer.color.SetAlhpa(0);

		_initWidthScale = Random.Range(-1f, 1f);
		_begionX = position.x;
		_begionY = position.y;
		_time = 0;
		_rate = 0;
		
		gameObject.SetActive(true);
		StartCoroutine(OnPlay());
	}

	IEnumerator OnPlay()
	{
		yield return new WaitForSeconds(delay);
		spriteRenderer.color = spriteRenderer.color.SetAlhpa(1);

		while(true)
		{
			yield return new WaitForEndOfFrame();
			_time += Time.deltaTime;
			_rate = _time / time;
			//transform.localScale = Vector3.Lerp(scaleBegin, scaleEnd, _rate);

			if(_time >= delayAlphaTime)
			{
				_color.a = Mathf.Lerp(1, 0, (_time - delayAlphaTime) / (time-delayAlphaTime));
				spriteRenderer.color = _color;
			}

			if(_time >= delayPositionTime)
			{
				transform.position = position.SetY(_begionY + Mathf.Lerp(0, height,  (_time - delayPositionTime) / (time-delayPositionTime))).SetX(_begionX + Mathf.Sin((_initWidthScale + _rate) * widthScale * _rate * 0.5f) * width * _rate * 0.5f);
			}

			if(_time >= time)
			{
				break;
			}
		}


		gameObject.SetActive(false);
		if(manager != null) manager.OnOver(this);
	}

}
