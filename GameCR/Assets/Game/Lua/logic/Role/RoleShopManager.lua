RoleShopManager = class("RoleShopManager", 
{
	allItems = nil,
	refreshTick = 999999,
	sendRefresh = false,
})

function RoleShopManager:ctor(shopProto)
	self:OnRefreshShop(shopProto)
	EventManager.AddEventListener(self, "S_RefreshShop_0x401", handler(self, self.OnRefreshShop), EventPriority.TOP_PRIORITY)
	EventManager.AddEventListener(self, "S_BuyShopItem_0x400", handler(self, self.OnBuyShopItem), EventPriority.TOP_PRIORITY)
end

function RoleShopManager:OnUpdate(delta)
	if self.refreshTick > 0 then
		self.refreshTick = self.refreshTick - delta
	elseif not self.sendRefresh then
		self.sendRefresh = true
		ShopProto.C_RefreshShop_0x401()
	end
end

function RoleShopManager:OnRefreshShop(msg)
	self.sendRefresh = false

	self.allItems = {}
	self.refreshTick = msg.next_refresh_ticks
	for i,v in ipairs(msg.sell_items) do
		local item = RoleShopItem.New(v)
		self.allItems[item.pos] = item
	end
end

function RoleShopManager:OnBuyShopItem(msg)
	self.allItems[msg.sell_item.pos] = RoleShopItem.New(msg.sell_item)
end