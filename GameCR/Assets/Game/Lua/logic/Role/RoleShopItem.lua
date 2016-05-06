RoleShopItem = class("RoleShopItem", 
{
	pos = 0,
	itemId = 0,
	itemCount = 0,
	currencyType = 0,
	currencyCost = 0,
})

function RoleShopItem:ctor(protoShopItemInfo)
	self.pos = protoShopItemInfo.pos
	self.itemId = protoShopItemInfo.item_id
	self.itemCount = protoShopItemInfo.item_count
	self.currencyType = protoShopItemInfo.currency_type
	self.currencyCost = protoShopItemInfo.currency_cost
end
