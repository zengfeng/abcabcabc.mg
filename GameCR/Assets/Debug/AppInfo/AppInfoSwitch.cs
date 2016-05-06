using UnityEngine;
using System.Collections;

public class AppInfoSwitch : MonoBehaviour {

	public GameObject appInfoPanel;
	void Start () 
	{
		if(appInfoPanel == null) appInfoPanel = GameObject.Find("AppInfoPanel");
		if(appInfoPanel != null) appInfoPanel.SetActive(true);
		DontDestroyOnLoad(transform.parent.gameObject);
	}

	float touchTime = 0;
	float touchVisiableTime = 0;
	void Update () 
	{
		if(Application.isMobilePlatform)
		{
			if(Input.touchCount >= 4 && Time.time >= touchTime )
			{
				touchVisiableTime += Time.deltaTime;
				if(touchVisiableTime >= 1)
				{
					touchTime = Time.time + 1F;
					touchVisiableTime = 0;
					appInfoPanel.SetActive(!appInfoPanel.activeSelf);
					if(appInfoPanel.activeSelf)
					{
						appInfoPanel.GetComponent<RectTransform>().SetAsLastSibling();
					}
				}
			}
			else
			{
				touchVisiableTime = 0;
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.F1))
			{
				appInfoPanel.SetActive(!appInfoPanel.activeSelf);
				if(appInfoPanel.activeSelf)
				{
					appInfoPanel.GetComponent<RectTransform>().SetAsLastSibling();
				}
			}
		}
	}

	public void Show()
	{
		appInfoPanel.SetActive(true);
		appInfoPanel.GetComponent<RectTransform>().SetAsLastSibling();
	}

	public void Hide()
	{
		appInfoPanel.SetActive(false);
	}
}
