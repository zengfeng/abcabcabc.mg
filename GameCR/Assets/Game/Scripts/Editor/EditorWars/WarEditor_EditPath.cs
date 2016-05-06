
using UnityEngine;
using UnityEditor;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using CC.Runtime.Utils;

namespace Game.Editors.Wars
{
	public class WarEditor_EditPath : EditorWindow
    {
        static WarEditor_EditPath mCurrentWindow;
        public string mFromIdxStr = "1";
        public string mToIdxStr = "2";
        int mFromId = 0;
        int mToId = 0;
        StagePathData mPathData;//关卡路径信息
        string mKey = "";//路径key
        int mCurStageId = 0;//当前关卡id

        [MenuItem("关卡/编辑路径 ", false, 5000)]
        static void init()
        {
            Debug.LogFormat("-------ScalePicWindow----");
            WarEditor_EditPath currentWindow = EditorWindow.GetWindow<WarEditor_EditPath>("关卡配置");
            currentWindow.minSize = new Vector2(300, 200);
        }

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 100, 200));
                GUILayout.Label("from");
                GUILayout.Label("to");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(50, 0, 100, 200));
            mFromIdxStr = GUILayout.TextField(mFromIdxStr, 25);
            mToIdxStr = GUILayout.TextField(mToIdxStr, 25);
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(0, 50, 200, 200));
            if (GUILayout.Button("获取路径"))
            {
                btnShowPath();
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(0, 100, 200, 200));
            if (GUILayout.Button("保存路径"))
            {
                if (EditorUtility.DisplayDialog("Save path?", "是否更新路径", "确定", "取消"))
                {
                    btnSavePath();
                }
                else
                {
                }
            }
            GUILayout.EndArea();
        }
        //读取文件
        private string LoadFile(string path)
        {
            Debug.Log("loadfile path: " + path);
            FileInfo t = new FileInfo(path);
            if (!t.Exists)
            {
                return "";
            }
            StreamReader sr = null;
            sr = File.OpenText(path);
            string content = sr.ReadToEnd();
            
            sr.Close();
            sr.Dispose();
            return content;
        }
        //显示路径
        public void btnShowPath()
		{
            mFromId = mFromIdxStr.ToInt32();
            mToId = mToIdxStr.ToInt32();

            if (War.sceneData == null)
            {
                Debug.Log("=====err cant find war====");
                return;
            }
            mCurStageId = War.sceneData.stageConfig.id;
            //获取配置表
            //object asset = WarRes.GetRes<object>(StagePathData.GetFilePath(mCurStageId));
            //if (asset == null)
            //{
            //    Debug.Log("=============asset null=============");
            //    return;
            //}
            string content = LoadFile(Application.dataPath + "/Game/Config/stage_path/path_" + mCurStageId + ".json");
            Debug.Log("=================ShowPath =================: " + content.Length);
            mPathData = JsonConvert.DeserializeObject(content, typeof(StagePathData)) as StagePathData;

            Dictionary<string, PathPoint[]> pointDict = mPathData.pointDict;
            List<Vector3> nodes = new List<Vector3>();
            //获取路径
            mKey = string.Format("{0}_{1}", mFromIdxStr, mToIdxStr);
            PathPoint []Pt;
            if (!pointDict.TryGetValue(mKey, out Pt))
            {
                mKey = string.Format("{0}_{1}", mToIdxStr, mFromIdxStr);
                if (!pointDict.TryGetValue(mKey, out Pt))
                {
                    Debug.Log("cant find key: " + mKey);
                    mKey = "";
                    return;
                }
            }
            Debug.Log("===key: " + mKey);
            for (int i = 0; i < Pt.Length; i ++)
            {
                Vector3 vc = Vector3.zero;
                vc.x = Pt[i].x;
                vc.y = 0.0f;
                vc.z = Pt[i].z;
                nodes.Add(vc);
                Debug.LogFormat("===path pot:{0} {1} {2}===", vc.x, vc.y, vc.z);
            }
            //iTween.DrawPath(nodes.ToArray(), Color.red);
            //绘制路径
            GameObject go = GameObject.Find("WarEditorScene/Path");
            iTweenPath iPath = go.GetComponent<iTweenPath>();
            iPath.nodeCount = 0;
            iPath.nodes.Clear();
            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 pos = Vector3.zero;
                pos.x = nodes[i].x;
                pos.y = nodes[i].y;
                pos.z = nodes[i].z;
                iPath.nodes.Add(pos);
            }
        }
        //保存路径
        public void btnSavePath()
        {
            //更新pathData数据
            Vector3[] pathPos = iTweenPath.GetPath("path");
            mPathData.AddPointForce(mFromId, mToId, pathPos);
            
            //保存至json文件
            string str = JsonConvert.SerializeObject(mPathData, Formatting.Indented);

            string filesPath = Application.dataPath + "/Game/" + StagePathData.GetFilePath(mPathData.stageId) + ".json";
            Debug.Log(filesPath);

            PathUtil.CheckPath(filesPath, true);
            if (File.Exists(filesPath)) File.Delete(filesPath);
            FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
            fs.Close();
        }
    }
}