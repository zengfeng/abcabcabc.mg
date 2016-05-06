local this = definePanel("SoldierPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	list = transform:FindChild("List")
	soldierItem = transform:FindChild("SoldierItem")
	buyWin = SoldierBuyWin.New(transform:FindChild("BuyWin"), window)

	soldierItem.gameObject:SetActive(false)

	EventManager.AddEventListener(this, "S_CardBattleStatusChange_0x202", OnProtoBack)
	EventManager.AddEventListener(this, "S_BuySoldier_0x650", OnProtoBack)
end

function OnEnter()
	MainPanel.backCallback = OnClickClose

	ReloadData()
end

-----------------------
--  Function
-----------------------

function ReloadData()
	destroyChildren(list)

	local soldiers = ConfigManager.soldier:GetAllConfigs()
	local sortList = {}
	for k,v in pairs(soldiers) do
		table.insert(sortList, v)
	end
	table.sort(sortList, function(a, b)
		return a.level < b.level
	end)

	for k,v in pairs(sortList) do
		local item = SoldierShopItem.New(newobject(soldierItem).transform, window)
		item:UpdateBySoldierCfg(v)
		item.transform:SetParent(list, false)
	end
end

function OnProtoBack(msg)
	ReloadData()
end

function OnClickClose()
	window:Back()
end