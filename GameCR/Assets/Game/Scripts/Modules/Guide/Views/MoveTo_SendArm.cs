using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class MoveTo_SendArm {

		public GuideMoveToPanel 	guidePanel;
		public AbstractMoveToView 	mt;
		public GuideStepAction		stepAction;
		
		public int id;
		public int fromId;
		public int toId;
		
		public bool isFinal;
		
		public MoveTo_SendArm(int id, int fromId, int toId, GuideMoveToPanel guidePanel, GuideStepAction	stepAction)
		{
			this.id = id;
			this.fromId = fromId;
			this.toId = toId;
			this.guidePanel = guidePanel;
			this.stepAction = stepAction;
		}
		
		
		void OnHandDownBuild (int buildId)
		{
			if(buildId == fromId)
			{
				Hide();
			}
		}
		
		
		void OnHandSendArm (int from, int to)
		{
			if(from == fromId && to == toId)
			{
				if(stepAction != null) stepAction.End();
				Close();
				isFinal = true;
			}
		}
		
		
		void OnHandUpBuild (int buildId) 
		{
			if(buildId == fromId)
			{
				if(isFinal == false)
				{
					Show();
				}
			}
		}
		
		public void Init()
		{
			UnitCtl fromUnitCtl = War.scene.GetBuild(fromId);
			UnitCtl toUnitCtl = War.scene.GetBuild(toId);
			
			mt = guidePanel.MoveWorld(id, fromUnitCtl.transform.position, toUnitCtl.transform.position, GuideMoveToPanel.ViewType.Send);
			
			
			War.signal.sHandDownBuild += OnHandDownBuild;
			War.signal.sHandSendArm += OnHandSendArm;
			War.signal.sHandUpBuild += OnHandUpBuild;
			War.signal.sPause += Hide;
			War.signal.sResume += Show;
		}
		
		public void Hide()
		{
			if(mt != null)
			{
				mt.gameObject.SetActive(false);
			}
		}
		
		
		public void Show()
		{
			if(mt != null)
			{
				mt.gameObject.SetActive(true);
				mt.Play();
			}
		}
		
		public void Close()
		{
			
			if(guidePanel != null) guidePanel.CloseMoveTo(id);
			
			War.signal.sHandDownBuild -= OnHandDownBuild;
			War.signal.sHandSendArm -= OnHandSendArm;
			War.signal.sHandUpBuild -= OnHandUpBuild;
			War.signal.sPause -= Hide;
			War.signal.sResume -= Show;

			guidePanel = null;
			mt = null;
		}
	}
}
