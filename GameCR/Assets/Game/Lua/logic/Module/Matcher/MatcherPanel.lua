local this = definePanel("MatcherPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	titleText = transform:FindChild("TitleText"):GetComponent("Text")
	time = transform:FindChild("Time"):GetComponent("Text")
	grade = transform:FindChild("Self/Title/Grade"):GetComponent("MultiImage")
	name = transform:FindChild("Self/Title/Name"):GetComponent("Text")
	head = transform:FindChild("Self/Head/Icon"):GetComponent("Image")
	oriTitleText = titleText.text

	prop1Prog = transform:FindChild("Self/Content/Prop1/Progress"):GetComponent("Slider")
	prop1Text = transform:FindChild("Self/Content/Prop1/Text"):GetComponent("Text")
	prop2Prog = transform:FindChild("Self/Content/Prop2/Progress"):GetComponent("Slider")
	prop2Text = transform:FindChild("Self/Content/Prop2/Text"):GetComponent("Text")
	prop3Prog = transform:FindChild("Self/Content/Prop3/Progress"):GetComponent("Slider")
	prop3Text = transform:FindChild("Self/Content/Prop3/Text"):GetComponent("Text")

	tick = 0
	oneStepTick = 0
	isMatcher = false
	timer = Timer.New(OnTimer, 1, -1, TimerGroup.UI):Start(true)
	EventManager.AddEventListener(this, "S_LeaveMatcher_0x801", OnLeaveMatcher)
	EventManager.AddEventListener(this, "S_BattleRoomPrepare_0x810", OnBattleRoomPrepare)
	EventManager.AddEventListener(this, "S_PvPMatched_0x802", OnPvPMatched)

	EventManager.AddEventListener(this, SystemEvent.Reconnect, OnReconnect)
end

function OnEnter()
	UIUtils.LoadAvatarWithId(head, Role.avatarId)
	tick = 0
	MainPanel.backCallback = OnClickClose
	grade:SetImageIndex(Role.GetGrade().id-1)
	titleText.text = oriTitleText
	name.text = Role.name
	isMatcher = true

	local cardIds = {}
	for i,v in ipairs(Role.cardManager.battleCards) do
		local c = Role.cardManager:GetCard(v)
		table.insert(cardIds, {c.cardId, c.level})
	end

	local totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue = 
				BattleManager.GetTotalDisplayBattleProp(cardIds, Role.soldierManager.battleSoldier, Role.level)

	UIUtils.UpdateProgress(prop1Prog, maxAtkValue, totalAtkValue, nil, true)
	prop1Text.text = math.floor(totalAtkValue)

	UIUtils.UpdateProgress(prop2Prog, maxDefValue, totalDefValue, nil, true)
	prop2Text.text =  math.floor(totalDefValue)

	UIUtils.UpdateProgress(prop3Prog, maxSpValue, totalSpValue, nil, true)
	prop3Text.text =  math.floor(totalSpValue)

	BattleManager.MatchPVP(parameter)
end

-----------------------
--  Function
-----------------------

function OnReconnect(sid)
	OnEnter()
end

function OnTimer(delta)
	time.text = TimeUtil.ToDHMSS(tick)
	tick = tick + 1

	if not isMatcher then
		return
	end

	oneStepTick = oneStepTick + 1
	if oneStepTick > 30 then --30s重新匹配
		oneStepTick = 0
		BattleManager.MatchPVP(parameter)
	end
end

function OnClickClose()
	titleText.text = Lang.MATCHER_1
	BattleManager.LeaveMatchPVP()
end

function OnLeaveMatcher()
	isMatcher = false
	window:Back()
end

function OnBattleRoomPrepare()
	isMatcher = false
	titleText.text = Lang.MATCHER_2
end

function OnPvPMatched()
	isMatcher = false
end