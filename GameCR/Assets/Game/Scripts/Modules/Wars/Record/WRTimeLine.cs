using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class WRTimeLine : MonoBehaviour 
	{
		public WRTimeLineData timeLineData;
		public WRAction action;
		public int index = 0;
		public int count = 0;


		void Start () 
		{
			if(War.isGameing)
			{
				Init();
			}
			else
			{
				War.signal.sGameBegin += Init;
			}
		}


		void OnDestroy()
		{
			War.signal.sGameBegin -= Init;
		}

		void Init()
		{
			Debug.Log ("WRTimeLine.Init");
			if (!War.isRecord)
			{
				this.enabled = false;
			} 
			else
			{
				Debug.Log (" War.timeLineData=" +  War.timeLineData);
				timeLineData = War.timeLineData;
				count = timeLineData.queue.Count;

				if(index < count)
				{
					action = timeLineData.queue[index];
					index++;
				}
			}

		}

		void Update () 
		{
			if (action == null)
				return;

			CheckAction ();
		}

		void CheckAction()
		{
			if (War.time > action.t)
			{
				action.Exe ();
				action = null;

				if (index < count) 
				{
					action = timeLineData.queue [index];
					index++;

					CheckAction ();
				}
			}
		}

	}
}