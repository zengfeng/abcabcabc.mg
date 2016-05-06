local this = definePanel("BattleEndPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	bg = transform:FindChild("Bg")
	result = transform:FindChild("Result"):GetComponent("MultiObject")
	resultCanvas = transform:FindChild("Result"):GetComponent("CanvasGroup")
	bottomCanvas = transform:FindChild("Bottom"):GetComponent("CanvasGroup")
	chestAll = transform:FindChild("Bottom/ChestAll")
	chest = ChestIcon.New(transform:FindChild("Bottom/ChestAll/Chest"))
	confirmBtn = transform:FindChild("Bottom/ConfirmButton")
	replayButton = transform:FindChild("Bottom/ReplayButton")
	left = FightResultItem.New(transform:FindChild("Bg/Left"), window)
	right = FightResultItem.New(transform:FindChild("Bg/Right"), window)
	reputationTrans = transform:FindChild("Bottom/Reputation")
	reputation = transform:FindChild("Bottom/Reputation/Text"):GetComponent("Text")
	reputationColor = transform:FindChild("Bottom/Reputation/Text"):GetComponent("MultiColor")
	playWin = false
	click = false
	EventManager.AddEventListener(this, "S_UpdateGuideStep_0x118", OnUpdateGuideStep)
	-- EventManager.AddEventListener(this, "S_EndSubStage_0x902", OnUpdateGuideStep)

	window:AddClick(confirmBtn.gameObject, OnClick)
	window:AddClick(replayButton.gameObject, OnClickReplayButton)
end

function OnEnter()
	local overData = parameter
	local OverType = Games.Module.Wars.OverType
	local grade = Role.GetGrade()
	local deltaPrize = 0

	left:SetPVPVisible(true)
	right:SetPVPVisible(true)
	reputationTrans.gameObject:SetActive(true)
	if overData.isRecord then --判断是否是录像
		click = false
		reputationTrans.gameObject:SetActive(false)
		chestAll.gameObject:SetActive(false)
		replayButton.gameObject:SetActive(true)
	else
		watchCallback = nil 
		clickCallback = nil
		reputationTrans.gameObject:SetActive(true)
		chestAll.gameObject:SetActive(true)
		replayButton.gameObject:SetActive(false)
	end
	if overData.vsmode == VSMode.Train or 
	   overData.vsmode == VSMode.Dungeon or
	   overData.isRecord then

		chestAll.gameObject:SetActive(false)
		left:SetPVPVisible(false)
		right:SetPVPVisible(false)
		reputationTrans.gameObject:SetActive(false)
		confirmBtn.gameObject:SetActive(true)

		local r = {left, right}
		for i=0,1 do
			local legion = overData.legionDatas[i]
			local res = RoleFightResult.New()
			res.star = 0
			res.roleId = legion.roleId
			if legion.overType == OverType.Win then
				res.endType = 2
			elseif legion.overType == OverType.Lose then
				res.endType = 0
			elseif legion.overType == OverType.Draw then
				res.endType = 1
			end
			res.buildTotal = legion.buildTotal
			res.buildCount = legion.buildCount
			res.star = legion.starCount

			if overData.isRecord then
				r[i+1]:UpdateWith(res, War.enterData.legionList[i])
			else
				r[i+1]:UpdateWith(res)
			end
		end

		local battleParam = BattleManager.battleParam --[type:BattleParam]
		if overData.vsmode == VSMode.Train then
			local step = Role.newGuideStep
			if parameter.overType == OverType.Win then
				confirmBtn.gameObject:SetActive(false)
			end
			EnterProto.C_UpdateGuideStep_0x118(step)
		elseif overData.vsmode == VSMode.Dungeon then
			local resFg = left.roleFightResult --[type:RoleFightResult]
			DungeonProto.C_EndSubStage_0x902(resFg.endType, battleParam.dungeonStageId, battleParam.dungeonStageIndex, resFg.star)
		end
	elseif overData.vsmode == VSMode.PVP then
		local battleEndParam = BattleManager.battleEndParam --[type:BattleEndParam]
		if battleEndParam.isDrop then
			local c = Role.chestManager:GetNewDrop()
			chest:SetStateById(c.chestId, false)
			chestAll.gameObject:SetActive(true)
		else
			chestAll.gameObject:SetActive(false)
		end

		local leftInfo, rightInfo
		for k,v in pairs(BattleManager.battleEndParam.fightResult) do
			if v.roleId == Role.roleId then
				leftInfo = v
			else
				rightInfo = v
			end
		end

		left:UpdateWith(leftInfo)
		right:UpdateWith(rightInfo)

		deltaPrize = BattleManager.battleEndParam.prize - BattleManager.battleParam.selfRoleInfo.roleInfo.prize
	end

	click = false

	if parameter.overType == OverType.Win then
		result:SetObjectIndex(0)
		playWin = true
		reputation.text = "+" .. deltaPrize
		reputationColor:SetColorIndex(0)
	elseif parameter.overType == OverType.Lose then
		result:SetObjectIndex(1)
		playWin = false
		reputation.text = deltaPrize
		reputationColor:SetColorIndex(1)
	elseif parameter.overType == OverType.Draw then
		result:SetObjectIndex(2)
		playWin = true
		reputation.text = "+0"
		reputationColor:SetColorIndex(-1)
	end

	PlayAnim()
end

-----------------------
--  Function
-----------------------

function OnClick()
	if click then
		return
	end
	if clickCallback then
		clickCallback()
	end
	click = true
	Timer.New(function()
		War.Exit()
	end, 0.5, 1):Start()
end

function OnClickReplayButton()--重播
	if watchCallback then
		watchCallback()
	end
	-- Timer.New(function()
	-- 	War.Exit()
	-- end, 0.5, 1):Start()
end

function PlayAnim()
	bgPos = bg.anchoredPosition
	resPos = resultCanvas.transform.anchoredPosition
	bottomPos = bottomCanvas.transform.anchoredPosition
	bg.anchoredPosition = Vector2.New(bgPos.x, -transform.rect.height/2)
	resultCanvas.transform.anchoredPosition = Vector2.New(resPos.x, resPos.y + 100)
	bottomCanvas.transform.anchoredPosition = Vector2.New(bottomPos.x, bottomPos.y - 80)

	resultCanvas.alpha = 0
	bottomCanvas.alpha = 0

	local moveBg = Tweener.DOAnchorPos(bg, bgPos, 0.3, false)
	Tweener.SetEase(moveBg, Ease.OutBack)

	local resultTw = {Tweener.SetEase(Tweener.DOAnchorPos(resultCanvas.transform, resPos, 0.05, false), Ease.Linear), Tweener.DOFade4(resultCanvas, 1, 0)}
	local resultCallback = function ()
		local winSound = "effect_btl_win"
		local loseSound = "effect_btl_fail"
		if playWin then
			Coo.soundManager:PlaySound(winSound)
		else
			Coo.soundManager:PlaySound(loseSound)
		end
	end

	local bottomTw = {Tweener.DOAnchorPos(bottomCanvas.transform, bottomPos, 0.8, false), Tweener.DOFade4(bottomCanvas, 1, 0.7)}
	local seq = Sequence.Create(
		moveBg, 0.1, 
		left:PlayBuilding(true).tweenSeq, 0.2,
		right:PlayBuilding(false).tweenSeq, 0.3,
		left:PlayStar(), 0.2,
		right:PlayStar(), 0.3,
		resultTw, resultCallback, 0.5, bottomTw)
end

function OnUpdateGuideStep()
	if Role.chestManager.newDropChestPos > 0 then
		local c = Role.chestManager:GetNewDrop()
		if c then
			chestAll.gameObject:SetActive(true)
			chest:SetStateById(c.chestId, false)
		end
	end
	confirmBtn.gameObject:SetActive(true)
end