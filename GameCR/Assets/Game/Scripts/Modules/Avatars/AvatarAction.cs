using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{

	public class AvatarAction : ScriptableObject
	{
		public string action;
		public float frameTime = 0.08333F;
		public float deltaAngle = 90F;
		public float offsetAngle = 0F;
		public SpriteAnimationClip[] clips;

		public SpriteAnimationClip GetSpriteAnimationClip(float angle)
		{
			angle += offsetAngle;
			angle %= 360f;
			if(angle < 0) angle += 360f;

			int index = deltaAngle == 0 ? 0 : Mathf.RoundToInt(angle / deltaAngle);
			if(index >= clips.Length)
				index = 0;

			return clips[index];
		}

		public void Dispose()
		{
			foreach(SpriteAnimationClip clip in clips)
			{
				clip.Dispose();
			}
		}

	}
}