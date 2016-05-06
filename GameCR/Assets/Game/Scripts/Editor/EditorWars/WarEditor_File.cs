
using UnityEngine;
using UnityEditor;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;
using System.IO;
using System.Collections.Generic;

namespace Game.Editors.Wars
{
	public class WarEditor_File
	{


		public static bool SaveStageConfig(StageConfig stageConfig)
		{
			if(War.isEditor == false) return false;

			bool result = true;

			StageConfig sourceStageConfig = War.model.GetStage(stageConfig.id);
			if(sourceStageConfig != null)
			{
				if(!EditorUtility.DisplayDialog("保存关卡配置", string.Format("已存在编号为{0} （{1}）的关卡，是否替换？", stageConfig.name, sourceStageConfig.name), "替换", "取消"))
				{
					return false;
				}

				War.model.stageConfigs_Index.Remove(stageConfig.id);
				War.model.stageConfigs_Index.Add(stageConfig.id, stageConfig);
			}
			else
			{
				War.model.stageConfigs_Index.Add(stageConfig.id, stageConfig);
			}

			stageConfig.resource = War.sceneData.mapConfig.id;

			SaveStagePosition(stageConfig);

			Save_stage_csv();

			SaveStateIcon();

			return result;
		}

		public static bool SaveStagePosition(StageConfig stageConfig)
		{
			bool result = true;
			List<StagePositionConfig> list = new List<StagePositionConfig>();

			GameObject root = GameObject.Find("Scene/Caserns");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform itemTransform =  root.transform.GetChild(i);
					if(itemTransform.gameObject.activeSelf )
					{
						UnitCtl unitCtl = itemTransform.GetComponent<UnitCtl>();
						if(unitCtl != null && unitCtl.unitData != null && unitCtl.unitData.we_BuildConfigData != null)
						{
							UnitData unitData = unitCtl.unitData;
							WE_BuildConfigData buildConfigData = unitCtl.unitData.we_BuildConfigData;
							StagePositionConfig positionConfig = new StagePositionConfig();
							positionConfig.stageId = stageConfig.id;
							positionConfig.index = list.Count + 1;
							positionConfig.position = itemTransform.position;
							positionConfig.hp = buildConfigData.hp;
							positionConfig.legionId = unitData.legionId;
							positionConfig.unitType = unitData.unitType;
							positionConfig.buildType = unitData.buildType;
							positionConfig.buildUid = buildConfigData.buildConfig.id;
							positionConfig.level = unitData.level;
							positionConfig.settledPriority = buildConfigData.settledPriority;
							positionConfig.name = buildConfigData.buildConfig.name;
							positionConfig.stageName = stageConfig.name;

							list.Add(positionConfig);
						}
					}
				}
			}

			root = GameObject.Find("Scene/Walls");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform itemTransform =  root.transform.GetChild(i);
					if(itemTransform.gameObject.activeSelf )
					{
						UnitCtl unitCtl = itemTransform.GetComponent<UnitCtl>();
						if(unitCtl != null && unitCtl.unitData != null && unitCtl.unitData.we_BuildConfigData != null)
						{
							UnitData unitData = unitCtl.unitData;
							WE_BuildConfigData buildConfigData = unitCtl.unitData.we_BuildConfigData;
							StagePositionConfig positionConfig = new StagePositionConfig();
							positionConfig.stageId = stageConfig.id;
							positionConfig.index = list.Count + 1;
							positionConfig.position = itemTransform.position;
							positionConfig.hp = buildConfigData.hp;
							positionConfig.legionId = unitData.legionId;
							positionConfig.unitType = unitData.unitType;
							positionConfig.buildType = unitData.buildType;
							positionConfig.buildUid = buildConfigData.buildConfig.id;
							positionConfig.level = 0;
							positionConfig.name = buildConfigData.buildConfig.name;
							positionConfig.stageName = stageConfig.name;
							
							list.Add(positionConfig);
						}
					}
				}
			}

			
			if(War.model.stagePositionConfigs.ContainsKey(stageConfig.id))
			{
				War.model.stagePositionConfigs.Remove(stageConfig.id);
			}

			War.model.stagePositionConfigs.Add(stageConfig.id, list);

			stageConfig.GenerationPositionData();
			
			Save_stage_position_csv();
			return result;
		}


		public static void Delete(int stageId)
		{
			if(War.model.stageConfigs_Index.ContainsKey(stageId))
			{
				War.model.stageConfigs_Index.Remove(stageId);
				War.model.stagePositionConfigs.Remove(stageId);
				Save_stage_csv();
				Save_stage_position_csv();

				RemoveStageIcon(stageId);
			}
		}




		public static void Save_stage_csv()
		{
			
			string path = "Assets/Game/Config/stage.csv";

			List<StageConfig> list = new List<StageConfig>(); 
			foreach(var item in War.model.stageConfigs_Index)
			{
				list.Add(item.Value);
			}

			list.Sort((StageConfig a, StageConfig b) => { return a.id - b.id;});

			
			if (File.Exists(path)) File.Delete(path);

			FileStream fs = new FileStream(path, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);


			string head1 = "编号;名称;描述;关卡类型;解锁关卡;美术资源编号;掉落编号;星级评价;胜利条件;挂载脚本;消耗体力;限时;求救提示;关卡等级;血条开关;中立主公等级;联盟关系;势力0;势力0类型;势力0颜色;开放功能0;机器人ID;势力1;势力1类型;势力1颜色;开放功能1;机器人ID;势力2;势力2类型;势力2颜色;开放功能2;机器人ID;势力3;势力3类型;势力3颜色;开放功能3;机器人ID;势力4;势力4类型;势力4颜色;开放功能4;机器人ID";
			string head2 = "id;name;description;type;nextStageId;resource;dropID;stars;win;luaID;costStrength;time;sos;level;showHP;neutralRoleLevel;LegionRelation;legion;legionType;color;produce;robotId;legion;legionType;color;produce;robotId;legion;legionType;color;produce;robotId;legion;legionType;color;produce;robotId;legion;legionType;color;produce;robotId";

			sw.WriteLine(head1);
			sw.WriteLine(head2);

			for(int i = 0; i < list.Count; i ++)
			{
				sw.WriteLine(list[i].ToCsv());
			}


			sw.Close(); fs.Close();
//			AssetDatabase.Refresh();

			Debug.Log(path);
		}


		public static void Save_stage_position_csv()
		{
			
			string path = "Assets/Game/Config/stage_position.csv";


			Dictionary<int, List<StagePositionConfig>> stagePositionConfigs = War.model.stagePositionConfigs;
			stagePositionConfigs.Sort<List<StagePositionConfig>>();


			
			
			if (File.Exists(path)) File.Delete(path);
			
			FileStream fs = new FileStream(path, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);


			string head1 = "关卡编号;建筑编号;X坐标;Y坐标;人口配置;势力ID;单位类型;建筑类型;建筑等级;建筑参数;英雄上阵优先级;备注;备注";
			string head2 = "stageId;buldIndex;X;y;hp;legionId;unitType;buildType;buldLeve;typeUid;settledPriority;ps2;ps1";

			sw.WriteLine(head1);
			sw.WriteLine(head2);
			
			foreach(var stagePositionList in stagePositionConfigs)
			{
				foreach(StagePositionConfig positionConfig in stagePositionList.Value)
				{
					sw.WriteLine(positionConfig.ToCsv());
				}
			}
			
			sw.Close(); fs.Close();
//			AssetDatabase.Refresh();
			
			Debug.Log(path);
		}

		
		static string stageIconRoot = "Assets/EditorDefaultResources/StageIcon/";
		public static void SaveStateIcon()
		{
			PathUtil.CheckPath(stageIconRoot, false);
			string filename = stageIconRoot + War.sceneData.id + ".png";
			ScreenshotTool.Shot(Camera.main, 300, 200, false, filename);

			string file_1920x1280 = Application.dataPath + "/../../../document/策划案/关卡截图/" + War.sceneData.id + ".png";
			PathUtil.CheckPath(file_1920x1280, true);
			ScreenshotTool.Shot(Camera.main, 1920, 1280, false, file_1920x1280);
			
			AssetDatabase.Refresh();
			
			WarEditor_StageWindow.RefreshStageIcon( War.sceneData.id);
		}

		public static void RemoveStageIcon(int id)
		{
			string filename = stageIconRoot + id + ".png";
			if(File.Exists(filename)) File.Delete(filename);
			AssetDatabase.Refresh();

			WarEditor_StageWindow.RefreshStageIcon(id);
		}

		public static void SaveStagePathData()
		{
			GameObject go = GameObject.Find("WarEditorScene");
			if(go != null)
			{
				go.GetComponent<WE_StagePathManager>().Init();
			}
		}


	}
}