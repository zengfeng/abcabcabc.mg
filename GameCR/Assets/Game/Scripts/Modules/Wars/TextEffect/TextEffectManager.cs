using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;
using System.Collections.Generic;
using Games.Module.Wars;

public class TextEffectManager : MonoBehaviour
{
	public TextEffectPool 			normalPool;
	public TextEffectPool 			damagePool;
	public TextEffectPool 			damageItemPool;
	public TextEffectPool 			spotPool;
	public Dictionary<TextEffectType, TextEffectPool> poolDict = new Dictionary<TextEffectType, TextEffectPool>();
	public Dictionary<System.Object, AbstractTextEffect> uidTextEffectDict = new Dictionary<object, AbstractTextEffect>();

	public Camera mainCamera;

	public float devWidth = 1920f;
	public float devHeight = 1280f;
	public float devAspect;
	private float screenWidth = 0;
	private float screenHeight = 0;
	private float rate = 1;

	public Vector3 offset_Build = new Vector3(0f, 2f, 0f);
	public Vector3 offset_Solider = new Vector3(0f, 1f, 0f);
	public Color colorHP_Plus = Color.green;
	public Color colorHP_Minus = Color.red;

	void Start()
	{

		poolDict.Add(TextEffectType.Normal, normalPool);
		poolDict.Add(TextEffectType.Damage, damagePool);
		poolDict.Add(TextEffectType.Spot, spotPool);

		War.textEffect = this;
		if(mainCamera == null) mainCamera = Camera.main;
		devAspect = devWidth / devHeight;
		SetRate();
	}

	
	void OnDestroy()
	{
		normalPool.Clear();
		damagePool.Clear();
		damageItemPool.Clear();
		uidTextEffectDict.Clear();
	}


	#if UNITY_EDITOR
	void Update ()
	{
		if(screenWidth != Screen.width || screenHeight != Screen.height)
		{
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			SetRate();
		}
	}
	#endif

	void SetRate()
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		float aspect = screenWidth / screenHeight;
		if(aspect >= devAspect)
		{
			rate = devHeight / screenHeight;
		}
		else
		{
			rate = devWidth / screenWidth;
		}
	}

	#region hp
	public AbstractTextEffect PlayHP(float hp, UnitCtl unitCtl, int fontSize = 30 , bool isFllow = false)
	{
		if(fontSize <= 30) return null;
		if(hp == 0) return null;

		Vector3 offset = Vector3.zero;
		
		switch(unitCtl.unitData.unitType)
		{
		case UnitType.Build:
			offset = offset_Build;
			break;
		default:
			offset = offset_Solider;
			break;
		}

		AbstractTextEffect textEffect = PlayHP(hp, unitCtl.transform, offset, isFllow);
		if(textEffect != null && textEffect is TextEffectNormal)
		{
			TextEffectNormal textEffectNormal = (TextEffectNormal) textEffect;
			textEffectNormal.text.fontSize = fontSize;
			if(fontSize > 30)
			{
				textEffectNormal.randomScale = 0f;
			}
		}
		return textEffect;
	}

	public AbstractTextEffect PlayHP(float hp, Transform transform, Vector3 offset, bool isFllow = false)
	{
		int val = (int)hp;
		if(val== 0) return null;

		string txt;
		Color color;
		if(hp >= 0)
		{
			txt = "+" + val;
			color = colorHP_Plus;
		}
		else
		{
			txt = "" + val;
			color = colorHP_Minus;
		}

		TextEffectType type = TextEffectType.Normal;
		AbstractTextEffect textEffect = null;
//		if(val < 0)
//		{
//			type = TextEffectType.Damage;
//
//			StartCoroutine(OnPlaySubHP(type, val, color, transform, offset, isFllow));
//		}
//		else
//		{
//			textEffect = OnPlaySubHP(type, txt, color, transform, offset, isFllow);
//		}
		if(val < 0)
		{
			type = TextEffectType.Damage;
		}
		textEffect = Play(type, txt, color, transform, offset, isFllow);

		return textEffect;
	}

	IEnumerator OnPlaySubHP(TextEffectType type, int val, Color color, Transform transform, Vector3 offset, bool isFllow)
	{
		int count = 5;
		if(Mathf.Abs(val) < count)
		{
			count = Mathf.Abs(val);
		}

		int v = val / count;

		string txt = "";
		if(v >= 0)
		{
			txt = "+" + v;
		}
		else
		{
			txt = "" + v;
		}

		for(int i = 0; i < count; i ++)
		{
			AbstractTextEffect textEffect = Play(type, txt, color, transform, offset, isFllow);
			yield return new WaitForSeconds(0.15f);
		}
	}
	#endregion


	#region spot

	public AbstractTextEffect PlaySpot(SpotType spotType, Transform transform)
	{
		return Play(TextEffectType.Spot, spotType, Color.white,  transform.position + new Vector3(4, 2, 0), transform);
	}

	#endregion

	
	
	
	#region image
	
	public AbstractTextEffect PlayImage(TextEffectImageType type, Transform transform)
	{
		return Play(TextEffectType.Spot, type, Color.white,  transform.position + new Vector3(0, 3, 0), transform);
	}
	
	#endregion


	

	public AbstractTextEffect Play(TextEffectType type, object val, Color color, Transform transform)
	{
		return Play(type, val, color, transform.position, transform);
	}

	
	public AbstractTextEffect Play(TextEffectType type, object val, Color color, Transform transform, Vector3 offset, bool isFllow)
	{
		AbstractTextEffect textEffect = Play(type, val, color, transform.position + offset, transform);

		if(isFllow)
		{
			UIFllowWorldPosition uiFllow = textEffect.GetComponent<UIFllowWorldPosition>();
			if(uiFllow == null)
			{
				uiFllow = textEffect.gameObject.AddComponent<UIFllowWorldPosition>();
			}
			
			uiFllow.targetWorld = transform;
			uiFllow.offset = offset;
			uiFllow.enabled = true;
		}
		return textEffect;
	}


	public AbstractTextEffect Play(TextEffectType type, object val, Color color, Vector3 worldPosition, System.Object uid)
	{
		TextEffectPool pool = poolDict[type];

		AbstractTextEffect textEffect = null;
		if(type == TextEffectType.Damage)
		{
			if(uidTextEffectDict.ContainsKey(uid))
			{
				textEffect = uidTextEffectDict[uid];
			}
		}

		if(textEffect == null)
		{
			textEffect = pool.Get();
			textEffect.transform.SetParent(transform, false);
//			textEffect.transform.localScale = Vector3.one;
			textEffect.pool = pool;

			if(type == TextEffectType.Damage)
			{
				uidTextEffectDict.Add(uid, textEffect);
			}
		}


		Vector3 pt = mainCamera.WorldToScreenPoint(worldPosition).SetZ(0);
		(textEffect.transform as RectTransform).anchoredPosition = pt * rate;
		textEffect.gameObject.SetActive(true);
		textEffect.Play(val, color);
//		Debug.Log("textEffect.Play txt=" + val + " color=" + color );
		return textEffect;
	}

	public void OnOver(AbstractTextEffect item)
	{
		if(uidTextEffectDict.ContainsKey(item))
		{
			uidTextEffectDict.Remove(item);
		}
	}



}
