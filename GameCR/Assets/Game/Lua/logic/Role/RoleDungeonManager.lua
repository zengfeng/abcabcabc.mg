RoleDungeonManager = class("RoleDungeonManager", 
{
	dungeonStageMap = {},
})

function RoleDungeonManager:ctor(dungeonProto)
	-- local dun = RoleDungeonStage.New()
	-- dun.id = 2101
	-- dun.stage1Star = 3
	-- dun.stage2Star = 3
	-- dun.stage3Star = 1
	-- dun.stage1ChestOpened = true
	-- dun.stage2ChestOpened = false
	-- dun.stage3ChestOpened = false

	-- self.dungeonStageMap[2101] = dun
	for i,v in ipairs(dungeonProto) do
		local dun = RoleDungeonStage.New()
		dun.id = v.dungeonStageId
		dun:UpdateWithProto(v)
		self.dungeonStageMap[v.dungeonStageId] = dun
	end
end

function RoleDungeonManager:GetLastDungeon(dungeonId, hardId)--[return:RoleDungeonStage]
	local stages = {}
	for k,v in pairs(self.dungeonStageMap) do
		if getDungeonByDungeonStageId(v.id) == dungeonId and getHardIdByDungeonStageId(v.id) == hardId then
			table.insert(stages, v)
		end
	end
	table.sort(stages, function(a, b)
		return a.id < b.id
	end)
	return stages[#stages]
end

function RoleDungeonManager:GetFirstDungeon(dungeonId, hardId)--[return:RoleDungeonStage]
	local stages = {}
	for k,v in pairs(self.dungeonStageMap) do
		if getDungeonByDungeonStageId(v.id) == dungeonId and getHardIdByDungeonStageId(v.id) == hardId then
			table.insert(stages, v)
		end
	end
	table.sort(stages, function(a, b)
		return a.id < b.id
	end)
	return stages[1]
end

function RoleDungeonManager:GetRoleDungeonStage(dungeonStageId)--[return:RoleDungeonStage]
	return self.dungeonStageMap[dungeonStageId]
end

function RoleDungeonManager:UpdateDungeonStageWithProto(proto)
	local dungeon = self:GetRoleDungeonStage(proto.dungeonStageId)
	if not dungeon then
		dungeon = RoleDungeonStage.New()
		dungeon.id = proto.dungeonStageId
		self.dungeonStageMap[proto.dungeonStageId] = dungeon
	end
	
	dungeon:UpdateWithProto(proto)
end

-----------------------
--  RoleDungeonStage
-----------------------

RoleDungeonStage = class("RoleDungeonStage",
{
	id = 0,
	openChestCount = 0,
	stage1Star = 0,
	stage2Star = 0,
	stage3Star = 0,
	stage1ChestOpened = false,
	stage2ChestOpened = false,
	stage3ChestOpened = false,
})

function RoleDungeonStage:IsFinish()
	return self.stage3Star > 0
end

function RoleDungeonStage:GetStarByIndex(index)
	return self["stage" .. tostring(index) .. "Star"]
end

function RoleDungeonStage:GetChestOpen(index)
	return self["stage" .. tostring(index) .. "ChestOpened"]
end

function RoleDungeonStage:GetLastStage()
	for i=1,3 do
		local star = self["stage" .. i .. "Star"]
		if star <= 0 then
			return i
		end
	end
	return -1
end

function RoleDungeonStage:SetStarByIndex(index, star)
	self["stage" .. tostring(index) .. "Star"] = star
end

function RoleDungeonStage:UpdateWithProto(proto)
	self.openChestCount = proto.open_chest_count
	for i,v in ipairs(proto.sub_stages) do
		self:SetStarByIndex(i, v.star)
	end
end

function RoleDungeonStage:GetProgressIdx()
	for i=1,3 do
		local star = self["stage" .. tostring(i) .. "Star"]
		if star <= 0 then
			return i
		end
	end
	return 3
end

function RoleDungeonStage:GetConfig()--[return:DungeonStageStruct]
	return ConfigManager.dungeonStage:GetConfig(self.id)
end