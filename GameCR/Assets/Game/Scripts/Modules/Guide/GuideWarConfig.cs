using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	public class GuideWarConfig
	{
		public bool guide 				= false;

		public bool lockGuide 			= true;


		public bool enableSendArm 		= true;
		public bool enableUplevel 		= true;
		public bool enableSkill 		= true;

		#region sendArm
		public int sendArmFrom = -1;
		public int sendArmTo = -1;

		public void EnterSendArm(int fromUid, int toUid)
		{
			sendArmFrom = fromUid;
			sendArmTo = toUid;

			SetAllDisable ();
			enableSendArm = true;
		}

		public void CloseSendArm()
		{
//			sendArmFrom = -1;
//			sendArmTo = -1;
//
//			SetAllDisable ();
		}


		public bool GetEnableSendArmFrom(int fromUid)
		{
			if(lockGuide)
			{
				if (guide)
				{
					if(enableSendArm)
					{
						if(sendArmFrom != -1)
						{
							if (sendArmFrom != fromUid) 
							{
								return false;
							}
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}




		public bool GetEnableSendArmTo(int toUid)
		{
			if(lockGuide)
			{
				if (guide)
				{
					if(enableSendArm)
					{
						if(sendArmFrom != -1)
						{
							if (sendArmTo != toUid) 
							{
								return false;
							}
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}

		#endregion





		#region uplevel
		public int uiplevelUid = -1;
		public void EnterUplevel(int uid)
		{
			uiplevelUid = uid;

			SetAllDisable ();
			enableUplevel = true;
		}


		public void CloseUplevel()
		{
			uiplevelUid = -1;
			SetAllDisable ();
		}

		public bool GetEnableUplevel(int uid)
		{
//			Debug.Log ("uid=" + uid + " lockGuide=" + lockGuide + " guide=" + guide + " enableUplevel="+ enableUplevel + " uiplevelUid=" + uiplevelUid);
			if(lockGuide)
			{
				if (guide)
				{
					if(enableUplevel)
					{
						if(uiplevelUid != -1)
						{
							if (uiplevelUid != uid) 
							{
								return false;
							}
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}

		#endregion

		#region skill
		public int skillId = -1;
		public int skillTargetUid = -1;
		public void EnterSkill(int skillId, int uid)
		{
			this.skillId = skillId;
			this.skillTargetUid = uid;

			SetAllDisable ();
			enableSkill = true;
		}


		public void CloseSkill()
		{
			skillId = -1;
			skillTargetUid = -1;
			SetAllDisable ();
		}

		public bool GetEnableSkillSkillId(int skillId)
		{
			if(lockGuide)
			{
				if (guide)
				{
					if(enableSkill)
					{
						if(this.skillId != -1)
						{
							if (this.skillId != skillId) 
							{
								return false;
							}
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}


		public bool GetEnableSkillTargetUid(int uid)
		{
			//Debug.Log ("GetEnableSkillTargetUid uid=" + uid + "  lockGuide=" + lockGuide + "  guide=" + guide + "  enableSkill=" + enableSkill + "  skillTargetUid=" + skillTargetUid);
			if(lockGuide)
			{
				if (guide)
				{
					if(enableSkill)
					{
						if(skillTargetUid != -1)
						{
							if (skillTargetUid != uid) 
							{
								return false;
							}
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}

		#endregion


		public void EndGuide()
		{
			guide = false;
			lockGuide = false;
			enableSendArm = true;
			enableUplevel = true;
			enableSkill = true;
		}

		public void SetAllDisable()
		{
			enableSendArm = false;
			enableUplevel = false;
			enableSkill = false;
		}

	}
}