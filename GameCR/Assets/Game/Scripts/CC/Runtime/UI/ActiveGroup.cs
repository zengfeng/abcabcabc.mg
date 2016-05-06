using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class ActiveGroup : MonoBehaviour {

	private Dictionary<int, ActiveButton> _activeButtons = new Dictionary<int, ActiveButton>();
	private LuaFunction _callback;

	private ActiveButton _select = null;
	public ActiveButton Select
	{
		get
		{
			return _select;
		}
		set
		{
			foreach (ActiveButton btn in _activeButtons.Values)
			{
				if (value != btn)
					btn.OnUnActive();
			}
			_select = value;
			_select.OnActive();

			if (_callback != null)
				_callback.Call(_select.uid);
		}
	}

	public void SelectByUid(int uid)
	{
		if (_activeButtons.ContainsKey(uid))
		{
			Select = _activeButtons[uid];
		}
	}

	public void AddActiveButton(ActiveButton button)
	{
		if (!_activeButtons.ContainsKey(button.uid))
		{
			_activeButtons.Add(button.uid, button);
		}
		else
		{
			_activeButtons[button.uid] = button;
		}
	}

	public void SetChangeCallback(LuaFunction func)
	{
		_callback = func;
	}
}
