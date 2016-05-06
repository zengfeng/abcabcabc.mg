EventManager = {}

local eventMap = {}
local sortList = {}
function EventManager.AddEventListener(groupId, eventName, callbackPtr, priorityNum)
	priorityNum = priorityNum or 0

	if eventMap[eventName] == nil then
		eventMap[eventName] = {}
	end
	local groupObj = {group = groupId, callback = callbackPtr, priority = priorityNum}
	eventMap[eventName][groupId] = groupObj
end

function EventManager.DispatchEvent(eventName, ...)
	local eventList = eventMap[eventName]
	if eventList then
		sortList = {}
		for k,v in pairs(eventList) do
			table.insert(sortList, v)
		end
		table.sort(sortList, function (a, b)
			return a.priority > b.priority
		end)
		for i,v in ipairs(sortList) do
			if v.callback then
				v.callback(...)
			end
		end
	end
end

function EventManager.RemoveListener(groupId)
	for k1,v1 in pairs(eventMap) do
		for k2,v2 in pairs(v1) do
			if v2.group == groupId then
				eventMap[k1][k2] = nil
			end
		end
	end
end

function EventManager:CleanAll()
	eventMap = {}
end

function EventManager:GetEventMap()
	return eventMap
end