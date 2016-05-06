SoldierShopItem = class("SoldierShopItem", 
{
})

function SoldierShopItem:ctor(transform, window)
	self.transform = transform
	self.head = transform:FindChild("Head"):GetComponent("Image")
	self.propIcon = transform:FindChild("Prop/Icon"):GetComponent("MultiImage")
	self.propAdd = transform:FindChild("Prop/Text"):GetComponent("Text")
	self.propAddMul = transform:FindChild("Prop/Text"):GetComponent("MultiColor")
	self.name = transform:FindChild("Title/Name"):GetComponent("Text")
	self.isEmbattle = transform:FindChild("IsEmbattle")
	self.multiImg = transform:GetComponent("ImageSetMaterial")
	self.gradeDesc = transform:FindChild("Grade"):GetComponent("Text")

	self.gradeDescText = self.gradeDesc.text

	self.soldierCfg = nil

	transform.gameObject:SetActive(true)

	window:AddClick(transform.gameObject, handler(self, self.OnClick))
end

function SoldierShopItem:UpdateBySoldierCfg(soldierCfg)
	soldierCfg = soldierCfg--[type:SoldierStruct]
	self.soldierCfg = soldierCfg

	UIUtils.LoadAvatarFullWithId(self.head, soldierCfg.avatarId)

	if soldierCfg.initBattle > 0 then
		self.propIcon:SetImageIndex(0)
		self.propAdd.text = "+" .. soldierCfg:GetProp1(true)
	elseif soldierCfg.initGainSoldier > 0 then
		self.propIcon:SetImageIndex(1)
		self.propAdd.text = "+" .. soldierCfg:GetProp2(true)
	else
		self.propIcon:SetImageIndex(2)
		self.propAdd.text = "+" .. soldierCfg:GetProp3(true)
	end

	self.name.text = soldierCfg.name

	if soldierCfg.id == Role.soldierManager.battleSoldier then
		self.isEmbattle.gameObject:SetActive(true)
		self.propAddMul:SetColorIndex(-1)
		self.multiImg:SetMaterial(1)
	else
		self.isEmbattle.gameObject:SetActive(false)
		if Role.soldierManager.allSoldier[soldierCfg.id] then
			self.propAddMul:SetColorIndex(-1)
			self.multiImg:SetMaterial(1)
		else
			self.propAddMul:SetColorIndex(0)
			self.multiImg:SetMaterial(0)
		end
	end

	if Role.level < soldierCfg.level then
		self.gradeDesc.gameObject:SetActive(true)
		self.gradeDesc.text = string.format(self.gradeDescText, soldierCfg.level)
	else
		self.gradeDesc.gameObject:SetActive(false)
	end
end

function SoldierShopItem:OnClick()
	if Role.soldierManager.battleSoldier == self.soldierCfg.id then
	elseif Role.soldierManager.allSoldier[self.soldierCfg.id] then
		CardProto.C_CardBattleStatusChange_0x202(nil, self.soldierCfg.id)
	else
		if Role.level < self.soldierCfg.level then
			CommonUtil.ShowMsg(string.format(Lang.SOLDIER_1, self.soldierCfg.level))
			return
		end
		SoldierPanel.buyWin:Show(self.soldierCfg.id)
	end
end