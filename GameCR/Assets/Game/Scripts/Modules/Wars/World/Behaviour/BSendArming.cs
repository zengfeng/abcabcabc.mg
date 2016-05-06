using UnityEngine;
using System.Collections;
using CC.Runtime;
using RayPaths;
using System.Collections.Generic;
using Games.Module.Avatars;
using CC.Runtime.Utils;
using Games.Module.Props;
using zfpaths;
using Games.Manager;


namespace Games.Module.Wars
{
	public class BSendArming : EBehaviour
	{
		private Dictionary<int, int> onceCountDict = new Dictionary<int, int>();
		private Dictionary<int, float> gapDict = new Dictionary<int, float>();
		/** 一排士兵宽度 */
		public float armOnceWidth = 8;
		public int onceCount = 8;
		public float radius = 1f;
		public float gapH = 1f;
		public float gapV = 1f;
		protected override void OnStart ()
		{
			base.OnStart ();

		}

		private bool _forced = false;
		public int  _num = 0;
		public bool isInitPathCache = true;

		public int targetCount;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(!sendArmData.sending) return;
			if(!War.isGameing) return;
			if(_forced == false && unitData.freezedSendArm) return;
			if(unitData.unitNum <= 0 || unitData.death)
			{
				Stop();
				return;
			}

			
			armOnceWidth = legionData.soliderData.armOnceWidth;
			radius = legionData.soliderData.radius;
			gapV = legionData.soliderData.gapV;
			gapH = radius * 2;
			if(gapV < 0) gapV = gapH;
			if(armOnceWidth < 0) armOnceWidth= 8;
			onceCount = Mathf.FloorToInt(armOnceWidth / gapH);


			targetCount = sendArmData.targets.Count;
			for(int j = 0 ; j < targetCount; j ++)
			{
				SendArmDataTarget targetData = sendArmData.targets[j];

				int count = Mathf.Min(targetData.num, onceCount);
				count = Mathf.Min(count, unitData.unitNum);
				//Debug.Log ("j=" + j + " count=" + count + "  targetData.num=" + targetData.num);
				if (count <= 0) 
				{
					sendArmData.WillRemoveTarget (targetData);
					continue;
				}

				if(count > 8) count = 8;

				if(Time.time > targetData.nextTime)
				{
					
					PathGroup pathGroup = War.scene.GetPathCache(onceCount, transform, targetData.target.transform);
					isInitPathCache = pathGroup != null;
					List<UnitPath> unitPathList = new List<UnitPath>();
					UnitPathGroup unitPathGroup = null;
					if(!isInitPathCache)
					{
						GameObject groupGO = War.factory.CreatePathGroup();
						groupGO.transform.position = transform.position;
						unitPathGroup = groupGO.GetComponent<UnitPathGroup>();
					}
					
					float moveSpeed = 1f;
					for(int i = 0; i < count; i ++)
					{
						int pathIndex = (int)((i + 1) / 2) * (i % 2 == 0 ? 1 : -1);

						targetData.num += -1;
						sendArmData.sendNum += -1;
						unitData.AddUnitNum(-1);
						
//											GameObject soliderGO = War.factory.CreateSolider(unitData.legionId);
						GameObject soliderGO = War.soliderPool.Get();
						UnitData soliderUnitData = legionData.soliderData.Clone();
						soliderUnitData.id = targetData.idBegin ++;
						soliderUnitData.from = unitData;
						soliderUnitData.to = targetData.target.unitData;
						unitData.soliderPropContainer.UnitApp(soliderUnitData);
						legionData.soliderPropContainer.UnitApp(soliderUnitData);
						legionData.soliderInitPropContainer.UnitApp(soliderUnitData, true);
						
						soliderGO.AddEComponent(soliderUnitData);
						soliderUnitData.Init();
						if(targetData.forced) soliderUnitData.moveSpeed = targetData.speed;
						UnitAgent unitAgent = soliderGO.GetComponent<UnitAgent>();
						unitAgent.Walk();
						unitAgent.angel = HMath.angle(transform.position.z, transform.position.x, targetData.target.transform.position.z, targetData.target.transform.position.x);
						
						
						soliderGO.name = "War_Solider-" + soliderUnitData.id;
						
						
						UnitPath unitPath = soliderGO.GetComponent<UnitPath>();
						unitPath.index = pathIndex;
						unitPath.maxSpeed = targetData.forced ? targetData.speed : soliderUnitData.moveSpeed;
						soliderGO.transform.position = transform.position;
						
						if(isInitPathCache)
						{
							unitPathList.Add(unitPath);
						}
						else
						{
							unitPathGroup.list.Add(unitPath);
						}

						
						
						moveSpeed = unitPath.maxSpeed;
						if(targetData.forced)
						{
							soliderUnitData.moveSpeed = moveSpeed;
							soliderUnitData.Props[PropId.InitMoveSpeed] = moveSpeed;
						}
						
						soliderUnitData.to.AddFromLegionUnit(soliderUnitData.legionId, 1);

						SoliderPoolItem soliderPoolItem = soliderGO.GetComponent<SoliderPoolItem>();
						if(soliderPoolItem != null)
						{
							soliderPoolItem.Rest();
						}
					}
					
					//				Debug.Log(string.Format("<color=green>isInitPathCache={0}</color>", isInitPathCache));
					if(isInitPathCache)
					{
						pathGroup = War.scene.GetPathCache(onceCount, transform, targetData.target.transform);
						int unitPathListCount = unitPathList.Count;
						pathGroup = pathGroup.Clone(unitPathListCount);
						
						for(int i = 0; i < unitPathListCount; i ++)
						{
							unitPathList[i].SetPath(pathGroup.paths[i]);
						}
					}
					else
					{
						unitPathGroup.gap = gapH;
						unitPathGroup.pathNum = count;
						unitPathGroup.onceCount = onceCount;
						unitPathGroup.MoveTo(unitCtl, targetData.target);
					}
					
					if(float.IsNaN(moveSpeed) || moveSpeed <= 0) moveSpeed = 1f;
					targetData.nextTime = Time.time + (gapV + sendArmData.sendUnitSpeed )/ moveSpeed;
				}
			}

			sendArmData.ExeRemoveTargets ();


		}

		
		virtual public void Send(UnitCtl target)
		{
			float sendArmRate = 1f;
			if(unitData.relation == RelationType.Own)
			{
				sendArmRate = War.sendArmRate;
			}
			Send(target, sendArmRate);
		}

		
		virtual public void Send(UnitCtl target, float sendArmRate)
		{
			if(unitData.freezedSendArm) return;
			int sendNum = unitData.unitNum;
			sendNum = Mathf.CeilToInt(sendNum * sendArmRate);

			int idBegin = War.sceneData.GetSoliderUID(unitData.id, target.unitData.id, _num, unitData.legionId);
			if(!War.requireSynch)
			{
//				sendArmData.sendNum = sendNum;
//				sendArmData.sending = true;
//				sendArmData.AddTarget(target, idBegin);

				ExeSend (target, sendNum, idBegin);
			}
			else
			{
				War.pvp.C_SendArm(unitCtl, target, sendNum, idBegin);

			}
			_num += sendNum;
		}

		virtual public void Send(UnitCtl target, int sendNum)
		{
			if(unitData.freezedSendArm) return;
			if (sendNum == -1)
				sendNum = unitData.unitNum;
			
			if (sendNum > unitData.unitNum)
				sendNum = unitData.unitNum;

			int idBegin = War.sceneData.GetSoliderUID(unitData.id, target.unitData.id, _num, unitData.legionId);
			if(!War.requireSynch)
			{
				//				sendArmData.sendNum = sendNum;
				//				sendArmData.sending = true;
				//				sendArmData.AddTarget(target, idBegin);

				ExeSend (target, sendNum, idBegin);
			}
			else
			{
				War.pvp.C_SendArm(unitCtl, target, sendNum, idBegin);

			}
			_num += sendNum;
		}



		virtual public void S_Send(UnitCtl target, int count, int idBegin)
		{
			ExeSend (target, count, idBegin);
		}

		virtual public void ExeSend(UnitCtl target, int count, int idBegin)
		{
			sendArmData.sendNum = count;
			sendArmData.sending = true;
			sendArmData.AddTarget(target, idBegin, count, false, 0);
			_num += count;

			War.signal.DoSendArm (unitData.uid, target.unitData.uid, count, idBegin);
		}

		virtual public void Send(UnitCtl target, int count, float speed)
		{
			//Stop();

			sendArmData.sendNum += count;
			sendArmData.sending = true;
			int idBegin = War.sceneData.GetSoliderUID(unitData.id, target.unitData.id, _num, unitData.legionId);
			sendArmData.AddTarget(target, idBegin, count, true, speed);
			_num += count;
			_forced = true;
		}

		virtual public void Stop()
		{
			_forced = false;
			sendArmData.sending = false;
			sendArmData.sendNum = 0;
			sendArmData.Stop();
		}
	}
}
