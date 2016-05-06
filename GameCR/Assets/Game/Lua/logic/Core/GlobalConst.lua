TimerGroup = class("TimerGroup", 
{
	UI = "ui",
})

EventPriority = class("EventPriority",
{
	TOP_PRIORITY = 999,
})

SpecialItemType = class("SpecialItem",
{
	Coins = 100000,
	Money = 100001,
	Exp = 100002,
})

CardDataConst = class("CardCardConst",
{
	EMBATTLE_MAX = 8,
})

RoleConst = class("RoleConst",
{
	GRADE_OF_HIDE_RIVAL_INFO = 3,
})

function chestTimeToMoney(timeSec)
	return math.ceil(timeSec / 600)
end

function getDungeonByDungeonStageId(dungeonStageId)
	return math.floor(dungeonStageId / 1000)
end

function getHardIdByDungeonStageId(dungeonStageId)
	return math.floor(dungeonStageId / 100)%10
end

function getDungeonIndexByDungeonStageId(dungeonStageId)
	return math.floor(dungeonStageId)%10
end

function translateDungeonStageId(dungeonStageId, dungeon, hardId, stageId)
	return dungeonStageId + dungeon * 1000 + hardId * 100 + stageId
end

function getQualityColor(quality)
	local arr = {"#6C6C6CFF", "#004BC6FF", "#771AFFFF"}
	return ({ColorUtility.TryParseHtmlString(arr[quality], 1)})[2]
end