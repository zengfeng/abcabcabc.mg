using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using CC.Runtime.Utils;
using Games.Module.Wars;

public class BeginTimeText : MonoBehaviour 
{
	public Image				image;
	public RectTransform 		scale;
	public Text 				text;

	public int 	count = 3;
	public float onceTime = 1f;


	void Start () 
	{
		if(War.isGameing)
		{
			Init();
		}
		else
		{
			War.signal.sGameBegin += Init;
		}
	}
	
	
	void OnDestroy()
	{
		War.signal.sGameBegin -= Init;
	}
	
	void Init()
	{
		if(War.sceneData.begionDelayTime > 0)
		{
			count = War.sceneData.begionDelayTime - 1;
			Play();
		}
		else
		{
			gameObject.SetActive(false);
		}

	}

	[ContextMenu("Play")]
	public void Play()
	{
		War.scene.MaskVisiable = true;

		scale.transform.localScale = Vector3.zero;
		scale.gameObject.SetActive(true);
		text.color = text.color.SetAlhpa(0);
		image.color = image.color.SetAlhpa(0.3f);

		gameObject.SetActive(true);
		StopAllCoroutines();
		StartCoroutine(OnPlay());
	}

	IEnumerator OnPlay()
	{
		float showTime = 0.3f * onceTime;
		float waitTime = 0.5f * onceTime;
		float hideTime = 0.2f * onceTime;
		yield return new WaitForSeconds(1.2f);

		for(int i = count; i >= 0; i --)
		{
			switch(i)
			{
			case 0:
				text.text = "s";
				break;
			case 1:
				text.text = "r";
				break;
			default:
				text.text = i.ToString();
				break;
			}

			scale.transform.localScale = Vector3.zero;
			text.color = text.color.SetAlhpa(0);

			scale.transform.DOScale(Vector3.one, showTime);
			text.DOFade(1, showTime * 0.5f);

			yield return new WaitForSeconds(showTime + waitTime);
			if(i > 0)
			{
				scale.transform.DOScale(Vector3.zero, hideTime);
				text.DOFade(0, hideTime * 0.8f);
			}

			yield return new WaitForSeconds(hideTime);
		}
		
		if(War.isPlaying) War.scene.MaskVisiable = false;
		
		image.DOFade(0, 0.1F);
		text.DOFade(0, 0.1f).OnComplete(()=>{
			gameObject.SetActive(false);


			scale.transform.localScale = Vector3.zero;
			text.color = text.color.SetAlhpa(0);

		});

	}


}
