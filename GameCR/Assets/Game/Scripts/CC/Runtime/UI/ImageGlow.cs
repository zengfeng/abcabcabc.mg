using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

namespace CC.UI
{
	[AddComponentMenu("CC/UI/ImageGlow", 40)]
	public class ImageGlow : MonoBehaviour 
	{
		public float min = 0F;
		public float max = 1F;
		public float time = 0.5F;
		public Image img;

		void Awake()
		{
			if(img == null) img = GetComponent<Image>();
		}

		void OnEnable()
		{
			_time = 0;
			Color color = img.color.Clone();
			color.a = 0;
			img.color = color;
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