TipConfig = class("TipConfig", ConfigModel)
TipStruct = class("TipStruct",
{
	id = 1,
	txt = "",
})

function TipConfig:ctor()
	self.super.ctor(self, "Config/Tip")
	self.struct = TipStruct
end

function TipConfig:GetConfig(id)--[return:TipStruct]
	return self.super.GetConfig(self, id)
end

function TipConfig:GetRand()
	local idx = math.floor(math.Random(1, #self.configs))
	return self.configs[idx].txt
end