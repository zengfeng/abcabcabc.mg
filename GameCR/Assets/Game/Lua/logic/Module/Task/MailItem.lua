MailItem = class("MailItem", 
{
})

function MailItem:ctor(transform, window)
	self.transform = transform
	self.bg = self.transform:FindChild("Bg")
	self.readDesc = self.bg:FindChild("ReadDesc"):GetComponent("Text")--已读
	self.unReadDesc = self.bg:FindChild("UnReadDesc"):GetComponent("Text")--未读
	self.time = self.bg:FindChild("Time"):GetComponent("Text")--已读
	self.icon = self.bg:FindChild("Icon"):GetComponent("MultiImage")
	self.isAttach = self.bg:FindChild("IsAttach")--可领取
	self.roleMail = nil
	self.unShow = self.bg:FindChild("UnShow")--半透明黑底
	window:AddClick(self.bg.gameObject, handler(self, self.OnClick))
end

function MailItem:UpdateWith(roleMail)
	self.roleMail = roleMail
	local title = "";
	if self.roleMail.mail_type ~= 0 then --模板邮件
		local config = ConfigManager.mail:GetConfig(self.roleMail.mail_type)
		title = config.name
	else
		title = self.roleMail.title
	end
	self.unShow.gameObject:SetActive(false)
	if self.roleMail.is_read == true then--已读
		self.readDesc.gameObject:SetActive(true)
		self.unReadDesc.gameObject:SetActive(false)
		self.readDesc.text = title
		self.icon.imageIndex = 0
	else
		self.readDesc.gameObject:SetActive(false)--未读
		self.unReadDesc.gameObject:SetActive(true)
		self.unReadDesc.text = title
		self.icon.imageIndex = 1
	end
	
	self.isAttach.gameObject:SetActive(false)
	self.time.text = DateTimeUtils.DateStringFromNow(self.roleMail.create_time)--邮件创建时间
	self.time.text = self:formatDate(self.roleMail.create_time) --邮件创建时间
	UIUtils.ShowTip(self.bg, self.roleMail.is_read == false)--小红点
end

function MailItem:OnClick()

	TaskPanel.OpenMail(self.roleMail)
end

function MailItem:formatDate(seconds,dateformat)
	seconds = tonumber(seconds)
	dateformat = dateformat or "%m/%d"--年月日
	return os.date(dateformat, seconds)
end