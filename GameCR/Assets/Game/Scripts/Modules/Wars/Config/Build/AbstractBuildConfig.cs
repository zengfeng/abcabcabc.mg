using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Avatars;
using Games.Cores;


namespace Games.Module.Wars
{
	public class AbstractBuildConfig : IParseCsv, IKey<int>
	{
		
		/** id */
		public int 		id;
		/** 名称 */
		public string 	name = "";
		/** 素材 */
		public int 		avatarId;

		public BuildType buildType;
		public BuildModuleType buildModuleType;
		
		public int Key
		{
			get
			{
				return id;
			}
		}

		public AvatarConfig avatarConfig
		{
			get
			{
				return Goo.avatar.GetConfig(avatarId);
			}
		}

		
		virtual public void ParseCsv(string[] csv)
		{
		}


		/** 应用 */
		virtual public void App(int uid, UnitData unitData, bool calculate = false)
		{
			App(unitData, calculate);
		}

		virtual public void App(UnitData unitData, bool calculate = false)
		{
		}


		
		/** 移除 */
		virtual public void Revoke(int uid, UnitData unitData, bool calculate = false)
		{
			Revoke(unitData, calculate);
		}

		virtual public void Revoke(UnitData unitData, bool calculate = false)
		{
			
		}



	}
}
