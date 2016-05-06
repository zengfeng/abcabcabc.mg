 using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Games.Enters
{
	public class LoadBar : MonoBehaviour 
	{
		public Text 	stateText;
		public Slider 	totalSlider;
		public Text 	totalText;
		
		public Slider 	fileSlider;
		public Text 	fileText;

		public bool showFileBar = true;
		private bool _showFileBar = true;

		public float fileProgress;
		public float totalProgress;

		
		public string State
		{
			set
			{
				if(stateText != null) stateText.text = value;
			}
		}

		public string File
		{
			set
			{
				if(fileText != null) fileText.text = value;
			}
		}


		void Awake () 
		{
			stateText = transform.FindChild("StateText").GetComponent<Text>();
			totalSlider = transform.FindChild("TotalBar").GetComponent<Slider>();
			totalText = totalSlider.transform.FindChild("Text").GetComponent<Text>();

			fileSlider = transform.FindChild("FileBar").GetComponent<Slider>();
			fileText = transform.FindChild("FileText").GetComponent<Text>();
		}


		void Update ()
		{
			if(_showFileBar != showFileBar)
			{
				_showFileBar = showFileBar;
				if(fileSlider != null) fileSlider.gameObject.SetActive(showFileBar);
			}


			if(fileProgress < fileSlider.value)
			{
				fileSlider.value = fileProgress;
			}
			else if(fileProgress != fileSlider.value)
			{
				fileSlider.value = Mathf.Lerp(fileSlider.value, fileProgress, Time.deltaTime * 10F);
			}


			if(totalProgress < totalSlider.value)
			{
				totalSlider.value =  totalProgress;
			}
			else if(totalProgress != totalSlider.value)
			{
				totalSlider.value = Mathf.Lerp(totalSlider.value, totalProgress, Time.deltaTime * 10F);
			}

			totalText.text = Mathf.RoundToInt(totalSlider.value * 100)+ "%";

		}

		public void SetInfo(string state, bool showFileBar, float totalProgress, string file)
		{
			this.State = state;
			this.showFileBar = showFileBar;
			this.totalProgress = totalProgress;
			this.File = file;
		}

		public void SetProgress(float totalProgress, string file)
		{
			this.totalProgress = totalProgress;
			this.File = file;
		}
	}
}