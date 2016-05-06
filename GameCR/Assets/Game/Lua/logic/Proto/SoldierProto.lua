SoldierProto = class("SoldierProto", 
{
})

local this = SoldierProto

function SoldierProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_BuySoldier_0x650", this.S_BuySoldier_0x650, soldier_pb.S_BuySoldier_0x650())
end

-----------------------
-- 购买
-----------------------

function SoldierProto.C_BuySoldier_0x650(soldierId, buyType)
	local msg = soldier_pb.C_BuySoldier_0x650()
	msg.soldierId = soldierId
	msg.buy_type = buyType

	ProtoUtil.SendMsg(msg, 0x650)
end

function SoldierProto.S_BuySoldier_0x650(msg)
	Role.soldierManager:UpdateAllSoldier(msg.soldiers)
end

this.StoC( )