
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime.Utils;

	public class WE_UnitSelect : MonoBehaviour {
		
		public LayerMask layerMask;
		void Start () {
			layerMask.value = WarLayer.Unit | WarLayer.ObstacleStar | WarLayer.ObstacleRay;
		}
		
		void Update () 
		{
			if(transform.position.y != 0)
			{
				transform.position = transform.position.SetY(0);
			}

			if(Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 300, layerMask.value))
				{
					Debug.DrawLine(ray.origin, hit.point);

					Transform select = hit.collider.transform;
					if(select.GetComponent<UnitCtl>() == null)
					{
						select = select.parent;
						if(select != null && select.GetComponent<UnitCtl>() == null)
						{
							select = select.parent;
							if(select != null && select.GetComponent<UnitCtl>() == null)
							{
								select = select.parent;

								if(select != null && select.GetComponent<UnitCtl>() == null)
								{
									select = hit.collider.transform;
								}
							}
						}
					}

					if(select == null)
					{
						select = hit.collider.transform;
					}
					Selection.activeGameObject = select.gameObject;
				}
			}
		}
	}
#endif