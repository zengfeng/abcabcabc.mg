LeagueItem = class("LeagueItem", 
{
})

function LeagueItem:ctor(transform, window)
	self.luagueName = transform:FindChild("Bg/LuagueName"):GetComponent("Text")--联盟名字
	self.leagueDes = transform:FindChild("Bg/LeagueDes"):GetComponent("Text")--联盟人数描述
	self.leagueIcon = transform:FindChild("Bg/Icon"):GetComponent("Image")--公会图标
	self.score = transform:FindChild("Bg/Image/Number"):GetComponent("Text")--数字
	self.leagueId = 0
	self.bg = transform:FindChild("Bg")
	window:AddClick(self.bg.gameObject, handler(self, self.OnClick))

end
	-- optional int32 leagueId = 1;
	-- optional string name = 2;
	-- optional int32 icon = 3;
	-- optional int32 prize = 4;
	-- optional int32 member_count = 5;
	-- optional string description = 6;
	-- optional int32 type = 7;  // 类型: 1.允许任何人  2.批准可加入  3.不可加入
	-- optional int32 need_prize = 8;
	-- optional int32 location = 9;
	-- optional int32 donate_card_weekly = 10;
	-- repeated ProtoRoleBaseInfo members = 11;
function LeagueItem:UpdateWith(leaugeInfo)
	self.leagueId = leaugeInfo.leagueId
	self.luagueName.text = leaugeInfo.name
	self.score.text = string.format("%d", leaugeInfo.prize)
	self.leagueDes.text = string.format(Lang.LeagueCountDes, leaugeInfo.member_count)
end

function LeagueItem:OnClick()
	LeaguePanel.OnLeagueClick(self.leagueId)
end
