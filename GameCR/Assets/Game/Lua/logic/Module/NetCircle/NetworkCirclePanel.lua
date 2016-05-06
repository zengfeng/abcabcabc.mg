local this = definePanel("NetworkCirclePanel")

-----------------------	
--  LuaBehaviour
-----------------------

isInit = false

function Awake(_gameObject)
	gameObject = _gameObject
	window = gameObject:GetComponent("LuaWindow")
end

function Start()
	if not isInit then
		isInit = true
		Coo.packetManager.socketManager:AddLuaReconnectCallback(ReconectCallback)
	end
end

-----------------------
--  Module
-----------------------

function SetParameter(parameter)
end

function DestroyModule()
end

-----------------------
--  Function
-----------------------

function ReconectCallback(sid)
	window:Exit()
end