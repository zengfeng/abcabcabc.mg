RoleChestManager = class("RoleChestManager", 
{
	onlineChestCount = 0,
	nextOnlineChestTicks = 0,
	starChestStarCount = 0,
	nextStarChestTicks = 0,
	dropChestInfo = {},

	unlockingPos = -1,
	maxOnlineChestCount = false,
	sendOnlineUnlock = false,
	sendDropUnlock = false,
	newDropChestPos = 0,
	starGain = 0,
})

function RoleChestManager:ctor(chestProto)
	self:UpdateByProto(chestProto, true)
	self.sendOnlineUnlock = false

	EventManager.AddEventListener(self, "S_AddOnlineChest_0x311", handler(self, self.OnPreOpenOnlineChest), EventPriority.TOP_PRIORITY)
	EventManager.AddEventListener(self, "S_PreOpenArenaChest_0x332", handler(self, self.OnPreOpenArenaChest), EventPriority.TOP_PRIORITY)
	EventManager.AddEventListener(self, "S_UnlockArenaChest_0x331", handler(self, self.OnUnlockArenaChest), EventPriority.TOP_PRIORITY)
	EventManager.AddEventListener(self, "S_OpenChest_0x300", handler(self, self.OnOpenChest), EventPriority.TOP_PRIORITY)
	EventManager.AddEventListener(self, "S_SyncChestInfo_0x301", handler(self, self.OnSyncChestInfo), EventPriority.TOP_PRIORITY)
end

function RoleChestManager:UpdateByProto(chestProto, isFirst)
	isFirst = isFirst or false

	local lastStar = self.starChestStarCount

	self.onlineChestCount = chestProto.online_chest_count
	self.nextOnlineChestTicks = chestProto.next_online_chest_ticks
	self.starChestStarCount = chestProto.star_chest_starcount
	self.nextStarChestTicks = chestProto.next_star_chest_ticks

	if not isFirst then
		self.starGain = math.max(self.starChestStarCount - lastStar, 0)
	end

	if self.nextOnlineChestTicks == -1 then
		self.maxOnlineChestCount = true
	else
		self.maxOnlineChestCount = false
	end

	local last = {}
	for k,v in pairs(self.dropChestInfo) do
		last[v.pos] = v.status
	end

	self.dropChestInfo = {}
	for i,v in ipairs(chestProto.drop_chests) do
		local chest = RoleDropChestInfo.New(v)
		self.dropChestInfo[chest.pos] = chest

		if last[chest.pos] == 0 and chest.status ~= 0 and not isFirst then
			self.newDropChestPos = chest.pos
		end

		if chest.status == 2 then
			self.unlockingPos = chest.pos
		end
	end

	self.startTime = os.time()
end

function RoleChestManager:OnUpdate(delta)

	if self.nextOnlineChestTicks <= 0 and not self.sendOnlineUnlock and not self.maxOnlineChestCount then
		self.sendOnlineUnlock = true
		self.nextOnlineChestTicks = 0
		ChestProto.C_AddOnlineChest_0x311()
	end

	self.nextOnlineChestTicks = math.max(math.round(self.nextOnlineChestTicks - delta), 0)

	local chest = self.dropChestInfo[self.unlockingPos]
	if chest then
		chest.unlockTicks = math.max(math.round(chest.unlockTicks - delta), 0)

		if chest.status == 2 and chest.unlockTicks <= 0 and not self.sendDropUnlock then
			self.sendDropUnlock = true
			ChestProto.C_PreOpenArenaChest_0x332(chest.pos)
		end
	end
end

function RoleChestManager:OnPreOpenOnlineChest(msg)
	self.sendOnlineUnlock = false
	self.nextOnlineChestTicks = msg.next_online_chest_ticks
	self.onlineChestCount = msg.online_chest_count

	if self.nextOnlineChestTicks == -1 then
		self.maxOnlineChestCount = true
	else
		self.maxOnlineChestCount = false
	end
end

function RoleChestManager:OnPreOpenArenaChest(msg)
	self.sendDropUnlock = false

	if self.dropChestInfo[msg.pos] then
		self.dropChestInfo[msg.pos].unlockTicks = msg.unlock_ticks
		if msg.unlock_ticks <= 0 then
			self.dropChestInfo[msg.pos].status = 3
		end
	end
end

function RoleChestManager:OnUnlockArenaChest(msg)
	self.unlockingPos = msg.pos

	local chest = self.dropChestInfo[msg.pos]
	if chest then
		chest.status = 2
		chest.unlockTicks = msg.unlock_ticks
	end
end

function RoleChestManager:OnOpenChest(msg)
	if msg.chest_type == 3 then --竞技场宝箱
		local chest = self.dropChestInfo[msg.pos]
		if chest then
			chest.status = 0
		end
		if msg.pos == self.unlockingPos then
			self.unlockingPos = -1
		end
	end
end

function RoleChestManager:OnSyncChestInfo(msg)
	self:UpdateByProto(msg.chest_info)
end

function RoleChestManager:GetDropChestByPos(pos)--[return:RoleDropChestInfo]
	local ret = nil
	for k,v in pairs(self.dropChestInfo) do
		if v.pos == pos then
			ret = v
			break
		end
	end
	return ret
end

function RoleChestManager:GetNewDrop()--[return:RoleDropChestInfo]
	return self:GetDropChestByPos(self.newDropChestPos)
end

function RoleChestManager:IsDropChestFull()
	local count = 0
	for i,v in ipairs(self.dropChestInfo) do
		if v.status ~= 0 then
			count = count + 1
		end
	end
	return count >= 4
end

-----------------------
--  RoleDropChestInfo
-----------------------

RoleDropChestInfo = class("RoleDropChestInfo",
{
	pos = 0,
	status = 0, --4种状态: 0.empty 1.lock 2.unlocking  3.preopen
	chestId = 0,
	unlockTicks = 0
})

function RoleDropChestInfo:ctor(dropChestInfoProto)
	self.pos = dropChestInfoProto.pos
	self.status = dropChestInfoProto.status
	self.chestId = dropChestInfoProto.chestId
	self.unlockTicks = dropChestInfoProto.unlock_ticks
end	

