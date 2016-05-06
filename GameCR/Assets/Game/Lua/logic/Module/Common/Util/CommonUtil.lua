CommonUtil = class("CommonUtils")

--浮动框
function CommonUtil.ShowMsg(msg)
	if not msg then
		error("msg is nil")
		return
	end
	SysmsgManager.LuaExecute(0, {msg})
end