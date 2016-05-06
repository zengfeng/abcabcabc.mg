using UnityEngine;
using System.Collections;
using System;

public class CloudControl : MonoBehaviour {

	public Transform leftLayer;
	public Transform rightLayer;
	private Animator _animator;
	private Action<CloudControl> _cloudCloseAction;

	void Awake ()
	{
		_animator = GetComponent<Animator> ();
		SetActive(false);
	}
	
	void Update () {
	
	}

	public void PlayCloudClose(Action<CloudControl> callback)
	{
		_cloudCloseAction = callback;
		_animator.SetInteger("State", 1);
	}

	public void PlayCloudOpen()
	{
		_animator.SetInteger("State", 2);
	}

	public void OnCloudClose()
	{
		if (_cloudCloseAction != null)
			_cloudCloseAction.Invoke(this);

		_cloudCloseAction = null;
	}

	public void SetActive(bool active)
	{
		leftLayer.gameObject.SetActive(active);
		rightLayer.gameObject.SetActive(active);
	}
}
