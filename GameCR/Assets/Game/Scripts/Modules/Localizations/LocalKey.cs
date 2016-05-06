using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;

public partial class Local 
{
	public static string glod = "glod";
	public static string silver = "silver";
	public static string AutoBattle = "AutoBattle";
	public static string CancelBattle = "CancelBattle";
	public static string exp = "exp";
	public static string level = "level";
	public static string hero = "hero";
	public static string soldier = "soldier";
	public static string role = "role";

	public enum Key
	{
		Hi = 1000,
		WaSai

	}

}



//[Test]
//Debug.Log(Local.Get(Local.glod));
//Debug.Log(Local.Get(Local.silver));
//Debug.Log(Local.Get(Local.Key.Hi, new object[]{"A", "B"}));
//Debug.Log(Local.Get(1001));