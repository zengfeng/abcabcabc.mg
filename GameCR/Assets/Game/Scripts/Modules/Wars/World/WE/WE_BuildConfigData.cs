using UnityEngine;
using System.Collections;
using Games.Module.Wars;

public class WE_BuildConfigData {

	public int hp;
	public int settledPriority = 0;
	public AbstractBuildConfig buildConfig;

	public WE_BuildConfigData()
	{

	}

	public WE_BuildConfigData(int hp)
	{
		this.hp = hp;
	}


	public WE_BuildConfigData Clone()
	{
		WE_BuildConfigData item  = new WE_BuildConfigData();
		item.hp = hp;
		item.settledPriority = settledPriority;
		item.buildConfig = buildConfig;

		return item;
	}
}
