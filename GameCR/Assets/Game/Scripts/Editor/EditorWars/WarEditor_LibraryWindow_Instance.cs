using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Games.Module.Wars;
using System;
using System.Reflection;
using UnityEditor.AnimatedValues;
using Games.Module.Avatars;
using Games.Cores;
using CC.Runtime;
using Games.Module.Props;


namespace Game.Editors.Wars
{

	public partial class WarEditor_LibraryWindow 
	{

		public int GetMaxIndex()
		{
			int maxId = 0;
			foreach(var item in War.sceneData.buildDict)
			{
				if(maxId < item.Value.id)
				{
					maxId = item.Value.id;
				}
			}

			foreach(var item in War.sceneData.wallDict)
			{
				if(maxId < item.Value.id)
				{
					maxId = item.Value.id;
				}
			}
			return maxId;
		}

		public void OnReplaceSelect(int colorId, int level, AbstractBuildConfig buildConfig, object parameter)
		{
			UnitCtl unitCtl = (UnitCtl) parameter;
			bool result = false;
			if(buildConfig is BuildWallConfig)
			{
				result = Create_Wall((BuildWallConfig)buildConfig, unitCtl.transform.position);
			}
			else
			{
				result = Create_Build(colorId, level,  buildConfig, unitCtl.transform.position, unitCtl.unitData.we_BuildConfigData);
			}

			if(result) GameObject.Destroy(unitCtl.gameObject);
		}

		
		public void Click_Build(int colorId, int level, BuildConfig buildConfig)
		{
			if(sOnSelect != null)
			{
				sOnSelect(colorId, level, buildConfig, onSelect_parameter);
				sOnSelect = null;
				onSelect_parameter = null;
			}
			else
			{
				Create_Build(colorId, level, buildConfig, new Vector3(-22, 0, 17), null);
			}
		}

		public bool Create_Build(int colorId, int level, AbstractBuildConfig buildConfig, Vector3 position, WE_BuildConfigData weBuildConfig = null)
		{
			if(War.sceneData == null)
			{
				this.ShowNotification(new GUIContent("请先‘选择关卡’或者去‘新建关卡’"));
				return false;
			}

			if(!War.sceneData.legionDict.ContainsKey(colorId))
			{
				this.ShowNotification(new GUIContent("关卡没有配置'" + WarColor.Names[colorId]+ "'势力，请先到（关卡/关卡配置）里添加势力"));
				return false;
			}

			int initHP = weBuildConfig == null ? 0 : weBuildConfig.hp;

			int index = GetMaxIndex() + 1;

			BuildType buildType = buildConfig.buildType;
			
			// 初始兵力--计算
			float[] firstProp = new float[PropId.MAX];
			firstProp[PropId.HpAdd] = initHP;
			
			
			// 兵营初始属性[Hp]
			float[] initProp = new float[PropId.MAX];
			initProp[PropId.InitHp] = initHP;
			
			
			War.sceneData.buildFirstProp.Add(index, firstProp);
			War.sceneData.buildInitProp.Add(index, initProp);
			
			// 生成兵营UnitData
			UnitData unitData = new UnitData();
			unitData.id = index;
			unitData.legionId = colorId;
			unitData.unitType = UnitType.Build;
			unitData.buildType = buildType;
			unitData.level = level;
			unitData.position = position;
			unitData.buildConfig = (BuildConfig)buildConfig;
			unitData.we_BuildConfigData = new WE_BuildConfigData();
			unitData.we_BuildConfigData.buildConfig = buildConfig;
			if (weBuildConfig != null) 
			{
				unitData.we_BuildConfigData.hp = weBuildConfig.hp;
				unitData.we_BuildConfigData.settledPriority = weBuildConfig.settledPriority;
			}
			unitData.hp = 0;
			unitData.avatarId = buildConfig.avatarId;




			War.sceneData.InitAttachPropData(index);
			War.sceneData.buildDict.Add(index, unitData);
			
			Selection.activeGameObject = War.sceneCreate.GenerationBuild(unitData);

			return true;
		}


		public void Click_Wall(BuildWallConfig wallConfig)
		{
			if(sOnSelect != null)
			{
				sOnSelect(1, 1, wallConfig, onSelect_parameter);
				sOnSelect = null;
				onSelect_parameter = null;
			}
			else
			{
				Create_Wall(wallConfig, new Vector3(-22, 0, 17));
			}

		}

		public bool Create_Wall(BuildWallConfig wallConfig, Vector3 position)
		{
			if(War.sceneData == null)
			{
				this.ShowNotification(new GUIContent("请先‘选择关卡’或者去‘新建关卡’"));
				return false;
			}

			
			int index = GetMaxIndex() + 1;

			UnitData unitData = new UnitData();
			unitData.id = index;
			unitData.legionId = 1;
			unitData.unitType = UnitType.Wall;
			unitData.level = 0;
			unitData.position = position;
			unitData.wallConfig = wallConfig;
			unitData.avatarId = wallConfig.avatarId;

			
			unitData.we_BuildConfigData = new WE_BuildConfigData();
			unitData.we_BuildConfigData.buildConfig = wallConfig;

			War.sceneData.wallDict.Add(index, unitData);
			
			Selection.activeGameObject = War.sceneCreate.GenerationWall(unitData);

			return true;

		}
	}
}
