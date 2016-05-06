using System;
namespace Games.Module.Props
{
	/** 属性类型 */
    public enum PropType
	{
		/** 附加具体值 */
		Add = 1,
		/** 附加百分比 */
		Per,
		/** 最终值 */
		Final,
		/** 附加初始百分比 */
		InitPer,
		/** 初始值 */
		Init,
		/** 状态 */
		State = 6
	}
}

