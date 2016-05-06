RankProto = class("RankProto", 
{
})

local this = RankProto

function RankProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_GetRoleRankList_0x600", this.S_GetRoleRankList_0x600, rank_pb.S_GetRoleRankList_0x600())
end

-----------------------
-- 查询排行榜
-----------------------
function RankProto.C_GetRoleRankList_0x600(start, endNum)
	local msg = rank_pb.C_GetRoleRankList_0x600()
	msg.start = start
	msg["end"] = endNum

	ProtoUtil.SendMsg(msg, 0x600)
end

function RankProto.S_GetRoleRankList_0x600( msg )
	
end

this.StoC( )