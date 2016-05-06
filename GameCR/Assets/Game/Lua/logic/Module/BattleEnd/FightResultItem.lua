FightResultItem = class("FightResultItem", 
{
})

function FightResultItem:ctor(transform, window)
	self.starList = transform:FindChild("StarList")
	self.buildCount = transform:FindChild("Building/Text"):GetComponent("Text")
	self.buildImg  = transform:FindChild("Building/Image"):GetComponent("Image")
	self.buildProgress = transform:FindChild("Progress"):GetComponent("Slider")
	self.headIcon = transform:FindChild("Head/Icon"):GetComponent("Image")
	self.name = transform:FindChild("Head/Name"):GetComponent("Text")

	self.roleFightResult = nil
end

function FightResultItem:UpdateWith(roleFightResult, warEnterLegionData)
	roleFightResult = roleFightResult --[type:RoleFightResult]
	self.roleFightResult = roleFightResult --[type:RoleFightResult]

	self:SetStar(roleFightResult.star)

	self.buildCount.text = roleFightResult.buildCount
	self.buildProgress.maxValue = roleFightResult.buildTotal
	self.buildProgress.value = roleFightResult.buildCount

	if warEnterLegionData then
		UIUtils.LoadAvatarWithId(self.headIcon, warEnterLegionData.headAvatarId)
		self.name.text = warEnterLegionData.name
	else
		local roleId = roleFightResult.roleId
		local roleInfo = BattleManager.battleParam:GetFightRoleInfoById(roleFightResult.roleId)--[type:FightRoleInfo]
		if roleInfo then
			UIUtils.LoadAvatarWithId(self.headIcon, roleInfo.roleInfo.icon)
			self.name.text = roleInfo.roleInfo.name
		end
	end
end

function FightResultItem:SetStar(star)
	for i=0,self.starList.childCount-1 do
		local child = self.starList:GetChild(i):GetComponent("MultiColor")
		if i+1 <= star then
			child:SetColorIndex(0)
		else
			child:SetColorIndex(1)
		end
	end
end

function FightResultItem:SetPVPVisible(vis)
	-- self.starList.gameObject:SetActive(vis)
end

function FightResultItem:PlayBuilding(isLeft)
	self.progVal = self.buildProgress.value
	self.buildProgress.value = 0
	self.buildCount.text = 0
	self:SetStar(0)

	local seqArr = {}
	local lastVal = 0
	local buildPos = self.buildImg.transform.anchoredPosition
	local moveProg = Tweener.DOValue(self.buildProgress, self.progVal, self.roleFightResult.buildCount * 0.1, false)
	Tweener.SetOnUpdate(moveProg, function()
		local val = math.floor(self.buildProgress.value)
		if val > lastVal then
			lastVal = val

			local newBuilding = newobject(self.buildImg.transform.gameObject).transform
			newBuilding:SetParent(self.buildImg.transform.parent, false)
			newBuilding.gameObject:SetActive(true)

			local offset = 150
			if isLeft then
				offset = -1 * offset
			end

			local img = newBuilding:GetComponent("Image")
			Tweener.DOAnchorPos(newBuilding, Vector2.New(buildPos.x - offset, buildPos.y), 0.2, false)
			Tweener.DOFade3(img, 0, 0.2)
			Tweener.DOScale(newBuilding, 0.5, 0.2)

			Coo.soundManager:PlaySound("gain_building")
		end

		self.buildCount.text = val
	end)
	Tweener.SetEase(moveProg, Ease.Linear)

	function numScaleFunc()
		self.buildCount.transform.localScale = Vector3.New(0.8, 0.8, 0.8)
		local numTweenScale1 = Tweener.DOScale(self.buildCount.transform, 1.4, 0.3)
		local numTweenScale2 = Tweener.DOScale(self.buildCount.transform, 1, 0.3)
		Tweener.SetEase(numTweenScale1, Ease.Linear)
		Tweener.SetEase(numTweenScale2, Ease.Linear)
		Sequence.Create(numTweenScale1, numTweenScale2)
	end

	table.insert(seqArr, moveProg)
	table.insert(seqArr, numScaleFunc)

	return Sequence.CreateWithArray(seqArr)
end

function FightResultItem:PlayStar()
	local lastStarVal = 0
	local starVal = 0
	local starTween = Tweener.TweenTo(
	function()
		return starVal
	end, 
	function(val)
		starVal = val
	end, 
	self.roleFightResult.star, self.roleFightResult.star*0.4)
	Tweener.SetOnUpdate(starTween, function()
		local star = math.floor(starVal)
		if star > lastStarVal then
			lastStarVal = star
			self:SetStar(star)

			local starTrans = self.starList:GetChild(star-1)
			starTrans.localScale = Vector3.New(0.8, 0.8, 0.8)
			local scale1 = Tweener.DOScale(starTrans, 1.3, 0.1)
			Tweener.SetEase(scale1, Ease.Linear)
			local scale2 = Tweener.DOScale(starTrans, 1, 0.1)
			Tweener.SetEase(scale2, Ease.Linear)
			Sequence.Create(scale1, scale2)

			Coo.soundManager:PlaySound("gain_star")
		end
	end)
	Tweener.SetEase(starTween, Ease.Linear)

	return starTween
end