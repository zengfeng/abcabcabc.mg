using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using CC.Runtime;

public class WarInput 
{
	public bool sendArm = true;
	public bool uplevel = true;
	public bool useSkill = true;


	public void Normal()
	{
		sendArm = true;
		uplevel = true;
		useSkill = true;
	}

	public void Skill()
	{
		sendArm = false;
		uplevel = false;
		useSkill = false;
	}

	public bool HitUI
	{
		get
		{
			if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
			{
//				return true;
			}

		
			Ray ray = Coo.uiCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, 1000, WarLayer.UI);
//			Debug.Log(hit2D + "  "+ hit2D.collider);
			return hit2D != null && hit2D.collider != null;
		
		}
	}


}
