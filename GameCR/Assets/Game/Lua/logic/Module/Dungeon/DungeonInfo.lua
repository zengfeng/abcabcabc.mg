DungeonInfo = class("DungeonInfo", 
{
})

function DungeonInfo:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.leftList = transform:FindChild("Left/List/Content")
	self.leftItem = transform:FindChild("Left/DungeonInfo_LeftItem")
	self.allLeftItem = {}
	self.middleList = {DungeonMiddleItem.New(transform:FindChild("Middle/Item1"), window, self),
						DungeonMiddleItem.New(transform:FindChild("Middle/Item2"), window, self),
						DungeonMiddleItem.New(transform:FindChild("Middle/Item3"), window, self)}

	self.backBtn = transform:FindChild("Title/Back")
	self.descTitle = transform:FindChild("Middle/Desc/Title"):GetComponent("Text")
	self.descText = transform:FindChild("Middle/Desc/Text"):GetComponent("Text")
	self.descName = transform:FindChild("Middle/Desc/Name"):GetComponent("Text")

	self.chest = ChestIcon.New(transform:FindChild("Right/Chest"))
	self.starText = transform:FindChild("Right/Star/Text"):GetComponent("Text")
	self.startButton = transform:FindChild("Right/Button")
	self.activeGroup = transform:FindChild("Title/ActiveGroup"):GetComponent("ActiveGroup")

	window:AddClick(self.backBtn.gameObject, handler(self, self.OnClickClose))
	window:AddClick(self.startButton.gameObject, handler(self, self.OnClickStart))
	window:AddClick(self.chest.transform.gameObject, handler(self, self.OnClickChest))

	self.hardId = 0
	self.dungeonId = 0
	self.dungeonStageId = 0
	self.dungeonStageIndex = 1
	self.stageIndex = 1
	self.canOpenChest = false
	self.isNewStage = false

	self.activeGroup:SetChangeCallback(handler(self, self.OnChangeTab))
end

function DungeonInfo:UpdateDungeon(dungeonId, hardId)
	self.dungeonId = dungeonId
	self.hardId = hardId

	self.allLeftItem = {}
	destroyChildren(self.leftList)

	local dunStages = ConfigManager.dungeonStage:GetDungeonStagesByDungeonId(dungeonId, self.hardId)
	local idx = 1
	for k,v in pairs(dunStages) do
		local trans = newobject(self.leftItem).transform
		trans.gameObject:SetActive(true)
		trans:SetParent(self.leftList, false)

		local leftItem = DungeonLeftItem.New(trans, self.window, self)
		leftItem:UpdateWith(v, idx)
		idx = idx + 1

		table.insert(self.allLeftItem, leftItem)
	end

	self:SelectDungeonStage(self.dungeonStageIndex)
end

function DungeonInfo:SelectDungeon(dungeonId, hardId, dungeonIndex, index)
	
	self.dungeonId = dungeonId
	self.dungeonStageIndex = dungeonIndex or 1
	self.stageIndex = index or 1
	self.hardId = hardId or 1
	self.activeGroup:SelectByUid(self.hardId)

	GuideManager.NonLineCheckPoint(dungeonSelect, {[GuideType.Dungeon] = {3}})
end

function DungeonInfo:SelectDungeonStage(index)
	for k,v in pairs(self.allLeftItem) do
		v:SetSelect(false)
	end

	local dungeon = self.allLeftItem[index]
	dungeon:SetSelect(true)

	self.dungeonStageIndex = index
	self.dungeonStageId = dungeon.dungeonStageSt.id
	self:SelectStage(self.stageIndex)

	local dungeonCfg = ConfigManager.dungeonStage:GetConfig(self.dungeonStageId)
	local roleDungeon = Role.dungeonManager:GetRoleDungeonStage(dungeonCfg.id)
	local openChestCount = roleDungeon and roleDungeon.openChestCount or 0
	local chest = nil

	if openChestCount >= 3 then
		chest = dungeonCfg:GetStageChestId(3)
		self.chest:SetStateById(chest, true)
	else
		local dungeonIdx = openChestCount + 1
		chest = dungeonCfg:GetStageChestId(dungeonIdx)
		self.chest:SetStateById(chest, false)
	end

	local star = 0
	if roleDungeon then
		for i=1,3 do
			star = star + roleDungeon:GetStarByIndex(i)
		end
		self.canOpenChest = star >= (openChestCount+1)*3
	end
	local maxStar = math.min(9, (openChestCount+1)*3)
	self.starText.text = star .. "/" .. maxStar
end

function DungeonInfo:SelectStage(idx)
	self.stageIndex = idx

	local dungeonCfg = ConfigManager.dungeonStage:GetConfig(self.dungeonStageId)
	textFormat(self, self.descTitle, dungeonCfg:GetStageRecommandLevel(idx))

	self.descText.text = dungeonCfg:GetStageDesc(idx)
	self.descName.text = dungeonCfg:GetStageName(idx)

	for k,v in pairs(self.middleList) do
		v:UpdateWith(dungeonCfg, k)
		v:SetSelect(false)
		if idx == k then
			v:SetSelect(true)
			v:SetGlow(true)
		else
			v:SetGlow(false)
		end
	end
end

function DungeonInfo:OnChangeTab(uid)
	if uid > 1 then
		local lastDun = Role.dungeonManager:GetFirstDungeon(self.dungeonId, uid-1)
		if lastDun == nil or not lastDun:IsFinish() then
			if uid == 2 then
				CommonUtil.ShowMsg(Lang.DUNGEON_2)
			else
				CommonUtil.ShowMsg(Lang.DUNGEON_3)
			end
			self.activeGroup:SelectByUid(self.hardId)
			return
		end
	end

	self:UpdateDungeon(self.dungeonId, uid)
end

function DungeonInfo:OnClickClose()
	DungeonPanel.ShowDungeonSelect()
end

function DungeonInfo:OnClickStart()
	local roleDungeon = Role.dungeonManager:GetRoleDungeonStage(self.dungeonStageId)
	if roleDungeon then
		self.isNewStage = roleDungeon:GetStarByIndex(self.stageIndex) <= 0
	else
		self.isNewStage = true
	end
	BattleManager.StartDungeon(self.dungeonStageId, self.stageIndex)
end

function DungeonInfo:OnClickChest()
	local dungeonCfg = ConfigManager.dungeonStage:GetConfig(self.dungeonStageId)
	local dunRole = Role.dungeonManager:GetRoleDungeonStage(self.dungeonStageId)
	local openChestCount = dunRole and dunRole.openChestCount or 0

	if openChestCount >= 3 then
		CommonUtil.ShowMsg(Lang.DUNGEON_6)
	else
		local win = ChestWindow.New(self.window)
		win:ShowByDungeon(self.chest.chestId, self.dungeonStageId, self.canOpenChest, (openChestCount+1)*3)
	end
end

-----------------------
--  DungeonLeftItem
-----------------------

DungeonLeftItem = class("DungeonLeftItem", 
{
})

function DungeonLeftItem:ctor(transform, window, parent)
	self.transform = transform
	self.parent = parent
	self.glow = transform:FindChild("Glow")
	self.bg = transform:FindChild("Bg")
	self.head = transform:FindChild("Bg/Head/Image"):GetComponent("Image")
	self.name = transform:FindChild("Bg/Text"):GetComponent("Text")
	self.tip = transform:FindChild("Bg/Tip")
	self.tipText = transform:FindChild("Bg/Tip/Text"):GetComponent("Text")
	self.originText = self.tipText.text

	self.dungeonStageSt = nil
	self.index = 1
	window:AddClick(self.bg.gameObject, handler(self, self.OnClick))
end

function DungeonLeftItem:UpdateWith(dungeonStageSt, index)
	dungeonStageSt = dungeonStageSt --[type:DungeonStageStruct]
	self.name.text = dungeonStageSt.name

	UIUtils.LoadAvatarFullWithId(self.head, dungeonStageSt.avatarId)

	local avt = ConfigManager.avatar:GetConfig(dungeonStageSt.avatarId)
	self.head.transform.pivot = Vector2.New(avt.fullPivot.id, avt.fullPivot.value)

	if Role.level < dungeonStageSt.level then
		self.tip.gameObject:SetActive(true)
		self.tipText.text = string.format(self.originText, dungeonStageSt.level)
	else
		local dunIndex = getDungeonIndexByDungeonStageId(dungeonStageSt.id)
		local dunHardId = getHardIdByDungeonStageId(dungeonStageSt.id)

		if dunHardId == 1 then --普通关卡
			if dunIndex > 1 then
				local lastDungeonStageId = translateDungeonStageId(dungeonStageSt.id, 0, 0, -1)
				local lastSt = Role.dungeonManager:GetRoleDungeonStage(lastDungeonStageId)
				if lastSt and lastSt:IsFinish() then
					self.tip.gameObject:SetActive(false)
				else
					self.tip.gameObject:SetActive(true)
					self.tipText.text = Lang.DUNGEON_1
				end
			else
				self.tip.gameObject:SetActive(false)
			end
		elseif dunHardId == 2 then --精英关卡
			local lastDungeonStageId = translateDungeonStageId(dungeonStageSt.id, 0, -1, 0)
			local lastSt = Role.dungeonManager:GetRoleDungeonStage(lastDungeonStageId)
			if lastSt and lastSt:IsFinish() then
				self.tip.gameObject:SetActive(false)
			else
				self.tip.gameObject:SetActive(true)
				self.tipText.text = Lang.DUNGEON_4
			end
		elseif dunHardId == 3 then --大师关卡
			local lastDungeonStageId = translateDungeonStageId(dungeonStageSt.id, 0, -1, 0)
			local lastSt = Role.dungeonManager:GetRoleDungeonStage(lastDungeonStageId)
			if lastSt and lastSt:IsFinish() then
				self.tip.gameObject:SetActive(false)
			else
				self.tip.gameObject:SetActive(true)
				self.tipText.text = Lang.DUNGEON_5
			end
		end
	end

	self.dungeonStageSt = dungeonStageSt --[type:DungeonStageStruct]
	self.index = index
end

function DungeonLeftItem:SetSelect(isSelect)
	self.glow.gameObject:SetActive(isSelect)
end

function DungeonLeftItem:OnClick()
	if self.tip.gameObject.activeSelf then
		CommonUtil.ShowMsg(self.tipText.text)
		return
	end

	self.parent:SelectDungeonStage(self.index)
end
 
-----------------------
--  DungeonMiddleItem
-----------------------

DungeonMiddleItem = class("DungeonMiddleItem", 
{
})

function DungeonMiddleItem:ctor(transform, window, parent)
	self.transform = transform
	self.parent = parent
	self.image = transform:FindChild("Image"):GetComponent("Image")
	self.glow = transform:FindChild("Glow")
	self.text = transform:FindChild("Text"):GetComponent("Text")
	self.textColor = transform:FindChild("Text"):GetComponent("MultiColor")
	self.starsList = transform:FindChild("Stars")
	self.back = transform:FindChild("Back")
	self.mat = transform:FindChild("Image"):GetComponent("ImageSetMaterial")
	self.lock = false
	self.isglow = false
	self.index = 1
	self.dungeonStageCfg = nil
	self.glow.gameObject:SetActive(false)
	window:AddClick(transform.gameObject, handler(self, self.OnClick))
end

function DungeonMiddleItem:UpdateWith(dungeonStageCfg, stageIndex)
	dungeonStageCfg = dungeonStageCfg --[type:DungeonStageStruct]

	self.text.text = dungeonStageCfg:GetStageName(stageIndex)
	self.index = stageIndex
	self.mat:SetMaterial(1)
	self.textColor:SetColorIndex(-1)
	self.lock = false
	
	UIUtils.LoadAvatarWithId(self.image, dungeonStageCfg:GetStageAvatarId(stageIndex))

	if stageIndex > 1 then
		local roleSt = Role.dungeonManager:GetRoleDungeonStage(dungeonStageCfg.id)
		if roleSt then
			UIUtils.UpdateStarList(self.starsList, roleSt:GetStarByIndex(stageIndex))
			if roleSt:GetStarByIndex(stageIndex - 1) <= 0 then
				self.lock = true
				self.mat:SetMaterial(0)
				self.textColor:SetColorIndex(0)
			end
		else
			self.lock = true
			self.mat:SetMaterial(0)
			self.textColor:SetColorIndex(0)
			UIUtils.UpdateStarList(self.starsList, 0)
		end
	else
		local roleSt = Role.dungeonManager:GetRoleDungeonStage(dungeonStageCfg.id)
		if roleSt then
			UIUtils.UpdateStarList(self.starsList, roleSt:GetStarByIndex(stageIndex))
		else
			UIUtils.UpdateStarList(self.starsList, 0)
		end
	end
end

function DungeonMiddleItem:OnClick()
	if self.lock then
		CommonUtil.ShowMsg(Lang.DUNGEON_1)
		return
	end
	self.parent:SelectStage(self.index)
end

function DungeonMiddleItem:SetGlow(glowType)
	self.isglow = glowType
	self.glow.gameObject:SetActive(self.isglow)
end

function DungeonMiddleItem:SetSelect(isSelect)
	self.back.gameObject:SetActive(isSelect)
end