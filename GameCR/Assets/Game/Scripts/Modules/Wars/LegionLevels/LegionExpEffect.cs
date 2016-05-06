using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using CC.Runtime.Pools;
using CC.Runtime.Utils;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public enum LegionExpEffectType
	{
		L,
		M,
		S
	}


	public class LegionExpEffect : MonoBehaviour 
	{
		public RectTransform point;
		public Image targetGlow;
		public Vector3 beginPos;
		public Vector3 targetPos;
		public Vector3 midePos;
		public Vector3 v = new Vector3(1, 1, 0);
		public Vector3 d;
		public float magnitude;

		public int count = 0;
		public List<EffectItem> list;

		public struct EffectItem
		{
			public LegionExpEffectType type;
			public Vector3 position;
		}

		void Start () 
		{
			War.legionExpEffect = this;
		}


		public void Play(LegionExpEffectType type, UnitCtl unit)
		{
			if(War.sceneData.visiableLegionLevelMsg == false)
			{
				return;
			}

			
			targetPos = targetGlow.transform.position;

			Vector3 unitPos = unit.transform.position;
			if(type == LegionExpEffectType.L)
			{
				unitPos += new Vector3(-2, 1, 0);
			}

			point.anchoredPosition = unitPos.WorldPosToAnchorPos();
			beginPos = point.position;

			GameObject go = War.pool.legionExpPool.Get(type);
			go.SetActive(false);
			go.transform.SetParent(transform);
			go.transform.position = beginPos;
			
			d = targetPos - beginPos;
			magnitude = d.magnitude / 10f;
			//Debug.Log("targetPos =" +targetPos + "  d.magnitude=" + d.magnitude);

			midePos = beginPos + d * 0.5f + v * magnitude * Random.Range(-1f, 1f);

			go.transform.DOPath(new Vector3[]{beginPos, midePos, targetPos}, Mathf.Max(0.8f, 1f * magnitude), PathType.CatmullRom).SetDelay(count * 0.05f).SetEase(Ease.InExpo).OnStart(()=>{go.SetActive(true);}).OnComplete(()=>{
				go.GetComponent<PrefabPoolItem>().Release();
				go.SetActive(false);
				go.transform.position = Vector3.zero * -1000;

				targetGlow.DOKill();
				targetGlow.color = targetGlow.color.SetAlhpa(1);
				targetGlow.DOFade(0, 0.5f);
				count --;
			});
			count ++;
		}
	}
}