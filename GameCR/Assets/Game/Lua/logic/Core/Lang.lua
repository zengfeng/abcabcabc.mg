--简体中文
local ZH_CN = class("ZH_CN",
{
	APPLICATION_1 = "你已注销",
	APPLICATION_2 = "注销将退出游戏，点击确定退出",

	HOME_CHEST_1 = "%s后才可开启！",
	HOME_CHEST_2 = "星级满后才可开启！",
	HOME_CHEST_3 = "时间未到！",
	HOME_CHEST_FULL_SUBTITLE = "宝箱已满！",
	HOME_CHEST_FULL_DESC = "挑战竞技场无法获得宝箱，是否继续？",
	HOME_TRAIN_END_SUBTITLE = "训练结束！",
	HOME_TRAIN_END_DESC = "继续挑战训练师，将不会获得奖励，确定要挑战吗？",

	EMBATTLE_1 = "上阵人数已满",
	EMBATTLE_2 = "竞技场到达%s阶段解锁",
	EMBATTLE_3 = "主公等级达到%d级解锁",

	COMMON_NOT_ENCOUGH_1 = "元宝不足！",
	COMMON_NOT_ENCOUGH_2 = "银币不足！",
	COMMON_CHEST_WINDOW_1 = "开启",

	OPEN_CHEST_1 = "新卡片解锁",
	OPEN_CHEST_2 = "资源卡片",
	OPEN_CHEST_3 = "您的金币",

	CARD_INFO_1 = "卡片数量不足！",

	MATCHER_1 = "正在取消匹配...",
	MATCHER_2 = "房间准备中...",

	RAND_1 = "联盟暂无",
	RAND_2 = "对战日志暂无",

	SHOP_1 = "获得一张%s卡",

	EMBATTLE_SUBTITLE = "还可以上阵！",
	EMBATTLE_DESC = "上阵人数未满，确定要退出吗？",

	PROP_SOLDIER_1 = "攻击",
	PROP_SOLDIER_2 = "造兵",
	PROP_SOLDIER_3 = "速度",

	SOLDIER_1 = "主公等级达到%d级解锁",

	DUNGEON_1 = "通关上一关解锁",
	DUNGEON_2 = "通关普通关卡解锁",
	DUNGEON_3 = "通关精英关卡解锁",
	DUNGEON_4 = "通关本关的普通关卡解锁",
	DUNGEON_5 = "通关本关的精英关卡解锁",
	DUNGEON_6 = "宝箱已开启过了！",
	DUNGEON_7 = "关卡到达3星才可开启",

	QUALITY_1 = "普通",
	QUALITY_2 = "稀有",
	QUALITY_3 = "史诗",

	--登录
	SVR = "区",
	WAITING_1 = "请稍后...",
	WAITING_2 = "点击重新登录",
	WAITING_3 = "服务器即将开始维护，暂不支持匹配",
	NOTICE1 = "%s<color=#0000ffff><i>（点击加入）</i></color>",
	NOTICE2 = "%s",

	NUM_0 = "零",
	NUM_1 = "一",
	NUM_2 = "二",
	NUM_3 = "三",
	NUM_4 = "四",
	NUM_5 = "五",
	NUM_6 = "六",
	NUM_7 = "七",
	NUM_8 = "八",
	NUM_9 = "九",
	NUM_DI_1 = "十",
	NUM_DI_2 = "百",
	NUM_DI_3 = "千",
	NUM_DI_4 = "万",
	NUM_Add_1 = "+",
	NUM_Add_2 = "%",

	 --颜色
    COLOR_WHITE = "<color=#ffffff>%s</color>",  --白色
    COLOR_GREEN = "<color=#3ca40c>%s</color>",  --绿色
    COLOR_BLUE = "<color=#2379b6>%s</color>",  --蓝色
    COLOR_PURPLE = "<color=#5429c2>%s</color>",  --紫色
    COLOR_ORANGE = "<color=#e07c12>%s</color>",  --橙色
    COLOR_ORANGE_2 = "<color=#ee3b0d>%s</color>",  --橙色,登录
    COLOR_GREEN_2 = "<color=#16e54b>%s</color>",  --绿色
    COLOR_RED = "<color=#f53a3a>%s</color>",  --红色
    --公会相关
    UnionNull = "无公会",
    UnionUseHero = "曹大仁",
   	Null = "无",
   	--段位相关
   	GradeTrain = "训练",
   	GradeBronze = "青铜",
   	Grade = "竞技场",
   	GradeNow = "您的竞技场",
   	GradeReach = "欢迎到达",
   	GradeAdd = "+",
   	GradeMinus = "-",
   	GradeNum = "第%d名",
   	LogMail = "您还没有邮件！",
   	LogFight = "您还没有对战日志！",
   	LogTask = "您还没有成就！",

   	--公会
   	LeagueCountDes = "人数: %d/50",
   	LeagueType1 = "允许任何人",
   	LeagueType2 = "批准可加入",
   	LeagueType3 = "不可加入",
   	Level = "级",
   	--签到
   	SignNum = "你已连续签到<color=#19E059FF>%d</color>次",--签到次数
   	SignNotHave = "收集物资",
   	SignHave = "已领取",
})

--英文
local EN_US = class("EN_US",
{
})

Lang = class("Lang", ZH_CN) --选择语言

function Lang.ToStringNumber(inNumber)
	local splitNums = {}
	local restBit = inNumber
	while restBit ~= 0 do
		table.insert(splitNums, restBit % 10)
		restBit = math.floor(restBit / 10)
	end

	local ret = ""
	for k,v in pairs(splitNums) do
		if k == 1 and v == 0 then -- 删除个位零
		else
			local digit = Lang["NUM_DI_" .. tostring(k - 1)]
			if digit then
				ret = digit .. ret
			end
			if #splitNums == 2 and k == 2 and v == 1 then --置换一十位
			else
				ret = Lang["NUM_" .. tostring(v)] .. ret
			end
		end
	end
	return ret
end

function Lang.changeToShortNumber(number)  --大于1万数字转化为 “数字+万”
	if number > 100000 then
       return tostring(math.floor(number / 10000)) .. Lang.NUM_DI_4

    else 
    	return tostring(number)
    end
end

function Lang.ToCardQualityName(quality)
	local arr = {"白", "蓝", "紫"}
	return arr[quality]
end

function Lang.ToCardQualityDesc(quality)
	local arr = {"普通", "稀有", "史诗"}
	return arr[quality]
end

function Lang.ToSpecialItemName(specialItemType)
	local arr = {[SpecialItemType.Coins] = "银币",
				 [SpecialItemType.Money] = "元宝",
				 [SpecialItemType.Exp] = "经验",}
	return arr[specialItemType]
end