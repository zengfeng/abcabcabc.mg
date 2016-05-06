ChestConfig = class("ChestConfig", ConfigModel)
ChestStruct = class("ChestStruct",
{
	chestId = 0,
	ranking = "",
	type = 0,
	money = 1,
	box1 = Pair.New(),
	box2 = Pair.New(),
	box3 = Pair.New(),
	box4 = Pair.New(),
})

function ChestConfig:ctor()
	self.super.ctor(self, "Config/Chest")
	self.struct = ChestStruct
	self.keyName = "chestId"
end

function ChestConfig:GetConfig(id)--[return:ChestStruct]
	return self.super.GetConfig(self, id)
end

function ChestConfig:GetChestTypeConfig(id)--[return:ChestTypeStruct]
	local st = self:GetConfig(id)
	return ConfigManager.chestType:GetConfig(st.type)
end

function ChestConfig:GetCoinBoxConfig(id)
	local st = self:GetConfig(id)
	if st.box1 then
		return ConfigManager.box:GetConfig(st.box1.id)
	end
end

function ChestConfig:GetHeroBoxConfig(id)
	local st = self:GetConfig(id)
	if st.box2 then
		return ConfigManager.box:GetConfig(st.box2.id)
	end
end

function ChestConfig:GetBlueHeroBoxConfig(id)
	local st = self:GetConfig(id)
	if st.box3 then
		return ConfigManager.box:GetConfig(st.box3.id)
	end
end

function ChestConfig:GetPurpleHeroBoxConfig(id)
	local st = self:GetConfig(id)
	if st.box4 then
		return ConfigManager.box:GetConfig(st.box4.id)
	end
end

function ChestConfig:GetBoxCount(id)
	local st = self:GetConfig(id)
	local count = 0
	for i=1,4 do
		if i ~= 2 then
			local box = st["box" .. tostring(i)]
			if not box:IsNull() then
				count = count + box.value
			end
		end
	end
	return count
end

function ChestConfig:GetCoinRange(id)
	local st = self:GetConfig(id)
	local boxCfgs = ConfigManager.box:GetConfigsByBoxId(st.box2.id)
	return boxCfgs[1].number*st.box2.value, boxCfgs[#boxCfgs].number*st.box2.value
end

function ChestConfig:GetLowQualityCard(id)
	local quality = 1
	local count = 0
	local st = self:GetConfig(id)
	if not st.box3:IsNull() then
		quality = 2
		count = st.box3.value
	elseif not st.box4:IsNull() then
		quality = 3
		count = st.box4.value
	end
	return quality, count
end