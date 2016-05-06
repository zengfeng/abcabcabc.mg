using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public class StateBuffLevel_ProduceSpeed : AbstateStateBuffLevel
	{
		public ParticleSystem particleSystem;
		public float[] levels = new float[]{1, 2, 3};
		public Color[] colors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta};

		public override void SetLevel (int level, int colorId)
		{
			int index = level - 1;
			particleSystem.startSize = levels[index];

			particleSystem.startColor = colors[colorId];
		}
	}
}