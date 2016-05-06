using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Games.Module.Wars
{
	public class HPRelationView : EntityView 
	{
		public HPView hpView;

		public HPView hpOwn;
		public HPView hpFriendly;
		public HPView hpEnemy;
		
		public RelationType relation;
		public bool visible = true;
		private float _value = 0F;
		private float _max = 100F;
		private float _uplevel = 0F;
		private RelationType _relation;
		private bool _visible = true;

		public float Max
		{
			get
			{
				return _max;
			}

			set
			{
				_max = value;
				if(_visible && hpView != null) hpView.max = _max;
			}
		}

		public float Value
		{
			get
			{
				return _value;
			}

			set
			{
				_value = value;
				if(_visible && hpView != null) hpView.value = _value;
			}
		}

		
		
		public float Uplevel
		{
			get
			{
				return _uplevel;
			}
			
			set
			{
				_uplevel = value;
				if(_visible && hpView != null) hpView.uplevel = _uplevel;
			}
		}

		protected override void Awake ()
		{
			base.Awake ();

			hpOwn = transform.FindChild("War_View_HPOwn").GetComponent<HPView>();
			hpFriendly = transform.FindChild("War_View_HPFriendly").GetComponent<HPView>();
			hpEnemy = transform.FindChild("War_View_HPEnemy").GetComponent<HPView>();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(_relation != relation)
			{
				_relation = relation;
				if(hpView != null) hpView.gameObject.SetActive(false);
				switch(_relation)
				{
				case RelationType.Own:
					hpView = hpOwn;
					break;
				case RelationType.Friendly:
					hpView = hpFriendly;
					break;
				default:
					hpView = hpEnemy;
					break;
				}

				if(_visible)
				{
					hpView.max = _max;
					hpView.value = _value;
					hpView.uplevel = _uplevel;
					hpView.gameObject.SetActive(true);
				}
			}

			if(_visible != visible)
			{
				_visible = visible;
				if(hpView != null) 
				{
					hpView.gameObject.SetActive(_visible);
					if(_visible)
					{
						hpView.max = _max;
						hpView.value = _value;
						hpView.uplevel = _uplevel;
					}
				}
			}
		}

		[ContextMenu("Set")]
		public void Set()
		{
			OnUpdate();
		}

		

	}
}