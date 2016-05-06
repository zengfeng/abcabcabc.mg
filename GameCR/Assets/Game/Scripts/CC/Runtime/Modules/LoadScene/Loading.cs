using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CC.Module.LoadScenes
{
	public class Loading : MonoBehaviour, ILoading 
	{
		public Slider slider;
		public Text text;

		protected AsyncOperation async;
		protected float progress = 0F;

		virtual protected void Start()
		{
			StartCoroutine(LoadScene());
		}

		IEnumerator LoadScene()
		{
			async = Application.LoadLevelAsync(LoadSceneManager.sceneName);
			async.allowSceneActivation = false;

			yield return async;
		}

		virtual protected void Update()
		{
			if(async.progress < 0.9F)
			{
				progress = async.progress;
			}
			else
			{
				progress = 1F;
			}

			slider.value = progress;
			text.text = Mathf.Floor(progress * 100F) + "%";

			if(progress == 1F)
			{
				async.allowSceneActivation = true;
			}
		}
	}
}