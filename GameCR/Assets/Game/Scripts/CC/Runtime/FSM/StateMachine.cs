using UnityEngine;
using System.Collections;


namespace CC.Runtime.FSMs
{
	public class StateMachine<T>
	{
		/** 拥有这个实例的智能体 */
		private T _Owner;
		/** 当前状态 */
		private State<T> _CurrentState;
		/** 智能体处于上一个状态的记录 */
		private State<T> _PreviousState;
		/** 每次FSM被更新时，这个状态逻辑被调用 */
		private State<T> _GlobalState;
		
		//----------------------------------------------------------------------
		/** 拥有这个实例的智能体 */
		public T Ower { get{return _Owner;}  }
		/** 当前状态 */
		public State<T> CurrentState { get{return _CurrentState;} }
		/** 智能体处于上一个状态的记录 */
		public State<T> PreviousState { get{return _PreviousState;} }
		/** 每次FSM被更新时，这个状态逻辑被调用 */
		public State<T> GlobalState { get{return _GlobalState;} }

		//----------------------------------------------------------------------
		public StateMachine(T owner)
		{
			_Owner = owner;
		}
		
		public StateMachine(T owner, State<T> currentState)
		{
			_Owner = owner;
			_CurrentState = currentState;
			if(_CurrentState != null) _CurrentState.Enter(owner);
		}

		public StateMachine(T owner, State<T> currentState, State<T> previousState, State<T> globalState)
		{
			_Owner = owner;
			_CurrentState = currentState;
			_PreviousState = previousState;
			_GlobalState = globalState;
			if(_CurrentState != null) _CurrentState.Enter(owner);
			if(_GlobalState != null) _GlobalState.Enter(owner);

		}
		
		//----------------------------------------------------------------------
		public void Update () 
		{
			if(_CurrentState != null) _CurrentState.Execute(_Owner);
			if(_GlobalState != null) _GlobalState.Execute(_Owner);
		}

	
		
		//----------------------------------------------------------------------
		/** 改变状态 */
		public void ChangeState(State<T> state)
		{
			_PreviousState = _CurrentState;
			if(_CurrentState != null) _CurrentState.Exit(_Owner);
			_CurrentState = state;
			_CurrentState.Enter(_Owner);
		}
		
		/** 返回上一个状态 */
		public void RevertToPreviousState()
		{
			ChangeState(_PreviousState);
		}

		/** 当前状态是否和指定的状态是同一类型 */
		public bool IsInState(State<T> state)
		{
			if(_CurrentState == state) return true;
			if(_CurrentState == null || state == null) return false;
			return _CurrentState.GetType() == state.GetType();
		}
		
		//----------------------------------------------------------------------
		/** 设置当前状态 */
		public void SetCurrentState(State<T> state)
		{
			_CurrentState = state;
		}

		/** 设置之前状态 */
		public void SetPreviousState(State<T> state)
		{
			_PreviousState = state;
		}

		/** 设置全局状态 */
		public void SetGlobalState(State<T> state)
		{
			_GlobalState = state;
		}
	}
}
