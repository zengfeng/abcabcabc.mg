using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using LuaInterface;
using System.Net;
using System.Net.Sockets;
using System;
using Games;

public class CrashReporter : MonoBehaviour
{
    private string fileName = "crash_report.log";
    private string postUrl = "http://www.qqpard.com/file_upload";
    private FileStream fileSt;
    private StreamWriter streamWr;
    private StreamReader streamRe;
    private float deltaTime = 0.5f;
    private float lastLogTime = 0;
    private string logStr = "";
    private string lastLogStr = "";
    static CrashReporter instance = null;

    public static CrashReporter Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("GameManagers");
                if(go == null) go = new GameObject("GameManagers");
                
                instance = go.GetComponent<CrashReporter>();
                if(instance == null) instance = go.AddComponent<CrashReporter>();
            }
            return instance;
        }
    }

    void Start()
    {
        fileSt = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        streamWr = new StreamWriter(fileSt);
        streamRe = new StreamReader(fileSt);
        logStr = streamRe.ReadToEnd();

        LuaScriptException.listener += OnLuaException;

        if (logStr.Length > 1)
        {
            StartCoroutine(SendCrashReport());
        }
    }

    void OnDestroy()
    {
        fileSt.Close();
        streamWr.Close();
    }

    public string filePath
    {
        get
        {
            return PathUtil.DataPath + fileName;
        }
    }

    protected void OnLuaException(string msg)
    {
		if (!GameConst.DevelopMode)
        	AppendLuaCrash(msg);
    }
    
    public void AppendLuaCrash(string str)
    {
        //防止同一个Log写入太频繁
        if (Time.time - lastLogTime < deltaTime)
        {
            if (str == lastLogStr)
            {
                return;
            }
        }
        lastLogTime = Time.time;
        lastLogStr = str;
		str += "\n" + str + "\n";

		LuaTable protoUtils = LuaScriptMgr.Instance.GetLuaTable("ProtoUtil");

		str += "\n\n\n ============= network log start ================\n\n";
		str += protoUtils.rawget("ProtoText") as string;
		str += "\n\n ============= network log end ===================\n\n\n";

		LuaTable role = LuaScriptMgr.Instance.GetLuaTable("Role");

		str += "\n\n\n ============= meta log start ===================\n\n";
		str += "roleId=" + role.rawget("roleId") as string;
		str += "\n\n ============= meta log end ===================\n\n\n";

		str += "\n =====================================================================================================================================\n";
		str += "\n ============= one log end ===========================================================================================================\n";
		str += "\n ======================================================================================================================================\n\n\n\n\n";

		protoUtils.RawGetFunc("CleanProtoText").Call();

		logStr += str;
        streamWr.Write(str);
        streamWr.Flush();
        fileSt.Flush();
    }

    public IEnumerator SendCrashReport()
    {
        yield return new WaitForSeconds(1);

        try
        {
            char[] charArr = logStr.ToCharArray();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "POST";
            request.ContentType = "text/plain";
            request.ContentLength = charArr.Length;

            request.BeginGetRequestStream((IAsyncResult result)=>
            {
                if (!result.IsCompleted)
                {
                    Debug.LogError("crash server error");
                    return;
                }

                HttpWebRequest req = (HttpWebRequest)result.AsyncState;
                Stream myRequestStream = request.EndGetRequestStream(result);
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
                myStreamWriter.Write(charArr);
                myStreamWriter.Close();
            }, request);

            logStr = "";
            fileSt.SetLength(0);
        }
        catch (Exception)
        {
            Debug.LogError("crash server error");
        }
    }
}
