using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public abstract class UpdateHandle
	{
		public WarScene scene;
		public UpdateHandle()
		{
		}
		
		public UpdateHandle(WarScene scene)
		{
			this.scene = scene;
		}
		
		public Dictionary<int, List<UnitCtl>> buildLegionDict
		{
			get
			{
				return scene.buildLegionDict;
			}
		}
		
		
		
		public List<UnitCtl> buildList
		{
			get
			{
				return scene.buildList;
			}
		}
		
		public List<UnitCtl> soliderList
		{
			get
			{
				return scene.soliderList;
			}
		}
		
		public int legionCount
		{
			get
			{
				return scene.legionCount;
			}
			
			set
			{
				scene.legionCount = value;
			}
		}
		
		
		
		public void AddBuild(UnitCtl unit)
		{
			scene.AddBuild(unit);
		}
		
		public List<UnitCtl> GetBuilds(int legionId)
		{
			return scene.GetBuilds(legionId);
		}
		
		
		public List<UnitCtl> GetEnemyBuilds(int legionId)
		{
			return scene.GetEnemyBuilds(legionId);
		}
		
		
		public float friendHPRate
		{
			get
			{
				return scene.friendHPRate;
			}
			
			set
			{
				scene.friendHPRate = value;
			}
		}
		
		
		
		public float friendHP
		{
			get
			{
				return scene.friendHP;
			}
			
			set
			{
				scene.friendHP = value;
			}
		}
		
		
		public float totalHP
		{
			get
			{
				return scene.totalHP;
			}
			
			set
			{
				scene.totalHP = value;
			}
		}
		
		public int friendBuildCount
		{
			get
			{
				return scene.friendBuildCount;
			}
			
			set
			{
				scene.friendBuildCount = value;
			}
		}
		
		public int totalBuildCount
		{
			get
			{
				return scene.totalBuildCount;
			}
			
			set
			{
				scene.totalBuildCount = value;
			}
		}
		
		
		public Dictionary<int, float> legionHP
		{
			get
			{
				return scene.legionHP;
			}
			
			set
			{
				scene.legionHP = value;
			}
		}
		
		
	}

}
