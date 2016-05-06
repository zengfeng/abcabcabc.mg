GradeConfig = class("GradeConfig", ConfigModel)
GradeStruct = class("GradeStruct",
{
	id = 0,
	name = "",
	avatarId = 0,
	min = 0,
	max = 0,
	onlineChestId = 0,
	starChestId = 0,
	shopChest1Id = 0,
	shopChest2Id = 0,
	shopChest3Id = 0,
	win = 0,
	lost = 0,
	robot = 0,
	AiId = 0,
})

function GradeConfig:ctor()
	self.super.ctor(self, "Config/Grade")
	self.struct = GradeStruct
end

function GradeConfig:GetConfig(id)--[return:GradeStruct]
	return self.super.GetConfig(self, id)
end

function GradeConfig:GetConfigByPrize(prize)--[return:GradeStruct]
	local grade = 1
	for i,v in ipairs(self.configs) do
		if prize >= v.min and prize <= v.max then
			grade = v.id
			break
		end
	end
	return self:GetConfig(grade)
end

function GradeConfig:GetLastConfig()--[return:GradeStruct]
	return self.configs[#self.configs]
end