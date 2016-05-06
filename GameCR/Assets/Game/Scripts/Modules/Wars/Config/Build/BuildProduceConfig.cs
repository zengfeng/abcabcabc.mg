using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Module.Props;

namespace Games.Module.Wars
{
	[ConfigPath("Config/build_produce",ConfigType.CSV)]
	public class BuildProduceConfig : AbstractBuildConfig
	{
		/** 属性列表 */
		public Prop[] props;

		public AttachPropData attachPropData;

		
		public BuildProduceConfig()
		{
			buildModuleType = BuildModuleType.Produce;
		}


		public override void ParseCsv (string[] csv)
		{
//			编号	名称	属性2-产兵速度
//			id	name	ProduceSpeedAdd
			int i = 0;

			// 编号
			id =  csv.GetInt32(i ++ );
			// 名称
			name = csv.GetString(i ++);
			// 属性
			props = PropConfigUtils.ParsePropFields(csv, i);


			attachPropData = new AttachPropData(props);

			War.model.AddBuildProduceConfig(this);
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