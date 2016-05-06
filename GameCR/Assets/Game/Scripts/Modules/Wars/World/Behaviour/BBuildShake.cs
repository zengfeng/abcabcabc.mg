using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class BBuildShake : MonoBehaviour {
		public enum ProgressState
		{
			/** 放大 */
			Enlarge,
			/** 放大 */
			Shrink,
			/** 等待 */
			Wait,

		}

		public Transform target;
		public bool playing = false;
		public Vector3 beginScale = Vector3.one;
		public Vector3 endScale = new Vector3(1F, 1.6F, 1F);
		public float delay = 0.1f;
		public float time = 0.2f;
		public float waitTime = 0.1f;
		public float shakeTime = 0.5f;
		private float _shakeTime = 0f;
		private float _time = 0f;
		private float _t = 0;
		private Vector3 _scale;

		private ProgressState progressState;
		private Coroutine _coroutiner;

		void Start () {
		
		}

		void Update () {
			if(_shakeTime > 0)
			{
				_shakeTime -= Time.deltaTime;
			}
		}

		public void Play()
		{
			if(enabled == false) return;

			_shakeTime = shakeTime;
			if(playing == false)
			{
				playing = true;
				_coroutiner = StartCoroutine(OnPlay());
			}
		}

		public void Stop()
		{
			_shakeTime = 0;
			playing = false;
			if(_coroutiner != null)
			{
				StopCoroutine(_coroutiner);
			}

			target.transform.localScale = Vector3.one;
			target.transform.localPosition = Vector3.zero;
		}

		IEnumerator OnPlay()
		{
			yield return new WaitForSeconds(delay);
			_time = 0;
			while(playing)
			{
				_time += Time.deltaTime;
				_t = _time / time;
				if(progressState == ProgressState.Enlarge)
				{
					_scale = Vector3.Lerp(beginScale, endScale, _t);
				}
				else if(progressState == ProgressState.Shrink)
				{
					_scale = Vector3.Lerp(endScale, beginScale, _t);
				}

				target.transform.localScale = _scale;
				target.transform.localPosition = target.transform.localPosition.SetY((_scale.y - 1) * 2);

				if(_time >= time)
				{
					_time = 0;
					if(progressState == ProgressState.Enlarge)
					{
						progressState = ProgressState.Shrink;
					}
					else if(progressState == ProgressState.Shrink)
					{
						progressState = ProgressState.Wait;
						yield return new WaitForSeconds(waitTime);
						playing = _shakeTime > 0;
					}
					else
					{
						progressState = ProgressState.Enlarge;
					}
				}
				yield return new WaitForEndOfFrame();
			}


		}
	}

}