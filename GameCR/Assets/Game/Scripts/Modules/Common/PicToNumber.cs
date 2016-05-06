using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime;
using System.Collections.Generic;



namespace Games.Module.Common
{
    public class PicToNumber : MonoBehaviour
    {
        public Sprite[] picSp = new Sprite[10];
        public int numberCurent = 0;
        private int loadCount = 0;
        private bool isShow = false;
        public string preImgName = "h_";
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < 10; i ++ )
            {
                string filename = "Image/Number/" + preImgName + i ;
                Coo.assetManager.Load(filename, onLoadDone, typeof(Sprite));
            }
        }

        void onLoadDone(string filename, System.Object obj)
        {
            loadCount++;
            string strNum = filename.Substring(filename.Length - 1, 1);
            int num = int.Parse(strNum);
            Debug.Log("====" + filename + "===: " + num + "---: " + obj);
            Sprite sp = obj as Sprite;
            picSp[num] = sp;
        }

        // Update is called once per frame
        void Update()
        {
            if (isShow == true && loadCount == picSp.Length)
            {
                isShow = false;
                List<int> numList = new List<int>();
                while(true)
                {
                    int num = numberCurent % 10;
                    numList.Add(num);
                    numberCurent = numberCurent / 10;
                    if (numberCurent <= 0)
                    {
                        break;
                    }
                }
                int idx = 1;
                for (int i = numList.Count - 1; i >= 0; -- i)
                {
                    Debug.Log("=======: " + i );
                    int num = numList[i];
                    if (num > picSp.Length)
                    {
                        continue;
                    }
                    
                    GameObject obj = new GameObject("number_" + num);
                    obj.transform.SetParent(this.gameObject.transform);
                    obj.transform.localScale = Vector3.one;
                    obj.transform.localPosition = new Vector3(0, 0, -100);
                   
                    Image imgNum = obj.AddComponent<Image>();
                    imgNum.sprite = picSp[num];
                    imgNum.SetNativeSize();
                    RectTransform rectTransform = (RectTransform)imgNum.gameObject.transform;
                    rectTransform.localPosition = new Vector2(imgNum.rectTransform.sizeDelta.x / 2 * idx, 0f);
                    idx++;
                }
            }
        }

        public void setNumber(int number)
        {
            Debug.Log("==========setNumber=============");
            numberCurent = 0;
            isShow = true;
            numberCurent = number;
        }
       
    }
}