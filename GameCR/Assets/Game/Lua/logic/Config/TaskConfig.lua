TaskConfig = class("TaskConfig", ConfigModel)
TaskStruct = class("TaskStruct",
{
	id = 0,
	preTaskId = 0,
	name = "",
	describe = "",
	avatar = 0,
	type = 0,
	condition = 0,
	parameter1 = 0,
	parameter2 = 0,
	schedule = 0,
	openLevel = 0,
	reward = PairList.New(),
})

function TaskConfig:ctor()
	self.super.ctor(self, "Config/Task")
	self.struct = TaskStruct
end

function TaskConfig:GetConfig(id)--[return:TaskStruct]
	return self.super.GetConfig(self, id)
end