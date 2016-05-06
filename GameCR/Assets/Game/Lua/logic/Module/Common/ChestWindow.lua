ChestWindow = class("ChestWindow", BaseWindow)

function ChestWindow:ctor(window)
	self.path = "module/Common/ChestWindow"
	self.window = window
	self.transform = nil
	self.title = nil
	self.titleIcon = nil
	self.show = nil
	self.descCardCount = nil
	self.descLine2 = nil
	self.descSpecialCard = nil
	self.button = nil
	self.multiButtonDesc = nil
	self.consume = nil
	self.btnOpenTime = nil
	self.openningDesc = nil
	self.id = 0
	self.pos = 0
	self.dropChest = nil--[type:RoleDropChestInfo]
	self.callback = nil
	self.timer = nil
	self.type = 1 --1掉落宝箱 2商城宝箱
	self.dungeonCanOpen = true
	self.dungeonStageId = 0
	self.starNeed = 0
end

function ChestWindow:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.back = self.transform:FindChild("Back")
	self.titleIcon = GradeIcon.New(self.transform:FindChild("Bg/Title/Icon"))
	self.chestName = self.transform:FindChild("Bg/Title/Text"):GetComponent("Text")
	self.show = ChestIcon.New(self.transform:FindChild("Bg/Show/Image"))
	self.descCardCount = self.transform:FindChild("Bg/DescContainer/Down/Desc/Container/Rare/Icon/Count"):GetComponent("Text")
	self.descLine2 = self.transform:FindChild("Bg/DescContainer/Down/Desc/Container/Epic")
	self.descSpecialCard = self.transform:FindChild("Bg/DescContainer/Down/Desc/Container/Epic/Icon/Count"):GetComponent("Text")
	self.button = self.transform:FindChild("Bg/Button")
	self.buttonMat = self.transform:FindChild("Bg/Button"):GetComponent("ImageSetMaterial")
	self.multiButtonDesc = self.button:GetComponent("MultiObject")
	self.consume = self.button:FindChild("Icon/Text"):GetComponent("Text")
	self.btnOpenTime = self.button:FindChild("Text"):GetComponent("Text")
	self.openningDesc = self.transform:FindChild("Bg/OpenningDesc"):GetComponent("MultiObject")
	self.openningDescTime = self.transform:FindChild("Bg/OpenningDesc/Tip1/Time"):GetComponent("Text")
	self.coinText = self.transform:FindChild("Bg/DescContainer/Up/Coin/Text"):GetComponent("Text")
	self.cardText = self.transform:FindChild("Bg/DescContainer/Up/Card/Text"):GetComponent("Text")
	self.down = self.transform:FindChild("Bg/DescContainer/Down")
	self.starNeedText = self.transform:FindChild("Bg/OpenningDesc/Tip3"):GetComponent("Text")
	self.timer = Timer.New(handler(self, self.OnUpdate), 1, -1, TimerGroup.UI):Start()
	self.transform:SetParent(MainPanel.transform, false)

	self.window:AddClick(self.button.gameObject, handler(self, self.OnClickButton))
	self.window:AddClick(self.back.gameObject, handler(self, self.OnClickClose))

	local chest = ConfigManager.chest --[type:ChestConfig]
	local st = chest:GetConfig(self.id) --[type:ChestStruct]
	local min, max = chest:GetCoinRange(self.id)
	self.coinText.text = tostring(min) .. "-" .. tostring(max)
	self.cardText.text = "x" .. tostring(chest:GetBoxCount(self.id))

	local box3 = not st.box3:IsNull() and tonumber(st.box3.value) or 0
	local box4 = not st.box4:IsNull() and tonumber(st.box4.value) or 0
	if box3 + box4 > 0 then
		self.down.gameObject:SetActive(true)
		self.descCardCount.text = string.format(self.descCardCount.text, box3)
		self.descSpecialCard.text = string.format(self.descSpecialCard.text, box4)

		self.descLine2.gameObject:SetActive(true)
		if box4 <= 0 then
			self.descLine2.gameObject:SetActive(false)
		end
	else
		self.down.gameObject:SetActive(false)
	end

	local typeSt = ConfigManager.chestType:GetConfig(st.type)
	self.chestName.text = typeSt.name
	textFormat(self, self.starNeedText, self.starNeed)

	self.show:SetStateById(st.chestId)

	local g = Role.GetGrade()
	self.titleIcon:SetGrade(g.id)

	if self.type == 1 then
		self:UpdateDropChest()
	elseif self.type == 2 then
		self:UpdateShopChest()
	elseif self.type == 3 then
		self:UpdateDungeonChest()
	end

	EventManager.AddEventListener(self, "S_PreOpenArenaChest_0x332", handler(self, self.PreOpenArenaChest))
end

function ChestWindow:PreOpenArenaChest(msg)
	if self.type == 1 then
		self:OnClickClose()
	end
end

function ChestWindow:UpdateDungeonChest()
	self.multiButtonDesc:SetObjectIndex(0)
	self.btnOpenTime.text = Lang.COMMON_CHEST_WINDOW_1

	if self.dungeonCanOpen then
		self.buttonMat:SetMaterial(1)
		self.openningDesc.gameObject:SetActive(false)
	else
		self.buttonMat:SetMaterial(0)
		self.openningDesc.gameObject:SetActive(true)
		self.openningDesc:SetObjectIndex(2)
	end
end

function ChestWindow:UpdateShopChest()
	self.multiButtonDesc:SetObjectIndex(1)
	self.openningDesc.gameObject:SetActive(false)
	print("========================: " .. self.id)
	local cst = ConfigManager.chest:GetConfig(self.id)
	self.consume.text = cst.money
end

function ChestWindow:UpdateDropChest()
	if self.dropChest.status == 1 then --lock
		if Role.chestManager.unlockingPos < 0 then
			self.multiButtonDesc:SetObjectIndex(0)
			self.openningDesc.gameObject:SetActive(false)
		else
			self.multiButtonDesc:SetObjectIndex(1)
			self.openningDesc.gameObject:SetActive(true)
			self.openningDesc:SetObjectIndex(1)
		end

		local ctype = ConfigManager.chest:GetChestTypeConfig(self.id)
		self.btnOpenTime.text = TimeUtil.ToDHMSS(ctype.time)
		self.consume.text = chestTimeToMoney(ctype.time)

		GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {2}})
	elseif self.dropChest.status == 2 then --unlocking
		self.multiButtonDesc:SetObjectIndex(1)
		self.openningDesc.gameObject:SetActive(true)
		self.openningDesc:SetObjectIndex(0)
		GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {5}})
	end

	self:OnUpdate()
end

function ChestWindow:OnUpdate(delta)
	if self.type == 1 then
		if self.dropChest.status == 2 then --unlocking...
			self.consume.text = chestTimeToMoney(self.dropChest.unlockTicks)
			if self.dropChest.pos == Role.chestManager.unlockingPos then
				self.openningDescTime.text = TimeUtil.ToDHMSS(self.dropChest.unlockTicks, 4)
			end
		end
	end
end

function ChestWindow:OnClickButton()
	if self.type == 1 then --dropChest
		if self.dropChest.status == 1 then --lock
			if Role.chestManager.unlockingPos < 0 then
				GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {3}})
				ChestProto.C_UnlockArenaChest_0x331(self.dropChest.pos)
			else
				if Role.money < toInt(self.consume.text) then
					CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_1)
				else
					local p = OpenChestParam.New()
					p.chestType = 3
					p.chestId = self.dropChest.chestId
					p.pos = self.dropChest.pos
					p.byMoney = true
					Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
				end
			end
		elseif self.dropChest.status == 2 then --unlocking
			if Role.money < toInt(self.consume.text) then
				CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_1)
			else
				local p = OpenChestParam.New()
				p.chestType = 3
				p.chestId = self.dropChest.chestId
				p.pos = self.dropChest.pos
				p.byMoney = true
				GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {6}})

				Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
			end
		end
	elseif self.type == 2 then
		if Role.money < toInt(self.consume.text) then
			CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_1)
		else
			local p = OpenChestParam.New()
			p.chestType = 4
			p.chestId = self.id
			p.byMoney = true
			Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
		end
	elseif self.type == 3 then
		if not self.dungeonCanOpen then
			return
		else
			local p = OpenChestParam.New()
			p.chestType = 5
			p.chestId = self.id
			p.byMoney = false
			p.dungeonStageId = self.dungeonStageId
			p.backMenuId = MenuType.Dungeon
			p.backMenuParam = true
			Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
		end
	end
	self:OnClickClose()
end

function ChestWindow:ShowByPos(pos, callback)
	self.type = 1
	self.pos = pos
	self.dropChest = Role.chestManager:GetDropChestByPos(pos)
	self.id = self.dropChest.chestId
	self.callback = callback
	self:Load()
end

function ChestWindow:ShowByShop(id, callback)
	self.type = 2
	self.id = id
	self.callback = callback
	self:Load()
end

function ChestWindow:ShowByDungeon(id, dungeonStageId, canopen, starNeed, callback)
	self.type = 3
	self.id = id
	self.starNeed = starNeed
	self.dungeonStageId = dungeonStageId
	self.callback = callback
	self.dungeonCanOpen = canopen
	self:Load()
end

function ChestWindow:OnClickClose()
	EventManager.RemoveListener(self)

	self.timer:Stop()
	self.super.OnCloseWindow(self)
end