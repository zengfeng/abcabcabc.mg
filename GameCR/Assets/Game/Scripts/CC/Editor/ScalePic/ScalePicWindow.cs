using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR_WIN
using System.Drawing;
using ImageMagick;
#endif

public class ScalePicWindow : EditorWindow
{
#if UNITY_EDITOR_WIN
    #region window
    static ScalePicWindow currentWindow;
    ////选择贴图的对象
    //private Texture texture;
    //目录映射
    private static Dictionary<string, string> effectInfoDic = new Dictionary<string, string>();
    private static Dictionary<string, float> fileScaleRate = new Dictionary<string, float>();
    Dictionary<string, string> md5Dic = new Dictionary<string, string>();
    string pathRoot = Directory.GetCurrentDirectory() + "/artHD";
    #endregion

    private static bool isNativeLoad = false;

    #region methed
    [MenuItem("Tools/ScalePic")]
    static void init()
    {
        Debug.LogFormat("-------ScalePicWindow----");
        currentWindow = (ScalePicWindow)EditorWindow.GetWindow(typeof(ScalePicWindow));
        currentWindow.titleContent.text = "windows";
        currentWindow.minSize = new Vector2(500, 500);
        currentWindow.maxSize = new Vector2(500, 500);
    }


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 200, 200 ));
        GUILayout.Label("----ScalePicWindow----", EditorStyles.boldLabel);
        if (GUILayout.Button("缩图--UI"))
        {
            BtnClickUI();
        }
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0, 50, 200, 200));
        if (GUILayout.Button("强制缩图--UI"))
        {
            BtnClickForceUI();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(0, 100, 200, 200));
        if (GUILayout.Button("缩图--Res"))
        {
            BtnClickRes();
        }
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0, 130, 200, 200));
        if (GUILayout.Button("强制缩图--Res"))
        {
            BtnClickForceRes();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(0, 180, 200, 200));
        if (GUILayout.Button("缩图--士兵"))
        {
            
        }
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0, 210, 200, 200));
        if (GUILayout.Button("强制缩图--士兵"))
        {
           
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(0, 260, 200, 200));
        if (GUILayout.Button("缩图Temp"))
        {
            BtnScaleTemp();
        }
        GUILayout.EndArea();
        // texture = EditorGUILayout.ObjectField("增加一个贴图", texture, typeof(Texture), true) as Texture;

    }
    #region 获取子目录
    void getSubDirectory(string rootPath, List<string>dirPathAllList)
    {
        string[] directoryEntries;
        try
        {
            directoryEntries = Directory.GetDirectories(rootPath);

            for (int i = 0; i < directoryEntries.Length; i++)
            {
                string[] subDir = Directory.GetDirectories(directoryEntries[i]);
                
                //文件
                if (subDir.Length <= 0)
                {
                    dirPathAllList.Add(directoryEntries[i]);
                }
                //遍历子目录下
                else
                {
                    getSubDirectory(directoryEntries[i], dirPathAllList);
                    continue;
                }
            }
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Debug.Log("err path: " + rootPath + " Directory object does not exist.");
        }
    }
    #endregion

    #region 文件
    //读取文件
    private int LoadFile(string path, Dictionary<string, string> md5Dic)
    {
        FileInfo t = new FileInfo(path);
        if (!t.Exists)
        {
            return -1;
        }
        StreamReader sr = null;
        sr = File.OpenText(path);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] md5Str = line.Split('=');
            if(md5Str.Length != 2)
            {
                continue;
            }
            md5Dic[md5Str[0]] = md5Str[1];
        }
        sr.Close();
        sr.Dispose();
        return 0;
    }

    //写入文件
    private int WriteToFile(string path, Dictionary<string, string> md5Dic)
    {
        string[] contents = new string[md5Dic.Count];
        int idx = 0;
        foreach(KeyValuePair<string, string> dic in md5Dic)
        {
            string line = dic.Key + "=" + dic.Value;
            contents[idx] = line;
            idx++;
        }
        File.WriteAllLines(path, contents);
        return 0;
    }
    #endregion

    #region 处理路径
    void DealUIPath()
    {
        //获取ui文件所有子目录
        List<string> dirPathAllList = new List<string>();
        string rootPath = pathRoot + "/ui";
        getSubDirectory(rootPath, dirPathAllList);
        for (int j = 0; j < dirPathAllList.Count; j++)
        {
            if (EditorUtility.DisplayCancelableProgressBar("获取士兵图片", (j + 1) + "/" + dirPathAllList.Count, (float)j / (float)dirPathAllList.Count))
                break;
            string targetDirPath = Application.dataPath + "/art/ui/" + dirPathAllList[j].Substring(rootPath.Length + 1);
            effectInfoDic[dirPathAllList[j]] = targetDirPath;
            fileScaleRate[dirPathAllList[j]] = 56;
            Debug.LogFormat("dir: {0} : {1} -> {2}", j, dirPathAllList[j], targetDirPath);
        }
        EditorUtility.ClearProgressBar();
        load();
    }

    void DealResPath()
    {
        //手动配置路径
        effectInfoDic[pathRoot + "/Resources/Image/Grade"] = Application.dataPath + "/Game/Resources/Image/Grade";
        fileScaleRate[pathRoot + "/Resources/Image/Grade"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/Hero"] = Application.dataPath + "/Game/Resources/Image/Hero";
        fileScaleRate[pathRoot + "/Resources/Image/Hero"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/RoleHead"] = Application.dataPath + "/Game/Resources/Image/RoleHead";
        fileScaleRate[pathRoot + "/Resources/Image/RoleHead"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/SkillIcon"] = Application.dataPath + "/Game/Resources/Image/SkillIcon";
        fileScaleRate[pathRoot + "/Resources/Image/SkillIcon"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/Soldier"] = Application.dataPath + "/Game/Resources/Image/Soldier";
        fileScaleRate[pathRoot + "/Resources/Image/Soldier"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/TaskIcon"] = Application.dataPath + "/Game/Resources/Image/TaskIcon";
        fileScaleRate[pathRoot + "/Resources/Image/TaskIcon"] = 56;
        effectInfoDic[pathRoot + "/Resources/Image/Union"] = Application.dataPath + "/Game/Resources/Image/Union";
        fileScaleRate[pathRoot + "/Resources/Image/Union"] = 56;
        effectInfoDic[pathRoot + "/Resources/map/terrain"] = Application.dataPath + "/Game/Resources/map/terrain";
        fileScaleRate[pathRoot + "/Resources/map/terrain"] = 56;
        load();
    }

    void DealSoliderPath()
    {
        //获取士兵文件所有子目录 
        //List<string> dirPathAllList = new List<string>();
        //string rootPath = pathRoot + "/unit_texture";
        //getSubDirectory(rootPath, dirPathAllList);
        //for (int j = 0; j < dirPathAllList.Count; j++)
        //{
        //    if (EditorUtility.DisplayCancelableProgressBar("获取士兵图片", (j+1) + "/" + dirPathAllList.Count, (float)j / (float)dirPathAllList.Count))
        //        break;
        //    string targetDirPath = Application.dataPath + "/Game/Res/unit_texture/" + dirPathAllList[j].Substring(rootPath.Length + 1);
        //    effectInfoDic[dirPathAllList[j]] = targetDirPath;
        //    fileScaleRate[dirPathAllList[j]] = 43;
        //    Debug.LogFormat("dir: {0} : {1} -> {2}", j, dirPathAllList[j], targetDirPath);
        //}
        //EditorUtility.ClearProgressBar();
    }
    #endregion

    #region 按钮事件
    void BtnScaleTemp()
    {
        effectInfoDic[pathRoot + "/Temp"] = pathRoot + "/TempTo";
        fileScaleRate[pathRoot + "/Temp"] = 50.0f;
        load();
    }

    void BtnClickUI()
    {
        LoadFile(pathRoot + "/md5FileUI", md5Dic);
        DealUIPath();
    }

    void BtnClickForceUI()
    {
        md5Dic.Clear();
        DealUIPath();
    }

    void BtnClickRes()
    {
        LoadFile(pathRoot + "/md5FileRes", md5Dic);
        DealResPath();
    }

    void BtnClickForceRes()
    {
        md5Dic.Clear();
        DealResPath();
    }

    void BtnSetPackingTag()
    {
        //士兵
        List<string> dirPathAllList = new List<string>();
        string rootPath = Application.dataPath + "/Game/Res/unit_texture/soldier";
        getSubDirectory(rootPath, dirPathAllList);

        for (int i = 0; i < dirPathAllList.Count; i++)
        {
            if (i > 1)
            {
                break;
            }
            //获取图片路径  

            string[] dirs = Directory.GetFiles(dirPathAllList[i], "*.png");
            for (int j = 0; j < dirs.Length; j++)
            {
                string filePath = dirs[j];

                Debug.Log("===path: " + filePath);
                int a = filePath.IndexOf("Assets");
                string assetPath = filePath.Substring(a);

                TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
                if (textureImporter == null)
                {
                    Debug.LogError("cant find: + " + assetPath);
                    continue;
                }

                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.isReadable = true;

                DirectoryInfo dirInfo1 = Directory.GetParent(filePath);
                DirectoryInfo dirInfo2 = Directory.GetParent(dirInfo1.ToString());
                DirectoryInfo dirInfo3 = Directory.GetParent(dirInfo2.ToString());
                textureImporter.spritePackingTag = "8888";// dirInfo3.Name;
                textureImporter.mipmapEnabled = false;
                textureImporter.maxTextureSize = 1024;

                TextureImporterSettings templateSettings = new TextureImporterSettings();
                textureImporter.ReadTextureSettings(templateSettings);
                textureImporter.SetTextureSettings(templateSettings);

                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceSynchronousImport);
                EditorUtility.SetDirty(textureImporter);
                //AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceSynchronousImport);

            }
            //string[] metaFiles = Directory.GetFiles(dirPathAllList[i], "*.meta");
            //for (int j = 0; j < dirs.Length; j++)
            //{
            //    Debug.Log("====fileinfo: " + metaFiles[j]);
            //    string filePath = metaFiles[j];
            //    FileInfo t = new FileInfo(filePath);
            //    if (!t.Exists)
            //    {
            //        continue;
            //    }
            //    StreamReader sr = null;
            //    sr = File.OpenText(filePath);
            //    //string line;
            //    //while ((line = sr.ReadLine()) != null)
            //    //{
            //    //    string[] md5Str = line.Split('=');
            //    //    if (md5Str.Length != 2)
            //    //    {
            //    //        continue;
            //    //    }
            //    //    md5Dic[md5Str[0]] = md5Str[1];
            //    //}
            //    sr.Close();
            //    sr.Dispose();
            //    File.Delete(filePath);
            //}
        }
    }

    #endregion


    //处理图片
    void load()
    {
		if (!isNativeLoad) 
		{
			isNativeLoad = true;
			NativeUtils.LoadLibrary (Application.dataPath + "/Plugins/ImageMagick/Magick.NET-Q8-x64.Native.dll");
		}

        Dictionary<string, string> filePaths = new Dictionary<string, string>();
        string imgtype = "*.JPG|*.PNG";
        string[] ImageType = imgtype.Split('|');
        //Debug.LogFormat("path:{0}", Application.dataPath);
        for (int i = 0; i < ImageType.Length; i++)
        {
            //获取图片路径  
            foreach (KeyValuePair<string, string> path in effectInfoDic)
            {
                string[] dirs = Directory.GetFiles( path.Key , ImageType[i]);
                for (int j = 0; j < dirs.Length; j++)
                {
                    //md5
                    string md5 = PathUtil.md5file(dirs[j]);
                    string md5InFile = "none";
                    if (!md5Dic.TryGetValue(dirs[j], out md5InFile))
                    {
                        md5InFile = "none";
                    }
                    if(md5InFile != md5)
                    {
                        filePaths.Add(dirs[j], path.Key);
                        md5Dic[dirs[j]] = md5;
                    }
                    
                }
            }
        }

        int idx = 0;
		foreach (KeyValuePair<string, string> filePathDic in filePaths)
        {
            idx++;
            if (EditorUtility.DisplayCancelableProgressBar("缩小图片", (idx + 1) + "/" + filePaths.Count, (float)idx / (float)filePaths.Count))
                break;
            string filePathFull = filePathDic.Key;//文件路径
            string fileDirectory = filePathDic.Value;//文件目录
            string fileName = filePathFull.Substring(fileDirectory.Length + 1);
            Debug.LogFormat("===path:{0}, name:{1}", filePathFull, fileName);

            string newFileDic;
			if (!effectInfoDic.TryGetValue(fileDirectory, out newFileDic))
            {
                Debug.LogFormat("<color=red>====cant find directory:{0}, {1}===</color>", fileDirectory, fileName);
                continue;
            }
            Debug.LogFormat("===find dic:{0} -> {1}", fileDirectory, newFileDic);

            //byte[] picData = getImageByte(filePathFull);

            //Texture2D tx = new Texture2D(300, 300);
            //tx.LoadImage(picData);

			string newFilePath = newFileDic + "/" + fileName;

			MagickImage image = new MagickImage (filePathFull);
            int oldWidth = image.Width;
            int oldHeight = image.Height;

            float scaleRate = 100;// fileScaleRate[fileDirectory];
            if (!fileScaleRate.TryGetValue(fileDirectory, out scaleRate))
            {
                Debug.LogError("=====rate err: " + scaleRate + "dir: " + fileDirectory);
                continue;
            }
            
            image.Quality = 100;
			image.Resize (new Percentage (scaleRate));
            image.Write (newFilePath);

            //Bitmap originBitmap = new Bitmap(filePathFull);
            //int oldWidth = originBitmap.Width;
            //int oldHeight = originBitmap.Height;
            //int width = (int)(oldWidth / 1.7);
            //int height = (int)(oldHeight / 1.7);
            //Bitmap outBitmap = new Bitmap(originBitmap, width, height);//主要代码，调用C#.NET库函数

            //Bitmap newImage = new Bitmap(newWidth, newHeight);
            //using (Graphics gr = Graphics.FromImage(newImage))
            //{
            //    gr.SmoothingMode = SmoothingMode.HighQuality;
            //    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //    gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            //}

            //outBitmap.Save(newFilePath);
            //System.IO.File.WriteAllBytes(newFilePath, tx.EncodeToPNG());

            Debug.Log(string.Format("<color=green>====缩图: {0} [{1}, {2}] => [{3}, {4}]]====</color>",
                       fileName, oldWidth, oldHeight, image.Width, image.Height));

        }
        EditorUtility.ClearProgressBar();
        //更新md5文件
        Debug.Log("================scale done================");
        WriteToFile(pathRoot + "/md5File", md5Dic);
    }

    /// <summary>  
    /// 根据图片路径返回图片的字节流byte[]  
    /// </summary>  
    /// <param name="imagePath">图片路径</param>  
    /// <returns>返回的字节流</returns>  
    private static byte[] getImageByte(string imagePath)
    {
        FileStream files = new FileStream(imagePath, FileMode.Open);
        byte[] imgByte = new byte[files.Length];
        files.Read(imgByte, 0, imgByte.Length);
        files.Close();

        return imgByte;

        //return tx.EncodeToPNG(); 
    }
    #endregion
#endif
}
