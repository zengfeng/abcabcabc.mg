using UnityEngine;
using System.Collections;
using CC.Runtime;

namespace Games.Module.Wars
{
	
	public class UnitAnchorName
	{
		public const string Self = "Anchor-Self";
		public const string UI = "Anchor-UI";
		public const string UICanva = "War_Scene_Canvas";
		public const string ImageSendArm = "Anchor-Image_SendArm";
		public const string ImageUplevel = "Anchor-Image_Uplevel";
		public const string EffectUplevel = "Anchor-Effect_Uplevel";
		public const string EffectFire = "Anchor-Effect_Fire";
		public const string EffectDeath = "Anchor-Effect_Death";

		public const string Angle = "Anchor-Angle";
	}

	public class UnitAnchor : EBehaviour 
	{
		#region anchor
		[HideInInspector]
		public Transform anchorUI;
		[HideInInspector]
		public Transform anchorAngle;
		[HideInInspector]
		public Transform anchorUICanva;
		[HideInInspector]
		public Transform anchorImageSendArm;
		[HideInInspector]
		public Transform anchorImageUplevel;
		[HideInInspector]
		public Transform anchorEffectUplevel;
		[HideInInspector]
		public Transform anchorEffectFire;
		[HideInInspector]
		public Transform anchorEffectDeath;
		#endregion
		
		protected override void OnAwake ()
		{
			base.OnAwake ();
			
			anchorAngle = transform.FindChild(UnitAnchorName.Angle);
			anchorUI = transform.FindChild(UnitAnchorName.UI);
			anchorImageSendArm = transform.FindChild(UnitAnchorName.ImageSendArm);
			anchorImageUplevel = transform.FindChild(UnitAnchorName.ImageUplevel);
			anchorEffectUplevel = transform.FindChild(UnitAnchorName.EffectUplevel);
			anchorEffectFire = transform.FindChild(UnitAnchorName.EffectFire);
			anchorEffectDeath = transform.FindChild(UnitAnchorName.EffectDeath);
			if(anchorUI != null) anchorUICanva = transform.FindChild(UnitAnchorName.UICanva);

		}

		virtual public Transform GetAnchor(string name)
		{
			switch(name)
			{
			case UnitAnchorName.Self:
				return transform;
			case UnitAnchorName.Angle:
				return anchorAngle;
			case UnitAnchorName.UI:
				return anchorUI;
			case UnitAnchorName.ImageSendArm:
				return anchorImageSendArm;
			case UnitAnchorName.ImageUplevel:
				return anchorImageUplevel;
			case UnitAnchorName.EffectUplevel:
				return anchorEffectUplevel;
			case UnitAnchorName.EffectFire:
				return anchorEffectFire;
			case UnitAnchorName.EffectDeath:
				return anchorEffectDeath;
			case UnitAnchorName.UICanva:
				if(anchorUI != null)
				{
					Coo.assetManager.Load(WarRes.SceneCanvas, (string resname, System.Object obj) => {
						GameObject go =(GameObject) GameObject.Instantiate(obj as UnityEngine.Object);
						go.name = name;
						go.transform.SetParent(anchorUI);
						go.transform.localPosition = Vector3.zero;
						anchorUICanva = go.transform;
					});
				}
				return anchorUICanva;
			}
			return transform;
		}

	}
}