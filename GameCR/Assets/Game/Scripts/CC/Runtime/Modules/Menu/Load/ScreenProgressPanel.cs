using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CC.Module.Loads
{
	public class ScreenProgressPanel : ProgressPanel
	{
		
		
		public SceneLoader sceneLoader;

		public Text 	stateText;
		public Slider 	totalSlider;
		public Text 	totalText;
		
		public Slider 	fileSlider;
		public Text 	fileText;
		
		public bool showFileBar = false;
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
			stateText = transform.FindChild("Bar/StateText").GetComponent<Text>();
			totalSlider = transform.FindChild("Bar/TotalBar").GetComponent<Slider>();
			totalText = totalSlider.transform.FindChild("Text").GetComponent<Text>();
			
			fileSlider = transform.FindChild("Bar/FileBar").GetComponent<Slider>();
			fileText = transform.FindChild("Bar/FileText").GetComponent<Text>();

			if(sceneLoader == null)
			{
				sceneLoader = GetComponent<SceneLoader>();
			}

			if(sceneLoader != null)
			{
				sceneLoader.sSetState += SetState;
				sceneLoader.sSetProgress += SetProgress;
			}
		}

		void OnDestroy()
		{
			if(sceneLoader != null)
			{
				sceneLoader.sSetState -= SetState;
				sceneLoader.sSetProgress -= SetProgress;
			}
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

			if(totalProgress < totalSlider.value)
			{
				totalSlider.value =  totalProgress;
			}

			this.totalProgress = totalProgress;
			this.File = file;
		}

		override public void SetProgress(float progress, int index, int count, string file)
		{
			if(count == -1)
			{
				SetProgress(progress, file);
				return;
			}
			this.totalProgress = progress;
			this.State = string.Format(state, index, count) ;
			this.File = file;
		}

		override public void SetState(string state)
		{
			this.state = state;
			this.State = state;
		}
	}
}
