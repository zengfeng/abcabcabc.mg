using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DOKillOnDestroy : MonoBehaviour {

	void OnDestroy()
	{
		transform.DOKill();
	}
}
