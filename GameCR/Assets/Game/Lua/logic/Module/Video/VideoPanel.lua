local this = definePanel("VideoPanel")

-----------------------
--  LuaBehaviour
-----------------------

function Start()
	closeButton = transform:FindChild("CloseButton")
	fightList = transform:FindChild("Content/VideoList"):GetComponent("TableView")--对战日志
	fightList:Setup(OnVideoItemUpdate, 0, false)
	window:AddClick(closeButton.gameObject, OnClickClose)
	EventManager.AddEventListener(this, "S_GetEliteVideoList_0x551", OnGetVideo)
	EventManager.AddEventListener(this, "S_NewSelectedVideoNotify_0x552", OnGetVideo)
end

function OnEnter()
	-- if parameter then
	-- 	return
	-- end
	VideoProto.C_GetEliteVideoList_0x551()
	print("打开视频面板")
end

-----------------------
--  Function
-----------------------

function OnGetVideo(msg)
	
	vedioList = {}
	for k,v in pairs(msg.share_videos) do
		if v.share_roleId ~= nil then
			if War.GetVersionCompatible(v.video.war_version) then
				table.insert(vedioList, v)
			end
		end	
	end
	table.sort(vedioList, function(a, b)
		
		return a.video.share_time > b.video.share_time
	end)
	fightList:ReloadData(#vedioList)
	
end

function OnVideoItemUpdate(lineTable, line, tableView)--对战日志
	for k,v in pairs(lineTable) do
		local item = vedioList[tonumber(k)]
		local videoItem = VideoItem.New(v.transform, this)
		videoItem:UpdateWith(item)
	end
end

function OnClickClose()
	window:Exit()

	HomePanel.OnEnter()
end