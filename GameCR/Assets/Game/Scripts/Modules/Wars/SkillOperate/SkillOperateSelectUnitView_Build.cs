using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class SkillOperateSelectUnitView_Build : MonoBehaviour
	{
		public SpriteRenderer icon;
		/** 瞄准 */
		public Sprite iconAim;
		/** 攻击 */
		public Sprite iconAttack;
		/** 升级 */
		public Sprite iconUplevel;
		/** 升级2 */
		public Sprite iconUplevel2;
		/** 锤子 */
		public Sprite iconChange;
		/** 加 */
		public Sprite iconAdd;

		public Color enemyColor = Color.red;
		public Color findlyColor = Color.green;

		void Start () 
		{
			if(icon == null) icon = GetComponent<SpriteRenderer>();
		}

		public void Show(SkillOperateSelectUnitIconType iconType, bool isEnemy, int level)
		{
			icon.color = icon.color.SetAlhpa (1);
			switch(iconType)
			{
			case SkillOperateSelectUnitIconType.Aim:
				icon.sprite = iconAim;
				break;
			case SkillOperateSelectUnitIconType.Attack:
				icon.sprite = iconAttack;
				break;
			case SkillOperateSelectUnitIconType.Uplevel:
				icon.sprite = level >=2 ? iconUplevel2 : iconUplevel;
				break;
			case SkillOperateSelectUnitIconType.Change:
				icon.sprite = iconChange;
				break;
			case SkillOperateSelectUnitIconType.Add:
				icon.sprite = iconAdd;
				break;
			}

			if(iconType == SkillOperateSelectUnitIconType.Aim)
			{
				icon.color = isEnemy ? enemyColor : findlyColor;
			}
			else
			{
				icon.color = Color.white;
			}

			isShowDelayHide = false;
			StopAllCoroutines ();
			
			gameObject.SetActive(true);
		}


		public void Hide()
		{
			isShowDelayHide = false;
			if (gameObject.activeSelf) 
			{
				StopAllCoroutines ();
				gameObject.SetActive (false);
			}
		}

		public bool isShowDelayHide;
		public void ShowDelayHide(SkillOperateSelectUnitIconType iconType, bool isEnemy, int level, float delay, float time)
		{
			Show (iconType, isEnemy, level);
			isShowDelayHide = true;

			icon.color = icon.color.SetAlhpa (0);
			StartCoroutine (DelayShow(delay, time));
		}

		IEnumerator DelayShow(float delay, float time)
		{
			yield return new WaitForSeconds (delay);
			icon.color = icon.color.SetAlhpa (1);
			StartCoroutine (DelayHide(time));
		}

		IEnumerator DelayHide(float time)
		{
			yield return new WaitForSeconds (time);
			Hide ();
		}

		public void CancelShow()
		{
			StopAllCoroutines ();
			if (isShowDelayHide) 
			{
				Hide ();
			}
		}
	}
}