/*
 * Copyright 2013 ThirdMotion, Inc.
 *
 *	Licensed under the Apache License, Version 2.0 (the "License");
 *	you may not use this file except in compliance with the License.
 *	You may obtain a copy of the License at
 *
 *		http://www.apache.org/licenses/LICENSE-2.0
 *
 *		Unless required by applicable law or agreed to in writing, software
 *		distributed under the License is distributed on an "AS IS" BASIS,
 *		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *		See the License for the specific language governing permissions and
 *		limitations under the License.
 */

/**
 * @class strange.extensions.signal.impl.Signal
 * 
 * This is actually a series of classes defining the Base concrete form for all Signals.
 * 
 * Signals are a type-safe approach to communication that essentially replace the
 * standard EventDispatcher model. Signals can be injected/mapped just like any other
 * object -- as Singletons, as instances, or as values. Signals can even be mapped
 * across Contexts to provide an effective and type-safe way of communicating
 * between the parts of your application.
 * 
 * Signals in Strange use the Action Class as the underlying mechanism for type safety.
 * Unity's C# implementation currently allows up to FOUR parameters in an Action, therefore
 * SIGNALS ARE LIMITED TO FOUR PARAMETERS. If you require more than four, consider
 * creating a value object to hold additional values.
 * 
 * Examples:

		//BASIC SIGNAL CREATION/DISPATCH
		//Create a new signal
		Signal signalWithNoParameters = new Signal();
		//Add a listener
		signalWithNoParameters.AddListener(callbackWithNoParameters);
		//This would throw a compile-time error
		signalWithNoParameters.AddListener(callbackWithOneParameter);
		//Dispatch
		signalWithNoParameters.Dispatch();
		//Remove the listener
		signalWithNoParameters.RemoveListener(callbackWithNoParameters);

		//SIGNAL WITH PARAMETERS
		//Create a new signal with two parameters
 		Signal<int, string> signal = new Signal<int, string>();
 		//Add a listener
		signal.AddListener(callbackWithParamsIntAndString);
		//Add a listener for the duration of precisely one Dispatch
		signal.AddOnce(anotherCallbackWithParamsIntAndString);
		//These all throw compile-time errors
		signal.AddListener(callbackWithParamsStringAndInt);
		signal.AddListener(callbackWithOneParameter);
		signal.AddListener(callbackWithNoParameters);
		//Dispatch
		signal.Dispatch(42, "zaphod");
		//Remove the first listener. The listener added by AddOnce has been automatically removed.
		signal.RemoveListener(callbackWithParamsIntAndString);
 * 
 * @see strange.extensions.signal.api.IBaseSignal
 * @see strange.extensions.signal.impl.BasrSignal
 */

using System;
using System.Collections.Generic;

namespace CC.Runtime.signals
{

//	public class HSignal
//	{
//		public virtual void AddListener(Action callback) { }
//		public virtual void AddOnce(Action callback) { }
//		public virtual void RemoveListener(Action callback) { }
//		public virtual void Dispatch() {}
//	}

	
	public class HSignal : IHSignal
	{
		/**
		 * Once
		 */
		Dictionary<Action, int> onceActionValues = new Dictionary<Action, int>();
		List<Action> onceActions = new List<Action>();
		public virtual void AddOnce(Action callback)
		{
			int val = -1;
			if(!onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues.Add(callback, 1);
			}
			
			if(val == 0)
			{
				onceActionValues[callback] = 1;
			}
		}
		
		public virtual void RemoveOnce(Action callback)
		{
			int val = -1;
			if(onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues[callback] = 0;
			}
		}

		void ExecuteOnce()
		{
			if(onceActionValues.Count > 0)
			{
				
				foreach(KeyValuePair<Action, int> kvp in onceActionValues)
				{
					if(kvp.Value == 1)
					{
						onceActions.Add(kvp.Key);
					}
				}
				
				foreach(Action action in onceActions)
				{
					int val = -1;
					if(onceActionValues.TryGetValue(action, out val))
					{
						onceActionValues.Remove(action);
						if(val == 1)
						{
							action();
						}
					}
				}
				
				onceActionValues.Clear();
			}
		}


		
		/**
		 * Listener
		 */
		public event Action Listener = delegate { };
		public void AddListener(Action callback) 
		{
			foreach (Delegate del in Listener.GetInvocationList())
			{
				Action action = (Action)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			Listener += callback;
		}
		
		public void RemoveListener(Action callback) 
		{ 
			Listener -= callback; 
		}

		public virtual void Dispatch()
		{
			Listener();
			ExecuteOnce();
		}
	}

	
	
	//--------------------------------------------
	public class HSignal<T> : IHSignal
	{
		
		/**
		 * Once
		 */
		Dictionary<Action<T>, int> onceActionValues = new Dictionary<Action<T>, int>();
		List<Action<T>> onceActions = new List<Action<T>>();
		public virtual void AddOnce(Action<T> callback)
		{
			int val = -1;
			if(!onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues.Add(callback, 1);
			}
			
			if(val == 0)
			{
				onceActionValues[callback] = 1;
			}
		}
		
		public virtual void RemoveOnce(Action<T> callback)
		{
			int val = -1;
			if(onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues[callback] = 0;
			}
		}
		
		void ExecuteOnce(T t)
		{
			if(onceActionValues.Count > 0)
			{
				
				foreach(KeyValuePair<Action<T>, int> kvp in onceActionValues)
				{
					if(kvp.Value == 1)
					{
						onceActions.Add(kvp.Key);
					}
				}
				
				foreach(Action<T> action in onceActions)
				{
					int val = -1;
					if(onceActionValues.TryGetValue(action, out val))
					{
						onceActionValues.Remove(action);
						if(val == 1)
						{
							action(t);
						}
					}
				}
				
				onceActionValues.Clear();
			}
		}
		
		
		
		/**
		 * Listener
		 */
		public event Action<T> Listener = delegate { };
		public void AddListener(Action<T> callback) 
		{
			foreach (Delegate del in Listener.GetInvocationList())
			{
				Action<T> action = (Action<T>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			Listener += callback;
		}
		
		public void RemoveListener(Action<T> callback) 
		{ 
			Listener -= callback; 
		}
		
		public virtual void Dispatch(T t)
		{
			Listener(t);
			ExecuteOnce(t);
		}
	}
	
	//--------------------------------------------
	public class HSignal<T, U> : IHSignal
	{
		
		/**
		 * Once
		 */
		Dictionary<Action<T, U>, int> onceActionValues = new Dictionary<Action<T, U>, int>();
		List<Action<T, U>> onceActions = new List<Action<T, U>>();
		public virtual void AddOnce(Action<T, U> callback)
		{
			int val = -1;
			if(!onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues.Add(callback, 1);
			}
			
			if(val == 0)
			{
				onceActionValues[callback] = 1;
			}
		}
		
		public virtual void RemoveOnce(Action<T, U> callback)
		{
			int val = -1;
			if(onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues[callback] = 0;
			}
		}
		
		void ExecuteOnce(T t, U u)
		{
			if(onceActionValues.Count > 0)
			{
				
				foreach(KeyValuePair<Action<T, U>, int> kvp in onceActionValues)
				{
					if(kvp.Value == 1)
					{
						onceActions.Add(kvp.Key);
					}
				}
				
				foreach(Action<T, U> action in onceActions)
				{
					int val = -1;
					if(onceActionValues.TryGetValue(action, out val))
					{
						onceActionValues.Remove(action);
						if(val == 1)
						{
							action(t, u);
						}
					}
				}
				
				onceActionValues.Clear();
			}
		}
		
		
		
		/**
		 * Listener
		 */
		public event Action<T, U> Listener = delegate { };
		public void AddListener(Action<T, U> callback) 
		{
			foreach (Delegate del in Listener.GetInvocationList())
			{
				Action<T, U> action = (Action<T, U>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			Listener += callback;
		}
		
		public void RemoveListener(Action<T, U> callback) 
		{ 
			Listener -= callback; 
		}
		
		public virtual void Dispatch(T t, U u)
		{
			Listener(t, u);
			ExecuteOnce(t, u);
		}
	}


	
	//--------------------------------------------
	public class HSignal<T, U, V> : IHSignal
	{
		
		/**
		 * Once
		 */
		Dictionary<Action<T, U, V>, int> onceActionValues = new Dictionary<Action<T, U, V>, int>();
		List<Action<T, U, V>> onceActions = new List<Action<T, U, V>>();
		public virtual void AddOnce(Action<T, U, V> callback)
		{
			int val = -1;
			if(!onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues.Add(callback, 1);
			}
			
			if(val == 0)
			{
				onceActionValues[callback] = 1;
			}
		}
		
		public virtual void RemoveOnce(Action<T, U, V> callback)
		{
			int val = -1;
			if(onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues[callback] = 0;
			}
		}
		
		void ExecuteOnce(T t, U u, V v)
		{
			if(onceActionValues.Count > 0)
			{
				
				foreach(KeyValuePair<Action<T, U, V>, int> kvp in onceActionValues)
				{
					if(kvp.Value == 1)
					{
						onceActions.Add(kvp.Key);
					}
				}
				
				foreach(Action<T, U, V> action in onceActions)
				{
					int val = -1;
					if(onceActionValues.TryGetValue(action, out val))
					{
						onceActionValues.Remove(action);
						if(val == 1)
						{
							action(t, u, v);
						}
					}
				}
				
				onceActionValues.Clear();
			}
		}
		
		
		
		/**
		 * Listener
		 */
		public event Action<T, U, V> Listener = delegate { };
		public void AddListener(Action<T, U, V> callback) 
		{
			foreach (Delegate del in Listener.GetInvocationList())
			{
				Action<T, U, V> action = (Action<T, U, V>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			Listener += callback;
		}
		
		public void RemoveListener(Action<T, U, V> callback) 
		{ 
			Listener -= callback; 
		}
		
		public virtual void Dispatch(T t, U u, V v)
		{
			Listener(t, u, v);
			ExecuteOnce(t, u, v);
		}
	}

	
	//--------------------------------------------
	public class HSignal<T, U, V, W> : IHSignal
	{
		
		/**
		 * Once
		 */
		Dictionary<Action<T, U, V, W>, int> onceActionValues = new Dictionary<Action<T, U, V, W>, int>();
		List<Action<T, U, V, W>> onceActions = new List<Action<T, U, V, W>>();
		public virtual void AddOnce(Action<T, U, V, W> callback)
		{
			int val = -1;
			if(!onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues.Add(callback, 1);
			}
			
			if(val == 0)
			{
				onceActionValues[callback] = 1;
			}
		}
		
		public virtual void RemoveOnce(Action<T, U, V, W> callback)
		{
			int val = -1;
			if(onceActionValues.TryGetValue(callback, out val))
			{
				onceActionValues[callback] = 0;
			}
		}
		
		void ExecuteOnce(T t, U u, V v, W w)
		{
			if(onceActionValues.Count > 0)
			{
				
				foreach(KeyValuePair<Action<T, U, V, W>, int> kvp in onceActionValues)
				{
					if(kvp.Value == 1)
					{
						onceActions.Add(kvp.Key);
					}
				}
				
				foreach(Action<T, U, V, W> action in onceActions)
				{
					int val = -1;
					if(onceActionValues.TryGetValue(action, out val))
					{
						onceActionValues.Remove(action);
						if(val == 1)
						{
							action(t, u, v, w);
						}
					}
				}
				
				onceActionValues.Clear();
			}
		}
		
		
		
		/**
		 * Listener
		 */
		public event Action<T, U, V, W> Listener = delegate { };
		public void AddListener(Action<T, U, V, W> callback) 
		{
			foreach (Delegate del in Listener.GetInvocationList())
			{
				Action<T, U, V, W> action = (Action<T, U, V, W>)del;
				if (callback.Equals(action)) //If this callback exists already, ignore this addlistener
					return;
			}
			
			Listener += callback;
		}
		
		public void RemoveListener(Action<T, U, V, W> callback) 
		{ 
			Listener -= callback; 
		}
		
		public virtual void Dispatch(T t, U u, V v, W w)
		{
			Listener(t, u, v, w);
			ExecuteOnce(t, u, v, w);
		}
	}
	//--------------------------------------------


	/// Base concrete form for a Signal with no parameters
	public class Signal : BaseSignal
	{
		public event Action Listener = delegate { };
		public event Action OnceListener = delegate { };
		public void AddListener(Action callback) { Listener += callback; }
		public void AddOnce(Action callback) { OnceListener += callback; }
		public void RemoveListener(Action callback) { Listener -= callback; }
		public override List<Type> GetTypes()
		{
			return new List<Type>();
		}
		public void Dispatch()
		{
			Listener();
			OnceListener();
			OnceListener = delegate { };
			base.Dispatch(null);
		}
	}

	/// Base concrete form for a Signal with one parameter
	public class Signal<T> : BaseSignal
	{
		public event Action<T> Listener = delegate { };
		public event Action<T> OnceListener = delegate { };
		public void AddListener(Action<T> callback) { Listener += callback; }
		public void AddOnce(Action<T> callback) { OnceListener += callback; }
		public void RemoveListener(Action<T> callback) { Listener -= callback; }
		public override  List<Type> GetTypes() 
		{ 
			List<Type> retv = new List<Type>();
			retv.Add(typeof(T));
			return retv;
		}
		public void Dispatch(T type1)
		{
			Listener(type1);
			OnceListener(type1);
			OnceListener = delegate { };
			object[] outv = { type1 };
			base.Dispatch(outv);
		}
	}

	/// Base concrete form for a Signal with two parameters
	public class Signal<T, U> : BaseSignal
	{
		public event Action<T, U> Listener = delegate { };
		public event Action<T, U> OnceListener = delegate { };
		public void AddListener(Action<T, U> callback) { Listener += callback; }
		public void AddOnce(Action<T, U> callback) { OnceListener += callback; }
		public void RemoveListener(Action<T, U> callback) { Listener -= callback; }
		public override List<Type> GetTypes()
		{
			List<Type> retv = new List<Type>();
			retv.Add(typeof(T));
			retv.Add(typeof(U));
			return retv;
		}
		public void Dispatch(T type1, U type2)
		{
			Listener(type1, type2);
			OnceListener(type1, type2);
			OnceListener = delegate { };
			object[] outv = { type1, type2 };
			base.Dispatch(outv);
		}
	}

	/// Base concrete form for a Signal with three parameters
	public class Signal<T, U, V> : BaseSignal
	{
		public event Action<T, U, V> Listener = delegate { };
		public event Action<T, U, V> OnceListener = delegate { };
		public void AddListener(Action<T, U, V> callback) { Listener += callback; }
		public void AddOnce(Action<T, U, V> callback) { OnceListener += callback; }
		public void RemoveListener(Action<T, U, V> callback) { Listener -= callback; }
		public override List<Type> GetTypes()
		{
			List<Type> retv = new List<Type>();
			retv.Add(typeof(T));
			retv.Add(typeof(U));
			retv.Add(typeof(V));
			return retv;
		}
		public void Dispatch(T type1, U type2, V type3)
		{
			Listener(type1, type2, type3);
			OnceListener(type1, type2, type3);
			OnceListener = delegate { };
			object[] outv = { type1, type2, type3 };
			base.Dispatch(outv);
		}
	}

	/// Base concrete form for a Signal with four parameters
	public class Signal<T, U, V, W> : BaseSignal
	{
		public event Action<T, U, V, W> Listener = delegate { };
		public event Action<T, U, V, W> OnceListener = delegate { };
		public void AddListener(Action<T, U, V, W> callback) { Listener += callback; }
		public void AddOnce(Action<T, U, V, W> callback) { OnceListener += callback; }
		public void RemoveListener(Action<T, U, V, W> callback) { Listener -= callback; }
		public override List<Type> GetTypes()
		{
			List<Type> retv = new List<Type>();
			retv.Add(typeof(T));
			retv.Add(typeof(U));
			retv.Add(typeof(V));
			retv.Add(typeof(W));
			return retv;
		}
		public void Dispatch(T type1, U type2, V type3, W type4)
		{
			Listener(type1, type2, type3, type4);
			OnceListener(type1, type2, type3, type4);
			OnceListener = delegate { };
			object[] outv = { type1, type2, type3, type4 };
			base.Dispatch(outv);
		}
	}

}
