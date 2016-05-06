using UnityEngine;
using System.Collections;

public class AtkRadius : MonoBehaviour 
{
	public Transform 		rotationNode;
	public Transform 		sizeNode;
	public SpriteRenderer 	spriteNode;
	public bool 		rotation = true;
	public float 		rotationSpeed = 25f;
	public float		radius = 1f;
	private float		_radius = 1f;
	public float		radiusSpeed = 10f;
	public Color		color 		= Color.gray;
	private Color		_color 		= Color.white;
	public float 		colorSpeed = 2;
	public int 			level = 1;
	public Sprite[] 	textures;

	void Start () 
	{
		if(rotationNode == null) 	rotationNode 	= transform.FindChild("Rotation");
		if(sizeNode == null)		sizeNode		= transform.FindChild("Rotation/Size");
		if(spriteNode == null)		spriteNode		= transform.FindChild("Rotation/Size/Sprite").GetComponent<SpriteRenderer>();
		SetLevel(level);
	}

	void Update () 
	{
		if(rotation)
		{
			Vector3 angle = rotationNode.localEulerAngles;
			angle.y += rotationSpeed * Time.deltaTime;
			rotationNode.localEulerAngles = angle;
		}

		if(_radius != radius)
		{
			_radius = radius;
//			_radius = Mathf.Lerp(_radius, radius, radiusSpeed * Time.deltaTime);
//			if(Mathf.Abs(radius - _radius) < 0.01) _radius = radius;
			sizeNode.transform.localScale = Vector3.one * _radius;
		}

		if(_color != color)
		{
			_color = Color.Lerp(_color, color, colorSpeed * Time.deltaTime);
			spriteNode.color = _color;
		}
	}

	public void SetLevel(int level)
	{
		this.level = level;
		if(spriteNode != null)
		{
			spriteNode.sprite = textures[level - 1];
		}
	}

	public void ChangeLegion( Color color, float radius)
	{

		this.color = color;
		StartCoroutine(OnChangeLegionCoroution(radius));
	}

	IEnumerator OnChangeLegionCoroution(float finalRadius)
	{
//		radius = 0;
//		yield return new WaitForSeconds(0.5f);
		yield return new WaitForEndOfFrame();
		radius = finalRadius;
	}

	[ContextMenu("SetRed")]
	public void SetRed()
	{
		ChangeLegion(Color.red, 5f);
	}

	
	[ContextMenu("SetGreen")]
	public void SetGreen()
	{
		ChangeLegion(Color.green, 5f);
	}
}
