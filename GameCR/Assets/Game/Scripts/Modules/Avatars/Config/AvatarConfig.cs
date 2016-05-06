using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using System;
using System.Collections.Generic;
using Games.Module.Wars;


namespace Games.Module.Avatars
{
	[ConfigPath("Config/avatar", ConfigType.CSV)]
	public class AvatarConfig : IParseCsv, IKey<int>
	{
		public int id;
		public string name;
		public string detail;
		public string icon;
		public string vsIcon;
		public string full;
		public string model;
		public string changeLegionEfffect;
		public string effect;
		public float radius = 1f;
        public Vector2 talkPivot;
		public int Key
		{
			get
			{
				return id;
			}
		}
		
		public string Model 
		{
			get
			{
				return string.Format(model, War.config.ownDefaultColor);
			}
		}


		
		public void ParseCsv(string[] csv)
		{

			//编号	名称	通用图标	战场图标	全身像	模型	切换阵营特效	单位大小半径	备注
			//id	name	iocn	vsIocn	full	model	changeLegionEfffect		radius	detail

			int i = 0;
			id = csv.GetInt32(i++);
			name = csv.GetString(i++);
			icon = csv.GetString(i++);
			vsIcon = csv.GetString(i++);
			full = csv.GetString(i++);
			model = csv.GetString(i++);
			changeLegionEfffect = csv.GetString(i++);
			effect = csv.GetString(i++);
			radius = csv.GetSingle(i++);
            i++;
            string talkPivotString = csv.GetString(i++);
            string[] talkPivotArray = talkPivotString.Split(':');
            if (talkPivotArray.Length == 2)
            {
                talkPivot.x = talkPivotArray[0].ToSingle();
                talkPivot.y = talkPivotArray[1].ToSingle();
            }

			if(string.IsNullOrEmpty(vsIcon)) vsIcon = "Image/HeroIcon/hero_vs_icon_" + id;
		}
		
		public void LoadIcon( Action<string,object> callback)
		{
//			Debug.Log("icon=" + icon);
			Coo.assetManager.Load(icon, callback, typeof(Sprite));
		}

		
		public void LoadVSIcon( Action<string,object> callback)
		{
			Coo.assetManager.Load(vsIcon, callback, typeof(Sprite));
		}
		
		public void LoadHeadSkillClipIcon( Action<string,object> callback)
		{
			Coo.assetManager.Load(effect, callback, typeof(Sprite));
		}

		public void LoadFull( Action<string,object> callback)
		{
			Coo.assetManager.Load(full, callback, typeof(Sprite));
		}


		public void LoadIcon( Action<string,object> callback, int color)
		{
			Debug.Log(GetIconPath(color));
			Coo.assetManager.Load(GetIconPath(color), callback, typeof(Sprite));
		}

		public string GetIconPath(int color)
		{
			return string.Format(icon, color);
		}

		public string GetModelPath(int color)
		{
			return string.Format(model, color);
		}



		
		public List<string> GetResList(List<string> list, int[] colorIds)
		{
			for(int i = 0; i < colorIds.Length; i ++)
			{
				string path = GetModelPath(colorIds[i]);
				if(!string.IsNullOrEmpty(path) && list.IndexOf(path) == -1)
				{
					list.Add(path);
				}
			}
			
			
			if(!string.IsNullOrEmpty(changeLegionEfffect) && list.IndexOf(changeLegionEfffect) == -1)
			{
				list.Add(changeLegionEfffect);
			}
			
			
			if(!string.IsNullOrEmpty(effect) && list.IndexOf(effect) == -1)
			{
				list.Add(effect);
			}

			return list;
		}


		public override string ToString ()
		{
			return string.Format ("[AvatarConfig: Key={0}, name={1}, detail={2}, model={3}, icon={4}, full={5}, changeLegionEfffect={6}]", Key, name, detail, model, icon, full, changeLegionEfffect);
		}
	}
}