Role = class("Role", 
{
	roleId = 0,
	userId = 0,
	name = "",
	avatarId = 0,
	level = 0,
	levelExp = 0,
	coins = 0,
	money = 0,
	prize = 0,
	unreadMailCount = 0,
	statusMark = 0,
	stopServer = false,--是否要停服
	gradeChange = false,--用于判断段位有无变化
	firstFight = false,--用于判断是否第一次有战斗日志
	newGuideStep = 0,
	cardManager = nil, --[type:RoleCardManager]
	soldierManager = nil, --[type:RoleSoldierManager]
	chestManager = nil, --[type:RoleChestManager]
	shopManager = nil, --[type:RoleShopManager]
	taskManager = nil, --[type:RoleTaskManager]
	dungeonManager = nil, --[type:RoleDungeonManager]
	signInfo = nil,--签到信息
})

local this = Role

function Role.Init(roleProto)
	this.gradeChange = false
	this.firstFight = false
	this.stopServer = false
	this.roleId = roleProto.base_info.roleId
	this.name = roleProto.base_info.name
	this.avatarId = roleProto.base_info.icon
	this.level = roleProto.base_info.level
	this.levelExp = roleProto.base_info.level_exp
	this.coins = roleProto.coins
	this.money = roleProto.money
	this.prize = roleProto.base_info.prize
	this.signInfo = roleProto.signs
	this.newGuideStep = roleProto.new_guide_step
	this.unreadMailCount = roleProto.unread_mail_count
	this.statusMark = roleProto.status_mark
	this.cardManager = RoleCardManager.New(roleProto.cards)
	this.cardManager:UpdateBattleCards(roleProto.battle_info.battle_cards)

	this.soldierManager = RoleSoldierManager.New(roleProto.soldiers)
	this.soldierManager:UpdateBattleSoldier(roleProto.battle_info.battle_soldier)

	this.chestManager = RoleChestManager.New(roleProto.chests)
	this.shopManager = RoleShopManager.New(roleProto.shops)
	this.taskManager = RoleTaskManager.New(roleProto.tasks)
	this.dungeonManager = RoleDungeonManager.New(roleProto.dungeon_stages)

	this.roleTimer = Timer.New(Role.OnUpdate, 1, -1, nil):Start(true)
end

function Role.OnUpdate(delta)
	this.cardManager:OnUpdate(delta)
	this.chestManager:OnUpdate(delta)
	this.shopManager:OnUpdate(delta)
end

function Role.GetGrade()--[return:GradeStruct]
	local guideCfg = ConfigManager.train:GetConfig(Role.newGuideStep)
	local nonguide = ConfigManager.train:GetNonGuideTrain()
	if guideCfg.step < nonguide.step then
		local grade = GradeStruct.New()
		grade.id = 0
		grade.name = Lang.GradeTrain
		return grade
	end
		
	return ConfigManager.grade:GetConfigByPrize(this.prize)
end

function Role.GetExpConfig()--[return:ExpStruct]
	return ConfigManager.exp:GetConfig(this.level)
end

function Role.IsTrainState()
	local guideCfg = ConfigManager.train:GetConfig(this.newGuideStep)
	local nonguide = ConfigManager.train:GetNonGuideTrain()

	return guideCfg.step < nonguide.step
end

function Role.GetRobotFloatProp()
	local max = this.GetGrade().max
	if this.GetGrade().id >= ConfigManager.grade:GetLastConfig().id then
		max = 3000
	end

	return ConfigManager.robotFloatProp:GetRandRadio(this.prize / max)
end