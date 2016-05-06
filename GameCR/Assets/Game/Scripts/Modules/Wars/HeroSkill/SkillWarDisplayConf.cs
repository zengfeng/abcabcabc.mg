using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{

	[ConfigPath("Config/skills_display",ConfigType.CSV)]
	public class SkillWarDisplayConf : IParseCsv, IKey<int>
	{
		public int 				skillId;
		public string			skillName;
		public string			skillDescription;
		public string			skillDisplay;
		public int 				avatarId;


		public int Key
		{
			get
			{
				return skillId;
			}
		}

		public void ParseCsv(string[] csv)
		{

//			技能ID	技能名称	技能描述	技能升级描述	素材编号	备注1	备注2	备注3
//			skillId	skillName	skillDescription	skillDisplay	avatarId	Ps1	heroId	heroName

			int i = 0;
			skillId = csv.GetInt32 (i++);
			skillName = csv.GetString (i++);
			skillDescription = csv.GetString (i++);
			skillDisplay = csv.GetString (i++);
			avatarId = csv.GetInt32 (i++);

			War.model.AddSkillWarDisplayConf (this);

		}
	}

}
