using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime;


namespace Games.Module.Wars
{
	public partial class WarIcons : MonoBehaviour 
	{

		void Awake()
		{
			War.icons = this;
		}


		/** 瞄准 */
		public Sprite skilloperateAim;
		/** 攻击 */
		public Sprite skilloperateAttack;
		/** 升级 */
		public Sprite skilloperateUplevel;
		/** 升级2 */
		public Sprite skilloperateUplevel2;
		/** 锤子 */
		public Sprite skilloperateChange;
		/** 加 */
		public Sprite skilloperateAdd;


		public Sprite GetSkillSelectUnitIcon(SkillOperateSelectUnitIconType iconType)
		{
			switch(iconType)
			{
			case SkillOperateSelectUnitIconType.Aim:
				return skilloperateAim;
				break;
			case SkillOperateSelectUnitIconType.Attack:
				return skilloperateAttack;
				break;
			case SkillOperateSelectUnitIconType.Uplevel:
				return skilloperateUplevel;
				break;
			case SkillOperateSelectUnitIconType.Change:
				return skilloperateChange;
				break;
			case SkillOperateSelectUnitIconType.Add:
				return skilloperateAdd;
				break;
			}

			return skilloperateAim;
		}


		/** 攻击 */
		public Texture skilloperateTextureAttack;
		/** 锤子 */
		public Texture skilloperateTextureChange;
		/** 加 */
		public Texture skilloperateTextureAdd;


		public Texture GetSkillSelectTexture(SkillOperateSelectUnitIconType iconType)
		{
			switch(iconType)
			{
			case SkillOperateSelectUnitIconType.Attack:
				return skilloperateTextureAttack;
				break;
			case SkillOperateSelectUnitIconType.Change:
				return skilloperateTextureChange;
				break;
			default:
				return skilloperateTextureAdd;
				break;
			}

			return skilloperateTextureAdd;
		}

    }


}
