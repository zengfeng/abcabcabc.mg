using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class SetSiblingIndex : MonoBehaviour 
	{
		public int sortOrder = -1;
		private int _sortOrder;

		void Start () 
		{
			SetIndex();
		}

		void Update () 
		{
			if(_sortOrder != sortOrder)
			{
				SetIndex();
			}
		}

		[ContextMenu("SetSiblingIndex")]
		public void SetIndex()
		{
			if(sortOrder != -1)
			{
				transform.SetSiblingIndex(sortOrder);
			}
		}
	}
}
