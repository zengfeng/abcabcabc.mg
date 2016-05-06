require "debug"

DebugUtil = {}

local prefixPath = "Game/Lua/"
local resetModule = 
{
	"logic/Util",
	"logic/Module",
}
local resetFile = 
{
	"logic/Core/BattleManager",
	"logic/Core/GuideManager",
	"logic/Core/functions",
	"logic/Core/GlobalConst",
}

function DebugUtil.reloadMain()
	GuideManager.unforceIndicator:SetParent(GuideManager.mask, false)
	EventManager.CleanAll()
	DebugUtil.resetAllModule()
	MainManager.first = true
	DebugUtil.HomePanelParam = 1
	DebugUtil.HomePanelBtn = true
	Coo.menuManager.forceDestroyAll = true
	Timer.StopGroup(TimerGroup.UI)
	GuideManager.Init()
	-- Coo.menuManager:CloseAll()
	-- Coo.menuManager.forceDestroyAll = false
	-- Coo.menuManager:LuaOpenMenuPreInstance(MenuType.MainUI, DebugUtil, BlankFunction)
	Coo.menuManager:OpenMenu(MenuType.MainScene)
end

function DebugUtil.resetAllModule()
	for k,v in pairs(resetModule) do
		DebugUtil.resetModuleByPath(v)
	end
	
	for k,v in pairs(resetFile) do
		package.loaded[v] = nil
		require(v)
	end
end

function DebugUtil.resetModuleByPath(modulePath)
	function recur(path)
		local paths = PathUtil.FindDirectory(path)
		for i=0,paths.Length-1 do
			if StringUtil.IsDirectory(paths[i]) then
				recur(string.match(paths[i], ".*("..prefixPath..".+)$"))
			else
				local ext = StringUtil.GetExt(paths[i])
				if ext == "lua" then
					local relapath = string.match(paths[i], ".*"..prefixPath.."(.+)$")
					local noext = StringUtil.RemoveExt(relapath)
					package.loaded[noext] = nil
					require(noext)
				end
			end
		end
	end
	recur(prefixPath .. modulePath)
end