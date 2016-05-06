using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class CameraController : MonoBehaviour
	{
		public Transform zoomCtl;
		public Vector2 sourceSize = new Vector2(960F, 640F);
		public bool isUpdate = false;
		public float sourceZoom = -100;
		public float minZoom = -100;
		public float maxZoom = -100;
		public float sourceRate;
		public float nowRate;
		public float r;
		public Camera camera;
		public float sourceOrthographicSize = 20f;
		public float minOrthographicSize = 19f;
		public float maxOrthographicSize = 22f;

		void Start ()
		{
			sourceZoom = zoom;
			sourceRate = sourceSize.x / sourceSize.y;

			if(camera == null) camera = Camera.main;
			sourceOrthographicSize = camera.orthographicSize;
		}

		void Update () 
		{
			Setting();
		}

		public void Setting()
		{
			nowRate = (float)Screen.width / (float)Screen.height;
			r = sourceRate < nowRate ? sourceRate / nowRate :  nowRate / sourceRate;

			float size = r * sourceOrthographicSize;
			if(size < minOrthographicSize) camera.orthographicSize = minOrthographicSize;
			if(size > maxOrthographicSize) camera.orthographicSize = maxOrthographicSize;
//			zoom = r * sourceZoom;
		}

		public float zoom
		{
			get
			{
				return zoomCtl.localPosition.z;
			}

			set
			{
				zoomCtl.localPosition = zoomCtl.localPosition.SetZ(value);
			}
		}
	}
}
