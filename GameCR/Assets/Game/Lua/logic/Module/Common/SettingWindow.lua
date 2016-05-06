SettingWindow = class("SettingWindow", BaseWindow)

function SettingWindow:ctor(window)
	self.path = "module/Common/SettingWindow"
	self.window = window
	self.roleAvatarId = 0
	self.RoleDisPlayInfo = nil
end

function SettingWindow:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.content = self.transform:FindChild("Content")
	self.closeButton = self.content:FindChild("CloseButton")--

	--主公名字头像信息
	self.roleName = self.content:FindChild("RoleName")
	self.head = self.roleName:FindChild("Head")
	self.icon = self.head:FindChild("HeadBg/HeadIcon"):GetComponent("Image")
	self.name = self.head:FindChild("Name"):GetComponent("Text")
	self.roleId = self.head:FindChild("RoleId/Num"):GetComponent("Text")
	self.prizeNum =  self.head:FindChild("RolePrize/Num"):GetComponent("Text")
	self.gradeImage = self.head:FindChild("RolePrize/GradeImage"):GetComponent("MultiImage")
	self.changeName = self.roleName:FindChild("ChangeName")
	self.changeHead = self.roleName:FindChild("ChangeHead")
	self.nameWin = ChangeNameWin.New(self.transform:FindChild("NameWin"), self.window)
	--公会信息
	self.unionIcon = self.roleName:FindChild("Union/UnionImage/UnionIcon")
	self.unionIconImage = self.roleName:FindChild("Union/UnionImage/UnionIcon"):GetComponent("Image")
	self.unionName = self.roleName:FindChild("Union/UnionName"):GetComponent("Text")
	self.unionMemberNum = self.roleName:FindChild("Union/UnionMember/Num"):GetComponent("Text")
	self.unionButton = self.roleName:FindChild("Union/UnionButton")
	--主公属性
	self.rolePropList = self.content:FindChild("RoleProp/PropList")
	self.level = self.content:FindChild("RoleProp/RoleLevel/LevelIcon/LevelText"):GetComponent("Text")
	self.population = self.rolePropList:FindChild("Population/PropNum"):GetComponent("Text")--初始兵力
	self.attack = self.rolePropList:FindChild("Attack/PropNum"):GetComponent("Text")--攻击
	self.defense = self.rolePropList:FindChild("Defense/PropNum"):GetComponent("Text")--造兵
	self.speed = self.rolePropList:FindChild("Speed/PropNum"):GetComponent("Text")--速度
	--出战卡组
	self.roleInfo = self.content:FindChild("RoleInfo")
	self.roleCards = self.roleInfo:FindChild("RoleCards/CardList")
	self.atkBar = self.roleInfo:FindChild("RoleCards/Info/Atk"):GetComponent("Slider")
	self.atkValue = self.roleInfo:FindChild("RoleCards/Info/Atk/Text"):GetComponent("Text")
	self.defBar = self.roleInfo:FindChild("RoleCards/Info/Def"):GetComponent("Slider")
	self.defValue = self.roleInfo:FindChild("RoleCards/Info/Def/Text"):GetComponent("Text")
	self.speBar = self.roleInfo:FindChild("RoleCards/Info/Spe"):GetComponent("Slider")
	self.speValue = self.roleInfo:FindChild("RoleCards/Info/Spe/Text"):GetComponent("Text")
	self.heroButton = self.roleInfo:FindChild("RoleCards/Info/HeroButton")
	--数据统计
	self.roleDataList = self.roleInfo:FindChild("RoleData/DataList")
	self.winNum = self.roleDataList:FindChild("WinNum/Num"):GetComponent("Text")--胜利次数
	self.useHero = self.roleDataList:FindChild("UseHero/Num"):GetComponent("Text")--近期常用武将
	self.starWinNum = self.roleDataList:FindChild("StarWinNum/Num"):GetComponent("Text")--3星胜利次数
	self.heroNum = self.roleDataList:FindChild("HeroNum/Num"):GetComponent("Text")--已招募武将数量
	self.prizeMaxNum = self.roleDataList:FindChild("PrizeMaxNum/Num"):GetComponent("Text")--奖杯最高数量
	self.donateNum = self.roleDataList:FindChild("DonateNum/Num"):GetComponent("Text")--捐赠总数

	-- local transformGuide = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	-- self.transform:SetParent(transformGuide, false)
	self.transform:SetParent(MainPanel.transform, false)
	self.transformRect = self.transform:GetComponent("RectTransform")
	self.isChangeCardHead = false 
	self.transformRect.localScale = Vector3.New(1, 1,1) 
	self.transformRect.anchoredPosition = Vector2.New(0, 0)
	self.window:AddClick(self.changeName.gameObject, handler(self, self.OnClickChangeName))
	self.window:AddClick(self.changeHead.gameObject, handler(self, self.OnClickChangeHead))
	self.window:AddClick(self.closeButton.gameObject, handler(self, self.OnClickClose))
	self.window:AddClick(self.unionButton.gameObject, handler(self, self.OnClickUnionButton))
	self.window:AddClick(self.heroButton.gameObject, handler(self, self.OnShowHero))

	EventManager.AddEventListener(self, "S_ChangeName_0x102", handler(self, self.OnChangeNameRecv))
	
end

function SettingWindow:Show(roleInfo,isShoW)
	self:Load()
	delay = true
	self.RoleDisPlayInfo = roleInfo
	if isShoW then
		self.changeName.gameObject:SetActive(true)
		self.changeHead.gameObject:SetActive(true)	
	else
		self.changeName.gameObject:SetActive(false)
		self.changeHead.gameObject:SetActive(false)
	end


	--主公名字头像信息
	UIUtils.LoadAvatarWithId(self.icon, self.RoleDisPlayInfo.base_info.icon)
	self.name.text = self.RoleDisPlayInfo.base_info.name
	self.roleId.text = self.RoleDisPlayInfo.base_info.roleId
	self.level.text = self.RoleDisPlayInfo.base_info.level
	local lvCfg = ConfigManager.exp:GetConfig(Role.level)
	self.prizeNum.text = self.RoleDisPlayInfo.base_info.prize
  	self.roleAvatarId = 0
  	self.nowGrade = Role.GetGrade().id
  	self.gradeImage:SetImageIndex(self.nowGrade)

  	self:ShowUnionInfo()
  	self:ShowRoleProp()
  	self:ShowRoleCards()
  	self:ShowRoleData()

end

--公会信息
function SettingWindow:ShowUnionInfo()--功能未做完
	self.unionIcon.gameObject:SetActive(false)
	self.unionName.text = Lang.UnionNull--无公会
	self.unionMemberNum.text = 0
end

--主公属性
function SettingWindow:ShowRoleProp()
	self.cardIds = {}
	local totalAtkValueNew, totalDefValueNew, totalSpValueNew = 
					BattleManager.GetTotalDisplayBattleProp(self.cardIds, nil, self.RoleDisPlayInfo.base_info.level)
	self.newHp = ConfigManager.exp:GetConfig(self.RoleDisPlayInfo.base_info.level).initTroop
	
	self.population.text = self.newHp
	self.attack.text = math.floor(totalAtkValueNew)
	self.defense.text = math.floor(totalDefValueNew)
	self.speed.text = math.floor(totalSpValueNew)
end

--出战卡组
function SettingWindow:ShowRoleCards()
	destroyChildren(self.roleCards.transform)
	self.cardHeroIds = {}
	self.cards = {}
	local battleCards = self.RoleDisPlayInfo.battle_info.battle_cards
	for i,v in ipairs(battleCards) do
		local card = ItemCardLevel.New(self.window)
		card:SetClickType(false)
		card:ShowRoleCardWithIdAndLevel(v.card_id,v.level, function()
			card:SetParent(self)
			
			card.transform:SetParent(self.roleCards.transform, false)
		end)
		table.insert(self.cardHeroIds, {v.card_id, v.level})
		table.insert(self.cards, card)
	end
	local totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue = 
					BattleManager.GetTotalDisplayBattleProp(self.cardHeroIds, Role.soldierManager.battleSoldier, Role.level)

	self.atkValue.text = math.floor(totalAtkValue)
	UIUtils.UpdateProgress(self.atkBar, maxAtkValue, totalAtkValue, delay)

	self.defValue.text = math.floor(totalDefValue)
	UIUtils.UpdateProgress(self.defBar, maxDefValue, totalDefValue, delay)

	self.speValue.text = math.floor(totalSpValue)
	UIUtils.UpdateProgress(self.speBar, maxSpValue, totalSpValue, delay)
	delay = false
end

--数据统计
function SettingWindow:ShowRoleData()
	self.winNum.text = self.RoleDisPlayInfo.statistic_info.arena_fight_win
	local useHeroInfo  = ConfigManager.card:GetConfig(self.RoleDisPlayInfo.statistic_info.often_fight_card)
	if useHeroInfo == nil then
		self.useHero.text = Lang.Null
	else
		self.useHero.text = useHeroInfo.name
	end
	self.starWinNum.text = self.RoleDisPlayInfo.statistic_info.arena_perfect_win
	self.heroNum.text = self.RoleDisPlayInfo.statistic_info.total_card_count
	self.prizeMaxNum.text = self.RoleDisPlayInfo.statistic_info.max_prize
	self.donateNum.text = self.RoleDisPlayInfo.statistic_info.donate_card_count
end

function SettingWindow:OnClickClose()
	self.super.OnCloseWindow(self)
end

function SettingWindow:OnClickChangeName()
	self.nameWin:Show()
end

function SettingWindow:OnChangeNameRecv(msg)
	self.name.text = Role.name
end



function SettingWindow:OnClickChangeHead()
	local roleAvatarIds = {}
  	for k,v in pairs(ConfigManager.avatar:GetAllConfigs()) do
    	if v.id >= 80000 and  v.id < 90000 then
      		table.insert(roleAvatarIds, v.id)
    	end
  	end
  local randomNum  = math.random(#roleAvatarIds)
  self.roleAvatarId = roleAvatarIds[randomNum]

  UIUtils.LoadAvatarWithId(self.icon, self.roleAvatarId)
  if self.roleAvatarId > 0 then
    	EnterProto.C_ChangeHeadIcon_0x105(self.roleAvatarId)
  end
end

function SettingWindow:OnClickUnionButton()
	print("公会详情信息")
end

function SettingWindow:OnShowHero()
	for i,v in ipairs(self.cards) do
		if self.isChangeCardHead == false then
			v:SetHeadIcon(HeadType.HeadIcon)
		else
			v:SetHeadIcon(HeadType.SkillIcon)
		end
	end
	if self.isChangeCardHead == false then
		self.isChangeCardHead = true
	else
		self.isChangeCardHead = false
	end
end

