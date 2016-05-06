

namespace Games.Module.Wars
{
	/** 战斗环境配置 */
	public class WarConfig
	{
		/** PC机是否开启PC操作模式 */
		public bool PCOperater = false;
		/** 是否开启兵营升级 */
		public bool CasernEnableUplevel = true;
		/** 技能抛物线重力常数 */
		public float ProjectileGravity = 40;
		/** 自己阵营颜色 */
		public int ownDefaultColor = 1;

		/** 主公技能ID */
		public int roleSkillId = 999;
		
		/** 星级评价是否显示消息 */
		public bool isShowStarMsg = false;

		/** 建筑升第3级--最低需要士兵数量 */
		public float buildUplevel_RequireMinHp = 2;
		/** 建筑升第3级--最高低需要士兵数量 */
		public float buildUplevel_RequireMaxHp = 17;
		/** 建筑升第3级--最高消耗时间 */
		public float buildUplevel_RequireMaxTime = 15;
		/** 建筑升第3级--士兵转时间比例 */
		public float buildUplevel_Hp2Time = 1;

		/** 技能改变建筑时间 */
		public float skillChangeBuildTime = 15;

		/** 使用技能是否强制吸附 */
		public bool skillSnap = true;


		bool isInit;
		public void Init()
		{
			if(isInit) return;
			isInit = true;
			buildUplevel_RequireMinHp 		= ConstConfig.GetFloat(ConstConfig.ID.War_BuildUplevel_RequireMinHp);
			buildUplevel_RequireMaxHp 		= ConstConfig.GetFloat(ConstConfig.ID.War_BuildUplevel_RequireMaxHp);
			buildUplevel_RequireMaxTime 	= ConstConfig.GetFloat(ConstConfig.ID.War_BuildUplevel_RequireMaxTime);
			buildUplevel_Hp2Time 			= ConstConfig.GetFloat(ConstConfig.ID.War_BuildUplevel_Hp2Time);

			
			skillChangeBuildTime 			= ConstConfig.GetFloat(ConstConfig.ID.War_SkillChangeBuildTime);

			skillSnap = Setting.SkillSnapSwitch;
		}

	}
}
