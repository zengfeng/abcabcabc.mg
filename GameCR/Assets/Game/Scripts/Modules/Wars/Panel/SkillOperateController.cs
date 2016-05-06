using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Guides;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SkillOperateController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		public RectTransform helpPoint;
		public Camera uiCamera;
		public RectTransform rootScreen;
		public RectTransform rootButtons;
		public GameObject buttonStateRect;


		public BezierArrow bezierArrow;
		
		private float devWidth = 1920f;
		private float devHeight = 1280f;
		private float devAspect;

		private float screenWidth = 0;
		private float screenHeight = 0;
		private float aspect;
		private float rate = 1;

		private WarMaterialsType selectUnitMaterialType;

		void SetRate()
		{
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			
			float aspect = screenWidth / screenHeight;
			if(aspect >= devAspect)
			{
				rate = devHeight / screenHeight;
			}
			else
			{
				rate = devWidth / screenWidth;
			}
		}
		
		public bool interactable = false;
		public RectTransform 		scaleNode;
		public SkillOperateData 	data;
		public SkillOperateState	state;
		private SkillOperateState	_state;
		private bool				_operatoring;
		public SkillInfo 				skillInfoNode;
		public SkillButton 				skillButton;
		public SkillButton_UseEffect	useEffect;
		public Vector2					initAnchoredPosition;
		public Vector3					initPosition;
		
		public bool 				objDestory;
		public GameObject			obj;
		public LayerMask			groundLayer;
		public LayerMask			unitLayer;
		public float 				maxDistance = 200F;

		private SkillOperateState _downState;
		private bool _isDrag = false;
		public bool isDraging = false;
		public List<UnitCtl> selectCacheList = new List<UnitCtl>();
		
		public RectTransform 	rectTransform
		{
			get
			{
				return (RectTransform) transform;
			}
		}

		void Awake()
		{
			initAnchoredPosition = rectTransform.anchoredPosition;
			initPosition = rectTransform.position;
		}

		void Update()
		{
			if(this.data != null)
			{
				if(state != this.data.operateState)
				{
					state = data.operateState;
					switch(this.data.operateState)
					{
					case SkillOperateState.Empty:
						EmptyState();
						break;
					case SkillOperateState.Normal:
						CancelDrag(false);
						NormalState();
						break;
					case SkillOperateState.Selected:
						SelectedState();
						break;
					case SkillOperateState.Drag_Button:
						DragButtonState();
						break;
					case SkillOperateState.Drag_Object:
						DragObjectState();
						break;
					}
				}

				
				
				if(_operatoring != data.operatoring)
				{
					_operatoring = data.operatoring;
					if(_operatoring)
					{
						BeginShowOperateHelp();
					}
					else
					{
						EndShowOperateHelp();
					}
				}

				interactable = Guide.warConfig.GetEnableSkillSkillId(data.skillId);

			}
			else
			{
				if(state != SkillOperateState.Empty)
				{
					state = SkillOperateState.Empty;
					EmptyState();
				}
			}

			if(_state != state)
			{
				_state = state;

				if(_state == SkillOperateState.Empty)
				{

					if(data != null) data.sSetUse -= SetUse;
					data = null;
				}
			}


		}

		public void SetData(SkillOperateData data)
		{
			uiCamera = Coo.uiCamera;

			this.data = data;
			data.receiveList.Clear();
			skillButton.SetData(data);
			skillInfoNode.SetData (data);
			if(useEffect != null) useEffect.SetData(data);



			if(data.skillConfig.skillType == SkillType.Build_Replace)
			{
				BuildConfig buildConfig = War.model.GetBuildConfig(data.skillConfig.buildId);
				Debug.Log("data.skillId=" + data.skillId + "  data.skillConfig.buildId=" + data.skillConfig.buildId);
				string file = buildConfig.GetLevelConfig(1).avatarConfig.Model;
				Debug.Log(file);
				GameObject prefab = WarRes.GetPrefab(file);
				obj = GameObject.Instantiate(prefab);
				obj.SetActive(false);
				obj.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f);
				objDestory = true;
			}
			else
			{
				switch(data.skillConfig.operate)
				{
				case SkillOperateType.SelectCircle:
					obj = GameObject.Instantiate (War.skillUse.selectCircleView.gameObject);
					obj.SetActive (false);
					SkillOperateSelectCircleView skillOperateSelectCircleView = obj.GetComponent<SkillOperateSelectCircleView> ();
					skillOperateSelectCircleView.Radius = data.skillConfig.radius;
					skillOperateSelectCircleView.Relation = data.skillConfig.relation;
					objDestory = true;
					break;
				}
			}

			selectUnitMaterialType = data.skillConfig.relation.REnemy() ? WarMaterialsType.operateSelect_Enemy : WarMaterialsType.operateSelect_Own;

			if(this.data != null)
			{
				rectTransform.anchoredPosition = new Vector2(-180, 56);
				MoveToGroove();

				this.data.sSetUse += SetUse;
			}
		}

		/** 状态--置空 */
		public void EmptyState()
		{
			interactable = false;
			skillButton.Visiable = false;
			skillButton.Selected = false;

			if(obj != null)
			{
				obj.SetActive(false);
				if(objDestory) GameObject.Destroy(obj);

				obj = null;
			}

		}
		
		/** 状态--正常 */
		public void NormalState()
		{
			interactable = true;
			skillButton.Visiable = true;
			skillButton.Selected = false;

			if(obj != null)
			{
				obj.SetActive(false);
			}
		}
		
		/** 状态--选中 */
		public void SelectedState()
		{
			skillButton.Visiable = true;
			skillButton.Selected = true;

			if(obj != null)
			{
				obj.SetActive(false);
			}
		}

		
		/** 状态--拖动—按钮形态 */
		public void DragButtonState()
		{
			skillButton.Visiable = true;
			skillButton.Selected = false;

			if(obj != null)
			{
				obj.SetActive(false);
			}
		}

		
		/** 状态--拖动—物件形态 */
		public void DragObjectState()
		{

			if(obj != null)
			{
				skillButton.Visiable = false;
				obj.SetActive(true);
			}
		}
		

		#region PointerEvent
		/** 鼠标--按下 */
		public void OnPointerDown (PointerEventData eventData)
		{

			initPosition = rectTransform.position;
//			Debug.Log("OnPointerDown");
			if(!interactable) return;
			_downState = data.operateState;
			data.operatoring = true;
			War.skillOperateSelect.SetSelect(this);
		}
		
		/** 鼠标--开始拖动 */
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(!interactable) return;
			_isDrag = true;
//			Debug.Log("SkillOperateController OnBeginDrag _isDrag=" + _isDrag);
			OnBeginDragHandler();
		}


		/** 鼠标--拖动 */
		public void OnDrag (PointerEventData eventData)
		{
//			Debug.Log("OnDrag");
//			OnDragHandler();
		}

		
		/** 鼠标--松开 */
		public void OnPointerUp (PointerEventData eventData)
		{
//			Debug.Log("OnPointerUp");
//			OnPointerUpHandler();
		}
		
		/** 鼠标--点击 */
		public void OnPointerClick (PointerEventData eventData)
		{
			if(!interactable) return;
			if(_isDrag) return;

//			Debug.Log("SkillOperateController OnPointerClick _isDrag=" + _isDrag + "  _downState=" + _downState );

			if(data.skillConfig.operate == SkillOperateType.Immediately)
			{
				if(_downState != SkillOperateState.Selected)
				{
					Use();
				}
			}
			
			if(data.operateState != SkillOperateState.Empty)
			{

				// 因为拖动后都取消选中状态
				SetNormal();

				// 因为拖动后都取消选中状态，所以暂时注销
//				if(_downState == SkillOperateState.Selected)
//				{
//					SetNormal();
//				}
//				else
//				{
//					data.operateState = SkillOperateState.Selected;
//				}
			}
		}


		void SetNormal()
		{
			
			data.operateState = SkillOperateState.Normal;
			data.operatoring = false;
			War.skillOperateSelect.CancelSelect(this);
		}
		
		/** 鼠标--结束拖动 */
		public void OnEndDrag(PointerEventData eventData)
		{
			_isDrag = false;
		}

		#endregion

		
		#region Event Handler
		/** 鼠标--按下 */
		public void OnPointerDownHandler ()
		{
//			Debug.Log("OnPointerDownHandler");
		}
		
		/** 鼠标--开始拖动 */
		public void OnBeginDragHandler()
		{
//			Debug.Log("SkillOperateController OnBeginDragHandler _isDrag=" + _isDrag);
			SetRate();
			_isDrag = true;
			isDraging = true;
			skillButton.Drag = true;
			transform.parent = rootScreen;
			buttonStateRect.SetActive(true);

			if (data.skillConfig.operate == SkillOperateType.SelectUnit) 
			{
				bezierArrow.SetTexture (War.icons.GetSkillSelectTexture(data.selectUnitIconType));
				bezierArrow.beginAnchor.position = initPosition;
				bezierArrow.endAnchor.position = transform.position;
				bezierArrow.VisiableArrow = obj == null;

				bezierArrow.Show ();
				bezierArrow.useing = true;
			}
			else 
			{
				bezierArrow.useing = false;
			}
		}

		
		/** 鼠标--拖动 */
		public void OnDragHandler ()
		{
//			Debug.Log("SkillOperateController OnDragHandler _isDrag=" + _isDrag);
			if(!interactable) return;
			ClearSelectCacheList ();

			rectTransform.anchoredPosition = Input.mousePosition * rate;

			
			SkillOperateState operateState = SkillOperateState.Drag_Object;
			
			Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);
			
			if (hit2D.collider != null)
			{
				//如果射线检测到的gameobject为grid，就把当前Panel放在grid节点下
				if(hit2D.collider.gameObject == buttonStateRect)
				{
					operateState = SkillOperateState.Drag_Button;
				}
			}

			if (data.skillConfig.operate == SkillOperateType.SelectUnit || data.skillConfig.operate == SkillOperateType.SelectCircle) 
			{
				scaleNode.localScale = Vector3.one * Mathf.Lerp (1, 0f, operateState == SkillOperateState.Drag_Button ? Mathf.Abs (rectTransform.position.y - initPosition.y) / 2.5f : 1f);
			} 
			else 
			{
				scaleNode.localScale = Vector3.one * Mathf.Lerp (1, 0.5f, operateState == SkillOperateState.Drag_Button ? Mathf.Abs (rectTransform.position.y - initPosition.y) / 2.5f : 1f);
			}


			skillInfoNode.Visiable = operateState == SkillOperateState.Drag_Object;

			if (bezierArrow.useing) 
			{
				if (data.operateState != operateState) 
				{
					bezierArrow.Visiable = operateState == SkillOperateState.Drag_Object;
				} 
			}

			
			data.operateState = operateState;


			bool hasTarget = true;
			if (data.skillConfig.operate == SkillOperateType.SelectUnit)
			{
				hasTarget = data.candidateReceiveCount > 0;
			}
			skillInfoNode.HasTarget = hasTarget;
			
			bool isSnap = data.skillConfig.operate == SkillOperateType.SelectUnit;
			RaycastHit hit3d;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			data.candidateEntity = null;

			if (isSnap && War.config.skillSnap && data.operateState == SkillOperateState.Drag_Object) 
			{
				if (Physics.Raycast (ray, out hit3d, maxDistance, groundLayer.value)) 
				{
					Vector3 hitPoint = hit3d.point.SetY (0F);

					float minDistance = float.MaxValue;
					UnitCtl minEntity = null;
					for (int i = 0; i < data.candidateReceiveList.Count; i++) {
						UnitCtl entity = data.candidateReceiveList [i];
						float distance = Vector3.Distance (hitPoint, entity.transform.position);
						if (distance < minDistance) {
							minDistance = distance;
							minEntity = entity;
						}
					}

					data.candidateEntity = minEntity;
				}
			}
			else 
			{
				if (isSnap) 
				{
					if (Physics.Raycast (ray, out hit3d, maxDistance, unitLayer.value))
					{
						UnitCtl entity = hit3d.collider.gameObject.GetComponent<UnitCtl> ();
						if (entity != null && data.EnableUse (entity)) {
							data.candidateEntity = entity;
						}
					}
				}
				else if(data.skillConfig.operate == SkillOperateType.SelectCircle)
				{
					if (Physics.Raycast (ray, out hit3d, maxDistance, groundLayer.value))
					{

						obj.transform.position = hit3d.point.SetY(0F);
						List<UnitCtl>  entityList = War.scene.SearchUnit (obj.transform.position, data.skillConfig.radius, data.skillConfig.unitType, data.legionId,  data.skillConfig.relation);
					

						for(int i = 0; i < entityList.Count; i++)
						{
							AddSelectCache (entityList[i]);
						}


						helpPoint.anchoredPosition = Camera.main.WorldToScreenPoint(obj.transform.position) * rate;
					}
				}

			}

			if (isSnap) {
				if (data.candidateEntity != null) {
					rectTransform.anchoredPosition = Camera.main.WorldToScreenPoint (data.candidateEntity.transform.position) * rate;
					if (obj != null)
						obj.transform.position = data.candidateEntity.transform.position;


					AddSelectCache (data.candidateEntity);
				} else if (obj != null) {
					if (Physics.Raycast (ray, out hit3d, maxDistance, groundLayer.value)) {
						obj.transform.position = hit3d.point.SetY (0F);
					}
				}

				helpPoint.anchoredPosition = rectTransform.anchoredPosition;
			} 
			else 
			{
				helpPoint.anchoredPosition = rectTransform.anchoredPosition;
			}





//			if(obj != null)
//			{
//				
//				if(isSnap && Physics.Raycast(ray, out hit3d, maxDistance, unitLayer.value))
//				{
//					UnitCtl entity = hit3d.collider.gameObject.GetComponent<UnitCtl>();
//					if(entity != null && data.EnableUse(entity))
//					{
//						obj.transform.position = hit3d.collider.transform.position;
//
//
//						AddSelectCache (entity);
//					}
//					
//				}
//				else if(Physics.Raycast(ray, out hit3d, maxDistance, groundLayer.value))
//				{
//					obj.transform.position = hit3d.point.SetY(0F);
//
//
//					List<UnitCtl>  entityList = War.scene.SearchUnit (obj.transform.position, data.skillConfig.radius, data.skillConfig.unitType, data.legionId,  data.skillConfig.relation);
////					List<UnitCtl>  entityList = War.scene.SearchUnit (obj.transform.position, data.skillConfig.radius, 0.USolider(true), data.legionId,  0.REnemy(true));
//
//
//					for(int i = 0; i < entityList.Count; i++)
//					{
//						AddSelectCache (entityList[i]);
//					}
//				}
//
//
//				helpPoint.anchoredPosition = Camera.main.WorldToScreenPoint(obj.transform.position) * rate;
//
//			}
//			else
//			{
//				if(isSnap && Physics.Raycast(ray, out hit3d, maxDistance, unitLayer.value))
//				{
//					UnitCtl entity = hit3d.collider.gameObject.GetComponent<UnitCtl>();
//					if(entity != null && data.EnableUse(entity))
//					{
//						rectTransform.anchoredPosition = Camera.main.WorldToScreenPoint(hit3d.collider.transform.position) * rate;
//						AddSelectCache (entity);
//					}
//				}
//
//				helpPoint.anchoredPosition = rectTransform.anchoredPosition;
//			}


			if(bezierArrow.useing) bezierArrow.endAnchor.position = helpPoint.position + new Vector3(0,0, 5);



			SetSelectCacheListEffect ();
		}
		
		
		
		/** 鼠标--松开 */
		public void OnPointerUpHandler ()
		{
//			Debug.Log("OnPointerUpHandler");
			if(!interactable) return;
		}
		

		
		
		/** 鼠标--结束拖动 */
		public void OnEndDragHandler(bool enableSelect = true)
		{
//			Debug.Log("SkillOperateController OnEndDragHandler _isDrag=" + _isDrag + "  enableSelect=" + enableSelect);
//			Debug.Log("OnEndDragHandler");
			if(!interactable) return;


			isDraging = false;
			skillButton.Drag = false;
			rectTransform.parent = rootButtons;
			scaleNode.localScale = Vector3.one;
			skillInfoNode.Visiable = false;


			CheckOperate();

			if(data.operateState != SkillOperateState.Empty)
			{
				// 因为拖动后都取消选中状态
				SetNormal();
				// 因为拖动后都取消选中状态，所以暂时注销
//				if(IsInButtonRect())
//				{
//					SetNormal();
//				}
//				else
//				{
//					if(enableSelect)
//					{
//						data.operateState = SkillOperateState.Selected;
//					}
//				}
				MoveToGroove();
				if(bezierArrow.useing) bezierArrow.Backward();
			}
			else
			{
				rectTransform.anchoredPosition = initAnchoredPosition;
				if(bezierArrow.useing) bezierArrow.Forward();
			}
			buttonStateRect.SetActive(false);
			ClearSelectCacheList ();

		}


		public void CancelDrag(bool enableSelect = true)
		{

			if(isDraging)
			{
				OnPointerUpHandler();
				OnEndDragHandler(enableSelect);
			}
		}

		#endregion


		public void BeginShowOperateHelp()
		{
			War.skillUse.ShowHelp(data);
			SkillHelpText.Show(data);
		}


		public void EndShowOperateHelp()
		{
			SkillHelpText.Hide(data);
			data.CancelOperator();
			War.skillOperateSelect.CancelSelect(this);
		}


		public bool IsInButtonRect()
		{
			bool preactive = buttonStateRect.gameObject.activeSelf;
			buttonStateRect.gameObject.SetActive(true);
			bool isInButtonRect = false;
			Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);
			if (hit2D.collider != null)
			{
				//如果射线检测到的gameobject为grid，就把当前Panel放在grid节点下
				if(hit2D.collider.gameObject == buttonStateRect)
				{
					isInButtonRect = true;
				}
			}
			buttonStateRect.gameObject.SetActive(preactive);
			
			return isInButtonRect;
		}

		public UnitCtl CheckSelectBuild()
		{
			RaycastHit hit3d;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit3d, maxDistance, unitLayer.value))
			{
				UnitCtl buildUnitCtl = hit3d.collider.GetComponent<UnitCtl>();
				if(data.EnableUse(buildUnitCtl))
				{
					return buildUnitCtl;
				}
			}

			return null;
		}

		public void CheckOperate()
		{
//			Debug.Log("CheckOperate");
			switch(data.skillConfig.operate )
			{
			case SkillOperateType.Immediately:
			case SkillOperateType.Passive:
				if(!IsInButtonRect())
				{
					Use();
				}
				break;
			case SkillOperateType.SelectUnit:
//				UnitCtl entity = CheckSelectBuild();
				UnitCtl entity = data.candidateEntity;
				if(entity != null)
				{
					data.receiveList.Add(entity);
					Use();
				}
				break;
			case SkillOperateType.SelectCircle:
				if(!IsInButtonRect())
				{
					data.receivePosition = obj.transform.position;
					Use();
				}
				break;
			}

		}

		
		public void Use()
		{
//			Debug.Log("Use");
			if(useEffect != null && obj == null) useEffect.Play(transform.position, data.skillConfig.operate);
			data.OnUse();
		}


		public void SetUse(SkillOperateData skillOperateData)
		{
			if(useEffect != null && obj == null) useEffect.Play(transform.position, data.skillConfig.operate);
		}





		/** 移动到凹槽位置 */
		public bool mtgScale;
		public float mtgTime = 0.1f;
		private Vector2 _mtgFrom;
		private float _mtgTime = 0f;
		public void MoveToGroove()
		{
			rectTransform.parent = rootButtons;
			rectTransform.SetAsLastSibling();
			_mtgFrom = rectTransform.anchoredPosition;
			_mtgTime = 0;
			if(gameObject.activeInHierarchy)
			{
				StartCoroutine(OnMoveToGroove());
			}
			else
			{
				SetInitPosition();
			}
		}

		IEnumerator OnMoveToGroove()
		{
			skillButton.MoveBack = true;
			while(_mtgTime < mtgTime)
			{
				_mtgTime += Time.deltaTime;
				float rate = _mtgTime/mtgTime;
				rectTransform.anchoredPosition = Vector2.Lerp(_mtgFrom, initAnchoredPosition, rate);
				yield return new WaitForEndOfFrame();
			}

			float time = 0.08f;
			float _t = 0;
			Vector2 posA = initAnchoredPosition + (_mtgFrom - initAnchoredPosition).normalized * 6;
			Vector2 posB = initAnchoredPosition + (_mtgFrom - initAnchoredPosition).normalized * -3f;

			Vector3 scaleA = Vector3.one * 1.05f;
			Vector3 scaleB = Vector3.one * 0.925f;
			while(_t < time)
			{
				_t += Time.deltaTime;
				float rate = _t/time;
				rectTransform.anchoredPosition = Vector2.Lerp(initAnchoredPosition, posA, rate);
				if(mtgScale) rectTransform.localScale = Vector3.Lerp(Vector3.one, scaleA, rate);
				yield return new WaitForEndOfFrame();
			}

			time = 0.1f;
			_t = 0;
			while(_t < time)
			{
				_t += Time.deltaTime;
				float rate = _t/time;
				rectTransform.anchoredPosition = Vector2.Lerp(posA, posB, rate);
				if(mtgScale) rectTransform.localScale = Vector3.Lerp(scaleA, scaleB, rate);
				yield return new WaitForEndOfFrame();
			}
			
			time = 0.05f;
			_t = 0;
			while(_t < time)
			{
				_t += Time.deltaTime;
				float rate = _t/time;
				rectTransform.anchoredPosition = Vector2.Lerp(posB, initAnchoredPosition, rate);
				if(mtgScale) rectTransform.localScale = Vector3.Lerp(scaleB, Vector3.one, rate);
				yield return new WaitForEndOfFrame();
			}


			rectTransform.anchoredPosition = initAnchoredPosition;
			rectTransform.localScale = Vector3.one;
			skillButton.MoveBack = false;

		}

		void SetInitPosition()
		{
			rectTransform.parent = rootButtons;
			rectTransform.SetAsLastSibling();
			rectTransform.anchoredPosition = initAnchoredPosition;
			rectTransform.localScale = Vector3.one;
			skillButton.MoveBack = false;

		}



		public void ClearSelectCacheList()
		{
			while(selectCacheList.Count > 0)
			{
				UnitCtl unitCtl = selectCacheList[0];
				selectCacheList.RemoveAt (0);
				if (unitCtl != null && unitCtl.unitAgent != null)
				{
					unitCtl.unitAgent.BackMaterial (selectUnitMaterialType);
					unitCtl.unitAgent.visiableAvatar = true;
				}
			}
		}

		public void SetSelectCacheListEffect()
		{
			for(int i = 0; i < selectCacheList.Count; i ++)
			{
				UnitCtl unitCtl = selectCacheList[i];
				if (unitCtl != null && unitCtl.unitAgent != null)
				{
					unitCtl.unitAgent.SetMaterial (selectUnitMaterialType);
					if (data.skillConfig.skillType == SkillType.Build_Replace)
					{
						unitCtl.unitAgent.visiableAvatar = false;
					}
				}
			}
		}

		public void AddSelectCache(UnitCtl unitCtl)
		{
			if (!selectCacheList.Contains (unitCtl))
			{
				selectCacheList.Add (unitCtl);
			}
		}


	}
}