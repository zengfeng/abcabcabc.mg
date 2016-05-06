using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class SelectCircleAction : OperateAction
	{
		public List<UnitCtl> entitys = new List<UnitCtl>();

		public override void Enter ()
		{
			base.Enter();
			AddToVOOperatorList();
			AddToUpdateList();
			skillUse.selectCircleView.transform.position = skillData.heroData.position;
			skillUse.selectCircleView.Radius = skillData.skillConfig.radius;
			skillUse.selectCircleView.sCanel.AddListener(Cancel);
			skillUse.selectCircleView.sSelect.AddListener(OnSelect);

			CallUtil.Instance.AddFrameOnce(Active);
		}

		void Active()
		{
			skillUse.selectCircleView.gameObject.SetActive(true);
		}

		void OnSelect()
		{
			skillData.receivePosition = skillUse.selectCircleView.transform.position;
			Exit();
		}
	
		
		public override void Exit ()
		{
			skillData.OnUse();
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			skillUse.selectCircleView.gameObject.SetActive(false);
			skillUse.selectCircleView.sCanel.RemoveListener(Cancel);
			skillUse.selectCircleView.sSelect.RemoveListener(OnSelect);
			CallUtil.Instance.RemoveFrameOnce(Active);
		}
		
		public override void Cancel ()
		{
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			skillUse.selectCircleView.gameObject.SetActive(false);
			skillUse.selectCircleView.sCanel.RemoveListener(Cancel);
			skillUse.selectCircleView.sSelect.RemoveListener(OnSelect);
			CallUtil.Instance.RemoveFrameOnce(Active);
		}
	}
}