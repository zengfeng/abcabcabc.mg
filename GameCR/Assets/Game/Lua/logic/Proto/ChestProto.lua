ChestProto = class("ChestProto", 
{
})

local this = ChestProto

function ChestProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_OpenChest_0x300", this.S_OpenChest_0x300, chest_pb.S_OpenChest_0x300())
	ProtoUtil.AddLuaProtoCallback("S_AddOnlineChest_0x311", this.S_AddOnlineChest_0x311, chest_pb.S_AddOnlineChest_0x311())
	ProtoUtil.AddLuaProtoCallback("S_UnlockArenaChest_0x331", this.S_UnlockArenaChest_0x331, chest_pb.S_UnlockArenaChest_0x331())
	ProtoUtil.AddLuaProtoCallback("S_PreOpenArenaChest_0x332", this.S_PreOpenArenaChest_0x332, chest_pb.S_PreOpenArenaChest_0x332())
	ProtoUtil.AddLuaProtoCallback("S_SyncChestInfo_0x301", this.S_SyncChestInfo_0x301, chest_pb.S_SyncChestInfo_0x301())
end

-----------------------
-- 打开宝箱
-----------------------
function ChestProto.C_OpenChest_0x300(chestType, chestId, pos, byMoney)
	local msg = chest_pb.C_OpenChest_0x300()
	msg.chest_type 	= chestType --宝箱类型： 1.在线宝箱   2.星星宝箱   3.竞技场宝箱  4.商城宝箱
	msg.chest_id 	= chestId or 0
	msg.pos 		= pos
	msg.by_money 	= byMoney or false

	ProtoUtil.SendMsg(msg, 0x300)
end

function ChestProto.S_OpenChest_0x300( msg )
	Role.chestManager:UpdateByProto(msg.chest_info)
end

-----------------------
-- 增加在线宝箱
-----------------------
function ChestProto.C_AddOnlineChest_0x311(  )
	local msg = chest_pb.C_AddOnlineChest_0x311()

	ProtoUtil.SendMsg(msg, 0x311)
end

function ChestProto.S_AddOnlineChest_0x311( msg )
	local mgr = Role.chestManager
	mgr.onlineChestCount = msg.online_chest_count
	mgr.nextOnlineChestTicks = msg.next_online_chest_ticks
	print("===========================: " .. mgr.nextOnlineChestTicks)
end

-----------------------
-- 解锁竞技宝箱
-----------------------
function ChestProto.C_UnlockArenaChest_0x331( pos )
	local msg = chest_pb.C_UnlockArenaChest_0x331()
	msg.pos = pos

	ProtoUtil.SendMsg(msg, 0x331)
end

function ChestProto.S_UnlockArenaChest_0x331( msg )
end

-----------------------
-- 增加竞技场宝箱
-----------------------
function ChestProto.C_PreOpenArenaChest_0x332( pos )
	local msg = chest_pb.C_PreOpenArenaChest_0x332()
	msg.pos = pos

	ProtoUtil.SendMsg(msg, 0x332)
end

function ChestProto.S_PreOpenArenaChest_0x332( msg )
end

-----------------------
-- 后台同步
-----------------------
function ChestProto.C_SyncChestInfo_0x301()
	local msg = chest_pb.C_SyncChestInfo_0x301()
	ProtoUtil.SendMsg(msg, 0x301)
end

function ChestProto.S_SyncChestInfo_0x301( msg )
end

this.StoC()