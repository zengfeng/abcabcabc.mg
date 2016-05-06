MainManager = {}
local this = MainManager
this.first = true
this.isArena = false
this.exitWarMenu = -1
this.exitWarMenuArg = nil
function this.Awake( ... )
end

function this.Start( ... )
	if this.first then
		if Role.newGuideStep <= 1 then
			BattleManager.StartTrain()
			return
		end
		this.first = false
		Coo.menuManager:OpenMenu(MenuType.Home, 0)
	else
		if this.exitWarMenu > 0 then
			--Coo.menuManager:OpenMenu(MenuType.Home, 0)
			Coo.menuManager:OpenMenu(this.exitWarMenu, this.exitWarMenuArg)
			this.exitWarMenu = -1
		else
			Coo.menuManager:Back(MenuType.WarScene, 2)
		end

	end
	Coo.soundManager:ChangeMusicBg("music_main_city")
end

function this.SetExitWarMenu(menuId, menuArg )
	this.exitWarMenu 			= menuId
	this.exitWarMenuArg 		= menuArg
end