using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using CC.Runtime.Utils;
using CC.UI;


namespace Games.Enters
{
	public class ServerVO
	{
		public enum StateType
		{
			Close,
			Open,
			New
		}

		public static string[] StateNames = new string[]{"关闭", "开启", "新服"};

		public int id;
		public string name;
		public string ip;
		public StateType state;
		public string stateName
		{
			get
			{
				return StateNames[(int)state];
			}
		}

		public override string ToString ()
		{
			return string.Format ("[ServerVO: id={0}, name={1}, ip={2}, state={3} stateName={4}]",id, name, ip, stateName, stateName);
		}
	}

	public class ServerListPanel : MonoBehaviour 
	{
		public Action OnSelect;
		public RectTransform container;
		public GameObject itemPrefab;
		public List<ServerVO> voList = new List<ServerVO>();
		public TabGroup group;

		void Awake () 
		{
			if(container == null) container = transform.FindChild("ListPanel").FindChild("Panel").GetComponent<RectTransform>();
			if(itemPrefab == null) itemPrefab = container.FindChild("Item").gameObject;
			if(group == null) group = container.GetComponentInChildren<TabGroup>();
			itemPrefab.SetActive(false);

		}


		void OnEnable()
		{
			StartCoroutine(SetList());
		}

		IEnumerator SetList()
		{
			string url = PathUtil.DataUrl + GameConst.Platform_ServerFileName;
			
			WWW www = new WWW(url); 
			yield return www;
			if (!string.IsNullOrEmpty(www.error)) 
			{
				yield break;
			}

			for(int i = 1; i < container.childCount; i ++)
			{
				DestroyImmediate(container.GetChild(i).gameObject);
			}

			string[] lines = www.text.Split('\n');
			foreach(string line in lines)
			{
				if(string.IsNullOrEmpty(line))
					continue;

				string[] csv = line.Split(';');

				ServerVO vo = new ServerVO();
				vo.id = csv.GetInt32(0);
				vo.name = csv.GetString(1);
				vo.ip = csv.GetString(2);
				vo.state = (ServerVO.StateType)csv.GetInt32(3);
				voList.Add(vo);
			}


			for(int i = voList.Count - 1; i >= 0; i --)
			{
				GameObject go = GameObject.Instantiate(itemPrefab);
				ServerItem item = go.GetComponent<ServerItem>();
				item.vo = voList[i];

				go.GetComponent<TabButton>().group = group;

				go.transform.SetParent(container);
				go.SetActive(true);

				if(GameConst.ServerID <= 0)
				{
					if(i == voList.Count - 1)
					{
						group.select = go.GetComponent<TabButton>();
					}
				}
				else if(GameConst.ServerID == item.vo.id)
				{
					group.select = go.GetComponent<TabButton>();
				}
			}

			container.sizeDelta = new Vector2(container.sizeDelta.x, (50 + 5) * voList.Count);

		}


		public void OnClickEnter()
		{
			if(group.select == null) return;
			ServerVO vo = group.select.GetComponent<ServerItem>().vo;
			Debug.Log(vo);

			GameConst.ServerID = vo.id;
			

			if(OnSelect != null) OnSelect();
		}
	}
}