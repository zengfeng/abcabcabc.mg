using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	public class DarkScreenVisbleLayer : MonoBehaviour 
	{
		public RenderLayer renderLayer;
		public RenderLayer.Layer normalLayer = RenderLayer.Layer.Default;
		public RenderLayer.Layer showLayer = RenderLayer.Layer.War_HeroSkill;
		public bool onlyHide = true;
		void Awake () 
		{
			if(renderLayer == null)
			{
				renderLayer = GetComponent<RenderLayer>();
			}

		}

		public void Set(bool visible)
		{
			if(onlyHide && visible) return;
			if(renderLayer != null)
			{
				renderLayer.sortingLayer = visible ? showLayer : normalLayer;
				renderLayer.Set();
			}
		}

		void OnEnable()
		{
			
			Set(War.darkScreenVisible);
			SignalFactory.GetInstance<WarDarkScreenVisible>().AddListener(Set);
		}

		void OnDisable()
		{
			SignalFactory.GetInstance<WarDarkScreenVisible>().RemoveListener(Set);
		}



	}
}