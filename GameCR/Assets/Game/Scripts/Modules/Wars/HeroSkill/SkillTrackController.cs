using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;

//[System.Serializable]
//public struct SkillTrackTypeStruct
//    {
//        public float speed;
//        public float high;       
//    }
namespace Games.Module.Wars
{
    public class TrackParamClass
    {
        public float speedTrack = 20.0f;//速度
        public float range = 10.0f;//范围
        public float high = 4.0f;//弹跳的高度
        public UnitCtl caster;
        public UnitCtl unitCtlCur;
    }
    public class SkillTrackController : MonoBehaviour
    {
        public Vector3[] m_pathAll = new Vector3[3];
        public Vector3[] m_pathAllNext = new Vector3[3];
        //public Vector3[] m_pathAll2 = new Vector3[3];
        TrackParamClass trackParam = new TrackParamClass();
        Vector3 m_endPos;
        Vector3 m_endPos2;//第二次弹跳的坐标
        //路径寻路中的所有点

        // Use this for initialization
        void Start()
        {
        }
        void Update()
        {
            // transform.LookAt(Camera.main.transform.position);
        }

		public void addForceParabola(Vector3 srcPos, float skillRange, TrackParamClass param)
        {
            trackParam = param;
            float currentDist = Vector3.Distance(this.transform.position, srcPos);
            if (currentDist > skillRange)
            {
                return ;
            }
            trackParam.unitCtlCur.unitData.freezedMoveSpeed = true;
            StartCoroutine(addForceParabolaGo(srcPos, skillRange)); 
        }
        IEnumerator addForceParabolaGo(Vector3 srcPos, float skillRange)
        {
            float idxRand = Random.Range(0, 0.2f);
            yield return new WaitForSeconds(idxRand);

            float currentDist = Vector3.Distance(this.transform.position, srcPos);
            float randValue = Random.Range(0, 5.0f);
            // print("==="+ randValue);
            Vector3 t = (transform.position - srcPos).normalized;
            m_endPos = srcPos + (transform.position - srcPos).normalized * (currentDist + trackParam.range + randValue);
            m_endPos.y = transform.position.y;
            m_endPos2 = m_endPos + (transform.position - srcPos).normalized * (trackParam.range / 4);
            m_endPos2.y = transform.position.y;
            //直接散开
            float idxDis = Random.Range(0, 1.0f);
            m_pathAll[0] = transform.position;
            m_pathAll[1] = new Vector3((m_endPos.x - transform.position.x) / 2 + transform.position.x, trackParam.high + idxDis,
                                                     (m_endPos.z - transform.position.z) / 2 + transform.position.z + idxDis);
            m_pathAll[2] = m_endPos;
            //计算角度
            Vector3 a = new Vector3(0, 0, 1);
            Vector3 b = transform.position - srcPos;
            float angle = HMath.angle(0, 0, b.z, b.x);
            Hashtable args = new Hashtable();
            //设置路径的点
            args.Add("path", m_pathAll);
            //设置类型为线性，线性效果会好一些。
            //args.Add("easeType", iTween.EaseType.easeOutQuad);
            args.Add("easeType", iTween.EaseType.linear);
            //设置寻路的速度
            args.Add("speed", trackParam.speedTrack);
            //args.Add("delay", 0.2f);
            //是否先从原始位置走到路径中第一个点的位置
            // args.Add("movetopath", true);
            //是否让模型始终面朝当面目标的方向，拐弯的地方会自动旋转模型
            //如果你发现你的模型在寻路的时候始终都是一个方向那么一定要打开这个
            //args.Add("orienttopath", true);

            //处理移动过程中的事件。
            //开始发生移动时调用AnimationStart方法，5.0表示它的参数
            args.Add("onstart", "AnimationStart");
            args.Add("onstartparams", angle);

            //移动结束时调用，参数和上面类似
            args.Add("oncomplete", "AnimationEnd");
            args.Add("oncompleteparams", "end");
            args.Add("oncompletetarget", gameObject);
            //移动中调用，参数和上面类似
            //args.Add("onupdate", "AnimationUpdate");
            //args.Add("onupdatetarget", gameObject);
            //args.Add("onupdateparams", true);
            //让模型开始寻路	
            iTween.MoveTo(this.gameObject, args);
        }

        //对象开始移动时调用
        void AnimationStart(float f)
        {
            trackParam.unitCtlCur.unitAgent.angel = f;
            trackParam.unitCtlCur.unitAgent.action = "die";

        }
        void AnimationEnd(string f)
        {
            StartCoroutine(moveNext());
        }
         IEnumerator moveNext()
        {
            yield return new WaitForSeconds(0f);
            m_pathAllNext[0] = m_pathAll[2];
            m_pathAllNext[1] = new Vector3((m_endPos2.x - transform.position.x) / 2 + transform.position.x, trackParam.high / 7,
                                                     (m_endPos2.z - transform.position.z) / 2 + transform.position.z);
            m_pathAllNext[2] = m_endPos2;
            Hashtable args = new Hashtable();
            args.Add("path", m_pathAllNext);
            args.Add("easeType", iTween.EaseType.linear);
            args.Add("speed", trackParam.speedTrack / 4);
            args.Add("oncomplete", "AnimationEnd2");
            args.Add("oncompleteparams", "end");
            args.Add("oncompletetarget", gameObject);
            //让模型开始寻路	
            iTween.MoveTo(this.gameObject, args);
        }
        void AnimationEnd2(string f)
        {
            iTween.Stop(this.gameObject);
            trackParam.unitCtlCur.DamageToDeath(trackParam.caster);
        }
		
		public void OnRelease ()
		{
			StopAllCoroutines ();
			iTween.Stop(this.gameObject);
		}

        //void OnDrawGizmos()
        //{
        //    //iTween.DrawLine(pathAll3, Color.yellow);
        //    iTween.DrawPath(m_pathAll, Color.red);

        //    //iTween.DrawLine(pathAll2, Color.yellow);
        //    iTween.DrawPath(m_pathAllNext, Color.red);

        //}
    }
}