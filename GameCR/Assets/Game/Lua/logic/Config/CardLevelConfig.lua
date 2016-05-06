CardLevelConfig = class("CardLevelConfig", ConfigModel)
CardLevelStruct = class("CardLevelStruct",
{
	level = 0,
	number = 0,
	quality1coin = 0,
	quality2coin = 0,
	quality3coin = 0,
	quality1exp = 0,
	quality2exp = 0,
	quality3exp = 0,
})

function CardLevelConfig:ctor()
	self.super.ctor(self, "Config/card_level")
	self.struct = CardLevelStruct
	self.keyName = "level"
end

function CardLevelConfig:GetConfig(id)--[return:CardLevelStruct]
	return self.super.GetConfig(self, id)
end

function CardLevelConfig:GetCoin(level, quality)
	local st = self:GetConfig(level)
	local key = "quality" .. tostring(quality) .. "coin"
	return st[key]
end

function CardLevelConfig:GetExp(level, quality)
	local st = self:GetConfig(level)
	local key = "quality" .. tostring(quality) .. "exp"
	return st[key]
end