AvatarConfig = class("AvatarConfig", ConfigModel)
AvatarStruct = class("AvatarStruct",
{
	id = 0,
	name = "",
	icon = "",
	vsIcon = "",
	full = "",
	model = "",
	changeLegionEfffect = "",
	effect = "",
	radius = "",
	fullPivot = Pair.New(),
	talkPivot = Pair.New(),
	headIcon = "",
})

function AvatarConfig:ctor()
	self.super.ctor(self, "Config/avatar")
	self.struct = AvatarStruct
end

function AvatarConfig:GetConfig(id)--[return:AvatarStruct]
	return self.super.GetConfig(self, id)
end