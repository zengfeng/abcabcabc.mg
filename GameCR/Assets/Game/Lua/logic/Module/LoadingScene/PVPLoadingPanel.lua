local this = definePanel("PVPLoadingPanel")

-----------------------	
--  VSItem
-----------------------

local VSItem = class("VSItem")

function VSItem:ctor(transform)
	self.progress = transform:FindChild("Progress"):GetComponent("Text")
	self.name = transform:FindChild("Title/Name"):GetComponent("Text")
	self.grade = transform:FindChild("Title/Grade"):GetComponent("MultiImage")
	self.head = transform:FindChild("Head/Icon"):GetComponent("Image")
	self.prop1Prog = transform:FindChild("Content/Prop1/Progress"):GetComponent("Slider")
	self.prop1Text = transform:FindChild("Content/Prop1/Text"):GetComponent("Text")
	self.prop1TextMul = transform:FindChild("Content/Prop1/Text"):GetComponent("MultiColor")
	self.prop2Prog = transform:FindChild("Content/Prop2/Progress"):GetComponent("Slider")
	self.prop2Text = transform:FindChild("Content/Prop2/Text"):GetComponent("Text")
	self.prop2TextMul = transform:FindChild("Content/Prop2/Text"):GetComponent("MultiColor")
	self.prop3Prog = transform:FindChild("Content/Prop3/Progress"):GetComponent("Slider")
	self.prop3Text = transform:FindChild("Content/Prop3/Text"):GetComponent("Text")
	self.prop3TextMul = transform:FindChild("Content/Prop3/Text"):GetComponent("MultiColor")

end

function VSItem:UpdateWith(fightRoleInfo)
	fightRoleInfo = fightRoleInfo --[type:FightRoleInfo]
	self.name.text = fightRoleInfo.roleInfo.name

	local gradeCfg = ConfigManager.grade:GetConfigByPrize(fightRoleInfo.roleInfo.prize)
	self.grade:SetImageIndex(gradeCfg.id - 1)

	UIUtils.LoadAvatarWithId(self.head, fightRoleInfo.roleInfo.icon)

	local cardIds = {}
	for i,v in ipairs(fightRoleInfo.fightCards) do
		table.insert(cardIds, {v.cardId, v.level})
	end
	local totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue = 
				BattleManager.GetTotalDisplayBattleProp(cardIds, fightRoleInfo.fightSoldier, fightRoleInfo.roleInfo.level)

	if Role.roleId == fightRoleInfo.roleInfo.roleId then
		UIUtils.UpdateProgress(self.prop1Prog, maxAtkValue, totalAtkValue)
		self.prop1Text.text = math.floor(totalAtkValue * fightRoleInfo.factorProp1)

		UIUtils.UpdateProgress(self.prop2Prog, maxDefValue, totalDefValue)
		self.prop2Text.text =  math.floor(totalDefValue * fightRoleInfo.factorProp2)

		UIUtils.UpdateProgress(self.prop3Prog, maxSpValue, totalSpValue)
		self.prop3Text.text =  math.floor(totalSpValue * fightRoleInfo.factorProp3)

		local rival = BattleManager.battleParam.otherRoleInfos[1]
		if rival then
			local cardIds = {}
			for i,v in ipairs(rival.fightCards) do
				table.insert(cardIds, {v.cardId, v.level})
			end
			local otherProp1, otherProp2, otherProp3, otherProp1Max, otherProp2Max, otherProp3Max = 
						BattleManager.GetTotalDisplayBattleProp(cardIds, rival.fightSoldier, rival.roleInfo.level)

			local arrSelf = {totalAtkValue, totalDefValue, totalSpValue}
			local arrVal = {otherProp1 * rival.factorProp1, otherProp2 * rival.factorProp1, otherProp3 * rival.factorProp1}
			local arrMul = {self.prop1TextMul, self.prop2TextMul, self.prop3TextMul}
			for i=1,3 do
				if math.floor(arrSelf[i]) == math.floor(arrVal[i]) then
					arrMul[i]:SetColorIndex(-1)
				elseif math.floor(arrSelf[i]) < math.floor(arrVal[i]) then
					arrMul[i]:SetColorIndex(0)
				else
					arrMul[i]:SetColorIndex(1)
				end
			end
		end
	else
		if Role.GetGrade().id < RoleConst.GRADE_OF_HIDE_RIVAL_INFO then
			UIUtils.UpdateProgress(self.prop1Prog, maxAtkValue, totalAtkValue)
			self.prop1Text.text = math.floor(totalAtkValue * fightRoleInfo.factorProp1)

			UIUtils.UpdateProgress(self.prop2Prog, maxDefValue, totalDefValue)
			self.prop2Text.text =  math.floor(totalDefValue * fightRoleInfo.factorProp2)

			UIUtils.UpdateProgress(self.prop3Prog, maxSpValue, totalSpValue)
			self.prop3Text.text =  math.floor(totalSpValue * fightRoleInfo.factorProp3)
		else
			UIUtils.UpdateProgress(self.prop1Prog, 1, 0.13)
			self.prop1Text.text = "???"

			UIUtils.UpdateProgress(self.prop2Prog, 1, 0.13)
			self.prop2Text.text =  "???"

			UIUtils.UpdateProgress(self.prop3Prog, 1, 0.13)
			self.prop3Text.text =  "???"
		end
		print_sp("factorStart", fightRoleInfo.factorProp1, fightRoleInfo.factorProp2, fightRoleInfo.factorProp3)
	end
end

function VSItem:UpdateWithWarEnterLegionData(warEnterLegionData, otherEnterLegionData)
	self.name.text = warEnterLegionData.name

	local gradeCfg = ConfigManager.grade:GetConfigByPrize(warEnterLegionData.prize)
	if gradeCfg then
		self.grade:SetImageIndex(gradeCfg.id - 1)
	end

	UIUtils.LoadAvatarWithId(self.head, warEnterLegionData.headAvatarId)

	local cardIds = {}
	for i=0,warEnterLegionData.heroList.Count-1 do
		local heroData = warEnterLegionData.heroList[i]
		table.insert(cardIds, {heroData.heroId, heroData.level})
	end

	local totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue = 
			BattleManager.GetTotalDisplayBattleProp(cardIds, warEnterLegionData.solider.id, warEnterLegionData.level)

	UIUtils.UpdateProgress(self.prop1Prog, maxAtkValue, totalAtkValue)
	self.prop1Text.text = math.floor(totalAtkValue * warEnterLegionData.prop1Factor)

	UIUtils.UpdateProgress(self.prop2Prog, maxDefValue, totalDefValue)
	self.prop2Text.text =  math.floor(totalDefValue * warEnterLegionData.prop2Factor)

	UIUtils.UpdateProgress(self.prop3Prog, maxSpValue, totalSpValue)
	self.prop3Text.text =  math.floor(totalSpValue * warEnterLegionData.prop3Factor)

	print_sp("factorEnd", warEnterLegionData.prop1Factor, warEnterLegionData.prop2Factor, warEnterLegionData.prop3Factor)

	if otherEnterLegionData then
		cardIds = {}
		for i=0,otherEnterLegionData.heroList.Count-1 do
			local heroData = otherEnterLegionData.heroList[i]
			table.insert(cardIds, {heroData.heroId, heroData.level})
		end

		local otherProp1, otherProp2, otherProp3, otherProp1Max, otherProp2Max, otherProp3Max = 
				BattleManager.GetTotalDisplayBattleProp(cardIds, otherEnterLegionData.solider.id, otherEnterLegionData.level)

		local arrSelf = {totalAtkValue, totalDefValue, totalSpValue}
		local arrVal = {otherProp1 * otherEnterLegionData.prop1Factor, 
						otherProp2 * otherEnterLegionData.prop2Factor,
						otherProp3 * otherEnterLegionData.prop3Factor}
		local arrMul = {self.prop1TextMul, self.prop2TextMul, self.prop3TextMul}
		for i=1,3 do
			if math.floor(arrSelf[i]) == math.floor(arrVal[i]) then
				arrMul[i]:SetColorIndex(-1)
			elseif math.floor(arrSelf[i]) < math.floor(arrVal[i]) then
				arrMul[i]:SetColorIndex(0)
			else
				arrMul[i]:SetColorIndex(1)
			end
		end
	end
end

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	thisPanel = gameObject.transform
	vsSelf = thisPanel:FindChild("Self")
	vsEnemy = thisPanel:FindChild("Rival")
	-- progress = thisPanel:FindChild("Progress"):GetComponent("Slider")
	sceneLoader = thisPanel:GetComponent("LuaScreenLoadPanel").sceneLoader
	tip = transform:FindChild("Tip"):GetComponent("Text")
	sceneLoader.minLoadTimeDelta = 3
	tipText = tip.text
	tip.text = string.format(tipText, ConfigManager.tip:GetRand())
	timer = Timer.New(OnTimer, 5, -1, TimerGroup.UI):Start(true)

	vsSelfItem = VSItem.New(vsSelf)
	vsEnemyItem = VSItem.New(vsEnemy)

	if War.isRecord == false then
		battleParam = BattleManager.battleParam --[type:BattleParam]
		if battleParam then
			vsSelfItem:UpdateWith(battleParam.selfRoleInfo)
			vsEnemyItem:UpdateWith(battleParam.otherRoleInfos[1])
		end
	else
		vsSelfItem:UpdateWithWarEnterLegionData(War.enterData.legionList[0], War.enterData.legionList[1])
		vsEnemyItem:UpdateWithWarEnterLegionData(War.enterData.legionList[1])
	end

	EventManager.AddEventListener(this, "S_BattleLoad_0x811", OnBattleLoad)
end

function OnDestroy( ... )
	thisPanel = nil

	if timer then
		timer:Stop()
	end
	timer = nil
end

function OnTimer(delta)
	tip.text = string.format(tipText, ConfigManager.tip:GetRand())
end

function OnBattleLoad(msg)
	if Role.roleId == msg.roleId then
		vsSelfItem.progress.text = msg.progress .. "%"
	else
		vsEnemyItem.progress.text = msg.progress .. "%"
	end
end

function SetProgress(prog)
	if not thisPanel then
		return
	end

	local param = BattleManager.battleParam
	if param and War.isRecord == false then
		if param.battleType ~= BattleType.PVE_Dungeon then
			return
		end
	end

	vsSelfItem.progress.text = math.floor(prog*100) .. "%"
	-- progress.value = prog
end