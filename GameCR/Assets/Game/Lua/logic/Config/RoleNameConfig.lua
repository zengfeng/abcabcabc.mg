RoleNameConfig = class("RoleNameConfig", ConfigModel)
RoleNameStruct = class("RoleNameStruct",
{
	id = 1,
	type = 1,
	string = "",
})

function RoleNameConfig:ctor()
	self.super.ctor(self, "Config/role_name")
	self.struct = RoleNameStruct
end

function RoleNameConfig:GetConfig(id)--[return:RoleNameStruct]
	return self.super.GetConfig(self, id)
end

function RoleNameConfig:GetRandName()
	local famiArr = {}
	local nameArr = {}
	for i,v in ipairs(self.configs) do
		if v.type == 1 then
			table.insert(famiArr, v.id)
		elseif v.type == 2 then
			table.insert(nameArr, v.id)
		end
	end

	math.randomseed(os.time())
	local tmp = math.random(1, 10000)
	local famiRand = famiArr[math.random(1, #famiArr)]
	math.randomseed(tmp + os.time())
	local nameRand = nameArr[math.random(1, #nameArr)]

	return self:GetConfig(famiRand).string .. self:GetConfig(nameRand).string
end