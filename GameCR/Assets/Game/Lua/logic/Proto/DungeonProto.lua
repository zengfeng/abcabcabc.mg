DungeonProto = class("DungeonProto", 
{
})

local this = DungeonProto

function DungeonProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_GetDungeonInfo_0x900", this.S_GetDungeonInfo_0x900, dungeon_pb.S_GetDungeonInfo_0x900())
	ProtoUtil.AddLuaProtoCallback("S_StartSubStage_0x901", this.S_StartSubStage_0x901, dungeon_pb.S_StartSubStage_0x901())
	ProtoUtil.AddLuaProtoCallback("S_EndSubStage_0x902", this.S_EndSubStage_0x902, dungeon_pb.S_EndSubStage_0x902())
	ProtoUtil.AddLuaProtoCallback("S_OpenDungeonChest_0x903", this.S_OpenDungeonChest_0x903, dungeon_pb.S_OpenDungeonChest_0x903())
end

-----------------------
-- 获取副本信息
-----------------------

function DungeonProto.C_GetDungeonInfo_0x900()
	local msg = dungeon_pb.C_GetDungeonInfo_0x900()

	ProtoUtil.SendMsg(msg, 0x900)
end

function DungeonProto.S_GetDungeonInfo_0x900(msg)

end

-----------------------
-- 开始副本战斗
-----------------------

function DungeonProto.C_StartSubStage_0x901(dungeonStageId, substage_index)
	local msg = dungeon_pb.C_StartSubStage_0x901()
	msg.dungeonStageId = dungeonStageId
	msg.substage_index = substage_index

	ProtoUtil.SendMsg(msg, 0x901)
end

function DungeonProto.S_StartSubStage_0x901(msg)

end

-----------------------
-- 结束副本战斗
-----------------------

function DungeonProto.C_EndSubStage_0x902(winType, dungeonStageId, substage_index, star)
	local msg = dungeon_pb.C_EndSubStage_0x902()
	msg.winType = winType
	msg.dungeonStageId = dungeonStageId
	msg.substage_index = substage_index
	msg.star = star

	ProtoUtil.SendMsg(msg, 0x902)
end

function DungeonProto.S_EndSubStage_0x902(msg)
	Role.dungeonManager:UpdateDungeonStageWithProto(msg.dungeon_stage)
end

-----------------------
-- 打开副本宝箱
-----------------------

function DungeonProto.C_OpenDungeonChest_0x903(dungeonStageId)
	local msg = dungeon_pb.C_OpenDungeonChest_0x903()
	msg.dungeonStageId = dungeonStageId

	ProtoUtil.SendMsg(msg, 0x903)
end

function DungeonProto.S_OpenDungeonChest_0x903(msg)
	Role.dungeonManager:UpdateDungeonStageWithProto(msg.dungeon_stage)
end

this.StoC( )