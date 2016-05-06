using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Generic;

public class AnimatorLua : MonoBehaviour
{

	private Animator _animator;

	public Animator animator {
		get {
			return _animator;
		}
	}
	private LuaFunction _startCallback;
	public LuaFunction startCallback
	{
		get
		{
			return _startCallback;
		}
		set
		{
			_startCallback = value;
		}
	}

	private LuaFunction _endCallback;
	public LuaFunction endCallback
	{
		get
		{
			return _endCallback;
		}
		set
		{
			_endCallback = value;
		}
	}

	private Dictionary<string, LuaFunction> _stateFunction = new Dictionary<string, LuaFunction>();

	void Awake ()
	{
		_animator = GetComponent<Animator> ();
	}
	
	void Update ()
	{
		foreach (string stateName in _stateFunction.Keys)
		{
			if (_animator.IsInTransition(0) && 
			    _animator.GetNextAnimatorStateInfo(0).IsName(stateName)
			    )
			{
				_stateFunction[stateName].Call (this);
			}
		}
	}

	void AddStateCallback (string stateName, LuaFunction func)
	{
		_stateFunction.Add(stateName, func);
	}

	void OnAnimationStart()
	{
		if (_startCallback != null)
		{
			_startCallback.Call (this);
		}
	}

	void OnAnimationEnd()
	{
		if (_endCallback != null)
		{
			_endCallback.Call (this);
		}
	}

	public void PlayByState(int state, LuaFunction endFunc = null)
	{
		endCallback = endFunc;
		_animator.SetInteger("State", state);
	}
}
