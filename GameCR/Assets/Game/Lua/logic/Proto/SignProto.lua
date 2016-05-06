SignProto = class("SignProto", 
{
})

local this = SignProto

function SignProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_GetSignInfo_0x1060", this.S_GetSignInfo_0x1060, sign_pb.S_GetSignInfo_0x1060())
	ProtoUtil.AddLuaProtoCallback("S_SignIn_0x1061", this.S_SignIn_0x1061, sign_pb.S_SignIn_0x1061())
	ProtoUtil.AddLuaProtoCallback("S_EnableSignNotify_0x1062", this.S_EnableSignNotify_0x1062, sign_pb.S_EnableSignNotify_0x1062())
end

-----------------------
--
-----------------------

function SignProto.C_GetSignInfo_0x1060()
	local msg = sign_pb.C_GetSignInfo_0x1060()
	ProtoUtil.SendMsg(msg, 0x1060)
end

function SignProto.S_GetSignInfo_0x1060(msg)
end

-----------------------
-- 领取当天物资
-----------------------

function SignProto.C_SignIn_0x1061( signDay)
	local msg = sign_pb.C_SignIn_0x1061()
	msg.sign_day = signDay
	ProtoUtil.SendMsg(msg, 0x1061)
end

function SignProto.S_SignIn_0x1061(msg)
	Role.signInfo = msg.sign_info
end
----------
--提示可领取
---------
function SignProto.S_EnableSignNotify_0x1062(msg)
	Role.signInfo.can_sign = true
end
this.StoC( )