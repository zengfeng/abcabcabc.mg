using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Avatars;

namespace Games.Module.Wars
{
	/** 胜利条件--占领指定建筑，持续{0}时间 */
	public class Win_T1_Occupy : WinProcessor 
	{
		public Win_T1_Occupy_View view;
		public List<UnitCtl> builds = new List<UnitCtl>();
		public float time = 20;
		public int legionId = -1;
		public bool become;
		public AvatarConfig avatarConfig;
		void Start()
		{
			foreach(int buildId in  winConfig.t1_builds)
			{
				UnitCtl unitCtl = War.scene.GetBuild(buildId);
				builds.Add(unitCtl);
				avatarConfig = unitCtl.unitData.avatarConfig;
			}
			
			view.avatarConfig = avatarConfig;
		}

		public override void Init (WinConfig winConfig, GameObject viewGO)
		{
			base.Init (winConfig, viewGO);
			
			view = viewGO.GetComponent<Win_T1_Occupy_View>();
			view.maxTime = winConfig.t1_time;
		}

		
		override public void SetInfoPanel(GameObject infoPanelGO)
		{
			Win_T1_Occupy_View view = infoPanelGO.GetComponent<Win_T1_Occupy_View>();
			view.avatarConfig = avatarConfig;
			view.descriptionText.text = winConfig.description;
			view.time = (int)time;
			view.maxTime = winConfig.t1_time;
			view.legionId = legionId;
		}

		override protected void OnLateUpdate()
		{
			int id = -1;
			become = true;
			foreach(UnitCtl unitCtl in builds)
			{
				if(unitCtl.unitData.isNeutral)
				{
					become = false;
					break;
				}

				if(id < 0)
				{
					id = unitCtl.unitData.legionId;
				}
				else if(id != unitCtl.unitData.legionId)
				{
					become = false;
					break;
				}
			}

			if(become)
			{
				if(legionId != id)
				{
					legionId = id;
					time = Time.deltaTime;
				}
				else
				{
					time += Time.deltaTime;
				}
			}
			else
			{
				time = 0;
				legionId = 0;
			}
			
			view.time = (int)time;
			view.legionId = legionId;

			if(time >= winConfig.t1_time)
			{
				if(War.ownLegionData.GetRelation(legionId) == RelationType.Enemy)
				{
					state = WinState.Fail;
					War.Over(OverType.Lose);
				}
				else
				{
					state = WinState.Success;;
					War.Over(OverType.Win);
				}
			}

		}

		public override OverType GetGameOverType ()
		{
			if(state == WinState.Success)
			{
				return OverType.Win;
			}
			else
			{
				return OverType.Lose;
			}
		}


	}
}