DungeonStageConfig = class("DungeonStageConfig", ConfigModel)
DungeonStageStruct = class("DungeonStageStruct",
{
	id = 0,
	name = "",
	level = 0,
	avatarId = 0,
	stageid1 = 0,
	name1 = "",
	desc1 = "",
	recmLevel1 = 0,
	avatarId1 = 0,
	chest1 = 0,
	stageid2 = 0,
	name2 = "",
	desc2 = "",
	recmLevel2 = 0,
	avatarId2 = 0,
	chest2 = 0,
	stageid3 = 0,
	name3 = "",
	desc3 = "",
	recmLevel3 = 0,
	avatarId3 = 0,
	chest3 = 0,
})

-----------------------
--  DungeonStageStruct
-----------------------

function DungeonStageStruct:GetStageId(idx)
	return self["stageid" .. tostring(idx)]
end

function DungeonStageStruct:GetStageName(idx)
	return self["name" .. tostring(idx)]
end

function DungeonStageStruct:GetStageDesc(idx)
	return self["desc" .. tostring(idx)]
end

function DungeonStageStruct:GetStageRecommandLevel(idx)
	return self["recmLevel" .. tostring(idx)]
end

function DungeonStageStruct:GetStageAvatarId(idx)
	return self["avatarId" .. tostring(idx)]
end

function DungeonStageStruct:GetStageChestId(idx)
	return self["chest" .. tostring(idx)]
end

-----------------------
--  DungeonStageConfig
-----------------------

function DungeonStageConfig:ctor()
	self.super.ctor(self, "Config/dungeon_stage")
	self.struct = DungeonStageStruct
end

function DungeonStageConfig:GetConfig(id)--[return:DungeonStageStruct]
	return self.super.GetConfig(self, id)
end

function DungeonStageConfig:GetDungeonStagesByDungeonId(dungeonId, hardId)
	local stages = {}
	for k,v in pairs(self.configs) do
		if getDungeonByDungeonStageId(v.id) == dungeonId and getHardIdByDungeonStageId(v.id) == hardId then
			table.insert(stages, v)
		end
	end
	table.sort(stages, function(a, b)
		return a.id < b.id
	end)
	return stages
end