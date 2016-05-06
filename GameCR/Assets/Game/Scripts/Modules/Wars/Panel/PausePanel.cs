using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Games.Module.Wars
{
	public class PausePanel : MonoBehaviour
	{
		public Toggle musicToggle;
		public Toggle soundEffectToggle;
		public Toggle snapToggle;

		void Start () 
		{

			Set();

			musicToggle.onValueChanged.AddListener(OnMusicToggleChange);
			soundEffectToggle.onValueChanged.AddListener(OnSoundEffectToggleChange);
			snapToggle.onValueChanged.AddListener(OnSnapToggleChange);
		}


		public void Set()
		{
			musicToggle.isOn = Setting.MusicSwitch;
			soundEffectToggle.isOn = Setting.SoundEffectSwitch;
			snapToggle.isOn = Setting.SkillSnapSwitch;
		}

		public void OnMusicToggleChange(bool isOn)
		{
			Setting.MusicSwitch = isOn;
			Setting.Change();
		}
		
		public void OnSoundEffectToggleChange(bool isOn)
		{
			Setting.SoundEffectSwitch = isOn;
			Setting.Change();
		}


		public void OnSnapToggleChange(bool isOn)
		{
			Setting.SkillSnapSwitch = isOn;
			Setting.Change();

			War.config.skillSnap = isOn;
		}


		public void Show()
		{
			gameObject.SetActive(true);
		}
		
		
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void OnClickExit()
		{
			if(War.requireSynch)
			{
				War.service.C_BattleLeave_0x813();
				Hide();
			}
			else
			{
				War.Exit(true);
			}
		}

		public void OnClickPlay()
		{
			Hide();
			if(!War.isPlaying) War.Play();
		}

		public void OnClickPause()
		{
//			War.Pause();
			Show();
		}

	}
}