using UnityEngine;
using System.Collections;
using Games;

public class PlayerPrefsUtil 
{
	public static bool UseUserId = true;

	/// <summary>
	/// 生成一个Key名
	/// </summary>
	public static string GetKey(string key) {
		if (UseUserId)
			return GameConst.AppPrefix + GameConst.UserId + "_" + key;
		else
			return GameConst.AppPrefix + "_" + key;
	}

	
	
	/// <summary>
	/// 有没有值
	/// </summary>
	public static bool HasKey(string key) {
		string name = GetKey(key);
		return PlayerPrefs.HasKey(name);
	}

	
	/// <summary>
	/// 取得整型
	/// </summary>
	public static int GetInt(string key) {
		string name = GetKey(key);
		return PlayerPrefs.GetInt(name);
	}
	
	/// <summary>
	/// 保存整型
	/// </summary>
	public static void SetInt(string key, int value) {
		string name = GetKey(key);
		PlayerPrefs.DeleteKey(name);
		PlayerPrefs.SetInt(name, value);
		PlayerPrefs.Save();
	}

	
	
	/// <summary>
	/// 取得整型
	/// </summary>
	public static float GetFloat(string key) {
		string name = GetKey(key);
		return PlayerPrefs.GetFloat(name);
	}
	
	/// <summary>
	/// 保存整型
	/// </summary>
	public static void SetFloat(string key, float value) {
		string name = GetKey(key);
		PlayerPrefs.DeleteKey(name);
		PlayerPrefs.SetFloat(name, value);
		PlayerPrefs.Save();
	}

	
	/// <summary>
	/// 取得数据
	/// </summary>
	public static string GetString(string key) {
		string name = GetKey(key);
		return PlayerPrefs.GetString(name);
	}
	
	/// <summary>
	/// 保存数据
	/// </summary>
	public static void SetString(string key, string value) {
		string name = GetKey(key);
		PlayerPrefs.DeleteKey(name);
		PlayerPrefs.SetString(name, value);
		PlayerPrefs.Save();
	}
	
	/// <summary>
	/// 删除数据
	/// </summary>
	public static void RemoveData(string key) {
		string name = GetKey(key);
		PlayerPrefs.DeleteKey(name);
	}

	/// <summary>
	/// 删除所有数据
	/// </summary>
	public static void RemoveAllData() {
		PlayerPrefs.DeleteAll();
	}

	public static void SettingChange()
	{
		Setting.Change();
	}
}
