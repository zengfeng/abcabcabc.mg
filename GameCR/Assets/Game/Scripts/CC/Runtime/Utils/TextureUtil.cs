using UnityEngine;
using System.Collections;

public static class TextureUtil
{
	public static Sprite ToSprite(this Texture2D texture)
	{
		return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2( 0.5F,  0.5F));
	}


	public static Texture2D DrawBackground(this Texture2D texture, Color col)
	{
		int width = texture.width;
		int height = texture.height;

		for(int x = 0; x < width; x ++)
		{
			for(int y = 0; y < height; y ++)
			{
				//				Color color = new Color (Mathf.Lerp(0, 1, x * 1F / width), Mathf.Lerp(0, 1, y * 1F / height), 0, 1);
				texture.SetPixel (x, y, col);
			}
		}

		texture.Apply (false);
		return texture;
	}


	public static Texture2D DrawRect(this Texture2D texture, float px, float py, float w, float h, Color32 col)
	{
		int width = texture.width;
		int height = texture.height;

		int startX = (int) Mathf.Clamp (px, 0, texture.width);
		int startY = (int) Mathf.Clamp (py, 0, texture.height);

		int endX = (int)  Mathf.Clamp (px + w, 0, texture.width);
		int endY = (int)  Mathf.Clamp (py + h, 0, texture.height);


		int lengthX = endX-startX;
		int lengthY = endY-startY;

		Vector2 start = new Vector2 (startX, startY);

		Color[] pixels = texture.GetPixels (startX, startY, lengthX, lengthY,0);


		for(int x = 0; x < lengthX; x ++)
		{
			for(int y = 0; y < lengthY; y ++)
			{
				pixels[y*lengthX+x]=col;
			}
		}


		texture.SetPixels (startX, startY, lengthX, lengthY, pixels, 0);
		texture.Apply ();
		return texture;
	}


	public static Texture2D DrawCircle(this Texture2D texture, Vector2 origin, float radius, Color32 col, float feather = 0)
	{
		int width = texture.width;
		int height = texture.height;



		int startX = (int) Mathf.Clamp (origin.x - radius , 0, width - 1);
		int startY = (int) Mathf.Clamp (origin.y - radius, 0, height - 1);

		int endX = (int) Mathf.Clamp (origin.x + radius, 0, width - 1);
		int endY = (int) Mathf.Clamp (origin.y + radius, 0, height - 1);




		float rf = radius - feather;

		float r;
		for(int x = startX; x <=  endX; x ++)
		{
			for(int y = startY; y <= endY; y ++)
			{

				float xx = x - origin.x;
				float yy = y - origin.y;

				r = Mathf.Sqrt (xx * xx + yy * yy);
				if (r <= radius) 
				{
					Color32 color = texture.GetPixel(x, y);


					if (r < rf ) 
					{
						color = col;
					} 
					else
					{
						color = Color32.Lerp (col, color, (r - rf)  /  feather);
					}


					texture.SetPixel (x, y, color);
				}
			}
		}

		texture.Apply (false);

		return texture;
	}




	public static Texture2D DrawLine(this Texture2D texture, Vector2 from, Vector2 to, float w, float f, Color32 col )
	{
		bool stroke = false;
		float strokeWidth = 0;
		Color strokeCol = Color.white;

		w = Mathf.Round (w);
		strokeWidth = Mathf.Round (strokeWidth);

		float sqrW = w*w;
		float sqrF = f * f;
		float sqrFS = (w - f) * (w - f);

		float extent = w + strokeWidth;


		strokeWidth = strokeWidth/2;
		float strokeInner = (w-strokeWidth)*(w-strokeWidth);
		float strokeOuter = (w+strokeWidth)*(w+strokeWidth);
		float strokeOuter2 = (w+strokeWidth+1)*(w+strokeWidth+1);

		int startX = (int) Mathf.Clamp (Mathf.Min (from.x,to.x) - extent,0,texture.width);
		int startY = (int) Mathf.Clamp (Mathf.Min (from.y,to.y) - extent,0,texture.height);

		int endX = (int)  Mathf.Clamp (Mathf.Max (from.x,to.x) + extent,0,texture.width);
		int endY = (int)  Mathf.Clamp (Mathf.Max (from.y,to.y) + extent,0,texture.height);


		int lengthX = endX-startX;
		int lengthY = endY-startY;

		Vector2 start = new Vector2 (startX, startY);

		Color[] pixels = texture.GetPixels (startX, startY, lengthX, lengthY,0);


		Color c;
		Color pc;

		for(int x = 0; x < lengthX; x ++)
		{
			for(int y = 0; y < lengthY; y ++)
			{


				Vector2 p = new Vector2 (x,y) + start;
				Vector2 center = p + new Vector2(0.5f,0.5f);
				float dist = (center-NearestPointStrict(from,to,center)).sqrMagnitude;//The squared distance from the center of the pixels to the nearest point on the line

				if (dist<=strokeOuter2)
				{
					if (dist < sqrFS ) 
					{
						c = col;
					} 
					else
					{
						c = pixels [y * lengthX + x];
						c = Color32.Lerp (col, c, (dist - sqrFS)  /  sqrF);
					}

					pixels[y*lengthX+x]=c;
				}


			}
		}


		texture.SetPixels (startX, startY, lengthX, lengthY, pixels, 0);
		texture.Apply ();
		return texture;
	}


	static Vector2 NearestPointStrict(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
	{
		Vector2 fullDirection = lineEnd-lineStart;
		Vector2 lineDirection = fullDirection.normalized;
		float closestPoint = Vector2.Dot((point-lineStart),lineDirection)/Vector2.Dot(lineDirection,lineDirection);
		return lineStart+(Mathf.Clamp(closestPoint,0.0f,fullDirection.magnitude)*lineDirection);
	}


	public enum Samples
	{
		None,
		Samples2,
		Samples4,
		Samples8,
		Samples16,
		Samples32,
		RotatedDisc
	}

	static Vector2[] Sample (Vector2 p, Samples numSamples)
	{
		switch (numSamples) {
		case Samples.None:
			return new Vector2[] {
				p + new Vector2 (0.5f, 0.5f) 
			};

		case Samples.Samples2:
			return new Vector2[] { 
				p + new Vector2 (0.25f, 0.5f),
				p + new Vector2 (0.75f, 0.5f),
			};
		case Samples.Samples4: 
			return new Vector2[] { 
				p + new Vector2 (0.25f, 0.5f),
				p + new Vector2 (0.75f, 0.5f),
				p + new Vector2 (0.5f, 0.25f),
				p + new Vector2 (0.5f, 0.75f)

			};
		case Samples.Samples8: 
			return new Vector2[] { 


				p + new Vector2 (0.25f, 0.5f),
				p + new Vector2 (0.75f, 0.5f),
				p + new Vector2 (0.5f, 0.25f),
				p + new Vector2 (0.5f, 0.75f),

				p + new Vector2 (0.25f, 0.25f),
				p + new Vector2 (0.75f, 0.25f),
				p + new Vector2 (0.25f, 0.75f),
				p + new Vector2 (0.75f, 0.75f)

			};
		case Samples.Samples16: 
			return new Vector2[] { 

				p + new Vector2 (0f, 0f),
				p + new Vector2 (0.3f, 0f),
				p + new Vector2 (0.7f, 0f),
				p + new Vector2 (1f, 0f),

				p + new Vector2 (0f, 0.3f),
				p + new Vector2 (0.3f, 0.3f),
				p + new Vector2 (0.7f, 0.3f),
				p + new Vector2 (1f, 0.3f),

				p + new Vector2 (0f, 0.7f),
				p + new Vector2 (0.3f, 0.7f),
				p + new Vector2 (0.7f, 0.7f),
				p + new Vector2 (1f, 0.7f),

				p + new Vector2 (0f, 1f),
				p + new Vector2 (0.3f, 1f),
				p + new Vector2 (0.7f, 1f),
				p + new Vector2 (1f, 1f)
			};
		case Samples.Samples32:
			return new Vector2[] { 

				p + new Vector2 (0f, 0f),
				p + new Vector2 (1f, 0f),
				p + new Vector2 (0f, 1f),
				p + new Vector2 (1f, 1f),

				p + new Vector2 (0.2f, 0.2f),
				p + new Vector2 (0.4f, 0.2f),
				p + new Vector2 (0.6f, 0.2f),
				p + new Vector2 (0.8f, 0.2f),

				p + new Vector2 (0.2f, 0.4f),
				p + new Vector2 (0.4f, 0.4f),
				p + new Vector2 (0.6f, 0.4f),
				p + new Vector2 (0.8f, 0.4f),

				p + new Vector2 (0.2f, 0.6f),
				p + new Vector2 (0.4f, 0.6f),
				p + new Vector2 (0.6f, 0.6f),
				p + new Vector2 (0.8f, 0.6f),

				p + new Vector2 (0.2f, 0.8f),
				p + new Vector2 (0.4f, 0.8f),
				p + new Vector2 (0.6f, 0.8f),
				p + new Vector2 (0.8f, 0.8f),



				p + new Vector2 (0.5f, 0f),
				p + new Vector2 (0.5f, 1f),
				p + new Vector2 (0f, 0.5f),
				p + new Vector2 (1f, 0.5f),

				p + new Vector2 (0.5f, 0.5f)

			};
		case Samples.RotatedDisc:
			return new Vector2[] { 

				p + new Vector2 (0f, 0f),
				p + new Vector2 (1f, 0f),
				p + new Vector2 (0f, 1f),
				p + new Vector2 (1f, 1f),

				p + new Vector2 (0.5f, 0.5f) + new Vector2 (0.258f, 0.965f),//Sin (75°f) && Cos (75°f)
				p + new Vector2 (0.5f, 0.5f) + new Vector2 (-0.965f, -0.258f),
				p + new Vector2 (0.5f, 0.5f) + new Vector2 (0.965f, 0.258f),
				p + new Vector2 (0.5f, 0.5f) + new Vector2 (0.258f, -0.965f)
			};

			break;
		}

		return new Vector2[] {
			p + new Vector2 (0.5f, 0.5f) 
		};
	}


}
