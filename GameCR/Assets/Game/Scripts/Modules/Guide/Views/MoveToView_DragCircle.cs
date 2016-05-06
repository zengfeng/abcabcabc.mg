using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using Games.Module.Wars;


namespace Games.Guides
{
	public class MoveToView_DragCircle : AbstractMoveToView 
	{
		public RectTransform content;
		public RectTransform hand;
		public RectTransform circle;
		public RectTransform arrow;
		public LayerMask circleViewLayerMask;
		public SkillOperateSelectCircleView circleView;

		public Vector3 from;
		public Vector3 to;
		public Vector3 localFrom = Vector3.zero;
		public Vector3 localTo;


		public float delayBegin = 0.5f;
		public float delayEnd = 0.5f;
		public float speed = 1f;
		public float time;
		public float backtime;
		public float _time;
		public float _t;
		public float arrowScale = 0;
		public float _arrowScale = 0;

		public float radius = 5f;
		public void SetRadius(float radius)
		{
			this.radius = radius;
			if (circleView != null) 
			{
				circleView.radius = radius;
			}
		}

		void Awake()
		{
			if(speed == 0) speed = 0.001f;

			GameObject go = GameObject.Instantiate (War.skillUse.selectCircleView.gameObject);
			circleView = go.GetComponent<SkillOperateSelectCircleView> ();
			circleView.Radius = radius;
			WorldFllowUIPosition worldFllowUIPosition = go.AddComponent<WorldFllowUIPosition> ();
			worldFllowUIPosition.targetUI = circle;
			worldFllowUIPosition.layerMask = circleViewLayerMask;
			circleView.gameObject.SetActive (false);
		}


		void OnDisable()
		{
			Stop();
			StopAllCoroutines();

			_t = 0;
			arrow.localScale = Vector3.zero;

			if(circleView != null)
				circleView.gameObject.SetActive (false);
		}

		void OnDestroy()
		{
			if (circleView != null) 
			{
				Destroy (circleView.gameObject);
			}
		}
	

		[ContextMenu("Play")]
		override public void Play()
		{
			isPlay = true;
			from = fromTransform.position;
			to = toTransform.position;


			localTo = to - from;
			content.position = from;
			time = localTo.magnitude / speed;
			backtime = time / 4;
			arrowScale = localTo.magnitude / 2;
			arrow.eulerAngles = new Vector3(0F, 0F, HMath.angle(0, 0, localTo.x, localTo.y));
			arrow.localScale = new Vector3(0, Mathf.Clamp(0, 0, 2F), 1);
			
			_time = 0;
			StopAllCoroutines();
			StartCoroutine(Playing());
		}

		IEnumerator Playing()
		{
			bool isBack = false;
			while(isPlay)
			{
				if(isBack == false)
				{
					if(_time == 0)
					{
						hand.position =  from;
						_arrowScale = arrowScale * _t;
						arrow.localScale = new Vector3(_arrowScale, 1, 1);
						yield return new WaitForSeconds(delayBegin * 0.4f);
						hand.localScale =  Vector3.one * 0.8f;
						yield return new WaitForSeconds(delayBegin * 0.1f);
						circle.localScale = Vector3.one * 0.8f;
						yield return new WaitForSeconds(delayBegin * 0.5f);

						circleView.gameObject.transform.position = new Vector3 (0, -10, -1000);
						circleView.gameObject.SetActive (true);
					}

					_time += Time.deltaTime;
					_t = _time / time;
					hand.position = Vector3.Lerp(from, to, _t);
					circle.position = hand.position;
					
					_arrowScale = arrowScale * _t;
					arrow.localScale = new Vector3(_arrowScale, 1, 1);
					if(_t >=1)
					{
						_time = 0;
						_t = 0;
						isBack = true;
					}
					
					if(from != fromTransform.position || to != toTransform.position)
					{
						from = fromTransform.position;
						to = toTransform.position;
						
						localTo = to - from;
						content.position = from;
						
						arrowScale = localTo.magnitude / 2;
						arrow.eulerAngles = new Vector3(0F, 0F, HMath.angle(0, 0, localTo.x, localTo.y));
						time = localTo.magnitude / speed;
					}
				}
				else
				{
					if(_time == 0)
					{
						yield return new WaitForSeconds(delayEnd);
						_arrowScale = arrowScale * _t;
						arrow.localScale = new Vector3(_arrowScale, 1, 1);
						circle.localScale = Vector3.one;
					}

					
					_time += Time.deltaTime;
					_t = _time / backtime;
					hand.position = Vector3.Lerp(to, from, _t);

					if(_t >=1)
					{
						_time = 0;
						_t = 0;
						isBack = false;


						circleView.gameObject.SetActive (false);
						yield return new WaitForSeconds(0.1f);
						circle.position = from;
						circle.localScale = Vector3.one;
						yield return new WaitForSeconds(0.25f);
					}


				}
				
				yield return new WaitForEndOfFrame();

			}
		}
	}
}