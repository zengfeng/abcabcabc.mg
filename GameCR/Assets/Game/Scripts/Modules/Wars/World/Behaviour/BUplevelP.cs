using UnityEngine;
using System.Collections;
using CC.Runtime;


namespace Games.Module.Wars
{
	public class BUplevelP : EBehaviour
	{
		public Transform anchorImageUplevel;
		public HolderView uplevelView;
		public UplevelView uplevelView2;
		public SkillOperateSelectUnitView_Build skillOperateSelectUnitView;


		protected override void OnAwake ()
		{
			base.OnAwake ();
			anchorImageUplevel = transform.FindChild(UnitAnchorName.ImageUplevel);
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			
			Coo.assetManager.Load(WarRes.UplevelView, OnLoadRes);
		}

		protected void OnLoadRes(string name, System.Object obj)
		{
			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
			go.transform.SetParent(anchorImageUplevel);
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			uplevelView = go.GetComponent<HolderView>();
			uplevelView.visible = false;

			uplevelView2 = go.GetComponent<UplevelView>();
			
			Set();
		}

		public RelationType _relation = RelationType.None;
		private bool _enableLevel = false;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			Set();
		}

		public void Set()
		{
			if(uplevelView == null) return;

			if(_relation != unitData.relation)
			{
				_relation = unitData.relation;
				if(_relation == RelationType.Own)
				{
					uplevelView2.SetLevel(levelData.Level);
					uplevelView.visible = levelData.EnableUpLevel;
				}
				else
				{
					uplevelView.visible = false;
				}
			}

			if(_relation == RelationType.Own)
			{
				if(_enableLevel != levelData.EnableUpLevel)
				{
					_enableLevel = levelData.EnableUpLevel;
					
					if(_enableLevel)
					{
						uplevelView2.SetLevel(levelData.Level);
						uplevelView.visible = !skillOperateSelectUnitView.isShowDelayHide;
						event3D.sDoubleClick.AddListener(OnDoubleClick);
						event3D.sClick.AddListener(OnClick);
					}
					else
					{
						uplevelView.visible = false;
						event3D.sDoubleClick.RemoveListener(OnDoubleClick);
						event3D.sClick.RemoveListener(OnClick);

						skillOperateSelectUnitView.CancelShow ();
					}
				}
			}
		}
		
		virtual protected void OnDoubleClick()
		{
			if(War.input.uplevel)
			{
				levelData.Uplevel();
			}
		}

		virtual protected void OnClick()
		{
			if (skillOperateSelectUnitView.isShowDelayHide) 
			{
				OnDoubleClick ();
			} 
			else 
			{

				StopAllCoroutines ();
				uplevelView.visible = false;
				skillOperateSelectUnitView.ShowDelayHide (SkillOperateSelectUnitIconType.Uplevel, false, unitData.level, 0.3f, 3f);
				StartCoroutine (DelaySetUplevelView(3.3f));

			}
		}


		IEnumerator DelaySetUplevelView(float time)
		{
			yield return new WaitForSeconds (time);
			uplevelView.visible = _enableLevel;
		}



	}
}
