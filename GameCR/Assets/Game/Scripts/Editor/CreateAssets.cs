using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;
using Games.Module.Wars;
using Games.Module.Avatars;

namespace CC.Editors
{
	public partial class CreateAssets 
	{

		/*
		[MenuItem("Assets/Test/CreateAsset/MyData")]
		public static void CreateAsset_MyData()
		{
//			CreateAsset<MyData>();
		}
		
		[MenuItem("Assets/War/CreateAsset/FxData")]
		public static void CreateAsset_FxData()
		{
			CreateAsset<FxData>();
		}

		
		
		[MenuItem("Assets/War/CreateAsset/SkillData")]
		public static void CreateAsset_SkillData()
		{
			CreateAsset<SkillData>();
		}

		
		
		[MenuItem("Assets/War/CreateAsset/ProjectileData")]
		public static void CreateAsset_ProjectileData()
		{
			CreateAsset<ProjectileData>();
		}

		
		
		[MenuItem("Assets/War/CreateAsset/BuffData")]
		public static void CreateAsset_BuffData()
		{
			CreateAsset<BuffData>();
		}

		
		
		[MenuItem("Assets/War/CreateAsset/ShieldData")]
		public static void CreateAsset_ShieldData()
		{
			CreateAsset<ShieldData>();
		}
		
		
		[MenuItem("Assets/War/CreateAsset/HealShieldData")]
		public static void CreateAsset_HealShieldData()
		{
			CreateAsset<HealShieldData>();
		}
		
		[MenuItem("Assets/War/CreateAsset/HealData")]
		public static void CreateAsset_HealData()
		{
			CreateAsset<HealData>();
		}

		[MenuItem("Assets/War/CreateAsset/DamageData")]
		public static void CreateAsset_DamageData()
		{
			CreateAsset<DamageData>();
		}
		
		[MenuItem("Assets/War/CreateAsset/PropertyEffectData")]
		public static void CreateAsset_PropertyEffectData()
		{
			CreateAsset<PropertyEffectData>();
		}

		
		
		[MenuItem("Assets/War/CreateAsset/StateEffectData")]
		public static void CreateAsset_StateEffectData()
		{
			CreateAsset<StateEffectData>();
		}
		
		
		[MenuItem("Assets/War/CreateAsset/TextEffectData")]
		public static void CreateAsset_TextEffectData()
		{
			CreateAsset<TextEffectData>();
		}


		[MenuItem("Assets/War/CreateAsset/ChainData")]
		public static void CreateAsset_ChainData()
		{
			CreateAsset<ChainData>();
		}
		
		
		[MenuItem("Assets/War/CreateAsset/FallData")]
		public static void CreateAsset_FallData()
		{
			CreateAsset<FallData>();
		}
		
		[MenuItem("Assets/War/CreateAsset/SummonData")]
		public static void CreateAsset_SummonData()
		{
			CreateAsset<SummonData>();
		}
		
		[MenuItem("Assets/War/CreateAsset/FastArmData")]
		public static void CreateAsset_FastArmData()
		{
			CreateAsset<FastArmData>();
		}

*/



		//-------------------------------------------

		[MenuItem("Assets/Avatar/SpriteAnimationClip")]
		public static void CreateAsset_SpriteAnimationClip()
		{
			CreateAsset<SpriteAnimationClip>();
		}
		
		
		[MenuItem("Assets/Avatar/AvatarAction")]
		public static void CreateAsset_AvatarAction()
		{
			CreateAsset<AvatarAction>();
		}
		
		
		[MenuItem("Assets/Avatar/AvatarData")]
		public static void CreateAsset_AvatarData()
		{
			CreateAsset<AvatarData>();
		}
	}
}
