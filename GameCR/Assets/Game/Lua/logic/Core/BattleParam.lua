require "logic/Core/BattleType"

-----------------------	
--  BattleParam
-----------------------

BattleParam = class("BattleParam")

function BattleParam:ctor()
	self.battleType = nil --[type:BattleType]
	self.selfRoleInfo = nil --[type:FightRoleInfo]
	self.otherRoleInfos = {} --[type:FightRoleInfo]
	self.dungeonStageId = 0
	self.dungeonStageIndex = 1
end

function BattleParam:InitWithPVPMatcheProto(pvpMatchProto)
	self.matcherType = pvpMatchProto.matcher_type
	self.battleRoomId = pvpMatchProto.battle_room_id
	self.battleStageId = pvpMatchProto.battle_stage_id
	self.otherRoleInfos = {}

	for i,v in ipairs(pvpMatchProto.fight_roles) do
		if v.role_info.roleId == Role.roleId then
			self.selfRoleInfo = FightRoleInfo.New(v)
		else
			table.insert(self.otherRoleInfos, FightRoleInfo.New(v, true))
		end
	end
end

function BattleParam:GetFightRoleInfoById(roleId)--[return:FightRoleInfo]
	if self.selfRoleInfo.roleInfo.roleId == roleId then
		return self.selfRoleInfo
	end

	for i,v in ipairs(self.otherRoleInfos) do
		if v.roleInfo.roleId == roleId then
			return v
		end
	end
end





-----------------------	
--  BattleEndParam
-----------------------

BattleEndParam = class("BattleEndParam")

function BattleEndParam:ctor()
	self.prize = 0
	self.arenaFightWin = 0
	self.arenaFightCount = 0
	self.arenaStreakLose = 0
	self.isDrop = false
	self.fightResult = nil --[type:RoleFightResult]
end

function BattleEndParam:InitWith(battleEndProto)
	self.prize = battleEndProto.prize
	self.arenaFightWin = battleEndProto.arena_fight_win
	self.arenaFightCount = battleEndProto.arena_fight_count
	self.arenaStreakLose = battleEndProto.arena_streak_lose
	self.isDrop = battleEndProto.is_drop

	self.fightResult = {}
	for i,v in ipairs(battleEndProto.fight_result) do
		table.insert(self.fightResult, RoleFightResult.New(v))
	end
end

-----------------------	
--  RoleFightResult
-----------------------

RoleFightResult = class("RoleFightResult")

function RoleFightResult:ctor(protoRoleFightResult)
	self.roleId = 0
	self.endType = 1
	self.star = 1
	self.buildCount = 1
	self.buildTotal = 1

	if protoRoleFightResult then
		self:Init(protoRoleFightResult)
	end
end

function RoleFightResult:Init(protoRoleFightResult)
	self.roleId = protoRoleFightResult.roleId
	self.endType = protoRoleFightResult.end_type
	self.star = protoRoleFightResult.star
	self.buildCount = protoRoleFightResult.build_count
	self.buildTotal = protoRoleFightResult.build_total
end

-----------------------	
--  FightRoleInfo
-----------------------

FightRoleInfo = class("FightRoleInfo")

function FightRoleInfo:ctor(fightRoleInfoProto, useFakeName)
	self.roleInfo = nil --[type:RoleBaseInfo]
	self.fightSoldier = 0
	self.fightCards = {} --[type:FightCardInfo]
	self.isRobot = false
	self.robotAi = 0
	self.teamId = 0
	self.teamGroup = 0
	self.useFakeName = useFakeName or false
	self.arenaStreakVictory = 0

	--机器人浮动值
	self.factorProp1 = 1
	self.factorProp2 = 1
	self.factorProp3 = 1

	if fightRoleInfoProto then
		self:Init(fightRoleInfoProto)
	end
end

function FightRoleInfo:Init(fightRoleInfoProto)
	self.roleInfo = RoleBaseInfo.New(fightRoleInfoProto.role_info)

	self.fightSoldier = fightRoleInfoProto.battle_info.battle_soldier
	self.fightCards = {}
	for i,v in ipairs(fightRoleInfoProto.battle_info.battle_cards) do
		local card = FightCardInfo.New(v)
		table.insert(self.fightCards, card)
	end

	self.isRobot = fightRoleInfoProto.is_robot
	self.robotAi = fightRoleInfoProto.robot_ai
	self.teamId = fightRoleInfoProto.team_id
	self.teamGroup = fightRoleInfoProto.team_group
	self.arenaStreakVictory = fightRoleInfoProto.arena_streak_victory

	if self.isRobot and self.useFakeName then
		local randName = ConfigManager.roleName:GetRandName()
		while randName == Role.name do
			randName = ConfigManager.roleName:GetRandName()
		end
		self.roleInfo.name = randName
	end
end


-----------------------	
--  RoleBaseInfo
-----------------------

RoleBaseInfo = class("RoleBaseInfo")

function RoleBaseInfo:ctor(roleBaseProto)
	self.roleId = 0
	self.name = nil
	self.icon = nil
	self.level = 0
	self.prize = 0
	if roleBaseProto then
		self:Init(roleBaseProto)
	end
end

function RoleBaseInfo:Init(roleBaseProto)
	self.roleId = roleBaseProto.roleId
	self.name = roleBaseProto.name
	self.icon = roleBaseProto.icon
	self.level = roleBaseProto.level
	self.prize = roleBaseProto.prize
end

-----------------------	
--  FightCardInfo
-----------------------

FightCardInfo = class("FightCardInfo")

function FightCardInfo:ctor(fightCardInfo)
	self.name = ""
	self.cardId = 0
	self.level = 0

	if fightCardInfo then
		self:Init(fightCardInfo)
	end
end

function FightCardInfo:Init(fightCardInfo)
	self.name = ConfigManager.card:GetConfig(fightCardInfo.card_id).name
	self.cardId = fightCardInfo.card_id
	self.level = fightCardInfo.level
end