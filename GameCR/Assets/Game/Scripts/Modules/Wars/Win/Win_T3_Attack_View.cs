using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;
using Games.Module.Avatars;
using Games.Module.Wars;
using Games.Cores;

public class Win_T3_Attack_View : MonoBehaviour 
{
	public Text descriptionText;
	public int enemySoliderAvatarId;
	public Image soliderIcon;
	public Text hpText;
	public int hp;

	private int _hp;
	void Start () 
	{
		if(hpText == null) hpText = transform.FindChild("HP").GetComponent<Text>();
		if(soliderIcon == null) soliderIcon = transform.FindChild("Image").GetComponent<Image>();
		SetHP();
		//SetSolider(enemySoliderAvatarId);
	}

	void Update () 
	{
		if(_hp != hp)
		{
			SetHP();
		}
	}

	void SetHP()
	{
		_hp = hp;
		hpText.text = "×" +  hp.ToString();
	}

	public void SetSolider(int enemySoliderAvatarId)
	{
		AvatarConfig avatarConfig = Goo.avatar.GetConfig(enemySoliderAvatarId);
		avatarConfig.LoadFull(OnLoadIcon);
	}

	void OnLoadIcon(string name, object obj)
	{
		if(obj == null) return; 
		if(obj is Sprite)
		{
			soliderIcon.sprite  = obj as Sprite;
		}
		else
		{
			
			float width = 75F;
			float height = 90f;
			Texture2D texture = obj as Texture2D;
			width = texture.width;
			height = texture.height;
			soliderIcon.sprite   = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
		}
	}


}
