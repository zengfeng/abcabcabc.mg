local this = definePanel("EmbattlePanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	selectList = transform:FindChild("SelectList"):GetComponent("TableView")
	activeGroup = transform:FindChild("Title/ActiveGroup"):GetComponent("ActiveGroup")
	bottom = transform:FindChild("Bottom")
	infoPanel = transform:FindChild("Bottom/Info")
	division = transform:FindChild("SelectList/Content/Division")
	emCards = {}
	for i=1,8 do
		table.insert(emCards, EmbattleCard.New(transform:FindChild("Bottom/Right/Bg/EmbattleCard" .. tostring(i)), window, i))
	end
	atkBar = transform:FindChild("Bottom/Info/Atk"):GetComponent("Slider")
	atkValue = transform:FindChild("Bottom/Info/Atk/Text"):GetComponent("Text")
	defBar = transform:FindChild("Bottom/Info/Def"):GetComponent("Slider")
	defValue = transform:FindChild("Bottom/Info/Def/Text"):GetComponent("Text")
	speBar = transform:FindChild("Bottom/Info/Spe"):GetComponent("Slider")
	speValue = transform:FindChild("Bottom/Info/Spe/Text"):GetComponent("Text")

	bar1Anim = transform:FindChild("Bottom/Info/Sparking/Image01"):GetComponent("Animator")
	bar2Anim = transform:FindChild("Bottom/Info/Sparking/Image02"):GetComponent("Animator")
	bar3Anim = transform:FindChild("Bottom/Info/Sparking/Image03"):GetComponent("Animator")
	bar1Anim.gameObject:SetActive(false)
	bar2Anim.gameObject:SetActive(false)
	bar3Anim.gameObject:SetActive(false)

	soldierImg = transform:FindChild("Bottom/Soldier/Head"):GetComponent("Image")
	soldierIcon = transform:FindChild("Bottom/Soldier/Icon"):GetComponent("MultiImage")
	soldierAdd = transform:FindChild("Bottom/Soldier/Add"):GetComponent("Text")

	roleCards = {}
	cardBrands = {}
	cardBrandsIndexMap = {}
	sortHeroList = {}
	divisionIndex = 0
	delay = true
	isEffectLight = false
	closeButton = transform:FindChild("Title/CloseButton")
	activeGroup:SetChangeCallback(OnChangeTab)
	selectList:Setup(OnItemUpdate, 0, false)

	window:AddClick(closeButton.gameObject, OnBeforeClose)
	window:AddClick(soldierImg.gameObject, OnClickSoldier)
end

function OnEnter()
	for i,v in ipairs(emCards) do
		v:OnEnter()
	end
	local battleCards = Role.cardManager.battleCards
	for i,v in ipairs(battleCards) do
		AddArrange(v, false)
	end

	activeGroup:SelectByUid(0)
	isChange = false--有无上阵
	atkBar.value = 0
	defBar.value = 0
	speBar.value = 0
	delay = true
	isFlyDone = true --上阵时候飞出的闪光是否已经飞到目的地
	UpdateBar()

	local soldierCfg = Role.soldierManager:GetBattleSoldierCfg()
	UIUtils.LoadAvatarWithId(soldierImg, soldierCfg.avatarId)

	if soldierCfg.initBattle > 0 then
		soldierIcon:SetImageIndex(0)
		soldierAdd.text = "+" .. soldierCfg:GetProp1(true)
	elseif soldierCfg.initGainSoldier > 0 then
		soldierIcon:SetImageIndex(1)
		soldierAdd.text = "+" .. soldierCfg:GetProp2(true)
	else
		soldierIcon:SetImageIndex(2)
		soldierAdd.text = "+" .. soldierCfg:GetProp3(true)
	end
end

-----------------------
--  Function
-----------------------
function EffectLight(cardId, callback)
	if not isEffectLight then
		return
	end
	isFlyDone = false
	local effects = {}
	for k,v in pairs(cardBrands) do
		if v.cardId == cardId then
			effectParent = v
		end	
	end
	local flyTime = 0.6
	for i=1, 3 do
		Coo.assetManager:LuaLoad(this, "effect_ui/CR_ui/shangsheng_guang", function (_, name, obj)--发光特效
				local effect = newobject(obj).transform
				local effectRect = effect:GetComponent("RectTransform")	
				effect.transform:SetParent(effectParent.transform, false)
				effectRect.anchoredPosition = Vector2.New(0 , 0)				
				endPosObj = transform:FindChild("Bottom/Info/Sparking"):GetChild(i-1)
				-- local endPos = MiscLuaUtil.AnchoredPosNode1InNode2Local(endPosObj, effectParent.transform)
				-- endPos = Vector3.New(endPos.x + effectParent.transform.rect.width * (effectParent.transform.pivot.x - 0.5), 
				-- 			endPos.y + effectParent.transform.rect.height * (effectParent.transform.pivot.y - 0.5), 0)
				-- print_sp("endPosX=", endPos.x, "endPosY=", endPos.y)
				local anim = effect:GetComponent("UIAnimationComm")	
				local  offsetTag = 0
				if i == 1 then
					offsetTag = 1
				elseif i == 2 then
					offsetTag = 0
				elseif i == 3 then	
					offsetTag = -1
				end
				anim:AnimationFlyTo(endPosObj.transform, offsetTag, flyTime)

			end)
	end
	local tweeners = {}
	table.insert(tweeners, flyTime)
	table.insert(tweeners, function() 
		isFlyDone = true
		if callback then
			callback()
		end
	end)
	Sequence.CreateWithArray(tweeners)
	isEffectLight = false
end

function SparkBar()
	EffectLight(selectCardId, function() 
			bar1Anim.gameObject:SetActive(true)
			bar1Anim:SetTime(0)
			bar1Anim.speed = 1
			bar2Anim.gameObject:SetActive(true)
			bar2Anim:SetTime(0)
			bar2Anim.speed = 1
			bar3Anim.gameObject:SetActive(true)
			bar3Anim:SetTime(0)
			bar3Anim.speed = 1
			end
		)
end

function UpdateEmbattleCard()
	for i,v in ipairs(emCards) do
		if v:IsArrange() then
			v:Arrange(v.cardId)
		end
	end
end

function AddArrange(cardId, updateBar)
	if isFlyDone == false then
		return false
	end
	selectCardId = cardId
	local isArr = false
	for i,v in ipairs(emCards) do
		if not v:IsArrange() then
			isArr = v:Arrange(cardId)
			break
		end
	end
	if not isArr then
		CommonUtil.ShowMsg(Lang.EMBATTLE_1)
		return false
	end

	if updateBar == nil then
		updateBar = true
	end
	if updateBar then
		isEffectLight = true
		UpdateBar()
		SparkBar()
	end
	isChange = true
	return isArr
end

function RemoveArrange(cardId, updateBar)
	for i,v in ipairs(emCards) do
		if v.cardId == cardId then
			v:Remove()
		end
	end

	if updateBar == nil then
		updateBar = true
	end
	if updateBar then
		UpdateBar()
	end
	isChange = true
end

function ReloadData(career)
	career = career or 0
	sortHeroList = {}
	sortUnHeroList = {}--未招募

	local c = Role.cardManager.allCards
	local myList = {}
	for k,v in pairs(c) do
		local config = v:GetConfig()
		local show = false
		show = show or career == 0
		show = show or career == config.career
		if show then
			myList[v.cardId] = v
			table.insert(sortHeroList, v)
		end
	end

	table.sort(sortHeroList, function(a, b)
		local cfgA = a:GetConfig()
		local cfgB = b:GetConfig()
		local weightA = cfgA.quality*100 + a.level
		local weightB = cfgB.quality*100 + b.level
		return weightA > weightB
	end)

	table.insert(sortHeroList, "division")
	divisionIndex = #sortHeroList

	for k,v in pairs(ConfigManager.card.configs) do
		if not myList[v.id] and v.state ~= 0 then
			local show = false
			show = show or career == 0
			show = show or career == v.career
			if show then
				table.insert(sortUnHeroList, v)
			end
		end
	end
	
	table.sort(sortUnHeroList, function(a, b)
		
		return b.arena > a.arena
	end)
	for k,v in pairs(sortUnHeroList) do
		table.insert(sortHeroList, v)
	end
	cardBrands = {}
	cardBrandsIndexMap = {}
	selectList:ReloadData(#sortHeroList)
end

function OnItemUpdate(lineTable, line, tableView)
	items = {}
	for k,v in pairs(lineTable) do
		local idx = tonumber(k)
		if v == "null" then
			if cardBrandsIndexMap[idx] then
				cardBrands[cardBrandsIndexMap[idx]] = nil
				cardBrandsIndexMap[idx] = nil
			end
		else
			local data = sortHeroList[idx]
			if idx == divisionIndex then
				destroyChildren(v.transform)
				local o = newobject(division.gameObject)
				o:SetActive(true)
				o.transform:SetParent(v.transform, true)
				o.transform.anchoredPosition = Vector2.New(0, 0)
			elseif idx < divisionIndex then
				local config = data:GetConfig()
				local isEmbattle = false
				for _,v2 in ipairs(emCards) do
					if v2.cardId == data.cardId then
						isEmbattle = true
					end
				end

				local item = CardBrand.New(v.transform, window)
				item:UpdateByRoleCardId(data.cardId, isEmbattle)
				cardBrands[data.cardId] = item
				cardBrandsIndexMap[idx] = data.cardId
			else
				local item = CardBrand.New(v.transform, window)
				item:UpdateById(data.id, false)
			end
		end
	end
end

function UpdateBar()
	local cardIds = {}
	for i,v in ipairs(emCards) do
		if v:IsArrange() then
			local roleCard = Role.cardManager:GetCard(v.cardId)
			table.insert(cardIds, {v.cardId, roleCard.level})
		end
	end

	local totalAtkValue, totalDefValue, totalSpValue, maxAtkValue, maxDefValue, maxSpValue = 
					BattleManager.GetTotalDisplayBattleProp(cardIds, Role.soldierManager.battleSoldier, Role.level)

	atkValue.text = math.floor(totalAtkValue)
	UIUtils.UpdateProgress(atkBar, maxAtkValue, totalAtkValue, delay)

	defValue.text = math.floor(totalDefValue)
	UIUtils.UpdateProgress(defBar, maxDefValue, totalDefValue, delay)

	speValue.text = math.floor(totalSpValue)
	UIUtils.UpdateProgress(speBar, maxSpValue, totalSpValue, delay)

	delay = false
end

function OnChangeTab(uid)
	ReloadData(uid)
end

function OnBeforeClose()
	if not Role.IsTrainState() then
		local count = 0
		for i,v in ipairs(emCards) do
			if v:IsArrange() then
				count = count + 1
			end
		end

		if count < Role.GetExpConfig().embattle and table.getCount(Role.cardManager.allCards) > count then
			local win = MsgWindow.New(transform, window)
			win:SetMsg(nil, Lang.EMBATTLE_SUBTITLE, Lang.EMBATTLE_DESC)
			win:Show(function()
				OnClickClose()
			end)
			return
		end
		OnClickClose()
	else
		OnClickClose()
	end
end

function OnClickSoldier()
	SendEmbattle()
	Coo.menuManager:OpenMenuBack(MenuType.Soldier, window.menuId)
end

function SendEmbattle()
	if isChange == true then
		local ids = {}
		for i,v in ipairs(emCards) do
			if v.cardId > 0 then
				table.insert(ids, v.cardId)
			end
		end
		CardProto.C_CardBattleStatusChange_0x202(ids)
		isChange = false
	end
end

function OnClickClose()
	SendEmbattle()
	-- local ids = {}
	-- for i,v in ipairs(emCards) do
	-- 	if v.cardId > 0 then
	-- 		table.insert(ids, v.cardId)
	-- 	end
	-- end
	-- CardProto.C_CardBattleStatusChange_0x202(ids)
	window:Exit()

	GuideManager.CheckPoint(nil, {[GuideType.PointClose] = {2}})

	HomePanel.OnEnter()
end