ChestIcon = class("ChestIcon", 
{
})

function ChestIcon:ctor(transform, shadowTransform)
	self.transform = transform
	self.gameObject = transform.gameObject
	self.image = transform:GetComponent("MultiImage")
	self.animator = transform:GetComponent("Animator")
	self.chestId = 0

	if shadowTransform then
		self.shadow = shadowTransform:GetComponent("Animator")
	end
end

function ChestIcon:SetState(quality, isOpen)
	isOpen = isOpen or false

	local factor = 0
	if isOpen then
		factor = 1
	end

	local index = quality+factor*4
	self.image:SetImageIndex(index)
end

function ChestIcon:SetStateById(id, isOpen)
	isOpen = isOpen or false
	
	local chest = ConfigManager.chest:GetConfig(id)
	self:SetState(chest.type - 1, isOpen)
	self.chestId = id
end

function ChestIcon:Animate(isStart)
	self.animator:SetTime(0)
	if isStart then
		self.animator.speed = 1
		if self.shadow then
			self.shadow:SetTime(0)
			self.shadow.speed = 1
		end
	else
		self.animator.speed = 0
		if self.shadow then
			self.shadow:SetTime(0)
			self.shadow.speed = 0
		end
	end
end