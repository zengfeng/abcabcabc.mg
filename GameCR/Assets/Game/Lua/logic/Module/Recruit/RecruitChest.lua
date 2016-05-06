RecruitChest = class("RecruitChest", 
{
})

function RecruitChest:ctor(transform, window, id)
	self.transform = transform
	self.window = window
	self.icon = GradeIcon.New(transform:FindChild("Bg/Title/Icon"))
	self.chestName = transform:FindChild("Bg/Title/Text"):GetComponent("Text")
	self.button = transform:FindChild("Bg/Button")
	self.buttonText = transform:FindChild("Bg/Button/Text"):GetComponent("Text")
	self.buttonTextMul = transform:FindChild("Bg/Button/Text"):GetComponent("MultiColor")
	self.chestId = id
	self.buttonTextMul:SetColorIndex(-1)

	window:AddClick(self.transform.gameObject, handler(self, self.OnClick))
end

function RecruitChest:UpdateWithId(id)
	self.chestId = id
	 self.st = ConfigManager.chest:GetConfig(id)
	self.buttonText.text = self.st.money
	if Role.money < self.st.money then
			self.buttonTextMul:SetColorIndex(0)
		end
	local typeSt = ConfigManager.chestType:GetConfig(self.st.type)
	self.chestName.text = typeSt.name

	self.icon:SetGrade(Role.GetGrade().id)
end

function RecruitChest:OnClick()
	if Role.money >= self.st.money then
		local w = ChestWindow.New(self.window)
		w:ShowByShop(self.chestId)
	else
		CommonUtil.ShowMsg("元宝不足")
	end
end