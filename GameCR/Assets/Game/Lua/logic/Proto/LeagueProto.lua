LeagueProto = class("LeagueProto", 
{
})

local this = LeagueProto

function LeagueProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_SearchLeague_0x701", this.S_SearchLeague_0x701, league_pb.S_SearchLeague_0x701())
end

function LeagueProto.C_SearchLeague_0x701(taskId)
	local msg = league_pb.C_SearchLeague_0x701()
	msg.search_type = 1
	ProtoUtil.SendMsg(msg, 0x701)
end

function LeagueProto.S_SearchLeague_0x701(msg)
	print("----------S_SearchLeague_0x701-------")
end

function LeagueProto.C_CreateLeague_0x700(name, icon, description, type, need_prize)
	local msg = league_pb.C_CreateLeague_0x700()
	msg.league_info.name = name
	msg.league_info.icon = icon
	msg.league_info.description = description
	msg.league_info.type = type
	msg.league_info.need_prize = need_prize
	
	ProtoUtil.SendMsg(msg, 0x700)
end

function LeagueProto.S_CreateLeague_0x700(msg)
	print("----------S_SearchLeague_0x700-------")

end

this.StoC()