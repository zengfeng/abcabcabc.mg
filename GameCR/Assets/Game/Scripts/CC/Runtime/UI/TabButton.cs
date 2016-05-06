using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using SimpleFramework;
using LuaInterface;
using System.Collections.Generic;

namespace CC.UI
{
	[AddComponentMenu("CC/UI/TabButton", 35)]
	[RequireComponent(typeof(RectTransform))]
	public class TabButton : BaseUI , IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{





		public int uid = 0;
		public object data;



		public bool Interactable = true;
		public TabGroup group;
		public Image image;
		public Text text;
		public GameObject mark;
		
		// color
		public bool useColor = true;
		
		public Color colorNormal = Color.white;
		public Color colorHighlighted = new Color(245F/255F, 245F/255F, 245F/255F);
		public Color colorPressed = new Color(200F/255F, 200F/255F, 200F/255F);
		public Color colorDisabled = new Color(200F/255F, 200F/255F, 200F/255F);
		
		public Color selectColorNormal = new Color(230F/255F, 230F/255F, 230F/255F);
		public Color selectColorHighlighted = new Color(245F/255F, 245F/255F, 245F/255F);
		public Color selectColorPressed = new Color(200F/255F, 200F/255F, 200F/255F);

		//sprite
		public bool useSprite = false;

		public Sprite spriteNormal;
		public Sprite spriteHighlighted;
		public Sprite spritePressed;
		public Sprite spriteDisabled;
		
		public Sprite selectSpriteNormal;
		public Sprite selectSpriteHighlighted;
		public Sprite selectSpritePressed;
		public Sprite selectSpriteDisabled;

		
		// text color
		public bool useTextColor = false;
		
		public Color textColorNormal = new Color(0F, 0F, 0F);
		public Color textColorHighlighted = new Color(20F/255F, 20F/255F, 20F/255F);
		public Color textColorPressed = new Color(30F/255F, 30F/255F, 30F/255F);
		public Color textColorDisabled = new Color(127F/255F, 127F/255F, 127F/255F);
		
		public Color textSelectColorNormal = new Color(20F/255F, 20F/255F, 20F/255F);
		public Color textSelectColorHighlighted = new Color(20F/255F, 20F/255F, 20F/255F);
		public Color textSelectColorPressed = new Color(30F/255F, 30F/255F, 30F/255F);

		public bool disableShowText = true;
		public bool operationDown = false;


		protected override void Awake ()
		{
			base.Awake ();
			if(useSprite)
			{
				if(spriteHighlighted 	== null) spriteHighlighted = spriteNormal;
				if(spritePressed 		== null) spritePressed = spriteNormal;
				if(spriteDisabled 		== null) spriteDisabled = spriteNormal;

				
				if(selectSpriteNormal 				== null) selectSpriteNormal = spriteNormal;
				if(selectSpriteHighlighted 			== null) selectSpriteHighlighted = selectSpriteNormal;
				if(selectSpritePressed 				== null) selectSpritePressed = selectSpriteNormal;
				if(selectSpriteDisabled 			== null) selectSpriteDisabled = selectSpriteNormal;
			}
		}
		
		override protected void Start ()
		{
			SetState();
		}
		
		public bool _isSelect;
		public bool IsSelect
		{
			get
			{
				return _isSelect;
			}
			
			set
			{
				_isSelect = value;
				onValueChanged.Invoke(_isSelect);
			}
		}

		
		
		//----------------------------
		[Serializable]
		public class TabEvent : UnityEvent<bool> { }
		[SerializeField]
		public TabEvent onValueChanged = new TabEvent();
		//----------------------------
		
		[Serializable]
		public class OnClickEvent : UnityEvent<TabButton> { }
		[SerializeField]
		private OnClickEvent m_OnClick = new OnClickEvent();
		public OnClickEvent onClick { get { return m_OnClick; }  }
		//----------------------------


		protected bool _pointerEnter = false;
		protected bool _pointerDown = false;
		virtual public void OnPointerEnter (PointerEventData eventData)
		{
			if(!Interactable) return;
			_pointerEnter = true;
		}

		virtual public void OnPointerDown (PointerEventData eventData)
		{
			if(!Interactable) return;
			_pointerDown = true;

			if(operationDown)
				Operation();
			

		}

		virtual public void OnPointerUp (PointerEventData eventData)
		{
			if(!Interactable) return;
			_pointerDown = false;

		}

		virtual public void OnPointerClick (PointerEventData eventData)
		{
			if(!Interactable) return;
			
			if(!operationDown)
				Operation();
		}


		virtual public void OnPointerExit (PointerEventData eventData)
		{
			if(!Interactable) return;
			_pointerEnter = false;
		}

		virtual protected void Operation()
		{
			if(group != null)
			{
				group.SetSelect(this);
			}
			else
			{
				IsSelect = !IsSelect;
			}

			
			m_OnClick.Invoke(this);
		}
		
		private bool _preInteractable = true;
		private bool _preIsSelect = false;
		private bool _prePointerEnter = false;
		private bool _prePointerDown = false;
		virtual protected void Update () 
		{
			if(_preInteractable != Interactable || 
			   _preIsSelect != _isSelect || 
			   _prePointerEnter != _pointerEnter || 
			   _prePointerDown != _pointerDown)
			{
				_preInteractable = Interactable;
				_preIsSelect = _isSelect;
				_prePointerEnter = _pointerEnter;
				_prePointerDown = _pointerDown;
				SetState();
			}
		}

		virtual protected void SetState()
		{
			SetTextDisable();
			SetTextColor();
			SetColor();
			SetSprite();
			SetMark();
		}

		/**
		 * Text Disable
		 */
		virtual protected void SetTextDisable()
		{
			if(text == null || disableShowText) return;

			if(Interactable)
			{
				text.gameObject.SetActive(true);
			}
			else
			{
				text.gameObject.SetActive(false);
			}
		}

		/**
		 * Text Color
		 */
		virtual protected void SetTextColor()
		{
			if(text == null || useTextColor == false) return;

			if(Interactable)
			{
				if(_isSelect)
				{
					if(_pointerDown)
					{
						text.color = textSelectColorPressed;
					}
					else if(_pointerEnter)
					{
						text.color = textSelectColorHighlighted;
					}
					else
					{
						text.color = textSelectColorNormal;
					}
				}
				else
				{
					if(_pointerDown)
					{
						text.color = textColorPressed;
					}
					else if(_pointerEnter)
					{
						text.color = textColorHighlighted;
					}
					else
					{
						text.color = textColorNormal;
					}
				}
			}
			else
			{
				text.color = textColorDisabled;
			}
		}
		
		/**
		 * Image Color
		 */
		virtual protected void SetColor()
		{
			if(image == null || useColor == false) return;
			
			if(Interactable)
			{
				if(_isSelect)
				{
					if(_pointerDown)
					{
						image.color = selectColorPressed;
					}
					else if(_pointerEnter)
					{
						image.color = selectColorHighlighted;
					}
					else
					{
						image.color = selectColorNormal;
					}
				}
				else
				{
					if(_pointerDown)
					{
						image.color = colorPressed;
					}
					else if(_pointerEnter)
					{
						image.color = colorHighlighted;
					}
					else
					{
						image.color = colorNormal;
					}
				}
			}
			else
			{
				image.color = colorDisabled;
			}
		}

		
		/**
		 * Image Sprite
		 */
		virtual protected void SetSprite()
		{
			if(image == null || useSprite == false) return;
			
			if(Interactable)
			{
				if(_isSelect)
				{
					if(_pointerDown)
					{
						image.sprite = selectSpritePressed;
					}
					else if(_pointerEnter)
					{
						image.sprite = selectSpriteHighlighted;
					}
					else
					{
						image.sprite = selectSpriteNormal;
					}
				}
				else
				{
					if(_pointerDown)
					{
						image.sprite = spritePressed;
					}
					else if(_pointerEnter)
					{
						image.sprite = spriteHighlighted;
					}
					else
					{
						image.sprite = spriteNormal;
					}
				}
			}
			else
			{
				if(_isSelect)
				{
					image.sprite = selectSpriteDisabled;
				}
				else
				{
					image.sprite = spriteDisabled;
				}
			}
		}

		/**
		 * Mark
		 */
		virtual protected void SetMark()
		{

			if(mark == null) return;
			
			if(Interactable)
			{
				if(_isSelect)
				{
					mark.SetActive(true);
				}
				else
				{
					mark.SetActive(false);
				}
			}
			else
			{
//				mark.SetActive(false);

				if(_isSelect)
				{
					mark.SetActive(true);
				}
				else
				{
					mark.SetActive(false);
				}
			}
		}





		public object GetData()
		{
			return data;
		}
		
		public void SetData(object val)
		{
			data = val;
		}
		
		public int GetID()
		{
			return uid;
		}
		
		public void SetID(int id)
		{
			uid = id;
		}

		public void SetGroup(TabGroup group)
		{
			this.group = group;
		}

		public void SetInteractable(bool interactable)
		{
			this.Interactable = interactable;
		}

		public void SetIsSelect(bool val)
		{
			SetIsSelect(val, true);
		}
		
		
		public void SetIsSelect(bool val, bool isSendSignal)
		{
			if(isSendSignal)
			{
				this.IsSelect = val;
			}
			else
			{
				_isSelect = val;
			}

		}



		
		private List<LuaFunction> buttons = new List<LuaFunction>();
		/// 添加单击事件
		public void AddClick(LuaFunction luafunc) {
			
			buttons.Add(luafunc);
			onClick.AddListener(
				delegate(TabButton select) {
				luafunc.Call(select);
			}
			);
		}
		
		/// 清除单击事件
		public void ClearClick() {
			for (int i = 0; i < buttons.Count; i++) {
				if (buttons[i] != null) {
					buttons[i].Dispose();
					buttons[i] = null;
				}
			}
		}
		
		
		//-----------------------------------------------------------------
		virtual protected void OnDestroy() {
			onValueChanged.RemoveAllListeners();
			ClearClick();
			Util.ClearMemory();
		}
	}
}
