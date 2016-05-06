FightItem = class("FightItem", 
{
})

function FightItem:ctor(transform, parent)
	self.parent = parent
	self.window = self.parent.window
	--己方
	self.roleNameSelf = transform:FindChild("Self/RoleName"):GetComponent("Text")
	self.unionNameSelf = transform:FindChild("Self/UnionName"):GetComponent("Text")
	self.prizeNumSelf = transform:FindChild("Self/PrizeNum/Num"):GetComponent("Text")
	self.prizeNumAddSelf = transform:FindChild("Self/PrizeAddNum/Num"):GetComponent("Text")
	self.cardListSelf = transform:FindChild("Self/SelfCardList")
	--敌方
	self.roleNameEnemy = transform:FindChild("Enemy/RoleName"):GetComponent("Text")
	self.unionNameEnemy = transform:FindChild("Enemy/UnionName"):GetComponent("Text")
	self.prizeNumEnemy = transform:FindChild("Enemy/PrizeNum/Num"):GetComponent("Text")
	self.cardListEnemy = transform:FindChild("Enemy/EnemyCardList")
	self.shareButton = transform:FindChild("Enemy/ShareButton")--分享按钮
	self.shareButtonImage = transform:FindChild("Enemy/ShareButton"):GetComponent("ImageSetMaterial")
	self.watchButton = transform:FindChild("Enemy/WatchButton")--观看按钮
	--比分信息
	self.scoreSelf = transform:FindChild("VSInfo/ScoreInfo/SelfScore"):GetComponent("Text")
	self.scoreEnemy = transform:FindChild("VSInfo/ScoreInfo/EnemyScore"):GetComponent("Text")
	self.time = transform:FindChild("VSInfo/Time"):GetComponent("Text")
	self.win = transform:FindChild("VSInfo/Win")
	self.lost = transform:FindChild("VSInfo/Lost")
	self.draw = transform:FindChild("VSInfo/Draw")--平局

	self.shareButtonImage:SetMaterial(0)
	self.window:AddClick(self.shareButton.gameObject, handler(self, self.OnClickShareButton))
	self.window:AddClick(self.watchButton.gameObject, handler(self, self.OnClickWatchButton))
end

function FightItem:UpdateWith(fightInfo)
	self.fightInfo = fightInfo
	self.fightRolesInfo = {}
	self.fightRolesInfo = listToTable(self.fightInfo.fight_roles)
	for k,v in ipairs(self.fightRolesInfo) do
		if v.role_info.roleId == Role.roleId then   --己方
			self.unionNameSelf.text = Lang.UnionNull	--无公会
			self.prizeNumSelf.text = v.role_info.prize
			if v.change_prize > 0 then
				self.prizeNumAddSelf.text = Lang.GradeAdd .. v.change_prize
			else
				self.prizeNumAddSelf.text = v.change_prize
			end
			local battleCards = listToTable(v.battle_info.battle_cards)
			self:ShowRoleCards(battleCards,self.cardListSelf)
			self.scoreSelf.text = v.final_house
			if v.end_type == 0 then
			  	self.win.gameObject:SetActive(false)
			 	self.lost.gameObject:SetActive(true)
			 	self.draw.gameObject:SetActive(false)
			elseif v.end_type == 1 then
				self.win.gameObject:SetActive(false)
			  	self.lost.gameObject:SetActive(false)
			  	self.draw.gameObject:SetActive(true)
			elseif v.end_type == 2 then
				self.win.gameObject:SetActive(true)
			  	self.lost.gameObject:SetActive(false)
			  	self.draw.gameObject:SetActive(false)
			end
		else           
			self.roleNameEnemy.text = v.role_info.name --敌方
			self.unionNameEnemy.text = Lang.UnionNull	--无公会
			self.prizeNumEnemy.text = v.role_info.prize
			local battleCards = listToTable(v.battle_info.battle_cards)
			self:ShowRoleCards(battleCards,self.cardListEnemy)	
			self.scoreEnemy.text = v.final_house								
		end
		
	end
	self.time.text = DateTimeUtils.DateStringFromNow(self.fightInfo.create_time)

	self.shareButtonImage:SetMaterial(1)
end

--出战卡组
function FightItem:ShowRoleCards(battleCards,listParent)
	destroyChildren(listParent.transform)
	for i,v in ipairs(battleCards) do
		local card = ItemCardLevel.New(self.window)
		card:SetClickType(false)
		card:ShowRoleCardWithIdAndLevel(v.card_id,v.level, function()
			--card:SetParent(self.parent)
			card.transform:SetParent(listParent.transform, false)
		end)
	end
end
function FightItem:OnClickShareButton()--分享
	print("分享")
	CommonUtil.ShowMsg("暂未开放")
end

function FightItem:OnClickWatchButton()--观看
	VideoProto.C_ViewSelfVideo_0x553()--给服务器统计本地观看次数
	BattleEndPanel.watchCallback = function () War.Start(self.fightInfo, Role.roleId) end
	BattleEndPanel.clickCallback = function () MainManager.SetExitWarMenu(MenuType.Task, 1) end--用来观看后回到日志面板
	MainManager.SetExitWarMenu(MenuType.Task, 1)
	War.Start(self.fightInfo, Role.roleId)
	
end

