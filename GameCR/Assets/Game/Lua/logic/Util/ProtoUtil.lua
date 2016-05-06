ProtoUtil = class("ProtoUtil")
ProtoUtil.ProtoText = ""

function ProtoUtil.AddLuaProtoCallback(proto, callback, msg)
	Coo.packetManager:AddLuaProtoCallback(proto, function(data)
    	msg:ParseFromString(data)
    	
    	local msgc = string.gsub(tostring(msg), "{", "[[")
    	msgc = string.gsub(tostring(msgc), "}", "]]")

        local logMsg = "network log (" .. proto ..") detail: S->C msg : \n" .. msgc
		Debugger.Log(logMsg)
        ProtoUtil.ProtoText = logMsg .. "\n"

    	local result = callback(msg)
    	if result == nil or result then
    		EventManager.DispatchEvent(proto, msg, proto)
    	end
	end)
end

function ProtoUtil.SendMsg(msg, protoNum, socketId)
    socketId = socketId or CC.Runtime.SocketId.Main
    
    local packetManager = Coo.packetManager
    local data = msg:SerializeToString()
    packetManager:SendMessage(socketId, protoNum, data)

    local msgc = string.gsub(tostring(msg), "{", "[[")
    msgc = string.gsub(tostring(msgc), "}", "]]")

    local logMsg = "network log detail: C->S msg : \n" .. msgc
    Debugger.Log(logMsg)
    ProtoUtil.ProtoText = logMsg .. "\n"
end

function ProtoUtil.CleanProtoText()
    ProtoUtil.ProtoText = {}
end