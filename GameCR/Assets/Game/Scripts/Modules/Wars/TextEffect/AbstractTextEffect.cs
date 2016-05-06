using UnityEngine;
using System.Collections;

public class AbstractTextEffect : MonoBehaviour
{
	public TextEffectPool pool;

	virtual public void Play(object val)
	{
		Play(val, Color.white);
	}

	virtual public void Play(object val, Color color)
	{
	}
}
