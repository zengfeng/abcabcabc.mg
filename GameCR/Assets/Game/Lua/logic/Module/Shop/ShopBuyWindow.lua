ShopBuyWindow = class("ShopBuyWindow", 
{
})

function ShopBuyWindow:ctor(transform, window)
	self.transform = transform
	self.window = window
	self.bg = transform:FindChild("Bg")
	self.itemName = self.transform:FindChild("Content/Bg/Title/Name"):GetComponent("Text")
	self.type1Quality = self.transform:FindChild("Content/Bg/Title/Brand"):GetComponent("MultiImage")
	self.itemCard = self.transform:FindChild("Content/Bg/CardBg/ItemCard")
	self.button = self.transform:FindChild("Content/Bg/Button")
	self.costText = self.transform:FindChild("Content/Bg/Button/Container/Text"):GetComponent("Text")
	self.costTextMul = self.transform:FindChild("Content/Bg/Button/Container/Text"):GetComponent("MultiColor")
	self.cost = self.transform:FindChild("Content/Bg/Button/Container/Icon"):GetComponent("MultiImage")
	self.infoBtn = self.transform:FindChild("Content/Bg/Info")
	self.pos = 0
	self.shopItem = nil
	self.itemId = 0

	self.transform.gameObject:SetActive(false)

	window:AddClick(self.button.gameObject, handler(self, self.OnClick))
	window:AddClick(self.bg.gameObject, handler(self, self.OnClickClose))
	window:AddClick(self.infoBtn.gameObject, handler(self, self.OnClickInfo))
end

function ShopBuyWindow:ShowWith(pos, itemId, itemCount, curType, curCost, name, showType, shopItem)
	self.shopItem = shopItem
	self.transform.gameObject:SetActive(true)
	self.infoBtn.gameObject:SetActive(false)

	destroyChildren(self.itemCard)
	if itemId ~= SpecialItemType.Coins then
		local card = ConfigManager.card:GetConfig(itemId)
		self.type1Quality:SetImageIndex(card.quality-1)
		self.type1Quality.gameObject:SetActive(true)
		self.infoBtn.gameObject:SetActive(true)
		self.itemName.text = card.name

		local roleCard = Role.cardManager:GetCard(itemId)
		local itemCardCollect = ItemCardCollect.New()
		local count = itemCount
		if roleCard then
			count = count + roleCard.count
		end

		itemCardCollect:SetInfo(count, 1)
		itemCardCollect:ShowWithId(itemId, function()
			itemCardCollect.transform:SetParent(self.itemCard, false)
			itemCardCollect.name.gameObject:SetActive(false)
		end)
	else
		self.itemName.text = name
		self.type1Quality:SetImageIndex(0)
		local itemCard = ItemCard.New()
		itemCard:SetCount(itemCount)
		itemCard:SetShowType(showType)
		itemCard:ShowWithCurrType(SpecialItemType.Coins, function()
			itemCard.transform:SetParent(self.itemCard, false)
		end)
	end
	self.itemId = itemId

	self.costTextMul:SetColorIndex(-1)
	if curType == SpecialItemType.Coins then
		self.cost:SetImageIndex(0)
		if Role.coins < curCost then
			self.costTextMul:SetColorIndex(0)
		end
	elseif curType == SpecialItemType.Money then
		self.cost:SetImageIndex(1)
		if Role.money < curCost then
			self.costTextMul:SetColorIndex(0)
		end
	end
	self.costText.text = curCost
	self.pos = pos

	if self.itemId == 100000 then
		ShopPanel.flyCoinParent = self.itemCard
		ShopPanel.flyCoinNum = itemCount
	end
end

function ShopBuyWindow:OnClick()
	ShopProto.C_BuyShopItem_0x400(self.pos)
	self:OnClickClose()
end

function ShopBuyWindow:OnClickInfo()
	Coo.menuManager:OpenMenuBack(MenuType.CardInfo, self.window.menuId, {self.itemId, true})
end

function ShopBuyWindow:OnClickClose()
	self.transform.gameObject:SetActive(false)
	if self.shopItem then
		self.shopItem:Flip(false)
	end
end