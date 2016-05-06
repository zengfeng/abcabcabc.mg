using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Actions.UGUI;
using CC.Runtime;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class HeroSkillClipManager : MonoBehaviour 
	{
		public HeroSkillClip prefab;
		public List<HeroSkillClip> leftList;
		public List<HeroSkillClip> rightList;
		
		public int leftCount = 0;
		public int leftIndex = 0;

		
		public int rightCount = 0;
		public int rightIndex = 0;

		void Awake()
		{
		}


		public void OnUse(SkillOperateData operateData)
		{
			if(operateData.relation == RelationType.Enemy)
			{
				Right(operateData);
			}
			else
			{
				Left(operateData);
			}
		}

		void Left(SkillOperateData operateData)
		{
			HeroSkillClip heroSkillClip;
			if(leftIndex < leftList.Count)
			{
				heroSkillClip = leftList[leftIndex];
			}
			else
			{
				GameObject go = GameObject.Instantiate(prefab.gameObject);
				go.transform.SetParent(prefab.transform.parent);
				go.transform.localScale = Vector3.one;
				heroSkillClip = go.GetComponent<HeroSkillClip>();
				leftList.Add(heroSkillClip);
			}

			heroSkillClip.gameObject.name =  "HeroSkillClip-left-" + leftIndex;
			heroSkillClip.heroSkillClipManager = this;
			heroSkillClip.SetData(operateData);
			heroSkillClip.isRight = false;
			heroSkillClip.index = leftIndex;
			heroSkillClip.SetDirection();
			leftIndex ++;
			leftCount ++;
			heroSkillClip.Play();

		}

		void Right(SkillOperateData operateData)
		{
			HeroSkillClip heroSkillClip;
			if(rightIndex < rightList.Count)
			{
				heroSkillClip = rightList[rightIndex];
			}
			else
			{
				GameObject go = GameObject.Instantiate(prefab.gameObject);
				go.transform.SetParent(prefab.transform.parent);
				go.transform.localScale = Vector3.one;
				heroSkillClip = go.GetComponent<HeroSkillClip>();
				rightList.Add(heroSkillClip);
			}
			
			heroSkillClip.gameObject.name =  "HeroSkillClip-right-" + rightIndex;
			heroSkillClip.heroSkillClipManager = this;
			heroSkillClip.SetData(operateData);
			heroSkillClip.isRight = true;
			heroSkillClip.index = rightIndex;
			heroSkillClip.SetDirection();
			rightIndex ++;
			rightCount ++;
			heroSkillClip.Play();
		}

		
		
		public void OnClose(HeroSkillClip item)
		{
			if(item.isRight)
			{
				rightCount --;
				if(rightCount <= 0)
				{
					rightCount = 0;
					rightIndex = 0;
				}
			}
			else
			{
				leftCount --;
				if(rightCount <= 0)
				{
					leftCount = 0;
					leftIndex = 0;
				}
			}
		}


	}
}