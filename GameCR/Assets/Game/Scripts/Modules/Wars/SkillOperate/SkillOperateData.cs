using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SkillOperateData 
	{
		public Action<SkillOperateData> sSetUse;


		/** 施法者 */
		public UnitCtl caster;
		/** 操作动作 */
		public List<OperateAction> 	operatorList 	= new List<OperateAction>();
		/** 接收技能单位列表 */
		public List<UnitCtl> 		receiveList 	= new List<UnitCtl>();
		/** 接收技能坐标 */
		public Vector3 				receivePosition;
		/** 接收技能方向 */
		public Vector3 				receiveDirection;
		/** 快捷键 */
		public KeyCode 				key;
		/** 候选目标数量 */
		public int					candidateReceiveCount = 0;
		public List<UnitCtl>		candidateReceiveList = new List<UnitCtl>();
		public UnitCtl 				candidateEntity;

		/** 唯一ID */
		public int 			uid;

		/** 技能条--凹槽位置 */
		public int			grooveIndex;

		public bool 		isRoleSkill
		{
			get
			{
				return skillId == War.config.roleSkillId;
			}
		}

		/** 获取第一个接受单位 */
		public UnitCtl GetReceiveUnitCtl()
		{
			if(receiveList.Count > 0)
			{
				return receiveList[0];
			}
			return null;
		}
		
		#region Hero & Legion
		/** 英雄数据 */
		public HeroData heroData;

		/** 英雄UID */
		public int	heroUid
		{
			get
			{
				return heroData.unitData.id;
			}
		}

		/** 英雄名称 */
		public string heroName
		{
			get
			{
				return heroData.name;
			}
		}

		/** 英雄名称 */
		public Color heroColor
		{
			get
			{
				return heroData.color;
			}
		}
		
		/** 英雄单位控制器 */
		public UnitCtl	heroUnitCtl
		{
			get
			{
				return heroData.unit;
			}
		}
		
		/** 英雄单位数据 */
		public UnitData	heroUnitData
		{
			get
			{
				return heroData.unitData;
			}
		}

		
		/** 势力Id */
		public int legionId
		{
			get
			{
				return heroData.unitData.legionId;
			}
		}
		
		/** 势力数据 */
		public LegionData legionData
		{
			get
			{
				return heroData.unitData.legionData;
			}
		}

		#endregion
		
		/** 已经使用的次数 */
		public int useNum = 0;
		public bool enableProduce
		{
			get
			{
				if(skillConfig.useCount == -1) return true;
				return useNum < skillConfig.useCount;
			}
		}



		#region 操作
		/** 是否在操作中 */
		public bool 				operatoring;
		/** 操作状态 */
		public SkillOperateState	operateState;
		#endregion

		#region 技能配置数据
		public ISkillConfig skillConfig;

		public int 			skillId;
		public int 			skillLevel 		= 1;


		public void Init()
		{
			if(skillConfig == null)
			{
				skillConfig = new HSkillConfig();
				skillConfig.Init(skillId, skillLevel);
			}
		}

	
		#endregion

		#region 加载图标
		/** 加载--技能图标 */
		public void LoadIcon( Action<string,object> callback)
		{
			Coo.assetManager.Load(skillConfig.icon, callback);
		}

		/** 加载--英雄头像 */
		public void LoadHeadIcon( Action<string,object> callback)
		{
			heroData.avatar.LoadIcon(callback);
		}
		
		/** 加载--英雄战斗中头像 */
		public void LoadVSHeadIcon( Action<string,object> callback)
		{
			heroData.avatar.LoadVSIcon(callback);
		}


		/** 加载--英雄使用技能冒出剪辑图片 */
		public void LoadHeadSkillClipIcon( Action<string,object> callback)
		{
			heroData.avatar.LoadHeadSkillClipIcon(callback);
		}
		#endregion


		/** 和自己势力的”关系“ */
		public RelationType relation
		{
			get
			{
				return heroData.unitData.relation;
			}
		}
		
		/** 获取与某个势力的”关系“ */
		public RelationType GetRelation(int legionId)
		{
			return heroData.unitData.GetRelation(legionId);
		}

		/** 使用--开始创建技能效果（操作完成） */
		public void OnUse()
		{
			operatoring = false;
			operateState = SkillOperateState.Empty;

			War.skillCreater.OnUse(this);
			War.signal.SkillUse (this);
		}
		
		/** 使用--开始创建技能效果（服务器同步） */
		public void S_Use()
		{
			War.skillCreater.OnUse(this);
		}

		public void SetUse()
		{
			operatoring = false;
			operateState = SkillOperateState.Empty;
			War.skillCreater.SetUse(this);

			if (sSetUse != null)
			{
				sSetUse (this);
			}
		}

//		/** 使用--开始进入操作步骤 */
//		public void Use()
//		{
//			War.skillUse.UseSkill(this);
//		}

		/** 取消技能操作 */
		public void CancelOperator()
		{
			operatoring = false;
			if(operateState != SkillOperateState.Empty)
			{
				operateState = SkillOperateState.Normal;
			}

			foreach(OperateAction action in operatorList.ToArray())
			{
				action.Cancel();
			}
		}

		/** 判断该技能是否能应用到某个单位 */
		public bool EnableUse(UnitCtl entity)
		{
			RelationType relation = GetRelation(entity.unitData.legionId);
			bool enable = skillConfig.EnableUse(entity, relation);
			if (enable) 
			{
				if (heroData.unitData.relation == RelationType.Own) 
				{
					enable = Games.Guides.Guide.warConfig.GetEnableSkillTargetUid (entity.unitData.uid);
				}
			}
			return enable;
		}

		/** 获取选择单位图标 */
		public SkillOperateSelectUnitIconType GetSelectUnitIconType(UnitCtl entity, bool isEnemy)
		{
			SkillOperateSelectUnitIconType t = SkillOperateSelectUnitIconType.Aim;
			switch(skillConfig.skillType)
			{
			case SkillType.Build_Attach:
				t = SkillOperateSelectUnitIconType.Change;
				break;
			case SkillType.Build_Uplevel:
				t = SkillOperateSelectUnitIconType.Uplevel;
				break;
			case SkillType.Build_Replace:
				if(skillConfig.buildId == entity.unitData.buildConfig.id)
				{
					t = SkillOperateSelectUnitIconType.Uplevel;
				}
				else
				{
					t = SkillOperateSelectUnitIconType.Change;
				}
				break;
			default:
				if(isEnemy)
				{
					t = SkillOperateSelectUnitIconType.Attack;
				}
				else
				{
					t = SkillOperateSelectUnitIconType.Add;
				}
				break;
			}

			return t;
		}

		public SkillOperateSelectUnitIconType selectUnitIconType
		{
			get 
			{
				SkillOperateSelectUnitIconType t = SkillOperateSelectUnitIconType.Aim;
				switch(skillConfig.skillType)
				{
				case SkillType.Build_Attach:
					t = SkillOperateSelectUnitIconType.Change;
					break;
				case SkillType.Build_Uplevel:
					t = SkillOperateSelectUnitIconType.Uplevel;
					break;
				case SkillType.Build_Replace:
					t = SkillOperateSelectUnitIconType.Change;
					break;
				default:
					if(skillConfig.relation.REnemy())
					{
						t = SkillOperateSelectUnitIconType.Attack;
					}
					else
					{
						t = SkillOperateSelectUnitIconType.Add;
					}
					break;
				}

				return t;
			}
		}


	}
}
