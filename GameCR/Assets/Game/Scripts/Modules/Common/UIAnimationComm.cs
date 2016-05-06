using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimationComm : MonoBehaviour {

    // Use this for initialization
    Animator anim = null;
    void Start() {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }
    //获取物品时暴击数字动画
    public void AnimationCritical()
    {
        Debug.Log("------AnimationCritical------");
        //调用DOmove方法来让图片移动
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(0f, 0f, 0f);

        Sequence mySequence = DOTween.Sequence();
        Tweener tweenerScale = rectTransform.DOScale(1.5f, 0.2f);
        tweenerScale.SetEase(Ease.InQuad);
        mySequence.Append(tweenerScale);

        Tweener tweenerMove = rectTransform.DOMoveY(2f, 0.2f);
        tweenerMove.SetEase(Ease.InQuad);
        mySequence.Join(tweenerMove);

        Tweener tweenerScale2 = rectTransform.DOScale(1.0f, 0.1f);
        tweenerScale2.SetEase(Ease.InQuad);
        mySequence.Append(tweenerScale2);

        // alpha1 = rectTransform.DOColor(new Color(c.r, c.g, c.b, 1), 0.5f);

        //设置移动类型
        //tweener.SetEase(Ease.Linear);
        //tweener.onComplete = delegate()
        //{
        //    Debug.Log("移动完毕事件");
        //};
        //image.material.DOFade(0, 1f).onComplete = delegate()
        //{
        //    Debug.Log("褪色完毕事件");
        //};
    }

    public void AnimationTipMoveLeft()
    {
        Debug.LogFormat("-----AnimationTipMoveLeft----");
        Sequence mySequence = DOTween.Sequence();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        float moveOffset = rectTransform.sizeDelta.x + 20;
        //Debug.LogFormat("=====move left len: {0} {1}", moveOffset, rectTransform.localPosition.x);
        Tweener tweenerMove = rectTransform.DOLocalMoveX(rectTransform.localPosition.x - moveOffset / 2, 0.3f);
        mySequence.Append(tweenerMove);
    }
    public void AnimationTipMoveRight()
    {
        Debug.LogFormat("-----AnimationTipMoveRight----");
        Sequence mySequence = DOTween.Sequence();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        float moveOffset = rectTransform.sizeDelta.x + 20;
        //Debug.LogFormat("=====move right len: {0} {1}", moveOffset, rectTransform.localPosition.x);
        Tweener tweenerMove = rectTransform.DOLocalMoveX(rectTransform.localPosition.x + moveOffset / 2, 0.3f);
        mySequence.Append(tweenerMove);
    }

    #region 上阵英雄
    //offsetTag = 1 顺时针旋转，-1：逆时针
    public void AnimationFlyTo(Transform srcPosTransform, int offsetTag, float time)
    {

        Vector3 srcPos = srcPosTransform.position;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector3[] pathAll = new Vector3[3];
        pathAll[0] = transform.position;
        float distance = Vector3.Distance(this.transform.position, srcPos);
        Debug.Log("=============distance: " + distance);

        Vector3 vTmp = transform.position;
        Vector3 dir = (srcPos - transform.position).normalized;
        Quaternion r = transform.rotation;
        Vector3 f0 = (transform.position + (r * dir) * distance);

        if (offsetTag == 1)
        {
            Quaternion r0 = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 8f);

            Vector3 f1 = (transform.position + (r0 * dir) * distance * 0.6f);
            vTmp = f1;
            //Debug.DrawLine(transform.position, vTmp, Color.red, 100.0f);
        }
        else if (offsetTag == -1)
        {
            Quaternion r0 = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 15f);

            Vector3 f1 = (transform.position + (r0 * dir) * distance * 0.3f);
            vTmp = f1;
            //Debug.DrawLine(transform.position, vTmp, Color.blue, 100.0f);
        }
        else
        {
            Quaternion r0 = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            Vector3 f1 = (transform.position + (r0 * dir) * distance / 2f);
            vTmp = f1;
            // Debug.DrawLine(transform.position, vTmp, Color.yellow, 100.0f);
        }
        pathAll[1] = vTmp;
        

        pathAll[2] = new Vector3(srcPos.x , srcPos.y, srcPos.z );

        Hashtable args = new Hashtable();
        //设置路径的点
        args.Add("path", pathAll);
        args.Add("easeType", iTween.EaseType.linear);
        args.Add("time", time);

        //移动结束时调用
        args.Add("oncomplete", "AnimationEnd");
        args.Add("oncompleteparams", "end");
        args.Add("oncompletetarget", gameObject);
       
        //让模型开始寻路	
        iTween.MoveTo(this.gameObject, args);
    }

    void AnimationEnd(string f)
    {
        Destroy(gameObject);
    }

    #endregion
    //
    #region 战斗数字
    public void TextAnimation()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        Sequence mySequence = DOTween.Sequence();
        Tweener tweenerScale = rectTransform.DOScale(0.7f, 0.8f);

    }
    #endregion
}


