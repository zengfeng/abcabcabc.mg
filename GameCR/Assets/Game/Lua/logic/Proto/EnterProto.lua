EnterProto = {}
local this = EnterProto

local  socketId = CC.Runtime.SocketId.Main
local  packetManager = Coo.packetManager

-----------------------
--  连接socket
-----------------------

function EnterProto.Connect( ... )
	User.Print()
	if Coo.packetManager.socketManager:isServerConnect(socketId) then
		this.C_EnterGame_0x100()
	else
		Coo.packetManager.socketManager:Connect(socketId, User.server.ip_addr, User.server.port)
	end
end

function EnterProto:Connected(sid) 
	if sid == CC.Runtime.SocketId.Main then
		print("连接Main服务器成功 sid=" .. tostring(sid))
		Coo.packetManager.socketManager:Stop(CC.Runtime.SocketId.Login)

		this.C_EnterGame_0x100()
	end
end

-----------------------
-- 监听
-----------------------
function EnterProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_EnterGame_0x100", this.S_EnterGame_0x100, hall_pb.S_EnterGame_0x100())
	ProtoUtil.AddLuaProtoCallback("S_UpdateGuideStep_0x118", this.S_UpdateGuideStep_0x118, hall_pb.S_UpdateGuideStep_0x118())
	ProtoUtil.AddLuaProtoCallback("S_ChangeName_0x102", this.S_ChangeName_0x102, hall_pb.S_ChangeName_0x102())
	ProtoUtil.AddLuaProtoCallback("S_ChangeHeadIcon_0x105", this.S_ChangeHeadIcon_0x105, hall_pb.S_ChangeHeadIcon_0x105())
	ProtoUtil.AddLuaProtoCallback("S_ReConnect_0x101", this.S_ReConnect_0x101, hall_pb.S_ReConnect_0x101())
	ProtoUtil.AddLuaProtoCallback("S_KickOut_0x103", this.S_KickOut_0x103, hall_pb.S_KickOut_0x103())
	ProtoUtil.AddLuaProtoCallback("S_GetRoleDisPlayInfo_0x120", this.S_GetRoleDisPlayInfo_0x120, hall_pb.S_GetRoleDisPlayInfo_0x120())

	Coo.packetManager.socketManager:AddLuaConnectedCallback(this, this.Connected)
end

-----------------------
-- 进入游戏
-----------------------
function EnterProto.C_EnterGame_0x100(  )
	local msg = hall_pb.C_EnterGame_0x100()
	msg.session_id 	= User.session_id

	ProtoUtil.SendMsg(msg, 0x100)
end


function EnterProto.S_EnterGame_0x100( msg )
	print("进入游戏成功")
	if msg.session_id == 0 then --登录失败，需要重新登录
		GameManager.isAutoLogin = true
		GameManager:LoginLast()
		return
	end
	Role.Init(msg.roleInfo)
	User.session_id = msg.session_id
	GameManager.LoadResource()
end

-----------------------
-- 新手引导
-----------------------
function EnterProto.C_UpdateGuideStep_0x118(newStep)
	local msg = hall_pb.C_UpdateGuideStep_0x118()
	msg.new_step = newStep

	ProtoUtil.SendMsg(msg, 0x118)
end

function EnterProto.S_UpdateGuideStep_0x118( msg )
	Role.newGuideStep = msg.new_step
	if msg:HasField("chests") then
		Role.chestManager:UpdateByProto(msg.chests)
	end

	GuideManager.Reset()
end

-----------------------
-- 更改名字
-----------------------
function EnterProto.C_ChangeName_0x102(name)
	local msg = hall_pb.C_ChangeName_0x102()
	msg.name = name

	ProtoUtil.SendMsg(msg, 0x102)
end

function EnterProto.S_ChangeName_0x102( msg )
	Role.name = msg.name
	Role.statusMark = msg.status_mark
end

-----------------------
-- 更改头像
-----------------------
function EnterProto.C_ChangeHeadIcon_0x105(avatarId)
	local msg = hall_pb.C_ChangeHeadIcon_0x105()
	msg.avatar_id = avatarId

	ProtoUtil.SendMsg(msg, 0x105)
end

function EnterProto.S_ChangeHeadIcon_0x105( msg )
	print("===========S_ChangeHeadIcon_0x105========")
	Role.avatarId = msg.avatar_id
end

-----------------------
-- 获取角色数据
-----------------------
function EnterProto.C_GetRoleDisplayInfo_0x120(roleId)
	local msg = hall_pb.C_GetRoleDisplayInfo_0x120()
	msg.roleId = roleId
	ProtoUtil.SendMsg(msg, 0x120)
end

function EnterProto.S_GetRoleDisPlayInfo_0x120( msg )
	--Role.avatarId = msg.avatar_id
end
-----------------------
-- 重连
-----------------------

function EnterProto.C_ReConnect_0x101(sessionId)
	local msg = hall_pb.C_ReConnect_0x101()
	msg.session_id = sessionId

	ProtoUtil.SendMsg(msg, 0x101)
end

function EnterProto.S_ReConnect_0x101(msg)
	if msg.retcode ~= 0 then
		GameManager.ShowForceTip2(true)
	end
end

function EnterProto.S_KickOut_0x103(msg)
	GameManager.ShowForceTip3(true)
end

this.StoC()