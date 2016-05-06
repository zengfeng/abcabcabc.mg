SignConfig = class("SignConfig", ConfigModel)
SignStruct = class("SignStruct",
{
	id = 0,
	itemId = 0,
	itemCount = 0,
	
})

function SignConfig:ctor()
	self.super.ctor(self, "Config/Sign")
	self.struct = SignStruct
end

function SignConfig:GetConfig(id)--[return:TaskStruct]
	return self.super.GetConfig(self, id)
end