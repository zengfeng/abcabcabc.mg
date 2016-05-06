using UnityEngine;
using System.Collections;
using RayPaths;

namespace Games.Module.Wars
{
	public class BBuildAroundAtk : EBehaviour
	{
		public float speed = 0.5F;
		public float time = 0f;
		public int onceNum = 1;

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			time += Time.deltaTime;
			if(time >= speed)
			{
				time = time - speed;

				int i = 0;
				while(i < onceNum && i < unitData.aroundList.Count)
				{

					int index = Random.Range(0, unitData.aroundList.Count - 1);
					if(unitData.aroundList[index].unit != null)
					{
						UnitPath unitPath = unitData.aroundList[index].unit.GetComponent<UnitPath>();
						unitPath.In(true);
						i++;
					}
					else
					{
						unitData.aroundList.RemoveAt(index);
					}
				}
			}
		}
	}
}
