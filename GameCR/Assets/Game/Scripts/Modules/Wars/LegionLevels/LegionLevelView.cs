using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Games.Module.Wars
{

	public class LegionLevelView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public LegionLevelPropPanel propPanel;

		public Image colorImage;
		public Text  levelText;

		public LegionData legionDta;
		public LegionLevelData legionLevelData;

		void Start () 
		{
		
		}

		private float _exp = -1;
		private int _level = -1;
		void Update () 
		{
			if(legionLevelData == null) return;

			if(_exp != legionLevelData.exp)
			{
				_exp 					= legionLevelData.exp;
				colorImage.fillAmount 	= legionLevelData.maxExp == 0 ? 1 : Mathf.Max(0, Mathf.Min(1, legionLevelData.exp / legionLevelData.maxExp));
			}

			
			if(_level != legionLevelData.Level)
			{
				_level 			= legionLevelData.Level;
				levelText.text 	= legionLevelData.Level + "";

				OnUplevel();
			}

			
//			levelText.text 	= legionLevelData.Level + "(" + legionLevelData.exp +"/" + legionLevelData.maxExp + ")";

		}


		public void OnPointerDown (PointerEventData eventData)
		{
			propPanel.Show();
		}

		public void OnPointerUp (PointerEventData eventData)
		{
			propPanel.Hide();
		}

		bool _isFirst = true;
		void OnUplevel()
		{
			if(_isFirst)
			{
				_isFirst = false;
				return;
			}

//			if(legionLevelData.legionData.legionId != War.ownLegionID)
//			{
//				return;
//			}

			StopAllCoroutines();
			StartCoroutine(ShowPropPanel());
		}

		IEnumerator ShowPropPanel()
		{
			propPanel.Show();
			yield return new WaitForSeconds(3F);
			propPanel.Hide();
		}



		public void SetData(LegionData legionDta)
		{
			if(legionDta != null)
			{
				this.legionDta 			= legionDta;
				this.legionLevelData 	= legionDta.levelData;

				propPanel.data = this.legionLevelData;

				Show();
			}
			else
			{
				Hide();
			}
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			StopAllCoroutines();
			gameObject.SetActive(false);
		}

	}
}