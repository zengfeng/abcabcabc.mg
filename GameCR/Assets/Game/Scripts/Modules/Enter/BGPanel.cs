using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;

public class BGPanel : MonoBehaviour 
{
	public GameObject bgPanel;
	public bool isLoadSceneing = false;
	private bool _visiable = true;
	void Start ()
	{
	
	}

	void Update () 
	{
//		if (GameScene.IsEnter () == false)
//		{
//
//			DelayDestory delayDestory = bgPanel.GetComponent<DelayDestory> ();
//			if (delayDestory == null)
//				bgPanel.AddComponent<DelayDestory> ();
//
//			delayDestory.DelayTime = 5;
//			delayDestory.enabled = true;
//			this.enabled = false;
//			Destroy (this);
//		}

		bool visiable = isLoadSceneing;
		if(visiable == false) visiable = Application.loadedLevelName != "War";
		if(visiable != _visiable)
		{
			_visiable = visiable;
			bgPanel.SetActive(_visiable);

			if(_visiable)
			{
				DelayUnactive delayUnactive = bgPanel.GetComponent<DelayUnactive> ();
				if (delayUnactive == null)
					delayUnactive = bgPanel.AddComponent <DelayUnactive>();

				delayUnactive.DelayTime = 5;
				delayUnactive.finalDisable = true;
				delayUnactive.enabled = true;
			}
		}

	}
}
