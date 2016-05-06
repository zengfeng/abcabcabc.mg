using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Wars;

public class TestWarStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenStage(int stageId)
	{
		Coo.menuManager.OpenMenu(121, stageId);
	}

	public void OpenMenu(int menuId)
	{
		Coo.menuManager.OpenMenu(menuId);
	}

	public void Pause()
	{

	}

	public void Resume()
	{

	}

	public void RestStart()
	{
		War.ResetStart();
	}

	public void Win()
	{
		War.Over(OverType.Win);
	}

	public void Lose()
	{
		War.Over(OverType.Lose);
	}

	public void BuildChangeLegion(int buildId)
	{
		UnitCtl unitCtl = War.scene.GetBuild(buildId);
		unitCtl.unitData.ChangeLegion(unitCtl.legionData.legionId == 1 ? 2 : 1);
	}

	public void SetPlaySpeed(float timeScale)
	{
		Time.timeScale = timeScale;
	}

	public void SetPlaySpeedNormal()
	{
		Time.timeScale = 1;
	}

	public void AddPlaySpeed(float val)
	{
		Time.timeScale += val;
	}


	public void RecordSaveJSON()
	{
		War.recordManager.timeLineData.SaveJSON ();
	}



	public void RecordSaveBinary()
	{
		War.recordManager.timeLineData.SaveBytes ();
	}

	public void RecordSave()
	{
		War.record.Save(War.GetWarOverData());
	}


	public void Disperse(int buildId)
	{
		UnitCtl unitCtl = War.scene.GetBuild (buildId);
		BSendArming sendArming = unitCtl.GetComponent<BSendArming> ();
		int count = 20;
		if (count > War.scene.buildList.Count)
			count = War.scene.buildList.Count;
		
		for(int i = 1; i <= count; i++)
		{
			if (i == buildId)
				continue;

			sendArming.Send ( War.scene.GetBuild (i), 100, 10f);
		}
	}
}
