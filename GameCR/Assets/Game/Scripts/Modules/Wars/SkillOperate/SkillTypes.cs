using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	
	[HelpAttribute("技能操作方式")]
	public enum SkillOperateType
	{
		[HelpAttribute("被动")]
		Passive,

		[HelpAttribute("立刻生效")]
		Immediately,
		
		[HelpAttribute("选择目标")]
		SelectUnit,
		
		[HelpAttribute("选择圆形区域")]
		SelectCircle,
		
		[HelpAttribute("选择方向")]
		SelectDirection
	}

	
	
	[HelpAttribute("技能类型")]
	public enum SkillType
	{
		[HelpAttribute("普通")]
		Normal,
		
		[HelpAttribute("建筑升级")]
		Build_Uplevel = 10,

		[HelpAttribute("替换建筑")]
		Build_Replace = 11,
		
		[HelpAttribute("附加建筑功能")]
		Build_Attach = 12,
	}

	
	[HelpAttribute("技能操作状态")]
	public enum SkillOperateState
	{

		[HelpAttribute("置空")]
		Empty,

		[HelpAttribute("正常")]
		Normal,
		
		[HelpAttribute("选中")]
		Selected,
		
		[HelpAttribute("拖动—按钮形态")]
		Drag_Button,
		
		[HelpAttribute("拖动—物件形态")]
		Drag_Object,

	}

	
	
	[HelpAttribute("选择单位图标")]
	public enum SkillOperateSelectUnitIconType
	{
		
		[HelpAttribute("瞄准")]
		Aim,
		
		[HelpAttribute("攻击")]
		Attack,
		
		[HelpAttribute("升级")]
		Uplevel,
		
		[HelpAttribute("锤子")]
		Change,

		[HelpAttribute("加")]
		Add,
		
	}

}
