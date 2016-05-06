using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using Games.Module.Props;
using CC.Runtime;

namespace Games.Module.Wars
{
	[ConfigPath("Config/build_turret",ConfigType.CSV)]
	public class BuildTurretConfig : AbstractBuildConfig
	{
		
		/** 攻击范围 */
		public float 	attackRadius;
		/** 攻击速度 */
		public float 	attackSpeed;
		/** 攻击伤害 */
		public float 	attackDamage;
		
		/** 属性列表 */
		public Prop[] props;
		
		public AttachPropData attachPropData;
	
		
		public BuildTurretConfig()
		{
			buildType = BuildType.Turret;
			buildModuleType = BuildModuleType.Turret;
		}
		
		
		
		override public void ParseCsv(string[] csv)
		{
			//			编号	名称	炮弹Avatar	攻击范围	攻击速度	攻击伤害
			//			id	name	turretAvatar	attackRadius	attackSpeed	attackDamage
			int i = 0;
			// 箭塔编号
			id =  csv.GetInt32(i ++ );
			// 名称
			name = csv.GetString(i ++);
			// 箭塔素材
			avatarId =  csv.GetInt32(i ++ );
			// 攻击范围
			attackRadius =  csv.GetSingle(i ++ );
			// 攻击速度
			attackSpeed =  csv.GetSingle(i ++ );
			// 攻击伤害
			attackDamage =  csv.GetSingle(i ++ );
			// 属性列表
			props =  new Prop[]{Prop.CreateInstance(PropId.AttackRadiusAdd, attackRadius),
				Prop.CreateInstance(PropId.AttackSpeedAdd, attackSpeed),
				Prop.CreateInstance(PropId.AttackDamageAdd, attackDamage)
			};
			
			attachPropData = new AttachPropData(props);

			War.model.AddBuildTurretConfig(this);
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
		
		public override string ToString ()
		{
			return string.Format ("[BuildTurretConfig: id={0},  avatarId={1},  attackRadius={2}, attackSpeed={3}, attackDamage={4}]",
			                      id, avatarId, attackRadius, attackSpeed, attackDamage);
		}
	}

}