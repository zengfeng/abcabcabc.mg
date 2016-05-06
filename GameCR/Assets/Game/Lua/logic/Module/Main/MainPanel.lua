local this = definePanel("MainPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	--fordebug
	debugParent = transform:FindChild("Debug")
	debugBtn = transform:FindChild("Debug/Reset")
	window:AddClick(debugBtn.gameObject, function()
		DebugUtil.reloadMain()
	end)
	debugParent.gameObject:SetActive(GameConst.DevelopMode)

	animation = transform:FindChild("Debug/Animation")
	window:AddClick(animation.gameObject, function()
		-- HomePanel.chestBoard.chestArena.chestList[1]:PlayFlyAnim()
		--MainPanel.PlayCurrencyAnimation(FlyType.Gold,TaskPanel.roleTaskItem[1].moneyIcon, tonumber(TaskPanel.roleTaskItem[1].money.text), 10)
		--MainPanel.PlayCurrencyAnimation(FlyType.Coin,TaskPanel.roleTaskItem[1].expIcon, tonumber(TaskPanel.roleTaskItem[1].money.text), 10)
		--MainPanel.PlayExpAnimation(TaskPanel.roleTaskItem[1].expIcon, 30, 10)
		-- BattleEndPanel.PlayAnim()
		--MainPanel.PlayCurrencyAnimation(FlyType.Gold,TaskPanel.flyGoldParent, TaskPanel.flyGoldNum, 10)
		--MainPanel.PlayCurrencyAnimation(FlyType.Coin,TaskPanel.flyCoinParent, TaskPanel.flyCoinNum, 10)
		--EmbattlePanel.EffectLight(EmbattlePanel.sortHeroList[1].cardId,  nil)
	end)

	title = transform:FindChild("Title")
	leftup  = title:FindChild("LeftUp"):GetComponent("MultiObject")
	headButton = title:FindChild("LeftUp/Head")
	headIcon = title:FindChild("LeftUp/Head/Icon"):GetComponent("Image")
	headName = title:FindChild("LeftUp/Head/Name"):GetComponent("Text")
	backBtn = title:FindChild("LeftUp/Back")

	exp = title:FindChild("LeftUp/Exp")
	expProg = exp:GetComponent("Slider")
	expText = exp:FindChild("Text"):GetComponent("Text")
	expIconText = exp:FindChild("Icon/Text"):GetComponent("Text")
	expFly = exp:FindChild("Icon/ExpFly")
	expFlyIcon1 = exp:FindChild("Icon/ExpFly/ExpIcon1")
	expEffect = exp:FindChild("Effect")
	expEffect.gameObject:SetActive(false)

	rightUp = title:FindChild("RightUp")
	reputation = rightUp:FindChild("Reputation")
	reputationText = rightUp:FindChild("Reputation/Text"):GetComponent("Text")--将杯数
	reputationIcon = rightUp:FindChild("Reputation/Icon"):GetComponent("MultiImage")

	goldFly = rightUp:FindChild("Gold/GoldFly")
	goldFlyIcon1 = rightUp:FindChild("Gold/GoldFly/GoldIcon1")
	goldText = rightUp:FindChild("Gold/Text"):GetComponent("Text")--元宝数
	coinFly = rightUp:FindChild("Coin/CoinFly")
	coinFlyIcon1 = rightUp:FindChild("Coin/CoinFly/CoinIcon1")
	coinText = rightUp:FindChild("Coin/Text"):GetComponent("Text")--金币数

	expAnim = exp:FindChild("Icon/ExpIcon"):GetComponent("Animator")--经验图标抖动动画
	goldAnim = rightUp:FindChild("Gold/Image"):GetComponent("Animator")--元宝图标抖动动画
	coinAnim = rightUp:FindChild("Coin/Image"):GetComponent("Animator")--铜钱图标抖动动画
	backCallback = nil
	curState = 1
	window:AddClick(backBtn.gameObject, OnClickBack)
	window:AddClick(headButton.gameObject, OnClickSetting)
	window:AddClick(reputation.gameObject, OnClickReputation)
	UIUtils.LoadAvatarWithId(headIcon, Role.avatarId)
	oldRolePrize = nil
	EventManager.AddEventListener(this, "S_RoleBaseInfoNotify_0x151", OnProtoBack)
	EventManager.AddEventListener(this, "S_ChangeName_0x102", OnChangeName)
	EventManager.AddEventListener(this, "S_ChangeHeadIcon_0x105", OnChangeHead)
	EventManager.AddEventListener(this, "S_GetRoleDisPlayInfo_0x120", OnGetRoleDisPlayInfo)

	EventManager.AddEventListener(this, SystemEvent.DisConnect, OnDisConnect)
	EventManager.AddEventListener(this, SystemEvent.Reconnect, OnReconnect)
	EventManager.AddEventListener(this, SystemEvent.Relogin, OnRelogin)
end

function OnEnter()
	-- backCallback = nil
	headName.text = Role.name
	
	OnProtoBack()
	SetState(parameter)
	expAnim:SetBool("isStop", true)
	goldAnim:SetBool("isStop", true)
	coinAnim:SetBool("isStop", true)
end

function OnOpenSubWindow()
	local curWin = Coo.menuManager.currentWindow
	if curWin then
		curWin:OnOpenSubWindow()
	end
end

function OnCloseSubWindow()
	local curWin = Coo.menuManager.currentWindow
	if curWin then
		curWin:OnCloseSubWindow()
	end
end

-----------------------
--  Function
-----------------------

--1隐藏头像，2隐藏头像隐藏信息条，3显示所有
function SetState(state)
	local ty = state
	if ty then
		title.gameObject:SetActive(true)
		if ty == 1 then
			leftup:SetObjectIndex(1)
			rightUp.gameObject:SetActive(true)
		elseif ty == 2 then
			leftup:SetObjectIndex(1)
			rightUp.gameObject:SetActive(false)
		elseif ty == 3 then
			leftup:SetObjectIndex(0)
			rightUp.gameObject:SetActive(true)
		elseif ty == 4 then
			title.gameObject:SetActive(false)
		end
	end
	curState = state
end

function OnDisConnect()
end

function OnReconnect()
end

function OnRelogin()
end

--货币飞行动画（奖杯，元宝，铜钱）
function PlayCurrencyAnimation(flyType,node, goldDelta, count, callback)
	local flyAnim = nil
	local roleCurrency = nil
	if flyType == FlyType.Prize then

	elseif flyType == FlyType.Gold then
		parentFly = goldFly
		parentFlyIcon1 = goldFlyIcon1
		parentFlyText = goldText
		flyAnim = goldAnim
		roleCurrency = Role.money
	elseif flyType == FlyType.Coin then
		parentFly = coinFly
		parentFlyIcon1 = coinFlyIcon1
		parentFlyText = coinText
		flyAnim = coinAnim
		roleCurrency = Role.coins
	end

	parentFly.anchoredPosition = Vector2.New(0, 0)
	parentFlyText.text = roleCurrency - goldDelta
	local starList = {}
	for i=1, count do
		local star = newobject(parentFlyIcon1)
		star.transform:SetParent(parentFly, false)
		table.insert(starList, star)
	end

	--图标飞行动画
	local endPos = Vector2.New(-120, 0)
	local flyTime = 99999
	for i=1,#starList do
		local star = starList[i]
		star.gameObject:SetActive(true)
		if node == nil then
			print("============node nil");
		end
		if parentFly.parent == nil then
			print("============parentFly.parent nil");
		end
		star.anchoredPosition = MiscLuaUtil.AnchoredPosNode1InNode2Local(node, parentFly.parent)

		local range = 100
		local starPos = Vector2.New(star.anchoredPosition.x + math.Random(-range, range), star.anchoredPosition.y + math.Random(-range, range))
		local mag = (starPos - endPos).magnitude / 1000
		local centerTween = Tweener.DOAnchorPos(star, starPos, 0.2+i*0.1, false)
		Tweener.SetEase(centerTween, Ease.Linear)

		local moveTween = Tweener.DOAnchorPos(star, endPos, mag, false)
		Tweener.SetEase(moveTween, Ease.InQuart)

		local seq = Sequence.Create(centerTween, moveTween, function()
			destroy(star.gameObject)
		end)
		local duration = Tweener.Duration(seq.tweenSeq, false) 
		if duration < flyTime then
			flyTime = duration
		end

	end
	
	local tweeners = {}
	table.insert(tweeners, flyTime)
	table.insert(tweeners, function() 
		flyAnim:SetBool("isStop", false)  end)
	local textTweener = Tweener.DoTextNumber(parentFlyText, roleCurrency, 1)
	Tweener.SetEase(textTweener, Ease.Linear)

	table.insert(tweeners, textTweener)
	table.insert(tweeners, function() 
		flyAnim:SetBool("isStop", true) end)
	Sequence.CreateWithArray(tweeners)
end
--经验飞行动画
function PlayExpAnimation(node, expDelta, count, callback)
	expFly.anchoredPosition = Vector2.New(0, 0)

	local starList = {}
	for i=1, count do
		local star = newobject(expFlyIcon1)
		star.transform:SetParent(expFly, false)
		table.insert(starList, star)
	end

	--图标飞行动画
	local endPos = Vector2.New(0, 0)
	local flyTime = 99999
	for i=1,#starList do
		local star = starList[i]
		-- Tweener.DOKill(star, true)
		star.gameObject:SetActive(true)
		if node == nil then
			print("============node nil");
		end
		if expFly.parent == nil then
			print("============expFly.parent nil");
		end
		star.anchoredPosition = MiscLuaUtil.AnchoredPosNode1InNode2Local(node, expFly.parent)

		local spinTween = Tweener.DORotate2(star, Vector3.New(0, 0, 360), 0.5, RotateMode.FastBeyond360)
		Tweener.SetLoop(spinTween, 10)
		Tweener.SetEase(spinTween, Ease.Linear)

		local range = 100
		local starPos = Vector2.New(star.anchoredPosition.x + math.Random(-range, range), star.anchoredPosition.y + math.Random(-range, range))
		local mag = (starPos - endPos).magnitude / 1000
		local centerTween = Tweener.DOAnchorPos(star, starPos, 0.2+i*0.1, false)
		Tweener.SetEase(centerTween, Ease.Linear)

		local moveTween = Tweener.DOAnchorPos(star, endPos, mag, false)
		Tweener.SetEase(moveTween, Ease.InQuart)

		local seq = Sequence.Create(centerTween, moveTween, function()
			destroy(star.gameObject)
		end)
		local duration = Tweener.Duration(seq.tweenSeq, false) 
		if duration < flyTime then
			flyTime = duration
		end
	end

	--进度条动画

	local tweeners = {}
	table.insert(tweeners, flyTime)
	table.insert(tweeners, function() expEffect.gameObject:SetActive(true) end)
	table.insert(tweeners, function() 
		expAnim:SetBool("isStop", false) end)
	local curExp = ConfigManager.exp:GetExpNeed(Role.level)
	local before = curExp + Role.levelExp - expDelta
	local beforeCfg = ConfigManager.exp:GetConfigByTotalExp(before)
	local beforeNeed = ConfigManager.exp:GetExpNeed(beforeCfg.level)
	local deltaLv = Role.level - beforeCfg.level

	SetExp(before - beforeNeed, beforeCfg.roleExp)
	expIconText.text = beforeCfg.level

	for i=0,deltaLv do
		local lv = beforeCfg.level + i
		local cfg = ConfigManager.exp:GetConfig(lv)
		if i < deltaLv then
			table.insert(tweeners, function()
				SetExp(0, cfg.roleExp)
			end)

			local valueTweener = Tweener.DOValue(expProg, cfg.roleExp, 0.5, false)
			Tweener.SetOnUpdate(valueTweener, function()
				expText.text = math.floor(expProg.value) .. "/" .. expProg.maxValue
				expIconText.text = lv
			end)
			table.insert(tweeners, valueTweener)
		else
			table.insert(tweeners, function()
				SetExp(0, cfg.roleExp)
			end)
			local valueTweener = Tweener.DOValue(expProg, Role.levelExp, 0.5, false)
			Tweener.SetEase(valueTweener, Ease.OutExpo)
			Tweener.SetOnUpdate(valueTweener, function()
				expText.text = math.floor(expProg.value) .. "/" .. expProg.maxValue
				expIconText.text = lv
			end)
			table.insert(tweeners, valueTweener)
		end
	end

	table.insert(tweeners, function() 
		expEffect.gameObject:SetActive(false)
		if callback then
			callback()
		end
	end)
	table.insert(tweeners, function() 
		expAnim:SetBool("isStop", true) end)
	Sequence.CreateWithArray(tweeners)
end

function SetExp(value, maxValue)
	expProg.maxValue = maxValue
	expProg.value = value
	expText.text = value .. "/" .. maxValue
end

function OnProtoBack(msg)
	local expSt = ConfigManager.exp:GetConfig(Role.level)
	SetExp(Role.levelExp, expSt.roleExp)
	expIconText.text = Role.level
	reputationText.text = Role.prize
	reputationIcon:SetImageIndex(Role.GetGrade().id-1)
	goldText.text = Role.money
	coinText.text = Role.coins
	print("=====================Role.avatarId: " .. Role.avatarId)
	UIUtils.LoadAvatarWithId(headIcon, Role.avatarId)
	
end

function OnChangeName(msg)
	headName.text = Role.name
end

function OnChangeHead(msg)
	UIUtils.LoadAvatarWithId(headIcon, Role.avatarId)
end

function OnClickBack()
	print("关闭按钮")
	GuideManager.CheckPoint(nil, {[GuideType.PointClose] = {2}})
	if backCallback then
		backCallback()
	end
	HomePanel.OnEnter()
end

function OnClickSetting()
	EnterProto.C_GetRoleDisplayInfo_0x120(Role.roleId)
	
end

function OnGetRoleDisPlayInfo(msg)--获取主公数据
	if msg.display_info.base_info.roleId == Role.roleId then
		isShow = true
	else
		isShow = false
	end
	local settingWin = SettingWindow.New(window)--人物信息界面		
	settingWin:Show(msg.display_info,isShow)
end

function OnClickReputation()
	local nowGrade = Role.GetGrade().id
	local grade = GradekUpPanel.New(window)
	
	grade:Show(GradeType.TitleNow,nowGrade)
end