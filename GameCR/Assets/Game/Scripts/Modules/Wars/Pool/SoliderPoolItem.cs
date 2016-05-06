using UnityEngine;
using System.Collections;
namespace Games.Module.Wars
{

	public class SoliderPoolItem : MonoBehaviour
	{
		public bool isPut = false;
		public bool isRelease = false;
		public bool needRest = false;
		private WarSoliderPool pool;
		private Coroutine coroutinePutPool;
		private Coroutine coroutineRelease;
		public WarSoliderPool Pool
		{
			set
			{
				pool = value;
			}
		}

		void StopCoroutineAll()
		{
			if(War.scene != null)
			{
				if (coroutineRelease != null)
					War.scene.StopCoroutine (coroutineRelease);

				if (coroutinePutPool != null)
					War.scene.StopCoroutine (coroutinePutPool);
			}
		}

		public void DelayRelease(float time)
		{
			StopCoroutineAll();

			coroutineRelease = War.scene.StartCoroutine(OnDelayRelease(time));
		}

		IEnumerator OnDelayRelease(float time)
		{
			yield return new WaitForSeconds(time);
			Release();
		}

		public void Release()
		{

			if (coroutineRelease != null && War.scene != null)
				War.scene.StopCoroutine (coroutineRelease);
			
			StopCoroutineAll();

			needRest = true;
			gameObject.SendMessage("OnRelease");
			isRelease = true;

			iTween[] tweens = gameObject.GetComponents<iTween> ();
			for(int i = 0; i < tweens.Length; i ++)
			{
//				if (Application.isEditor) 
//				{
//					Debug.LogError ("soliderpool Release has iTween");
//				}

				GameObject.Destroy (tweens[i]);
			}

			if (coroutinePutPool != null && War.scene != null)
				War.scene.StopCoroutine (coroutinePutPool);
			coroutinePutPool = War.scene.StartCoroutine (DelayPutPool());
		}

		IEnumerator DelayPutPool()
		{
			yield return new WaitForEndOfFrame ();
			gameObject.SetActive(false);
			yield return new WaitForEndOfFrame ();
			if(isPut)
			{
				Debug.Log("<color=red>SoliderPoolItem isPut=" + isPut + "</color>");
			}

			pool.Put(gameObject);
			isPut = true;
		}

		public void Rest()
		{
			if(needRest) gameObject.SendMessage("OnRest");

			if (Application.isEditor)
			{
				if (gameObject.GetComponent<iTween>()) 
				{
					Debug.LogError ("soliderpool Rest has iTween");
				}
			}

			isRelease = false;
			if (coroutineRelease != null && War.scene != null)
				War.scene.StopCoroutine (coroutineRelease);


			if (coroutinePutPool != null && War.scene != null)
				War.scene.StopCoroutine (coroutinePutPool);
		}
	}




}