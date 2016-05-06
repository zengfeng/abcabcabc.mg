ChestTypeConfig = class("ChestTypeConfig", ConfigModel)
ChestTypeStruct = class("ChestTypeStruct",
{
	id = 0,
	name = "",
	time = 0,
})

function ChestTypeConfig:ctor()
	self.super.ctor(self, "Config/chest_type")
	self.struct = ChestTypeStruct
end

function ChestTypeConfig:GetConfig(id)--[return:ChestTypeStruct]
	return self.super.GetConfig(self, id)
end