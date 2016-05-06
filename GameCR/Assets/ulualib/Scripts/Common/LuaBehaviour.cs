using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using CC.UI;

namespace SimpleFramework {
    public class LuaBehaviour : BehaviourBase {
        private string data = null;
        private List<LuaFunction> buttons = new List<LuaFunction>();
        private List<LuaFunction> frameEndFunc = new List<LuaFunction>();
        protected static bool initialize = true;

		virtual protected void Awake() 
		{
            CallMethod("Awake", gameObject);
        }

		virtual protected void Start() 
		{
            if (LuaManager != null && initialize) {
                LuaState l = LuaManager.lua;
                l[name + ".transform"] = transform;
                l[name + ".gameObject"] = gameObject;

				if(transform is RectTransform)
				{
					l[transform.name + ".rectTransform"] = transform as RectTransform;
				}
            }
            CallMethod("Start");
        }

		protected void OnClick() {
            CallMethod("OnClick");
        }

		protected void OnClickEvent(GameObject go) {
            CallMethod("OnClick", go);
        }

        /// <summary>
        /// 添加单击事件
        /// </summary>
		public void AddClick(GameObject go, LuaFunction luafunc) {
            if (go == null) return;
            buttons.Add(luafunc);

			if(go.GetComponent<Button>() != null)
			{
	            go.GetComponent<Button>().onClick.AddListener(
	                delegate() {
	                    luafunc.Call(go);
	                }
	            );
			}
			else
			{
				go.GetComponent<TabButton>().onClick.AddListener(
					delegate(TabButton tab) {
					luafunc.Call(tab);
				}
				);
			}
		}

		/// <summary>
		/// 添加单击事件
		/// </summary>
		public void AddClick(string button, LuaFunction luafunc) {
			// Transform to = transform.Find(button);
			// if (to == null) return;
			GameObject go = GameObject.Find(button);
			if(go == null) return;
			buttons.Add(luafunc);


			if(go.GetComponent<Button>() != null)
			{
				go.GetComponent<Button>().onClick.AddListener(
					delegate() {
					luafunc.Call(go);
				}
				);
			}
			else
			{
				go.GetComponent<TabButton>().onClick.AddListener(
					delegate(TabButton tab) {
					luafunc.Call(tab);
				}
				);
			}

		}

        /// <summary>
        /// 清除单击事件
        /// </summary>
        public void ClearClick() {
            for (int i = 0; i < buttons.Count; i++) {
                if (buttons[i] != null) {
                    buttons[i].Dispose();
                    buttons[i] = null;
                }
            }
        }

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        protected object[] CallMethod(string func, params object[] args) {
            if (!initialize) return null;
            return Util.CallMethod(name, func, args);
        }

        //-----------------------------------------------------------------
		virtual protected void OnDestroy() {
            ClearClick();
            LuaManager = null;
            Util.ClearMemory();
            Debug.Log("~" + name + " was destroy!");
        }

        /// <summary>
        /// 增加在帧结束时回调函数
        /// </summary>
        public void AddFrameEndCall(LuaFunction func){
            frameEndFunc.Add(func);
            StartCoroutine(OnFrameEnd());
        }

        IEnumerator OnFrameEnd(){
            yield return new WaitForEndOfFrame();

            foreach (var func in frameEndFunc)
            {
                func.Call();
            }
            frameEndFunc.Clear();
        }
    }
}