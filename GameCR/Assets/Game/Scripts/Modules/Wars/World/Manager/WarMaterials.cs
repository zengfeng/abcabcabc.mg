using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime;


namespace Games.Module.Wars
{

	public enum WarMaterialsType
	{

		[HelpAttribute("状态--默认")]
		stateDefault,

		[HelpAttribute("状态--冰冻")]
		stateFreeze,


		[HelpAttribute("操作--选择")]
		operateSelect,
		operateSelect_Own,
		operateSelect_Enemy,
	}

	public partial class WarMaterials : MonoBehaviour 
	{
		/** 状态--默认 */
		public Material stateDefault;
		/** 状态--冰冻 */
		public Material stateFreeze;
		/** 操作--选择 */
		public Material operateSelect;
		public Material operateSelect_Own;
		public Material operateSelect_Enemy;

		void Awake()
		{
			War.materials = this;
		}


		public Material GetMaterial(WarMaterialsType type)
		{
			switch(type)
			{
			/** 状态--默认 */
			case WarMaterialsType.stateDefault:
				return stateDefault;
				break;

			/** 状态--冰冻 */
			case WarMaterialsType.stateFreeze:
				return stateFreeze;
				break;

			/** 操作--选择 */
			case WarMaterialsType.operateSelect:
				return operateSelect;
				break;
			case WarMaterialsType.operateSelect_Own:
				return operateSelect_Own;
				break;
			case WarMaterialsType.operateSelect_Enemy:
				return operateSelect_Enemy;
				break;

			default:
				return stateDefault;
				break;

			}
		}

    }


}
