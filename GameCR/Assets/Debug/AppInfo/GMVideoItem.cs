using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.PB;
using Games.Module.Wars;
using CC.Runtime.Utils;
using Games.Cores;

public class GMVideoItem : MonoBehaviour 
{
	public GMVideoPanel panel;

	public Text idText;
	public Text nameText;
	public Text countText;
	public Text versionText;
	public Text createTimeText;

	public ProtoBattleVideoInfo data;



	public void SetData(ProtoBattleVideoInfo data)
	{
		this.data = data;
		idText.text = data.uid_local + "";
		countText.text = data.view_count + "";
		versionText.text = "V." + data.war_version;

		string name = "";
		for(int i = 0; i < data.fight_roles.Count; i ++)
		{
			ProtoBattleVideoRoleInfo role = data.fight_roles[i];
			name += role.role_info.name;
			if(i < data.fight_roles.Count -1)
			{
				name += "   VS   ";
			}
		}
		nameText.text = name;
		createTimeText.text = DateTimeUtils.DateStringFromNow( data.create_time );
	}


	public void Watch()
	{
		War.record.SetWatchCount (data.uid_local, data.view_count + 1);
		War.Start (data, -1);
	}

	public void S_Watch()
	{
		Goo.save.record.Load(data, -1);
	}

	public void Delete()
	{
		War.record.Delete (data.uid_local);
		panel.Load ();
	}

	public void Upload()
	{
		War.record.Upload (data, 2, -1);
//		War.service.C_UploadBattleVideo_0x550 (data);
	}

}
