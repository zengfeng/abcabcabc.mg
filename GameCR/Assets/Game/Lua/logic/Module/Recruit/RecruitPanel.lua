local this = definePanel("RecruitPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	chest1 = RecruitChest.New(transform:FindChild("Content/Chest1"), window)
	chest2 = RecruitChest.New(transform:FindChild("Content/Chest2"), window)
	chest3 = RecruitChest.New(transform:FindChild("Content/Chest3"), window)
end

function OnEnter()
	MainPanel.backCallback = OnClickClose

	local grade = Role.GetGrade()
	if grade.id == 0 then
		grade = ConfigManager.grade:GetConfig(1)
	end
	chest1:UpdateWithId(grade.shopChest1Id)
	chest2:UpdateWithId(grade.shopChest2Id)
	chest3:UpdateWithId(grade.shopChest3Id)
end

-----------------------
--  Function
-----------------------

function OnClickClose()
	window:Exit()
end