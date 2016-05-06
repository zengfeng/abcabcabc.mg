BoxConfig = class("BoxConfig", ConfigModel)
BoxStruct = class("BoxStruct",
{
	id = 0,
	boxId = 0,
	type = 0, --1武将，2金币
	itemId = 0,
	number = 1,
	probability = 1,
})

function BoxConfig:ctor()
	self.super.ctor(self, "Config/Box")
	self.struct = BoxStruct
end

function BoxConfig:GetConfig(id)--[return:BoxStruct]
	return self.super.GetConfig(self, id)
end

function BoxConfig:GetConfigsByBoxId(boxId)
	local list = {}
	for k,v in pairs(self.configs) do
		if v.boxId == boxId then
			table.insert(list, v)
		end
	end
	table.sort(list, function(a, b)
		return a.number < b.number
	end)
	return list
end