using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction : MonoBehaviour
	{
		public int stepIndex;
		public string describe;
		public GuideStepData data;

		protected virtual void OnDestroy()
		{
			if(data != null && data.completeType == GuideStepCompleteType.ClickScreenCall)
			{
				Guide.signal.onClickScreen -= NextFrameComplete;
			}

			StopAllCoroutines();
		}

		public virtual void SetData(GuideStepData data)
		{
			this.data = data;
			stepIndex = data.stepIndex;
			describe = data.describe;
			data.action = this;
		}

		/** 进入 */
		public virtual void Enter()
		{
			CheckComplete();
		}

		/** 完成 */
		[ContextMenu("End")]
		public virtual void End()
		{
			if(data.parent != null)
			{
				data.parent.action.OnChildEnd(data);
			}

			War.service.C_RecordSubGuideStep_0x119 (data.stepIndex);

			Close();
		}

		/** 关闭 */
		public virtual void Close()
		{
			if(data.completeType == GuideStepCompleteType.ClickScreenCall || data.completeType == GuideStepCompleteType.ClickScreenCall_Ro_WaitSecond)
			{
				Guide.signal.onClickScreen -= NextFrameComplete;
			}
			StopAllCoroutines();
			Destroy(this);


		}

		public virtual void OnChildEnd(GuideStepData childData)
		{
		}
		
		/** 检测完成 */
		protected virtual void CheckComplete()
		{
			switch(data.completeType)
            {
            case GuideStepCompleteType.ClickScreenCall:
				Guide.signal.onClickScreen += NextFrameComplete;
				break;
			case GuideStepCompleteType.Immediately:
				End();
				break;
			case GuideStepCompleteType.NextFrame:
				NextFrameComplete();
				break;
			case GuideStepCompleteType.WaitSecond:
                    WaitSecondComplete();
				break;
            }

            if(data.completeType == GuideStepCompleteType.ClickScreenCall_Ro_WaitSecond)
            {
                WaitSecondComplete();
                Guide.signal.onClickScreen += NextFrameComplete;
            }
		}

		/** 等待X秒完成 */
		protected virtual void WaitSecondComplete()
		{
			StartCoroutine(OnWaitSecondComplete());
		}

		protected virtual IEnumerator OnWaitSecondComplete()
		{
			yield return new WaitForSeconds(data.completeWaitSecond);
			End();
		}

		/** 下一帧完成 */
		protected virtual void NextFrameComplete()
		{
			StartCoroutine(OnNextFrameComplete());
		}
		
		protected virtual IEnumerator OnNextFrameComplete()
		{
			yield return new WaitForEndOfFrame();
			End();
		}

		public virtual void NextFrameEnd()
		{
			NextFrameComplete ();
		}
	}
}