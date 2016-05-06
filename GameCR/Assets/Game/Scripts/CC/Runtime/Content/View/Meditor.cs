using UnityEngine;
using System.Collections;


namespace CC.Runtime
{
    public class Meditor : MonoBehaviour, IMeter
    {

        private View _contextView;
        public View contextView
        {
            get
            {
                return _contextView;
            }

            set
            {
                if (_contextView != null)
                {
                    _contextView.sOnShow -= PreRegister;
                    _contextView.sOnShow -= OnRegister;
                    _contextView.sOnHide -= OnRemove;
                }

                _contextView = value;

                if (_contextView != null)
                {
                    _contextView.sOnShow += PreRegister;
                    _contextView.sOnShow += OnRegister;
                    _contextView.sOnHide += OnRemove;
                }
            }
        }


        /**
         * View第一次OnShow时会调用
         */
        virtual public void PreRegister()
        {
            if (_contextView != null)
                _contextView.sOnShow -= PreRegister;

        }

        /**
         * View每次OnShow都会调用
         */
        virtual public void OnRegister()
        {
        }

        /**
         * View每次OnHide都会调用
         */
        virtual public void OnRemove()
        {
        }
    }
}