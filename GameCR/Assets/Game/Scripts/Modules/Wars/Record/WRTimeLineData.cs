using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ProtoBuf;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	[Serializable]
	[ProtoContract]
	public class WRTimeLineData 
	{
		private List<WRAction> _queue = new List<WRAction> ();
		[ProtoMember(1)]
		public List<WRAction> queue { get { return _queue; }	 set{ _queue = value; }}


		private WarEnterData _enterData;
		[ProtoMember(2)]
		public WarEnterData enterData { get{ return _enterData;}  set{ _enterData = value;}}

		private WarOverData _overData;
		[ProtoMember(3)]
		public WarOverData overData { get{ return _overData;}  set{ _overData = value;}}

		public void SortQueue()
		{
			_queue.Sort ((WRAction a, WRAction b) => {return Mathf.RoundToInt( a.t * 100000000 - b.t * 100000000);});
		}

		public string SerializeJSON()
		{
			SortQueue ();

			return JsonConvert.SerializeObject (this, Formatting.Indented);
		}

		public static WRTimeLineData DeserializeJSON(string json)
		{
			Debug.Log (json);
			WRTimeLineData tld = JsonConvert.DeserializeObject (json, typeof(WRTimeLineData)) as WRTimeLineData;


			return tld;
		}




		public void AddAction(WRAction action)
		{

			action.t = War.time;
			queue.Add (action);

			if (action.actionType == WRActionType.Skill)
			{
				action.t -= 0.5f;
				if (action.t < 0)
					action.t = 0f;
			}
//			Debug.LogFormat ("action.t={0} , War.time={1}", action.t, War.time);
		}

		public byte[] GetBytes()
		{
			SortQueue ();

			MemoryStream memStream = new MemoryStream (100);
			memStream.Position = 0;
			Serializer.Serialize(memStream, this);

			byte[] bytes = new byte[(int)memStream.Length];
			memStream.Position = 0;
			memStream.Read (bytes, 0, (int)memStream.Length);
			memStream.Dispose ();

			return bytes;
		}

		public static WRTimeLineData Create(byte[] bytes)
		{
//			StringUtils.PrintBytes("bytes", bytes);
			MemoryStream memStream = new MemoryStream (bytes.Length);
			memStream.Position = 0;
			memStream.Write (bytes, 0, bytes.Length);



			memStream.Position = 0;
			WRTimeLineData timeLineData = Serializer.Deserialize<WRTimeLineData>(memStream);
			memStream.Dispose ();
			return timeLineData;
		}

		public void SaveJSON()
		{
			enterData = War.enterData;
			enterData.skillConfigDict = new Dictionary<int, ISkillConfig> ();
			string str = (string) this.SerializeJSON();


			string filesPath = PathUtil.DataPath + "test_record.json";
			PathUtil.CheckPath(filesPath, true);
			if (File.Exists(filesPath)) File.Delete(filesPath);

			FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);
			sw.Write(str);
			sw.Close(); fs.Close();
			Debug.Log("[WRTimeLineData] SaveJSON " + filesPath);
		}



		public void SaveBytes()
		{
			enterData = War.enterData;

			string filesPath = PathUtil.DataPath + "test_record.bin";
			PathUtil.CheckPath(filesPath, true);
			if (File.Exists(filesPath)) File.Delete(filesPath);

			SortQueue ();
			using (var file = File.Create(filesPath))
			{
				Serializer.Serialize(file, this);
			}
			Debug.Log("[WRTimeLineData] SaveBytes " + filesPath);
		}


		public static IEnumerator OnUseJson(int watchRoleId)
		{
			yield return new WaitForEndOfFrame ();



			string url = PathUtil.DataUrl + "test_record.json";
			WWW www = new WWW(url);
			yield return www;

			if(string.IsNullOrEmpty(www.error))
			{
				Debug.Log(url);
				WRTimeLineData timeLineData =  WRTimeLineData.DeserializeJSON (www.text);
				War.Start(timeLineData, watchRoleId);
			}
			else
			{
				Debug.Log(string.Format("<color=red>[WRTimeLineData] test_record.json失败 url={0} error={1}  text={2}</color>", url, www.error, www.text));
			}

			www.Dispose();
			www = null;
		}

		public static IEnumerator OnUseBinary(int watchRoleId)
		{
			yield return new WaitForEndOfFrame ();

			string filesPath = PathUtil.DataPath + "test_record.bin";

			using (var file = File.OpenRead(filesPath))
			{
				WRTimeLineData timeLineData = Serializer.Deserialize<WRTimeLineData>(file);

				War.Start(timeLineData, watchRoleId);
			}
		}
	}
}
