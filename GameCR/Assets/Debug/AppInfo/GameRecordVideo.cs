using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

public class GameRecordVideo : MonoBehaviour
{
	public float gap = 0.5f;
	public bool isRecording = false;
	public string path = "../record";
	public int frame = 0;

	private float _time;
	private string _path;
	private Transform sourceParent;
	void Start () 
	{
		_path =  Application.dataPath + "/" + path + "/" + System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss") + "/";

		PathUtil.CheckPath(_path);
		GameObject.DontDestroyOnLoad (gameObject);
	}

	void Update ()
	{
		if (isRecording)
		{
			_time -= Time.deltaTime;
			if (_time <= 0) 
			{
				_time = gap;
				Application.CaptureScreenshot (_path + StringUtils.FillStr(frame ++, 4) + ".png");
			}
		}
	}

	public void Begin()
	{
		sourceParent = transform.parent;
		transform.parent = null;
		frame = 0;
		isRecording = true;
		gameObject.SetActive (true);
	}

	public void Stop()
	{
		isRecording = false;
		gameObject.SetActive (false);

		transform.parent = sourceParent;
	}
}
