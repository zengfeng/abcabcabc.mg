using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	/** 胜利条件--关卡规定时间内，坚守时间越长，将领越丰厚 */
	public class Win_T3_Attack : WinProcessor 
	{
		public Win_T3_Attack_View view;
		public float hp;
		public int enemySoliderAvatarId;


		public override void Init (WinConfig winConfig, GameObject viewGO)
		{
			base.Init (winConfig, viewGO);

			foreach(KeyValuePair<int, LegionData> kvp in  War.sceneData.legionDict)
			{
				if(kvp.Value.type != LegionType.Neutral &&  kvp.Value.GetRelation(War.ownLegionID) == RelationType.Enemy)
				{
					enemySoliderAvatarId = kvp.Value.soliderData.avatarId;
					break;
				}
			}
			
			view = viewGO.GetComponent<Win_T3_Attack_View>();
			view.enemySoliderAvatarId = enemySoliderAvatarId;
		}

		
		override public void SetInfoPanel(GameObject infoPanelGO)
		{
			Win_T3_Attack_View view = infoPanelGO.GetComponent<Win_T3_Attack_View>();
			view.descriptionText.text = winConfig.description;
			view.hp = (int)hp;
		}


		void OnEnable()
		{
			War.signal.sHPConst += OnHPConst;
		}

		void OnDisable()
		{
			War.signal.sHPConst -= OnHPConst;

		}

		void OnHPConst(int legionId, int casterLegionId, float constHP)
		{
			if(casterLegionId == War.ownLegionID)
			{
				hp += constHP;
				if(view != null) view.hp = (int)hp;
			}
		}

		public override OverType GetGameOverType ()
		{
			if(War.overType == OverType.Lose)
			{
				if(War.timeLimit && War.time >= War.timeMax)
				{
					return OverType.Win;
				}
				else
				{
					return OverType.Lose;
				}
			}
			else
			{
				return OverType.Win;
			}
		}

		public override void SetWarOverData (WarOverData overData)
		{
//			overData.parameter = new float[]{(int)hp};
//			overData.enemySoliderAvatarId = enemySoliderAvatarId;
		}


	}
}