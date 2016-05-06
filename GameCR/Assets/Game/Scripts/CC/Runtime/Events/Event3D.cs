using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using CC.Runtime.signals;
namespace CC.Runtime
{
	public class Event3D : MonoBehaviour 
	{
		public HSignal sDoubleClick = new HSignal();
		public HSignal sDown = new HSignal();
		public HSignal sClick = new HSignal();


		public LayerMask layerMask;
		public float maxDistance = 200F;
		private bool isDoubleClick = false;
		private int clickCount = 0;
		private float downTime = 0F;
		void Update () 
		{
			if(Input.GetMouseButtonDown(0))
			{
//				if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
//				{
					if(IsSelf())
					{
						OnDown();
						downTime = Time.time;
					}
//				}
			}

			if(Input.GetMouseButtonUp(0))
			{
//				if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
//				{
					if(IsSelf())
					{
						if(Time.time - downTime <= 0.5F)
						{
							clickCount ++;

							if(clickCount == 1)
							{
								OnClick();
							}

							if(clickCount == 2)
							{
								isDoubleClick = true;
								OnDoubleClick();
							}
						}
					}
//				}
			}

			if(Time.time - downTime > 0.5F)
			{
				clickCount = 0;
				downTime = 0F;
				isDoubleClick = false;
			}

		}

		bool IsSelf()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, maxDistance, layerMask.value))
			{
				if(hit.collider.gameObject == gameObject)
				{
					return true;
				}
			}
			return false;
		}

		void OnDoubleClick()
		{
			sDoubleClick.Dispatch();
		}

		void OnClick()
		{
			// Debug.Log("Event3D.OnClick");
			sClick.Dispatch();
		}

		void OnDown()
		{
			sDown.Dispatch();
		}

	}
}
