using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class NativeUtils : MonoBehaviour {

	[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
	public static extern IntPtr LoadLibrary(
		string lpFileName
	);
}
