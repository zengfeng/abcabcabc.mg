DungeonConfig = class("DungeonConfig", ConfigModel)
DungeonStruct = class("DungeonStruct",
{
	id = 0,
	level = 0,
	name = "",
})

function DungeonConfig:ctor()
	self.super.ctor(self, "Config/dungeon")
	self.struct = DungeonStruct
end

function DungeonConfig:GetConfig(id)--[return:DungeonStruct]
	return self.super.GetConfig(self, id)
end