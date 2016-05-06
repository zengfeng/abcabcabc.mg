using UnityEngine;
using System.Collections;
namespace CC.Runtime
{
	public class ManangerRoot : MonoBehaviour 
	{
		private static ManangerRoot _Instance;
		public static ManangerRoot Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("GameManagers");
					if(go == null) go = new GameObject("GameManagers");
					
					_Instance = go.GetComponent<ManangerRoot>();
					if(_Instance == null) _Instance = go.AddComponent<ManangerRoot>();
				}
				return _Instance;
			}
		}

		void Awake ()
		{
			_Instance = this;
		}


//		public HSignal<int> sConnect = new HSignal<int>();
//		public HSignal<int> sReconnect = new HSignal<int>();
//		public HSignal<int> sDisconnect = new HSignal<int>();



	}
}