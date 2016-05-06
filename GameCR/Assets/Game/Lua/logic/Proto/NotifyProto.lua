NotifyProto = class("NotifyProto", 
{
})

local this = NotifyProto

-----------------------
-- 监听
-----------------------
function NotifyProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_RewardInfoNotify_0x150", this.S_RewardInfoNotify_0x150, hall_pb.S_RewardInfoNotify_0x150())
	ProtoUtil.AddLuaProtoCallback("S_RoleBaseInfoNotify_0x151", this.S_RoleBaseInfoNotify_0x151, hall_pb.S_RoleBaseInfoNotify_0x151())
end

-----------------------
-- 主公信息变化
-----------------------
function NotifyProto.S_RoleBaseInfoNotify_0x151( msg )
	local oldGrade = Role.GetGrade().id
	Role.level = msg.level
	Role.levelExp = msg.level_exp
	Role.coins = msg.coins
	Role.money = msg.money
	Role.prize = msg.prize
	local newGrade = Role.GetGrade().id
	--print("oldGrade=" .. oldGrade)
	--print("newGrade=" .. newGrade)
	if newGrade ~= oldGrade  then
		Role.gradeChange = true
		--print("段位变化")
	end
end

-----------------------
-- 卡牌奖励通知
-----------------------
function NotifyProto.S_RewardInfoNotify_0x150( msg )
	if msg.reward_cards then
		for i,v in ipairs(msg.reward_cards) do
			Role.cardManager:UpdateCard(v)
		end
	end
end

this.StoC( )