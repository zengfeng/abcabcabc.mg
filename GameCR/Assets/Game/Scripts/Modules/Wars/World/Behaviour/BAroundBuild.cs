using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System.Collections.Generic;

public class AroundPart
{
	public int index;
	public int initNum;
	public int count;
	
	public Vector3 	o;
	public float 	r;
	
	public Vector3 center;
	public float angleBegin;
	public float angleEnd;


	public float mDistance;
	public bool mSelect;
	public int mGetPointIndex = 0;

	public void Init()
	{
		float angle = angleBegin + (angleEnd - angleBegin) * 0.5f;
		center = HMath.PointAngle(o, angle, r);
	}

	public float Distance(Vector3 p)
	{
		return mDistance = Vector3.Distance(center, p);
	}

	
	public bool GetIsFull(int num)
	{
		if(initNum - count >= num) return false;
		if(initNum - count >= num * 0.5F) return false;
		return true;
	}

	public List<Vector3> GetPoints(int num)
	{
		List<Vector3> list = new List<Vector3>();
		float gap = (angleEnd - angleBegin) / num;
		int mi = mGetPointIndex % 4;
		int sg = mi % 2 == 0 ? 1 : -1;
		float offset = sg * gap / (1 + mi) + gap * 0.5f;

//		Debug.Log("offset=" + offset + "  mGetPointIndex=" + mGetPointIndex  + " count=" + count + " gap=" + gap);
		for(int i = 0; i < num; i ++)
		{
			float a = angleBegin + gap * i + offset;
			Vector3 p = HMath.PointAngle(o, a, r + mGetPointIndex * 0f);
			list.Add(p);
		}
		mGetPointIndex ++;
		count += num;

		return list;
	}

	public void Remove(int num)
	{
		count -= num;
		if(count < 0) count= 0;
	}

	public void OnDrawGizmos() 
	{
		Gizmos.color = Color.green * (mSelect ? 1f : 0.7f);
		Gizmos.DrawWireSphere(center, 0.01f);
	}
}

public class BAroundBuild : MonoBehaviour 
{
	public float 	radius = 5f;
	public float 	externalRadius = 2F;
	public Vector3 	o;
	public float 	r;
	public int 		partPointNum = 10;
	public int 		partNum = 8;
	public float 	angleOffset = 0f;
	public float 	partAngle = 45f;

	public bool 	isUpdate;

	public List<AroundPart> pars = new List<AroundPart>();

	void Start ()
	{
		SetAroundPoints();
	}

	void Update () 
	{
		if(isUpdate)
		{
			SetAroundPoints();
		}
	}

	void SetAroundPoints()
	{
		SphereCollider sphereCollider = GetComponent<SphereCollider>();
		if(sphereCollider == null)
		{
			Transform sphereColliderGO = transform.FindChild("ObstacleBox-Ray");
			if(sphereColliderGO != null) sphereCollider = sphereColliderGO.GetComponent<SphereCollider>();
		}
		if(sphereCollider != null) radius = sphereCollider.radius * transform.lossyScale.x;

		partAngle = 360f / partNum;
		r = radius + externalRadius;
		o = transform.position;

		for(int i = 0; i < partNum; i ++)
		{
			AroundPart aroundPart = new AroundPart();
			aroundPart.index = i;
			aroundPart.initNum = partPointNum;
			aroundPart.o = o;
			aroundPart.r = r;

			aroundPart.angleBegin 	= angleOffset + partAngle * i ;
			aroundPart.angleEnd 	= angleOffset + partAngle * (i + 1);

			aroundPart.Init();
			pars.Add(aroundPart);
		}
	}

	public AroundPart FindPart(Vector3 p, int unitCount = 8)
	{
		float minDistance = 9999;
		float nofullDistance = 9999;
		int minCount = 99999;
		AroundPart minDistanceItem = null;
		AroundPart nofullItem = null;
		AroundPart minCountItem = null;
		bool allFull = true;
		float score = 0;
		float minScore = 9999;
		AroundPart minScoreItem = null;

		float oDistance = Vector3.Distance(p, o);
		foreach(AroundPart aroundPart in pars)
		{
			if(aroundPart.Distance(p) <= minDistance)
			{
				minDistance = aroundPart.mDistance;
				minDistanceItem = aroundPart;
			}

			if(aroundPart.mDistance < nofullDistance && !aroundPart.GetIsFull(unitCount))
			{
				nofullDistance = aroundPart.mDistance;
				nofullItem = aroundPart;
			}

			if(aroundPart.count < aroundPart.initNum)
			{
				allFull = false;
			}


			if(aroundPart.count < minCount)
			{
				minCount = aroundPart.count;
				minCountItem = aroundPart;
			}

			
			score = aroundPart.mDistance / oDistance * 0.65f + aroundPart.count / aroundPart.initNum * 0.35f;
			if(score <= minScore)
			{
				minScore = score;
				minScoreItem = aroundPart;
			}

		}

		if(nofullItem == null)
		{
			nofullItem = minScoreItem;
		}
		return nofullItem;
	}

	public List<Vector3> FindPoints(Vector3 p, int unitCount, out AroundPart aroundPart)
	{
		aroundPart = FindPart(p, unitCount);
		return aroundPart.GetPoints(unitCount);
	}

	void OnDrawGizmos() 
	{
//		Gizmos.color = Color.white;
//		for(int i = 0; i < partNum; i ++)
//		{
//			float angle = partAngle * i + angleOffset;
//			Vector3 p = HMath.PointAngle(o, angle, r);
//			Gizmos.DrawLine(o, p);
//		}
//
//		foreach(AroundPart aroundPart in pars)
//		{
//			aroundPart.OnDrawGizmos();
//		}

	}
}
