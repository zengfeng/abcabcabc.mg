using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActiveButton : MonoBehaviour
{
	public int uid = 0;
	public Button activeButton;
	public Button unactiveButton;
	public ActiveGroup group;

	void Awake()
	{
		if (activeButton != null) 
		{
			activeButton.onClick.AddListener (OnClickButton);
		}
		if (unactiveButton != null) 
		{
			unactiveButton.onClick.AddListener (OnClickButton);
		}
		if (group != null)
		{
			group.AddActiveButton(this);
		}
	}

	protected void OnClickButton ()
	{
		if (group != null)
		{
			group.Select = this;
		}
	}

	public void OnUnActive()
	{
		if (activeButton != null) 
		{
			activeButton.gameObject.SetActive(false);
		}
		if (unactiveButton != null) 
		{
			unactiveButton.gameObject.SetActive(true);
		}
	}

	public void OnActive()
	{
		if (activeButton != null) 
		{
			activeButton.gameObject.SetActive(true);
		}
		if (unactiveButton != null) 
		{
			unactiveButton.gameObject.SetActive(false);
		}
	}
}
