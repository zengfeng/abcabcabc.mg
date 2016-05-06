using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using System;

namespace CC.Module.Loads
{
	public class Loader 
	{
		public Action<Loader> sDone;
		public Action<Loader> sCancel;
		/** (float progress, int index, int count, string file) */
		public Action<float, int, int, string> sProgress;
		public int uid = -1;
		public object bindData;

		public List<string> list = new List<string>();
		public int index = 0;
		public int count = 0;
		public int addIndex = 0;
		public int addCount = 0;
		public bool isShowFile = true;
		private bool _cancel;


		public void Begin()
		{
			_cancel = false;
			count = list.Count;
			index = 0;

			if(index < count)
			{
				Load();
			}
			else
			{
				Done();
			}
		}

		private void Load()
		{
			if(sProgress != null) sProgress((float)(index + addIndex) / (float)(count + addCount), index + 1 + addIndex, count + addCount, isShowFile ? list[index] : String.Empty);
			Coo.assetManager.LoadAsync(list[index], OnLoadHandler);
		}

		private void OnLoadHandler(string path, System.Object obj)
		{
			if(uid > 0) Coo.menuManager.OnPreloadFile(uid, path, obj);
			index ++;
			if(_cancel) return;
			if(index < count)
			{
				Load();
			}
			else
			{
				if(sProgress != null) sProgress(1.0f, index + 1 + addIndex, count + addCount, String.Empty);
				Done();
			}
		}

		private void Done()
		{
			if(sDone != null) sDone(this);
		}

		public void Cancel()
		{
			_cancel = true;
			if(sCancel != null) sCancel(this);
		}
	}
}
