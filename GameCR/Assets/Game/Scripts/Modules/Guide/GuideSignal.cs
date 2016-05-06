using UnityEngine;
using System.Collections;
using System;

namespace Games.Guides
{
	public class GuideSignal
	{
		public Action onClickScreen;

		public void OnClickScreenHandler()
		{
			if(onClickScreen != null)
			{
				onClickScreen();
			}
		}

        public void Clear()
        {
            onClickScreen = null;

        }

	}
}