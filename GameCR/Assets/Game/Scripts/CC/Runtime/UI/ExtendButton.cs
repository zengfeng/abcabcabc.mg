using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LuaInterface;

public class ExtendButton : Button, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler {

	public enum TouchCallbackType
	{
		Down,
		Up,
        nomal
	}

	public Animator animator;
	public bool autoPlayAnimator;

	private LuaFunction _touchCallback;
    TouchCallbackType type;
	public LuaFunction touchCallback
	{
		get
		{
			return _touchCallback;
		}
		set
		{
			_touchCallback = value;
		}
	}

	// Use this for initialization
	void Start () {
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
       
        type = TouchCallbackType.nomal;
        if (autoPlayAnimator)
        {
            PlayAnimatorUp();
        }
    }

    void IPointerDownHandler.OnPointerDown (PointerEventData eventData)
	{
        type = TouchCallbackType.Down;
        if (autoPlayAnimator)
        {
            PlayAnimatorDown();
        }
        if (touchCallback != null)
		{
			touchCallback.Call(TouchCallbackType.Down.ToString());
		}

	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
        if(type != TouchCallbackType.Down)
        {
            return;
        }
        if (autoPlayAnimator)
        {
            PlayAnimatorUp();
        }
        if (touchCallback != null)
		{
			//touchCallback.Call(TouchCallbackType.Up.ToString());
			StartCoroutine (upCall());		
		}

	}

	IEnumerator upCall()
	{
		yield return new WaitForSeconds(0.1f);
		touchCallback.Call(TouchCallbackType.Up.ToString());
	}

	public void PlayAnimatorDown()
	{
		if (animator != null)
		{
			animator.SetBool("Down", true);
			animator.SetBool("Up", false);
		}
	}

	public void PlayAnimatorUp()
	{
		if (animator != null)
		{
			animator.SetBool("Down", false);
			animator.SetBool("Up", true);
		}
	}
}
