RobotFloatPropConfig = class("RobotFloatPropConfig", ConfigModel)
RobotFloatPropStruct = class("RobotFloatPropStruct",
{
	id = 0,
	type = 0,
	proportion = 0,
	atkMin = 0,
	atkMax = 0,
	ProduceSpeedMin = 0,
	ProduceSpeedMax = 0,
	speedMin = 0,
	speedMax = 0,
})

function RobotFloatPropConfig:ctor()
	self.super.ctor(self, "Config/robot_float_prop")
	self.struct = RobotFloatPropStruct
	self.sortList = {}
	self.zeroCfg = nil
end

function RobotFloatPropConfig:GetConfig(id)--[return:RobotFloatPropStruct]
	return self.super.GetConfig(self, id)
end

function RobotFloatPropConfig:ParseComplete(csv, st)
	for k,v in pairs(self.configs) do
		table.insert(self.sortList, v)
	end

	function sortFunc(a, b)
		return a.proportion < b.proportion
	end
	table.sort(self.sortList, sortFunc)
end

function RobotFloatPropConfig:GetZeroStreakRank()
	local cfg = self.zeroCfg
	local atk = math.Random(cfg.atkMin, cfg.atkMax)
	local produce = math.Random(cfg.ProduceSpeedMin, cfg.ProduceSpeedMax)
	local speed = math.Random(cfg.speedMin, cfg.speedMax)
	return atk, produce, speed
end

function RobotFloatPropConfig:GetRandRadio(proportion)
	proportion = math.min(proportion, 1)
	local ret = 1
	for k,v in pairs(self.sortList) do
		if proportion < v.proportion then
			ret = k
			break
		end
	end
	
	local cfg = self.sortList[ret]
	local atk = math.Random(cfg.atkMin, cfg.atkMax)
	local produce = math.Random(cfg.ProduceSpeedMin, cfg.ProduceSpeedMax)
	local speed = math.Random(cfg.speedMin, cfg.speedMax)
	print_sp("Efwekfjwlekfj", atk, produce, speed)
	return atk, produce, speed
end