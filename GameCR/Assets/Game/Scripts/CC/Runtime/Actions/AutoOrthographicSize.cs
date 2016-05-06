using UnityEngine;
using System.Collections;

public class AutoOrthographicSize : MonoBehaviour 
{
	public enum Mode
	{
		ExpandWidth,
		ExpandHeight,
		ExpandAll,
		ShrinkAll,

	}

//	public float orthographicSize;
//	public int pixelWidth;
//	public int pixelHeight;
//	public Rect pixelRect;
//	public Rect rect;
//	public Vector3 velocity;
//	
//	public float newOrthographicSize;
//	
//	public int sceneWidth;
	//	public int sceneHeight;
//	private float width = 9.6f;
//	private float height;
	
	public Camera camera;
	/** 屏幕的纵横比 */
	private float aspect;
	private float devAspect;

	public float devWidth = 9.6f;
	public float devHeight = 6.4f;
	public Mode mode;
	public float scale = 1f;

	void Start () 
	{
		if(camera == null) camera = GetComponent<Camera>();
		
		devAspect = devWidth / devHeight;
	}

	void Update () 
	{
		aspect = camera.aspect;
//		orthographicSize = camera.orthographicSize;
//		pixelWidth = camera.pixelWidth;
//		pixelHeight = camera.pixelHeight;
//		pixelRect = camera.pixelRect;
//		rect = camera.rect;
//		velocity = camera.velocity;
//
//		sceneWidth = Screen.width;
//		sceneHeight = Screen.height;
//		
//		height = orthographicSize * 2f;
//		width = height * aspect;
//
//		
//		newOrthographicSize = devWidth / (2f * aspect);

		if(mode == Mode.ExpandWidth)
		{
			camera.orthographicSize =scale * devWidth / (2f * aspect);
		}
		else if(mode == Mode.ExpandHeight)
		{
			camera.orthographicSize = scale * devHeight / 2F;
		}
		else if(mode == Mode.ExpandAll)
		{
			if(devAspect <= aspect)
			{
				camera.orthographicSize = scale * devHeight / 2F;
			}
			else
			{
				camera.orthographicSize = scale * devWidth / (2f * aspect);
			}
		}
		else if(mode == Mode.ShrinkAll)
		{
			if(devAspect >= aspect)
			{
				camera.orthographicSize = scale * devHeight / 2F;
			}
			else
			{
				camera.orthographicSize = scale * devWidth / (2f * aspect);
			}
		}


	}
}
