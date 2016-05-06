CardBrand = class("CardBrand")

function CardBrand:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.cardId = 0
	self.isEmbattle = false
	self.isRoleCard = false
	self.bgImage = self.transform:FindChild("Portrait/Bg")
	self.brandBg = self.transform:FindChild("Bg"):GetComponent("MultiColor")
	self.bg = self.transform:FindChild("Portrait/Bg"):GetComponent("MultiImage")
	self.headTrans = self.transform:FindChild("Portrait/Head")
	self.head = self.transform:FindChild("Portrait/Head"):GetComponent("Image")
	self.headQuality = self.transform:FindChild("Portrait/Head/Quality"):GetComponent("MultiColor")
	self.material = self.transform:FindChild("Portrait/Head"):GetComponent("ImageSetMaterial")
	self.skillQuality = self.transform:FindChild("Portrait/Head/SkillQuality"):GetComponent("MultiColor")
	self.skillIcon = self.transform:FindChild("Portrait/Head/SkillQuality/Icon"):GetComponent("Image")
	self.name = self.headTrans:FindChild("Text"):GetComponent("Text")
	self.level = self.headTrans:FindChild("Level/LevelNumText"):GetComponent("Text")
	self.levelNode = self.headTrans:FindChild("Level")
	self.levelBarNode = self.headTrans:FindChild("LevelBar")
	self.levelBar = self.headTrans:FindChild("LevelBar"):GetComponent("Slider")
	self.levelBarBg = self.headTrans:FindChild("LevelBar/Bg")
	self.barText = self.headTrans:FindChild("LevelBar/Text"):GetComponent("Text")
	self.barBg = self.headTrans:FindChild("LevelBar/Bg"):GetComponent("MultiObject")
	self.prog = self.headTrans:FindChild("LevelBar/Bg/NotEncough"):GetComponent("Slider")
	self.infoButton = self.transform:FindChild("InfoButton"):GetComponent("MultiObject")
	self.levelUpBtn = self.transform:FindChild("InfoButton/LvUp")
	self.levelUpCost = self.transform:FindChild("InfoButton/LvUp/Cost"):GetComponent("Text")
	self.cardInfoBtn = self.transform:FindChild("InfoButton/Info")
	self.embattleTip = self.headTrans:FindChild("IsEmbattle")
	self.gradeDesc = self.headTrans:FindChild("Grade"):GetComponent("Text")
	self.glow = self.transform:FindChild("Glow"):GetComponent("Animator")
	animatorStop(self.glow, false)
	self.gradeDescText = self.gradeDesc.text
	self.skillQuality.gameObject:SetActive(false)

	self.window:AddClick(self.levelUpBtn.gameObject, handler(self, self.OnClickLevelUp))
	self.window:AddClick(self.cardInfoBtn.gameObject, handler(self, self.OnClickCardInfo))
	self.window:AddClick(self.head.gameObject, handler(self, self.OnClickEmbattle))
end

function CardBrand:UpdateByRoleCardId(id, isEmbattle)
	self.cardId = id
	self.isEmbattle = isEmbattle
	self.isRoleCard = true

	local card = ConfigManager.card:GetConfig(self.cardId)
	local roleCard = Role.cardManager:GetCard(self.cardId)
	local cardLv = roleCard:GetCardLevelConfig()
	local canLevelUp = roleCard.count >= cardLv.number
	self.bg:SetImageIndex(card.quality - 1)
	self.brandBg:SetColorIndex(card.quality - 1)
	self.name.text = card.name
	textFormat(self, self.level, roleCard.level)
	
	self.barText.text = roleCard.count .. "/" .. cardLv.number
	self.prog.value = roleCard.count
	self.prog.maxValue = cardLv.number

	self.levelNode.gameObject:SetActive(true)
	self.levelBarNode.gameObject:SetActive(true)
	self.gradeDesc.gameObject:SetActive(false)
	self.material:SetMaterial(1)
	self.skillQuality.gameObject:SetActive(true)
	self.skillQuality:SetColorIndex(card.quality - 1)
	self.headQuality.gameObject:SetActive(true)
	self.headQuality:SetColorIndex(card.quality - 1)

	local skillDisplay = ConfigManager.skillDisplay:GetConfig(card.skill)
	UIUtils.LoadAvatarWithId(self.skillIcon, skillDisplay.avatarId)

	if canLevelUp then
		self.barBg:SetObjectIndex(1)
		self.infoButton:SetObjectIndex(1)
		self.levelUpCost.text = ConfigManager.cardLevel:GetCoin(roleCard.level, card.quality)
	else
		self.barBg:SetObjectIndex(0)
		self.infoButton:SetObjectIndex(0)
	end

	local avat = ConfigManager.card:GetAvatarConfig(self.cardId)
	Coo.assetManager:LuaLoad(self, avat.model, function (_, name, obj)
		self.head.sprite = toSprite(obj)
	end)

	self:UpdateEmbattle()
end

function CardBrand:UpdateById(id)
	self.cardId = id
	self.isEmbattle = false
	self.isRoleCard = false

	local card = ConfigManager.card:GetConfig(self.cardId)
	self.brandBg:SetColorIndex(card.quality - 1)
	self.bg:SetImageIndex(card.quality - 1)
	self.name.text = card.name

	self.levelNode.gameObject:SetActive(false)
	self.levelBarNode.gameObject:SetActive(false)
	self.material:SetMaterial(0)
	self.skillQuality.gameObject:SetActive(false)
	self.headQuality.gameObject:SetActive(false)

	if Role.GetGrade().id < card.arena then
		local arenaCfg = ConfigManager.grade:GetConfig(card.arena)
		self.gradeDesc.gameObject:SetActive(true)
		self.gradeDesc.text = string.format(self.gradeDescText, arenaCfg.name)
	else
		self.gradeDesc.gameObject:SetActive(false)
	end

	local avat = ConfigManager.card:GetAvatarConfig(self.cardId)
	Coo.assetManager:LuaLoad(self, avat.model, function (_, name, obj)
		self.head.sprite = toSprite(obj)
	end)

	self:UpdateEmbattle()
end

function CardBrand:UpdateEmbattle()
	self.embattleTip.gameObject:SetActive(self.isEmbattle)

	GuideManager.CheckPoint(self, {[GuideType.Embattle] = {1}, [GuideType.Levelup] = {1}})

	delayCall(function()
		GuideManager.CheckPoint(self, {[GuideType.Embattle] = {2}, [GuideType.Levelup] = {2}})
	end)
end

function CardBrand:PlaySparking()
	animatorPlay(self.glow)
end

function CardBrand:OnClickLevelUp()
	if not self.isRoleCard then
		return
	end
	EmbattlePanel.SendEmbattle()
	Coo.menuManager:OpenMenuBack(MenuType.CardInfo, self.window.menuId, {self.cardId, false})
end

function CardBrand:OnClickCardInfo()
	EmbattlePanel.SendEmbattle()
	if not self.isRoleCard then
		self:OnShowUnownCard()
		return
	end
	
	Coo.menuManager:OpenMenuBack(MenuType.CardInfo, self.window.menuId, {self.cardId, false})
end

function CardBrand:OnClickEmbattle()
	if not self.isRoleCard then
		self:OnShowUnownCard()
		return
	end

	if not self.isEmbattle then
		if EmbattlePanel.AddArrange(self.cardId) then
			self.isEmbattle = true
		end
	else
		EmbattlePanel.RemoveArrange(self.cardId)
		self.isEmbattle = false
	end
	self:UpdateEmbattle()
end

function CardBrand:OnShowUnownCard()
	local card = ConfigManager.card:GetConfig(self.cardId)
	if Role.GetGrade().id < card.arena then
		local arenaCfg = ConfigManager.grade:GetConfig(card.arena)
		CommonUtil.ShowMsg(string.format(Lang.EMBATTLE_2, arenaCfg.name))
	else
		Coo.menuManager:OpenMenuBack(MenuType.CardInfo, self.window.menuId, {self.cardId, true})
	end
end