using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class BWall : EBehaviour
	{
		public Transform obstacleBox;
		public BuildWallConfig wallConfig;
		protected override void OnStart ()
		{
			base.OnStart ();

			if(obstacleBox == null) obstacleBox = transform.FindChild("ObstacleBox");


			wallConfig =  unitData.wallConfig;
			unitAgent.angel = wallConfig.angle;


			if(wallConfig.wallType == WallType.Cube)
			{
				obstacleBox.localScale = wallConfig.size;
				obstacleBox.eulerAngles = new Vector3(0F, wallConfig.angle, 0F);
			}
			else
			{
				obstacleBox.localScale = Vector3.one * 0.5F * wallConfig.radius;
			}

		}
	}
}
