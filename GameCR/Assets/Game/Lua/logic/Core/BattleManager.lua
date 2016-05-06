BattleManager = class("BattleManager", {
	battleParam = nil, --[type:BattleParam]
	battleEndParam = nil,
})

----------------------------------------------
--  管理不同类型的战斗启动与结束
----------------------------------------------

local this = BattleManager

function BattleManager.Init()
	EventManager.AddEventListener(this, "S_PvPMatched_0x802", this.OnPVPMatch)
	EventManager.AddEventListener(this, "S_BattleRoomPrepare_0x810", this.OnBattleRoomPrepare)
	EventManager.AddEventListener(this, "S_BattleEnd_0x830", this.OnBattleEnd)
	EventManager.AddEventListener(this, "S_StartSubStage_0x901", this.OnStartSubStage)
end

--训练模式
function BattleManager.StartTrain()
	local trainSt = ConfigManager.train:GetConfig(Role.newGuideStep)
	local stageId = 0
	if trainSt.trainType == 1 then
		stageId = trainSt.stageId
	else
		--临时数据
		-- local allStage = {30001, 30002, 30003, 30004, 30005, 30006}
		local StageType = Games.Module.Wars.StageType
		local enumerator = War.model.stageConfigs_Index:GetEnumerator()
		local idx = 1
		local allStage = {}
		while enumerator:MoveNext() do
			local stageCfg = enumerator.Current.Value
			if stageCfg.type == StageType.Arena and stageCfg.nextStageId <= Role.GetGrade().id then
				allStage[idx] = enumerator.Current.Value.id
				idx = idx + 1
			end
		end
		stageId = allStage[math.random(1, #allStage)]
	end

	local p = BattleParam.New()
	p.battleType = BattleType.PVE_Train
	p.battleStageId = stageId

	--self ...
	p.selfRoleInfo = this.CreateSelfFightInfo(1)

	--other ...
	p.otherRoleInfos = {}
	table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(trainSt.legion2, 2))
	table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(trainSt.legion3, 3))
	table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(trainSt.legion4, 4))
	table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(trainSt.legion0, 0))

	this.battleParam = p
	this.OnStartBattle()
end

--副本模式
function BattleManager.StartDungeon(dungeonStageId, substage_index)
	DungeonProto.C_StartSubStage_0x901(dungeonStageId, substage_index)
end

--匹配模式
function BattleManager.MatchPVP(matchType)
	local p = BattleParam.New()
	p.battleType = matchType
	this.battleParam = p

	ArenaProto.C_AttendMatcher_0x800(matchType)
end

function BattleManager.LeaveMatchPVP()
	ArenaProto.C_LeaveMatcher_0x801()
end

function BattleManager.OnPVPMatch(msg)
	this.battleParam:InitWithPVPMatcheProto(msg)
end

function BattleManager.OnBattleRoomPrepare()
	this.OnStartBattle()
end

function BattleManager.OnBattleEnd(msg)
	this.battleEndParam = BattleEndParam.New()
	this.battleEndParam:InitWith(msg)

	Role.chestManager:UpdateByProto(msg.chests)

	if not PlayerPrefsUtil.HasKey(PlayerPrefsKey.TipImage_FirstArena) then
	    -- PlayerPrefsUtil.SetInt(PlayerPrefsKey.TipImage_FirstArena, 1)
	end
end

function BattleManager.OnStartSubStage(msg)
	local dungeonCfg = ConfigManager.dungeonStage:GetConfig(msg.dungeonStageId)
	local p = BattleParam.New()
	p.battleType = BattleType.PVE_Dungeon
	p.battleStageId = dungeonCfg:GetStageId(msg.substage_index)
	p.dungeonStageId = msg.dungeonStageId
	p.dungeonStageIndex = msg.substage_index

	--self ...
	p.selfRoleInfo = this.CreateSelfFightInfo(1)

	--other ...
	p.otherRoleInfos = {}
	for i=2,4 do
		local robotId =  War.model:GetRobotId(dungeonCfg:GetStageId(msg.substage_index), i)
		if robotId > 0 then
			table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(robotId, i))
		end
	end
	local robotId =  War.model:GetRobotId(dungeonCfg:GetStageId(msg.substage_index), 0)
	if robotId > 0 then
		table.insert(p.otherRoleInfos, this.CreateFightInfoByRobotId(robotId, 0))
	end

	print_table_sp(p.otherRoleInfos, "all")

	this.battleParam = p
	this.OnStartBattle()

	MainManager.SetExitWarMenu(MenuType.Dungeon, 1)
end

function BattleManager.OnStartBattle()
	local bparam = this.battleParam --[type:BattleParam]
	local warGameData = Games.Module.Wars.WarEnterData.New()
	warGameData.backMenuId = MenuType.Home
	warGameData.overMenuId = MenuType.BattleEnd1v1
	warGameData.stageId = bparam.battleStageId
	warGameData.ownRoleId = Role.roleId
	warGameData.ownLegionId = bparam.selfRoleInfo.teamId
	warGameData.rivalRoleId = bparam.otherRoleInfos[1].teamId

	local isPVP = false
	if bparam.battleType == BattleType.PVP_1_VS_1 then
		warGameData.vsmode = VSMode.PVP
		isPVP = true
	elseif bparam.battleType == BattleType.PVE_Dungeon then
		warGameData.vsmode = VSMode.Dungeon
	elseif bparam.battleType == BattleType.PVE_Train then
		warGameData.vsmode = VSMode.Train
	end

	--self role
	local selfTeam = this.CreateLegionData(bparam.selfRoleInfo)
	warGameData.legionList:Add(selfTeam)

	--other roles
	for i,v in ipairs(bparam.otherRoleInfos) do
		local legionData = this.CreateLegionData(v)
		if legionData.isRobot and isPVP then
			local facAtk, facPro, facSpe = Role.GetRobotFloatProp()
			legionData.totalAtk = legionData.totalAtk * facAtk
			legionData.totalProduceSpeed = legionData.totalProduceSpeed * facPro
			legionData.totalMoveSpeed = legionData.totalMoveSpeed * facSpe
			legionData.prop1Factor = facAtk
			legionData.prop2Factor = facPro
			legionData.prop3Factor = facSpe

			v.factorProp1 = facAtk
			v.factorProp2 = facPro
			v.factorProp3 = facSpe
		end
		warGameData.legionList:Add(legionData)
	end

	Coo.soundManager:ChangeMusicBg("none")
	War.Start (warGameData)
end

function BattleManager.CreateSelfFightInfo(teamId)
	local selfRoleInfo = FightRoleInfo.New()
	selfRoleInfo.isRobot = false
	selfRoleInfo.teamId = teamId

	local roleInfo = RoleBaseInfo.New()
	roleInfo.level = Role.level
	roleInfo.roleId = Role.roleId
	roleInfo.name = Role.name
	roleInfo.prize = Role.prize
	roleInfo.icon = Role.avatarId

	selfRoleInfo.roleInfo = roleInfo
	selfRoleInfo.fightSoldier = Role.soldierManager.battleSoldier
	selfRoleInfo.fightCards = {}

	local bcs = Role.cardManager.battleCards
	for k,v in pairs(bcs) do
		local fightCard = FightCardInfo.New()
		fightCard.cardId = v
		fightCard.level = Role.cardManager:GetCard(v).level
		table.insert(selfRoleInfo.fightCards, fightCard)
	end

	return selfRoleInfo
end

function BattleManager.CreateFightInfoByRobotId(robotId, teamId)
	if robotId <= 0 then
		return nil
	end

	local robotSt = ConfigManager.robot:GetConfig(robotId)
	local fightInfo = FightRoleInfo.New()
	fightInfo.teamId = teamId
	fightInfo.isRobot = true
	fightInfo.robotAi = robotSt.AiId

	local roleInfo = RoleBaseInfo.New()
	roleInfo.level = robotSt.level
	roleInfo.name = robotSt.name
	roleInfo.prize = robotSt.Trophy
	roleInfo.icon = robotSt.avatar

	fightInfo.roleInfo = roleInfo
	fightInfo.fightSoldier = robotSt.soldier--30101
	fightInfo.fightCards = {}

	for i=1,4 do
		local fightCard = FightCardInfo.New()
		fightCard.cardId = robotSt["card" .. i]
		fightCard.level = robotSt["card" .. i .. "level"]
		table.insert(fightInfo.fightCards, fightCard)
	end

	return fightInfo
end

function BattleManager.CreateLegionData(fightRoleInfo)
	fightRoleInfo = fightRoleInfo --[type:FightRoleInfo]
	baseRoleInfo = fightRoleInfo.roleInfo --[type:RoleBaseInfo]

	local legionData = Games.Module.Wars.WarEnterLegionData.New()
	legionData.name = baseRoleInfo.name
	legionData.roleId = baseRoleInfo.roleId
	legionData.legionId = fightRoleInfo.teamId
	legionData.isRobot = fightRoleInfo.isRobot
	legionData.headAvatarId = fightRoleInfo.roleInfo.icon
	legionData.ai = fightRoleInfo.robotAi

	local soldierData = Games.Module.Wars.WarEnterSoliderData.New()
	soldierData.avatarId = fightRoleInfo.fightSoldier
	legionData.solider = soldierData

	--英雄卡片
	local cardIds = {}
	for k, v in ipairs(fightRoleInfo.fightCards) do
		if v.cardId ~= 0 then
			local cardCfg = ConfigManager.card:GetConfig(v.cardId)
			local heroData = Games.Module.Wars.WarEnterHeroData()
			heroData.name = cardCfg.name
			heroData.heroId = v.cardId
			heroData.avatarId = cardCfg.avatarID
			heroData.skillId = cardCfg.skill
			-- heroData.quality = cardCfg.quality
			heroData.level = v.level

			local roleCard = RoleCard.New()
			roleCard.cardId = v.cardId
			roleCard.level = v.level

			local list = {}
			local roleList = roleCard:GetAllProps()
			for i,v in ipairs(roleList) do
				local csprop = CSProp.CreateInstance(v[1], v[2])
				table.insert(list, csprop)
			end
			heroData.props = list
			legionData.heroList:Add(heroData)

			table.insert(cardIds, {v.cardId, v.level})
		end
	end

	local expCfg = ConfigManager.exp:GetConfig(baseRoleInfo.level)
	legionData.atk = expCfg.atk
	legionData.produceSpeed = expCfg.produce
	legionData.movespeed = expCfg.speed
	legionData.maxAtk = expCfg.maxAtk
	legionData.maxProduceSpeed = expCfg.maxProduce
	legionData.maxMovespeed = expCfg.maxSpeed
	legionData.subAtk = expCfg.sub[1]
	legionData.subProduceSpeed = expCfg.sub[2]
	legionData.subMoveSpeed = expCfg.sub[3]
	legionData.initHP = expCfg.initTroop
	legionData.prize = baseRoleInfo.prize
	legionData.level = baseRoleInfo.level

	local atk, proSpe, spe = BattleManager.GetTotalBattleProp(cardIds, fightRoleInfo.fightSoldier, baseRoleInfo.level)
	legionData.totalAtk = atk
	legionData.totalProduceSpeed = proSpe
	legionData.totalMoveSpeed = spe

	return legionData
end

--实际战斗力
function BattleManager.GetTotalBattleProp(cardIds, soldier, level)
	local totalAtkBar, totalAtkValue = 0, 0
	local totalDefBar, totalDefValue = 0, 0
	local totalSpBar, totalSpValue = 0, 0
	local factor = Games.ConstConfig.GetFloat(Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio)
	for i,v in ipairs(cardIds) do
		if v[1] > 0 then
			local cardCfg = ConfigManager.card:GetConfig(v[1])
			totalAtkValue 	= totalAtkValue + cardCfg:GetAtk(v[2])
			totalDefValue 	= totalDefValue + cardCfg:GetProduceSpe(v[2]) * factor
			totalSpValue 	= totalSpValue + cardCfg:GetSpe(v[2])
		end
	end

	if soldier ~= nil then
		local soldierCfg = ConfigManager.soldier:GetConfig(soldier)
		if soldierCfg then
			totalAtkValue = totalAtkValue + soldierCfg:GetProp1()
			totalDefValue = totalDefValue + soldierCfg:GetProp2()
			totalSpValue = totalSpValue + soldierCfg:GetProp3()
		end
	end

	local expCfg = ConfigManager.exp:GetConfig(level)
	totalAtkValue = totalAtkValue + expCfg.atk
	totalDefValue = totalDefValue + expCfg.produce
	totalSpValue = totalSpValue + expCfg.speed

	return totalAtkValue, totalDefValue, totalSpValue
end

--显示战斗力
function BattleManager.GetTotalDisplayBattleProp(cardIds, soldier, level)
	local totalAtkValue, totalDefValue, totalSpValue = BattleManager.GetTotalBattleProp(cardIds, soldier, level)
	local maxAtkValue, maxDefValue, maxSpValue = 0
	local expCfg = ConfigManager.exp:GetConfig(level)

	local propCfg =  ConfigManager.prop:GetConfig(PropId.AtkAdd)
	totalAtkValue = totalAtkValue * propCfg.displayMultiplier - expCfg.sub[1]
	maxAtkValue = expCfg.maxAtk * propCfg.displayMultiplier 

	propCfg =  ConfigManager.prop:GetConfig(PropId.ProduceSpeedAdd)
	totalDefValue = totalDefValue * propCfg.displayMultiplier - expCfg.sub[2]
	maxDefValue = expCfg.maxProduce * propCfg.displayMultiplier 

	propCfg =  ConfigManager.prop:GetConfig(PropId.MoveSpeedAdd)
	totalSpValue = totalSpValue * propCfg.displayMultiplier - expCfg.sub[3]
	maxSpValue = expCfg.maxSpeed * propCfg.displayMultiplier 

	return totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue
end

BattleManager.Init()