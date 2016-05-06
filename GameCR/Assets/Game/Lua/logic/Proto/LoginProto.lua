LoginProto = {}
local this = LoginProto
this.server = "112.126.75.68:2110"
this.username = "123"
this.passworld = "123"

local  socketId = CC.Runtime.SocketId.Login

function this.Login( username, passworld, server )
	this.username = username;
	if passworld ~= nil then
		this.passworld = passworld;
	end
	if server ~= nil then
		this.server = server
	end

	this.Connect()
end

-----------------------
--  连接socket
-----------------------
function this.Connect( ... )
	Coo.packetManager.socketManager:Close(CC.Runtime.SocketId.Login)
	Coo.packetManager.socketManager:Connect(CC.Runtime.SocketId.Login, this.server)
	-- Coo.packetManager.socketManager:Connect(CC.Runtime.SocketId.Login, "192.168.1.28", 1201)
end


function this:Connected(sid) 
	
	if sid == CC.Runtime.SocketId.Login then
		print("链接登陆服务器成功 sid=" .. tostring(sid))
		this.C_UserLogin_0x01()
		--GameManager.LoginServerConnected()
	end
end

-----------------------
-- 监听
-----------------------
function this.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_UserLogin_0x01", this.S_UserLogin_0x01, login_pb.S_UserLogin_0x01())
	--ProtoUtil.AddLuaProtoCallback("S_UserRegister_0x02", this.S_UserRegister_0x02, login_pb.S_UserRegister_0x02())
	--ProtoUtil.AddLuaProtoCallback("S_ServerList_0x03", this.S_ServerList_0x03, login_pb.S_ServerList_0x03())
	--ProtoUtil.AddLuaProtoCallback("S_SelectServer_0x04", this.S_SelectServer_0x04, login_pb.S_SelectServer_0x04())

	Coo.packetManager.socketManager:AddLuaConnectedCallback(this, this.Connected)
end

-----------------------
-- 登陆
-----------------------
function  this.C_UserLogin_0x01()
	local msg 		= login_pb.C_UserLogin_0x01()
	msg.platform 	= CenterManager.centerName
	msg.user_name 	= this.username
	-- msg.device_id   = SystemInfo.deviceUniqueIdentifier
	print("===msg.platform:" .. msg.platform)
	ProtoUtil.SendMsg(msg, 0x01, socketId)
end

function this.S_UserLogin_0x01(msg) 
	User.session_id = msg.session_id
	User.id = msg.user_id
	print("登录成功 msg.session_id=" .. msg.session_id .. "  msg.user_id=" .. msg.user_id)
	-- print("====server: " .. #msg.server_info)
	GameConst.UserId = tostring(msg.user_id)

	GameManager.loginInSuccess(msg.server_info)
end

this.StoC()

-----------------------
-- 注册
-----------------------
-- function  this.C_UserRegister_0x02 (username)
-- 	local msg 		= login_pb.C_UserRegister_0x02()
-- 	msg.device_id 	= SystemInfo.deviceUniqueIdentifier
-- 	msg.user_name 	= username
-- 	msg.location 	= "上海"

-- 	ProtoUtil.SendMsg(msg, 0x02, socketId)
-- end


-- function  this.S_UserRegister_0x02 (msg)
--     User.id = msg.user_id
-- end

-----------------------
-- 服务器列表
-----------------------
-- function this.C_ServerList_0x03()
-- 	local msg  = login_pb.C_ServerList_0x03()

-- 	ProtoUtil.SendMsg(msg, 0x03, socketId)
-- end

-- function  this.S_ServerList_0x03( msg )
--     GameManager.getServerListSucess(msg.server_info)
-- end

-- -----------------------
-- -- 选择服务器
-- -----------------------
-- function  this.C_SelectServer_0x04( serverId )
-- 	local msg 		= login_pb.C_SelectServer_0x04()
-- 	msg.server_id 	= serverId

-- 	ProtoUtil.SendMsg(msg, 0x04, socketId)
-- end

-- function this.S_SelectServer_0x04( msg )
--     print("选择服务器成功")
--     GameManager.EnterScuess()
	
-- end
