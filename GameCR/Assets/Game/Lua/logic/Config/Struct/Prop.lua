Prop = class("Prop")

function Prop:ctor(str, csv, keyName)
	if str == nil then
		return
	end

	local pair = Pair.New(str, csv, keyName)

	self.id = pair.id
	self.value = pair.value

	if self.id > 0 then
		self.config = ConfigManager.prop:GetConfig(self.id)
	else
		self.config = {}
	end
end

function Prop:GetID()
	return self.config.id or 0
end

function Prop:GetName()
	return self.config.name or ""
end

function Prop:GetPriority()
	return self.config.priority or 0
end

function Prop:GetValue()
	return self.value or 0
end

function Prop:GetDisplayValue( ... )
	return self.value * ConfigManager.prop:GetConfig(self.id).displayMultiplier
end

function Prop:ToString() 
	return string.format("[id=%f,name=%s,value=%f]", self:GetID(), self:GetName(), self.value)
end