using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

public class Win_T2_Defend_View : MonoBehaviour 
{
	public Text descriptionText;
	public Text timeText;

	public int time;

	private int _time;
	void Start () 
	{
		if(timeText == null) timeText = transform.FindChild("Time").GetComponent<Text>();
		SetTime();
	}

	void Update () 
	{
		if(_time != time)
		{
			SetTime();
		}
	}

	void SetTime()
	{
		_time = time;
		timeText.text = TimeUtil.ToMMSS(time);
	}


}
