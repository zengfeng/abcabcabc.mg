using UnityEngine;
using System.Collections;
namespace Games.Module.Wars
{
	public class SpotChangeEffect : MonoBehaviour
	{
		public ParticleSystem particle;
		public Color[] colors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta};
		public void SetColorId(int colorId)
		{
			particle.startColor = colors[colorId];
		}
	}
}
