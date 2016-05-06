
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Internal;
using LuaInterface;

namespace CC.Runtime.Utils
{
	public class CallUtil 
	{
		#region Instance
		static CallUtil instance = null;
		static readonly object padlock = new object();
		public static CallUtil Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new CallUtil();
						}
					}
				}
				return instance;
			}
		}
		#endregion

		CallMB callMB;
		CallUtil ()
		{
			GameObject gameObject = GameObject.Find("CallUtil");
			if(gameObject == null)
			{
				gameObject = new GameObject();
				gameObject.name = "CallUtil";
			}
			
			callMB = gameObject.AddComponent<CallMB>();
		}

		public void LuaAddFrameOnce( LuaFunction callback)
		{
			AddFrameOnce(callback.Callback);
		}
		
		public void LuaRemoveFrameOnce( LuaFunction callback)
		{
			RemoveFrameOnce(callback.Callback);
		}

		public void LuaAddUpdate(LuaFunction callback)
		{
			AddUpdate(callback.Callback);
		}
		
		public void LuaRemoveUpdate(LuaFunction callback)
		{
			RemoveUpdate(callback.Callback);
		}
		
		/**
	     * FrameOnce
		 */
		public void AddFrameOnce(Action action)
		{
			callMB.AddFrameOnce(action);
		}
		
		public void RemoveFrameOnce(Action action)
		{
			callMB.RemoveFrameOnce(action);
		}

		
		/**
	     * LastUpdate
		 */
		public void AddLastUpdate(Action action)
		{
			callMB.AddLateUpdate(action);
		}

		public void RemoveLastUpdate(Action action)
		{
			callMB.RemoveLateUpdate(action);
		}

		
		/**
	     * FixedUpdate
		 */
		
		public void AddFixedUpdate(Action action)
		{
			callMB.AddFixedUpdate(action);
		}
		
		public void RemoveFixedUpdate(Action action)
		{
			callMB.RemoveFixedUpdate(action);
		}

		/**
	     * Update
		 */
		public void AddUpdate(Action action)
		{
			callMB.AddUpdate(action);
		}
		
		public void RemoveUpdate(Action action)
		{
			callMB.RemoveUpdate(action);
		}
		
		/**
	     * Second
		 */
		public void AddSecond(Action action)
		{
			callMB.AddSecond(action);
		}
		
		public void RemoveSecond(Action action)
		{
			callMB.RemoveSecond(action);
		}
		/**
	     * SetTimeOut,ClearTimeOut
		 */
		public int SetTimeOut(Action<object[]> action, float time, [DefaultValue ("null")] object[] args = null)
		{
			return callMB.SetTimeOut(action, time, args);
		}

		public void ClearTimeOut(int uid)
		{
			callMB.ClearTimeOut(uid);
		}
		
		/**
	     * SetInterval,ClearInterval
		 */
		public int SetInterval(Action<object[]> action, float time, [DefaultValue ("null")] object[] args = null)
		{
			return callMB.SetInterval(action, time, args);
		}
		
		public void ClearInterval(int uid)
		{
			callMB.ClearInterval(uid);
		}

		/**
	     * StartCoroutine
		 */
		public void StartCoroutine(IEnumerator routine)
		{
			callMB.StartCoroutine(routine);
		}

	}


	public class CallMB : MonoBehaviour
	{
		/**
		 * FrameOnce
		 */
		Dictionary<Action, int> frameOnceActionValues = new Dictionary<Action, int>();
		List<Action> frameOnceActions = new List<Action>();
		internal void AddFrameOnce(Action callback)
		{
			int val = -1;
			if(!frameOnceActionValues.TryGetValue(callback, out val))
			{
				frameOnceActionValues.Add(callback, 1);
			}

			if(val == 0)
			{
				frameOnceActionValues[callback] = 1;
			}
		}

		internal void RemoveFrameOnce(Action callback)
		{
			int val = -1;
			if(frameOnceActionValues.TryGetValue(callback, out val))
			{
				frameOnceActionValues[callback] = 0;
			}
		}

		/**
		 * LateUpdateListener
		 */
		public event Action LateUpdateListener = delegate { };
		public void AddLateUpdate(Action callback) 
		{
			foreach (Delegate del in LateUpdateListener.GetInvocationList())
			{
				Action action = (Action)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			LateUpdateListener += callback;
		}

		public void RemoveLateUpdate(Action callback) 
		{ 
			LateUpdateListener -= callback; 
		}

		/**
		 * UpdateListener
		 */
		public event Action UpdateListener = delegate { };
		public void AddUpdate(Action callback) 
		{
			foreach (Delegate del in UpdateListener.GetInvocationList())
			{
				Action action = (Action)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			UpdateListener += callback;
		}
		
		public void RemoveUpdate(Action callback) 
		{ 
			UpdateListener -= callback; 
		}

		/**
		 * FixedUpdateListener
		 */
		public event Action FixedUpdateListener = delegate { };
		public void AddFixedUpdate(Action callback) 
		{
			foreach (Delegate del in FixedUpdateListener.GetInvocationList())
			{
				Action action = (Action)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			FixedUpdateListener += callback;
		}
		
		public void RemoveFixedUpdate(Action callback) 
		{ 
			FixedUpdateListener -= callback; 
		}

		
		/**
		 * SecondListener
		 */
		public event Action SecondListener = delegate { };
		public void AddSecond(Action callback) 
		{
			foreach (Delegate del in SecondListener.GetInvocationList())
			{
				Action action = (Action)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			SecondListener += callback;
		}
		
		public void RemoveSecond(Action callback) 
		{ 
			SecondListener -= callback; 
		}

		//=====================================================
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
		}


		/**
		 * LateUpdate
		 */
		void LateUpdate()
		{
			if(frameOnceActionValues.Count > 0)
			{

				frameOnceActions.Clear();
				foreach(KeyValuePair<Action, int> kvp in frameOnceActionValues)
				{
					frameOnceActions.Add(kvp.Key);
				}
				

				foreach(Action action in frameOnceActions)
				{
					int val = -1;
					if(frameOnceActionValues.TryGetValue(action, out val))
					{
						frameOnceActionValues.Remove(action);
						if(val == 1)
						{
							action();
						}
					}
				}
				
				//frameOnceActionValues.Clear();
			}

			LateUpdateListener();
		}
		
		/**
		 * Update
		 */
		void Update()
		{
			UpdateListener();
		}

		
		
		/**
		 * FixedUpdate
		 */
		void FixedUpdate()
		{
			FixedUpdateListener();
		}

		void OnEnable()
		{
			StartCoroutine("OnSecond", 1F);
		}
		
		void OnDisable()
		{
			//StopAllCoroutines();
			StopCoroutine("OnSecond");
		}
		
		/**
		 * OnSecond
		 */
		IEnumerator OnSecond(float time) {
			while (true) {
				yield return new WaitForSeconds(time);
				SecondListener();
			}
		}
		
		/**
		 * TimeOut
		 */
		class TimeParam
		{
			public Action<object[]> action;
			public float time;
			public object[] args;
			int uid;
			public int UID
			{
				get
				{
					return uid;
				}
			}
			
			internal bool isBreak;

			static int index = 10000;
			public TimeParam(Action<object[]> action, float time, [DefaultValue ("null")] object[] args)
			{
				this.action = action;
				this.time = time;
				this.args = args;
				uid = index++;
			}
		}

		Dictionary<int, TimeParam> timeDict = new Dictionary<int, TimeParam>();
		
		/**
		 * SetTimeOut, ClearTimeOut
		 */
		public int SetTimeOut(Action<object[]> action, float time, [DefaultValue ("null")] object[] args)
		{
			TimeParam param = new TimeParam(action, time, args);
			timeDict.Add(param.UID, param);
			StartCoroutine(OnTimeOut(param));
			return param.UID;
		}

		public void ClearTimeOut(int uid)
		{
			TimeParam param;
			if(timeDict.TryGetValue(uid, out param))
			{
				param.isBreak = true;
			}
		}

		IEnumerator OnTimeOut(TimeParam param) {
			yield return new WaitForSeconds(param.time);
			if(!param.isBreak)
			{
				param.action(param.args);
			}

			timeDict.Remove(param.UID);
		}
		
		/**
		 * setInterval, ClearTimeOut
		 */
		public int SetInterval(Action<object[]> action, float time, [DefaultValue ("null")] object[] args)
		{
			TimeParam param = new TimeParam(action, time, args);
			timeDict.Add(param.UID, param);
			StartCoroutine(OnInterval(param));
			return param.UID;
		}
		
		public void ClearInterval(int uid)
		{
			TimeParam param;
			if(timeDict.TryGetValue(uid, out param))
			{
				param.isBreak = true;
			}
		}

		IEnumerator OnInterval(TimeParam param) {
			while(!param.isBreak)
			{
				yield return new WaitForSeconds(param.time);
				if(!param.isBreak)
				{
					param.action(param.args);
				}
			}
			timeDict.Remove(param.UID);
		}
		
		/**
		 * OnApplicationPause
		 */
		void OnApplicationPause(bool pauseStatus)
		{
			if(pauseStatus == false)
			{
				Timeleft.Correct();
			}
		}


	}


	public class Timeleft
	{
		bool runInBackground;
		int second;
		int secondBegin;
		long beginTicks;
		static List<Timeleft> cacheList = new List<Timeleft>();
		
		internal static void Correct()
		{
			Timeleft[] list = cacheList.ToArray();
			long ticks = DateTime.Now.Ticks;
			int second;
			foreach(Timeleft timeleft in list)
			{
				if(timeleft.second > 0)
				{
					second = timeleft.secondBegin - (int)((ticks - timeleft.beginTicks) / 10000000);
					if(second < 0) second = 0;
					timeleft.setSecond(second);
				}
			}
		}

		public Timeleft(bool runInBackground = true)
		{
			this.runInBackground = runInBackground;
		}

		void onSecond()
		{
			second --;
			setSecond(second);
		}

		void setSecond(int time)
		{
			second = time;
			if(second <= 0)
			{
				CallUtil.Instance.RemoveSecond(onSecond);
				if(runInBackground) cacheList.Remove(this);
			}
			SendUpdate();
		}

		
		public void SetTimeleft(int second)
		{
			beginTicks = DateTime.Now.Ticks;
			secondBegin = second;
			setSecond(second);
			if(second > 0)
			{
				CallUtil.Instance.AddSecond(onSecond);
				if(runInBackground) cacheList.Add(this);
			}
		}
		
		public int Second
		{
			get
			{
				return second;
			}
		}

		public string ToHHMMSS()
		{
	        return DateTimeUtils.ConvertIntDatetime(second).ToString("HH:mm:ss");
			//return TimeUtil.ToHHMMSS(second);
		}
		
		public string ToHHMM()
		{
	        return DateTimeUtils.ConvertIntDatetime(second).ToString("HH:mm");
			//return TimeUtil.ToHHMM(second);
		}
		
		public string ToMMSS()
		{
	        return DateTimeUtils.ConvertIntDatetime(second).ToString("mm:ss");
			//return TimeUtil.ToMMSS(second);
		}
		
		public string ToDDHHMMSS()
		{
	        return DateTimeUtils.ConvertIntDatetime(second).ToString("dd:HH:mm:ss");
			//return TimeUtil.ToDDHHMMSS(second);
		}

		/**
		 * UpdateListener
		 */
		event Action<int> UpdateListener = delegate { };
		public void AddUpdate(Action<int> callback) 
		{
			foreach (Delegate del in UpdateListener.GetInvocationList())
			{
				Action<int> action = (Action<int>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			UpdateListener += callback;
		}
		
		public void RemoveUpdate(Action<int> callback) 
		{ 
			UpdateListener -= callback; 
		}

		void SendUpdate()
		{
			UpdateListener(second);
			UpdateListenerObj(this);
		}

		
		/**
		 * UpdateListener
		 */
		event Action<Timeleft> UpdateListenerObj = delegate { };
		public void AddUpdate(Action<Timeleft> callback) 
		{
			foreach (Delegate del in UpdateListenerObj.GetInvocationList())
			{
				Action<Timeleft> action = (Action<Timeleft>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			UpdateListenerObj += callback;
		}
		
		public void RemoveUpdate(Action<Timeleft> callback) 
		{ 
			UpdateListenerObj -= callback; 
		}

	}

}
