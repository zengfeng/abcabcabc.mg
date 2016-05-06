using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using CC.UI;

namespace CC.Module.DebugLog
{
    public class GMInfoView : DebugBaseView
    {
		public MultipleTextList list = new MultipleTextList();
		public GMInfoCell gmCell;
        private List<GMInfoVO> vos = new List<GMInfoVO>();

        void Start()
        {

            TextAsset ta = Resources.Load<TextAsset>("Config/gm") as TextAsset;
            string text = ta.text;
            StringReader reader = new StringReader(text);
			reader.ReadLine();
			reader.ReadLine();
            while (true)
            {
                string str = reader.ReadLine();
                if (str == null)
                {
                    break;
                }

                string[] csv = str.Split(';');
                GMInfoVO vo = new GMInfoVO();
                vo.name = csv [0];
                vo.enPart = csv [1];
                vo.numPart = csv [2];
                vos.Add(vo);
            }


            foreach (GMInfoVO vo in vos)
            {
				GameObject cellObj = GameObject.Instantiate(gmCell.gameObject) as GameObject;

				cellObj.SetActive(true);
				list.Add(cellObj.GetComponent<RectTransform>());

				
				GMInfoCell cell = cellObj.GetComponent<GMInfoCell>();
				cell.Vo = vo;
                cell.updateView();
            }
        }
    }
}

