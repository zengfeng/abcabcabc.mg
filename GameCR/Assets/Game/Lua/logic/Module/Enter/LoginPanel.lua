LoginPanel = {}
local this = LoginPanel

function this.Awake()
end

---------------------------
-- Start
---------------------------
function this.Start()

	this.contentTransform = this.transform:FindChild("Content")
	this.waitingTransform = this.transform:FindChild("Waiting")
	this.waitingText = this.transform:FindChild("Waiting/Text"):GetComponent("Text")
	this.waitingCircle = this.transform:FindChild("Waiting/Circle")
	this.waitingCanClick = false

	local loginButton = this.contentTransform:FindChild("LoginButton")
	local fastEnterButton = this.contentTransform:FindChild("FastEnterButton")

	this.serverDropdown = this.contentTransform:FindChild("ServerDropdown"):GetComponent('Dropdown')
	this.userNameInputField = this.contentTransform:FindChild("UserNameInputField"):GetComponent('InputField')

	print(this.userNameInputField.text );


	local luaWindow = this.gameObject:GetComponent('LuaWindow')

	luaWindow:AddClick(loginButton.gameObject, this.OnClickLogin)
	luaWindow:AddClick(fastEnterButton.gameObject, this.OnClickFastEnter)
	luaWindow:AddClick(this.waitingTransform.gameObject, this.OnClickWaiting)

	local server = LoginProto.server
	local username = LoginProto.username

	if PlayerPrefsUtil.HasKey(PlayerPrefsKey.Login_Server) then
		server = PlayerPrefsUtil.GetString(PlayerPrefsKey.Login_Server)
	end

	if PlayerPrefsUtil.HasKey(PlayerPrefsKey.Login_Username) then
		username = PlayerPrefsUtil.GetString(PlayerPrefsKey.Login_Username)
	end

	this.SetServer(server)
	this.SetUserName(username)

	if CenterManager.IsNoCenter() then
		--登录面板是否需要显示
		local isFlagShowPanel = PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_ShowLoginPanel)
		if isFlagShowPanel == 0 then
			this.contentTransform.gameObject:SetActive(false)
			this.autoLogin()
		else
			this.contentTransform.gameObject:SetActive(true)
		end
	else
		this.contentTransform.gameObject:SetActive(false)
		this.loginCenter()
	end
end

function this.autoLogin( ... )
	-- local token = PlayerPrefsUtil.GetString(PlayerPrefsKey.Login_Username)
	-- if string.len(token) == 0 then
	-- 	token = System.Guid.NewGuid():ToString() --Coo.GetStringRandom()
	-- end
	local token = SystemInfo.deviceUniqueIdentifier
	print("--------------------autoLogin:" .. token .. "   username:" .. PlayerPrefsKey.Login_Username)
	PlayerPrefsUtil.SetString(PlayerPrefsKey.Login_Username, token)
	LoginProto.Login(token, nil)
end

function this.loginCenter()
	this.waitingTransform.gameObject:SetActive(true)
	this.waitingCanClick = false
	this.waitingText.text = Lang.WAITING_1
	this.waitingCircle.gameObject:SetActive(true)

	CenterManager.InitCenter(function(success)
		CenterManager.Login(function(success)

			if success then
				this.waitingTransform.gameObject:SetActive(false)
				local userId = CenterManager.centerUserId
				LoginProto.Login(userId, nil)
			else
				this.waitingCircle.gameObject:SetActive(false)
				this.waitingCanClick = true
				this.waitingText.text = Lang.WAITING_2
			end
		end)
	end)
end

function this.OnClickWaiting()
	if not this.waitingCanClick then
		return
	end

	this.loginCenter()
end

function  this.GetServer()
	return this.serverDropdown.options[this.serverDropdown.value].text
end


function  this.SetServer( val )
	local count = this.serverDropdown.options.count
	local selectIndex = 0
	for i = 0, count - 1 do
		if this.serverDropdown.options[i].text == val then
			selectIndex = i
			break
		end
		print("----serverDropdown:" .. this.serverDropdown.options[i].text)
	end

	this.serverDropdown.value = selectIndex
end


function  this.GetUserName()
	return this.userNameInputField.text
end


function  this.SetUserName( val )
	this.userNameInputField.text = val
end


---------------------------
-- 点击登陆按钮
---------------------------
function  this.OnClickLogin( ... )
	print('Server='..this.GetServer())
	print('UserName='..this.GetUserName())

	PlayerPrefsUtil.SetString(PlayerPrefsKey.Login_Server, this.GetServer())
	PlayerPrefsUtil.SetString(PlayerPrefsKey.Login_Username, this.GetUserName())
	LoginProto.Login(this.GetUserName(), nil, this.GetServer())
end

