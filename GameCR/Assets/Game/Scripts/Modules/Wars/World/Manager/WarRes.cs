using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using Games.Module.Avatars;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{

	public class WarRes
	{
		public const string SceneCanvas 					= "War/UI/War_Scene_Canvas";
		public const string HPView 							= "War/UI/War_View_HP";
		public const string SendArmy 						= "War/UI/War_View_SendArmy";
		public const string UplevelView 					= "War/UI/War_View_UplevelView";
		public const string War_View_SkillOperate_SelectUnit = "War/UI/War_View_SkillOperate_SelectUnit";

		public const string Effect_Uplevel 			= "effect_ui/CR_ui/e_eff_build_legion_change02";
		public const string Effect_DestroyExplosion = "War/Effect/War_Effect_DestroyExplosion";
		public const string Effect_Beattack = "effect3d/e_eff_build_fighting";
        public const string Effect_Fire_1 = "effect3d/e_eff_build_fire_1";
        public const string Effect_Fire_2 = "effect3d/e_eff_build_fire_2";
        public const string Effect_Fire_3 = "effect3d/e_eff_build_fire_3";
		public const string build_legion_chenge = "effect3d/e_eff_build_legion_change";
        public const string effect_soldiers_die = "effect3d/e_eff_build_soldiers_die";
        public const string effect_soldier_one_die = "effect3d/e_eff_build_soldier_one_die";
		public const string effect_solider_walk = "unit_prefab/effect/e_dust_soldier_run";
		
		public static string Unit_Hun					= "War/Unit/War_Hun";
		public static string Unit_AtkRadius				= "War/Unit/War_AtkRadius";
		public static string Unit_Shadow				= "War/Unit/War_Shadow";
		public static string Unit_Prefab_UnitPathGroup 	= "War/Unit/War_UnitPathGroup";
		public static string Unit_Prefab_Solider 		= "War/Unit/War_Solider";
		public static string Unit_Build					= "War/Unit/War_Build";
		public static string Unit_Build_Casern 			= "War/Unit/War_Build_Casern";
		public static string Unit_Build_Turret 			= "War/Unit/War_Build_Turret";
		public static string Unit_Build_Spot 			= "War/Unit/War_Build_Spot";
		public static string Unit_Player 				= "War/Unit/War_Player";
		public static string Unit_Hero 					= "War/Unit/War_Hero";
		public static string Unit_Wall 					= "War/Unit/War_Wall";

		
		public const string WarViews_UnitHP 		= "War/View/WarViews_UnitHP";
		public const string WarViews_UnitClock 		= "War/View/WarViews_Clock";
		public const string WarViews_UnitSOS 		= "War/View/WarViews_UnitSOS";
		public const string WarViews_HeroHead 	= "War/View/WarViews_HeroHead";
		public const string WarViews_SkillHeadButton 	= "War/View/WarViews_SkillHeadButton";


		public const string Turret_Fx_Projectile = "effect3d/e_turret_atk_ball";
		public const string Turret_Fx_Explosion = "effect3d/e_turret_atk_explosion";

		// 士兵BUFF
//		public const string e_buffstate_solider_attack_down = "unit_prefab/effect/e_buffstate_solider_attack_down";
//		public const string e_buffstate_solider_attack_up = "unit_prefab/effect/e_buffstate_solider_attack_up";
//		public const string e_buffstate_solider_killhero_down = "unit_prefab/effect/e_buffstate_solider_killhero_down";
//		public const string e_buffstate_solider_killhero_up = "unit_prefab/effect/e_buffstate_solider_killhero_up";
//		public const string e_buffstate_solider_movespeed_down = "unit_prefab/effect/e_buffstate_solider_movespeed_down";
//		public const string e_buffstate_solider_movespeed_up = "unit_prefab/effect/e_buffstate_solider_movespeed_up";

		
		public const string e_buffstate_atk_up 					= "effect3d/e_buffstate_atk_up";
		public const string e_buffstate_movespeed_up 			= "effect3d/e_buffstate_movespeed_up";
		public const string e_buffstate_producespeed_up 		= "effect3d/e_buffstate_producespeed_up";


		
		public const string e_spot_change					= "effect3d/e_spot_change";

		
		public const string e_legionexp_l					= "effect3d/effect3d_cr/e_legionexp_l";
		public const string e_legionexp_m					= "effect3d/effect3d_cr/e_legionexp_m";
		public const string e_legionexp_s					= "effect3d/effect3d_cr/e_legionexp_s";

		public const string e_target_build_own					= "effect3d/effect3d_cr/e_target_build_own";



		public static Dictionary<string, object> prefabs = new Dictionary<string, object>();

		public static void AddPrefab(string name, object go)
		{
			name = name.ToLower();

			if(!prefabs.ContainsKey(name))
			{
				prefabs.Add(name, go);
			}
			else
			{
				prefabs[name] = go;
			}
		}

		public static GameObject GetPrefab(string name)
		{
			name = name.ToLower();
			object go = null;
			if(prefabs.TryGetValue(name, out go))
			{
				return (GameObject) go;
			}

//			Debug.Log(name);
			Coo.assetManager.Load(name, (string prefname, object obj) => {go = obj; AddPrefab(prefname, go); });
			return (GameObject) go;
		}

		public static T GetRes<T>(string name)
		{
           // Debug.Log("===================name: " + name);
			name = name.ToLower();
			object go = null;
			if(prefabs.TryGetValue(name, out go))
			{
				return (T) go;
			}
			
			Debug.Log(string.Format("<color=red>name={0} go={1}</color>", name, go));
			return (T)go;
		}




		/** 预加载资源 */
		public static List<string> preloadList = new List<string>();
        /** 生成预加载资源 */
        public static void GenerationPreloadList()
        {

            preloadList.Clear();
            List<string> list = preloadList;

//			for(int colorId = 0; colorId < 3; colorId ++)
//			{
//	            for (int leveId = 0; leveId < 3; leveId++)
//	            {
//					list.Add("unit_prefab/turret/t_01_jianta_"+ colorId + "_" + leveId);
//				}
//				list.Add("unit_prefab/spot/spot_01_zhangpeng_"+ colorId );
//            }


			int stageId = War.sceneData.id;
			if(!War.model.stagePaths.ContainsKey(stageId))
			{
				list.Add(StagePathData.GetFilePath(stageId));
			}

			
			list.Add(WarRes.e_legionexp_l);
			list.Add(WarRes.e_legionexp_m);
			list.Add(WarRes.e_legionexp_s);

			list.Add(WarRes.e_spot_change);
			list.Add(WarRes.e_target_build_own);

			list.Add(WarRes.e_buffstate_atk_up);
			list.Add(WarRes.e_buffstate_movespeed_up);
			list.Add(WarRes.e_buffstate_producespeed_up);

            list.Add(WarRes.Turret_Fx_Projectile);
			list.Add(WarRes.Turret_Fx_Explosion);
			
			list.Add(WarRes.SendArmy);

			list.Add(WarRes.Unit_Hun);
			list.Add(WarRes.Unit_AtkRadius);
			list.Add(WarRes.Unit_Shadow);
			list.Add(WarRes.Unit_Prefab_UnitPathGroup);
			list.Add(WarRes.Unit_Prefab_Solider);
			list.Add(WarRes.Unit_Build_Casern);
			list.Add(WarRes.Unit_Build_Turret);
			list.Add(WarRes.Unit_Build_Spot);
			list.Add(WarRes.Unit_Player);
			list.Add(WarRes.Unit_Hero);
			list.Add(WarRes.Unit_Wall);
			list.Add(WarRes.WarViews_UnitHP);
			list.Add(WarRes.WarViews_UnitClock);
			list.Add(WarRes.WarViews_UnitSOS);
			list.Add(WarRes.WarViews_HeroHead);
			list.Add(WarRes.WarViews_SkillHeadButton);
			list.Add(WarRes.War_View_SkillOperate_SelectUnit);
			list.Add(WarRes.effect_solider_walk);
            list.Add(WarRes.effect_soldiers_die);
//            list.Add(WarRes.effect_soldier_one_die);
			list.Add(WarRes.Effect_Beattack);
			list.Add(WarRes.build_legion_chenge);

			if(list.IndexOf(WarRes.Effect_Uplevel) == -1) list.Add(WarRes.Effect_Uplevel);




			list.Add(War.sceneData.mapConfig.terrain);
			list.Add(War.sceneData.mapConfig.buildGround);  



			foreach(KeyValuePair<int, UnitData> buildKVP in War.sceneData.buildDict)
			{
				BuildConfig buildConfig = buildKVP.Value.buildConfig;
				buildConfig.GetResList(list, War.sceneData.colorIds);
			}


			
			
			foreach(KeyValuePair<int, UnitData> wallKVP in War.sceneData.wallDict)
			{
				string file = wallKVP.Value.prefabFile;
				if(list.IndexOf(file) == -1)
				{
					list.Add(file);
				}
			}

			foreach(KeyValuePair<int, LegionData> legionKVP in War.sceneData.legionDict)
			{
				string file = legionKVP.Value.soliderData.prefabFile;
				if(list.IndexOf(file) == -1)
				{
					list.Add(file);
				}

				foreach(KeyValuePair<int, SkillOperateData> skillKVP in legionKVP.Value.skillDatas)
				{
					skillKVP.Value.skillConfig.GetRes(list);
				}

			}
			
		}
		
		/** 销毁战斗加载的资源 */
		public static void Destroy()
		{
			prefabs.Clear();

			int count = preloadList.Count;
			for(int i = 0; i < count; i ++)
			{
				Coo.assetManager.Unload(preloadList[i], true);
			}

			preloadList.Clear();
		}



	}
}
