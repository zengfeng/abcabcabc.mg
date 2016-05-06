local this = definePanel("HomePanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	chestBoard = ChestBoard.New(transform:FindChild("Chest"), window)
	dungeonBtn = transform:FindChild("Left/Dungeon")
	arenaBtn = transform:FindChild("Middle/Button")
	shopBtn = transform:FindChild("Bottom/Shop/Button")
	recruitBtn = transform:FindChild("Bottom/Recruit/Button")
	heroBtn = transform:FindChild("Bottom/Hero/Button")
	rankBtn = transform:FindChild("Bottom/Rank/Button")
	unionBtn = transform:FindChild("Bottom/Union/Button")
	taskBtn = transform:FindChild("Bottom/Task/Button")
	videoBtn = transform:FindChild("Bottom/Video/Button")
	middleMul = transform:FindChild("Middle"):GetComponent("MultiObject")
	guideText = transform:FindChild("Middle/Button/TrainText/Inner"):GetComponent("Text")
	arenaText = transform:FindChild("Middle/Button/ArenaText/Inner"):GetComponent("Text")
	dungeonTip = transform:FindChild("Left/Dungeon/Tip")

	effect = transform:FindChild("Effect")

	isFirstGuideEnd = false
	
	window:AddClick(dungeonBtn.gameObject, OnClickDungeon)
	window:AddClick(arenaBtn.gameObject, OnClickArena)
	window:AddClick(shopBtn.gameObject, OnClickShop)
	window:AddClick(recruitBtn.gameObject, OnClickRecruit)
	window:AddClick(heroBtn.gameObject, OnClickHero)
	window:AddClick(rankBtn.gameObject, OnClickRank)
	window:AddClick(unionBtn.gameObject, OnClickUnion)
	window:AddClick(taskBtn.gameObject, OnClickTask)
	window:AddClick(videoBtn.gameObject, OnClickVideo)

	EventManager.AddEventListener(this, "S_RoleBaseInfoNotify_0x151", OnProtoBack)
	EventManager.AddEventListener(this, "S_CardBattleStatusChange_0x202", OnCardBattleStatusChange)
	EventManager.AddEventListener(this, "S_MailStatusNotify_0x1005", OnMailCount)
	EventManager.AddEventListener(this, "S_EnableSignNotify_0x1062", OnSignCount)
	OnProtoBack()
end

function OnDestroy( ... )
	chestBoard:OnDestroy()
end

function ShowIsGuideEnd(  )--判断是否为第一次引导全部打完
	if  IsTrainState() or PlayerPrefsUtil.HasKey(PlayerPrefsKey.GuideFirstEnd) then
		return
	end
	PlayerPrefsUtil.SetInt(PlayerPrefsKey.GuideFirstEnd, 1)
	isFirstGuideEnd = true
end

function ShowFirstLog(  )--判断是否为第一次有日志
	roleFightLogs = {}
	roleAllFightLogs = {}
	roleAllFightLogs = War.record:GetList()
	roleFightLogs = listToTable(roleAllFightLogs)
	if  #roleFightLogs == 0 or PlayerPrefsUtil.HasKey(PlayerPrefsKey.FirstFightLog) then
		return
	end
	PlayerPrefsUtil.SetInt(PlayerPrefsKey.FirstFightLog, 1)
	Role.firstFight = true
end

function OnGrade()--段位信息变化
	if Role.gradeChange == true then	
		local grade = GradekUpPanel.New(window)
		local nowGrade = Role.GetGrade().id
		grade:Show(GradeType.TitleReach,nowGrade)
		Role.gradeChange = false
	end
end

function OnEnter()
	ShowIsGuideEnd(  )
	ShowFirstLog(  )
	if isFirstGuideEnd == true then
		isFirstGuideEnd = false
		Role.gradeChange = true
	end
	if Role.chestManager.newDropChestPos == 0 then
		OnGrade()
	else
		chestBoard.chestArena.chestList[Role.chestManager.newDropChestPos].animCallback = OnGrade
	end
	

	chestBoard:OnEnter()

	local guideCfg = ConfigManager.train:GetConfig(Role.newGuideStep)
	local nonguide = ConfigManager.train:GetNonGuideTrain()
	if guideCfg.step >= nonguide.step then
	else
		textFormat(this, guideText, guideCfg.step - 1 .. "/" .. nonguide.step - 1)
	end

	GuideManager.CheckPoint(this, 
		{[GuideType.EnterTrain] = {1}, 
		[GuideType.PointEmbattle] = {1}
	})

	if not IsTrainState() then
		GuideManager.NonLineCheckPoint(this, 
			{[GuideType.Arena] = {1}, 
			[GuideType.Dungeon] = {1}
		}, true)
	end

	CheckTip()

	if IsTrainState() then
		middleMul:SetObjectIndex(0)
		dungeonTip.gameObject:SetActive(true)
	else
		middleMul:SetObjectIndex(1)
		dungeonTip.gameObject:SetActive(false)
	end

	OnProtoBack()
end

function OnExit()
	if chestBoard then
		chestBoard:OnExit()
	end
end

function OnOpenSubWindow()
	effect.gameObject:SetActive(false)
end

function OnCloseSubWindow()
	effect.gameObject:SetActive(true)
end

-----------------------
--  Function
-----------------------

function OnProtoBack()
	textFormat(this, arenaText, Role.GetGrade().name)
end

function OnMailCount( msg )
	CheckTip()
end

function OnSignCount( msg )
	CheckTip()
end

function OnCardBattleStatusChange(msg)
	CheckTip()
end

function CheckTip()
	cardLevelUpNum = 0
	if not IsTrainState() and not PlayerPrefsUtil.HasKey(PlayerPrefsKey.TipImage_FirstArena) then
	    PlayerPrefsUtil.SetInt(PlayerPrefsKey.TipImage_FirstArena, 1)
	end

	local isFirstArena = 0
	if PlayerPrefsUtil.HasKey(PlayerPrefsKey.TipImage_FirstArena) then
		isFirstArena = PlayerPrefsUtil.GetInt(PlayerPrefsKey.TipImage_FirstArena)
	end

	UIUtils.ShowTip(rankBtn, isFirstArena == 1)
	UIUtils.ShowTip(heroBtn, Role.cardManager:CanEmbattle())

	
	local guideCfg = ConfigManager.train:GetConfig(Role.newGuideStep)
	local nonguide = ConfigManager.train:GetNonGuideTrain()
	if guideCfg.step < nonguide.step then--引导第七关结束之前暂时屏蔽日志小红点
		UIUtils.ShowTip(taskBtn, false)
	else
		UIUtils.ShowTip(taskBtn, Role.taskManager:HasFinish() or Role.unreadMailCount > 0 or Role.signInfo.can_sign == true  or Role.firstFight == true)	
	end
	
	for k,v in pairs(Role.cardManager.allCards) do
		local roleCard = Role.cardManager:GetCard(v.cardId)		
		local cardLv = roleCard:GetCardLevelConfig()
		if  roleCard.count >= cardLv.number then
			cardLevelUpNum = cardLevelUpNum + 1
		end
	end
	if Role.cardManager:CanEmbattle() == false then
		UIUtils.ShowGreenTip(heroBtn,cardLevelUpNum > 0,cardLevelUpNum)--绿点提示可升级卡牌数量
	else
		UIUtils.ShowGreenTip(heroBtn,false,cardLevelUpNum)
	end
end

function IsTrainState()
	local guideCfg = ConfigManager.train:GetConfig(Role.newGuideStep)
	local nonguide = ConfigManager.train:GetNonGuideTrain()

	return guideCfg.step < nonguide.step
end

function OnClickDungeon()
	if IsTrainState() then
		return
	end
	Coo.menuManager:OpenMenu(MenuType.Dungeon)
end

function OnClickPrictise()
	function enterPrictise()
		GuideManager.CheckPoint(this, {[GuideType.EnterTrain] = {2}})
		BattleManager.StartTrain()
	end

	if not IsTrainState() then
		local win = MsgWindow.New(transform, window)
		win:SetMsg(nil, Lang.HOME_TRAIN_END_SUBTITLE, Lang.HOME_TRAIN_END_DESC)
		win:Show(function()
			enterPrictise()
		end)
	else
		enterPrictise()
	end
end

function OnClickArena()
	if IsTrainState() then
		OnClickPrictise()
		return
	end
	if Role.stopServer == true then
		CommonUtil.ShowMsg(Lang.WAITING_3)--服务器维护不支持匹配
		return
	end
	
	if Role.chestManager:IsDropChestFull() then
		local win = MsgWindow.New(transform, window)
		win:SetMsg(nil, Lang.HOME_CHEST_FULL_SUBTITLE, Lang.HOME_CHEST_FULL_DESC)
		win:Show(function()
			Coo.menuManager:OpenMenu(MenuType.Matcher, BattleType.PVP_1_VS_1)
		end)
	else
		Coo.menuManager:OpenMenu(MenuType.Matcher, BattleType.PVP_1_VS_1)
	end
	GuideManager.NonLineCheckPoint(this, {[GuideType.Arena] = {2}})
end

function OnClickShop()
	Coo.menuManager:OpenMenu(MenuType.Shop)
end

function OnClickRecruit()
	Coo.menuManager:OpenMenu(MenuType.Recruit)
end

function OnClickHero()
	GuideManager.CheckPoint(this, {[GuideType.PointEmbattle] = {2}})

	Coo.menuManager:OpenMenu(MenuType.Embattle)
end

function OnClickRank()
	Coo.menuManager:OpenMenu(MenuType.Rank)
end

function OnClickUnion()
	CommonUtil.ShowMsg("暂未开放")
	-- Coo.menuManager:OpenMenu(MenuType.League)
end

function OnClickTask()
	Coo.menuManager:OpenMenu(MenuType.Task)
end

function OnClickVideo()
	Coo.menuManager:OpenMenu(MenuType.Video)
	--Coo.menuManager:OpenMenu(MenuType.Video)
	
end