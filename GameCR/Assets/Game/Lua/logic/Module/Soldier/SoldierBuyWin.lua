SoldierBuyWin = class("SoldierBuyWin", 
{
})

function SoldierBuyWin:ctor(transform, window)
	self.transform = transform
	self.area = transform:FindChild("ClickArea")
	self.bg = transform:FindChild("Frame/Bg")
	self.name = self.bg:FindChild("NameBg/Text"):GetComponent("Text")
	self.head = self.bg:FindChild("Head"):GetComponent("Image")
	self.desc = self.bg:FindChild("Prop/Desc"):GetComponent("Text")
	self.desSoldier = self.bg:FindChild("DesSoldier"):GetComponent("Text")
	self.propAdd = self.bg:FindChild("Prop/Text"):GetComponent("Text")
	self.propIcon = self.bg:FindChild("Prop/Icon"):GetComponent("MultiImage")
	self.coinCost = self.bg:FindChild("CoinBuyButton/Text"):GetComponent("Text")
	self.coinCostMul = self.bg:FindChild("CoinBuyButton/Text"):GetComponent("MultiColor")
	self.coinButton = self.bg:FindChild("CoinBuyButton")
	self.coinButtonImg = self.bg:FindChild("CoinBuyButton"):GetComponent("ImageSetMaterial")

	self.soldierCfg = nil

	window:AddClick(self.coinButton.gameObject, handler(self, self.OnClickCoin))--铜钱购买
	window:AddClick(self.area.gameObject, handler(self, self.OnClickArena))
end

function SoldierBuyWin:Show(soldierId)
	local soldierCfg = ConfigManager.soldier:GetConfig(soldierId)
	self.soldierCfg = soldierCfg

	self.transform.gameObject:SetActive(true)
	UIUtils.LoadAvatarFullWithId(self.head, soldierCfg.id)

	self.name.text = soldierCfg.name

	if soldierCfg.initBattle > 0 then
		self.desc.text = Lang.PROP_SOLDIER_1
		self.propAdd.text = "+" .. soldierCfg:GetProp1(true)
		self.propIcon:SetImageIndex(0)
	elseif soldierCfg.initGainSoldier > 0 then
		self.desc.text = Lang.PROP_SOLDIER_2
		self.propAdd.text = "+" .. soldierCfg:GetProp2(true)
		self.propIcon:SetImageIndex(1)
	else
		self.desc.text = Lang.PROP_SOLDIER_3
		self.propAdd.text = "+" .. soldierCfg:GetProp3(true)
		self.propIcon:SetImageIndex(2)
	end
	if Role.coins > soldierCfg.coin then
		self.coinCostMul:SetColorIndex(-1)
		self.coinButtonImg:SetMaterial(1)
	else
		self.coinCostMul:SetColorIndex(0)
		self.coinButtonImg:SetMaterial(0)
	end
	self.coinCost.text = soldierCfg.coin
	self.desSoldier.text = soldierCfg.describe
end

function SoldierBuyWin:OnClickCoin()
	if Role.coins < self.soldierCfg.coin then
		CommonUtil.ShowMsg(Lang.COMMON_NOT_ENCOUGH_2)
		return
	end

	SoldierProto.C_BuySoldier_0x650(self.soldierCfg.id, 1)
	self:OnClickArena()
end

function SoldierBuyWin:OnClickArena()
	self.transform.gameObject:SetActive(false)
end