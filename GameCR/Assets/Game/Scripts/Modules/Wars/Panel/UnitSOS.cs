using UnityEngine;
using System.Collections;
namespace Games.Module.Wars
{
	public class UnitSOS : WBaseUI
	{
		
		public bool visiable = true;


		
		public void SetVisible(bool visiable)
		{
			if(this.visiable != visiable)
			{
				this.visiable = visiable;
				gameObject.SetActive(visiable);
			}
		}

	}

}