using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepListenerAction : GuideStepAction
	{
		public GuideStepListenerData listenerData;

		public override void SetData (GuideStepData data)
		{
			listenerData = (GuideStepListenerData) data;
			base.SetData (data);
		}

		public override void Enter ()
		{
			CheckListener ();
		}

		protected override void OnDestroy ()
		{
			War.signal.sDoBuildLegionChange -= OnBuildLegionChange;
			War.signal.sOnBehit -= OnBuildHit;
			War.signal.sDoSendArm -= OnLegionSendArm;
			base.OnDestroy ();
		}

		protected virtual void CheckListener()
		{
			switch(listenerData.listenerType)
			{
			case GuideListenerType.None:
				CheckExe ();
				break;
			case GuideListenerType.BuildOccupied:
				War.signal.sDoBuildLegionChange += OnBuildLegionChange;
				break;
			case GuideListenerType.BuildBehit:
				War.signal.sOnBehit += OnBuildHit;
				break;
			case GuideListenerType.LegionSendArm:
				War.signal.sDoSendArm += OnLegionSendArm;
				break;
			}
		}

		protected virtual void OnLegionSendArm(int fromUid, int toUid, int count, int beginUid)
		{
			UnitCtl fromUnit = War.scene.GetBuild (fromUid);

			RelationType fromRelationType = fromUnit.unitData.GetRelation (listenerData.sendArm_from_relationLegionId);
			bool result = GetExeResult(fromUid, listenerData.sendArm_from_buildId, fromUnit.unitData.legionId, listenerData.sendArm_from_legionId, fromRelationType, listenerData.sendArm_from_relation);
			Debug.Log ("OnLegionSendArm from result=" + result);
			if (result) 
			{
				UnitCtl toUnit = War.scene.GetBuild (toUid);
				RelationType toRelationType = toUnit.unitData.GetRelation (listenerData.sendArm_to_relationLegionId);
				result = GetExeResult (toUid, listenerData.sendArm_to_buildId, toUnit.unitData.legionId, listenerData.sendArm_to_legionId, toRelationType, listenerData.sendArm_to_relation);
			}
			Debug.Log ("OnLegionSendArm to result=" + result);
			if (result) 
			{
				CheckExe ();
			}
		}

		protected virtual void OnBuildHit(int uid, int hitLegionId)
		{
			UnitCtl unit = War.scene.GetBuild (uid);
			RelationType relationType = unit.unitData.GetRelation (listenerData.buildBehit_relationLegionId);
			bool result = GetExeResult (uid, listenerData.buildBehit_buildId, 
				unit.unitData.legionId, listenerData.buildBehit_legionId,
				relationType, listenerData.buildBehit_relationLegionId
			);

			if (result) 
			{
				relationType = unit.unitData.GetRelation (listenerData.buildBehit_hit_relationLegionId);
				result = GetExeResult (uid, listenerData.buildBehit_buildId, 
					hitLegionId, listenerData.buildBehit_hit_legionId,
					relationType, listenerData.buildBehit_hit_relationLegionId
				);
			}

			if (result) 
			{
				CheckExe ();
			}

//			if (listenerData.buildBehit_buildId == -1 || listenerData.buildBehit_buildId == uid)
//			{
//				UnitCtl unit = War.scene.GetBuild (uid);
//				bool legionResult = listenerData.buildBehit_legionId == -1 || listenerData.buildBehit_legionId == unit.unitData.legionId;
//
//				if (legionResult) 
//				{
//					legionResult = listenerData.buildBehit_relation == -1 || listenerData.buildBehit_relation.RValue (unit.unitData.GetRelation (listenerData.buildBehit_relationLegionId));
//				}
//
//				if (legionResult)
//				{
//					legionResult = listenerData.buildBehit_hit_legionId == -1 || listenerData.buildBehit_hit_legionId == hitLegionId;
//
//					if (legionResult) 
//					{
//						legionResult = listenerData.buildBehit_hit_relation == -1 || listenerData.buildBehit_hit_relation.RValue (unit.unitData.GetRelation (listenerData.buildBehit_hit_relationLegionId));
//					}
//				}
//
//				if (legionResult) 
//				{
			//					CheckExe ();
//				} 
//			}
		}

		protected virtual void OnBuildLegionChange(int uid, int legionId)
		{

			UnitCtl unit = War.scene.GetBuild (uid);
			bool result = GetExeResult (uid, listenerData.buildOccupied_buildId, 
				unit.unitData.legionId, listenerData.buildOccupied_legionId,
				unit.unitData.GetRelation (listenerData.buildOccupied_relationLegionId), listenerData.buildOccupied_relation
			);

			if (result) 
			{
				CheckExe ();
			}

//			if (listenerData.buildOccupied_buildId == -1 || listenerData.buildOccupied_buildId == uid)
//			{
//				UnitCtl unit = War.scene.GetBuild (uid);
//				bool legionResult = listenerData.buildOccupied_legionId == -1 || listenerData.buildOccupied_legionId == unit.unitData.legionId;
//
//				if (legionResult) 
//				{
//					legionResult = listenerData.buildOccupied_relation == -1 || listenerData.buildOccupied_relation.RValue (unit.unitData.GetRelation (listenerData.buildOccupied_relationLegionId));
//				}
//
//				if (legionResult) 
//				{
			//					CheckExe ();
//				} 
//			}
		}

		protected virtual bool GetExeResult(int buildId, int dataBuildId, int legionId, int dataLegionId, RelationType relationType, int dataRelation)
		{
			bool result = true;
			result = dataBuildId == -1 || dataBuildId == buildId;
			if(result)
			{
				result = dataLegionId == -1 || dataLegionId == legionId;
				if (result) 
				{
					result = dataRelation == -1 || dataRelation.RValue (relationType);
				}
			}

			return result;
		}

		bool checkExeed;
		protected virtual void CheckExe()
		{
			if (checkExeed)
				return;
			
			checkExeed = true;
			if (listenerData.delay > 0) 
			{
				StartCoroutine (OnExeHanld());
			} 
			else 
			{
				Exe ();
			}
		}

		IEnumerator OnExeHanld()
		{
			yield return new WaitForSeconds (listenerData.delay);
			Exe ();
		}

		protected virtual void Exe()
		{
			CheckComplete ();
		}

	}
}