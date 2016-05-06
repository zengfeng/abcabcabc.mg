RoleSoldierManager = class("RoleSoldierManager", 
{
	allSoldier = {},
	battleSoldier = 0,
})

function RoleSoldierManager:ctor(soldierProto)
	self:UpdateAllSoldier(soldierProto)
end

function RoleSoldierManager:UpdateAllSoldier(soldierProto)
	self.allSoldier = {}

	for i,v in ipairs(soldierProto) do
		self.allSoldier[v] = v
	end
end

function RoleSoldierManager:UpdateBattleSoldier(soldierId)
	self.battleSoldier = soldierId
end

function RoleSoldierManager:GetBattleSoldierCfg() --[return:SoldierStruct]
	return ConfigManager.soldier:GetConfig(self.battleSoldier)
end