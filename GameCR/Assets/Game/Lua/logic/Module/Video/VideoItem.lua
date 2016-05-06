VideoItem = class("VideoItem", 
{
})

 function VideoItem:ctor(transform, parent)
	--己方
	self.parent = parent
	self.window = self.parent.window
	self.selfPanel = transform:FindChild("Content/SelfPanel/Bg_3")
	self.roleNameSelf = self.selfPanel:FindChild("Self/RoleName"):GetComponent("Text")
	self.unionNameSelf = self.selfPanel:FindChild("Self/UnionName"):GetComponent("Text")
	self.rankNumSelf = self.selfPanel:FindChild("Self/RankNum"):GetComponent("Text")
	self.watchNum = self.selfPanel:FindChild("Self/WatchNum/Num"):GetComponent("Text")
	self.cardListSelf = self.selfPanel:FindChild("Self/SelfCardList")
	--敌方
	self.enemyPanel = transform:FindChild("Content/EnemyPanel/Bg_4")
	self.roleNameEnemy = self.enemyPanel:FindChild("Enemy/RoleName"):GetComponent("Text")
	self.unionNameEnemy = self.enemyPanel:FindChild("Enemy/UnionName"):GetComponent("Text")
	self.rankNumEnemy = self.enemyPanel:FindChild("Enemy/RankNum"):GetComponent("Text")
	self.cardListEnemy = self.enemyPanel:FindChild("Enemy/EnemyCardList")
	self.watchButton = self.enemyPanel:FindChild("Enemy/WatchButton")--观看按钮
	--比分信息
	self.vsPanel = transform:FindChild("Content/VSInfoPanel")
	self.time = self.vsPanel:FindChild("VSInfo/Time"):GetComponent("Text")
	self.newVideo = self.vsPanel:FindChild("VSInfo/NewVideo")
	self.oldVideo = self.vsPanel:FindChild("VSInfo/OldVideo")
	self.window:AddClick(self.watchButton.gameObject, handler(self, self.OnClickWatchButton))
 end

 function VideoItem:UpdateWith(fightAllInfo)
 	--print("精选视频")
 	self.fightAllInfo = fightAllInfo
 	self.shareRoleId = self.fightAllInfo.share_roleId--分享者
	self.fightInfo = self.fightAllInfo.video --分享的视频信息
	self.fightRolesInfo = {}
	self.fightRolesInfo = self.fightInfo.fight_roles
	for k,v in ipairs(self.fightRolesInfo) do
		if v.role_info.roleId == self.shareRoleId then   --己方
			self.roleNameSelf.text = v.role_info.name
			self.unionNameSelf.text = Lang.UnionNull	--无公会
			self.rankNumSelf.text = string.format(Lang.GradeNum, v.rank)
			local battleCards = v.battle_info.battle_cards
			self:ShowRoleCards(battleCards,self.cardListSelf)
		else           
			self.roleNameEnemy.text = v.role_info.name --敌方
			self.unionNameEnemy.text = Lang.UnionNull	--无公会
			self.rankNumEnemy.text = string.format(Lang.GradeNum, v.rank)
			local battleCards = v.battle_info.battle_cards
			self:ShowRoleCards(battleCards,self.cardListEnemy)									
		end
	end
	self.watchNum.text = self.fightInfo.view_count
	self.time.text = DateTimeUtils.DateStringFromNow(self.fightInfo.create_time)
	self.newVideo.gameObject:SetActive(false)
	self.oldVideo.gameObject:SetActive(false)--暂时都为新视频
end

--出战卡组
function VideoItem:ShowRoleCards(battleCards,listParent)
	destroyChildren(listParent.transform)
	for i,v in ipairs(battleCards) do
		local card = ItemCardLevel.New(self.window)
		card:SetClickType(false)
		card:ShowRoleCardWithIdAndLevel(v.card_id,v.level, function()
			card.transform:SetParent(listParent.transform, false)
		end)
	end
end

function VideoItem:OnClickWatchButton()--观看
	VideoProto.C_ViewBattleVideo_0x552(2,self.fightInfo.uuid)
	BattleEndPanel.watchCallback = function () self:OnWatch() end
	BattleEndPanel.clickCallback = function () MainManager.SetExitWarMenu(MenuType.Video, 1) end--用来观看后回到日志面板
	MainManager.SetExitWarMenu(MenuType.Video, nil)--用来观看后回到视频面板
	self:OnWatch()

end

function VideoItem:OnWatch()--观看
	if type(self.fightInfo) == "table" then
		local msg = video_pb.S_GetEliteVideoList_0x551()
		table.insert(msg.share_videos, self.fightAllInfo)
    	local data = msg:SerializeToString()
		War.Start(data, Role.roleId, true)
	else
		War.Start(self.fightInfo, Role.roleId)
	end
end