using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.conf;
using System.Collections.Generic;
using Games.Module.Wars;
using UnityEngine.UI;
using Games.Module.Avatars;
using Games.Cores;
using DG.Tweening;

namespace Games.Manager
{
    public enum heroTalkType
    {
        tpSendSoldier = 1, // 出兵触发
        tpHited           = 2, // 被打触发 
        tpCapture       = 3, // 俘虏触发
        tpDead            = 4,//阵亡触发
        tpActice           = 5 //上阵触发
    }
    //英雄对话信息
    public class heroTalkInfo
    {
        public string id;
        public int count; //出现对话次数
    }
    public class PlotTalkManager : MonoBehaviour
    {
        private static PlotTalkManager m_instance;
        public static PlotTalkManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject go = GameObject.Find("PlotTalkManager");
                    if (go == null) go = new GameObject("PlotTalkManager");

                    m_instance = go.GetComponent<PlotTalkManager>();
                    if (m_instance == null) m_instance = go.AddComponent<PlotTalkManager>();
                    GameObject.DontDestroyOnLoad(go);
                }
                return m_instance;
            }
        }
        public Dictionary<int, PlotWarStartConf> plotWarStartConfDic = new Dictionary<int, PlotWarStartConf>();

        public void AddPlotWarStartConf(PlotWarStartConf plotWarStartConf)
        {
            plotWarStartConfDic.Add(plotWarStartConf.id, plotWarStartConf);
        }

        public PlotWarStartConf GetPlotWarStartConf(int stageId, int plotId)
        {
            int id = stageId * 1000 + plotId;
            PlotWarStartConf plotWarStartConf;
            if (plotWarStartConfDic.TryGetValue(id, out plotWarStartConf))
            {
                return plotWarStartConf;
            }
            return null;
        }
        public Dictionary<string, PlotWarHeroConf> plotWarHeroConfDic = new Dictionary<string, PlotWarHeroConf>();
        public void AddPlotWarHeroConf(PlotWarHeroConf plotWarHeroConf)
        {
            plotWarHeroConfDic.Add(plotWarHeroConf.id, plotWarHeroConf);
        }

        public PlotWarHeroConf GetPlotWarHeroConf(int stageId, int monsterId, heroTalkType triggerType)
        {
            string id = string.Format("{0}_{1}_{2}", stageId, monsterId, (int)triggerType); 
            PlotWarHeroConf plotWarHeroConf;
            if (plotWarHeroConfDic.TryGetValue(id, out plotWarHeroConf))
            {
                return plotWarHeroConf;
            }
            return null;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        int m_stageId = 0;
        int m_plotId = 0;
        PlotWarStartConf m_plotConf = null;
        AvatarConfig aratarConf;
        GameObject m_plotPannel;
        Image m_imgHeroFull;
        Image m_nameBg;
        Text m_textContent;
        bool isTipsJumping;
        //对话框
       public Dictionary<string, heroTalkInfo> heroTalkInfoDic = new Dictionary<string, heroTalkInfo>();
        void initPlot()
        {
            m_stageId = 0;
            m_plotId = 0;
            m_plotConf = null;
            aratarConf = null;
            if(m_plotPannel != null)
            {
                Destroy(m_plotPannel);
            }
            m_imgHeroFull = null;
            m_nameBg = null;
            m_textContent = null;
            if(War.isPlaying == false)
            {
                War.Play();
            }
            isTipsJumping = false;
        }
        public AvatarConfig GetAvatarConf(int avatarId)
        {
            AvatarConfig avatarConfig = null;
            avatarConfig = Goo.avatar.GetConfig(avatarId);

            if (avatarConfig == null)
            {
                avatarConfig = Goo.avatar.GetConfig(20001);
            }

            return avatarConfig;
            
        }

        #region 剧情对话
        public void ShowTalk(int stageId)
        {
            Debug.Log("=====ShowTalk====");
            //int isPlayed = PlayerPrefs.GetInt("plot_" + stageId);
            //if (isPlayed == 1)
            //{
            //    return;
            //}
            m_stageId = stageId;
            string filename = "UI/Plot/PlotTalkPannel";
            Coo.assetManager.Load(filename.ToLower(), OnLoadPanel);
        }

        void OnLoadPanel(string filename, System.Object obj)
        {
            GameObject prefab = (GameObject)obj;
            m_plotPannel = GameObject.Instantiate<GameObject>(prefab);

            m_plotPannel.SetActive(false);
            m_plotPannel.transform.SetParent(GameObject.Find("Canvas").transform);
            m_plotPannel.transform.localScale = Vector3.one;
            m_plotPannel.transform.localPosition = new Vector3(0, 0, -100);
            RectTransform rectTransform = (RectTransform)m_plotPannel.transform;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            Button btnClick = m_plotPannel.GetComponent<Button>();
            btnClick.onClick.AddListener(delegate()
            {
                this.OnBtnClick(m_plotPannel);
            });

            playTalkStart();
        }
        void playTalkStart()
        {
            m_plotId ++;
            //Debug.Log("=============m_plotId: " + m_plotId);
            
            m_plotConf = GetPlotWarStartConf(m_stageId, m_plotId);
            if (m_plotConf == null)
            {
                Debug.LogFormat("<color=green>cant find plotconf {0} {1}</color>", m_stageId, m_plotId);
                //PlayerPrefs.SetInt("plot_" + m_stageId, 1);
                initPlot();
                return;
            }

            aratarConf = GetAvatarConf(m_plotConf.avatarId);
            if(aratarConf == null)
            {
                Debug.LogFormat("<color=green>cant find aratarConf {0} {1}</color>", m_stageId, m_plotId);
                //PlayerPrefs.SetInt("plot_" + m_stageId, 1);
                initPlot();
                return;
            }
            War.Pause();
            aratarConf.LoadFull(LoadFullDone);   
        }
        void LoadFullDone(string name, object obj)
        {
            m_plotPannel.SetActive(true);
            Image imgHero_0 = m_plotPannel.transform.FindChild("imgBg/imgHero_0").GetComponent<Image>();
            Image imgHero_1 = m_plotPannel.transform.FindChild("imgBg/imgHero_1").GetComponent<Image>();
            m_textContent = m_plotPannel.transform.FindChild("imgBg/imgTalkBg/textTalk").GetComponent<Text>();
            Image nameBgLeft = m_plotPannel.transform.FindChild("imgBg/imgNameLeftBg").GetComponent<Image>();
            Image nameBgRight = m_plotPannel.transform.FindChild("imgBg/imgNameRightBg").GetComponent<Image>();
            Image imgTip = m_plotPannel.transform.FindChild("imgBg/imgTalkBg/imgTip").GetComponent<Image>();
            //Vector3 targetPos = new Vector3(imgTip.rectTransform.position.x, imgTip.rectTransform.position.y, imgTip.rectTransform.position.z + 20);
            //iTween.Stop(imgTip.gameObject);
            Vector3[] pathJump = new Vector3[3];
            if (isTipsJumping == false)
            {
                pathJump[0] = imgTip.rectTransform.position;
                pathJump[1] = new Vector3(imgTip.rectTransform.position.x, imgTip.rectTransform.position.y + 0.2f, imgTip.rectTransform.position.z);
                pathJump[2] = imgTip.rectTransform.position;
                Hashtable args = new Hashtable();
                args.Add("path", pathJump);
                args.Add("easeType", iTween.EaseType.linear);
                args.Add("speed", 1.0f);
                args.Add("loopType", "loop");	
                iTween.MoveTo(imgTip.gameObject, args);
                isTipsJumping = true;
            }

            //Sequence seq = imgTip.rectTransform.DOJump(targetPos, 0.5f, 1, 1f);
            //seq.SetLoops(400, LoopType.Restart);
           // Sequence mySeq = DOTween.Sequence(); 
            //Tweener myTweenUp = imgTip.rectTransform.DOMoveY(1.0f, 1);
            //Tweener myTweenDown = imgTip.rectTransform.DOMoveY(-1.0f, 1);
            //mySeq.Append(myTweenUp);
           // mySeq.Append(myTweenDown);
            //mySeq.SetLoops(400, LoopType.Restart);

            if(m_plotConf.postion == 0)//左面
            {
                nameBgLeft.gameObject.SetActive(true);
                nameBgRight.gameObject.SetActive(false);
                imgHero_0.gameObject.SetActive(true);
                imgHero_1.gameObject.SetActive(false);
                m_imgHeroFull = imgHero_0;
                m_nameBg = nameBgLeft;
                m_textContent.alignment = TextAnchor.MiddleLeft;
            }
            else //右面
            {
                nameBgLeft.gameObject.SetActive(false);
                nameBgRight.gameObject.SetActive(true);
                imgHero_0.gameObject.SetActive(false);
                imgHero_1.gameObject.SetActive(true);
                m_imgHeroFull = imgHero_1;
                m_nameBg = nameBgRight;
                m_textContent.alignment = TextAnchor.MiddleRight;
            }
            //名字
            Text textName = m_nameBg.transform.FindChild("textName").GetComponent<Text>();
            textName.text = m_plotConf.name;
            //英雄图片
            Sprite sp = obj as Sprite;
            m_imgHeroFull.sprite = sp;
           //图片位置
            //Debug.LogFormat("===rectTransform========={0} {1}==", sp.pivot.x / sp.rect.size.x, sp.pivot.y / sp.rect.size.y);
            //m_imgHeroFull.rectTransform.pivot = new Vector2(sp.pivot.x / sp.rect.size.x, sp.pivot.y / sp.rect.size.y);
            m_imgHeroFull.rectTransform.pivot = aratarConf.talkPivot;
            m_imgHeroFull.SetNativeSize();
            Debug.LogFormat("========pivot: {0} {1}", m_nameBg.rectTransform.anchoredPosition.x, m_nameBg.rectTransform.position.y);
            m_imgHeroFull.rectTransform.anchoredPosition = m_nameBg.rectTransform.anchoredPosition;
            //开始显示文字
            m_textContent.text = m_plotConf.content;
            
        }
        public void OnBtnClick(GameObject sender)
        {
            //Debug.LogFormat("====OnClick=====");
            playTalkStart();
        }

        IEnumerator startShowTalk()
        {
            int idx = 1;
            Debug.LogFormat("====content:{0}", m_plotConf.content);
            while (true)
            {
                if (idx > m_plotConf.content.Length)
                {
                    break;
                }
                m_textContent.text = m_plotConf.content.Substring(0, idx);
                idx++;
                yield return new WaitForSeconds(0.1f);
            }
        }
        #endregion

        #region 战中人物对话
        public void showTalkTips(int stageId, int monsterId, heroTalkType type, Transform headTransform)
        {
            Debug.LogFormat("=======stageId:{0} {1} {2}", stageId, monsterId, (int)type);
            PlotWarHeroConf plotWarHeroConf = GetPlotWarHeroConf(stageId, monsterId, type);
            if (plotWarHeroConf == null)
            {
                //Debug.LogFormat("cant find plotWarHeroConf");
                return;
            }
            int randIdx = Random.Range(1, 100);
            if (randIdx > plotWarHeroConf.triggerRate)
            {
                //Debug.LogFormat("rate: {0} {1}", randIdx, plotWarHeroConf.triggerRate);
                return;
            }
            string curHeroTalkKey = string.Format("{0}_{1}_{2}", stageId, monsterId, (int)type);
            heroTalkInfo talkInfo;
            if (heroTalkInfoDic.TryGetValue(curHeroTalkKey, out talkInfo))
            {
                talkInfo.count++;
            }
            else
            {
                talkInfo = new heroTalkInfo();
                talkInfo.id = curHeroTalkKey;
                talkInfo.count = 0;
                heroTalkInfoDic.Add(curHeroTalkKey, talkInfo);
            }
            GameObject heroTalkItem = headTransform.FindChild("Content/heroTalkItem").gameObject;
            heroTalkItem.SetActive(true);
            Image imgBg = headTransform.FindChild("Content/heroTalkItem/imgBg").GetComponent<Image>();
            if (headTransform.localPosition.x > 1000)
            {
                RectTransform rectTransform = (RectTransform)heroTalkItem.transform;
                imgBg.rectTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                rectTransform.anchoredPosition = new Vector3(-90, 70, 0);
            }
            Debug.LogFormat("====count: {0}", talkInfo.count);
            if(talkInfo.count > plotWarHeroConf.count && plotWarHeroConf.count != 0)
            {
                return;
            }
            if(plotWarHeroConf.contentArray.Length <= 0)
            {
                return;
            }
            int idxContent = talkInfo.count % plotWarHeroConf.contentArray.Length;
            Text textContent = headTransform.FindChild("Content/heroTalkItem/textTalk").GetComponent<Text>();
            textContent.text = plotWarHeroConf.contentArray[idxContent];
            StartCoroutine(TipsDone(heroTalkItem));
        }
        IEnumerator TipsDone(GameObject heroTalkItem)
        {
            yield return new WaitForSeconds(1.5f);
            heroTalkItem.SetActive(false);
        }
        public void cleanTipsInfo()
        {
            heroTalkInfoDic.Clear();
        }
        #endregion
    }
}
