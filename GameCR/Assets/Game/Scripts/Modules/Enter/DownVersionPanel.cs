using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownVersionPanel : MonoBehaviour 
{
	public string url;
	public string currentVersion;
	public string nowVersion;

	public Text curentText;
	public Text nowText;
	public Text urlText;

	void Awake () 
	{
		if(curentText == null) curentText = transform.GetChild(0).FindChild("CurrentValue").GetComponent<Text>();
		if(nowText == null) nowText = transform.GetChild(0).FindChild("NowValue").GetComponent<Text>();
		if(urlText == null) urlText = transform.GetChild(0).FindChild("Url").GetComponent<Text>();
	}


	void OnEnable()
	{
		curentText.text = currentVersion;
		nowText.text = nowVersion;
		urlText.text = url;
	}


	public void OnClickDown()
	{
		Application.OpenURL(url);
	}
}
