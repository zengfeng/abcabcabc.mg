local currentCenter = GameConst.CenterName

------------------
-- CenterType
------------------

NoCenter = class("NoCenter",
{
	appId = "",
	appKey = "",
	qqGroupKey = "0POfj73j3PTMfn2w6XAeAHvVVa6fwvXK",
	qqNumber = "344021892"
})

XiaoMi = class("XiaoMi", 
{
	appId = "2882303761517461188",
	appKey = "5971746158188",
	qqGroupKey = "yCmQjgCD3QjR0BZ6x09YkSqk1YtN16Ej",
	qqNumber = "530293906"
})

M4399 = class("M4399", 
{
	appId = "",
	appKey = "111674",
	qqGroupKey = "6qkmdZyN6p7UP9W8fz9h6ORLGmO3doSA",
	qqNumber = "399800901"
})

------------------
-- CenterManager
------------------

CenterManager = class("CenterManager", 
{
	centerName = currentCenter,
	center = _G[currentCenter],
	initCenterCallback = nil,
	loginCallback = nil,
	centerUserId = "",
	centerToken = "",
	centerNickName = "",
})

local this = CenterManager

function CenterManager.Init()
	print("CenterManager   " ..  currentCenter)

	if not this.IsNoCenter() then
		Coo.nativeManager:SetAppInfo(this.center.appId, this.center.appKey)
	end

	Coo.nativeManager:AddNativeFunctionCallback("OnInitCenter", this.OnInitCenter)
	Coo.nativeManager:AddNativeFunctionCallback("OnLogin", this.OnLogin)
	Coo.nativeManager:AddNativeFunctionCallback("OnLogout", this.OnLogout)
	Coo.nativeManager:AddNativeFunctionCallback("OnSwitchAccount", this.OnSwitchAccount)
end

function CenterManager.IsNoCenter()
	return this.centerName == "NoCenter"
end

function CenterManager.InitCenter(callback)
	this.initCenterCallback = callback

	Coo.nativeManager:InitCenter()
end

function CenterManager.Login(callback)
	this.loginCallback = callback

	Coo.nativeManager:LoginCenter()
end

function CenterManager.GetQQGroupDesc()
	if this.centerName == "XiaoMi" or 
		this.centerName == "M4399" then
		return Lang.NOTICE2
	else
		return Lang.NOTICE1
	end
end

function CenterManager.AddQQGroup()
	if this.centerName == "XiaoMi" or
		this.centerName == "M4399" then
		return
	end
	Coo.nativeManager:AppendQQGroup(this.center.qqGroupKey)
end

function CenterManager.GetQQGroupNumber()
	return this.center.qqNumber
end

function CenterManager.OnInitCenter(params)
	print_sp("CenterManager", "OnInitCenter", this.initCenterCallback)
	if this.initCenterCallback then
		local success = true
		if params.Length > 0 then 
			success = toBool(params[0])
		end
		this.initCenterCallback(success)
	end
end

function CenterManager.OnLogin(params)
	local str = Coo.nativeManager:GetUserInfo()
	local arr = string.split(str, ",")
	print_sp("CenterManager", "OnLogin", arr)
	if arr then
		this.centerUserId = arr[1]
		this.centerToken = arr[2]
		this.centerNickName = arr[3]
	end

	if this.loginCallback then
		local success = true
		if params.Length > 0 then 
			success = toBool(params[0])
		end
		this.loginCallback(success)
	end
end

function CenterManager.OnLogout(params)
	-- Application.Quit()
	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	local win = MsgWindow.New(transform, nil)
	win:SetMsg(nil, Lang.APPLICATION_1, Lang.APPLICATION_2)
	win:ShowOK(function()
		Application.Quit()
	end)
end

function CenterManager.OnSwitchAccount(params)
	GuideManager.BringBack()
	Coo.menuManager:CloseAll()

	local str = Coo.nativeManager:GetUserInfo()
	local arr = string.split(str, ",")
	if arr then
		this.centerUserId = arr[1]
		this.centerToken = arr[2]
		this.centerNickName = arr[3]
	end

	local userId = this.centerUserId
	LoginProto.Login(userId, nil)
end

this.Init()