using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Games.Module.Wars;
using Games.Module.Avatars;
using CC.Runtime.Utils;

public class Win_T1_Occupy_View : MonoBehaviour 
{
	public Text descriptionText;
	public Text timeText;
	public Image bar;
	public Image icon;

	public bool isCountdown = true;
	public float maxTime;
	public int time;
	public int legionId;
	public AvatarConfig avatarConfig;

	private int _time = -1;
	private int _legionId = -1;
	void Start () 
	{
		if(timeText == null) timeText = transform.FindChild("Time").GetComponent<Text>();
		if(bar == null) bar = transform.FindChild("Bar/Color").GetComponent<Image>();
		if(icon == null) icon = transform.FindChild("IconBox/Icon").GetComponent<Image>();
	}

	void Update () 
	{
		if(_time != time)
		{
			SetTime();
		}

		if(_legionId != legionId)
		{
			_legionId = legionId;
			SetIcon();
		}
	}

	public void SetTime()
	{
		_time = time;
		timeText.text = (isCountdown ? (maxTime - time ) + "秒" :  TimeUtil.ToMMSS(time));
		bar.fillAmount = time / maxTime;

//		UnitData unitData;
//		SpriteAvatar spriteAvatar;
//		spriteAvatar.avatarData.avatarActions[0].clips[0].frames[0];
	}


	public void SetIcon()
	{
		LegionData legionData = War.GetLegionData(_legionId < 0 ? 0 : _legionId);
		avatarConfig.LoadIcon(OnLoadIcon, legionData.colorId);
	}

	void OnLoadIcon(string name, object obj)
	{
		Debug.Log(name + "  obj=" + obj);
		if(obj == null) return; 
		if(obj is Sprite)
		{
			icon.sprite  = obj as Sprite;
		}
		else
		{
			
			float width = 100F;
			float height = 100f;
			Texture2D texture = obj as Texture2D;
			width = texture.width;
			height = texture.height;
			icon.sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
		}
	}

}
