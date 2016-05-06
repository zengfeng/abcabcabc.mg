using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class WarCamera : MonoBehaviour
	{
		public float overScale = 1.1f;
		public float initScale = 22f;
		public float scale = 22f;
		public float smooth = 10;
		public float time = 1f;
		public Camera camera;
		public AutoOrthographicSize autoOrthographicSize;

		void Start()
		{
			if (camera == null)
				camera = Camera.main;

			if (autoOrthographicSize == null)
				autoOrthographicSize = camera.GetComponent<AutoOrthographicSize> ();


			initScale = autoOrthographicSize.scale;
			scale = initScale * overScale;

			War.camera = this;
		}


		[ContextMenu("PlayGameOver")]
		public void PlayGameOver()
		{
//			StartCoroutine (OnPlayGameOver());

			autoOrthographicSize.scale = initScale;
			Tween tween = DOTween.To (()=>autoOrthographicSize.scale, x=>autoOrthographicSize.scale = x, scale, time).SetEase(Ease.InOutQuad);
		}

		IEnumerator OnPlayGameOver()
		{
			bool playing = true;
			while(playing)
			{
				autoOrthographicSize.scale = Mathf.Lerp (autoOrthographicSize.scale, scale, Time.deltaTime * smooth);
				yield return new WaitForEndOfFrame ();

				if (Mathf.Abs (autoOrthographicSize.scale - scale) < 0.01f) 
				{
					playing = false;
					break;
				}
			}


		}
	}

}