using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class SkillInfo : MonoBehaviour {

		public SkillOperateData  data;

		public Image 			skillTypeIconImage;
		public Text 			heroNameText;
		public Text 			skillNameText;
		public Text 			noTargetText;

		
		public RectTransform 	rectTransform
		{
			get
			{
				return (RectTransform) transform;
			}
		}
		
		public bool Visiable
		{
			get
			{
				return gameObject.activeSelf;
			}

			set
			{
				gameObject.SetActive(value);
			}
		}




		public void SetData(SkillOperateData data)
		{
			this.data = data;

			skillTypeIconImage.sprite = War.icons.GetSkillSelectUnitIcon(data.selectUnitIconType);
			heroNameText.text = string.IsNullOrEmpty(data.heroName) ? "无名英雄" : data.heroName;
//			heroNameText.color = data.heroColor;
			skillNameText.text = data.skillConfig.name + "<color=#D6E8C8FF><size=43> " + data.skillLevel + "级</size></color>";
		}


		private bool _hasTarget = true;
		public bool HasTarget
		{
			get 
			{
				return _hasTarget;
			}

			set
			{
				if (_hasTarget != value) 
				{
					_hasTarget = value;
					skillTypeIconImage.gameObject.SetActive (_hasTarget);
					heroNameText.gameObject.SetActive (_hasTarget);
					skillNameText.gameObject.SetActive (_hasTarget);
					noTargetText.gameObject.SetActive (!_hasTarget);
				}
			}
		}



	}
}