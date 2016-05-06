PropConfig = class("PropConfig", ConfigModel)
PropStruct = class("PropStruct",
{
	id = 0,
	name = "",
	displayMultiplier = 0,
	mapping = "",
	limitMin = 0,
	limitMax = 0,
	priority = 0,
	additive = 0,
	type = 0,
})

function PropConfig:ctor()
	self.super.ctor(self, "Config/property")
	self.struct = PropStruct
end

function PropConfig:GetConfig(id)--[return:PropStruct]
	return self.super.GetConfig(self, id)
end