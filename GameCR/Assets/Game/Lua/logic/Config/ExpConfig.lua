ExpConfig = class("ExpConfig", ConfigModel)
ExpStruct = class("ExpStruct",
{
	level = 0,
	roleExpTotal = 0,
	roleExp = 0,
	type = 1,
	initTroop = 0,
	atk = 0,
	produce = 0,
	speed = 0,
	maxAtk = 0,
	maxProduce = 0,
	maxSpeed = 0,
	sub = {},
	embattle = 0,
})

function ExpConfig:ctor()
	self.super.ctor(self, "Config/exp")
	self.struct = ExpStruct
	self.keyName = "level"
end

function ExpConfig:GetConfig(id)--[return:ExpStruct]
	return self.super.GetConfig(self, id)
end

function ExpConfig:GetConfigByTotalExp(totalExp)--[return:ExpStruct]
	local level = self.configs[#self.configs].level
	for k,v in pairs(self.configs) do
		if totalExp < v.roleExpTotal then
			level = v.level
			break
		end
	end
	return self:GetConfig(level)
end

function ExpConfig:GetExpNeed(level)
	local expNeed = 0
	if level > 1 then
		expNeed = self:GetConfig(level - 1).roleExpTotal
	end

	return expNeed
end

function ExpConfig:GetEmbattleMinLevel(embattle)
	local sortArr = {}
	for k,v in pairs(self.configs) do
		table.insert(sortArr, v)
	end
	table.sort(sortArr, function(a, b)
		return a.level < b.level
	end)
	local level = sortArr[#sortArr]
	for k,v in pairs(sortArr) do
		if embattle <= v.embattle then
			level = v.level
			break
		end
	end

	return level
end