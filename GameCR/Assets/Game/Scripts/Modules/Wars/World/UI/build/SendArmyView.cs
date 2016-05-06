using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using CC.Runtime.signals;
using System.Collections.Generic;
using System;


namespace Games.Module.Wars
{
	public class SendArmyView : EntityView
	{
		public Action<UnitCtl>  sSelect;
		public List<UnitCtl> units = new List<UnitCtl>();
		public UnitCtl unit;
		private UnitCtl targetUnit;

		public bool isDrawing = false;
		public GameObject arrow;
		public LayerMask layerMask;
		public float nearDistance = 7F;

		protected override void OnAwake ()
		{
			base.OnAwake ();
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			arrow = transform.GetChild(0).gameObject;
		}

		void OnDisable()
		{
			targetUnit = null;
			isDrawing = false;
			if(arrow != null) arrow.SetActive(false);
		}

		
		private bool isDown = false;
		private Vector3 preMousePosition;
		private Vector3 offset;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

//			if(!unit.IsMyTeam)
//			{
//				if(isDrawing)
//				{
//					targetUnit = null;
//					isDrawing = false;
//					arrow.SetActive(false);
//				}
//				return;
//			}

			bool enableFrom = War.input.sendArm;
			if(enableFrom)
			{
				enableFrom = Games.Guides.Guide.warConfig.GetEnableSendArmFrom(unit.unitData.uid);
			}

			if(!enableFrom)
			{
				if(isDrawing)
				{
					targetUnit = null;
					isDrawing = false;
					arrow.SetActive(false);
				}
				return;
			}

			if(Input.GetMouseButtonDown(0))
			{
//				if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
//				{
					if(IsSelf())
					{
						isDown = true;
						preMousePosition = Input.mousePosition;
						War.signal.HandDownBuild (unit.unitData.id);
					}
//				}
			}

			if(isDown)
			{
				offset = Input.mousePosition - preMousePosition;
				if(offset.sqrMagnitude > 0.1F)
				{
					isDown = false;
					DrawStart();
				}

			}

			if(isDrawing)
			{
				DrawMoveing();
			}

			if(Input.GetMouseButtonUp(0))
			{
				isDown = false;
				War.signal.HandUpBuild (unit.unitData.id);
				if(isDrawing)
					DrawEnd();
			}
		}


		void DrawStart()
		{
			isDrawing = true;
			arrow.SetActive(true);
		}


		void DrawMoveing()
		{ 
			targetUnit = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 300, layerMask.value))
			{
				Debug.DrawLine(ray.origin, hit.point);
				Vector3 point = hit.point;
				targetUnit = CheckTarget(point);

				if(targetUnit != null)
					point = targetUnit.transform.position;
				point.y = 0.01f;

				float distance = Vector3.Distance(transform.position, point);
				float scale = distance / 2F;

				transform.LookAt(point);
				transform.localScale = new Vector3(Mathf.Clamp(scale, 0, 10F), 1F, scale);
			}
		}

		UnitCtl CheckTarget(Vector3 point)
		{
			UnitCtl targetUnit = null;
			float minDistance = 9999F;
			point.y = 0F;
			foreach(UnitCtl item in units)
			{
				if(item == unit) continue;
				if(item == null) continue;
				bool enableTo = Games.Guides.Guide.warConfig.GetEnableSendArmTo (item.unitData.uid);
				if(!enableTo) continue;

				float distance = Vector3.Distance(point, item.transform.position);
				if(distance <= nearDistance)
				{
					if(distance < minDistance)
					{
						targetUnit = item;
						minDistance = distance;
					}
				}
			}
			return targetUnit;
		}

		
		void DrawEnd()
		{
			if(targetUnit != null)
			{
				if(sSelect != null) sSelect(targetUnit);
			}

			targetUnit = null;
			isDrawing = false;
			arrow.SetActive(false);

		}

		
		bool IsSelf()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, layerMask.value))
			{
				if(hit.collider.gameObject == unit.gameObject)
				{
					return true;
				}
			}
			return false;
		}
	}
}