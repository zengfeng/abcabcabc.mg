using UnityEngine;
using System.Collections;

namespace CC.Module.Loads
{
	public class ProgressPanel : MonoBehaviour
	{
		public Loader loader;
		public string state="";
		
		
		virtual public void SetLoader(Loader loader)
		{
			this.loader = loader;
		}

		virtual public void SetState(string str)
		{
			state = str;
		}

		virtual public void SetProgress(float progress, int index, int count, string file)
		{

		}

		virtual public void Close(Loader loader)
		{
			Close();
		}

		virtual public void Close()
		{
//			GameObject.Destroy(gameObject);
			gameObject.SetActive(false);
			loader = null;
		}

		virtual public void Show()
		{
			gameObject.SetActive(true);
			(gameObject.transform as RectTransform).SetAsLastSibling();
		}

	}
}
