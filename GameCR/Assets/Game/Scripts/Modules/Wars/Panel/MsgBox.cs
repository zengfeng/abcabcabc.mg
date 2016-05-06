using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Games.Module.Wars
{
	
	public enum MsgPosType
	{
		Top,
		Middle,
	}

	public class MsgBox : MonoBehaviour 
	{

		public Transform parent_Top;
		public Transform parent_Middle;


		public GameObject prefab_Text;
		public GameObject prefab_KillHero;
		public GameObject prefab_LegionUplevel;
		public float gap = -100f;
		public int count = 0;
		public int index = 0;
		public int index_top 		= 0;
		public int index_middle 	= 0;

		
		public int count_top 		= 0;
		public int count_middle 	= 0;

		public List<MsgItem> list_middle = new List<MsgItem>();
	
		void Awake()
		{
			War.msgBox = this;
			gameObject.SetActive(false);
		}
		
		
		public void Show_Text(string msg)
		{
			GameObject go = GameObject.Instantiate(prefab_Text);
			Text text = go.GetComponent<Text>();
			text.text = msg;
			Show(go, MsgPosType.Top);
		}

		public void Show_KillHero(LegionData legionData, HeroData heroData)
		{
			GameObject go = GameObject.Instantiate(prefab_KillHero);
			MsgItem_KillHero item = go.GetComponent<MsgItem_KillHero>();
			item.Set(legionData, heroData);
			Show(go, MsgPosType.Top);
		}

		public void Show_LegionUplevel(int level)
		{
			if(War.sceneData.visiableLegionLevelMsg == false)
			{
				return;
			}

			GameObject go = GameObject.Instantiate(prefab_LegionUplevel);
			MsgItem_LegionUplevel item = go.GetComponent<MsgItem_LegionUplevel>();
			item.Set(level);
			Show(go, MsgPosType.Middle);
		}
	

		public void Show(GameObject go, MsgPosType msgPosType)
		{
			
			MsgItem item  = go.GetComponent<MsgItem>();
			item.msgBox = this;
			item.msgPosType = msgPosType;

			switch(msgPosType)
			{
			case MsgPosType.Top:
				ShowTop(item);
				break;
				
			case MsgPosType.Middle:
				ShowMiddle(item);
				break;
			}
			
			go.SetActive(true);
			if(!gameObject.activeSelf) gameObject.SetActive(true);
			count ++;

		}

		void ShowTop(MsgItem item)
		{
			float y = index_top * gap;
			item.transform.SetParent(parent_Top);
			item.transform.localPosition = new Vector3(0f, y , 0f);
			item.index = index_top++;
			count_top ++;
		}
		
		void ShowMiddle(MsgItem item)
		{
			for(int i = 0; i < list_middle.Count; i++)
			{
				list_middle[i].transform.DOLocalMoveY(list_middle[i].transform.localPosition.y - gap, 0.1f);
			}

			float y = 0;
			item.transform.SetParent(parent_Middle);
			item.transform.localPosition = new Vector3(0f, y , 0f);
			item.index = index_middle++;
			count_middle ++;

			list_middle.Add(item);
		}

		public void OnClose(MsgItem msgItem)
		{
			switch(msgItem.msgPosType)
			{
			case MsgPosType.Top:
				count_top --;
				if(count_top <= 0)
				{
					count_top = 0;
					index_top = 0;
				}
				break;

			case MsgPosType.Middle:
				count_middle --;
				if(count_middle <= 0)
				{
					count_middle = 0;
					index_middle = 0;
				}
				
				msgItem.transform.DOKill();
				if(list_middle.Contains(msgItem))
				{
					list_middle.Remove(msgItem);
				}
				break;
			}

			count --;
			if(count <= 0)
			{
				count = 0;
				index = 0;
				gameObject.SetActive(false);
			}
		}


	}
}