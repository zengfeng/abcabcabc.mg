using UnityEngine;
using System.Collections;
using Games.Module.Props;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Cores;
using Games.Module.Wars;
using Games.Module.Avatars;

namespace Games.Module.Wars
{
	[ConfigPath("Config/monster",ConfigType.CSV)]
	public class MonsterConfig : IParseCsv, IKey<int>
	{
		/** 编号 */
		public int id;
		/** 名称 */
		public string name;
		/** AvatarID */
		public int avatarId;
		/** 建筑类型 */
		public BuildType buildType;
		/** 技能ID */
		public int skillId;
		/** 技能等级 */
		public int skillLevel;

		
		/** 技能ID */
		public int skillId2;
		/** 技能等级 */
		public int skillLevel2;


		/** 属性列表 */
		public Prop[] props;

		
		
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

		public float battlePoint
		{
			get
			{
				return props.FindProp((int)(PropId.BattleForceAdd)).value;
			}
		}

		public float GetPropValue(int id)
		{
			return props.FindProp(id).value;
		}
		
		public void ParseCsv(string[] csv)
		{
			int i = 0;
			id = csv.GetInt32(i ++);
			name = csv.GetString(i ++);
			avatarId = csv.GetInt32(i++);
			if(id < 100)
			{
				buildType = (BuildType) csv.GetInt32(i);
			}
			i++;
			skillId = csv.GetInt32(i++);
			skillLevel = csv.GetInt32(i++);

			
			skillId2 = csv.GetInt32(i++);
			skillLevel2 = csv.GetInt32(i++);

			int begin = i ;
			props = PropConfigUtils.ParsePropFields(csv, begin);


			War.model.AddMonsterConfig(this);
		}

		public override string ToString ()
		{
			return string.Format ("[MonsterConfig: Key={0}, id={1}, name={2}, avatarId={3}, buildType={4}, skillId={5}, skillLevel={6}, skillId2={7}, skillLevel={8} props={9}]", Key,id, name, avatarId, buildType, skillId, skillLevel, skillId2, skillLevel2,  props.ToStr());
		}
	}
}
