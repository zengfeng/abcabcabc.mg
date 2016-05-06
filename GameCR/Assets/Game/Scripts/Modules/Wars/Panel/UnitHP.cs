using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CC.Runtime.signals;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class UnitHP : WBaseUI
	{
		private bool fullHP = false;
		private int _colorId = -1;
		public int colorId = 0;
		public Image color;
		public Text text;
		public float value;
		public float max = 100;
		public bool visiable = true;
		public CanvasGroup canvasGroup;


		protected override void OnAwake ()
		{
			base.OnAwake ();
			if(color 	== null) color 		= transform.FindChild("Color").GetComponent<Image>();
			if(text 	== null) text 		= transform.FindChild("Color/Text").GetComponent<Text>();
			if(canvasGroup	== null) canvasGroup	= GetComponent<CanvasGroup>();

			SetVal(value, max, true);
		}

		public void SetBarVisiable(bool visiableBar)
		{
			fullHP = !visiableBar;
		}
	
		
		public void SetVal(float val, float max, bool forceUpdate = false)
		{
			if(this.value != val || this.max != max || forceUpdate)
			{
				this.value = val;
				this.max = max;

				text.text = ((int)val).ToString();
				color.fillAmount = (fullHP || max == 0) ? 1 : val / max;
			}
		}

		public void SetVisible(bool visiable)
		{
			if(this.visiable != visiable)
			{
				this.visiable = visiable;
				gameObject.SetActive(visiable);

				if(visiable)
				{
					canvasGroup.DOKill();
					canvasGroup.alpha = 1;
				}
			}
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(_colorId != colorId)
			{
				_colorId = colorId;
				color.color = WarColor.GetUnitHPColor(colorId);
			}
		}


		public float damageDelay = 0.5f;
		public float damageDuration = 0.5f;
		public void OnDamage(DamageVO damageVO)
		{
			if(visiable)
			{
				return;
			}

			if(damageVO.fromType != DamageFromType.Solider)
			{
				return;
			}

			
			
			if(damageVO.fromType != DamageFromType.Solider)
			{
				return;
			}

			if(damageVO.caster != null && damageVO.caster.unitData.relation == RelationType.Enemy)
			{
				return;
			}

			canvasGroup.DOKill();
			gameObject.SetActive(true);
			canvasGroup.alpha = 1;
			canvasGroup.DOFade(0, damageDuration).SetDelay(damageDelay).OnComplete(()=>{if(!visiable) gameObject.SetActive(false);});
		}



	}
}