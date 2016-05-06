using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using CC.UI;

[ExecuteInEditMode]
[Serializable]
public class PrefabText : Text {

	public bool usePrefab = true;
	public GameObject prefabText;

	private GameObject _lastPrefabText = null;
	private bool _isValid = false;
	private Color _specialColor;
	private Color _originColor;
	private bool _useSpecialColor = false;

	void Start () {
		UpdateTextComponent();
	}
	
	void Update () {
#if UNITY_EDITOR
		if (_isValid)
		{
			_isValid = false;
			RemoveComponent();
			UpdateTextComponent();
		}
#endif
	}

	public void SetTextColor(Color c)
	{
		_useSpecialColor = true;
		_specialColor = c;
		color = c;
	}

	public void SetToOriginColor()
	{
		_useSpecialColor = false;
		color = _originColor;
	}

	void UpdateTextComponent()
	{
		if (usePrefab && prefabText != null)
		{
			var prefabTextComponent = prefabText.GetComponent<Text>();
			if (prefabTextComponent)
			{
				font = prefabTextComponent.font;
				fontSize = prefabTextComponent.fontSize;
				_originColor = prefabTextComponent.color;
				if (!_useSpecialColor)
					color = _originColor;
				else
					color = _specialColor;

                var prefabGradient = prefabText.GetComponent<CC.UI.Gradient>();
                if (prefabGradient)
                {
                    var selfGradient = GetComponent<CC.UI.Gradient>();
                    if (selfGradient == null)
                    {
                        selfGradient = gameObject.AddComponent<CC.UI.Gradient>();
                    }
                    selfGradient.topColor = prefabGradient.topColor;
                    selfGradient.bottomColor = prefabGradient.bottomColor;
                }

				var hasComponents = new Dictionary<Type, Component>();
				var components = GetComponents<Shadow>();
				foreach (var e in components)
				{
					if (!hasComponents.ContainsKey(e.GetType()))
						hasComponents.Add(e.GetType(), e);
				}

                var prefabHasComponents = new Dictionary<Type, Component>();
                var prefabComponents = prefabText.GetComponents<Shadow>();
                foreach (var e in prefabComponents)
                {
					if (!prefabHasComponents.ContainsKey(e.GetType()))
	                    prefabHasComponents.Add(e.GetType(), e);
                }

				Component compTemp;
                Component prefabComp;
                prefabHasComponents.TryGetValue(typeof(Outline), out prefabComp);
                if (prefabComp)
				{
                    var prefabOutline = (Outline)prefabComp;
					hasComponents.TryGetValue(typeof(Outline), out compTemp);
					Outline selfOutline = (Outline)compTemp;
					
					if (selfOutline == null)
					{
						selfOutline = gameObject.AddComponent<Outline>();
					}
					selfOutline.effectColor = prefabOutline.effectColor;
					selfOutline.effectDistance = prefabOutline.effectDistance;
				}

                prefabHasComponents.TryGetValue(typeof(Shadow), out prefabComp);
                if (prefabComp)
				{
                    var prefabShadow = (Shadow)prefabComp;
					hasComponents.TryGetValue(typeof(Shadow), out compTemp);
					Shadow selfShadow = (Shadow)compTemp;
					
					if (selfShadow == null)
					{
						selfShadow = gameObject.AddComponent<Shadow>();
					}
                    selfShadow.effectColor = prefabShadow.effectColor;
                    selfShadow.effectDistance = prefabShadow.effectDistance;
				}
			}
		}
	}

	public void RemoveComponent()
	{
		if (_lastPrefabText != prefabText && usePrefab == true)
		{
            var gradient = GetComponent<CC.UI.Gradient>();
            if (gradient)
            {
                DestroyImmediate(gradient);
            }

			var components = GetComponents<Shadow>();
			foreach (var e in components)
			{
				DestroyImmediate(e);
			}
			_lastPrefabText = prefabText;
		}
	}

#if UNITY_EDITOR
	void OnValidate ()
	{
		_isValid = true;
	}
#endif
}
