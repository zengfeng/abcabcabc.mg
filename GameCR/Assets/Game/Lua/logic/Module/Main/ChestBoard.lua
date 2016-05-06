ChestBoard = class("ChestBoard", 
{
})

function ChestBoard:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.chestOnline = ChestOnline.New(self.transform:FindChild("ChestOnline"), window)
	self.chestArena = ChestArena.New(self.transform:FindChild("ChestArena"), window)
	self.chestStar = ChestStar.New(self.transform:FindChild("ChestStar"), window)
	self.timer = Timer.New(handler(self, self.OnUpdate), 1, -1, TimerGroup.UI):Start()

	EventManager.AddEventListener(self, "S_OpenChest_0x300", handler(self, self.OnRecv))
end

function ChestBoard:OnEnter()
	self.timer.running = true
	self.chestStar:OnEnter()
	self.chestArena:UpdateWith()
end

function ChestBoard:OnExit()
	self.timer.running = false
end

function ChestBoard:OnUpdate(delta)
	self.chestOnline:OnUpdate(delta)
	self.chestArena:OnUpdate(delta)
	self.chestStar:OnUpdate(delta)
end

function ChestBoard:OnRecv(msg)
end

function ChestBoard:OnDestroy( ... )
	self.timer:Stop()
end

-----------------------
--  ChestOnline
-----------------------

ChestOnline = class("ChestOnline")
function ChestOnline:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.button = transform:FindChild("Button")
	self.buttonBg = transform:FindChild("Button"):GetComponent("MultiImage")
	self.tip = transform:FindChild("Button/Tip"):GetComponent("MultiObject")
	self.time = transform:FindChild("Button/Tip/CanOpen/Time"):GetComponent("Text")

	window:AddClick(self.button.gameObject, handler(self, self.OnClick))

	self:UpdateWithRole()
end

function ChestOnline:UpdateWithRole()
	local mgr = Role.chestManager --[type:RoleChestManager]
	if mgr.onlineChestCount > 0 then
		self.tip:SetObjectIndex(1)
		self.buttonBg:SetImageIndex(1)
	else
		self.tip:SetObjectIndex(0)
		self.buttonBg:SetImageIndex(0)

		self.time.text = TimeUtil.ToDHMSS(mgr.nextOnlineChestTicks)
	end
end

function ChestOnline:OnUpdate(delta)
	self:UpdateWithRole()
end

function ChestOnline:OnClick()
	local mgr = Role.chestManager --[type:RoleChestManager]
	if mgr.onlineChestCount <= 0 then
		CommonUtil.ShowMsg(string.format(Lang.HOME_CHEST_1, self.time.text))
		return
	end

	local p = OpenChestParam.New()
	p.chestType = 1
	Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
end

-----------------------
--  ChestArena
-----------------------

ChestArena = class("ChestArena")
function ChestArena:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.chestList = { ChestArenaItem.New(transform:FindChild("Chest1"), window),
						ChestArenaItem.New(transform:FindChild("Chest2"), window),
						ChestArenaItem.New(transform:FindChild("Chest3"), window),
						ChestArenaItem.New(transform:FindChild("Chest4"), window)}

	self:UpdateWith()
end

function ChestArena:UpdateWith()
	local infos = Role.chestManager.dropChestInfo
	for k,v in pairs(infos) do
		local item = self.chestList[v.pos]
		if item then
			item:UpdateWith(v)
		end
	end
end

function ChestArena:OnUpdate(delta)
	for k,v in pairs(self.chestList) do
		v:OnUpdate(delta)
	end
end

-----------------------
--  ChestArenaItem
-----------------------

ChestArenaItem = class("ChestArenaItem")
function ChestArenaItem:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.button = transform:FindChild("Button"):GetComponent("MultiImage")
	self.tip = transform:FindChild("Button/Tip"):GetComponent("MultiObject")
	self.openTime = transform:FindChild("Button/Tip/CanOpen"):GetComponent("Text")
	self.waiting = transform:FindChild("Button/Tip/Waiting/Text"):GetComponent("Text")
	self.pop = transform:FindChild("Pop"):GetComponent("MultiObject")
	self.timePop = transform:FindChild("Pop/TimePop/Text"):GetComponent("Text")
	self.icon = ChestIcon.New(transform:FindChild("Button/IconNode/Icon"), transform:FindChild("Button/IconNode/Shadow"))
	self.iconNode = ChestIcon.New(transform:FindChild("Button/IconNode"))
	self.effect = transform:FindChild("Button/CurtainEffect")

	self.popCanvas = transform:FindChild("Pop"):GetComponent("CanvasGroup")
	self.tipCanvas = transform:FindChild("Button/Tip"):GetComponent("CanvasGroup")
	self.buttonImage = transform:FindChild("Button"):GetComponent("Image")

	self.dropChestInfo = nil
	self.isEnd = false --获得宝箱效果是否播放完
	self.isDrop = false --是否有宝箱掉落
	self.animCallback = nil
	window:AddClick(self.button.gameObject, handler(self, self.OnClick))
	EventManager.AddEventListener(self, "S_UnlockArenaChest_0x331", handler(self, self.OnUnlockArenaChest))
	EventManager.AddEventListener(self, "S_PreOpenArenaChest_0x332", handler(self, self.PreOpenArenaChest))
end

function ChestArenaItem:UpdateWith(dropChestInfo)
	local dropChestInfo = dropChestInfo--[type:RoleDropChestInfo]
	self.dropChestInfo = dropChestInfo
	self.icon:Animate(false)

	if dropChestInfo.status == 0 then --empty
		self.button.gameObject:SetActive(false)
		self.pop.gameObject:SetActive(false)
	else
		if dropChestInfo.status == 1 then --lock
			local chestType = ConfigManager.chest:GetChestTypeConfig(dropChestInfo.chestId)
			self.openTime.text = TimeUtil.ToDHMSS(chestType.time)
			self.tip:SetObjectIndex(0)
			self.pop:SetObjectIndex(0)
			self.button:SetImageIndex(0)
			self.effect.gameObject:SetActive(false)

			if Role.chestManager.unlockingPos < 0 then
				self.pop.gameObject:SetActive(true)
			else
				self.pop.gameObject:SetActive(false)
			end
			GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {1}})
			local drop = Role.chestManager:GetNewDrop(true)
			if drop and drop.pos == dropChestInfo.pos then
				self.isDrop = true
				self:PlayFlyAnim()
				Role.chestManager.newDropChestPos = 0
			end
		elseif dropChestInfo.status == 2 then --unlocking
			self.waiting.text = chestTimeToMoney(dropChestInfo.unlockTicks)
			self.tip:SetObjectIndex(1)
			self.pop:SetObjectIndex(1)
			self.button:SetImageIndex(1)
			self.effect.gameObject:SetActive(true)
			self.timePop.text = TimeUtil.ToDHMSS(dropChestInfo.unlockTicks)
		elseif dropChestInfo.status == 3 then --preopen
			self.tip:SetObjectIndex(2)
			self.pop:SetObjectIndex(0)
			self.button:SetImageIndex(2)
			self.icon:Animate(true)
			self.effect.gameObject:SetActive(false)
		end

		self.button.gameObject:SetActive(true)
		self.icon:SetStateById(dropChestInfo.chestId)
	end
end

function ChestArenaItem:PlayFlyAnim()
	local curPos = MiscLuaUtil.AnchoredPosNode1InNode2Local(HomePanel.arenaBtn, self.iconNode.transform)
	local oriPos = self.iconNode.transform.anchoredPosition
	local highPos = Vector2.New(oriPos.x + (curPos.x - oriPos.x)/2, curPos.y + 50)

	self.iconNode.transform.anchoredPosition = curPos

	local arr = {}
	local t = 0
	local tweener = Tweener.TweenTo(
		function()
			return t
		end, 
		function(val)
			t = val
		end, 1, 1)

	Tweener.SetEase(tweener, Ease.InCubic)
	Tweener.SetOnUpdate(tweener, function()
		self.iconNode.transform.anchoredPosition = UIUtils.Bezier(curPos, highPos, oriPos, t)
	end)

	table.insert(arr, tweener)

	tweener = Tweener.DOPunchAnchorPos(self.transform, Vector2.New(0, 20), 0.3, 20, 1, true)
	table.insert(arr, tweener)

	local spawn = {}
	self.buttonImage.color = Color.New(1, 1, 1, 0)
	tweener = Tweener.DOFade3(self.buttonImage, 1, 0.5)
	table.insert(spawn, tweener)

	self.popCanvas.alpha = 0
	tweener = Tweener.DOFade4(self.popCanvas, 1, 0.5)
	table.insert(spawn, tweener)

	self.tipCanvas.alpha = 0
	tweener = Tweener.DOFade4(self.tipCanvas, 1, 0.5)
	table.insert(spawn, tweener)

	table.insert(arr, spawn)
	table.insert(arr, function()
		self.isEnd = true 
	end)
	if self.animCallback then
		table.insert(arr, self.animCallback)
	end
	Sequence.CreateWithArray(arr)
end

function ChestArenaItem:OnUnlockArenaChest(msg)
	local cinf = Role.chestManager.dropChestInfo[self.dropChestInfo.pos]--[type:RoleDropChestInfo]
	self:UpdateWith(cinf)

	if cinf.status == 2 then
		GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {4}})
	end
end

function ChestArenaItem:PreOpenArenaChest(msg)
	local cinf = Role.chestManager.dropChestInfo[self.dropChestInfo.pos]--[type:RoleDropChestInfo]
	self:UpdateWith(cinf)

	if cinf.status == 3 then
		GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {11}}, true)
	end
end

function ChestArenaItem:OnClick()
	if self.isDrop == true and self.isEnd == false then
		return
	else
		local dropChestInfo = self.dropChestInfo--[type:RoleDropChestInfo]
		if dropChestInfo.status == 1 then --lock
			local win = ChestWindow.New(self.window)
			win:ShowByPos(dropChestInfo.pos)
		elseif dropChestInfo.status == 2 then --unlocking
			local win = ChestWindow.New(self.window)
			win:ShowByPos(dropChestInfo.pos)
		elseif dropChestInfo.status == 3 then --preopen
			local p = OpenChestParam.New()
			p.pos = dropChestInfo.pos
			p.chestType = 3
			p.chestId = dropChestInfo.chestId
			p.byMoney = false

			GuideManager.CheckPoint(self, {[GuideType.OpenChest] = {12}})
			Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
		end
		self.isEnd = false 
		self.isDrop = false
	end
		
end

function ChestArenaItem:OnUpdate(delta)
	local cinf = Role.chestManager.dropChestInfo[self.dropChestInfo.pos]--[type:RoleDropChestInfo]
	if cinf and cinf.status == 2 then
		self:UpdateWith(cinf)
	end
end

-----------------------
--  ChestStar
-----------------------

ChestStar = class("ChestStar")
function ChestStar:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.button = transform:FindChild("Button")
	self.buttonBg = transform:FindChild("Button"):GetComponent("MultiImage")
	self.tip = transform:FindChild("Button/Tip"):GetComponent("MultiObject")
	self.prog = transform:FindChild("Button/Tip/Waiting/Bg"):GetComponent("Slider")
	self.progText = transform:FindChild("Button/Tip/Waiting/Bg/Text"):GetComponent("Text")
	self.timeText = transform:FindChild("Button/Tip/Timing/Time"):GetComponent("Text")
	self.spark = transform:FindChild("Button/Tip/Waiting/Effect/Animator"):GetComponent("Animator")
	self.progStr = self.progText.text
	self.icon = ChestIcon.New(transform:FindChild("Button/Icon"))
	self.starIcon = transform:FindChild("Button/Tip/Waiting/Star")
	self.flyPos = transform:FindChild("Button/Tip/Waiting/Star/StarFlyPos")
	self.star1 = self.flyPos:FindChild("Star1")
	self.mayUpdate = true
	--self.icon:SetState(Role.GetGrade().id-1, false)
	self.starCount = Role.chestManager.starChestStarCount

	self.spark.gameObject:SetActive(false)

	window:AddClick(self.button.gameObject, handler(self, self.OnClick))
	EventManager.AddEventListener(self, "S_OpenChest_0x300", handler(self, self.OnOpenChest))
end

function ChestStar:OnEnter()
	self:OnOpenChest()
end

function ChestStar:OnClick()
	if Role.chestManager.starChestStarCount < self.prog.maxValue then
		CommonUtil.ShowMsg(Lang.HOME_CHEST_2)
		return
	end
	if Role.chestManager.nextStarChestTicks > 0 then
		CommonUtil.ShowMsg(Lang.HOME_CHEST_3)
		return
	end

	local p = OpenChestParam.New()
	p.chestType = 2
	Coo.menuManager:OpenMenu(MenuType.OpenChest, p)
end

function ChestStar:OnUpdate(delta)
	if not self.mayUpdate then
		return
	end

	-- self:OnOpenChest()
end

function ChestStar:OnOpenChest(msg)
	if Role.chestManager.nextStarChestTicks > 0 then
		self.timeText.text = TimeUtil.ToDHMSS(Role.chestManager.nextStarChestTicks)
		self.buttonBg:SetImageIndex(0)
		self.tip:SetObjectIndex(2)
	else
		self:UpdateChestStar(Role.chestManager.starChestStarCount)
		if Role.chestManager.starGain > 0 then
			self:FlyStar(Role.chestManager.starGain)
			Role.chestManager.starGain = 0
		end
	end
end

function ChestStar:UpdateChestStar(star)
	self.prog.value = star
	self.progText.text = string.format(self.progStr, star)
	self.starCount = star

	if star < self.prog.maxValue then
		self.buttonBg:SetImageIndex(0)
		self.tip:SetObjectIndex(0)
	else
		self.buttonBg:SetImageIndex(1)
		self.tip:SetObjectIndex(1)
	end
end

function ChestStar:FlyStar(count)
	local delta = count - self.flyPos.childCount
	if delta > 0 then
		for i=self.flyPos.childCount+1,self.flyPos.childCount+delta do
			local star = newobject(self.star1)
			star.transform:SetParent(self.star1.transform.parent, false)
			star.gameObject.name = "Star" .. i
		end
	end

	self:UpdateChestStar(self.starCount - count)
	self.mayUpdate = false

	local endPos = MiscLuaUtil.AnchoredPosNode1InNode2Local(self.starIcon, self.star1.parent)
	for i=1,self.flyPos.childCount do
		local star = self.flyPos:FindChild("Star" .. i)
		if i <= count then
			star.gameObject:SetActive(true)
			Tweener.DOKill(star, true)
			local range = 100
			star.anchoredPosition = Vector2.New(math.Random(-range, range), math.Random(-range, range))

			local spinTween = Tweener.DORotate2(star, Vector3.New(0, 0, 360), 0.5, RotateMode.FastBeyond360)
			Tweener.SetLoop(spinTween, 10)
			Tweener.SetEase(spinTween, Ease.Linear)

			local moveTween = Tweener.DOAnchorPos(star, endPos, 0.5, false)
			Tweener.SetDelay(moveTween, 0.5+0.2*i)
			Tweener.SetEase(moveTween, Ease.InExpo)
			Tweener.SetOnComplete(moveTween, function()
				self.spark.gameObject:SetActive(true)
				self.spark:SetTime(0)
				self.spark.speed = 1
				star.gameObject:SetActive(false)

				self:UpdateChestStar(self.starCount + 1)

				if i == self.flyPos.childCount then
					self.mayUpdate = true
					self.spark.gameObject:SetActive(false)
				end
			end)
		else
			star.gameObject:SetActive(false)
		end
	end
end
