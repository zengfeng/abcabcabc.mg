local this = definePanel("ShopPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	restTime = transform:FindChild("Content/Time"):GetComponent("Text")
	list = transform:FindChild("Content/List/Content")
	timer = Timer.New(OnTimer, 1, -1, TimerGroup.UI):Start(true)
	buyWin = ShopBuyWindow.New(transform:FindChild("BuyWin"), window)
	curShopCardId = 0
	shopItemsList = {}
	EventManager.AddEventListener(this, "S_RefreshShop_0x401", OnRefreshShop)
	EventManager.AddEventListener(this, "S_BuyShopItem_0x400", OnBuyShopItem)
	flyCoinParent = nil 
	flyCoinNum = 0

end

function OnEnter()
	MainPanel.backCallback = OnClickClose

	UpdateShopItem()
end

-----------------------
--  Function
-----------------------

function UpdateShopItem()
	destroyChildren(list)
	shopItemsList = {}

	local shopItems = Role.shopManager.allItems
	for i,v in ipairs(shopItems) do
		local item = ShopItem.New(list, window)
		item:ShowWithRoleShopItem(v)
		table.insert(shopItemsList, item)
	end
end

function OnClickClose()
	buyWin:OnClickClose()
	window:Exit()
end

function OnTimer(delta)
	restTime.text = TimeUtil.ToDHMSS(Role.shopManager.refreshTick)
end

function OnRefreshShop(msg)
	UpdateShopItem()
end

function OnBuyShopItem(msg)
	if msg.sell_item.item_id == 100000 then
		MainPanel.PlayCurrencyAnimation(FlyType.Coin,flyCoinParent, flyCoinNum, 10)
	end
	if curShopCardId > 0 then
		local cardInfo = ConfigManager.card:GetConfig(curShopCardId)
		CommonUtil.ShowMsg(string.format(Lang.SHOP_1, cardInfo.name))
	end
	for k,v in pairs(shopItemsList) do
		v:OnRecv(msg)
	end

end