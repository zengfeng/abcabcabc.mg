TrainConfig = class("TrainConfig", ConfigModel)
TrainStruct = class("TrainStruct",
{
	step = 0,
	stageId = 0,
	trainType = 0, --1=引导阶段：按照顺序读取地图 2=随机阶段：随机读取地图
	legion0 = 0,
	legion2 = 0,
	legion3	= 0,
	legion4 = 0,
	guide = PairList.New(),
})

function TrainConfig:ctor()
	self.super.ctor(self, "Config/Train")
	self.struct = TrainStruct
end

function TrainConfig:GetConfig(id)--[return:TrainStruct]
	return self.super.GetConfig(self, id)
end

function TrainConfig:GetNonGuideTrain()--[return:TrainStruct]
	local train = nil
	for i,v in ipairs(self.configs) do
		if v.trainType == 2 then
			train = v
			break
		end
	end
	return train
end