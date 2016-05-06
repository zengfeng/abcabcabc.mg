RoleLevelPanel = class("RoleLevelPanel", BaseWindow)

function RoleLevelPanel:ctor(window)
	self.path = "module/Common/RoleLevelUpPanel"
	self.window = window
	self.oldPopulationNum = nil
	self.newPopulationNum = nil
	self.oldAttackNum = nil
	self.newAttackNum = nil
	self.oldDefenseNum = nil
	self.newDefenseNum = nil
	self.oldSpeedNum = nil
	self.newSpeedNum = nil
	
end

function RoleLevelPanel:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.back = self.transform:FindChild("Bg")
	self.roleLevel = self.transform:FindChild("Content/LevelInfo/Text"):GetComponent("Text")--当前主公等级
	self.content = self.transform:FindChild("Content")
	self.oldPopulationNum = self.content:FindChild("Population/OldNum"):GetComponent("Text")--升级前初始人口
	self.newPopulationNum = self.content:FindChild("Population/NewNum"):GetComponent("Text")--升级后初始人口
	self.oldAttackNum = self.content:FindChild("PropList/Attack/OldNum"):GetComponent("Text")--升级前攻击
	self.newAttackNum = self.content:FindChild("PropList/Attack/NewNum"):GetComponent("Text")--升级后攻击
	self.oldDefenseNum = self.content:FindChild("PropList/Defense/OldNum"):GetComponent("Text")--升级前募兵
	self.newDefenseNum = self.content:FindChild("PropList/Defense/NewNum"):GetComponent("Text")--升级后募兵
	self.oldSpeedNum = self.content:FindChild("PropList/Speed/OldNum"):GetComponent("Text")--升级前速度
	self.newSpeedNum = self.content:FindChild("PropList/Speed/NewNum"):GetComponent("Text")--升级后速度
	self.populationPanel = self.content:FindChild("Population")
	self.propListPanel = self.content:FindChild("PropList")

	local transformGuide = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	self.transform:SetParent(transformGuide, false)
	self.transformRect = self.transform:GetComponent("RectTransform")
	 self.isEnd = false
	self.transformRect.localScale = Vector3.New(1, 1,1) 
	self.transformRect.anchoredPosition = Vector2.New(0, 0)
	self.window:AddClick(self.transform.gameObject, handler(self, self.OnClickClose))
end

function RoleLevelPanel:ShowProp()
	
	self:Load()
	self.cardIds = {}
	local totalAtkValueOld, totalDefValueOld, totalSpValueOld = 
					BattleManager.GetTotalDisplayBattleProp(self.cardIds, nil, Role.level-1)
	local totalAtkValueNew, totalDefValueNew, totalSpValueNew = 
					BattleManager.GetTotalDisplayBattleProp(self.cardIds, nil, Role.level)
	self.oldHp = ConfigManager.exp:GetConfig(Role.level-1).initTroop
	self.newHp = ConfigManager.exp:GetConfig(Role.level).initTroop
	self.roleLevel.text = Role.level
	self.oldPopulationNum.text = self.oldHp
	self.oldAttackNum.text = math.floor(totalAtkValueOld)
	self.oldDefenseNum.text = math.floor(totalDefValueOld)
	self.oldSpeedNum.text = math.floor(totalSpValueOld)
	self.newPopulationNum.text = Lang.GradeAdd .. self.newHp - self.oldHp
	self.newAttackNum.text = Lang.GradeAdd .. math.floor(totalAtkValueNew) - math.floor(totalAtkValueOld)
	self.newDefenseNum.text = Lang.GradeAdd .. math.floor(totalDefValueNew) - math.floor(totalDefValueOld)
	self.newSpeedNum.text = Lang.GradeAdd .. math.floor(totalSpValueNew) - math.floor(totalSpValueOld)
	self.populationPanel.gameObject:SetActive(false)
	self.propListPanel.gameObject:SetActive(false)
	Sequence.Create(1, function ()
				self.isEnd = true
     			self.populationPanel.gameObject:SetActive(true)
				self.propListPanel.gameObject:SetActive(true)
				
    		end)
end

function RoleLevelPanel:OnClickClose()
	if self.isEnd == true then
		self.isEnd = false
		self.super.OnCloseWindow(self)
	end
end

