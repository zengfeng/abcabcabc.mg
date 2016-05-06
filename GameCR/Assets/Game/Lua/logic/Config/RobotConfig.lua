RobotConfig = class("RobotConfig", ConfigModel)
RobotStruct = class("RobotStruct",
{
	id = 0,
	name = "",
	avatar = 0,
	level = 0,
	Trophy = 0,
	AiId = 0,
	soldier = 0,
	card1 = 0,
	card1level = 0,
	card2 = 0,
	card2level = 0,
	card3 = 0,
	card3level = 0,
	card4 = 0,
	card4level = 0,
	card5 = 0,
	card5level = 0,
	card6 = 0,
	card6level = 0,
})

function RobotConfig:ctor()
	self.super.ctor(self, "Config/Robot")
	self.struct = RobotStruct
end

function RobotConfig:GetConfig(id)--[return:RobotStruct]
	return self.super.GetConfig(self, id)
end