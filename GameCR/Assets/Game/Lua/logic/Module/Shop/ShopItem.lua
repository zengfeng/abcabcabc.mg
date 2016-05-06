ShopItem = class("ShopItem", 
{
})

function ShopItem:ctor(parent, window)
	self.parent = parent
	self.window = window
	self.pos = 0
	self.itemId = 0
	self.itemCount = 0
	self.curType = 1
	self.curCost = 0
	self.callback = nil
end

function ShopItem:Load()
	Coo.assetManager:LuaLoad(self, "module/Shop/ShopItem", self.OnLoad)
end

function ShopItem:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.itemName = self.transform:FindChild("BgSlot/Bg/Title"):GetComponent("MultiObject")
	self.type1Quality = self.transform:FindChild("BgSlot/Bg/Title/Brand"):GetComponent("MultiImage")
	self.type1Name = self.transform:FindChild("BgSlot/Bg/Title/Brand/Name"):GetComponent("Text")
	self.type2Mul = self.transform:FindChild("BgSlot/Bg/Title/Money"):GetComponent("MultiObject")
	self.itemCard = self.transform:FindChild("BgSlot/Bg/CardBg/ItemCard")
	self.cost = self.transform:FindChild("BgSlot/Bg/Cost"):GetComponent("MultiImage")
	self.costText = self.transform:FindChild("BgSlot/Bg/Cost/Text"):GetComponent("Text")
	self.costTextMul = self.transform:FindChild("BgSlot/Bg/Cost/Text"):GetComponent("MultiColor")
	self.bgBtn = self.transform:FindChild("BgSlot")
	self.quest = self.transform:FindChild("QuestSlot")
	self.transform:SetParent(self.parent, false)

	self.name = ""

	self.window:AddClick(self.bgBtn.gameObject, handler(self, self.OnClick))
	-- EventManager.AddEventListener(self, "S_BuyShopItem_0x400", handler(self, self.OnRecv))

	self:UpdateInfo()

	if self.callback then
		self.callback()
	end
end

function ShopItem:SetRoleShopItem(roleShopItem)
end

function ShopItem:SetProto(shopItemProto)
	self.pos = shopItemProto.pos
	self.itemId = shopItemProto.item_id
	self.itemCount = shopItemProto.item_count
	self.curType = shopItemProto.currency_type
	self.curCost = shopItemProto.currency_cost
end

function ShopItem:UpdateInfo()
	if self.transform == nil then
		return
	end

	destroyChildren(self.itemCard)
	if self.itemId ~= SpecialItemType.Coins then
		local card = ConfigManager.card:GetConfig(self.itemId)
		self.itemName:SetObjectIndex(0)
		self.type1Quality:SetImageIndex(card.quality-1)
		self.type1Name.text = card.name

		local roleCard = Role.cardManager:GetCard(self.itemId)
		local itemCardCollect = ItemCardCollect.New()
		local count = self.itemCount
		local level = 1
		if roleCard then
			-- count = count + roleCard.count
			count = roleCard.count
			level = roleCard.level
		else
			count = 0
		end

		itemCardCollect:SetInfo(count, level)
		itemCardCollect:ShowWithId(self.itemId, function()
			itemCardCollect.transform:SetParent(self.itemCard, false)
			itemCardCollect.name.gameObject:SetActive(false)
		end)

		self.name = card.name
	else
		self.itemName:SetObjectIndex(1)
		self.type2Mul:SetObjectIndex(self.pos-4)
		local itemCard = ItemCard.New()
		itemCard:SetCount(self.itemCount)
		itemCard:SetShowType(self.pos-4)
		itemCard:ShowWithCurrType(SpecialItemType.Coins, function()
			itemCard.transform:SetParent(self.itemCard, false)
		end)

		self.name = self.type2Mul:GetCurObject():GetComponent("Text").text
	end

	self.costTextMul:SetColorIndex(-1)
	if self.curType == SpecialItemType.Coins then
		self.cost:SetImageIndex(0)
		if Role.coins < self.curCost then
			self.costTextMul:SetColorIndex(0)
		end
	elseif self.curType == SpecialItemType.Money then
		self.cost:SetImageIndex(1)
		if Role.money < self.curCost then
			self.costTextMul:SetColorIndex(0)
		end
	end
	self.costText.text = self.curCost
end

function ShopItem:ShowWithRoleShopItem(roleShopItem, callback)
	roleShopItem = roleShopItem --[type:RoleShopItem]
	self.pos = roleShopItem.pos
	self.itemId = roleShopItem.itemId
	self.itemCount = roleShopItem.itemCount
	self.curType = roleShopItem.currencyType
	self.curCost = roleShopItem.currencyCost
	self.callback = callback
	self:Load()
end

function ShopItem:OnRecv(msg)
	if msg.sell_item.pos ~= self.pos then
		return
	end

	self:SetProto(msg.sell_item)
	self:UpdateInfo()
end

function ShopItem:Flip(isEnter)
	if isEnter then
		Sequence.Create(
			Tweener.DORotate2(self.bgBtn, Vector3.New(0, 90, 0), 0.2, RotateMode.Fast),
			Tweener.DOVisible(self.bgBtn, false),
			Tweener.DOVisible(self.quest, true),
			Tweener.DORotate2(self.quest, Vector3.New(0, 0, 0), 0.2, RotateMode.Fast)
		)
	else
		Sequence.Create(
			Tweener.DORotate2(self.quest, Vector3.New(0, 90, 0), 0.2, RotateMode.Fast),
			Tweener.DOVisible(self.bgBtn, true),
			Tweener.DOVisible(self.quest, false),
			Tweener.DORotate2(self.bgBtn, Vector3.New(0, 0, 0), 0.2, RotateMode.Fast)
		)
	end
end

function ShopItem:OnClick()
	self:Flip(true)
	ShopPanel.buyWin:ShowWith(self.pos, self.itemId, self.itemCount, self.curType, self.curCost, self.name, self.pos-4, self)
	ShopPanel.curShopCardId = 0
	if self.itemId ~= SpecialItemType.Coins then
		ShopPanel.curShopCardId = self.itemId
	end
end