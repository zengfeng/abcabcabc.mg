using UnityEngine;
using System.Collections;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class WarManager : MonoBehaviour
	{
		public GameObject eventSystem;
		public GameObject canvas;
		public Canvas warCanvas;
		public Camera warUICamera;
		public WarProcessState processState;

		void Awake()
		{
			Init();
		}

		public void Init()
		{
			War.manager = this;
			War.pvp = GetComponent<WarPVP>();
			War.pveExpedition = GetComponent<WarPVEExpedition>();
			War.scene = GetComponent<WarScene>();
			War.map = GetComponent<WarMap>();
			War.preload = GetComponent<WarPreload>();
			War.sceneCreate = GetComponent<WarSceneCreate>();
			War.factory = GetComponent<WarFactory>();
			War.starManager = GetComponent<StarManager>();
			War.winManager = GetComponent<WinManager>();
			
			
			War.skillWarManager = GameObject.Find("SkillManager").GetComponent<SkillWarManager>();
			War.skillUse = GameObject.Find("SkillManager").GetComponent<SkillUse>();
			War.skillCreater = GameObject.Find("SkillManager").GetComponent<SkillCreater>();
			if(GameObject.Find("PathManager") != null) War.pathManager =  GameObject.Find("PathManager").GetComponent<PathManagerComponent>();
		}


		void OnDestroy()
		{
			War.Instance.Destory();

			
			War.signal.sGenerateDataComplete -= OnGenerateDataComplete;
			War.signal.sPreloadComplete -= BeginCreate;
			War.signal.sBuildComplete -= OnBuildComplete;
		}

		
		void Start () 
		{

			War.signal.sPreloadComplete += BeginCreate;
			War.signal.sBuildComplete += OnBuildComplete;


			
			if(War.isTest || War.processState != WarProcessState.Loading)
			{
				
				War.signal.sGenerateDataComplete += OnGenerateDataComplete;
			}
			else
			{
//				StartCoroutine(BegionPreload());
				BeginCreate();
			}
		}



		void OnGenerateDataComplete()
		{
			StartCoroutine(BegionPreload());
		}

		
		public IEnumerator BegionPreload()
		{
			yield return new WaitForEndOfFrame();
			War.preload.Load();
		}

		public void BeginCreate()
		{
			War.processState = WarProcessState.Installing;
			War.sceneCreate.Generation();
		}

		public void OnBuildComplete()
		{


			War.scene.GenerationBuildDistance();
			if(!War.requireSynch)
			{
				War.processState = WarProcessState.Gameing;
				War.signal.GameBegin ();
			}
			
			eventSystem.SetActive(War.isTest);
			canvas.SetActive(War.isTest);
			if(War.isTest)
			{
				warUICamera.gameObject.SetActive(true);
				warUICamera.gameObject.AddComponent<AudioListener>();
			}
			else
			{
				warUICamera.gameObject.SetActive(false);
				warCanvas.worldCamera = Coo.uiCamera;
			}

			if(War.isEditor == false)
			{
	            Coo.soundManager.ChangeMusicBg("music_btl");
//	            Coo.plotTalkManager.ShowTalk(War.enterData.stageId);
			}
		}

		public void OnReadyPVP()
		{

			StartCoroutine(OnReadyPVPFrame());
		}

		
		IEnumerator OnReadyPVPFrame()
		{
			
			yield return new WaitForSeconds(0.5f);
			War.processState = WarProcessState.Gameing;
			War.signal.GameBegin ();
			yield return new WaitForSeconds(1);
			Coo.loadManager.CloseSceneLoader();

		}

		void Update()
		{
			processState = War.processState;
		}
	}
}
