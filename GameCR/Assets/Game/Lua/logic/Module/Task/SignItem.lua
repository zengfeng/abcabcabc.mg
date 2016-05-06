SignItem = class("SignItem", 
{
})

function SignItem:ctor(transform, parent)
	self.parent = parent
	self.window = parent.window
	self.transform = transform
	self.item = self.transform:FindChild("Item")
	self.itemRect = self.transform:FindChild("Item"):GetComponent("RectTransform")
	self.isGetImage = self.transform:FindChild("IsGet")
	self.effectType = false
	self.isGet = false	
end

function SignItem:UpdateWith(itemId,itemCount,isSign)
	self.itemId = itemId
	self.itemCount = itemCount
	destroyChildren(self.item.transform)
	self.EffectRect = self.parent.signLightEffect:GetComponent("RectTransform")
	if self.itemId < 100000 then
		self.itemRect.localScale = Vector3.New(1.2, 1.2,1.2)
		local cardItem = ConfigManager.card:GetConfig(self.itemId)
		local card = ItemCardLevel.New(self.window)
		card:SetClickType(true)
		card:ShowRoleCardWithIdAndLevel(self.itemId,1, function()
			card:SetHeadIcon(HeadType.HeadIcon)
			card.transform:SetParent(self.item, false)
		end)
		card:ShowRoleCardName(cardItem.name)

	else 
		self.itemRect.localScale = Vector3.New(1, 1,1)
		local item = ItemCard.New()--货币物品
		item:SetCount(self.itemCount)		
		item:ShowWithCurrType(self.itemId, function()
			item.transform:SetParent(self.item, false)	
		end)
		item:SetIconImage()
	end
	if self.isGet == true then
		self.isGetImage.gameObject:SetActive(true)
	else
		self.isGetImage.gameObject:SetActive(false)
	end
	if isSign == true then
		if self.effectType == true then
			self.parent.signLightEffect:SetParent(self.transform, false)
			self.parent.signLightEffect.gameObject:SetActive(true)
			self.parent.signLightEffect.localPosition =  Vector3.New(0,0,0)
		end
	else
		self.parent.signLightEffect.gameObject:SetActive(false)
	end
		
end

function SignItem:SetIsGet(getType)--有无已领取
	self.isGet = getType
end

function SignItem:SetEffect(effectType)--是否可领取
	self.effectType = effectType
end