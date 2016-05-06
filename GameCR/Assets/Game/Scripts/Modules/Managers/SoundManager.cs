using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using CC.Runtime;

namespace Games.Module.Sound
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager m_instance;
        public static SoundManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject go = GameObject.Find("SoundManager");
                    if (go == null) go = new GameObject("SoundManager");

                    m_instance = go.GetComponent<SoundManager>();
                    if (m_instance == null) m_instance = go.AddComponent<SoundManager>();
                    GameObject.DontDestroyOnLoad(go);
                }
                return m_instance;
            }
        }

        public void Awake()
        {
            
        }
        

        void OnEnable()
        {
            Setting.sOnChange += OnSettingChange;
        }

        void OnDisable()
        {
           Setting.sOnChange -= OnSettingChange;
        }

        //设置面板设置信息改变
        void OnSettingChange()
        {
            Debug.Log("============OnSettingChange============");
            if (Setting.MusicSwitch)
            {
                ChangeMusicBg(mCurMusicName);
            }
            else
            {
                ChangeMusicBg("none");
            }
        }

        class AudioClipInfo
        {
            public string Name;
            AudioClip mClip;
            public AudioClipInfo(string name, AudioClip clip)
            {
                Name = name;
                mClip = clip;
            }

            public AudioClip Clip
            {
                //get { return mClip ?? (mClip = Resources.Load(Name) as AudioClip); }
				get { return mClip ?? (mClip = Resources.Load("Resources/sound/" + Name, typeof(AudioClip)) as AudioClip); }

                set { mClip = value; }
            }
        }

        //List<AudioClipInfo> mRuntimeClips = new List<AudioClipInfo>();
        Dictionary<string, AudioClipInfo> mClipInfoMap = new Dictionary<string, AudioClipInfo>();
        AudioSource mAudioSource;//音效
        AudioSource mAudioBg;//背景音乐
        public string mCurMusicName = "";
        List<string> mMusicToPlayNameList = new List<string>();
        bool isDealMusic = false;//是否真正处理背景音乐
        public AudioSource CurrentAudioSource
        {
            get
            {
                if (mAudioSource == null)
                {
                    //mAudioSource = GameObject.FindObjectOfType(typeof(AudioSource)) as AudioSource;
                    mAudioSource = gameObject.AddComponent<AudioSource>();
                }

                return mAudioSource;
            }
            set { mAudioSource = value; }
        }
        public AudioSource CurrentAudioSourceBg
        {
            get
            {
                if (mAudioBg == null)
                {
                    mAudioBg = gameObject.AddComponent<AudioSource>();
                }

                return mAudioBg;
            }
            set { mAudioBg = value; }
        }

        public void Init() { }

        private AudioClipInfo GetSoundClip(string soundName)
        {
            if (string.IsNullOrEmpty(soundName)) return null;

            AudioClipInfo retClip = null;
            if (mClipInfoMap.TryGetValue(soundName, out retClip))
            {
                return retClip;
            }

            string soundPath = "sound/" + soundName;
            //AudioClip audioClip = AssetDatabase.LoadAssetAtPath(soundPath, typeof(AudioClip)) as AudioClip;
            AudioClip audioClip = Resources.Load(soundPath) as AudioClip;
            if (audioClip != null)
            {
                AudioClipInfo clipInfo = new AudioClipInfo(soundName, audioClip);
                mClipInfoMap.Add(soundName, clipInfo);

                //Debug.Log(string.Format("<color=green>GetSoundIndex t load sound={0} </color>", soundName));
                return clipInfo;
            }

            Debug.Log("Fail to found sound: " + soundPath);
            return retClip;
        }

        //清除声音
        public void UnloadRuntimeClips()
        {
            mClipInfoMap.Clear();     
            mAudioSource = null;
            mAudioBg = null;
            mCurMusicName = "";
        }

        //播放音效
        public void PlaySound(string clipname)
        {
            if (!Setting.SoundEffectSwitch)
            {
                return;
            }
            AudioClipInfo clipInfo = GetSoundClip(clipname);
            if (clipInfo == null)
            {
                Debug.Log(string.Format("<color=red>PlaySound err cant load sound={0}</color>", clipname));
                return;
            }
            AudioClip clip = clipInfo.Clip;
            if(clip == null)
            {
                Debug.LogError("PlaySound err sound: " + clipname);
                return;
            }
            //Debug.Log(string.Format("<color=green>PlaySound t load sound={0} </color>", clipname));
            CurrentAudioSource.PlayOneShot(clip, Setting.Volume);
        }

        //背景音乐
        public void PlayMusicBg(string clipname)
        {
			mCurMusicName = clipname;
            if (!Setting.MusicSwitch)
            {
                Debug.LogFormat("========PlayMusicBg close========");
                ChangeMusicBg("none");
                return;
            }
            AudioClipInfo clipInfo = GetSoundClip(clipname);
            if (clipInfo == null)
            {
                //Debug.Log(string.Format("<color=red>PlaySound err cant load sound={0}</color>", clipname));
                return;
            }
            AudioClip clip = clipInfo.Clip;
            if (clip == null)
            {
                //Debug.LogError("PlaySound err sound: " + clipname );
                return;

            }
            //CurrentAudioSourceBg.Stop();
            //Debug.Log(string.Format("<color=green>PlaySound t load sound={0}</color>", clipname));
            CurrentAudioSourceBg.clip = clip;
            CurrentAudioSourceBg.loop = true;
            CurrentAudioSourceBg.volume = Setting.Volume;
            CurrentAudioSourceBg.Play();
        }

        public void ChangeMusicBg(string musicName)
        {
            if (string.IsNullOrEmpty(musicName)) return;
            //Debug.Log("======ChangeMusicBg=======" + musicName);
            mMusicToPlayNameList.Add(musicName);
            if(isDealMusic == false)
            {
                isDealMusic = true;
                string musicNameNew = mMusicToPlayNameList[0];
                mMusicToPlayNameList.RemoveAt(0);
                StartCoroutine(changeSound(musicNameNew));
            }
         }

        IEnumerator changeSound(string musicName)
        {
            while(true)
            {
                CurrentAudioSourceBg.volume -= 0.1f;
                yield return new WaitForSeconds(0.1f);
                if(CurrentAudioSourceBg.volume <= 0)
                {
                    break;
                }
            }
           // Debug.Log("============changeSound:============"+ musicName);
            CurrentAudioSourceBg.Stop();
            if (musicName != "none")
            {
                PlayMusicBg(musicName);
            }
            int idx = mMusicToPlayNameList.Count;
            if (idx > 0)
            {
                string musicNameNew = mMusicToPlayNameList[idx - 1];
                mMusicToPlayNameList.Clear();
                StartCoroutine(changeSound(musicNameNew));
            }
            else
            {
                isDealMusic = false;
            }
         }
    }
}