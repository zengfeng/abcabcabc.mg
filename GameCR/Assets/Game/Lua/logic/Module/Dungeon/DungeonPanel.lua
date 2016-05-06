local this = definePanel("DungeonPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	dungeonSelect = DungeonSelect.New(transform:FindChild("DungeonSelect"), window)
	dungeonInfo = DungeonInfo.New(transform:FindChild("DungeonInfo"), window)
	mulObj = transform:GetComponent("MultiObject")
end

function OnEnter()
	dungeonSelect:OnEnter()

	GuideManager.NonLineCheckPoint(dungeonSelect, {[GuideType.Dungeon] = {2}})
	if not parameter then
		ShowDungeonSelect(parameter)
	else
		local roleStage = Role.dungeonManager:GetRoleDungeonStage(dungeonInfo.dungeonStageId)
		local index = dungeonInfo.stageIndex
		if roleStage and roleStage:GetLastStage() > 0 and dungeonInfo.isNewStage then
			index = roleStage:GetLastStage()
		end
		ShowDungeonInfo(dungeonInfo.dungeonId, dungeonInfo.hardId, dungeonInfo.dungeonStageIndex, index)
	end
end

-----------------------
--  Function
-----------------------

function ShowDungeonSelect()
	mulObj:SetObjectIndex(0)
	MainPanel.SetState(1)
end

function ShowDungeonInfo(dungeonId, hardId, dungeonIndex, index)
	mulObj:SetObjectIndex(1)
	MainPanel.SetState(4)
	dungeonInfo:SelectDungeon(dungeonId, hardId, dungeonIndex, index)
end