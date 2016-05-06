CardConfig = class("CardConfig", ConfigModel)
CardStruct = class("CardStruct",
{
	id = 0,
	name = "",
	avatarID = 0,
	country = 1,
	description = "",
	career = 1,
	quality = 1,
	state = 0,
	skill = 1,
	initProps = PropList.New("initGainSoldier", "initBattle", "initSpeed"),
	growProps = PropList.New("growGainSoldier", "growBattle", "growSpeed"),
	speciallyAtk = 1,
	speciallyDef = 1,
	speciallySpeed = 1,
	arena = 1,
})

-----------------------
--  CardStruct
-----------------------

--卡牌属性实际值
function CardStruct:GetPropRealValue(propId, level)
	local initProp = self.initProps:GetProp(propId).value
	local groupProp = self.growProps:GetProp(propId).value
	return initProp + (level - 1) * groupProp
end

function CardStruct:GetAtk(level)
	return self:GetPropRealValue(PropId.BattleForceAdd, level)
end

function CardStruct:GetProduceSpe(level)
	return self:GetPropRealValue(PropId.ProduceSpeedAdd, level)
end

function CardStruct:GetSpe(level)
	return self:GetPropRealValue(PropId.SpeedAtkAdd, level)
end

-----------------------
--  CardConfig
-----------------------

function CardConfig:ctor()
	self.super.ctor(self, "Config/card")
	self.struct = CardStruct
end

function CardConfig:GetConfig(id)--[return:CardStruct]
	local c = self.super.GetConfig(self, id)
	return self.super.GetConfig(self, id)
end

function CardConfig:GetAvatarConfig(id)--[return:AvatarStruct]
	local st = self:GetConfig(id)
	return ConfigManager.avatar:GetConfig(st.avatarID)
end