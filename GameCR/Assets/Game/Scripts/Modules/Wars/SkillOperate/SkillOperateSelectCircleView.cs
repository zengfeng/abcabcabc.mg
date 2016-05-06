using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using CC.Runtime.Utils;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	public class SkillOperateSelectCircleView : EntityView
	{
		public HSignal sSelect = new HSignal();
		public HSignal sCanel = new HSignal();

		public LayerMask terrianLayer;
		public LayerMask uiLayer;
		public bool isDown;
		private Vector3 _oldMousePosition;
		private Vector3 _offset;
		public SpriteRenderer[] sprites;
		public Animator animator;
		public SpriteRenderer icon;
		public bool isFinal = false;

		private float defaultRadius = 4F;
		public float radius = 4F;
		public int relation;

		public Color colorOwn;
		public Color colorEnemy;

		public float Radius
		{
			get
			{
				return radius;
			}

			set
			{
				radius = value;
				icon.transform.localScale = Vector3.one * radius / 1;
			}
		}

		public int Relation 
		{
			get 
			{
				return relation;
			}

			set 
			{
				relation = value;

				if (relation.REnemy ())
				{
					icon.color = colorEnemy;
				}
				else
				{
					icon.color = colorOwn;
				}

			}
		}


//
//		protected override void OnEnable ()
//		{
//			base.OnEnable ();
//			Radius = radius;
//			War.input.Skill();
//			isCancel = false;
//			isFinal = false;
//			isUpdatePosition = false;
//			_oldMousePosition = transform.position;
////			_oldMousePosition = Vector3.zero;
////			transform.position = Vector3.zero;
//			Alhpa = 1;
//			animator.enabled = true;
//			if(War.config.PCOperater)
//			{
//				#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX
//				_oldMousePosition = Input.mousePosition;
//				SetPosition();
//				isUpdatePosition = true;
//				#endif
//			}
//		}
//
//
//		protected override void OnDisable ()
//		{
//			base.OnDisable ();
//			War.input.Normal();
//		}
//
//		private float _alpha = 1;
//		public float Alhpa
//		{
//			get
//			{
//				return _alpha;
//			}
//
//			set
//			{
//				_alpha = value;
//				if(_alpha >=0)
//				{
//					foreach(SpriteRenderer sprite in sprites)
//					{
//						Color color = sprite.color.Clone();
//						color.a = _alpha;
//						sprite.color = color;
//					}
//				}
//			}
//		}
//
//		private bool isUpdatePosition;
//		protected override void OnUpdate ()
//		{
//			base.OnUpdate ();
//
//			if(isCancel)
//			{
//				FlyOut();
//				return;
//			}
//
//			if(!isFinal)
//			{
//				if(Input.GetMouseButtonDown(0) && isDown == false)
//				{
//					if(!War.input.HitUI)
//					{
//						isDown = true;
//						isUpdatePosition = true;
//						_oldMousePosition = Input.mousePosition;
//					}
//				}
//
//				
//				if(isDown)
//				{
//					_offset = Input.mousePosition - _oldMousePosition;
//					_oldMousePosition = Input.mousePosition;
//
//				}
//
//				if(isDown && Input.GetMouseButtonUp(0))
//				{
//					isDown = false;
//					isFinal = true;
//
//					Debug.Log("_offset = " + _offset + " _offset.magnitude= " + _offset.magnitude);
//					if(_offset.magnitude >= 15)
//					{
//						Cancel();
//					}
//					else
//					{
//						Select();
//					}
//				}
//			}
//
//			
//			if(!isCancel)
//			{
//				if(isUpdatePosition) UpdatePosition();
//			}
//		}
//
//		void End()
//		{
//			if(isCancel)
//			{
//				sCanel.Dispatch();
//			}
//			else
//			{
//				sSelect.Dispatch();
//			}
//
//			gameObject.SetActive(false);
//		}
//
//		void Select()
//		{
//		}
//
//		public bool isCancel = false;
//		private float flySpeed = 10;
//		private Vector3 flyDirection;
//		void Cancel()
//		{
//			isCancel = true;
//			flySpeed = 10 ;
//			flyDirection = _offset.normalized;
//			_offset = Vector3.zero;
//			animator.enabled = false;
//		}
//
//		void FlyOut()
//		{
//			transform.position += flyDirection * flySpeed;
//			flySpeed *= 0.5F;
//			Alhpa *= 0.5F;
//			if(Alhpa < 0.05F)
//			{
//				End();
//			}
//		}
//
//		private float speed = 8F;
//		void UpdatePosition()
//		{
//			Vector3 point = GetPosition(_oldMousePosition);
//			_oldPoint = Vector3.Lerp(transform.position, point, 0.5F);
//			transform.position = _oldPoint;
//
//			if(isFinal)
//			{
//				if(Vector3.Distance(transform.position, point) < 0.1F)
//				{
//					End();
//				}
//			}
//		}
//
//		void SetPosition()
//		{
//			transform.position = GetPosition(Input.mousePosition);
//		}
//
//
//		private Vector3 _oldPoint = Vector3.zero;
//		Vector3 GetPosition(Vector3 mousePosition)
//		{
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			if (Physics.Raycast(ray, out hit, 300, terrianLayer.value))
//			{
//				Vector3 point = hit.point;
//				point.y = 0.01f;
//				return point;
//			}
//			return _oldPoint;
//		}


	}
}