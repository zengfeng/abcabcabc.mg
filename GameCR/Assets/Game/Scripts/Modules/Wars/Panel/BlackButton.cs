using UnityEngine;
using System.Collections;
using CC.Module.LoadScenes;


namespace Games.Module.Wars
{
	public class BlackButton : MonoBehaviour
	{
		public void OnClick()
		{
			War.Exit(true);
		}
	}
}