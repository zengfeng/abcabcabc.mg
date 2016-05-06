TaskItem = class("TaskItem", 
{
})

function TaskItem:ctor(transform, window)
	local bg = transform:FindChild("Bg")

	self.title = bg:FindChild("Title/Text"):GetComponent("Text")
	self.desc = bg:FindChild("Desc"):GetComponent("Text")
	self.icon = bg:FindChild("Icon/Cont"):GetComponent("Image")
	self.progBar = bg:FindChild("Prog")
	self.prog = bg:FindChild("Prog"):GetComponent("Slider")
	self.progText = bg:FindChild("Prog/Text"):GetComponent("Text")
	self.expIcon = bg:FindChild("Reward/Exp")
	self.exp = bg:FindChild("Reward/Exp/Text"):GetComponent("Text")
	self.moneyIcon = bg:FindChild("Reward/Money")
	self.money = bg:FindChild("Reward/Money/Text"):GetComponent("Text")
	self.rewardButton = bg:FindChild("RewardButton")

	window:AddClick(self.rewardButton.gameObject, handler(self, self.OnClick))
end

function TaskItem:UpdateWith(roleTask)
	local config = ConfigManager.task:GetConfig(roleTask.taskId)
	self.title.text = config.name
	self.desc.text = StringUtil.CSharpFormat(config.describe, config.parameter1)
	self.prog.maxValue = config.parameter1
	self.prog.value = roleTask.taskProgress
	self.progText.text =  roleTask.taskProgress .. "/" .. config.parameter1
	self.exp.text = config.reward.list[SpecialItemType.Exp].value
	self.money.text = config.reward.list[SpecialItemType.Money].value

	if roleTask.status == 2 then
		self.rewardButton.gameObject:SetActive(true)
		self.progBar.gameObject:SetActive(false)
	else
		self.rewardButton.gameObject:SetActive(false)
		self.progBar.gameObject:SetActive(true)
	end
	self.roleTask = roleTask

	UIUtils.LoadAvatarWithId(self.icon, config.avatar)
end

function TaskItem:OnClick()
	if self.roleTask.status == 2 then
		TaskPanel.lastClickTaskItem = self
		TaskPanel.isRefresh = true
		TaskProto.C_GetTaskAward_0x502(self.roleTask.taskId)
	end
end