using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{
	public class AvatarData : ScriptableObject
	{
		public AvatarAction[] avatarActions;

		public AvatarAction GetAvatarAction(string action)
		{
			foreach(AvatarAction avatarAction in avatarActions)
			{
				if(avatarAction.action == action)
				{
					return avatarAction;
				}
			}
			return null;
		}

		public void Dispose()
		{
			foreach(AvatarAction action in avatarActions)
			{
				action.Dispose();
			}
		}
	}

}