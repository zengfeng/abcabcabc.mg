ItemCardBase = class("ItemCardBase")

function ItemCardBase:ctor()
	self.path = nil
	self.transform = nil
	self.head = nil
	self.callback = nil
end

function ItemCardBase:Load()
	Coo.assetManager:LuaLoad(self, self.path, self.OnLoad)
end

function ItemCardBase:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.rectTransform = self.transform:GetComponent("RectTransform")
	self.head = self.transform:FindChild("Head"):GetComponent("Image")

	self.rectTransform.anchoredPosition = Vector2.New(0, 0)
	self:OnAfterLoad()

	if self.callback then
		self.callback()
	end
end

function ItemCardBase:OnAfterLoad()
end

-----------------------
--  ItemCard
-----------------------

ItemCard = class("ItemCard", ItemCardBase)

function ItemCard:ctor()
	self.super.ctor(self)
	self.path = "module/Common/ItemCard"
	self.count = 0
	self.typeIdx = 0
	self.currType = nil --[type:RoleCurrency]
	self.countText = nil
end

function ItemCard:OnAfterLoad()
	self.countText = self.transform:FindChild("Text"):GetComponent("Text")
	self.headImage = self.transform:FindChild("Head")
	self.headMul = self.transform:FindChild("Head"):GetComponent("MultiImage")
	self.IconImageBar = self.transform:FindChild("Image")
	self.IconImage = self.transform:FindChild("Icon")
	self.IconImageMul = self.transform:FindChild("Icon"):GetComponent("MultiImage")
	self.headMul:SetImageIndex(self.typeIdx)
	self.countText.text = self.count
end

function ItemCard:SetCount(count)
	self.count = count
end

function ItemCard:SetShowType(typeIdx)
	self.typeIdx = typeIdx
end

function ItemCard:NotShowIcon()--隐藏进度条和货币图标
	
    self.IconImageBar.gameObject:SetActive(false)
    self.IconImage.gameObject:SetActive(false)
end

function ItemCard:SetIconImage()--设置货币
	local IconImageNative = self.transform:FindChild("Icon"):GetComponent("Image")
	self.IconImageMul:SetImageIndex(self.typeIdx)
	IconImageNative:SetNativeSize()
	self.IconImageRect = self.IconImage:GetComponent("RectTransform") 
	self.IconImageRect.localScale = Vector3.New(0.55, 0.55,0.55) 

end

function ItemCard:ShowWithCurrType(currType, callback)
	self.currType = currType
	if self.currType == 100000 then
		self.typeIdx = 0
	elseif self.currType == 100001 then
		self.typeIdx = 1
	--elseif self.currType == 100002 then
	--	self.typeIdx = 2	
	end
	self.callback = callback
	self:Load()
end

-----------------------
--  ItemCardLevel
-----------------------
ItemCardLevel = class("ItemCardLevel", ItemCardBase)

function ItemCardLevel:ctor(window)
	self.super.ctor(self)
	self.window = window
	self.path = "module/Common/ItemCardLevel"
end

function ItemCardLevel:OnAfterLoad()
	self.qualityImg = self.transform:FindChild("Quality"):GetComponent("MultiImage")
	self.brand = self.transform:FindChild("Brand"):GetComponent("MultiImage")
	self.level = self.transform:FindChild("Brand/Text"):GetComponent("Text")
	self.Name = self.transform:FindChild("Brand/NameText"):GetComponent("Text")
	self.levelShow = self.transform:FindChild("Brand/Text")
	self.NameShow = self.transform:FindChild("Brand/NameText")
	self.clickArea = self.transform:FindChild("Click")--点击区域
	self.window:AddClick(self.clickArea.gameObject, handler(self, self.OnShowCard))
	self.levelShow.gameObject:SetActive(true)
	self.NameShow.gameObject:SetActive(false)
	if self.clickType == true then
		self.clickArea.gameObject:SetActive(false)
	else
		self.clickArea.gameObject:SetActive(true)
	end
	local st = ConfigManager.card:GetConfig(self.id)
	local roleCard = Role.cardManager:GetCard(self.id)
	local qualityIdx = st.quality-1
	self.qualityImg:SetImageIndex(qualityIdx)
	self.brand:SetImageIndex(qualityIdx)
	if self.playerLevel then
		self.level.text = string.format(self.level.text, self.playerLevel)
	else	
		self.level.text = string.format(self.level.text, roleCard.level)
	end

	UIUtils.LoadCardAvatar(self.head, self.id)
end

function ItemCardLevel:SetHeadIcon(headType)--设置头像（图标为头像图标或技能图标）
	local avat = ConfigManager.card:GetAvatarConfig(self.id)
	if headType == HeadType.HeadIcon then
		self.avatarIcon = avat.headIcon
	elseif headType == HeadType.SkillIcon then
		self.avatarIcon = avat.icon
	end
	Coo.assetManager:LuaLoad(self, self.avatarIcon, function (_, name, obj)
		self.head.sprite = toSprite(obj)
	end)
end

function ItemCardLevel:SetParent(parent)--设置显示卡牌的父物体
	self.parent = parent
	
end

function ItemCardLevel:SetClickType(clickType)--用于屏蔽点击事件
	self.clickType = clickType
end

function ItemCardLevel:OnShowCard()--显示卡牌详情
	if self.id > 100000 then
		local newId = math.floor (self.id/10) --取整
		self.clickId = newId
	else
		self.clickId = self.id
	end
	if self.clickType == true then
		return
	else
		local card = ConfigManager.card:GetConfig(self.clickId)
		if Role.GetGrade().id < card.arena then
			local arenaCfg = ConfigManager.grade:GetConfig(card.arena)
			CommonUtil.ShowMsg(string.format(Lang.EMBATTLE_2, arenaCfg.name))
		else
			if self.parent then
				Coo.menuManager:OpenMenu(MenuType.CardInfo, {self.clickId, true,handler(self, self.OnClickClose)})--父面板在Layer-MainUI
				self.parent.transform.gameObject:SetActive(false)
			else
				Coo.menuManager:OpenMenuBack(MenuType.CardInfo,self.window.menuId, {self.clickId, true})--父面板在Layer-Module
			end
			
		end
	end
end

function ItemCardLevel:OnClickClose()
	CardInfoPanel.window:Exit()
	if self.parent then
		self.parent.transform.gameObject:SetActive(true)
	end
end
function ItemCardLevel:ShowRoleCardName(nameText)--显示名字屏蔽等级
	self.levelShow.gameObject:SetActive(false)
	self.NameShow.gameObject:SetActive(true)
	self.Name.text = nameText
end

function ItemCardLevel:ShowRoleCardWithId(id, callback)
	self.id = id
	self.callback = callback
	self:Load()
end

function ItemCardLevel:ShowRoleCardWithIdAndLevel(id,level, callback)
	self.id = id
	self.playerLevel = level
	self.callback = callback
	self:Load()
end

-----------------------
--  ItemCardCollect
-----------------------

ItemCardCollect = class("ItemCardCollect", ItemCardBase)

function ItemCardCollect:ctor( ... )
	self.super.ctor(self)
	self.path = "module/Common/ItemCardCollect"
	self.id = 0
	self.name = nil
	self.value = 1
	self.level = 1
	self.count = nil
	self.isNew = nil
end

function ItemCardCollect:OnAfterLoad()
	self.qualityImg = self.transform:FindChild("Quality"):GetComponent("MultiImage")
	self.qualityEffect = self.transform:FindChild("Quality"):GetComponent("MultiObject")
	self.name = self.transform:FindChild("Name"):GetComponent("Text")
	self.arrow = self.transform:FindChild("ProBar/Arrow"):GetComponent("MultiImage")
	self.prog = self.transform:FindChild("ProBar"):GetComponent("Slider")
	self.progBg = self.transform:FindChild("ProBar/Bg"):GetComponent("MultiImage")
	self.progText = self.transform:FindChild("ProBar/Text"):GetComponent("Text")
	self.chestTip = self.transform:FindChild("ChestTip")
	self.chestTipCount = self.transform:FindChild("ChestTip/Count"):GetComponent("Text")
	self.chestNewCard = self.transform:FindChild("ChestTip/New")
	self.ProBar = self.transform:FindChild("ProBar")
	 namePosRect = self.transform:FindChild("Name"):GetComponent("RectTransform")
	local st = ConfigManager.card:GetConfig(self.id)
	local levelCfg = ConfigManager.cardLevel:GetConfig(self.level)
	local qualityIdx = st.quality-1
	self.name.text = st.name
	self.qualityImg:SetImageIndex(qualityIdx)
	self.qualityEffect:SetObjectIndex(qualityIdx)
	self.prog.value = self.value
	self.prog.maxValue = levelCfg.number
	self.progText.text = self.value .. "/" .. levelCfg.number

	if self.value >= levelCfg.number then
		self.arrow:SetImageIndex(1)
		self.progBg:SetImageIndex(1)
	else
		self.arrow:SetImageIndex(0)
		self.progBg:SetImageIndex(0)
	end

	UIUtils.LoadCardAvatar(self.head, self.id)

	if self.count then
		self.chestTip.gameObject:SetActive(true)
		self.chestTipCount.text = self.count
		self.chestNewCard.gameObject:SetActive(self.isNew)
	else
		self.chestTip.gameObject:SetActive(false)
	end
end

function ItemCardCollect:CardNamePos(cardNamePos)--名字位置
	
	namePosRect.anchoredPosition = cardNamePos
end

function ItemCardCollect:NotShowBar()--隐藏进度条
		
	self.ProBar.gameObject:SetActive(false)
end

function ItemCardCollect:SetInfo(value, level)
	self.value = value
	self.level = level
end

function ItemCardCollect:SetChestTip(count, isNew)
	self.count = count
	self.isNew = isNew
end

function ItemCardCollect:ShowWithId(id, callback)
	self.id = id
	self.callback = callback
	self:Load()
end