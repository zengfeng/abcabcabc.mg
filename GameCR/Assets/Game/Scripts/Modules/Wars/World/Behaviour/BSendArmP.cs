using UnityEngine;
using System.Collections;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class BSendArmP : EBehaviour
	{
		[HideInInspector]
		public Transform anchorImageSendArm;
		public SendArmyView sendArmyView;


		protected override void OnAwake ()
		{
			base.OnAwake ();
			anchorImageSendArm = transform.FindChild(UnitAnchorName.ImageSendArm);
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			if (War.isRecord)
			{
				enabled = false;
				return;
			}

			Init();
		}

		protected void Init()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.SendArmy);
			GameObject go = GameObject.Instantiate(prefab);
			go.name = "War_View_SendArmy";
			go.transform.SetParent(anchorImageSendArm);
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			sendArmyView = go.GetComponent<SendArmyView>();

			sendArmyView.unit = unitCtl;
			sendArmyView.units = War.scene.buildList;
			sendArmyView.sSelect += OnSelect;


		}

		public RelationType _relation = RelationType.None;
		private bool _enableLevel = false;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(sendArmyView == null) return;

			if(_relation != unitData.relation)
			{
				_relation = unitData.relation;
				if(_relation == RelationType.Own)
				{
					sendArmyView.gameObject.SetActive(true);
				}
				else
				{
					sendArmyView.gameObject.SetActive(false);
				}
			}
		}


		
		virtual protected void OnSelect(UnitCtl target)
		{
            //Coo.soundManager.PlaySound("effect_send_soldier");
            int idx = Random.Range(1, 6);
            string name = string.Format("chubing_1_{0:D2}", idx);
            Coo.soundManager.PlaySound(name);
            //			Debug.Log("BSendArmP OnSelect target=" + target);
            BSendArming sendArming = GetComponent<BSendArming>();
			if(sendArming != null)
			{
				sendArming.Send(target);
				War.signal.HandSendArm (unitData.id, target.unitData.id);
               // Coo.soundManager.PlaySound("eff_send_soldier");
			}
		}
		



	}
}
