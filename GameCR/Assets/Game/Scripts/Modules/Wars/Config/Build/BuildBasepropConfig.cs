using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Module.Props;

namespace Games.Module.Wars
{
	[ConfigPath("Config/build_baseprop",ConfigType.CSV)]
	public class BuildBasepropConfig : AbstractBuildConfig
	{
		/** 属性列表 */
		public Prop[] props;

		public AttachPropData attachPropData;

		public override void ParseCsv (string[] csv)
		{
//			编号	名称	属性1-兵力上限	属性3--防御	属性4--伤害
//			id	name	MaxHpAdd	DefendAdd	AttackDamageAdd

			int i = 0;

			// 编号
			id =  csv.GetInt32(i ++ );
			// 名称
			name = csv.GetString(i ++);
			// 属性
			props = PropConfigUtils.ParsePropFields(csv, i);


			attachPropData = new AttachPropData(props);

			War.model.AddBuildBasepropConfig(this);
		}


		/** 应用 */
		public override void App (UnitData unitData, bool calculate = false)
		{
			base.App (unitData, calculate);
			
			unitData.AppProps(attachPropData, calculate);
		}

		/** 移除 */
		public override void Revoke (UnitData unitData, bool calculate = false)
		{
			base.Revoke (unitData, calculate);
			unitData.RevokeProps(attachPropData, calculate);
		}

	}

}