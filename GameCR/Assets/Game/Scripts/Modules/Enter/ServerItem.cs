using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Enters
{
	public class ServerItem : MonoBehaviour 
	{
		public Text idText;
		public Text nameText;
		public Text ipText;
		public Text stateText;

		public ServerVO vo;

		void Awake () 
		{
			if(idText == null) idText = transform.FindChild("ID").GetComponent<Text>();
			if(nameText == null) nameText = transform.FindChild("Name").GetComponent<Text>();
			if(ipText == null) ipText = transform.FindChild("IP").GetComponent<Text>();
			if(stateText == null) stateText = transform.FindChild("State").GetComponent<Text>();
		}


		void OnEnable()
		{
			if(vo != null)
			{
				idText.text = vo.id.ToString();
				nameText.text = vo.name;
				ipText.text = vo.ip;
				stateText.text = vo.stateName;
			}
		}



	}
}
