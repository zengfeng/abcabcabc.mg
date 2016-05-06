using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC.UI;
using CC.Runtime.signals;


namespace Games.Module.Wars
{
	public class PlayPauseButton : MonoBehaviour 
	{
		public TabButton toggle;
		public PausePanel pausePanel;
		void Start () 
		{
			if(toggle == null) toggle = GetComponent<TabButton>();

			if(War.isGameing)
			{
				SetValue(toggle.IsSelect);
			}
			else
			{
				War.signal.sGameBegin += OnWarStarted;
			}
		}

		private bool _isPlayIng = true;
		void Update()
		{
			if(_isPlayIng != War.isPlaying)
			{
				_isPlayIng = War.isPlaying;
				toggle.SetIsSelect(!_isPlayIng, false);
			}
		}
		
		void OnDestroy()
		{
			War.signal.sGameBegin -= OnWarStarted;
		}
		
		void OnWarStarted()
		{
			SetValue(toggle.IsSelect);
		}



		public void OnChange(bool value)
		{
//			SetValue(toggle.IsSelect);
			SetValue(true);
		}

		public void SetValue(bool value)
		{
			if(!War.isGameing) return;
			if(value)
			{
				if (War.isRecord || War.vsmode != VSMode.PVP) {
					War.Pause ();
				}
				pausePanel.OnClickPause();
			}
			else
			{
				if (War.isRecord || War.vsmode != VSMode.PVP) {
					War.Play ();
				}
				pausePanel.OnClickPlay();
			}
		}
	}
}
