local this = definePanel("CardInfoPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	portrait = transform:FindChild("Left/Portrait"):GetComponent("Image")
	brand = transform:FindChild("Left/Bg"):GetComponent("MultiColor")
	collect = transform:FindChild("Left/Portrait/Collect"):GetComponent("Slider")
	collectText = transform:FindChild("Left/Portrait/Collect/Text"):GetComponent("Text")
	collectNode = transform:FindChild("Left/Portrait/Collect")
	outBoard = transform:FindChild("Right/Bg/Out")

	skill = transform:FindChild("Right/Bg/Content/Skill")
	prop = transform:FindChild("Right/Bg/Content/Prop")
	expIcon = transform:FindChild("Right/Bg/Out/Icon")
	titleName = transform:FindChild("Right/Bg/Title/Text"):GetComponent("Text")
	titleMul = transform:FindChild("Right/Bg/Title"):GetComponent("MultiImage")
	skillIcon = skill:FindChild("SkillIcon/Image"):GetComponent("Image")
	desc = skill:FindChild("Desc"):GetComponent("Text")
	skillName = skill:FindChild("SkillName"):GetComponent("Text")
	skillNameMul = skill:FindChild("SkillName"):GetComponent("MultiColor")
	atkProg = prop:FindChild("Prop1/Progress"):GetComponent("Slider")
	atkProgMul = prop:FindChild("Prop1/Progress/Fill"):GetComponent("MultiColor")
	atkText = prop:FindChild("Prop1/Text"):GetComponent("Text")
	atkTextMul = prop:FindChild("Prop1/Text"):GetComponent("MultiColor")
	atkAdd = prop:FindChild("Prop1/Add"):GetComponent("Text")
	defProg = prop:FindChild("Prop2/Progress"):GetComponent("Slider")
	defProgMul = prop:FindChild("Prop2/Progress/Fill"):GetComponent("MultiColor")
	defText = prop:FindChild("Prop2/Text"):GetComponent("Text")
	defTextMul = prop:FindChild("Prop2/Text"):GetComponent("MultiColor")
	defAdd = prop:FindChild("Prop2/Add"):GetComponent("Text")
	speProg = prop:FindChild("Prop3/Progress"):GetComponent("Slider")
	speProgMul = prop:FindChild("Prop3/Progress/Fill"):GetComponent("MultiColor")
	speText = prop:FindChild("Prop3/Text"):GetComponent("Text")
	speTextMul = prop:FindChild("Prop3/Text"):GetComponent("MultiColor")
	speAdd = prop:FindChild("Prop3/Add"):GetComponent("Text")
	exp = outBoard:FindChild("Exp"):GetComponent("Text")
	lvBtn = outBoard:FindChild("YellowButton")
	lvBtnMaterial = outBoard:FindChild("YellowButton"):GetComponent("ImageSetMaterial")
	lvCost = lvBtn:FindChild("Cost"):GetComponent("Text")
	lvCostColor = lvBtn:FindChild("Cost"):GetComponent("MultiColor")

	cardLevelupInfo = CardLevelupInfo.New(transform:FindChild("LvUp"), window)
	--cardCallBack = nil
	window:AddClick(lvBtn.gameObject, OnClickLevelUp)
	EventManager.AddEventListener(this, "S_CardLevelUp_0x201", OnLevelUpRecv)
	oldRoleLevel = nil
	cardId = 0
	levelUpState = 1 --1数量不足，2金币不够，3可以升级
	lastExp = 0
	sparkingBar = false
end

function OnEnter()
	cardId = parameter[1]
	isNotOwner = parameter[2]

	if parameter[3] == nil then
		MainPanel.backCallback = OnClickClose
	else
		MainPanel.backCallback = parameter[3]
	end
	UpdateWithId()

	GuideManager.CheckPoint(this, {[GuideType.Levelup] = {3}})
	oldRoleLevel = Role.level
	
	sparkingBar = false
end

-----------------------
--  Function
-----------------------

function OnClickClose()
	if window:GetBackId() == MenuType.Embattle then
		EmbattlePanel.UpdateEmbattleCard()
		if sparkingBar then
			EmbattlePanel.SparkBar()
		end
	end
	window:Back()
end

function OnLevelUpRecv()
	lastExp = tonumber(exp.text)
	UpdateWithId()
	cardLevelupInfo:ShowWithId(cardId)

	sparkingBar = true
end

function PlayExpAnim()
	MainPanel.PlayExpAnimation(expIcon, tonumber(lastExp), 10, function()
		if Role.level > oldRoleLevel then
			local roleLevel = RoleLevelPanel.New(window)--主公升级界面
			roleLevel:ShowProp()
			oldRoleLevel =  Role.level
		end
		end)
	
end

function UpdateWithId()
	local cardCfg = ConfigManager.card:GetConfig(cardId)
	
	local avatar = ConfigManager.avatar:GetConfig(cardCfg.avatarID)

	Coo.assetManager:LuaLoad(this, avatar.full, function(_, name, obj) portrait.sprite = toSprite(obj) end)
	skillName.text = cardCfg.name
	brand:SetColorIndex(cardCfg.quality-1)
	titleMul:SetImageIndex(cardCfg.quality-1)
	skillNameMul:SetColorIndex(cardCfg.quality-1)
	atkProgMul:SetColorIndex(cardCfg.quality-1)
	defProgMul:SetColorIndex(cardCfg.quality-1)
	speProgMul:SetColorIndex(cardCfg.quality-1)
	atkTextMul:SetColorIndex(cardCfg.quality-1)
	defTextMul:SetColorIndex(cardCfg.quality-1)
	speTextMul:SetColorIndex(cardCfg.quality-1)

	levelUpState = 3

	if not isNotOwner then
		local roleCard = Role.cardManager:GetCard(cardId)
		local cardLevelCfg = ConfigManager.cardLevel:GetConfig(roleCard.level)
		titleName.text = roleCard.level .. Lang.Level .. cardCfg.name
		collect.maxValue = cardLevelCfg.number
		collect.value = roleCard.count
		collectText.text = roleCard.count .. "/" .. cardLevelCfg.number

		if roleCard.count < cardLevelCfg.number then
			levelUpState = 1
			lvBtnMaterial:SetMaterial(0)
		else
			lvBtnMaterial:SetMaterial(1)
		end
		
		collectNode.gameObject:SetActive(true)
		outBoard.gameObject:SetActive(true)
	else
		titleName.text =  cardCfg.name
		collectNode.gameObject:SetActive(false)
		outBoard.gameObject:SetActive(false)
	end
	local roleCard = Role.cardManager:GetCard(cardId)
	print("cardId=" .. cardId)
	print("cardCfg.skill=" .. cardCfg.skill)
	local skillDisplay = ConfigManager.skillDisplay:GetConfig(cardCfg.skill)
	if roleCard ~= nil then
		cardLevel = roleCard.level
	else
		cardLevel = 1
	end
	local skillDesc = ConfigManager.skillDisplay:GetSkillDesc(cardCfg.skill,cardLevel)
	desc.text = skillDesc
	local skillAvatar = ConfigManager.avatar:GetConfig(skillDisplay.avatarId)
	Coo.assetManager:LuaLoad(this, skillAvatar.icon, function(_, name, obj) skillIcon.sprite = toSprite(obj) end)

	local factor1 =  ConfigManager.prop:GetConfig(PropId.AtkAdd).displayMultiplier
	local factor2 =  ConfigManager.prop:GetConfig(PropId.ProduceSpeedAdd).displayMultiplier
	local factor3 =  ConfigManager.prop:GetConfig(PropId.MoveSpeedAdd).displayMultiplier
	local ratioFactor = Games.ConstConfig.GetFloat(Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio)

	atkProg.value = cardCfg.speciallyAtk
	defProg.value = cardCfg.speciallyDef
	speProg.value = cardCfg.speciallySpeed

	
	local roleCardLevel = isNotOwner and 1 or roleCard.level
	local prop1 = math.floor(cardCfg:GetAtk(1) * factor1)
	local prop2 = math.floor(cardCfg:GetProduceSpe(1) * factor2 * ratioFactor)
	local prop3 = math.floor(cardCfg:GetSpe(1) * factor3)

	local realProp1 = math.floor(cardCfg:GetAtk(roleCardLevel) * factor1)
	local realProp2 = math.floor(cardCfg:GetProduceSpe(roleCardLevel) * factor2 * ratioFactor)
	local realProp3 = math.floor(cardCfg:GetSpe(roleCardLevel) * factor3)

	atkText.text = prop1
	defText.text = prop2
	speText.text = prop3
	atkAdd.text = "+" .. (realProp1 - prop1)
	defAdd.text = "+" .. (realProp2 - prop2)
	speAdd.text = "+" .. (realProp3 - prop3)
	exp.text = ConfigManager.cardLevel:GetExp(roleCardLevel, cardCfg.quality)

	if roleCardLevel <= 1 then
		atkAdd.gameObject:SetActive(false)
		defAdd.gameObject:SetActive(false)
		speAdd.gameObject:SetActive(false)
	else
		atkAdd.gameObject:SetActive(true)
		defAdd.gameObject:SetActive(true)
		speAdd.gameObject:SetActive(true)
	end

	local cost = ConfigManager.cardLevel:GetCoin(roleCardLevel, cardCfg.quality)
	lvCost.text = cost
	if Role.coins < cost then
		lvCostColor:SetColorIndex(0)
		levelUpState = 2
	else
		lvCostColor:SetColorIndex(-1)
	end
end

function OnClickLevelUp()
	GuideManager.CheckPoint(this, {[GuideType.Levelup] = {4}})
	-- OnLevelUpRecv()
	if levelUpState == 1 then
		CommonUtil.ShowMsg(Lang.CARD_INFO_1)
		return
	end
	if levelUpState == 2 then
		CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_2)
		return
	end
	CardProto.C_CardLevelUp_0x201(cardId)
end