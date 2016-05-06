ArenaProto = class("ArenaProto", 
{
})

local this = ArenaProto

this.fightRoles = nil
-----------------------
--  连接战斗服
-----------------------

function ArenaProto.ConnectBattleServer( host, port )
	this.isConnectTo = true
	Coo.packetManager.socketManager:Connect(CC.Runtime.SocketId.Battle, host, port)
end

function ArenaProto.Connected(self, sid)

	if sid == CC.Runtime.SocketId.Battle then
		Timer.New(function()
			this.C_EnterFight_0x104()
		end, 1, 1):Start()
		GameManager.SetBattleDisconnectCallback()
	end
end

function ArenaProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_EnterFight_0x104", this.S_EnterFight_0x104, hall_pb.S_EnterFight_0x104())

	ProtoUtil.AddLuaProtoCallback("S_AttendMatcher_0x800", this.S_AttendMatcher_0x800, battle_pb.S_AttendMatcher_0x800())
	ProtoUtil.AddLuaProtoCallback("S_LeaveMatcher_0x801", this.S_LeaveMatcher_0x801, battle_pb.S_LeaveMatcher_0x801())
	ProtoUtil.AddLuaProtoCallback("S_PvPMatched_0x802", this.S_PvPMatched_0x802, battle_pb.S_PvPMatched_0x802())
	ProtoUtil.AddLuaProtoCallback("S_BattleRoomPrepare_0x810", this.S_BattleRoomPrepare_0x810, battle_pb.S_BattleRoomPrepare_0x810())
	ProtoUtil.AddLuaProtoCallback("S_BattleEnd_0x830", this.S_BattleEnd_0x830, battle_pb.S_BattleEnd_0x830())
	ProtoUtil.AddLuaProtoCallback("S_BattleLoad_0x811", this.S_BattleLoad_0x811, battle_pb.S_BattleLoad_0x811())
	ProtoUtil.AddLuaProtoCallback("S_BattleRoomPrepare_0x810", this.S_BattleRoomPrepare_0x810, battle_pb.S_BattleRoomPrepare_0x810())

	Coo.packetManager.socketManager:AddLuaConnectedCallback(this, this.Connected)
end

-----------------------
-- 竞技场匹配
-----------------------

function ArenaProto.C_AttendMatcher_0x800()
	local msg = battle_pb.C_AttendMatcher_0x800()
	msg.matcher_type = 1

	ProtoUtil.SendMsg(msg, 0x800)
end

function ArenaProto.S_AttendMatcher_0x800( msg )
	print("匹配中...")

	--TODO: show UI
end

function ArenaProto.C_LeaveMatcher_0x801()
	local msg = battle_pb.C_LeaveMatcher_0x801()

	ProtoUtil.SendMsg(msg, 0x801)
end

function ArenaProto.S_LeaveMatcher_0x801( msg )
	print("离开匹配")
end

function ArenaProto.S_PvPMatched_0x802( msg )
	print("匹配成功！！！连接战斗服加入战斗...")

	this.ConnectBattleServer(msg.fight_server.host, msg.fight_server.port)
end

-----------------------
-- 竞技场战斗
-----------------------
function ArenaProto.C_EnterFight_0x104()
	local msg = hall_pb.C_EnterFight_0x104()
	msg.sessionId = User.session_id

	ProtoUtil.SendMsg(msg, 0x104, CC.Runtime.SocketId.Battle)
end

function ArenaProto.S_EnterFight_0x104( msg )
	print("登录战斗服成功")
end

function ArenaProto.S_BattleRoomPrepare_0x810( msg )
	print("战斗房间准备完毕，开始加载战斗资源")
	-- TODO: pass fight data, enter c# fight
end


function ArenaProto.S_BattleEnd_0x830( msg )
	Coo.packetManager.socketManager:Close(CC.Runtime.SocketId.Battle)

	-- TODO: process battle end
end

-----------------------
-- 战斗加载进度同步
-----------------------

function ArenaProto.C_BattleLoad_0x811 (progress)
	local msg = battle_pb.C_BattleLoad_0x811()
	msg.progress = progress

	ProtoUtil.SendMsg(msg, 0x811, CC.Runtime.SocketId.Battle)
end

function ArenaProto.S_BattleLoad_0x811 ()
end

this.StoC( )
