PropList = class("PropList")

function PropList:ctor(...)
	self.list = {}

	local fields = {...}
	self.fields = {}
	for i,v in ipairs(fields) do
		self.fields[v] = v
	end
end

function PropList:GetProp(propId)
	return self.list[propId]
end

function PropList:Parse(fieldName, str, csv)
	if self.fields[fieldName] then
		local prop = Prop.New(str, csv, fieldName)
		self.list[prop.id] = prop
	end
end

function PropList:GetAtk()
	return self.list[PropId.BattleForceAdd].value
end

function PropList:GetProduceSpeed()
	return self.list[PropId.ProduceSpeedAdd].value
end

function PropList:GetSpeed()
	return self.list[PropId.SpeedAtkAdd].value
end