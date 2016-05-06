local this = definePanel("TaskPanel")
require "logic/Proto/MailProto"
-----------------------
--  LuaBehaviour
-----------------------

function Start()
	bg = transform:FindChild("Content/Bg")
	maillistPanel = transform:FindChild("Content/InfoList/MailList")
	fightListPanel = transform:FindChild("Content/InfoList/FightList")
	taskListPanel = transform:FindChild("Content/InfoList/TaskList") 
	
	fightList = transform:FindChild("Content/InfoList/FightList"):GetComponent("TableView")--对战日志
	fightList:Setup(OnItemFightUpdate, 0, false)
	maillist = transform:FindChild("Content/InfoList/MailList"):GetComponent("TableView")--邮件
	maillist:Setup(OnItemMailUpdate, 0, false)
	taskList = transform:FindChild("Content/InfoList/TaskList"):GetComponent("TableView")--成就
	taskList:Setup(OnItemTaskUpdate, 0, false)
	signList = transform:FindChild("Content/InfoList/SignList")--签到
	activeGroup = transform:FindChild("Content/ActiveGroup"):GetComponent("ActiveGroup")--页签
	mailButton = transform:FindChild("Content/ActiveGroup/Mail")
	fightLogButton = transform:FindChild("Content/ActiveGroup/FightLog")
	taskButton = transform:FindChild("Content/ActiveGroup/Task")
	signButton = transform:FindChild("Content/ActiveGroup/Sign")
	unShow = transform:FindChild("Content/UnShow")
	unShowText = transform:FindChild("Content/UnShow/Text"):GetComponent("Text")
	--签到界面
	signNum = signList:FindChild("SignNum"):GetComponent("Text")--签到次数
	signItemButton = signList:FindChild("SignButton")
	signButtonImage = signList:FindChild("SignButton"):GetComponent("ImageSetMaterial")
	signButtonText = signList:FindChild("SignButton/Text"):GetComponent("Text")
	signLightEffect = signList:FindChild("kuang_xuanzhaun01")--发光特效
	signItems = {}
	for pos=0,6 do
		local signItemTrans = signList:FindChild("List"):GetChild(pos)	
		local signItem = SignItem.New(signItemTrans,this)		
		table.insert(signItems, signItem)
	end

	--邮件信息面板
	getMailPanel = transform:FindChild("GetMailPanel")
	mailTitle = transform:FindChild("GetMailPanel/Content/Des_1/Text"):GetComponent("Text")--邮件名
	mailDes = transform:FindChild("GetMailPanel/Content/Des_2/Text"):GetComponent("Text")--邮件内容
	mailItemPanel = transform:FindChild("GetMailPanel/Content/ItemPanel")
	mailItemList = transform:FindChild("GetMailPanel/Content/ItemPanel/ItemList")--邮件附件物品
	confirmButton = transform:FindChild("GetMailPanel/Content/ConfirmButton")--关闭按钮
	getButton = transform:FindChild("GetMailPanel/Content/GetButton")--领取附件按钮

	window:AddClick(confirmButton.gameObject, OnCloseButton)
	window:AddClick(getButton.gameObject, OnGetButton)
	window:AddClick(signItemButton.gameObject, OnSignButton)

	roleTasks = {}
	roleTaskItem = {}
	lastClickTaskItem = nil
	isRefresh = false
	AllInfo = {}
	activeGroup:SetChangeCallback(OnChangeTab)
	isFirst = false	
	oldRoleLevel = nil
	EventManager.AddEventListener(this, "S_TaskInfoNotify_0x501", OnTaskChange)--任务信息变化通知
	EventManager.AddEventListener(this, "S_GetTaskAward_0x502", OnProtoRecv)--领取任务奖励
	EventManager.AddEventListener(this, "S_MailList_0x1000", OnProtoBack)--登录获取邮件列表
	EventManager.AddEventListener(this, "S_GetMailAttach_0x1001", OnGetMailAttach)--领取邮件物品
	EventManager.AddEventListener(this, "S_ReadNewMail_0x1002", OnReadNewMail)--读新邮件
	EventManager.AddEventListener(this, "S_SignIn_0x1061", OnSignIn)--签到领取物资
end

function OnEnter()
	MainPanel.backCallback = OnClickClose

	if parameter then
		return
	end
	MailProto.C_MailList_0x1000()
	
	GetTask()
	GetFight()
	GetSignInfo()
	oldRoleLevel = Role.level
	UIUtils.ShowTip(mailButton, Role.unreadMailCount > 0)
	UIUtils.ShowTip(taskButton, Role.taskManager:HasFinish())
	UIUtils.ShowTip(signButton, Role.signInfo.can_sign == true)
	
end

function OnBack( ... )
	MainPanel.backCallback = OnClickClose
end

-----------------------
--  Function
-----------------------
function ShowActive()--优先按顺序显示有效红点的否则显示日志
	if Role.firstFight == true then
		activeGroup:SelectByUid(0)
		Role.firstFight = false
	else
		if  Role.unreadMailCount > 0 then
			activeGroup:SelectByUid(1)
		else
			if Role.taskManager:HasFinish() then
				activeGroup:SelectByUid(2)
			else
				if Role.signInfo.can_sign == true then
					activeGroup:SelectByUid(3)
				else
					activeGroup:SelectByUid(0)
				end
			end
		end
	end
	
end
--获取签到信息
function GetSignInfo()
	curSignDay = Role.signInfo.sign_day
	curCanSign =  Role.signInfo.can_sign
	curSignDay1 = math.floor (curSignDay/7) --取整
	curSignDay2 = curSignDay%7 --取余
	for k,v in pairs(signItems) do		
		if k > curSignDay2 then
		 	v:SetIsGet(false)--未领取
		else
			v:SetIsGet(true)--已领取
		end
		local signConfing = ConfigManager.sign:GetConfig(curSignDay1*7+k)
		if curCanSign == true and k ==  curSignDay2 + 1 then
			v:SetEffect(true)--可领
			flySignParent = v.item
			flySignType = signConfing.itemId
			flySignNum = signConfing.itemCount
		else
			v:SetEffect(false)
		end
		
		v:UpdateWith(signConfing.itemId,signConfing.itemCount,curCanSign)
	end
	if curCanSign == true then --签到按钮是否灰掉
		signButtonImage:SetMaterial(1)
		signButtonText.text = Lang.SignNotHave
	else
		signButtonImage:SetMaterial(0)
		signButtonText.text = Lang.SignHave
	end
	signNum.text = string.format(Lang.SignNum, curSignDay2)
end
--领取签到物资
function OnSignIn(msg)

	if flySignType == 100000 then
		MainPanel.PlayCurrencyAnimation(FlyType.Coin,flySignParent, flySignNum, 10)
	end
	if flySignType == 100001 then
		MainPanel.PlayCurrencyAnimation(FlyType.Gold,flySignParent, flySignNum, 10)
	end
	GetSignInfo()
	UIUtils.ShowTip(signButton, Role.signInfo.can_sign == true)
end
--获取对战日志信息
function GetFight()
	roleFightLogs = {}
	roleAllFightLogs = {}
	roleAllFightLogs = War.record:GetList()
	roleFightLogs = listToTable(roleAllFightLogs)
	table.sort(roleFightLogs, function(a, b)
		
		return a.create_time > b.create_time
	end)
	AllInfo[LogType.FightLog] = roleFightLogs
	
end

--获取成就信息
function GetTask()
	roleTasks = {}
	--roleTaskItem = {}
	for k,v in pairs(Role.taskManager.tasksList) do
		if v.status ~= 3 then
			table.insert(roleTasks, v)
		end
	end
	table.sort(roleTasks, function(a, b)
		if a.status == 2 and b.status == 2 then
			return false
		end
		return a.status == 2
	end)
	AllInfo[LogType.Task] = roleTasks
end
--任务信息变化
function OnTaskChange(msg)
	if isRefresh == true then
		isRefresh = false
	else
		GetTask()
		ReloadData(LogType.Task)
		UIUtils.ShowTip(taskButton, Role.taskManager:HasFinish())
	end

	
end
--获取成就奖励
function OnProtoRecv(msg)
	if lastClickTaskItem then
		MainPanel.PlayCurrencyAnimation(FlyType.Gold,lastClickTaskItem.moneyIcon, tonumber(lastClickTaskItem.money.text), 10,nil)
		MainPanel.PlayExpAnimation(lastClickTaskItem.expIcon, tonumber(lastClickTaskItem.exp.text), 10, function()
		if Role.level > oldRoleLevel then
			local roleLevel = RoleLevelPanel.New(window)--主公升级界面
			roleLevel:ShowProp()
			oldRoleLevel =  Role.level
		end
		
		end)
		GetTask()
		ReloadData(LogType.Task)
	end
	UIUtils.ShowTip(taskButton, Role.taskManager:HasFinish())
end
--邮件排序
function MailSort(listInfo)
	table.sort(listInfo, function(a, b)
		
		if #a.attach ~= 0 then
			a1 = 1
		else
			a1 = 0
		end
		if a.is_read == false then
			a2 = 10
		else
			a2 = 0
		end
		if #b.attach ~= 0 then
			b1 = 1
		else
			b1 = 0
		end
		if b.is_read == false then
			b2 = 10
		else
			b2 = 0
		end
		a0 = a1 + a2
		b0 = b1 + b2
		return a0 > b0
	end)
end
--获取邮件
function OnProtoBack(msg)
	isFirst = true
	mailSort = {}
	for k,v in pairs(msg.mail_info) do
		if v.mail_id ~= nil then
			table.insert(mailSort, v)
		end	
	end
	MailSort(mailSort)
	AllInfo[LogType.Mail] = mailSort
	ReloadData(LogType.Mail)
	ShowActive()
	
end
--读取未读取的邮件内容
function OnReadNewMail(msg) 
    for k,v in pairs(AllInfo[LogType.Mail]) do
     	if v.mail_id == msg.mail_id then
     		v.is_read = true
     	end  	
    end
    MailSort(mailSort)
	AllInfo[LogType.Mail] = mailSort
  	ReloadData(LogType.Mail)
  	Role.unreadMailCount = Role.unreadMailCount -1
  	UIUtils.ShowTip(mailButton, Role.unreadMailCount > 0)
  	--ShowActive()
end
--获取邮件附件物品
function OnGetMailAttach(msg) 
	if flyCoinParent then
		MainPanel.PlayCurrencyAnimation(FlyType.Coin,flyCoinParent, flyCoinNum, 10)
	end
	if flyGoldParent then
		MainPanel.PlayCurrencyAnimation(FlyType.Gold,flyGoldParent, flyGoldNum, 10)
	end
	for k,v in pairs(mailSort) do
    	if v.mail_id == msg.mail_id then
     		table.remove(mailSort, k)
     	end
	end
	MailSort(mailSort)
	AllInfo[LogType.Mail] = mailSort
	ReloadData(LogType.Mail)
	getMailPanel.gameObject:SetActive(false)
	MainPanel.SetState(1)
	GetTask()--刷新成就数据(领取到卡牌刷新成就)
end

function OnChangeTab(uid)
	
	for pos=0,3 do
		local itemListPanel = transform:FindChild("Content/InfoList"):GetChild(pos)	
		if pos == uid then
			itemListPanel.gameObject:SetActive(true)
		else
			itemListPanel.gameObject:SetActive(false)
		end

	end
	if uid ~= 3 then
		bg.gameObject:SetActive(true)
		unShow.gameObject:SetActive(true)
		ReloadData(uid+1)
	else
		unShow.gameObject:SetActive(false)
		bg.gameObject:SetActive(false)
	end


end

function ReloadData(curType)

	if curType == LogType.Mail then
		maillist:ReloadData(#AllInfo[curType])
		showText = Lang.LogMail
	elseif curType == LogType.FightLog then
		fightList:ReloadData(#AllInfo[curType])
		showText = Lang.LogFight
	elseif curType == LogType.Task then
		taskList:ReloadData(#AllInfo[curType])
		showText = Lang.LogTask
	end
	if #AllInfo[curType] == 0 then
		unShow.gameObject:SetActive(true)
		unShowText.text = showText
	else
		unShow.gameObject:SetActive(false)
	end
end

function OnItemMailUpdate(lineTable, line, tableView)--邮件
	curAllInfo = AllInfo[LogType.Mail]
	for k,v in pairs(lineTable) do
		local item = curAllInfo[tonumber(k)]
		local mailItem = MailItem.New(v.transform, window)
		mailItem:UpdateWith(item)
	end
end

function OnItemFightUpdate(lineTable, line, tableView)--对战日志
	curAllInfo = AllInfo[LogType.FightLog]
	for k,v in pairs(lineTable) do
		local item = curAllInfo[tonumber(k)]
		local fightItem = FightItem.New(v.transform, this)
		fightItem:UpdateWith(item)
	end
end

function OnItemTaskUpdate(lineTable, line, tableView)--成就
	curAllInfo = AllInfo[LogType.Task]
	for k,v in pairs(lineTable) do
		local item = curAllInfo[tonumber(k)]
		local taskItem = TaskItem.New(v.transform, window)
		taskItem:UpdateWith(item)
		table.insert(roleTaskItem, taskItem)
	end
end

function OpenMail(MailInfo)--打开邮件
	MainPanel.SetState(4)
	curMailId = MailInfo.mail_id
	curMailAttach = nil
	if MailInfo.is_read == false then
		MailProto.C_ReadNewMail_0x1002(MailInfo.mail_id) --发送读取未读邮件协议
	end
	getMailPanel.gameObject:SetActive(true)
	if MailInfo.mail_type ~= 0 then -- 模板邮件
		mailConfig = ConfigManager.mail:GetConfig(MailInfo.mail_type)
		mailTitle.text = mailConfig.name
		mailDes.text = mailConfig.content
	else --非模板邮件
		mailTitle.text = MailInfo.title
		mailDes.text = MailInfo.content
	end

	if #MailInfo.attach ~= 0 then

		mailItemPanel.gameObject:SetActive(true)
		curMailAttach = MailInfo.attach--当前邮件附件
		OnShowMailAttachInfo(  curMailAttach,mailItemList) 
		getButton.gameObject:SetActive(true)
		confirmButton.gameObject:SetActive(false)
	else
		mailItemPanel.gameObject:SetActive(false)
		getButton.gameObject:SetActive(false)
		confirmButton.gameObject:SetActive(true)
	end
end

function OnShowMailAttachInfo(  mailAttach,parent)  --附件信息 
	local itemNum = 0
	items = {}
	destroyChildren(parent.transform)
	for k,v in ipairs(mailAttach) do
		itemNum = itemNum + 1
		if v.itemId ~= nil then
			if v.itemId < 100000 then
				local cardNamePos = Vector2.New(0,-125)
				local roleCard = Role.cardManager:GetCard(v.itemId)
				if  roleCard ~= nil then
					isNewCard = false
				else
					isNewCard = true
				end
				local item = ItemCardCollect.New()--卡牌物品
				item:SetChestTip(v.itemCount, isNewCard)
				item:ShowWithId(v.itemId, function()
					item:NotShowBar()
					item:CardNamePos(cardNamePos)
					item.transform:SetParent(parent, false)
					
				end)
			else 
				flyCoinParent = nil
				flyCoinNum = nil
				flyGoldParent = nil
				flyGoldNum = nil
				local item = ItemCard.New()--货币物品
				item:SetCount(v.itemCount)
				
				item:ShowWithCurrType(v.itemId, function()
					item:NotShowIcon()
					item.transform:SetParent(parent, false)	
				end)
				table.insert(items, item)

			end
		end
	end
	for k,v in ipairs(items) do
		if v.currType == 100000 then
			flyCoinParent = v.headImage
			flyCoinNum = v.count
		end
		if v.currType == 100001 then	
			flyGoldParent = v.headImage
			flyGoldNum = v.count
		end
	end
	local parentRect = parent:GetComponent("RectTransform")
	if parent == mailItemList then
		if itemNum <= 6 then
			itemNumSize = 1270
		else
			itemNumSize = 1270 + (itemNum-6)*180
		end
	else
		if itemNum <= 5 then
			itemNumSize = 1100
		else
			itemNumSize = 1100 + (itemNum-5)*180
		end
	end
	parentRect.sizeDelta = Vector2.New(itemNumSize,240)
end

function OnCloseButton()--关闭邮件信息面板
	MainPanel.SetState(1)
	getMailPanel.gameObject:SetActive(false)
end

function OnGetButton() --领取附件物品
	MainPanel.SetState(4)
	MailProto.C_GetMailAttach_0x1001(curMailId) --发送领取邮件附件协议
end

function OnClickClose()
	--print("关闭日志")
	ShowActive()
	window:Exit()

end

function OnSignButton()--签到领取物资
	
	if curCanSign == true then
	SignProto.C_SignIn_0x1061(curSignDay+1)
	else
		CommonUtil.ShowMsg("已领取")
	end
end