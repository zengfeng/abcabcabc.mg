using UnityEngine;
using System.Collections;

namespace CC.Runtime.Utils
{
	public class ReorderParticle : MonoBehaviour {

		public ParticleSystem[] upLayers;
	    public Renderer[] upLayerRenderers;

		// Use this for initialization
		void Start () {
			if (upLayers != null)
			{
				foreach (ParticleSystem ps in upLayers)
				{
	                if (ps != null)
					{
					    ps.GetComponent<Renderer>().sortingOrder = 3;
					}
				}
			}

	        if (upLayerRenderers != null)
	        {
	            foreach (Renderer renderer in upLayerRenderers)
	            {
	                if (renderer != null)
					{
						Debug.Log("ParticleRenderer pre" + renderer.sortingLayerID + " " + renderer.sortingOrder);
						renderer.sortingOrder = 1;
						Debug.Log("ParticleRenderer post" + renderer.sortingLayerID + " " + renderer.sortingOrder);

					}
				}
	        }
		}
	}
}