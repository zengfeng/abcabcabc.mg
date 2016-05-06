GradekUpPanel = class("GradekUpPanel", BaseWindow)

function GradekUpPanel:ctor(window)
	self.path = "module/Common/GradekUpPanel"
	self.window = window
	self.roleGradeNow = nil
	self.cards = {}
	self:Load()
end

function GradekUpPanel:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.back = self.transform:FindChild("Bg")
	self.titleName = self.transform:FindChild("Content/Info/Title")
	self.title = self.transform:FindChild("Content/Info/Title"):GetComponent("Text")
	self.icon = self.transform:FindChild("Content/Info/Icon"):GetComponent("MultiImage")
	self.name = self.transform:FindChild("Content/Info/Name"):GetComponent("Text")
	self.prizeNum = self.transform:FindChild("Content/Info/PrizeInfo/Num"):GetComponent("Text")
	self.leftButton = self.transform:FindChild("Content/Info/LeftButton")
	self.rightButton = self.transform:FindChild("Content/Info/RightButton")
	self.cardList = self.transform:FindChild("Content/CardList/List")
	for pos = 0,7 do     
		local cardTrans = self.cardList:GetChild(pos)	
		local card = GradeCard.New(cardTrans,self)		
		table.insert(self.cards, card)
	end
	-- local transformGuide = Coo.menuManager:GetRoot(MenuLayerType.Layer_Guide)
	-- self.transform.parent = transformGuide
	self.transform:SetParent(MainPanel.transform, false)
	self.transformRect = self.transform:GetComponent("RectTransform") 
	self.transformRect.localScale = Vector3.New(1, 1,1) 
	self.transformRect.anchoredPosition = Vector2.New(0, 0)
	self.window:AddClick(self.back.gameObject, handler(self, self.OnClickClose))
	self.window:AddClick(self.leftButton.gameObject, handler(self, self.OnClickLeftButton))
	self.window:AddClick(self.rightButton.gameObject, handler(self, self.OnClickRightButton))
end

function GradekUpPanel:Show(titleType,roleGrade)
	self.roleGradeNow = roleGrade
	if self.roleGradeNow == Role.GetGrade().id then
		self.titleName.gameObject:SetActive(true)
		if titleType == GradeType.TitleNow then
			self.title.text = Lang.GradeNow
		else
			self.title.text = Lang.GradeReach
		end
	else
		self.titleName.gameObject:SetActive(false)
	end
	self.icon:SetImageIndex(self.roleGradeNow)
	if self.roleGradeNow > 0 then
		local nowGrade = ConfigManager.grade:GetConfig(self.roleGradeNow)
		self.name.text = nowGrade.name .. Lang.Grade
		self.leftButton.gameObject:SetActive(true)
		-- if self.roleGradeNow == 1 then
		-- 	--self.leftButton.gameObject:SetActive(false)
		-- 	self.prizeNum.text = 0 .. Lang.GradeAdd
		-- else
		-- 	--self.leftButton.gameObject:SetActive(true)
		-- 	local lastFrade = ConfigManager.grade:GetConfig(self.roleGradeNow-1)
		-- 	self.prizeNum.text = lastFrade.max .. Lang.GradeAdd
		-- end
		local lastFrade = ConfigManager.grade:GetConfig(self.roleGradeNow)
		self.prizeNum.text = lastFrade.min .. Lang.GradeAdd
		if self.roleGradeNow == 7 then
			self.rightButton.gameObject:SetActive(false)
		else
			self.rightButton.gameObject:SetActive(true)
		end
	else
		self.leftButton.gameObject:SetActive(false)
		self.prizeNum.text = 0 .. Lang.GradeAdd
		self.name.text = Lang.GradeTrain .. Lang.Grade
	end
	for k,v in pairs(ConfigManager.card:GetAllConfigs()) do
		if v.state ~= 0 then			
			for k_1,v_1 in ipairs(self.cards) do
				if v_1.gradeCardID == nil then
					if v.arena == self.roleGradeNow then
						v_1:Show(v.id)
						break 
					else
						v_1:Show(nil)
					end
				end
			end			
		end
	end
	
end

function GradekUpPanel:OnClickClose()
	self.super.OnCloseWindow(self)
end

function GradekUpPanel:OnClickLeftButton()
	for k,v in ipairs(self.cards) do
		v.gradeCardID = nil 
	end
	self:Show(GradeType.TitleNow,self.roleGradeNow-1)
end

function GradekUpPanel:OnClickRightButton()
	for k,v in ipairs(self.cards) do
		v.gradeCardID = nil 
	end
	self:Show(GradeType.TitleNow,self.roleGradeNow+1)
end

