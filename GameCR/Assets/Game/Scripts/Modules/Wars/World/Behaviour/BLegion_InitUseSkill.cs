using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class BLegion_InitUseSkill : EBehaviour
	{

		protected override void OnStart ()
		{
			base.OnStart ();

			if (War.isEditor)
			{
				enabled = false;
				return;
			}
			
			if(legionData.legionId != War.ownLegionID)
			{
				if(legionData.type == LegionType.Player)
				{
					enabled = false;
					return;
				}

				if(!War.isMainLegion)
				{
					enabled = false;
					return;
				}

			}

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
			if(legionData.initUseSkillId > 0)
			{
				SkillOperateData skillOperateData = legionData.GetSkillDataBySkillId(legionData.initUseSkillId);
				skillOperateData.receiveList.Clear();
				skillOperateData.receiveList.Add(War.scene.GetBuild(legionData.initUseSkillBuildId));
				skillOperateData.OnUse();
				
				if(legionData.enableProduceSkillUids.IndexOf(skillOperateData.uid) != -1)
				{
					legionData.enableProduceSkillUids.Remove(skillOperateData.uid);
				}
			}
		}

	}
}