using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

namespace CC.UI
{
	[AddComponentMenu("CC/UI/SpriteGlow", 41)]
	public class SpriteGlow : MonoBehaviour 
	{
		public float min = 0F;
		public float max = 1F;
		public float time = 0.5F;
		public SpriteRenderer img;

		void Awake()
		{
			if(img == null) img = GetComponent<SpriteRenderer>();
		}


		public float _time = 0;
		public int _mask = 1;
		void Update () 
		{
			if(_time >= time )
			{
				_mask = -1;
				_time = time;
			}
			else if(_time <= 0)
			{
				_mask = 1;
				_time = 0;
			}
			_time += Time.deltaTime * _mask;
			float a = min + (_time / time) * (max - min);
			Color color = img.color.Clone();
			color.a = a;
			img.color = color;
		}
	}
}