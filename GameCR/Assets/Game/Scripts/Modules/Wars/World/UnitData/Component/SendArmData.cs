using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SendArmDataTarget
	{
		public UnitCtl target;
		public float nextTime = 0;
		public int idBegin = 0;
		public int num = 0;
		public bool forced;
		public float speed = 1;

		public SendArmDataTarget()
		{
		}

		
		public SendArmDataTarget(UnitCtl target, int idBegin, int num, bool forced, float speed)
		{
			this.target = target;
			this.idBegin = idBegin;
			this.num = num;
			this.forced = forced;
			this.speed = speed;
		}
	}

	public class SendArmData : EData
	{

		public int onceGroupNum = ConstConfig.GetInt(ConstConfig.ID.War_Arm_OnceCount);
		public float sendUnitSpeed = ConstConfig.GetFloat(ConstConfig.ID.War_Arm_OnceTime);


		//-------code operation-------
		public int sendNum = 0;
		public bool sending = false;
		public int idBegin = 0;

		public List<SendArmDataTarget> targets = new List<SendArmDataTarget>();
		private Dictionary<UnitCtl, SendArmDataTarget> targetDict = new Dictionary<UnitCtl, SendArmDataTarget>();
		public int TargetCount {	get{	return targets.Count;	}	}
		public void AddTarget(UnitCtl target, int idBegin, int num, bool forced, float speed)
		{
			SendArmDataTarget targetData;
			if(targetDict.TryGetValue(target, out targetData))
			{
				targetData.idBegin = idBegin;
				targetData.num = num;
				targetData.forced = forced;
				targetData.speed = speed;
			}
			else
			{
				targetData = new SendArmDataTarget(target, idBegin, num, forced, speed);
				targets.Add(targetData);
				targetDict.Add(target, targetData);
				
				target.unitData.fromList.Add(unitData);
			}
		}



		public void Stop()
		{

			for(int i = 0; i < targets.Count; i ++)
			{
				targets[i].target.unitData.fromList.Remove(unitData);
			}
			targets.Clear();
			targetDict.Clear();
			willRemoveTargets.Clear ();
		}

		private List<SendArmDataTarget> willRemoveTargets = new List<SendArmDataTarget>();
		public void WillRemoveTarget(SendArmDataTarget targetData)
		{
			willRemoveTargets.Add (targetData);
		}

		private void RemoveTarget(SendArmDataTarget targetData)
		{
			targets.Remove (targetData);
			targetDict.Remove (targetData.target);
			targetData.target.unitData.fromList.Remove(unitData);

			if (willRemoveTargets.Contains (targetData))
				willRemoveTargets.Remove (targetData);
		}

		public void ExeRemoveTargets()
		{
			while(willRemoveTargets.Count > 0)
			{
				RemoveTarget (willRemoveTargets[0]);
			}

			if (targets.Count == 0) 
			{
				sending = false;
			}

		}

	}
}
