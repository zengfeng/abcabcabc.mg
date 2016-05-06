MsgWindow = class("MsgWindow", BaseWindow)

function MsgWindow:ctor(parent, window)
	self.path = "module/Common/MsgWindow"
	self.transform = nil
	self.window = window
	self.parent = parent
	self.callback = nil
	self.titleText = nil
	self.subTitleText = nil
	self.descText = nil
	self.yesCallback = nil
	self.noCallback = nil
	self.showButton = true
	self.msgType = 1
end

function MsgWindow:SetMsg(title, subtitle, desc)
	self.titleText = title
	self.subTitleText = subtitle
	self.descText = desc
end

function MsgWindow:SetButtonVisible(isVisible)
	self.showButton = isVisible
end

function MsgWindow:Show(yesCallback, noCallback)
	self.yesCallback = yesCallback
	self.noCallback = noCallback
	self.msgType = 1
	self:Load()
end

function MsgWindow:ShowOK(yesCallback)
	self.yesCallback = yesCallback
	self.msgType = 2
	self:Load()
end

function MsgWindow:OnLoad(name, obj)
	self.transform = newobject(obj).transform
	self.multi = self.transform:FindChild("Bg"):GetComponent("MultiObject")
	self.title = self.transform:FindChild("Bg/Title/Text"):GetComponent("Text")
	self.subTitle = self.transform:FindChild("Bg/SubTitle/Text"):GetComponent("Text")
	self.desc = self.transform:FindChild("Bg/Desc/Text"):GetComponent("Text")
	self.buttonNo = self.transform:FindChild("Bg/YesNo/ButtonNo")
	self.buttonYes = self.transform:FindChild("Bg/YesNo/ButtonYes")
	self.buttonOK = self.transform:FindChild("Bg/OK/ButtonYes")

	if self.titleText then
		self.title.text = self.titleText
	end

	if self.subTitleText then
		self.subTitle.text = self.subTitleText
	end

	if self.descText then
		self.desc.text = self.descText
	end

	self.transform.anchoredPosition = Vector2.New(0, 0)
	self.transform:SetParent(self.parent, false)

	self.buttonNo.gameObject:SetActive(self.showButton)
	self.buttonYes.gameObject:SetActive(self.showButton)

	if self.window then
		self.window:AddClick(self.buttonYes.gameObject, handler(self, self.OnClickYes))
		self.window:AddClick(self.buttonNo.gameObject, handler(self, self.OnClickNo))
		self.window:AddClick(self.buttonOK.gameObject, handler(self, self.OnClickYes))
	else
		self.buttonYes:GetComponent("Button").onClick:AddListener(handler(self, self.OnClickYes))
		self.buttonNo:GetComponent("Button").onClick:AddListener(handler(self, self.OnClickNo))
		self.buttonOK:GetComponent("Button").onClick:AddListener(handler(self, self.OnClickYes))
	end

	if self.msgType == 1 then
		self.multi:SetObjectIndex(0)
	elseif self.msgType == 2 then
		self.multi:SetObjectIndex(1)
	end
end

function MsgWindow:OnClickYes()
	if self.yesCallback then
		self.yesCallback()
	end

	self.super.OnCloseWindow(self)
end

function MsgWindow:OnClickNo()
	if self.noCallback then
		self.noCallback()
	end

	self.super.OnCloseWindow(self)
end