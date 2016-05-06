using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class ToLevel : MonoBehaviour 
	{


		
		public void ToLevelScene(int level)
		{
			Application.LoadLevel("Level"+level);
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}