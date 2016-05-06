using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime.PB;
using System.IO;
using ProtoBuf;
using System.Collections.Generic;
using CC.Runtime.Utils;
using CC.Runtime;
using System.Net;
using System;
using System.Text;

namespace Games.Cores
{
	public partial class GameSave_Record : GameSavePath 
	{

		private string GetVideoPath(int id)
		{
			return Root_Record + id + ".txt";
		}



		private string InfoPath
		{
			get
			{
				return Root_Record + "info.txt";
			}
		}


		private string KeyPath
		{
			get
			{
				return Root_Record + "key.txt";
			}
		}


		private string GetWatchCountTag(int id)
		{
			return KeyPath + "?tag=watchcount_" + id;
		}

		#region info
		public WarRecordIOInfo LoadInfo()
		{
			WarRecordIOInfo info = null;
			if (ES2.Exists (InfoPath))
			{
				byte[] bytes= ES2.LoadRaw (InfoPath);
				info = WarRecordIOInfo.Create (bytes);

			} 
			else 
			{
				info = new WarRecordIOInfo (); 
			}

			return info;
		}

		public void SaveInfo(WarRecordIOInfo info)
		{
			byte[] bytes = info.GetBytes ();
			ES2.SaveRaw (bytes, InfoPath);

		}
		#endregion


		#region video watch count
		public int LoadWatchCount(int id)
		{
			string tag = GetWatchCountTag (id);
			if(ES2.Exists(tag))
			{
				return ES2.Load<int> (tag);
			}
			return 0;
		}

		public void DeleteWatchCount(int id)
		{
			string tag = GetWatchCountTag (id);
			if(ES2.Exists(tag))
			{
				ES2.Delete (tag);
			}
		}

		public void SetWatchCount(int id, int count)
		{
			string tag = GetWatchCountTag (id);
			ES2.Save<int> (count, tag);
		}
		#endregion


		#region video
		// load file
		public ProtoBattleVideoInfo LoadVideo(int id)
		{
			ProtoBattleVideoInfo item = null;
			string file = GetVideoPath (id);
			if(ES2.Exists(file))
			{
				byte[] bytes= ES2.LoadRaw (file);
				item = CreateVideo (bytes);

				item.view_count = LoadWatchCount(item.uid_local);

			}
			return item;
		}

		// load list
		public List<ProtoBattleVideoInfo> LoadVideoList(List<int> ids)
		{
			List<ProtoBattleVideoInfo> list = new List<ProtoBattleVideoInfo> ();
			foreach(int id in ids)
			{
				ProtoBattleVideoInfo item = LoadVideo (id);
				if (item != null) 
				{
					list.Add (item);
				}
			}

			return list;
		}

		public List<ProtoBattleVideoInfo> LoadVideoList(WarRecordIOInfo info)
		{
			bool hasDelete = false;
			List<ProtoBattleVideoInfo> list = LoadVideoList (info.ids);
			for(int i = 0; i < list.Count; )
			{
				ProtoBattleVideoInfo item = list[i];
				if (War.GetVersionCompatible (item.war_version))
				{
					i++;
				}
				else 
				{
					list.Remove (item);
					DeleteVideoFile (item.uid_local);
					info.ids.Remove (item.uid_local);
					hasDelete = true;
				}

			}

			if (hasDelete)
			{
				SaveInfo (info);
			}

			return list;

		}

		// save
		public void SaveVideo(ProtoBattleVideoInfo video, WarRecordIOInfo info)
		{
			video.uid_local = info.GetNewId();
			info.Add (video.uid_local);

			byte[] bytes = GetVideoBytes (video);
			string file = GetVideoPath (video.uid_local);

			Debug.LogFormat ("video.uid_local = {0}, bytes.Length={1}, file={2}", video.uid_local, bytes.Length, file);


			ES2.SaveRaw (bytes, file);
			SetWatchCount (video.uid_local, 0);

			while(info.Count > info.MaxNum)
			{
				int itemId = info.ids[0];
				DeleteVideoFile (itemId);
				info.ids.Remove (itemId);
			}


			SaveInfo (info);

		}



		// delete
		private void DeleteVideoFile(int id)
		{
			DeleteWatchCount (id);
			ES2.Delete (GetVideoPath(id));
		}

		public void DeleteVide(int id, WarRecordIOInfo info)
		{
			if(info.ids.Contains(id))info.ids.Remove (id);
			DeleteVideoFile (id);
			SaveInfo (info);
		}





		// tool
		private byte[] GetVideoBytes(ProtoBattleVideoInfo video)
		{
			MemoryStream memStream = new MemoryStream (3096);
			memStream.Position = 0;
			Serializer.Serialize(memStream, video);

			byte[] bytes = new byte[(int)memStream.Length];
			memStream.Position = 0;
			memStream.Read (bytes, 0, (int)memStream.Length);
			memStream.Dispose ();

			return bytes;
		}

		private ProtoBattleVideoInfo CreateVideo(byte[] bytes)
		{
			MemoryStream memStream = new MemoryStream (bytes.Length);
			memStream.Position = 0;
			memStream.Write (bytes, 0, bytes.Length);
			memStream.Position = 0;

			ProtoBattleVideoInfo video = Serializer.Deserialize<ProtoBattleVideoInfo>(memStream);

			memStream.Dispose ();
			return video;
		}

		#endregion


		public void Clear()
		{
			
			if (Directory.Exists (Root_Record))
			{
				PathUtil.DeleteDirectory (Root_Record);
			}
		}




		public void Upload(ProtoBattleVideoInfo video, int uploadType, int roleId)
		{
			string url = Url_Video_Upload;
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "POST";
				request.ContentType = "application/octet-stream";
				request.ContentLength = video.video_data.Length;

				request.BeginGetRequestStream((IAsyncResult result)=>
					{
						if (!result.IsCompleted)
						{
							Debug.LogError("上传视频文件失败");
							return;
						}

						HttpWebRequest req = (HttpWebRequest)result.AsyncState;
						Stream myRequestStream = request.EndGetRequestStream(result);
						myRequestStream.Write(video.video_data, 0, video.video_data.Length);
					}, request);

				using (WebResponse wr = request.GetResponse())
				{
					//在这里对接收到的页面内容进行处理
					Stream stream = wr.GetResponseStream();
					StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
					string filename = streamReader.ReadToEnd();
					Debug.Log(filename);
					video.uuid = filename;

					byte[] t = video.video_data;
					video.video_data = null;
					War.service.C_UploadBattleVideo_0x550(video, uploadType, roleId);
					video.video_data = t;
				}

			}
			catch (Exception)
			{
				Debug.LogError("上传视频文件异常");
			}
		}

		public void Load(ProtoBattleVideoInfo video, int watchRoleId)
		{


			string url = GetVideoUrl (video.uuid);
			Debug.Log ("url=" + url);

			HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
			//设置接收对象的范围为0-10000000字节。

			hwr.AddRange(0, 10000000);

			MemoryStream ms = new MemoryStream ();
			//流对象使用完后自动关闭
			using (Stream stream = hwr.GetResponse().GetResponseStream())
			{
				//建立字节组，并设置它的大小是多少字节
				byte[] bytes = new byte[102400];
				int n = 1;
				while (n > 0)
				{
					//一次从流中读多少字节，并把值赋给Ｎ，当读完后，Ｎ为０,并退出循环
					n = stream.Read(bytes, 0, 10240); 
					ms.Write(bytes, 0, n); //将指定字节的流信息写入文件流中
				}
			}


			video.video_data = new byte[ms.Length];
			ms.Position = 0;
			ms.Read (video.video_data, 0, (int)ms.Length);

			War.Start (video, watchRoleId);


		}



	}
}