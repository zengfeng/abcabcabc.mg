RoleCardManager = class("RoleCardManager",
{
	allCards = nil,
	battleCards = nil,
})

function RoleCardManager:ctor(cardsProto)
	self.allCards = {}
	for i,v in ipairs(cardsProto) do
		local card = RoleCard.New(v)
		self.allCards[card.cardId] = card
	end
end

function RoleCardManager:UpdateBattleCards(battleCards)
	self.battleCards = {}
	for i,v in ipairs(battleCards) do
		table.insert(self.battleCards, v.card_id)
	end
end

function RoleCardManager:UpdateCard(protoCardInfo)
	local card = RoleCard.New(protoCardInfo)
	local last = 0
	if self.allCards[card.cardId] then
		last = self.allCards[card.cardId].count
	else
		card.isNew = true
	end
	card.countDelta = card.count - last
	self.allCards[card.cardId] = card
end

function RoleCardManager:GetCard(id) --[return:RoleCard]
	return self.allCards[id]
end

function RoleCardManager:CanEmbattle()
	local expCfg = Role.GetExpConfig()
	return #self.battleCards < CardDataConst.EMBATTLE_MAX and table.getCount(self.allCards) > #self.battleCards and #self.battleCards < expCfg.embattle
end

function RoleCardManager:OnUpdate(delta)
end