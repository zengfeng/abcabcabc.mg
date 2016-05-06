CardProto = class("CardProto", 
{
})

local this = CardProto

function CardProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_CardLevelUp_0x201", this.S_CardLevelUp_0x201, card_pb.S_CardLevelUp_0x201())
	ProtoUtil.AddLuaProtoCallback("S_CardBattleStatusChange_0x202", this.S_CardBattleStatusChange_0x202, card_pb.S_CardBattleStatusChange_0x202())
end

-----------------------
-- 升级卡片
-----------------------

function CardProto.C_CardLevelUp_0x201(cardId)
	local msg = card_pb.C_CardLevelUp_0x201()
	msg.card_id = cardId

	ProtoUtil.SendMsg(msg, 0x201)
end

function CardProto.S_CardLevelUp_0x201(msg)
	local card = Role.cardManager:GetCard(msg.card_info.card_id)
	card.count = msg.card_info.count
	card.level = msg.card_info.level
end

-----------------------
-- 卡片布阵
-----------------------

function CardProto.C_CardBattleStatusChange_0x202(cardIds, soldier)
	if not cardIds then
		cardIds = {}
		for k,v in pairs(Role.cardManager.battleCards) do
			table.insert(cardIds, v)
		end
	end

	if not soldier then
		soldier = Role.soldierManager.battleSoldier
	end

	local msg = card_pb.C_CardBattleStatusChange_0x202()
	for i,v in ipairs(cardIds) do
		table.insert(msg.battle_card_ids, v)
	end
	msg.battle_soldier =  soldier
	ProtoUtil.SendMsg(msg, 0x202)
end

function CardProto.S_CardBattleStatusChange_0x202(msg)
	Role.cardManager:UpdateBattleCards(msg.battle_info.battle_cards)
	Role.soldierManager:UpdateBattleSoldier(msg.battle_info.battle_soldier)
end

this.StoC( )