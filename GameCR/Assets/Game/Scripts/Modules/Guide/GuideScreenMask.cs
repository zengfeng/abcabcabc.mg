using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Guides
{
	public class GuideScreenMask : MonoBehaviour 
	{
		public Image image;
		public Texture2D texture;
		public Sprite sprite;

		public int width = 192;
		public int height = 128;

		public Color32 bgColor = new Color32(0, 0, 0, 175);
		public Color32 color = new Color32 (0, 0, 0, 0);

		public float radius = 10;
		public float feather = 2;
		public float lineWidth = 5;
		public float lineFeather = 2;

		public float skillButtonWidth = 10;
		public float skillButtonHeight = 10;

		public Vector2 ScreenToTexturePoint(Vector2 position)
		{
			position.x *= width * 1f / Screen.width;
			position.y *= height * 1f / Screen.height;

			return position;
		}

		public Vector2 WorldToTexturePoint(Vector3 position)
		{
			
			Vector2 point = Camera.main.WorldToScreenPoint (position);
			point = ScreenToTexturePoint(point);
			return point;
		}

		public Vector2 UGUIToTexturePoint(Vector3 position)
		{
			Vector2 point = RectTransformUtility.WorldToScreenPoint (Coo.uiCamera, position);
			point = ScreenToTexturePoint(point);
			return point;
		}

		public float WorldToTexturePixel(float worldVal)
		{
			Vector3 position = new Vector3(worldVal, 0, 0);
			Vector2 point = WorldToTexturePoint (position);
			return point.x;
		}


		void Start()
		{
			Init ();
		}

		public bool isInit;
		void Init()
		{
			if (isInit)
				return;
			isInit = true;

			if (image == null) image = GetComponent<Image> ();

			texture = new Texture2D (width, height, TextureFormat.ARGB32, false);
			sprite = texture.ToSprite ();
			image.sprite = sprite;
		}

		public void Reset()
		{
			Init ();
			texture.DrawBackground (bgColor);
		}

		public void DrawBG()
		{
			Show ();
			Reset ();
		}


		public void DrawCircle(Vector3 worldPosition)
		{
			Vector2 position = WorldToTexturePoint(worldPosition);
			//Debug.Log ("buildID=" + buildID + "  position=" + position + "  world=" + unit.transform.position + "  screen=" + Camera.main.ScreenToWorldPoint (unit.transform.position));
			texture.DrawCircle (position, radius, color, feather);
		}

		public void DrawBuild(int buildID)
		{
			UnitCtl unit = War.scene.GetBuild (buildID);
			Vector2 position = WorldToTexturePoint(unit.transform.position);
			//Debug.Log ("buildID=" + buildID + "  position=" + position + "  world=" + unit.transform.position + "  screen=" + Camera.main.ScreenToWorldPoint (unit.transform.position));
			texture.DrawCircle (position, radius, color, feather);
		}


		public void DrawSendArm(int from, int to, bool resetAndsHOW = true)
		{
			if (resetAndsHOW) 
			{
				Show ();
				Reset ();
			}
			DrawBuild (from);
			DrawBuild (to);

			UnitCtl unit = War.scene.GetBuild (from);
			Vector2 fromPoint = WorldToTexturePoint(unit.transform.position);

			unit =  War.scene.GetBuild (to);
			Vector2 toPoint = WorldToTexturePoint(unit.transform.position);

			texture.DrawLine (fromPoint, toPoint, lineWidth, lineFeather, color);
		}

		public void DrawUplevel(int buildId)
		{
			Show ();
			Reset ();
			DrawBuild (buildId);
		}


		public void DrawRect(Vector3 uguiWorldPosition)
		{
			Vector2 point = UGUIToTexturePoint (uguiWorldPosition);
			Rect rect = new Rect ();
			rect.width = skillButtonWidth;
			rect.height = skillButtonHeight;
			rect.x = point.x - rect.width * 0.5f;
			rect.y = point.y - rect.height * 0.5f;
			texture.DrawRect (rect.x, rect.y, rect.width, rect.height, color);
		}


		public void DrawDragSkillBuild(Vector3 uguiWorldPosition, int buildId)
		{
			Show ();
			Reset ();
			DrawBuild (buildId);


			DrawRect (uguiWorldPosition);

//			Vector2 fromPoint = UGUIToTexturePoint (uguiWorldPosition);
//			Vector2 toPoint = WorldToTexturePoint( War.scene.GetBuild (buildId).transform.position);
//			texture.DrawLine (fromPoint, toPoint, lineWidth, lineFeather, color);
		}



		public void DrawDragSkillCircle(Vector3 uguiFrom, Vector3 uguiTo, float radius)
		{
			Show ();
			Reset ();


			DrawRect (uguiFrom);

			Vector2 fromPoint = UGUIToTexturePoint (uguiFrom);
			Vector2 toPoint = UGUIToTexturePoint (uguiTo);

			texture.DrawCircle (toPoint, this.radius, color, feather);

//			texture.DrawLine (fromPoint, toPoint, lineWidth, lineFeather, color);
		}

		public void ResetAndShow()
		{
			Show ();
			Reset ();
		}


		public void Show()
		{
			gameObject.SetActive (true);
		}

		public void Hide()
		{
			gameObject.SetActive (false);
		}

	}
}