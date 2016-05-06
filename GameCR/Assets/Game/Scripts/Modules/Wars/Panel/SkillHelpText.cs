using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class SkillHelpText : MonoBehaviour
	{
		public static SkillHelpText instance;
		public Text 			text;
		public CanvasGroup 		canvasGroup;

		void Awake()
		{
			if(text == null) 			text 			= GetComponent<Text>();
			if(canvasGroup == null) 	canvasGroup 	= GetComponent<CanvasGroup>();

			instance = this;
			hide();
		}


		
		public static string GetText()
		{
			string str = "";
			if(lastSkill != null)
			{
				switch(lastSkill.skillConfig.operate)
				{
				case SkillOperateType.Immediately:
					str = "拖到战场释放";
					break;
				case SkillOperateType.SelectUnit:
					if(lastSkill.candidateReceiveCount == 0)
					{
						str = "没有可选目标";
					}
					else
					{
						str = "拖到目标建筑释放";
					}
					break;
				case SkillOperateType.SelectCircle:
					str = "拖到战场一个区域释放";
					break;
				case SkillOperateType.SelectDirection:
					str = "拖动一个方向释放";
					break;
				}
			}

			return str;
		}


		private static SkillOperateData lastSkill;
		public static void Show(SkillOperateData skillOperateData)
		{
			lastSkill 	= skillOperateData;
			_candidateReceiveCount = lastSkill.candidateReceiveCount;
			instance.show(GetText());
		}

		public static void Hide(SkillOperateData skillOperateData)
		{
			if(lastSkill == skillOperateData)
			{
				lastSkill = null;
				instance.hide();
			}
		}



		public float showDelayTime = 0.2f;
		public float showTime = 0.2f;
		public float hideTime = 0.2f;
		private float _time = 0;
		private Coroutine corutiner;
		private void show(string str)
		{
			text.text = str;
			if(!gameObject.activeSelf || canvasGroup.alpha != 1)
			{
				gameObject.SetActive(true);

				canvasGroup.alpha = 0;
				_time = 0;
				if(corutiner != null) StopCoroutine(corutiner);
				corutiner = StartCoroutine(DelayShow());
			}
		}

		IEnumerator DelayShow()
		{
			yield return new WaitForSeconds(showDelayTime);
			while(_time < showTime)
			{
				_time += Time.deltaTime;
				canvasGroup.alpha = _time / showTime;

				yield return new WaitForEndOfFrame();
			}
			
			canvasGroup.alpha = 1;
		}
		
		private void hide()
		{
			_time = 0;
			
			if(corutiner != null) StopCoroutine(corutiner);
			corutiner = StartCoroutine(DelayHide());
		}

		IEnumerator DelayHide()
		{
			while(_time < hideTime)
			{
				_time += Time.deltaTime;
				canvasGroup.alpha = 1 - _time / hideTime;
				
				yield return new WaitForEndOfFrame();
			}

			
			gameObject.SetActive(false);
		}

		public static int _candidateReceiveCount;
		void Update()
		{
			if(lastSkill != null)
			{
				if(lastSkill.skillConfig.operate == SkillOperateType.SelectUnit)
				{
					if(_candidateReceiveCount != lastSkill.candidateReceiveCount)
					{
						_candidateReceiveCount = lastSkill.candidateReceiveCount;
						text.text = GetText();
					}
				}
			}
		}



	}
}