GradeCard = class("GradeCard", 
{
})

function GradeCard:ctor(transform, parent)
	self.parent = parent
	self.transform = transform
	self.window = self.parent.window
	self.card = self.transform:FindChild("Image")
	self.cardImage = self.transform:FindChild("Image"):GetComponent("Image")

	self.window:AddClick(self.card.gameObject, handler(self, self.OnClick))
end

function GradeCard:Show(cardId)
	
	self.gradeCardID = cardId
	if self.gradeCardID == nil then
		self.card.gameObject:SetActive(false)
	else
		self.card.gameObject:SetActive(true)	
		UIUtils.LoadCardAvatar(self.cardImage, self.gradeCardID)
	end	
end

function GradeCard:OnClick()
	local card = ConfigManager.card:GetConfig(self.gradeCardID)
	if Role.GetGrade().id < card.arena then
		local arenaCfg = ConfigManager.grade:GetConfig(card.arena)
		CommonUtil.ShowMsg(string.format(Lang.EMBATTLE_2, arenaCfg.name))
	else
		Coo.menuManager:OpenMenu(MenuType.CardInfo, {self.gradeCardID, true, handler(self, self.OnClickClose)})
		self.parent.transform.gameObject:SetActive(false)
		
	end
end

function GradeCard:OnClickClose()
	CardInfoPanel.window:Exit()
	self.parent.transform.gameObject:SetActive(true)
end