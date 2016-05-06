using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent (typeof(Image)) ]
public class UIFrameAnimation : MonoBehaviour {

	public List<Sprite> frames = new  List<Sprite>();
	public float deltaTime = 0;
	private Image _image;
	private float _lastTime = 0;
	private int _currentFrame = 0;

	void Awake () {
		_image = GetComponent<Image>();
		_lastTime = Time.time;
	}
	
	void Update () {
		if (Time.time - _lastTime >= deltaTime && frames.Count > 0)
		{
			_currentFrame = (_currentFrame + 1) % frames.Count;
			_image.sprite = frames[_currentFrame];
			_lastTime = Time.time;
		}
	}
}
