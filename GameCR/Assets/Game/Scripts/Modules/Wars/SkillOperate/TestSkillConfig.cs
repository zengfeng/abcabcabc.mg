using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public class TestSkillConfig 
	{
		public int heroId;

		public int skillId			= 0;
		public int skillLevel 		= 0;

		
		public int skillId2 		= 0;
		public int skillLevel2 		= 0;

		public bool 	isSettledBuild 		= false;
		public string 	icon 				= "Image/SkillIcon/skill_50010";


		
		public SkillOperateType 	operate; 
		public int 					unitType; 
		public int 					relation; 

	}
}
