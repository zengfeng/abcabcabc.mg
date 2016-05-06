using UnityEngine;
using System.Collections;
using DG.Tweening;
using LuaInterface;
using System;

public class DOTweenLuaUtils : MonoBehaviour {

	public static Tweener OnUpdate(Tweener tweener, LuaFunction func)
    {
        return tweener.OnUpdate(()=>{
            func.Call();
        });
    }

	public static Sequence OnSeqComplete(Sequence seq, LuaFunction func)
    {
        return seq.OnComplete(()=>{
            func.Call();
        });
    }

	public static Sequence AppendSeqCallback(Sequence seq, LuaFunction func)
    {
        return seq.AppendCallback(()=>{
            func.Call();
        });
    }

	public static Tweener SetDelay(Tweener tweener, float delay)
	{
		return tweener.SetDelay(delay);
	}

	public static Tweener SetEase(Tweener tweener, Ease ease)
	{
		return tweener.SetEase(ease);
	}

	public static Tweener SetLoop(Tweener tweener, int loopCount)
	{
		return tweener.SetLoops(loopCount);
	}

	public static Tweener OnTweenerComplete(Tweener tweener, LuaFunction func)
	{
		return tweener.OnComplete(()=>{
			func.Call();
		});
	}

	public static Tweener OnTweenerUpdate(Tweener tweener, LuaFunction func)
	{
		return tweener.OnUpdate(()=>{
			func.Call();
		});
	}

	public static Tweener TweenTo(LuaFunction getter, LuaFunction setter, float endValue, float duration)
	{
		return DOTween.To(()=>{
					Double d = (Double)(getter.Call()[0]);
					return (float)(d);
				}, v=>{
					setter.Call(v);
				}, endValue, duration);
	}

	public static Tween PlayTween(Tween tween)
	{
		return tween.Play();
	}

	public static Tween PauseTween(Tween tween)
	{
		return tween.Pause();
	}
}
