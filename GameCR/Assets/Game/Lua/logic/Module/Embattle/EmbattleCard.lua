EmbattleCard = class("EmbattleCard", 
{
})

function EmbattleCard:ctor(transform, window, index)
	self.transform = transform
	self.cardTrans = transform:FindChild("Card")
	self.lock = transform:FindChild("Lock")
	self.window = window
	self.card = nil
	self.cardId = 0
	self.index = index
	self.originPos = self.cardTrans.anchoredPosition
	self.canvasGroup = self.cardTrans:GetComponent("CanvasGroup")
	self.mul = transform:GetComponent("MultiObject")
	self.isLock = false

	window:AddClick(self.transform.gameObject, handler(self, self.OnClick))
end

function EmbattleCard:OnEnter()
	self.isLock = false
	self.cardId = 0
	self.card = nil

	self.mul:SetObjectIndex(0)
	local expCfg = Role.GetExpConfig()
	if self.index <= expCfg.embattle then
		self.isLock = false
	else
		self.mul:SetObjectIndex(1)
		self.isLock = true
	end
end

function EmbattleCard:Arrange(cardId)
	if self.isLock then
		CommonUtil.ShowMsg(string.format(Lang.EMBATTLE_3, ConfigManager.exp:GetEmbattleMinLevel(self.index)))
		return false
	end
	self.mul:SetObjectIndex(2)

	destroyChildren(self.cardTrans)
	local card = ItemCardLevel.New(self.window)
	card:SetClickType(true)
	card:ShowRoleCardWithId(cardId, function()

		card.transform:SetParent(self.cardTrans, false)
	end)
	self.card = card
	self.cardId = cardId

	self.cardTrans.anchoredPosition = Vector2.New(self.originPos.x, self.originPos.y + 30)
	self.canvasGroup.alpha = 0

	GuideManager.CheckPoint(self, {[GuideType.Embattle] = {3}})

	Tweener.DOKill(self.cardTrans, true)
	local t = Tweener.DOAnchorPos(self.cardTrans, self.originPos, 0.7, false)
	Tweener.DOFade4(self.canvasGroup, 1, 0.7)
	Tweener.SetOnComplete(t, function()
		GuideManager.CheckPoint(self, {[GuideType.Embattle] = {4}})
	end)

	return true
end

function EmbattleCard:Remove()
	destroyChildren(self.cardTrans)
	self.card = nil
	self.cardId = 0
	self.mul:SetObjectIndex(0)
end

function EmbattleCard:IsArrange()
	return self.card ~= nil
end

function EmbattleCard:OnClick()
	if self.isLock then
		CommonUtil.ShowMsg(string.format(Lang.EMBATTLE_3, ConfigManager.exp:GetEmbattleMinLevel(self.index)))
		return
	end
	if self.cardId == 0 then
		for k,v in pairs(EmbattlePanel.cardBrands) do
			if not v.isEmbattle and v.isRoleCard then
				v:PlaySparking()
			end
		end
		return
	end

	if EmbattlePanel.cardBrands[self.cardId] then
		EmbattlePanel.cardBrands[self.cardId]:OnClickEmbattle()
	else
		EmbattlePanel.RemoveArrange(self.cardId)
	end
end