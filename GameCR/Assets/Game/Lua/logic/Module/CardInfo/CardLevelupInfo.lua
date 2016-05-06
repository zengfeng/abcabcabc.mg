CardLevelupInfo = class("CardLevelupInfo", 
{
})

function CardLevelupInfo:ctor(transform, window)
	self.transform = transform

	self.portraitBefore = CardLevelPortrait.New(transform:FindChild("Left/PortraitBefore"))
	self.portraitAfter = CardLevelPortrait.New(transform:FindChild("Left/PortraitAfter"))

	self.prop1 = transform:FindChild("Prop1")
	self.prop2 = transform:FindChild("Prop2")
	self.prop3 = transform:FindChild("Prop3")

	self.prop1Canvas = transform:FindChild("Prop1"):GetComponent("CanvasGroup")
	self.prop2Canvas = transform:FindChild("Prop2"):GetComponent("CanvasGroup")
	self.prop3Canvas = transform:FindChild("Prop3"):GetComponent("CanvasGroup")

	self.prop1Text = transform:FindChild("Prop1/Text"):GetComponent("Text")
	self.prop1AddText = transform:FindChild("Prop1/Add"):GetComponent("Text")
	self.prop2Text = transform:FindChild("Prop2/Text"):GetComponent("Text")
	self.prop2AddText = transform:FindChild("Prop2/Add"):GetComponent("Text")
	self.prop3Text = transform:FindChild("Prop3/Text"):GetComponent("Text")
	self.prop3AddText = transform:FindChild("Prop3/Add"):GetComponent("Text")

	self.propAnim1 = transform:FindChild("Prop1"):GetComponent("Animator")
	self.propAnim2 = transform:FindChild("Prop2"):GetComponent("Animator")
	self.propAnim3 = transform:FindChild("Prop3"):GetComponent("Animator")

	self.particle1 = transform:FindChild("Left/lizi_chixu"):GetComponent("ParticleSystem")
	self.particle2 = transform:FindChild("Left/lizi_jingyan"):GetComponent("ParticleSystem")
	self.particle3 = transform:FindChild("Left/lizi_baozha"):GetComponent("ParticleSystem")
	self.particle4 = transform:FindChild("Left/lizi_baozha/lizi_baozha2"):GetComponent("ParticleSystem")

	self.skill = transform:FindChild("Skill")
	self.skill.gameObject:SetActive(false)
	self.skillDes = transform:FindChild("Skill/Desc"):GetComponent("Text")
	self.skillTitle = transform:FindChild("Skill/Name/skillTitle"):GetComponent("Text")
	self.skillImg = transform:FindChild("Skill/SkillIcon/Image"):GetComponent("Image")
	self.skillQualityImg = transform:FindChild("Skill/SkillIcon/ImgQuality"):GetComponent("Image")

	self.cardLevel = 1
	self.transform.gameObject:SetActive(false)
	self.isCloseEnable = false
	self.tweenSeq = nil
	window:AddClick(transform.gameObject, handler(self, self.OnClick))
end

function CardLevelupInfo:displaySkill( cardCfg, textDes, textName, skillImage )
	-- body
	self.skill.gameObject:SetActive(true)
	local skillDisplay = ConfigManager.skillDisplay:GetConfig(cardCfg.skill)
	local s = skillDisplay.skillDescription
	local arr1 = {}
	local arr2 = {}
	local arr3 = {}
	local arr4 = {}
	local arr5 = {}
	local skillEffList = War.model:GetSkillWarConf(skillDisplay.skillId)
	for m1,m2 in string.gmatch(s, "{(%d+)}(%%?)") do

		local eff = skillEffList.effectDataList[m1]
		local str = ""
		local persent = ""
		local strReal = ""
		if m2 ~= "" then
			persent = "%"
		end
		str = str .. tostring(eff.data) .. persent

		local growUp = eff.growUp * self.cardLevel
		local _, f = math.modf(growUp)
		if f > 0 then
			growUp = tonumber(string.format("%.2f", growUp))
		end

		if growUp > 0 then
			local num = growUp - 0.4
			strReal = str .. "(<size=60><color=#19E059FF>+" .. tostring(num) .. persent .."</color></size>)"
		end
		table.insert(arr1, strReal)

		if growUp > 0 then
			local num = growUp - 0.3
			strReal = str .. "(<size=60><color=#19E059FF>+" .. tostring(num) .. persent .."</color></size>)"
		end
		table.insert(arr2, strReal)

		if growUp > 0 then
			local num = growUp - 0.2
			strReal = str .. "(<size=60><color=#19E059FF>+" .. tostring(num) .. persent .."</color></size>)"
		end
		table.insert(arr3, strReal)
		if growUp > 0 then
			local num = growUp - 0.1
			strReal = str .. "(<size=60><color=#19E059FF>+" .. tostring(num) .. persent .."</color></size>)"
		end
		table.insert(arr4, strReal)
		if growUp > 0 then
			local num = growUp
			num = string.format("%.1f", num)
			--print("=============num: " .. num)
			strReal = str .. "(<size=60><color=#19E059FF>+" .. tostring(num) .. persent .."</color></size>)"
		end
		table.insert(arr5, strReal)
	end
	s = string.gsub(s, "{(%d+)}(%%?)", "%%s")
	print("====================: " .. s .. "skillName: " .. skillDisplay.skillName)
	local seq = Sequence.Create(
		function ( ... )
			textDes.text = string.format(s, unpack(arr1))
		end,
		0.2,
		function ( ... )
			textDes.text = string.format(s, unpack(arr2))
		end,
		0.2,
		function ( ... )
			textDes.text = string.format(s, unpack(arr3))
		end,
		0.2,
		function ( ... )
			textDes.text = string.format(s, unpack(arr4))
		end,
		0.2,
		function ( ... )
			textDes.text = string.format(s, unpack(arr5))
		end
	)
	-- textName.text = skillDisplay.skillName

	if cardCfg.quality == CardQualityType.Purple then
		self.skillQualityImg.color = Color.New(238/255, 75/255, 1, 1)
	elseif cardCfg.quality == CardQualityType.Blue then
		self.skillQualityImg.color = Color.New(87/255, 127/255, 1, 1)
	else
		self.skillQualityImg.color = Color.New(1, 1, 1, 1)
	end

	local skillAvatar = ConfigManager.avatar:GetConfig(skillDisplay.avatarId)
	Coo.assetManager:LuaLoad(self, skillAvatar.icon, function(_, name, obj) skillImage.sprite = toSprite(obj) end)
end

function CardLevelupInfo:ShowWithId(cardId)
	self.transform.gameObject:SetActive(true)

	local roleCard = Role.cardManager:GetCard(cardId)
	local cardCfg = ConfigManager.card:GetConfig(cardId)
	local cardLevelCfg = ConfigManager.cardLevel:GetConfig(roleCard.level)
	self.cardLevel = roleCard.level
	--进度条数字变化
	self.portraitBefore:ShowWithId(cardId, roleCard.level - 1)
	local textExp = self.transform:FindChild("Left/Collect/Text"):GetComponent("Text")
	local cardLevelCfgOld = ConfigManager.cardLevel:GetConfig(roleCard.level - 1)
	local collect = self.transform:FindChild("Left/Collect")
	collect.gameObject:SetActive(false)
	collect.gameObject:SetActive(true)
	local collectSlider = collect:GetComponent("Slider")
	collectSlider.maxValue = cardLevelCfgOld.number
	collectSlider.value = cardLevelCfgOld.number
	print("==========value: " .. collectSlider.value .. " ==: " .. collectSlider.maxValue)
	local seq = Sequence.Create(
		0.25,
		Tweener.TweenTo(
			function()
				return cardLevelCfg.number
			end,
			function(v)
				textExp.text = math.floor(v) .. "/" .. cardLevelCfgOld.number
			end,
			0,
		    1),
		0.5,
		function ( ... )
			local cardLevelCfgNew = ConfigManager.cardLevel:GetConfig(roleCard.level)
			if cardLevelCfgNew ~= nil then
				textExp.text = 0 .. "/" .. cardLevelCfgNew.number
			end
		end
	)

	
	self.portraitAfter:ShowWithId(cardId, roleCard.level)

	local factor1 =  ConfigManager.prop:GetConfig(PropId.AtkAdd).displayMultiplier
	local factor2 =  ConfigManager.prop:GetConfig(PropId.ProduceSpeedAdd).displayMultiplier
	local factor3 =  ConfigManager.prop:GetConfig(PropId.MoveSpeedAdd).displayMultiplier
	local ratioFactor = Games.ConstConfig.GetFloat(Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio)

	local beforeProp1 = math.floor(cardCfg:GetAtk(roleCard.level - 1) * factor1)
	local beforeProp2 = math.floor(cardCfg:GetProduceSpe(roleCard.level - 1) * factor2 * ratioFactor)
	local beforeProp3 = math.floor(cardCfg:GetSpe(roleCard.level - 1) * factor3)

	local afterProp1 = math.floor(cardCfg:GetAtk(roleCard.level) * factor1)
	local afterProp2 = math.floor(cardCfg:GetProduceSpe(roleCard.level) * factor2 * ratioFactor)
	local afterProp3 = math.floor(cardCfg:GetSpe(roleCard.level) * factor3)

	self.prop1Text.text = beforeProp1
	self.prop1Text.text = ""
	self.prop2Text.text = beforeProp2
	self.prop2Text.text = ""
	self.prop3Text.text = beforeProp3
	self.prop3Text.text = ""

	self.particle1:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(cardCfg.quality))
	self.particle2:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(cardCfg.quality))
	self.particle3:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(cardCfg.quality))
	self.particle4:GetComponent("Renderer").material:SetColor("_TintColor", getQualityColor(cardCfg.quality))

	-- self.prop1Text.color = getQualityColor(cardCfg.quality)
	-- self.prop2Text.color = getQualityColor(cardCfg.quality)
	-- self.prop3Text.color = getQualityColor(cardCfg.quality)

	if cardCfg.quality == CardQualityType.Purple then
		self.prop1Text.color = getQualityColor(210/255, 22/255, 213/255, 1)
		self.prop2Text.color = getQualityColor(210/255, 22/255, 213/255, 1)
		self.prop3Text.color = getQualityColor(210/255, 2/255, 213/255, 1)
	elseif cardCfg.quality == CardQualityType.Blue then
		self.prop1Text.color = Color.New(18/255, 166/255, 1, 1)
		self.prop2Text.color = Color.New(18/255, 166/255, 1, 1)
		self.prop3Text.color = Color.New(18/255, 166/255, 1, 1)
	else
		self.prop1Text.color = Color.New(1, 1, 1, 1)
		self.prop2Text.color = Color.New(1, 1, 1, 1)
		self.prop3Text.color = Color.New(1, 1, 1, 1)
	end

	self.prop1AddText.text = "+" .. afterProp1 - beforeProp1
	self.prop2AddText.text = "+" .. afterProp2 - beforeProp2
	self.prop3AddText.text = "+" .. afterProp3 - beforeProp3

	self.curState = MainPanel.curState
	MainPanel.SetState(4)

	local allBefVal = {beforeProp1, beforeProp2, beforeProp3}
	local allAfVal = {afterProp1, afterProp2, afterProp3}

	function CreateTextTween(num, delay)
		local prop = self["prop" .. num]
		local propText = self["prop" .. num .. "Text"]
		local propCanvas = self["prop" .. num .. "Canvas"]
		local propAddText = self["prop" .. num .. "AddText"]
		local beforeVal = allBefVal[num]
		local afterVal = allAfVal[num]
		local PropAnimator = self["propAnim" .. num]
		propCanvas.alpha = 0
		local color = propAddText.color
		propAddText.color = Color.New(color.r, color.g, color.b, 0)

		local deltaX = -50
		local propPos = prop.anchoredPosition
		prop.anchoredPosition = Vector2.New(propPos.x - deltaX, propPos.y)

		local seq = Sequence.Create(
		delay,
		{
			Tweener.DOFade4(propCanvas, 1, 0.2),
			Tweener.DOAnchorPos(prop, propPos, 0.3, false),
		},
		function (  )
			PropAnimator:SetInteger("isFinish", 1)
		end,
		Tweener.TweenTo(
			function()
				--return beforeVal
				return 0
			end,
			function(v)
				propText.text = math.floor(v)
			end,
			afterVal,
			0.5)
		,
		-- function ()
		-- 	PropAnimator:SetInteger("isFinish", 1)
		-- 	--animatorStop(PropAnimator)
		-- end,
		Tweener.DOFade2(propAddText, 1, 0.1),
		function ( )
			if num == 3 then
				self.isCloseEnable = true
				self.tweenSeq = nil
			end
		end
		)
		return seq
	end

	self.tweenSeq = Sequence.Create(
		function () --武將卡牌显示
			self.portraitBefore:SetActive(true)
			self.portraitAfter:SetActive(false)

			self.prop1.gameObject:SetActive(false)
			self.prop2.gameObject:SetActive(false)
			self.prop3.gameObject:SetActive(false)
		end,
		2,
		function ( ) --技能描述显示
			self:displaySkill(cardCfg, self.skillDes, self.skillTitle, self.skillImg)
		end,
		0.5,
		function ( ... )
			self.portraitBefore:SetActive(false)
			self.portraitAfter:SetActive(true)
		end,
		function () -- 屬性增加显示
			self.prop1.gameObject:SetActive(true)
			self.prop2.gameObject:SetActive(true)
			self.prop3.gameObject:SetActive(true)
		end,
		{CreateTextTween(1, 0.3).tweenSeq,
		 CreateTextTween(2, 1.0 + 0.2).tweenSeq,
		 CreateTextTween(3, 1.7 + 0.2 + 0.2).tweenSeq}
	)
end

function CardLevelupInfo:OnClick()
	if self.isCloseEnable == false then
		if self.tweenSeq then
			Tweener.Complete(self.tweenSeq.tweenSeq, true)
			self.propAnim1:SetInteger("isFinish", 1)
			self.propAnim2:SetInteger("isFinish", 1)
			self.propAnim3:SetInteger("isFinish", 1)
		end
		return
	end
	self.isCloseEnable = false
	self.skill.gameObject:SetActive(false)
	self.transform.gameObject:SetActive(false)
	MainPanel.SetState(self.curState)
	CardInfoPanel.PlayExpAnim()
	GuideManager.CheckPoint(this, {[GuideType.Levelup] = {5}})

end

-----------------------
--  CardLevelPortrait
-----------------------

CardLevelPortrait = class("CardLevelPortrait")

function CardLevelPortrait:ctor(transform)
	self.transform = transform
	self.portrait = transform:GetComponent("Image")
	self.brand = transform:FindChild("Brand"):GetComponent("MultiImage")
	self.careerType = transform:FindChild("Brand/Type"):GetComponent("MultiImage")
	self.name = transform:FindChild("Brand/Name"):GetComponent("Text")
	self.level = transform:FindChild("Level"):GetComponent("Text")
	self.qualityImage = transform:FindChild("kuang02/liangbian01"):GetComponent("Image")
		-- self.collect = transform:FindChild("Collect"):GetComponent("Slider")
		-- self.collectText = transform:FindChild("Collect/Text"):GetComponent("Text")
end

function CardLevelPortrait:ShowWithId(cardId, level)
	local roleCard = Role.cardManager:GetCard(cardId)
	local cardCfg = ConfigManager.card:GetConfig(cardId)
	local cardLevelCfg = ConfigManager.cardLevel:GetConfig(level)
	local avatar = ConfigManager.avatar:GetConfig(cardCfg.avatarID)

	Coo.assetManager:LuaLoad(self, avatar.full, function(_, name, obj) self.portrait.sprite = toSprite(obj) end)
	
	self.brand:SetImageIndex(cardCfg.quality-1)
	self.careerType:SetImageIndex(cardCfg.career-1)
	self.name.text = cardCfg.name
	--textFormat(self, self.level, level)
	self.level.text = "Level " .. level
	self.qualityImage.color =getQualityColor(cardCfg.quality)
	-- if cardCfg.quality == CardQualityType.Purple then
	-- 	self.qualityImage.color = Color.New(93/255, 0, 1, 1)
	-- elseif cardCfg.quality == CardQualityType.Blue then
	-- 	self.qualityImage.color = Color.New(0, 86/255, 1, 1)
	-- else
	-- 	self.qualityImage.color = Color.New(1, 1, 1, 1)
	-- end
		-- self.collect.maxValue = cardLevelCfg.number
		-- self.collect.value = 0 --roleCard.count
		-- --self.collectText.text = roleCard.count .. "/" .. cardLevelCfg.number
		-- self.collectText.text = "0" .. "/" .. cardLevelCfg.number

end

function CardLevelPortrait:SetActive(isActive)
	self.transform.gameObject:SetActive(isActive)
end