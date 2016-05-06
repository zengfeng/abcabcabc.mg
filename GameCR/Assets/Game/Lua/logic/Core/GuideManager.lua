GuideManager = class("GuideManager", 
{
	mask = nil,
	indicator = nil,
	unforceIndicator = nil,
	target = nil,
	curObj = nil,
	curStep = 1,
	curSubStep = 0,
	curGuideTypeList = nil,
	parentMap = nil,
	lastTrans = {},
	nonLineGuide = {},
})

local this = GuideManager
local finishTag = 9999

function GuideManager.Init()
	local transform = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	this.mask = transform:FindChild("Mask")
	this.indicator = transform:FindChild("Mask/Indicator")

	this.unforceIndicator = transform.transform:Find("Mask/UnforceIndicator")
	this.unforceIndicator:SetParent(this.mask, false)
	this.unforceIndicator.gameObject:SetActive(false)

	this.parentMap = {}
	this.Load()
end

function GuideManager.Reset()
	this.curStep = 1
	this.curSubStep = 0
end

function GuideManager.Save()
	local str = ""
	for k,v in pairs(this.nonLineGuide) do
		str = str .. k .. ":" .. v .. ","
	end
	str = string.sub(str, 1, -2)
	PlayerPrefsUtil.SetString(PlayerPrefsKey.GuideManager, str)
end

function GuideManager.Load()
	this.nonLineGuide = {}

	local str = PlayerPrefsUtil.GetString(PlayerPrefsKey.GuideManager)
	local arr = string.split(str, ",")
	if arr then
		for k,v in pairs(arr) do
			local pair = string.split(v, ":")
			this.nonLineGuide[toInt(pair[1])] = toInt(pair[2])
		end
	end
end

-- guideTypeList = {guideType = {subStep...}, guideType = {subStep...}}
function GuideManager.CheckPoint(obj, guideTypeList, isJump)
	this.curObj = obj
	this.curGuideTypeList = guideTypeList

	isJump = isJump or false

	local transCfg = ConfigManager.train:GetConfig(Role.newGuideStep)
	local guideList = transCfg.guide.listUnsorted
	if #guideList > 0 then
		local guidePair = guideList[this.curStep]
		if guidePair then
			local subList = guideTypeList[guidePair.id]

			if subList then
				local runnable = false
				if table.contains(subList, this.curSubStep + 1) then --跳转状态
					this.curSubStep = this.curSubStep + 1
					runnable = true
				elseif table.contains(subList, this.curSubStep) then --当前状态
					runnable = true
				elseif isJump then
					this.curSubStep = subList[1]
					runnable = true
				end

				if runnable then
					local arr = string.split(guidePair.value, "-")
					this["RunStep" .. guidePair.id](arr)
				end
			end
		end
	end
end

--非线性引导（非强制）
function GuideManager.NonLineCheckPoint(obj, guideTypeList, isJump)
	this.curObj = obj
	isJump = isJump or false

	print_sp(this.nonLineGuide)

	for k1,v1 in pairs(guideTypeList) do
		local runnable = false
		local curStep = 1
		if this.nonLineGuide[k1] then
			curStep = this.nonLineGuide[k1]
		end

		if curStep == finishTag then
			runnable = false
		elseif table.contains(v1, curStep + 1) then --跳转状态
			curStep = curStep + 1
			runnable = true
		elseif table.contains(subList, this.curSubStep) then --当前状态
			runnable = true
		elseif isJump then
			curStep = v1[1]
			runnable = true
		end

		if runnable then
			this.nonLineGuide[k1] = curStep
			this["RunStep" .. k1](curStep)
		end
	end
end

function GuideManager.UnforcePoint(trans)
	if trans then
		this.unforceIndicator.gameObject:SetActive(true)
		this.unforceIndicator:SetParent(trans, false)
		this.unforceIndicator.anchoredPosition = Vector2.New(0, 0)
	else
		this.unforceIndicator:SetParent(this.mask, false)
		this.unforceIndicator.gameObject:SetActive(false)
	end
end

function GuideManager.BringToTop(trans, pointer, reset, waitTimer)
	if pointer == nil then
		pointer = true
	end
	if reset == nil then
		reset = true
	end
	if waitTimer == nil then
		waitTimer = 0
	end
	if reset then
		this.BringBack()
	end
	
	this.mask.gameObject:SetActive(true)
	this.indicator.gameObject:SetActive(false)

	this.lastTrans[trans] = trans
	this.parentMap[trans] = trans.parent
	trans:SetParent(this.mask, true)

	if pointer then
		Sequence.Create(waitTimer, function ()
			this.indicator.gameObject:SetActive(true)
		end)	
		this.indicator.localPosition = Vector3.New(trans.localPosition.x, trans.localPosition.y, 0)
		this.indicator:SetAsLastSibling()
	
	elseif reset then
		this.indicator.gameObject:SetActive(false)
	end
end

function GuideManager.BringBack()
	for k,v in pairs(this.lastTrans) do
		if this.parentMap[v] then
			v:SetParent(this.parentMap[v], true)
		end
	end

	this.lastTrans = {}
	this.parentMap = {}
	this.mask.gameObject:SetActive(false)
end

function GuideManager.FinishStep()
	this.curSubStep = 0
	this.curStep = this.curStep + 1

	this.BringBack()
end

-----------------------
--  引导类型逻辑
-----------------------

--GuideType.EnterTrain 强制进入训练模式
function GuideManager.RunStep1(paramsArr)
	local obj = this.curObj
	local subStep = this.curSubStep

	if subStep == 1 then
		this.BringToTop(obj.arenaBtn)
	elseif subStep == 2 then
		this.BringBack()
		this.FinishStep()
	end
end

--GuideType.Embattle 布阵
function GuideManager.RunStep2(paramsArr)
	local obj = this.curObj
	local subStep = this.curSubStep
	if subStep == 1 then
		this.BringBack()
		this.mask.gameObject:SetActive(true)
		this.indicator.gameObject:SetActive(false)
	elseif subStep == 2 then
		local id = tonumber(paramsArr[1])
		if id == obj.cardId then
			this.BringToTop(obj.head.transform)
			-- this.BringToTop(EmbattlePanel.bottom, false, false)
		end
	elseif subStep == 3 then
		this.BringBack()
		this.mask.gameObject:SetActive(true)
		this.indicator.gameObject:SetActive(false)
	elseif subStep == 4 then
		local id = tonumber(paramsArr[1])
		if id == obj.cardId then
			this.FinishStep()
			EmbattlePanel.ReloadData()
			GuideManager.CheckPoint(nil, {[GuideType.PointClose] = {1}})
		end
	end

	print_sp("uideManager.RunStep2   ", subStep)
end

--GuideType.Levelup 升级
function GuideManager.RunStep3(paramsArr)
	local obj = this.curObj
	local subStep = this.curSubStep

	print_sp("uideManager.RunStep3   ", subStep)
	
	local id = tonumber(paramsArr[1])
	if subStep == 1 then
		this.BringBack()
		this.mask.gameObject:SetActive(true)
		this.indicator.gameObject:SetActive(false)
	elseif subStep == 2 then
		if id == obj.cardId then
			this.BringToTop(obj.infoButton.transform)
		end
	elseif subStep == 3 then
		if id == obj.cardId then
			this.BringToTop(obj.lvBtn.transform)
		end
	elseif subStep == 4 then
		this.BringBack()
	elseif subStep == 5 then
		this.FinishStep()
		EmbattlePanel.ReloadData()
		GuideManager.CheckPoint(nil, {[GuideType.PointClose] = {1}})
	end
end

--GuideType.OpenChest 开宝箱
function GuideManager.RunStep4(paramsArr)

	local obj = this.curObj
	local subStep = this.curSubStep
	if subStep == 1 then
		this.BringToTop(obj.transform, nil, nil, 1.5)
	elseif subStep == 2 then
		this.BringToTop(obj.button)
	elseif subStep == 3 then
		this.BringBack()
	elseif subStep == 4 then
		this.BringToTop(obj.transform)
	elseif subStep == 5 then
		this.BringToTop(obj.button)
	elseif subStep == 6 then
		this.BringBack()
	elseif subStep == 7 then
		this.FinishStep()
	end

	--分支：宝箱时间到
	if subStep == 11 then
		this.BringToTop(obj.transform)
	elseif subStep == 12 then
		this.BringBack()
	elseif subStep == 13 then
		this.FinishStep()
	end
end

--GuideType.PointEmbattle 引导打开布阵界面
function GuideManager.RunStep100(paramsArr)
	local obj = this.curObj
	local subStep = this.curSubStep

	if subStep == 1 then
		this.BringToTop(obj.heroBtn)
	elseif subStep == 2 then
		this.FinishStep()
	end
end

--GuideType.PointClose 引导关闭界面
function GuideManager.RunStep101(paramsArr)
	local subStep = this.curSubStep

	if subStep == 1 then
		local closeBtn = MainPanel.backBtn
		if Coo.menuManager.currentWindowId == MenuType.Embattle then
			closeBtn = EmbattlePanel.closeButton
		end
		this.BringToTop(closeBtn)
	elseif subStep == 2 then
		this.FinishStep()
		GuideManager.CheckPoint(nil, {[GuideType.PointClose] = {1}})
	end
end


-----------------------
--  非强制引导逻辑
-----------------------

--GuideType.Dungeon 引导副本
function GuideManager.RunStep10001(subStep)
	local obj = this.curObj
	if not this.nonLineGuide[GuideType.Arena] or this.nonLineGuide[GuideType.Arena] ~= finishTag then
		return
	end
	if #Role.dungeonManager.dungeonStageMap > 0 then
		return
	end

	if subStep == 1 then
		this.UnforcePoint(obj.dungeonBtn)
	elseif subStep == 2 then
		this.UnforcePoint(obj.dungeonList[2].transform)
	elseif subStep == 3 then
		this.nonLineGuide[GuideType.Dungeon] = finishTag
		this.Save()
		this.UnforcePoint(nil)
	end
end

--GuideType.Arena 引导竞技场
function GuideManager.RunStep10002(subStep)
	local obj = this.curObj

	if subStep == 1 then
		this.UnforcePoint(obj.arenaBtn)
	elseif subStep == 2 then
		this.nonLineGuide[GuideType.Arena] = finishTag
		this.Save()
		this.UnforcePoint(nil)
	end
end