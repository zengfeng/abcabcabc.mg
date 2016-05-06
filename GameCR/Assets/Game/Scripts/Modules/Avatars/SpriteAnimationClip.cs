using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{

	public class SpriteAnimationClip : ScriptableObject
	{
		public string actionName;
		public float angle;
		public bool flip;
		public bool loop;
		public Sprite[] frames;
		
		public void Dispose()
		{
			foreach(Sprite frame in frames)
			{
				DestroyImmediate(frame, true);
			}
		}
	}


}