using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CC.UI
{
	
    [AddComponentMenu("UI/Effects/Gradient")]
    public class Gradient : BaseMeshEffect
    {
        [SerializeField]
        public Color32 topColor = Color.white;
        [SerializeField]
        public Color32 bottomColor = Color.black;

#if UNITY_5_2_2 || UNITY_5_2_3 || UNITY_5_3
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!this.IsActive())
				return;
			
			List<UIVertex>  vertexList = new List<UIVertex>();
			vh.GetUIVertexStream(vertexList);
			
			ModifyVertices(vertexList);
			
			vh.Clear();
			vh.AddUIVertexTriangleStream(vertexList);
		}

		public void ModifyVertices(List<UIVertex> vertexList)
		{
			if (!IsActive())
			{
				return;
			}
			
			int count = vertexList.Count;
			if (count > 0)
			{
				float bottomY = vertexList[0].position.y;
				float topY = vertexList[0].position.y;
				for (int i = 1; i < count; i++)
				{
					float y = vertexList [i] .position.y;
					if (y > topY)
					{
						topY = y;
					}
					else if (y < bottomY)
					{
						bottomY = y;
					}
				}
				
				float uiElementHeight = topY - bottomY;
				
				for (int i = 0; i < count; i++)
				{
					UIVertex uiVertex = vertexList [i] ;
					uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
					vertexList [i] = uiVertex;
				}
			}
		}

		private void ChangeColor( ref List<UIVertex> verList, int index, Color color)
		{
			UIVertex temp = verList[index];
			temp.color = color;
			verList[index] = temp;
		}
#else

        public override void ModifyMesh(Mesh mesh)
        {
            if (!IsActive())
            {
                return;
            }

            Vector3[] vertices = mesh.vertices;
            int count = mesh.vertexCount;
            if (count > 0)
            {
                float bottomY = vertices[0].y;
                float topY = vertices[0].y;

                for (int i = 1; i < count; i++)
                {
                    float y = vertices[i].y;
                    if (y > topY)
                    {
                        topY = y;
                    }
                    else if (y < bottomY)
                    {
                        bottomY = y;
                    }
                }

                float uiElementHeight = topY - bottomY;

                List<Color> inColors = new List<Color>();
                for (int i = 0; i < count; i++)
                {
                    Color color = Color32.Lerp(bottomColor, topColor, (vertices[i].y - bottomY) / uiElementHeight);
                    inColors.Add(color);
                }

                mesh.SetColors(inColors);
            }
        }
		
#endif
    }
}
