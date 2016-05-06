RankItem = class("RankItem", 
{
})

function RankItem:ctor(transform, window)
	self.transform = transform
	self.bg = transform:FindChild("Bg")
	self.bgColor = transform:FindChild("Bg"):GetComponent("MultiColor")
	self.bgColor2 = transform:FindChild("Bg"):GetComponent("ImageSetMaterial")
	self.randBgColor = transform:FindChild("RankBg"):GetComponent("MultiColor")
	self.headMulti = transform:FindChild("Head"):GetComponent("MultiObject")
	self.rank = transform:FindChild("Rank"):GetComponent("Text")
	self.grade = transform:FindChild("Grade"):GetComponent("MultiImage")
	self.gradeText = transform:FindChild("Grade/Text"):GetComponent("Text")
	self.headIcon = transform:FindChild("Head/Icon"):GetComponent("Image")
	self.headName = transform:FindChild("Head/Name"):GetComponent("Text")
	self.headLevel = transform:FindChild("Head/Level"):GetComponent("Text")
	self.headIconLevel = transform:FindChild("Head/LevelIcon/Level"):GetComponent("Text")
	self.prize = transform:FindChild("Prize/Text"):GetComponent("Text")
	self.status = transform:FindChild("Status"):GetComponent("MultiObject")
	self.statusDown = transform:FindChild("Status/Down/Text"):GetComponent("Text")
	self.statusUp = transform:FindChild("Status/Up/Text"):GetComponent("Text")
	self.close = transform:FindChild("Close")
	self.union = transform:FindChild("Union"):GetComponent("Image")
	self.rankRoleInfo = nil
	window:AddClick(self.transform.gameObject, handler(self, self.OnClickItem))
end

function RankItem:UpdateWith(rankRoleInfo)
	self.rankRoleInfo = rankRoleInfo --[type:RankRoleInfo]
	self.roleId = rankRoleInfo.roleInfo.roleId
	self.rank.text = rankRoleInfo.rank

	local grade = ConfigManager.grade:GetConfigByPrize(rankRoleInfo.roleInfo.prize)
	self.grade:SetImageIndex(grade.id - 1)
	self.gradeText.text = grade.name

	self.headName.text = rankRoleInfo.roleInfo.name
	self.headLevel.text = rankRoleInfo.roleInfo.level
	self.headIconLevel.text = rankRoleInfo.roleInfo.level
	self.prize.text = rankRoleInfo.roleInfo.prize

	self.randBgColor.gameObject:SetActive(true)
	if rankRoleInfo.rank == 1 then
		self.bgColor:SetColorIndex(2)
		self.bgColor2:SetMaterial(1)
		self.randBgColor:SetColorIndex(2)
		self.headMulti:SetObjectIndex(1)
	elseif rankRoleInfo.rank == 2 then
		self.bgColor:SetColorIndex(3)
		self.bgColor2:SetMaterial(1)
		self.randBgColor:SetColorIndex(3)
		self.headMulti:SetObjectIndex(1)
	elseif rankRoleInfo.rank == 3 then
		self.bgColor2:SetMaterial(1)
		self.bgColor:SetColorIndex(4)
		self.randBgColor:SetColorIndex(4)
		self.headMulti:SetObjectIndex(1)
	elseif rankRoleInfo.roleInfo.roleId == Role.roleId then
		self.bgColor2:SetMaterial(0)
		self.bgColor:SetColorIndex(1)
		self.randBgColor.gameObject:SetActive(false)
		self.headMulti:SetObjectIndex(1)
	else
		self.bgColor2:SetMaterial(0)
		self.bgColor:SetColorIndex(0)
		self.randBgColor.gameObject:SetActive(false)
		self.headMulti:SetObjectIndex(1)
	end

	UIUtils.LoadAvatarWithId(self.headIcon, rankRoleInfo.roleInfo.icon)
end

function RankItem:OnClickItem()
	EnterProto.C_GetRoleDisplayInfo_0x120(self.roleId)
end