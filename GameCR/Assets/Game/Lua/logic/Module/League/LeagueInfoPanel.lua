local this = definePanel("LeagueInfoPanel")
-----------------------
--  LuaBehaviour
-----------------------

function Start()
	
end

function OnEnter()
	MainPanel.backCallback = OnClickClose
	if parameter == nil then
		return
	end
	leagueInfo = nil
	for k,v in pairs(parameter) do 
		leagueInfo = v
		break
	end
	print("====: " .. tostring(leagueInfo))
	
end

function OnExit( ... )
	-- body
	print("=======leagues info exit=====")
end

function OnClickClose()
	window:Back()
end



