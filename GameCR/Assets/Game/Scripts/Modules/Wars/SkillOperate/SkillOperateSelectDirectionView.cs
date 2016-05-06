using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class SkillOperateSelectDirectionView : MonoBehaviour
	{
		private const float WIDTH = 2F;
		private const float DISTANCE = 12F;
		public Transform icon;
	
		public float width = 2F;
		public float distance = 12F;

		public float Width
		{
			get
			{
				return width;
			}

			set
			{
				width = value;
				Set();
			}
		}

		public float Distance
		{
			get
			{
				return distance;
			}
			
			set
			{
				distance = value;
				Set();
			}
		}

		void Set()
		{
			icon.transform.localScale = new Vector3(width / WIDTH, 1f, distance / DISTANCE);
		}

		void OnEnable()
		{
			Set();
		}

	}
}