using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RayPaths
{
	public class ObstacleBoxManager : MonoBehaviour 
	{
		public List<ObstacleBox> list = new List<ObstacleBox>();
		public Vector3 mapMin = new Vector3(-10F, 0F -10F);
		public Vector3 mapMax = new Vector3(10F, 0F, 10F);
		private bool isChange;
		void Start () 
		{

		}

		void Update () 
		{
			if(isChange)
			{
				foreach(ObstacleBox box in list)
				{

				}
			}
		}

		public void AddObstacleBox(ObstacleBox obstacleBox)
		{
			obstacleBox.change += OnChange;
			list.Add(obstacleBox);
			isChange = true;
		}

		public void RemoveObstacleBox(ObstacleBox obstacleBox)
		{
			obstacleBox.change -= OnChange;
			list.Remove(obstacleBox);
			isChange = true;
		}

		void OnChange(ObstacleBox obstacleBox)
		{
			isChange = true;
		}
	}
}
