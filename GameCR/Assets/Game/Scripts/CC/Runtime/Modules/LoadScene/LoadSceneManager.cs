using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace CC.Module.LoadScenes
{


	public class LoadSceneManager
	{
		private static string LOADING = "Loading";
		private static string LOADING_A = "LoadingA";
		private static string LOADING_B = "LoadingB";
		private static string currentLoading = "";

		public static HSignal<float, string> loadOtherProgressSignal = new HSignal<float, string>();
		public static HSignal loadOtherCompleteSignal = new HSignal();

		public static string sceneName = "Main";
		public static void Load(string name)
		{
			sceneName = name;

			Application.LoadLevel(LOADING);
		}

		public static void LoadAdditive(string name)
		{
			sceneName = name;

			if(currentLoading != LOADING_A)
			{
				currentLoading = LOADING_A;
			}
			else
			{
				currentLoading = LOADING_B;
			}
			
			Application.LoadLevel(currentLoading);
		}

		public static void LoadRes()
		{

		}
	}
}
