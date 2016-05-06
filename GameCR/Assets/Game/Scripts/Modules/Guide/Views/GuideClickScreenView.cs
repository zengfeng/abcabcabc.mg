using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideClickScreenView : GuideAlphaPanelView
	{
		void OnGUI()
		{
			if(Input.GetMouseButtonDown(0))
			{
				Guide.signal.OnClickScreenHandler();
			}
		}
	}
}