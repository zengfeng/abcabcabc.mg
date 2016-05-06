using UnityEngine;
using System.Collections;
using System;


namespace Games 
{
	public class Setting 
	{
		public static Action sOnChange;
		public static void Change()
		{
			if(sOnChange != null)
			{
				sOnChange();
			}
		}

		public static Action sSendArmChange;



		/** 发兵数量比例 */
		public static float SendArm
		{
			get
			{
				if(PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_SendArm))
				{
					return PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_SendArm);
				}
				return 100;
			}

			set
			{
				PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_SendArm, (int)value);
				if(sSendArmChange != null)
				{
					sSendArmChange();
				}
			}
		}

        //public const string Setting_MusicSwitch = "Setting_MusicSwitch";
        //public const string Setting_SoundEffectSwitch = "Setting_SoundEffectSwitch";

		
		/** 音乐开关 */
		public static bool TotalHP
		{
			get
			{
				if (PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_TotalHP))
				{
					return PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_TotalHP) == 1;
				}
				return true;
			}
			set
			{
				PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_TotalHP, value ? 1 : 0);
			}
		}

        /** 音乐开关 */
        public static bool MusicSwitch
        {
            get
            {
                if (PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_MusicSwitch))
                {
                    return PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_MusicSwitch) == 1;
                }
                return true;
            }
            set
            {
				PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_MusicSwitch, value ? 1 : 0);
            }
        }
        /** 音乐开关 */
        public static bool SoundEffectSwitch
        {
            get
            {
                if (PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_SoundEffectSwitch))
                {
                    return PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_SoundEffectSwitch) == 1;
                }
                return true;
            }
            set
            {
				PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_SoundEffectSwitch, value ? 1 : 0);
            }
        }
        /** 音量 */
        public static float Volume
        {
            get
            {
                if (PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_Volume))
                {
                    return PlayerPrefsUtil.GetFloat(PlayerPrefsKey.Setting_Volume);
                }
                return 1;
            }
            set
            {
                PlayerPrefsUtil.SetFloat(PlayerPrefsKey.Setting_Volume, value);
            }
        }


		/** 技能吸附 */
		public static bool SkillSnapSwitch
		{
			get
			{
				if (PlayerPrefsUtil.HasKey(PlayerPrefsKey.Setting_SkillSnap))
				{
					return PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_SkillSnap) == 1;
				}
				return true;
			}
			set
			{
				PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_SkillSnap, value ? 1 : 0);
			}
		}

	}
}