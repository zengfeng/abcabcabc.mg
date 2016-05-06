using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum UIDepthVal
{
    BlurBG = 1,
    Module = 500,
    MainUI = 600,
    Dialog = 650,
    Guide = 700,
}

public class UIDepth : MonoBehaviour {
    public UIDepthVal depth = UIDepthVal.Module;
    public int order;
	public bool isUI = true;
	public bool raycaster = true;
	void Start () 
	{
		if(isUI){
			Canvas canvas = GetComponent<Canvas>();
			if( canvas == null){
				canvas = gameObject.AddComponent<Canvas>();
				if(raycaster)
				{
					gameObject.AddComponent<GraphicRaycaster>();
				}
			}
			canvas.overrideSorting = true;
			canvas.sortingOrder = ((int)depth) + order;
		}
		else
		{
			Renderer []renders  =  GetComponentsInChildren<Renderer>();
			
			foreach(Renderer render in renders){
				render.sortingOrder = ((int)depth) + order;
            }
		}
	}


    [ContextMenu("UpdateQueue")]
    public void UpdateQueue()
    {
        Renderer[] renders = GetComponentsInChildren<Renderer>();

        foreach (Renderer render in renders)
        {
            render.sortingOrder = ((int)depth) + order;
        }
    }
}