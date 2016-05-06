using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{

	public class StagePathData 
	{

		public static string GetKey(int from, int to)
		{
			if(from <= to)
			{
				return from + "_" + to;
			}
			else
			{
				return to + "_" + from;
			}
		}

		public static bool NeedReverse(int from, int to)
		{
			return from > to;
		}

		public static string GetFilePath(int stageId)
		{
			return "Config/stage_path/path_" + stageId;
		}

		public int stageId;
		
		public Dictionary<string, Vector3[]> pathReverseDict = new Dictionary<string, Vector3[]>();
		public Dictionary<string, Vector3[]> pathDict = new Dictionary<string, Vector3[]>();
		public Dictionary<string, PathPoint[]> pointDict = new Dictionary<string, PathPoint[]>();
		
		public bool HasPath(int from, int to)
		{
			return pathDict.ContainsKey(GetKey(from, to));
		}

		public Vector3[] GetPath(int from, int to)
		{
			string key = GetKey(from, to);
			if(pathDict.ContainsKey(key))
			{
				if(NeedReverse(from, to))
				{
					if(!pathReverseDict.ContainsKey(key))
					{
						List<Vector3> list = new List<Vector3>(pathDict[key]);
						list.Reverse();
						pathReverseDict.Add(key, list.ToArray());
					}

					return pathReverseDict[key];
				}
				else
				{
					return pathDict[key];
				}
			}
			else
			{
				Debug.LogErrorFormat("from={0}, to={1}, key={2} not find path", from, to, key);
			}
			return null;
		}


		public void AddPath(int from, int to, Vector3[] path)
		{
			string key = GetKey(from, to);
			if(!pathDict.ContainsKey(key))
			{
				pathDict.Add(key, path);
			}
		}

        //强制更新路径，用于路径更新
        public void AddPointForce(int from, int to, Vector3[] path)
        {
            string key = GetKey(from, to);

            if (pointDict.ContainsKey(key))
            {
                pointDict.Remove(key);
            }
            List<PathPoint> list = new List<PathPoint>();
            int count = path.Length;
            for (int i = 0; i < count; i++)
            {
                list.Add(path[i].ToPoint());
            }
            pointDict.Add(key, list.ToArray());
        }

        public void AddPoint(int from, int to, Vector3[] path)
		{

			string key = GetKey(from, to);
			if(!pointDict.ContainsKey(key))
			{
				List<PathPoint> list = new List<PathPoint>();
				int count = path.Length;
				for(int i = 0; i < count; i ++)
				{
					list.Add(path[i].ToPoint());
				}

				pointDict.Add(key, list.ToArray());
			}
		}

		public void PointToVector3()
		{
			foreach(var item in pointDict)
			{
				PathPoint[] points = item.Value;

				List<Vector3> list = new List<Vector3>();
				int count = points.Length;
				for(int i = 0; i < count; i ++)
				{
					list.Add(points[i].ToVector3());
				}

				pathDict.Add(item.Key, list.ToArray());
			}
		}

	}
}