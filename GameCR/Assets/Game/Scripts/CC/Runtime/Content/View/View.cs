using UnityEngine;
using System.Collections;
using System;

namespace CC.Runtime
{
	public class View : MonoBehaviour, IView
    {
        // public field
        // ------------
        public Action sOnShow;
        public Action sOnHide;

        // private field
        // -------------
        private bool isStarted = false;

        
        public float Width
        {
            get
            {
				if(rectTransform != null)
				{
					return rectTransform.rect.width;
				}
				return 0F;
            }
        }
        
        public float Height
        {
            get
            {
				
				if(rectTransform != null)
				{
					return rectTransform.rect.height;
				}
				return 0F;
            }
        }

        public bool IsStarted
        {
            get
            {
                return isStarted;
            }
        }

		protected RectTransform rectTransform;
        // protected method
        // ----------------
		virtual protected void Awake()
        {
			rectTransform = GetComponent<RectTransform>();

			Meditor meditor = GetComponent<Meditor>();
			if(meditor)
				meditor.contextView = this;
        }

        virtual protected void Start()
        {
            isStarted = true;

            if (sOnShow != null)
            {
                sOnShow();
            }
        }

		virtual protected void OnDestroy()
        {
            if (sOnHide != null)
            {
                sOnHide();
            }
        }



        // private method
        // --------------
		virtual protected void OnEnable()
        {
            if (IsStarted)
            {
                if(sOnShow != null)
                {
                    sOnShow();
                }
            }
        }


    }
}

