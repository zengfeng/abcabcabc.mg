MailConfig = class("MailConfig", ConfigModel)
MailStruct = class("MailStruct",
{
	id = 0,
	functionId = 0,
	sender = "",
	time = 0,
	name = "",
	content = "",
	attachmentItem1Id = 0,
	attachmentItem1Num = 0,
	attachmentItem2Id = 0,
	attachmentItem2Num = 0,
	attachmentItem3Id = 0,
	attachmentItem3Num = 0,
	
})

function MailConfig:ctor()
	self.super.ctor(self, "Config/Mail")
	self.struct = MailStruct
end

function MailConfig:GetConfig(id)
	return self.super.GetConfig(self, id)
end