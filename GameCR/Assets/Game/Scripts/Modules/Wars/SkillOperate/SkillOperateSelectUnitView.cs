using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class SkillOperateSelectUnitView : MonoBehaviour
	{
		public SpriteRenderer icon;
		public Color enemyColor = Color.red;
		public Color findlyColor = Color.green;
		public bool isEnemy;
		private bool _isEnemy;
		void Start () 
		{
			if(icon == null) icon = transform.FindChild("Icon").GetComponent<SpriteRenderer>();
			icon.color = _isEnemy ? enemyColor : findlyColor;
		}

		void Update ()
		{
			if(_isEnemy != isEnemy)
			{
				_isEnemy = isEnemy;
				icon.color = _isEnemy ? enemyColor : findlyColor;
			}
		}

		public void SetColor(bool isEnemy)
		{
			this.isEnemy = isEnemy;
		}
	}
}