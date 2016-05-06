using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		public Dictionary<int, Vector3>  legionPositionDict = new Dictionary<int, Vector3>();
		public LayerMask groundLayer;
		private Vector2 _screenSize;
		public void GenerationLegionPositionDict()
		{
			legionPositionDict.Clear();

			Vector2 screenSize = new Vector2(Screen.width, Screen.height);
			_screenSize = screenSize;
			Vector2 padding = new Vector2(50, 50);
			Vector2[] screenPoints = new Vector2[]{
				new Vector2(screenSize.x * 0.5f, screenSize.y - padding.y), 
				new Vector2(screenSize.x * 0.5f, 150f), 
				new Vector2(screenSize.x- padding.x, screenSize.y - padding.y), 
				new Vector2(screenSize.x- padding.x, padding.y), 
				new Vector2(padding.x, screenSize.y - padding.y), 
			};

			for(int i = 0; i < screenPoints.Length; i ++)
			{
				Vector2 screenPoint = screenPoints[i];
				
				RaycastHit hit3d;
				Ray ray = Camera.main.ScreenPointToRay(screenPoint);
				if(Physics.Raycast(ray, out hit3d, 10000, groundLayer.value))
				{
					Vector3 pos = hit3d.point.SetY(0F);

					
//					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//					cube.transform.position = pos;
					legionPositionDict.Add(i, pos);
				}
			}
		}

		public Vector3 GetLegionPosition(int legionId)
		{
			if(_screenSize.x != Screen.width || _screenSize.y != Screen.height)
			{
				GenerationLegionPositionDict();
			}

			LegionData legionData = War.GetLegionData(legionId);
			if(legionPositionDict.ContainsKey(legionData.colorId))
			{
				return legionPositionDict[legionData.colorId];
			}

			return new Vector3(0, 0, 30);
		}


	}
}
	
