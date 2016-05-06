using UnityEngine;
using System.Collections;
using CC.Module.Menu;
using CC.Runtime;

public class BlurBG : MonoBehaviour 
{
	public GaussianBlurImage blurImage;
	public Transform backgroundMask;


	public void OnOpenMenu(MenuConfig config)
	{
		if (blurImage != null)
		{
			blurImage.AdvanceBlur();
		}

		if (backgroundMask != null)
		{
			backgroundMask.gameObject.SetActive(true);
		}
	}
	
	public void OnCloseMenu(MenuConfig config)
	{
		if (blurImage != null && blurImage.gameObject.activeSelf)
		{
			blurImage.BackBlur();
		}

		if (backgroundMask != null)
		{
			backgroundMask.gameObject.SetActive(false);
		}
	}

	public void Close()
	{
		if (blurImage != null && blurImage.gameObject.activeSelf)
		{
			blurImage.BackBlur();
		}

		
		if (backgroundMask != null)
		{
			backgroundMask.gameObject.SetActive(false);
		}
	}

	public void OnClickMask()
	{
		if(Coo.menuManager.currentWindowId != -1)
		{
			Coo.menuManager.CloseMenu(Coo.menuManager.currentWindowId);
		}

	}

}
