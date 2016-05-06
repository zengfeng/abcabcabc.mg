local this = definePanel("RankPanel")


RankRoleInfo = class("RankRoleInfo")

function RankRoleInfo:ctor(rankRoleProto)
	if rankRoleProto then
		self.rank = rankRoleProto.rank
		self.roleInfo = RoleBaseInfo.New(rankRoleProto.role_info)
		self.isSelf = false
	end
end

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	activeGroup = transform:FindChild("ActiveGroup"):GetComponent("ActiveGroup")
	close = transform:FindChild("Close")
	list = transform:FindChild("List"):GetComponent("TableView")
	selfBg = transform:FindChild("SelfRank")
	selfName = transform:FindChild("SelfRank/Name"):GetComponent("Text")
	selfRankText = transform:FindChild("SelfRank/Rank/Text"):GetComponent("Text")
	selfRankIcon = transform:FindChild("SelfRank/Head/Icon"):GetComponent("Image")
	list:Setup(OnItemUpdate, 0, false)

	activeGroup:SetChangeCallback(OnChangeTab)

	EventManager.AddEventListener(this, "S_GetRoleRankList_0x600", OnProtoRecv)

	window:AddClick(close.gameObject, OnClickClose)
	window:AddClick(selfBg.gameObject, OnClickSelfRank)

	rankList = {}
	selfRankText.text = ""
end

function OnEnter()
	RankProto.C_GetRoleRankList_0x600(1, 200)
	--MainPanel.backCallback = OnClickClose
	if PlayerPrefsUtil.HasKey(PlayerPrefsKey.TipImage_FirstArena) then
	    PlayerPrefsUtil.SetInt(PlayerPrefsKey.TipImage_FirstArena, 0)
	end

	selfName.text = Role.name

	UIUtils.LoadAvatarWithId(selfRankIcon, Role.avatarId)
end

function OnExit()
	if close then
		local rect = close:GetComponent("RectTransform")
		rect.localScale = Vector3.New(1, 1, 1)	
	end
end

-----------------------
--  Function
-----------------------

function MoveTo(rank)
	if rank < #rankList then
		local t = Tweener.DOAnchorPos(list.content, Vector2.New(list.content.anchoredPosition.x, list.cellHeight * (rank-1)), 0.5, true)
	end
end

function OnProtoRecv(msg)
	rankList = {}

	local selfInfo = RoleBaseInfo.New()
	selfInfo.roleId = Role.roleId
	selfInfo.name = Role.name
	selfInfo.icon = Role.avatarId
	selfInfo.level = Role.level
	selfInfo.prize = Role.prize

	selfRankInfo = RankRoleInfo.New()
	selfRankInfo.rank = msg.self_rank
	selfRankInfo.roleInfo = selfInfo
	selfRankInfo.isSelf = true

	selfRankText.text = selfRankInfo.rank

	-- table.insert(rankList, selfRankInfo)

	for k,v in ipairs(msg.rank_roles) do
		local rankInfo = RankRoleInfo.New()
		rankInfo.rank = v.rank
		rankInfo.roleInfo = RoleBaseInfo.New(v.role_info)
		table.insert(rankList, rankInfo)
	end
	list:ReloadData(#rankList)
end

function OnItemUpdate(lineTable, line, tableView)
	for k,v in pairs(lineTable) do
		local item = rankList[tonumber(k)]
		local rankItem = RankItem.New(v.transform, window)
		rankItem:UpdateWith(item)
	end
end

function OnChangeTab(uid)
	if uid == 2 then
		CommonUtil.ShowMsg(Lang.RAND_1)
		activeGroup:SelectByUid(1)
	end
end

function OnClickSelfRank()
	if selfRankInfo then
		MoveTo(selfRankInfo.rank)
	end
end

function OnClickClose()
	window:Exit()

	HomePanel.OnEnter()
end