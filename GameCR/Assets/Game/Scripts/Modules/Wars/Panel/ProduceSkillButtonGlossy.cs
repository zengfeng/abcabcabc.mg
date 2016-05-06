using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class ProduceSkillButtonGlossy : MonoBehaviour
	{
		public RawImage rawImage;
		public float delayTime = 0;
		public float time = 0.5f;
		public Vector2 uvFrom;
		public Vector2 uvTo;

		private float 	_time;
		private Rect 	_rect;

		void OnEnable()
		{
			Play();
		}

		public void Play()
		{
			_time = 0;
			_rect = rawImage.uvRect;

			StartCoroutine(OnPlay());
		}

		IEnumerator OnPlay()
		{
			_rect.position = uvFrom;
			rawImage.uvRect = _rect;

			if(delayTime > 0 )
			{
				yield return new WaitForSeconds(delayTime);
			}

			while(_time < time)
			{
				_time += Time.deltaTime;
				float rate = _time / time;
				_rect.position = Vector2.Lerp(uvFrom, uvTo, rate);
				rawImage.uvRect = _rect;

				yield return new WaitForEndOfFrame();
			}

			
			_rect.position = uvTo;
			rawImage.uvRect = _rect;
			yield return new WaitForEndOfFrame();

			gameObject.SetActive(false);
		}
	}
}