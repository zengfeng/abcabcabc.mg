require "logic/Core/include"

GameManager = {}
local this = GameManager
this.isExit = false
this.isFirstLogin = true
this.isAutoLogin = false
Application.targetFrameRate = 30

-- PlayerPrefsUtil.RemoveAllData()

function this.SetLoadBar(loadBar )
	PreloadFiles.loadBar = loadBar
	PreinstanceMenu.loadBar = loadBar
end

-- 初始化
function this.Init( ... )
 	Screen.sleepTimeout = -1

	if not GameConst.OfflineTest then
		Coo.assetManager:LuaLoad(this, "Config/sysmsg", this.OnLoadBase)
	end

	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	local tip2 = transform:FindChild("ForceTip2/Bg/Button"):GetComponent("Button")
	local tip3 = transform:FindChild("ForceTip3/Bg/Button"):GetComponent("Button")

	tip2.onClick:AddListener(this.OnForceTip2Click)
	tip3.onClick:AddListener(this.OnForceTip3Click)
end

-- 加载基础
function this.OnLoadBase(...) 
	-- local isFlagShowPanel = PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_ShowLoginPanel)
	-- if isFlagShowPanel == 0 then --自动登录
	-- 	MenuLayerType = CC.Module.Menu.MenuLayerType
	-- 	Coo.assetManager:LuaLoad(this, "module/Load/DarkCircleLoadPanel", function (_, name, obj)
	-- 		this.loadCircle = newobject(obj).transform
	-- 		local layerTransform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	-- 		this.loadCircle:SetParent(layerTransform, false)
	-- 		this:LoginServerConnected()
	-- 	end)
	-- else
		this:LoginServerConnected()
	-- end
end

-- 连接登陆服务器成功
function this:LoginServerConnected() 
	Coo.assetManager:LuaLoad(this, "Config/menu", this.OpenLoginPanel)
end

-- 打开登录面板
function this.OpenLoginPanel(table, name, obj)
	Coo.menuManager:OpenMenu(MenuType.Login)
end

function this.LoginLast()
	local server = LoginProto.server
	local username = LoginProto.username
	if server == nil or username == nil then
		error("Relogin failed, no last login info")
		return
	end
	-- Coo.packetManager.socketManager:CloseAll()
	GuideManager.BringBack()
	Coo.menuManager:CloseAll()
	LoginProto.Login(username, nil, server)

	EventManager.DispatchEvent(SystemEvent.Relogin)
end

function this.loginInSuccess( server_info )
	-- body
	if this.loadCircle ~= nil then
		destroy(this.loadCircle.gameObject)
		this.loadCircle = nil	
	end
	this.ServerList = server_info
	print("======server list =======: " .. #server_info)
	Coo.menuManager:OpenMenu(MenuType.ServerList)
	ServerListPanel:CheckLogin()
end

function this.EnterGame(  )
	EnterProto.Connect()
end

-- 加载资源
function this.LoadResource()
	Coo.menuManager:CloseMenu(MenuType.ServerList)
	if this.isFirstLogin then
		PreloadFiles.LoadResource()
	end
end

-- 加载资源完成
function this.InitConfig()
	if this.isFirstLogin then
		Coo.InitConfig()
		ConfigManager.InitConfig()
		Coo.InitPreloadCall()
		PreinstanceMenu.Begin()
		GuideManager.Init()
		Coo.packetManager.socketManager:AddLuaDisconnectCallback(CC.Runtime.SocketId.Main, this.OnDisconnectCallback)
		Coo.packetManager.socketManager:AddLuaReconnectCallback(CC.Runtime.SocketId.Main, this.OnReconnectCallback)
		this.isFirstLogin = false
	else
		this.EnterMainScene()
	end
end

function this.EnterMainScene()
	Coo.menuManager:OpenMenu(MenuType.MainScene)
end

function this.SetBattleDisconnectCallback()
	Coo.packetManager.socketManager:AddLuaDisconnectCallback(CC.Runtime.SocketId.Battle, this.OnDisconnectCallback)
	Coo.packetManager.socketManager:AddLuaReconnectCallback(CC.Runtime.SocketId.Battle, this.OnReconnectCallback)
end

function this.OnReconnectCallback(sid)
	if sid == CC.Runtime.SocketId.Main then 
		EventManager.DispatchEvent(SystemEvent.Reconnect)
	end
	this.ShowForceTip(false)
end

function this.OnDisconnectCallback(sid)
	if sid == CC.Runtime.SocketId.Main then
		EventManager.DispatchEvent(SystemEvent.DisConnect)
	end
	this.ShowForceTip(true)
end

function this.ShowForceTip(isShow)
	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	local tip = transform:FindChild("ForceTip")
	tip.gameObject:SetActive(isShow)
end

function this.ShowForceTip2(isShow)
	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	local tip = transform:FindChild("ForceTip2")
	tip.gameObject:SetActive(isShow)
end

function this.ShowForceTip3(isShow)
	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	local tip = transform:FindChild("ForceTip3")
	tip.gameObject:SetActive(isShow)
end

function this.OnForceTip2Click()
	this.LoginLast()
	this.ShowForceTip2(false)
end

function this.OnForceTip3Click()
	this.LoginLast()
	this.ShowForceTip3(false)
end

-- 退出
function  this.Exit( ... )
	this.isExit = true
	Coo.packetManager.socketManager:StopAll()
end

this.Init()