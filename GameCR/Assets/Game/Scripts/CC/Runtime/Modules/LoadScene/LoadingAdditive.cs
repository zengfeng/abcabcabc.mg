using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CC.Module.LoadScenes
{
	public class LoadingAdditive : MonoBehaviour, ILoading 
	{
		public Slider slider;
		public Text text;
		public Text describeText;

		protected AsyncOperation async;
		protected float progressScene = 0F;

		virtual protected void Start()
		{
			StartCoroutine(LoadScene());
			LoadSceneManager.loadOtherProgressSignal.AddListener(OnOtherProgress);
			LoadSceneManager.loadOtherCompleteSignal.AddListener(OnOtherComplete);
		}

		IEnumerator LoadScene()
		{
			async = Application.LoadLevelAdditiveAsync(LoadSceneManager.sceneName);
			async.allowSceneActivation = false;

			yield return async;
		}

		virtual protected void Update()
		{
			if(progressScene < 1)
			{
				UpdateLoadScene();
			}
		}

		virtual protected void UpdateLoadScene()
		{
			if(async.progress < 0.9F)
			{
				progressScene = async.progress;
			}
			else
			{
				progressScene = 1F;
			}
			slider.value = progressScene;
			text.text = Mathf.Floor(progressScene * 100F) + "%";

			if(progressScene == 1F)
			{
				async.allowSceneActivation = true;
			}
		}

		virtual protected void OnOtherProgress(float progress, string describe)
		{
			slider.value = progress;
			text.text = Mathf.Floor(progress * 100F) + "%";
			describeText.text = describe;
		}

		
		virtual protected void OnOtherComplete()
		{
			LoadSceneManager.loadOtherProgressSignal.RemoveListener(OnOtherProgress);
			LoadSceneManager.loadOtherCompleteSignal.RemoveListener(OnOtherComplete);

			GameObject.DestroyImmediate(gameObject);
		}
	}
}