using UnityEngine;
using System.Collections;
using SimpleFramework;
using CC.Module.Loads;

public class LuaScreenLoadPanel : LuaBehaviour 
{
	public SceneLoader sceneLoader;
	protected override void Start ()
	{
		base.Start ();
		if(sceneLoader == null) sceneLoader = transform.parent.GetComponent<SceneLoader>();
		if(sceneLoader == null) sceneLoader = transform.GetComponent<SceneLoader>();
		
		if(sceneLoader != null)
		{
			sceneLoader.sSetState += SetState;
			sceneLoader.sSetProgress += SetProgress;
		}
	}

	protected override void OnDestroy ()
	{
		
		CallMethod("OnDestroy");

		base.OnDestroy ();

		if(sceneLoader != null)
		{
			sceneLoader.sSetState -= SetState;
			sceneLoader.sSetProgress -= SetProgress;
		}
	}

	public void SetState(string txt)
	{
		CallMethod("SetState", txt);
	}

	
	
	public void SetProgress(float progress, int index, int count, string file)
	{
		CallMethod("SetProgress", progress, index, count, file);
	}




}
