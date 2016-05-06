using UnityEngine;
using System.Collections;
namespace Games.Module.Wars
{
	
	public class OperateAction 
	{
		public SkillUse 	skillUse;
		public SkillOperateData 	skillData;

		public float updateTime = 0F;
		public float updateDealyTime = 0F;
		
		public virtual void Enter ()
		{
		}
		
		public virtual void Execute ()
		{
//			if(skillData.heroData.death)
//			{
//				OnDeath();
//				return;
//			}

			if(updateDealyTime <= 0)
			{
				OnExecute();
			}
			else if(Time.time >= updateTime)
			{
				updateTime = Time.time + updateDealyTime;
				OnExecute();
			}
			
			OnExecuteFixed();
		}
		
		
		public virtual void OnExecute ()
		{
			
		}
		
		public virtual void OnExecuteFixed ()
		{
			
		}
		
		public virtual void Exit ()
		{
		}
		
		public virtual void Cancel()
		{
		}

		public virtual void OnDeath()
		{
			Cancel();
		}




		protected void AddToUpdateList()
		{
			if(!skillUse.operateActionList.Contains(this))
				skillUse.operateActionList.Add(this);
		}
		
		
		protected void RemoveFromUpdateList()
		{
			if(!skillUse.waitRemoveOperateActionList.Contains(this))
				skillUse.waitRemoveOperateActionList.Add(this);
		}
		
		protected void AddToVOOperatorList()
		{
//			skillData.operatoring = true;
			if(!skillData.operatorList.Contains(this))
			{
				skillData.operatorList.Add(this);
			}
		}
		
		protected void RemoveFromVOOperatorList()
		{
//			skillData.operatoring = false;
			if(skillData.operatorList.Contains(this))
			{
				skillData.operatorList.Remove(this);
			}
		}
	}
}
