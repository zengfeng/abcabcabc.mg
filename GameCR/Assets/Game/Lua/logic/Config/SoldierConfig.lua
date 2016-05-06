SoldierConfig = class("SoldierConfig", ConfigModel)
SoldierStruct = class("SoldierStruct",
{
	id = 0,
	level = 0,
	name = "",
	coin = 0,
	money = 0,
	initBattle = 0,
	initGainSoldier = 0,
	initSpeed = 0,
	avatarId = 0,
	describe = "",
})

-----------------------
--  SoldierStruct
-----------------------

function SoldierStruct:ctor()
	
end

function SoldierStruct:GetProp1(display)
	local val = self.initBattle * (display and ConfigManager.prop:GetConfig(PropId.AtkAdd).displayMultiplier or 1)
	return display and math.floor(val) or val
end

function SoldierStruct:GetProp2(display)
	local factor = Games.ConstConfig.GetFloat(Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio)
	local val = self.initGainSoldier * factor * (display and ConfigManager.prop:GetConfig(PropId.ProduceSpeedAdd).displayMultiplier or 1)
	return display and math.floor(val) or val
end

function SoldierStruct:GetProp3(display)
	local val = self.initSpeed * (display and ConfigManager.prop:GetConfig(PropId.MoveSpeedAdd).displayMultiplier or 1)
	return display and math.floor(val) or val
end

-----------------------
--  SoldierConfig
-----------------------

function SoldierConfig:ctor()
	self.super.ctor(self, "Config/Soldier")
	self.struct = SoldierStruct
end

function SoldierConfig:GetConfig(id)--[return:SoldierStruct]
	return self.super.GetConfig(self, id)
end