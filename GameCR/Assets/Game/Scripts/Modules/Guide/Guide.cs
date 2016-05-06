using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	public class Guide
	{
		public static GameObject 			go;
		public static GuideActionManager 	actionManager;
		public static GuideModel			model;
		public static GuideManager			manager;
		public static GuideView				view;
		public static GuideSignal			signal;
		public static GuideWarConfig			warConfig = new GuideWarConfig();

		private static bool _isInit;
		public static void Init()
		{
			if(_isInit == false)
			{
				actionManager 	= new GuideActionManager();
				model			= new GuideModel();
				signal 			= new GuideSignal();
			}

			if(go == null)
			{
				go = new GameObject("Guide");
				manager = go.AddComponent<GuideManager>();
			}
			_isInit = true;
		}

        public static void OnDestroy()
        {
            if(signal != null)
            {
                signal.Clear();
            }
        }



    }
}