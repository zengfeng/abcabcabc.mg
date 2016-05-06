using UnityEngine;
using System.Collections;

namespace Games.Cores
{
	public partial class GameSavePath
	{
		public string Root_Record
		{
			get
			{
				return PathUtil.UserDataPath + "record/";
			}
		}


		public string Url_Video_Upload
		{
			get 
			{
				return GameConst.Host_Upload + "/video_post";
			}
		}

		public string GetVideoUrl(string name)
		{
			return GameConst.Host_Upload + "/uploads/video/" + name + ".txt";
		}




	}
}