using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;


namespace Games.Guides
{
	public class AbstractMoveToView : MonoBehaviour 
	{
		
		public RectTransform fromTransform;
		public RectTransform toTransform;
		public bool isPlay;

		public virtual void Move(Vector3 from, Vector3 to)
		{
			fromTransform.position = from;
			toTransform.position = to;
			
			Play();
		}
		
		public virtual void Move(RectTransform from, RectTransform to)
		{
			fromTransform = from;
			toTransform = to;
			
			Play();
		}

		public virtual void MoveWorld(Vector3 from, Vector3 to)
		{
			MoveWorld(from, to, Camera.main);
		}
		
		
		public virtual void MoveWorld(Vector3 from, Vector3 to, Camera camera)
		{
			
			float rate = ScreenUtil.GetRate();
			
			Vector3 pt = camera.WorldToScreenPoint(from);
			pt.z = 0;
			fromTransform.anchoredPosition = pt * rate;
			
			pt = camera.WorldToScreenPoint(to);
			pt.z = 0;
			toTransform.anchoredPosition = pt * rate;
			
			
			Play();
		}
		
		
		public virtual void MoveWorld(Transform from, Transform to)
		{
			MoveWorld(from, to, Camera.main);
		}
		
		
		public virtual void MoveWorld(Transform from, Transform to, Camera camera)
		{
			MoveWorld(from.position, to.position, camera);
		}

		public virtual void Play()
		{
		}

		
		public virtual void Stop()
		{
			isPlay = false;
		}



	
	}
}