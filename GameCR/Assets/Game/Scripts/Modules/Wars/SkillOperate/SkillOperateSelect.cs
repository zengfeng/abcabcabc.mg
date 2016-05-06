using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SkillOperateSelect : MonoBehaviour 
	{
		public SkillOperateController selected;
		public bool isDown;
		public Vector3 mousePosition;


		void Awake()
		{
			War.skillOperateSelect = this;
		}

		void Update()
		{
			if(selected != null && selected.data != null)
			{
				if(Input.GetMouseButtonDown(0) && !War.input.HitUI)
				{
					selected.OnPointerDownHandler();
					selected.OnBeginDragHandler();
				}


				if(selected.isDraging)
				{
					selected.OnDragHandler();
				}
				
				
				if(Input.GetMouseButtonUp(0))
				{
					selected.CancelDrag();
				}
			}
		}

		void Update2()
		{
			if(selected != null && selected.data != null)
			{
				if(isDown == false && Input.GetMouseButtonDown(0) && !War.input.HitUI)
				{
					//					Debug.Log("Input.GetMouseButtonDown(0)");
					isDown = true;
					mousePosition = Input.mousePosition;
				}
				
				
				if(isDown && !selected.isDraging)
				{
					if(Vector3.Distance(mousePosition, Input.mousePosition) > 0.1f)
					{
						selected.OnPointerDownHandler();
						selected.OnBeginDragHandler();
					}
				}
				
				
				if(selected.isDraging)
				{
					selected.OnDragHandler();
				}
				
				
				if(Input.GetMouseButtonUp(0))
				{
					isDown = false;
					selected.CancelDrag();
				}
			}
			else
			{
				isDown = false;
			}
			
			
		}

		public void CancelSelect(SkillOperateController controller)
		{
			if(selected == controller)
			{
				selected = null;
				War.input.Normal();
				
				War.skillUse.selectImmediatelyView.gameObject.SetActive(false);
			}



		}

		public void SetSelect(SkillOperateController controller)
		{
			if(selected != null && selected != controller)
			{
				CancelSelect(selected);
			}
			selected = controller;
			War.input.Skill();
			War.skillUse.selectImmediatelyView.gameObject.SetActive(true);
		}

	}
}
