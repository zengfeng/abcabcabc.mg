
using System;
using System.Collections.Generic;

public static class DictionaryUtil
{

	public static void Sort<T>(this Dictionary<int, T> dictionary)
	{
		try
		{
			List<int> sortList = new List<int>();
			
			Dictionary<int, T> tempDictionary = new Dictionary<int, T>();
			
			foreach (int key in dictionary.Keys)
			{
				sortList.Add(key);
				
				tempDictionary.Add(key, dictionary[key]);
			}
			
			int flag = 1;
			
			int i, j;
			
			int itemCount = sortList.Count;
			
			int itemTemp;
			
			for (i = 1; i < itemCount && flag == 1; i++)
			{
				flag = 0;
				
				for (j = 0; j < itemCount - i; j++)
				{
					int countfore = sortList[j];
					
					int countback = sortList[j + 1];
					
					if (countfore > countback)
					{
						flag = 1;
						
						itemTemp = sortList[j];
						
						sortList[j] = sortList[j + 1];
						
						sortList[j + 1] = itemTemp;
					}
				}
			}
			dictionary.Clear();
			
			for (int n = 0; n < itemCount; n++)
			{
				foreach (int tempKey in tempDictionary.Keys)
				{
					int value = sortList[n];
					
					if (tempKey.Equals(value))
					{
						if (!dictionary.ContainsKey(tempKey))
						{
							dictionary.Add(tempKey, tempDictionary[tempKey]);
						}
					}
				}
			}
		}
		catch { }
	}
}