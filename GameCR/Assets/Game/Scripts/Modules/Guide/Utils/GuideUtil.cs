using UnityEngine;
using System.Collections;



namespace Games.Guides
{
	public static class GuideUtil
	{

		//			EnumUtil.GetValuesAndNames<GuideStepType>(out option_ids, out option_names);

		private static int[] 		_GuideStepType_ids 	= new int[]{};
		private static string[] 	_GuideStepType_names = new string[]{};

		public static int[] GuideStepType_ids
		{
			get 
			{
				if (_GuideStepType_ids.Length == 0) 
				{
					EnumUtil.GetValuesAndNames<GuideStepType>(out _GuideStepType_ids, out _GuideStepType_names);
				}

				return _GuideStepType_ids;
			}
		}

		public static string[] GuideStepType_names
		{
			get 
			{
				if (_GuideStepType_names.Length == 0) 
				{
					EnumUtil.GetValuesAndNames<GuideStepType>(out _GuideStepType_ids, out _GuideStepType_names);
				}

				return _GuideStepType_names;
			}
		}


		public static int GetId(GuideStepType type)
		{
			return (int)type;
		}

		public static string GetName(GuideStepType type)
		{
			return EnumUtil.GetName<GuideStepType> (type);
		}



		public static int GetId(GuideStepCompleteType type)
		{
			return (int)type;
		}

		public static string GetName(GuideStepCompleteType type)
		{
			return EnumUtil.GetName<GuideStepCompleteType> (type);
		}
		
	}
}