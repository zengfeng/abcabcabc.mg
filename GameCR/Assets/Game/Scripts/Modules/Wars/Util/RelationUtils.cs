using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public static class RelationUtils
	{

        public static void Test()
        {
            int relation = 0;
            relation = relation.ROwn(true).RFriendly(true).REnemy(true).RFriendly(false);
        }

		public static bool RValue(this int relation, RelationType relationType)
		{
			return (relation & (1 << ((int)relationType))) != 0;
		}


		/*----------Own--------------*/
		public static bool ROwn(this int relation)
		{
			return (relation & (1 << ((int)RelationType.Own))) != 0;
		}
		
		
		public static int ROwn(this int relation, bool value)
		{
			if(value)
			{
				relation |= (1 << ((int)RelationType.Own));
			}
			else if(ROwn(relation))
			{
				relation ^= (1 << ((int)RelationType.Own));
			}
			return relation;
		}
		
		
		/*----------Friendly--------------*/
		public static bool RFriendly(this int relation)
		{
			return (relation & (1 << ((int)RelationType.Friendly))) != 0;
		}
		
		
		public static int RFriendly(this int relation, bool value)
		{
			if(value)
			{
				relation |= (1 << ((int)RelationType.Friendly));
			}
			else if(RFriendly(relation))
			{
				relation ^= (1 << ((int)RelationType.Friendly));
			}
			return relation;
		}
		
		
		
		/*----------Enemy--------------*/
		public static bool REnemy(this int relation)
		{
			return (relation & (1 << ((int)RelationType.Enemy))) != 0;
		}
		
		
		public static int REnemy(this int relation, bool value)
		{
			if(value)
			{
				relation |= (1 << ((int)RelationType.Enemy));
			}
			else if(REnemy(relation))
			{
				relation ^= (1 << ((int)RelationType.Enemy));
			}
			return relation;
		}
		
		
		
		/*----------All--------------*/
		public static bool RAll(this int relation)
		{
			for(int i = 1; i <= 3; i ++ )
			{
				int value = relation & (1 << i);
				if(value == 0) return false;
			}
			return true;
		}
		
		
		public static int RAll(this int relation, bool value)
		{
			if(value)
			{
				relation = 0;
				for(int i = 1; i <= 3; i ++ )
				{
					relation |= 1 << i;
				}
			}
			else
			{
				relation = 0;
			}
			
			return relation;
		}
		
	}
}