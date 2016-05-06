ChangeNameWin = class("ChangeNameWin", 
{
})

function ChangeNameWin:ctor(transform, window)
	transform.gameObject:SetActive(false)

	self.transform = transform
	self.cost = transform:FindChild("Content/Cost"):GetComponent("MultiObject")
	self.input = transform:FindChild("Content/Content/Input/Name/Text"):GetComponent("InputField")
	self.dice = transform:FindChild("Content/Content/Input/Dice")
	self.confirm = transform:FindChild("Content/Confirm")
	self.bg = transform:FindChild("Bg")
	self.firstName = transform:FindChild("Content/Cost/First")--首次改名显示
	self.notFirstName = transform:FindChild("Content/Cost/NotFirst")
	self.isFirstChange = 0
	window:AddClick(self.dice.gameObject, handler(self, self.OnClickDice))
	window:AddClick(self.confirm.gameObject, handler(self, self.OnClickConfirm))
	window:AddClick(self.bg.gameObject, handler(self, self.OnClickClose))
	
end

function ChangeNameWin:Show()
	self.transform.gameObject:SetActive(true)
	self.isFirstChange =  getBit(Role.statusMark,1)
	if self.isFirstChange == 0 then --首次改名
		self.firstName.gameObject:SetActive(true)
		self.notFirstName.gameObject:SetActive(false)
	elseif self.isFirstChange == 1 then

		self.firstName.gameObject:SetActive(false)
		self.notFirstName.gameObject:SetActive(true)
	end
	self:OnClickDice()
end

function ChangeNameWin:OnClickDice()
	local last = self.input.text
	local new = ConfigManager.roleName:GetRandName()
	while new == last do
		new = ConfigManager.roleName:GetRandName()
	end
	self.input.text = new
end

function ChangeNameWin:OnClickConfirm()
	if self.isFirstChange == 0 then
		EnterProto.C_ChangeName_0x102(self.input.text)
		self:OnClickClose()
	else
		if Role.money >= 100 then
			EnterProto.C_ChangeName_0x102(self.input.text)
			self:OnClickClose()
		else
			CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_1)
		end
	end
end

function ChangeNameWin:OnClickClose()
	self.transform.gameObject:SetActive(false)
end