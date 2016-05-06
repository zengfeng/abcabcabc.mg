using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class MsgItem : MonoBehaviour 
	{
		public MsgBox 		msgBox;
		public MsgPosType 	msgPosType;
		public int 			index;

		public CanvasGroup canvasGroup;
		public float alpha_From = 0;
		public float alpha_To = 1;

		public Vector3 scale_From = new Vector3(1f, 0.5f, 1f);
		public Vector3 scale_To = new Vector3(1f, 1f, 1f);

		public Vector3 position_From = new Vector3(0f, 10f, 0f);
		public Vector3 position_To = new Vector3(0f, -10f, 0f);

		public float showTime = 0.2f;
		public float waitTime = 1f;
		public float hideTime = 0.3f;
		private float showAlpha_Speed;
		private float hideAlpha_Speed;
		
		private Vector3 position;
		private float _time = 0;
		private float _t = 0;

		void Start ()
		{
			if(canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
		}

		void OnEnable () 
		{
			Show();
		}

		void OnDisable()
		{
			StopAllCoroutines();
		}

		public void Show()
		{
			position = transform.localPosition;
			position_From = position + position_From;
			position_To = position + position_To;
			_time = 0f;
			StartCoroutine(ShowIng());
		}

		IEnumerator ShowIng()
		{
			while(_time < showTime)
			{
				_time += Time.deltaTime;
				_t = _time / showTime;
				canvasGroup.alpha = Mathf.Lerp(alpha_From, alpha_To, _t);
				transform.localScale = Vector3.Lerp(scale_From, scale_To, _t);
				transform.localPosition = Vector3.Lerp(position_From, position, _t);
				yield return new WaitForEndOfFrame();
			}

			canvasGroup.alpha = alpha_To;
			transform.localScale = scale_To;
			yield return new WaitForSeconds(waitTime);

			_time = 0;
			while(_time < hideTime)
			{
				_time += Time.deltaTime;
				_t = _time / hideTime;
				
				canvasGroup.alpha = Mathf.Lerp(alpha_To, 0, _t);
//				transform.localScale = Vector3.Lerp(scale_To, Vector3.zero, _t);
				
				transform.localPosition = Vector3.Lerp(position, position_To, _t);
				yield return new WaitForEndOfFrame();
			}

			gameObject.SetActive(false);
			transform.localPosition = position;
			if(msgBox != null) msgBox.OnClose(this);
			Destroy(gameObject);
		}

	}
}