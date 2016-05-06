ServerListPanel = {}
local this = ServerListPanel


function this.Awake()

end

---------------------------
-- Start
---------------------------
function this.Start()
	this.contentTransform = this.transform:FindChild("Content")
	this.container = this.contentTransform:FindChild("ListPanel/Panel"):GetComponent("RectTransform")
	this.tabGroup = this.container:GetComponent("TabGroup")
	this.itemPrefab = this.container:FindChild("Item").gameObject
	this.infoText = this.transform:FindChild("Bulletin/InfoText"):GetComponent("Text")
	this.itemPrefab:SetActive(false)
	this.textDes = this.transform:FindChild("bg/TextDes"):GetComponent("Text")
	this.stateText = {}
	this.stateText["1"] = "关闭"
	this.stateText["2"] = "新服"
	this.stateText["3"] = "爆满"
	this.enterBtn = this.transform:FindChild("btnEnter")
	--公告界面
	this.bulletinPanel = this.transform:FindChild("Bulletin")
	this.confirmBtn = this.transform:FindChild("Bulletin/BulletinButton"):GetComponent("ExtendButton")--公告确定按钮
	this.confirmBtn.touchCallback = this.OnCloseBulletin
	local luaWindow = this.gameObject:GetComponent('LuaWindow')
	luaWindow:AddClick("EnterButton", this.OnChooseSvr)--选服
	luaWindow:AddClick("btnEnter", this.OnClickEnter)
	luaWindow:AddClick("InfoTextButton", this.ClickAddGroup)
	--luaWindow:AddClick("BulletinButton", this.OnCloseBulletin)
	this.init = true

	local str = string.format(CenterManager.GetQQGroupDesc(), CenterManager.GetQQGroupNumber())
	textFormat(this, this.infoText, str)

	--LoginProto.C_ServerList_0x03()
	-- this.UpdateList()
	
end

function this.CheckLogin( ... )
	-- body
	if GameManager.isAutoLogin == true then
		this.OnClickEnter()
	end
end

function this.CreateItem( vo )
	local go = GameObject.Instantiate(this.itemPrefab)
	go:SetActive(true)
	go.transform:SetParent(this.container)
	go.transform.localScale = Vector3.New(1, 1, 1)

	go.transform:FindChild("ID"):GetComponent("Text").text = tostring(vo.id)
	go.transform:FindChild("Name"):GetComponent("Text").text = tostring(vo.name)
	go.transform:FindChild("IP"):GetComponent("Text").text = tostring(vo.ip_addr) .. ":" .. tostring(vo.port)
	go.transform:FindChild("State"):GetComponent("Text").text = tostring(this.stateText[tostring(vo.status)])
	local tabButton = go:GetComponent("TabButton")
	
	tabButton:SetID(vo.id)
	tabButton:SetGroup(this.tabGroup)
	return tabButton

end


function  this.OnChooseSvr( ... )
	if not this.tabGroup.select then
		print("没有选择服务器")
		return
	end
	local id = this.tabGroup.select.uid
	local vo = this.data[1]
	for k, v in ipairs(this.data) do
		if v.id == id then
			vo = v
			break
		end
	end
end

function this.ClickAddGroup()
	CenterManager.AddQQGroup()
end

---------------------------
-- 点击进入按钮
---------------------------
function  this.OnClickEnter( ... )
	print("================OnClickEnter====")
	this.enterBtn.gameObject:SetActive(false)
	for k, v in ipairs(GameManager.ServerList) do
		print("==========id: " .. v.id .. "sid: " .. GameConst.ServerID)
			User.server = v
		 	GameConst.ServerID = v.id
			GameConst.SocketAddress = v.ip_addr
			GameConst.SocketPort = v.port
			GameManager.EnterGame()
			break
	end
end

--------------------------
-- 点击关闭公告
---------------------------
function  this.OnCloseBulletin( funcType )
	print("================OnCloseBulletin====")
	if funcType == "Down" then
		
	else
		this.bulletinPanel.gameObject:SetActive(false)
	end
end
