local this = definePanel("LeaguePanel")
require "logic/Proto/LeagueProto"
-----------------------
--  LuaBehaviour
-----------------------

function Start()
	leagueListAll = {}
	leagueList = transform:FindChild("Search/LeaguesFind/LeagueList"):GetComponent("TableView")--邮件
	leagueList:Setup(OnItemLeagueListUpdate, 0, false)

	local msg = hall_pb.ProtoLeagueInfo()
	msg.leagueId = 1
	msg.name = "dddd"
	msg.prize = 123456
	msg.member_count = 22
	table.insert(leagueListAll, msg)
	leagueList:ReloadData(#leagueListAll)

	activeGroup = transform:FindChild("Search/ActiveGroup"):GetComponent("ActiveGroup")--页签
	activeGroup:SetChangeCallback(OnChangeTab)

	leaguesFind = transform:FindChild("Search/LeaguesFind")
	leagueCreate = transform:FindChild("Search/LeagueCreate")
	leagueCreateItem = LeagueCreate.New(leagueCreate, window)

	EventManager.AddEventListener(this, "S_SearchLeague_0x701", LeageuInfoProto)--获取工会列表
	--LeagueProto.C_SearchLeague_0x701()
end

function OnEnter()
	MainPanel.backCallback = OnClickClose
	if parameter then
		return
	end
	activeGroup:SelectByUid(0)
	leagueCreateItem:init()
end

function OnExit( ... )
	-- body
	print("=======leagues exit=====")
end

function OnClickClose()
	window:Exit()
end


function LeageuInfoProto( msg )
	print("======LeageuInfoProto=====")
	leagueListAll = {}
	for k,v in pairs(msg.leagues) do
		if v.leagueId ~= nil then
			table.insert(leagueListAll, v)
		end	
	end

	leagueList:ReloadData(#leagueListAll)
end

function OnChangeTab(tabIdx)
	print("=============tabidx: " .. tabIdx)
	--ReloadData(uid+1)

	if tabIdx == 0 then --搜索
		leaguesFind.gameObject:SetActive(true)
		leagueCreate.gameObject:SetActive(false)
	else
		leaguesFind.gameObject:SetActive(false)
		leagueCreate.gameObject:SetActive(true)
	end
end

--公会信息
function OnLeagueClick( lengueId )
	-- body
	print("=========LeagueItem:OnClick=============")
	--Coo.menuManager:OpenMenu(MenuType.LeagueInfo)
	for k, v in pairs(leagueListAll) do 
		if lengueId == v.leagueId then
			Coo.menuManager:OpenMenuBack(MenuType.LeagueInfo, window.menuId, {v})
			break
		end
	end
end

------tableview
--公会列表
function OnItemLeagueListUpdate(lineTable, line, tableView)--邮件
	for k,v in pairs(lineTable) do
		local item = leagueListAll[tonumber(k)]
		local leagueItem = LeagueItem.New(v.transform, window)
		leagueItem:UpdateWith(item)
		--table.insert(roleMailItem, mailItem)
	end
end

