RoleCard = class("RoleCard",
{
	cardId = 0,
	level = 1,
	count = 0,
	countDelta = 0,
	isNew = false,
})

function RoleCard:ctor(cardProto)
	if cardProto then
		self.cardId = cardProto.card_id
		self.level = cardProto.level
		self.count = cardProto.count
	end
end

function RoleCard:GetCardLevelConfig()--[return:CardLevelStruct]
	return ConfigManager.cardLevel:GetConfig(self.level)
end

function RoleCard:GetConfig()--[return:CardStruct]
	return ConfigManager.card:GetConfig(self.cardId)
end

function RoleCard:IsNew()
	return self.isNew
end

--获取成长后的属性值
function RoleCard:GetPropValue(propId)
	local card = ConfigManager.card:GetConfig(self.cardId)
	return card:GetPropRealValue(propId, self.level)
end

--获取成长后的属性值表
function RoleCard:GetAllProps()
	local st = self:GetConfig(self.cardId)--[type:CardStruct]
	local list = {}
	for k,v in pairs(st.initProps.list) do
		local propCalc = {}
		propCalc[1] = v.id
		propCalc[2] = self:GetPropValue(v.id)
		table.insert(list, propCalc)
	end
	return list
end