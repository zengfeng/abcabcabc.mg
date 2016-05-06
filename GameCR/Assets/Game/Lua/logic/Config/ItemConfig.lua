ItemConfig = class("ItemConfig", ConfigModel)
ItemStruct = class("ItemStruct",
{
	id = 0,
	name = "",
	avatarID = 0,
})

function ItemConfig:ctor()
	self.super.ctor(self, "Config/Item")
	self.struct = ItemStruct
end

function ItemConfig:GetConfig(id)--[return:ItemStruct]
	return self.super.GetConfig(self, id)
end