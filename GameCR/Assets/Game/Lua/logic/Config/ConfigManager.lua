ConfigManager = class("ConfigManager", 
{
	prop = PropConfig.New(),
	avatar = AvatarConfig.New(),
	card = CardConfig.New(),
	cardLevel = CardLevelConfig.New(),
	box = BoxConfig.New(),
	chest = ChestConfig.New(),
	chestType = ChestTypeConfig.New(),
	grade = GradeConfig.New(),
	exp = ExpConfig.New(),
	skillDisplay = SkillDisplayConfig.New(),
	task = TaskConfig.New(),
	mail = MailConfig.New(),
	sign = SignConfig.New(),
	robot = RobotConfig.New(),
	robotFloatProp = RobotFloatPropConfig.New(),
	train = TrainConfig.New(),
	roleName = RoleNameConfig.New(),
	tip = TipConfig.New(),
	soldier = SoldierConfig.New(),
	dungeon = DungeonConfig.New(),
	dungeonStage = DungeonStageConfig.New()
})

local this = ConfigManager

function ConfigManager.InitConfig()
	this.prop:LoadConfig()
	this.avatar:LoadConfig()
	this.card:LoadConfig()
	this.cardLevel:LoadConfig()
	this.box:LoadConfig()
	this.chest:LoadConfig()
	this.chestType:LoadConfig()
	this.grade:LoadConfig()
	this.exp:LoadConfig()
	this.skillDisplay:LoadConfig()
	this.task:LoadConfig()
	this.robot:LoadConfig()
	this.robotFloatProp:LoadConfig()
	this.mail:LoadConfig()
	this.sign:LoadConfig()
	this.train:LoadConfig()
	this.roleName:LoadConfig()
	this.tip:LoadConfig()
	this.soldier:LoadConfig()
	this.dungeon:LoadConfig()
	this.dungeonStage:LoadConfig()
end