DungeonSelect = class("DungeonSelect", 
{
})

function DungeonSelect:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.dungeonList = {}

	for i=1,3 do
		local item = DungeonItem.New(transform:FindChild("List/Content/DungeonItemContainer" .. i .. "/DungeonItem"), window)
		item:UpdateById(i)
		table.insert(self.dungeonList, item)
	end

	--self.back = transform:FindChild("Back")
	--window:AddClick(self.back.gameObject, handler(self, self.OnClickClose))
end

function DungeonSelect:OnEnter()
	MainPanel.backCallback = handler(self, self.OnClickClose)
end

function DungeonSelect:OnClickClose()
	self.window:Exit()
end

-----------------------
--  DungeonItem
-----------------------

DungeonItem = class("DungeonItem", 
{
})

function DungeonItem:ctor(transform, window)
	self.transform = transform
	self.desc = transform:FindChild("Desc"):GetComponent("MultiObject")
	self.lockLv = transform:FindChild("Desc/LevelTip"):GetComponent("Text")
	self.progress = transform:FindChild("Desc/Progress"):GetComponent("Text")
	self.tagText = transform:FindChild("TagBg/Text"):GetComponent("Text")
	self.tagMask = transform:FindChild("TagBg/Mask")
	self.dungeonItem = transform:GetComponent("ImageSetMaterial")
	self.dungeonId = 0
	self.isLock = false
	self.window = window

	window:AddClick(transform.gameObject, handler(self, self.OnClick))
end

function DungeonItem:UpdateById(id)
	local cfg =  ConfigManager.dungeon:GetConfig(id)
	self.tagText.text = cfg.name
	self.isLock = false

	if Role.level < cfg.level then
		self.desc:SetObjectIndex(0)
		textFormat(self, self.lockLv, cfg.level)

		self.dungeonItem:SetMaterial(0)
		self.tagMask.gameObject:SetActive(true)
		self.isLock = true
	else
		self.desc:SetObjectIndex(1)
		self.dungeonItem:SetMaterial(1)
		self.tagMask.gameObject:SetActive(false)

		local dun = Role.dungeonManager:GetLastDungeon(id, 1)
		if dun then
			local dunCfg = dun:GetConfig()
			local name = dunCfg:GetStageName(dun:GetProgressIdx())
			textFormat(self, self.progress, name)
		else
			self.desc:SetObjectIndex(-1)
		end
	end
	self.dungeonId = id
end

function DungeonItem:OnClick()
	if self.isLock then
		CommonUtil.ShowMsg(self.lockLv.text)
		return
	end

	if self.dungeonId == 1 then
		local win = MsgWindow.New(DungeonPanel.transform, self.window)
		win:SetMsg(nil, Lang.HOME_TRAIN_END_SUBTITLE, Lang.HOME_TRAIN_END_DESC)
		win:Show(function()
			BattleManager.StartTrain()
		end)
	else
		DungeonPanel.ShowDungeonInfo(self.dungeonId, 1)
	end
end