using UnityEngine;
using System.Collections;
using Games.Cores;
using Games.Module.Props;
using Games.Module.Avatars;
using System;

namespace Games.Module.Wars
{


	/** 英雄数据 */
	public class HeroData : EData
	{
		/** 幕后 */
		public Action<HeroData> sBackstage;
		/** 幕前 */
		public Action<HeroData> sForegstage;


		/** 是否安装 */
		public bool isInstance = false;
		/** 技能操作数据 */
		public SkillOperateData skillOperateData;
		/** 英雄UID */
		public int heroUid = -1;
		public string _name;
		public string name
		{
			get 
			{
				if (string.IsNullOrEmpty (_name)) 
				{
					if (avatar != null)
						_name = avatar.name;
				}
				return _name;
			}

			set 
			{
				_name = value;
			}
		}
		// 英雄品质 
		public int quality = 1;
		/** 英雄ID */
		public int heroId = -1;
		/** 所在兵营ID */
		public int buildId = -1;
		/** 原始势力 */
		public int originalLegion = -1;
		/** 是否是野外英雄 */
		public bool wild = false;
		/** 英雄属性 */
		public AttachPropData props 			{	get{ 	return War.GetLegionData(unitData.initLegionId).heroInitAttachPropData[heroId]; }	}
		/** 英雄附加给建筑属性 */
		public AttachPropData hero2BuildProps 	{	get{	return War.GetLegionData(unitData.initLegionId).hero2BuildAttachPropData[heroId]; }	}
		/** 英雄状态 */
		public HeroState state = HeroState.Backstage;

		/** 英雄Avatar配置 */
		public int avatarId;
		public AvatarConfig avatar
		{
			get
			{
				AvatarConfig avatarConfig = null;
				if(avatarId > 0)
				{
					avatarConfig = Goo.avatar.GetConfig(avatarId);
				}
				else
				{
					avatarConfig = Goo.avatar.GetConfig(heroId);
				}

				if(avatarConfig == null)
				{
					avatarConfig = Goo.avatar.GetConfig(20001);
				}

				return avatarConfig;
			}
		}
		
		/** 英雄世界坐标位置 */
		public Vector3 position
		{
			get
			{
				Vector3 point = unit.transform.position;
				point.y = 0.1F;
				return point;
			}
		}
		
		/** 是否死亡 */
		public bool death
		{
			get
			{
				return unitData.death;
			}
			
			set
			{
				unitData.death = value;
			}
		}

		public bool isRole
		{
			get
			{
				return skillOperateData.isRoleSkill;
			}
		}


		public Color color
		{
			get 
			{
				return WarColor.GetQualityColor (quality);
			}
		}





	}
}