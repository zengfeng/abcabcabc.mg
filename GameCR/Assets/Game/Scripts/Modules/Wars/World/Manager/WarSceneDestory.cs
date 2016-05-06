using UnityEngine;
using System.Collections;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class WarSceneDestory : MonoBehaviour
	{
		public void DestoryScene()
		{

			//TODO NEW SKILL
//			War.scene.rootSkillBar.DestorySkillButton();
//			War.scene.rootSkillHeadBar.DestorySkillButton();

			DestoryUnitSOS();
			DestoryUnitHP();
			DestoryUnitClock();
			StopSendArm();
			DestorySolider();
			DestoryHero();
			DestoryPlayer();
			DestoryBuild();
			DestoryWall();
			DestoryMap();

			
			War.scene.Clear();
			War.winManager.OnRest();
			War.starManager.OnRest();
			War.starPVPManager.OnRest();

		}

		
		public void DestoryUnitSOS()
		{
			int index = War.scene.rootUnitSOS.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootUnitSOS.GetChild(index).gameObject);
			}
		}

		public void DestoryUnitHP()
		{
			int index = War.scene.rootUnitHP.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootUnitHP.GetChild(index).gameObject);
			}
		}

		
		
		public void DestoryUnitClock()
		{
			int index = War.scene.rootUnitClock.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootUnitClock.GetChild(index).gameObject);
			}
		}

		public void StopSendArm()
		{
			foreach(UnitCtl unitCtl in War.scene.buildList)
			{
				unitCtl.GetComponent<BSendArming>().Stop();
			}
		}

		public void DestorySolider()
		{
			int index = War.scene.rootSoliders.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootSoliders.GetChild(index).gameObject);
			}
		}

		public void DestoryHero()
		{
			int index = War.scene.rootHeros.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootHeros.GetChild(index).gameObject);
			}
		}
		
		
		public void DestoryPlayer()
		{
			int index = War.scene.rootPlayers.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootPlayers.GetChild(index).gameObject);
			}
		}

		
		
		public void DestoryBuild()
		{
			int index = War.scene.rootCaserns.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootCaserns.GetChild(index).gameObject);
			}
		}

		
		
		public void DestoryWall()
		{
			int index = War.scene.rootWalls.childCount;
			while(-- index  >= 0)
			{
				Destroy(War.scene.rootWalls.GetChild(index).gameObject);
			}
		}

		public void DestoryMap()
		{
			War.map.Clear();
		}





	}
}
