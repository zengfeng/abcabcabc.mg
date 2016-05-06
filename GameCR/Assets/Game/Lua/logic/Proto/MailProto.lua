MailProto = class("MailProto", 
{
})

local this = MailProto
-- 监听
-----------------------
function MailProto.StoC( )	
	ProtoUtil.AddLuaProtoCallback("S_MailList_0x1000", this.S_MailList_0x1000, mail_pb.S_MailList_0x1000())
	ProtoUtil.AddLuaProtoCallback("S_GetMailAttach_0x1001", this.S_GetMailAttach_0x1001, mail_pb.S_GetMailAttach_0x1001())
	ProtoUtil.AddLuaProtoCallback("S_ReadNewMail_0x1002", this.S_ReadNewMail_0x1002, mail_pb.S_ReadNewMail_0x1002())
	ProtoUtil.AddLuaProtoCallback("S_DeleteMail_0x1003", this.S_DeleteMail_0x1003, mail_pb.S_DeleteMail_0x1003())
	ProtoUtil.AddLuaProtoCallback("S_MailStatusNotify_0x1005", this.S_MailStatusNotify_0x1005, mail_pb.S_MailStatusNotify_0x1005())
	
end

function MailProto.C_MailList_0x1000() --获取邮件信息
	local msg = mail_pb.C_MailList_0x1000()
	ProtoUtil.SendMsg(msg, 0x1000)
end

function MailProto.S_MailList_0x1000( msg ) 
	local mailInfo={}
	mailInfo=msg.mail_info
	
end

function MailProto.C_GetMailAttach_0x1001(mailId) --领取邮件附件物品
	local msg = mail_pb.C_GetMailAttach_0x1001()
	msg.mail_id = mailId
	ProtoUtil.SendMsg(msg, 0x1001)
end

function MailProto.S_GetMailAttach_0x1001( msg ) 
	
	
end

function MailProto.C_ReadNewMail_0x1002(mailId) --读取新邮件信息
	local msg = mail_pb.C_ReadNewMail_0x1002()
	msg.mail_id = mailId
	ProtoUtil.SendMsg(msg, 0x1002)
end

function MailProto.S_ReadNewMail_0x1002( msg ) 
	
	
end

function MailProto.C_DeleteMail_0x1003(mailId) --删除邮件信息
	local msg = mail_pb.C_DeleteMail_0x1003()
	msg.mail_id = mailId
	ProtoUtil.SendMsg(msg, 0x1002)
end

function MailProto.S_DeleteMail_0x1003( msg ) 
	
	
end

function MailProto.S_MailStatusNotify_0x1005( msg ) 
	Role.unreadMailCount = msg.unread_mail_count
	--print("=================: " .. Role.unreadMailCount)
end
this.StoC()

