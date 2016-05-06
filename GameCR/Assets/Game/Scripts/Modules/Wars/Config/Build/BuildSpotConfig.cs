using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using Games.Module.Props;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	[ConfigPath("Config/build_spot",ConfigType.CSV)]
	public class BuildSpotConfig : AbstractBuildConfig
	{
		/** 据点类型 */
		public SpotType spotType;

		/** 应用单位类型 */
		public UnitType unitType;
		/** 属性列表 */
		public Prop[] props;


		
		public BuildSpotConfig()
		{
			buildType = BuildType.Spot;
			buildModuleType = BuildModuleType.Spot;
		}
		
		override public void ParseCsv(string[] csv)
		{
//			编号	名称	据点素材	单位类型	增加属性1	增加属性2	增加属性3
//			id	name	spotAvatar	unitType	property1	property2	property3

			int i = 0;
			// 编号
			id =  csv.GetInt32(i ++ );
			// 名称
			name =  csv.GetString(i ++ );
			// 据点类型
			spotType = (SpotType) csv.GetInt32(i ++ );
			// 素材
			avatarId =  csv.GetInt32(i ++ );
			// 单位类型
			unitType =  (UnitType)csv.GetInt32(i ++ );
			// 属性
			props = PropConfigUtils.ParsePropFields(csv, i);



			War.model.AddBuildSpotConfig(this);
		}


		private Dictionary<int, AttachPropData> attachPropDataDict = new Dictionary<int, AttachPropData>();
		public AttachPropData GetAttachPropData(int uid)
		{
			if(attachPropDataDict.ContainsKey(uid))
			{
				return attachPropDataDict[uid];
			}
			
			AttachPropData attachPropData = new AttachPropData(uid, props);
			attachPropDataDict.Add(uid, attachPropData);
			return attachPropData;

		}
		
		/** 应用 */
		public override void App (int uid, UnitData unitData, bool calculate = false)
		{

			LegionData legionData = unitData.legionData;
			AttachPropData attachPropData = GetAttachPropData(uid);
			switch(unitType)
			{
			case UnitType.Player:
				legionData.legionPropContainer.Add(attachPropData);
				legionData.buildPropContainer.Add(attachPropData);
				legionData.soliderPropContainer.Add(attachPropData);
				break;
			case UnitType.Build:
				legionData.buildPropContainer.Add(attachPropData);
				break;
			case UnitType.Solider:
				legionData.soliderPropContainer.Add(attachPropData);
				break;
			case UnitType.Hero:
				legionData.heroPropContainer.Add(attachPropData);
				break;
			}
		}
		
		/** 移除 */
		public override void Revoke (int uid, UnitData unitData, bool calculate = false)
		{
			
			LegionData legionData = unitData.legionData;
			AttachPropData attachPropData = GetAttachPropData(uid);

			switch(unitType)
			{
			case UnitType.Player:
				legionData.legionPropContainer.Remove(attachPropData);
				legionData.buildPropContainer.Remove(attachPropData);
				legionData.soliderPropContainer.Remove(attachPropData);
				break;
			case UnitType.Build:
				legionData.buildPropContainer.Remove(attachPropData);
				break;
			case UnitType.Solider:
				legionData.soliderPropContainer.Remove(attachPropData);
				break;
			case UnitType.Hero:
				legionData.heroPropContainer.Remove(attachPropData);
				break;
			}
		}
		
		public override string ToString ()
		{
			return string.Format ("[BuildSpotConfig: id={0}, name={1}  avatarId={2}, props={3}]",
			                      id, name, avatarId, props.ToStr().Replace("{", "{{").Replace("}", "}}"));
		}

	}

}