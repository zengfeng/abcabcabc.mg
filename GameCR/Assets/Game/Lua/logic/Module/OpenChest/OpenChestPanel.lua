local this = definePanel("OpenChestPanel")

OpenChestCard = class("OpenChestCard",
{
	cardType = 0, --[type:SpecialItemType]
	cardId = 0,
	level = 0,
	count = 0,
	countDelta = 0,
})

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	chestIcon = ChestIcon.New(transform:FindChild("ChestNode/ChestShakeNode/Chest"))
	chestFlyIcon = ChestIcon.New(transform:FindChild("ChestNode/ChestFlyNode/ChestFly"))
	tipTrans = chestIcon.transform:FindChild("Tip")
	tipText = chestIcon.transform:FindChild("Tip/Text"):GetComponent("Text")
	hitArea = transform:FindChild("HitArea"):GetComponent("ExtendButton")

	right = transform:FindChild("CardInfo/Right")
	rightMul = right:GetComponent("MultiObject")
	cardName = right:FindChild("Name"):GetComponent("Text")
	quality = right:FindChild("Quality"):GetComponent("MultiColor")
	qualityText = right:FindChild("Quality"):GetComponent("Text")
	qualityFrame = right:FindChild("UnOwn/Skill/Quality"):GetComponent("MultiColor")
	skillCont = right:FindChild("UnOwn/Skill/Quality/SkillIcon")
	skillIcon = right:FindChild("UnOwn/Skill/Quality/SkillIcon/Image"):GetComponent("Image")
	skillName = right:FindChild("UnOwn/Skill/Quality/SkillIcon/Name"):GetComponent("Text")
	skillDesc = right:FindChild("UnOwn/Skill/Desc"):GetComponent("Text")
	prop1Prog = right:FindChild("UnOwn/Prop/Prop1/Progress"):GetComponent("Slider")
	prop2Prog = right:FindChild("UnOwn/Prop/Prop2/Progress"):GetComponent("Slider")
	prop3Prog = right:FindChild("UnOwn/Prop/Prop3/Progress"):GetComponent("Slider")
	prop1ProgFill = right:FindChild("UnOwn/Prop/Prop1/Progress/Fill"):GetComponent("MultiColor")
	prop2ProgFill = right:FindChild("UnOwn/Prop/Prop2/Progress/Fill"):GetComponent("MultiColor")
	prop3ProgFill = right:FindChild("UnOwn/Prop/Prop3/Progress/Fill"):GetComponent("MultiColor")
	collectMul = right:FindChild("Own/Bg"):GetComponent("MultiObject")
	collectNotEn = right:FindChild("Own/Bg/NotEncough"):GetComponent("Slider")
	collectText = right:FindChild("Own/Bg/Gain"):GetComponent("Text")
	collectLevel = right:FindChild("Own/Level"):GetComponent("Text")
	collectLevelMul = right:FindChild("Own/Level"):GetComponent("MultiColor")

	qualityTextCont = qualityText.text
	collectLevelTextCont = collectLevel.text

	left = transform:FindChild("CardInfo/Left")
	cardTrans = left:FindChild("Card")
	portrait = left:FindChild("Card/Portrait"):GetComponent("Image")
	portraitMul = left:FindChild("Card/Portrait"):GetComponent("MultiImage")
	portraitDesc = left:FindChild("Card/Portrait/PortraitDesc"):GetComponent("MultiObject")
	countText = left:FindChild("Card/Portrait/PortraitDesc/Count"):GetComponent("Text")
	newCardText = left:FindChild("Card/Portrait/PortraitDesc/NewCard"):GetComponent("Text")
	isNew = left:FindChild("Card/New")
	frame = left:FindChild("Card/Frame/Frame1"):GetComponent("Image")
	particle = left:FindChild("Card/Particle"):GetComponent("ParticleSystem")

	chestFlyAnim = chestFlyIcon.transform:GetComponent("Animator")
	chestAnim = chestIcon.transform:GetComponent("Animator")
	cardFlyAnim = cardTrans:GetComponent("Animator")
	collectAnim = collectMul:GetComponent("Animator")

	openedCardList = {}
	unopenCardList = {}
	cardAnimSeq = nil
	showType = 1 --1新卡片，2老卡片，3金币
	animState = 1 --1动画未开始或完毕，2卡片飞，3展示数值
	protoBack = false

	EventManager.AddEventListener(this, "S_RewardInfoNotify_0x150", OnProtoBack)
	hitArea.touchCallback = TouchCallback
end

function OnEnter()
	chestParam = parameter--[type:OpenChestParam]
	protoBack = false

	MainPanel.backCallback = OnClickClose
	tipTrans.gameObject:SetActive(false)
	if chestParam.chestType == 1 then --在线宝箱
		chestIcon:SetState(0, true)
		chestFlyIcon:SetState(0, false)
	elseif chestParam.chestType == 2 then --在线宝箱
		chestIcon:SetState(2, true)
		chestFlyIcon:SetState(2, false)
	elseif chestParam.chestType == 3 then --竞技场宝箱
		chestIcon:SetStateById(chestParam.chestId, true)
		chestFlyIcon:SetStateById(chestParam.chestId, false)
	elseif chestParam.chestType == 4 then --招募
		chestIcon:SetStateById(chestParam.chestId, true)
		chestFlyIcon:SetStateById(chestParam.chestId, false)
	elseif chestParam.chestType == 5 then --副本宝箱
	end

	GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {7, 13}})

	animatorStop(chestFlyAnim, false)
	animatorStop(cardFlyAnim, false)
	collectMul.gameObject:SetActive(false)
	right.gameObject:SetActive(false)
	chestAnim.gameObject:SetActive(false)

	chestFlying = true
	animatorPlay(chestFlyAnim, function()
		if chestParam.chestType == 5 then
			DungeonProto.C_OpenDungeonChest_0x903(chestParam.dungeonStageId)
		else
			ChestProto.C_OpenChest_0x300(chestParam.chestType, chestParam.chestId, chestParam.pos, chestParam.byMoney)
		end
		chestFlying = false
		right.gameObject:SetActive(false)
	end)
end

-----------------------
--  Function
-----------------------

function OnClickClose()
	if chestParam.backMenuId <= 0 then
		window:Exit()
	else
		Coo.menuManager:OpenMenu(chestParam.backMenuId, chestParam.backMenuParam)
	end
end

function TouchCallback(funcType)
	if funcType == "Down" then
		if animState == 1 then
			hitArea:PlayAnimatorDown()
		end
	else
		if chestFlying then
			return
		end

		if animState == 1 then
			OpenOneCard()
			hitArea:PlayAnimatorUp()
		elseif animState == 2 then
			cardFlyAnim.speed = 99999
		elseif animState == 3 then
			Tweener.Complete(cardAnimSeq.tweenSeq, true)
		end
	end
end

function OnClick()
end

function OnProtoBack(msg)
	protoBack = true
	openedCardList = {}
	unopenCardList = {}

	tipTrans.gameObject:SetActive(true)

	if msg.reward_coins > 0 then
		local c = OpenChestCard.New()
		c.cardType = SpecialItemType.Coins
		c.count = msg.reward_coins
		table.insert(unopenCardList, c)
	end
	if msg.reward_money > 0 then
		local c = OpenChestCard.New()
		c.cardType = SpecialItemType.Money
		c.count = msg.reward_money
		table.insert(unopenCardList, c)
	end
	if msg.reward_exp > 0 then
		local c = OpenChestCard.New()
		c.cardType = SpecialItemType.Exp
		c.count = msg.reward_exp
		table.insert(unopenCardList, c)
	end

	for i,v in ipairs(msg.reward_cards) do
		local c = OpenChestCard.New()
		c.cardType = 0
		c.cardId = v.card_id
		c.level = v.level
		c.count = v.count

		local roleCard = Role.cardManager:GetCard(v.card_id) 
		c.countDelta = roleCard.countDelta

		table.insert(unopenCardList, c)
	end
	tipText.text = #unopenCardList
	OpenOneCard()
end

function PlayCardFlyAnim(card)

	function createNewTipTween()
		isNew.localScale = Vector3.New(0, 0, 0)

		local news = Tweener.DOScale2(isNew, Vector3.New(1, 1, 1), 0.2)
		Tweener.SetEase(news, Ease.OutBack)

		return {news}
	end

	function createSkillTween()
		if not showAnimBefore then
			skillCountPosition = qualityFrame.transform.anchoredPosition
			skillDescPosition = skillDesc.transform.anchoredPosition
		end
		local skillCountCanvas = qualityFrame:GetComponent("CanvasGroup")
		local skillDescCanvas = skillDesc:GetComponent("CanvasGroup")
		skillCountCanvas.alpha = 0
		skillDescCanvas.alpha = 0
		qualityFrame.transform.anchoredPosition = Vector2.New(skillCountPosition.x + 50, skillCountPosition.y)
		skillDesc.transform.anchoredPosition = Vector2.New(skillDescPosition.x - 50, skillDescPosition.y)

		local c1t = Tweener.DOFade4(skillCountCanvas, 1, 0.3) --技能
		local c2t = Tweener.DOFade4(skillDescCanvas, 1, 0.4)
		local c1a = Tweener.DOAnchorPos(qualityFrame.transform, skillCountPosition, 0.3, false)
		local c2a = Tweener.DOAnchorPos(skillDesc.transform, skillDescPosition, 0.4, false)
		Tweener.SetEase(c1a, Ease.OutBack)
		Tweener.SetEase(c2a, Ease.OutBack)

		return {c1t, c2t, c1a, c2a}
	end

	function createPropTween()
		if not showAnimBefore then
			ptScale1 = prop1Prog.transform.parent.localScale
			ptScale2 = prop2Prog.transform.parent.localScale
			ptScale3 = prop3Prog.transform.parent.localScale
		end

		local prop1Trans = prop1Prog.transform.parent
		local prop2Trans = prop2Prog.transform.parent
		local prop3Trans = prop3Prog.transform.parent
		prop1Trans.localScale = Vector3.New(0, ptScale1.y, ptScale1.z)
		prop2Trans.localScale = Vector3.New(0, ptScale2.y, ptScale2.z)
		prop3Trans.localScale = Vector3.New(0, ptScale3.y, ptScale3.z)

		local pVal1 = prop1Prog.value
		local pVal2 = prop2Prog.value
		local pVal3 = prop3Prog.value
		prop1Prog.value = 0
		prop2Prog.value = 0
		prop3Prog.value = 0

		local p1t = Tweener.DOScale(prop1Trans, ptScale1, 0.2)
		local p2t = Tweener.DOScale(prop2Trans, ptScale2, 0.2)
		local p3t = Tweener.DOScale(prop3Trans, ptScale3, 0.2)
		local p1p = Tweener.DOValue(prop1Prog, pVal1, 0.3, false)
		local p2p = Tweener.DOValue(prop2Prog, pVal2, 0.3, false)
		local p3p = Tweener.DOValue(prop3Prog, pVal3, 0.3, false)

		Tweener.SetEase(p1t, Ease.OutBack)
		Tweener.SetEase(p2t, Ease.OutBack)
		Tweener.SetEase(p3t, Ease.OutBack)
		Tweener.SetEase(p1p, Ease.OutBack)
		Tweener.SetEase(p2p, Ease.OutBack)
		Tweener.SetEase(p3p, Ease.OutBack)

		Tweener.SetDelay(p2t, 0.1)
		Tweener.SetDelay(p3t, 0.2)

		return {Sequence.Create(p1t, p1p).tweenSeq,
				Sequence.Create(p2t, p2p).tweenSeq,
				Sequence.Create(p3t, p3p).tweenSeq}
	end

	function createCollectTween()
		if not showAnimBefore then
			colPos = collectMul.transform.anchoredPosition
			collectLevelPos = collectLevel.transform.anchoredPosition
		end
		local colc = collectMul:GetComponent("CanvasGroup")
		local textc = collectLevel:GetComponent("CanvasGroup")
		colc.alpha = 0
		textc.alpha = 0
		collectMul.transform.anchoredPosition = Vector3.New(colPos.x - 50, colPos.y, colPos.z)
		collectLevel.transform.anchoredPosition = Vector3.New(collectLevelPos.x - 50, collectLevelPos.y, collectLevelPos.z)

		local colt = Tweener.DOFade4(colc, 1, 0.3)
		local cola = Tweener.DOAnchorPos(collectMul.transform, colPos, 0.2, true)
		local texta = Tweener.DOFade4(textc, 1, 0.2)
		local textt = Tweener.DOAnchorPos(collectLevel.transform, collectLevelPos, 0.1, true)
		Tweener.SetEase(cola, Ease.OutBack)
		Tweener.SetEase(textt, Ease.OutBack)

		return {colt, cola, texta, textt}
	end

	function createCollectTextTween()
		local count = card.count - card.countDelta
		collectText.text = string.gsub(collectText.text, ".+(/.+)", count .. "%1")
		collectNotEn.value = count
		local colTwe = Tweener.TweenTo(
						function() return count end, 
						function(val)
							collectText.text = string.gsub(collectText.text, ".+(/.+)", math.floor(val) .. "%1")
							collectNotEn.value = val

							if collectNotEn.value >= collectNotEn.maxValue then
								collectMul:SetObjectIndex(1)
							else
								collectMul:SetObjectIndex(0)
							end
						end, 
						card.count, 0.3)

		Tweener.SetEase(colTwe, Ease.Linear)
		local colSeq = Sequence.Create(colTwe, function()
			animatorPlay(collectAnim)
		end)

		return {colSeq.tweenSeq}
	end

	function createNameTween()
		if not showAnimBefore then
			cardNamePos = cardName.transform.anchoredPosition
			qualityPos = quality.transform.anchoredPosition
		end
		local cardNameCanvas = cardName:GetComponent("CanvasGroup")
		local qualityCanvas = quality:GetComponent("CanvasGroup")
		cardNameCanvas.alpha = 0
		qualityCanvas.alpha = 0

		cardName.transform.anchoredPosition = Vector2.New(cardNamePos.x + 50, cardNamePos.y)
		quality.transform.anchoredPosition = Vector2.New(qualityPos.x + 50, qualityPos.y)

		local c1t = Tweener.DOFade4(cardNameCanvas, 1, 0.3)
		local c2t = Tweener.DOFade4(qualityCanvas, 1, 0.4)
		local c1a = Tweener.DOAnchorPos(cardName.transform, cardNamePos, 0.3, false)
		local c2a = Tweener.DOAnchorPos(quality.transform, qualityPos, 0.4, false)

		Tweener.SetEase(c1a, Ease.OutBack)
		Tweener.SetEase(c2a, Ease.OutBack)

		return {c1t, c2t, c1a, c2a}
	end

	function createCountTween()
		if not showAnimBefore then
			cardCountScale = portraitDesc.transform.localScale
		end

		portraitDesc.transform.localScale = Vector2.New(0, 0)

		local tw = Tweener.DOScale2(portraitDesc.transform, cardCountScale, 0.2)
		Tweener.SetEase(tw, Ease.OutBack)

		return {tw}
	end

	card = card --[type:OpenChestCard]
	collectAnim:SetBool("Loop", false)

	if cardAnimSeq then
		Tweener.Kill(cardAnimSeq.tweenSeq, true)
	end
	cardAnimSeq = nil
	animState = 2

	if showType == 1 then
		local arr = {}
		table.insert(arr, table.combine(createCountTween(), createNameTween()))
		table.insert(arr, 0.3)
		table.insert(arr, createCollectTween())
		table.insert(arr, createCollectTextTween())
		table.insert(arr, 0.1)
		table.insert(arr, function()
			animState = 1
		end)

		cardAnimSeq = Sequence.CreateWithArray(arr)
		Tweener.PauseTween(cardAnimSeq.tweenSeq)

		animatorPlay(cardFlyAnim, function()
			animState = 3
			animatorStop(collectAnim)
			Tweener.PlayTween(cardAnimSeq.tweenSeq)
		end)
	elseif showType == 2 then
		local arr = {}
		table.insert(arr, table.combine(createCountTween(), createNameTween()))
		table.insert(arr, 0.3)
		table.insert(arr, table.combine(createSkillTween(), createPropTween()))
		table.insert(arr, 0.1)
		table.insert(arr, function()
			animState = 1
		end)

		cardAnimSeq = Sequence.CreateWithArray(arr)
		Tweener.PauseTween(cardAnimSeq.tweenSeq)

		animatorPlay(cardFlyAnim, function()
			animState = 3
			animatorStop(collectAnim)
			Tweener.PlayTween(cardAnimSeq.tweenSeq)
		end)
	elseif showType == 3 then
		local val = 0
		if card.cardType == SpecialItemType.Money then
			val = Role.money
		elseif card.cardType == SpecialItemType.Coins then
			val = Role.coins
		elseif card.cardType == SpecialItemType.Exp then
			val = Role.levelExp
		end
		collectText.text = val - card.count

		local numt = Tweener.DoTextNumber(collectText, val, 0.5)
		Tweener.SetEase(numt, Ease.Linear)

		local arr = {}
		table.insert(arr, table.combine(createCountTween(), createNameTween()))
		table.insert(arr, 0.3)
		table.insert(arr, createCollectTween())
		table.insert(arr, numt)
		table.insert(arr, function()
			collectAnim:SetBool("Loop", false)
			animState = 1
		end)

		cardAnimSeq = Sequence.CreateWithArray(arr)
		Tweener.PauseTween(cardAnimSeq.tweenSeq)

		animatorStop(collectAnim)
		animatorPlay(cardFlyAnim, function()
			animatorPlay(collectAnim)
			animState = 3
			collectAnim:SetBool("Loop", true)
			Tweener.PlayTween(cardAnimSeq.tweenSeq)
		end)
	end
end

function OpenOneCard()
	if not protoBack then
		return
	end
	if #unopenCardList <= 0 then	
		MainPanel.OnClickBack()
		return
	end
	local card = unopenCardList[1] --[type:OpenChestCard]
	table.remove(unopenCardList, 1)

	collectMul.gameObject:SetActive(true)
	right.gameObject:SetActive(true)

	if card.cardType == 0 then
		local cardCfg = ConfigManager.card:GetConfig(card.cardId)
		local skillCfg = ConfigManager.skillDisplay:GetConfig(cardCfg.skill)
		local roleCardNum = 0
		local cardLevel = 1

		showType = 1
		rightMul:SetObjectIndex(0)

		local roleCard = Role.cardManager:GetCard(card.cardId)
		if roleCard then
			roleCardNum = roleCard.count
			cardLevel = roleCard.level

			if roleCard:IsNew() then
				showType = 2
				rightMul:SetObjectIndex(1)
			end
		end
		local cardLevelCfg = ConfigManager.cardLevel:GetConfig(roleCard.level)

		UIUtils.LoadAvatarWithId(skillIcon, skillCfg.avatarId)

		skillName.text = skillCfg.skillName
		skillDesc.text = ConfigManager.skillDisplay:GetSkillDesc(cardCfg.skill,1)

		prop1Prog.value = cardCfg.speciallyAtk
		prop2Prog.value = cardCfg.speciallyDef
		prop3Prog.value = cardCfg.speciallySpeed

		collectNotEn.maxValue = cardLevelCfg.number
		collectNotEn.value = roleCardNum
		collectText.text = roleCardNum .. "/" .. cardLevelCfg.number

		if showType == 1 then
			countText.text = "x" .. card.countDelta
			portraitDesc:SetObjectIndex(0)
		elseif showType == 2 then
			portraitDesc:SetObjectIndex(1)
		end

		frame.color = getQualityColor(cardCfg.quality)
		particle:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(cardCfg.quality))

		portraitMul:SetImageIndex(1)
		UIUtils.LoadAvatarFullWithId(portrait, cardCfg.avatarID)
		cardName.text = cardCfg.name
		qualityText.text = string.format(qualityTextCont, Lang.ToCardQualityDesc(cardCfg.quality))
		collectLevel.text = string.format(collectLevelTextCont, card.level)
		collectLevelMul:SetColorIndex(-1)

		quality:SetColorIndex(cardCfg.quality-1)
		collectMul:SetObjectIndex(0)
		qualityFrame:SetColorIndex(cardCfg.quality-1)
		prop1ProgFill:SetColorIndex(cardCfg.quality-1)
		prop2ProgFill:SetColorIndex(cardCfg.quality-1)
		prop3ProgFill:SetColorIndex(cardCfg.quality-1)
	elseif card.cardType == SpecialItemType.Coins then
		qualityText.text = Lang.OPEN_CHEST_2
		collectLevel.text = Lang.OPEN_CHEST_3
		quality:SetColorIndex(3)
		collectLevelMul:SetColorIndex(0)
		portraitDesc:SetObjectIndex(0)

		rightMul:SetObjectIndex(0)
		collectMul:SetObjectIndex(2)
		collectText.text = Role.coins
		portraitMul:SetImageIndex(0)
		countText.text = "+" .. card.count
		cardName.text = Lang.ToSpecialItemName(SpecialItemType.Coins)
		frame.color = getQualityColor(1)
		particle:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(1))
		showType = 3
	end
	tipText.text = #unopenCardList

	PlayCardFlyAnim(card)
	chestFlyAnim.gameObject:SetActive(false)
	chestAnim.gameObject:SetActive(true)
end