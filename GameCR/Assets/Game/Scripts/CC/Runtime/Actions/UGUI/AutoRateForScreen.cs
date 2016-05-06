using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoRateForScreen : MonoBehaviour
{
	public enum Model
	{
		Expand,
		ExpandWidth,
		Shrink,
	}

	public enum CanvasScaleModel
	{
		None,
		ScaleExpand,
		ScaleShrink,

	}

	private CanvasScaler canvasScaler;
	private CanvasScaleModel canvasScaleModel;
	public Model model;
	public bool isUpdate = false;
	public float devWidth = 960f;
	public float devHeight = 640f;
	private float devAspect;
	private int screenWidth = 960;
	private int screenHeight = 640;
	private float rate;



	void Start () 
	{
		if(canvasScaler == null)
		{
			Transform node = transform;
			while(node != null)
			{
				canvasScaler = node.GetComponent<CanvasScaler>();
				if(canvasScaler != null)
				{
					break;
				}
				node = node.parent;
			}
		}

		if(canvasScaler == null)
		{
			canvasScaleModel = CanvasScaleModel.None;
		}
		else
		{
			if(canvasScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
			{
				if(canvasScaler.screenMatchMode == CanvasScaler.ScreenMatchMode.Expand)
				{
					canvasScaleModel = CanvasScaleModel.ScaleExpand;
				}
				else if(canvasScaler.screenMatchMode == CanvasScaler.ScreenMatchMode.Shrink)
				{
					canvasScaleModel = CanvasScaleModel.ScaleShrink;
				}
			}
			else
			{
				canvasScaleModel = CanvasScaleModel.None;
			}
		}


		devAspect = devWidth / devHeight;
		Set();
	}

	void Update () 
	{
		if(isUpdate)
		{
			if(screenWidth != Screen.width || screenHeight != Screen.height)
			{
				Set();
			}
		}
	}

	void Set()
	{

		screenWidth = Screen.width;
		screenHeight = Screen.height;
		float aspect = screenWidth * 1F / screenHeight;

		if(model == Model.Expand)
		{
			if(canvasScaleModel == CanvasScaleModel.ScaleExpand)
			{
				rate = 1f;
			}
			else if(canvasScaleModel == CanvasScaleModel.ScaleShrink)
			{

				if(aspect >= devAspect)
				{
					rate = screenHeight /  devHeight / (screenWidth / devWidth);
				}
				else
				{
					rate = screenWidth / devWidth / (screenHeight /  devHeight);
				}

			}
			else
			{
				if(aspect >= devAspect)
				{
					rate = screenHeight /  devHeight;
				}
				else
				{
					rate = screenWidth / devWidth;
				}
			}
		}
		else if(model == Model.ExpandWidth)
		{

			if(canvasScaleModel == CanvasScaleModel.ScaleExpand)
			{
				if(aspect >= devAspect)
				{
					rate = 1f;
				}
				else
				{
					rate = aspect / devAspect;
				}

			}
			else if(canvasScaleModel == CanvasScaleModel.ScaleShrink)
			{
				
				if(aspect >= devAspect)
				{
					rate = screenHeight /  devHeight / (screenWidth / devWidth);
				}
				else
				{
					rate = screenWidth / devWidth / (screenHeight /  devHeight) * (aspect / devAspect);
				}
				
			}
			else
			{
				if(aspect >= devAspect)
				{
					rate = screenHeight /  devHeight;
				}
				else
				{
					rate = screenWidth / devWidth * (aspect / devAspect);
				}
			}


		}
		else if(model == Model.Shrink)
		{

			if(canvasScaleModel == CanvasScaleModel.ScaleShrink)
			{
				rate = 1f;
			}
			else if(canvasScaleModel == CanvasScaleModel.ScaleExpand)
			{
				if(aspect <= devAspect)
				{
					rate = screenHeight /  devHeight / (screenWidth / devWidth);
				}
				else
				{
					rate = screenWidth / devWidth / (screenHeight /  devHeight);
				}
			}
			else
			{
				if(aspect <= devAspect)
				{
					rate = screenHeight /  devHeight;
				}
				else
				{
					rate = screenWidth / devWidth;
				}
			}
		}



		transform.localScale = Vector3.one * rate;
	}
}
