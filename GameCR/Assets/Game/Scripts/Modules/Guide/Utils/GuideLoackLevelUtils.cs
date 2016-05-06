using UnityEngine;
using System.Collections;



namespace Games.Guides
{
	public static class GuideLoackLevelUtils
	{

		public static bool GLLValue(this int level, GuideLoackLevel type)
		{
			return (level & (1 << ((int)type))) != 0;
		}


		/*----------Time--------------*/
		public static bool GLLTime(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.Time))) != 0;
		}


		public static int GLLTime(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.Time));
			}
			else if(GLLTime(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.Time));
			}
			return level;
		}

		/*----------Produce--------------*/
		public static bool GLLProduce(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.Produce))) != 0;
		}


		public static int GLLProduce(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.Produce));
			}
			else if(GLLProduce(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.Produce));
			}
			return level;
		}

		/*----------Produce Skill--------------*/
		public static bool GLLProduceSkill(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.ProduceSkill))) != 0;
		}


		public static int GLLProduceSkill(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.ProduceSkill));
			}
			else if(GLLProduce(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.ProduceSkill));
			}
			return level;
		}


		/*----------AI--------------*/
		public static bool GLLAi(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.AI))) != 0;
		}
		
		
		public static int GLLAi(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.AI));
			}
			else if(GLLAi(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.AI));
			}
			return level;
		}


		/*----------Hanld--------------*/
		public static bool GLLHanld(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.Hanld))) != 0;
		}


		public static int GLLHanld(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.Hanld));
			}
			else if(GLLHanld(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.Hanld));
			}
			return level;
		}



		/*----------AI_Skill--------------*/
		public static bool GLLAiSkill(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.AI_Skill))) != 0;
		}


		public static int GLLAiSkill(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.AI_Skill));
			}
			else if(GLLAiSkill(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.AI_Skill));
			}
			return level;
		}


		/*----------AI_Uplevel--------------*/
		public static bool GLLAiUplevel(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.AI_Uplevel))) != 0;
		}


		public static int GLLAiUplevel(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.AI_Uplevel));
			}
			else if(GLLAiUplevel(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.AI_Uplevel));
			}
			return level;
		}


		/*----------AI_SendArm--------------*/
		public static bool GLLAiSendArm(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.AI_SendArm))) != 0;
		}


		public static int GLLAiSendArm(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.AI_SendArm));
			}
			else if(GLLAiSendArm(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.AI_SendArm));
			}
			return level;
		}


		/*----------All--------------*/
		public static bool GLLAll(this int level)
		{
			return (level & (1 << ((int)GuideLoackLevel.All))) != 0;
		}


		public static int GLLAll(this int level, bool value)
		{
			if(value)
			{
				level |= (1 << ((int)GuideLoackLevel.All));
			}
			else if(GLLAll(level))
			{
				level ^= (1 << ((int)GuideLoackLevel.All));
			}
			return level;
		}
		
		

		
	}
}