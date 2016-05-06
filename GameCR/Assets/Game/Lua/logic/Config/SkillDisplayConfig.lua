SkillDisplayConfig = class("SkillDisplayConfig", ConfigModel)
SkillDisplayStruct = class("SkillDisplayStruct",
{
	skillId = 0,
	skillName = "",
	skillDescription = "",
	skillDisplay = "",
	avatarId = 0,
})

function SkillDisplayConfig:ctor()
	self.super.ctor(self, "Config/Skills_Display")
	self.struct = SkillDisplayStruct
	self.keyName = "skillId"
end

function SkillDisplayConfig:GetConfig(id)--[return:SkillDisplayStruct]
	return self.super.GetConfig(self, id)
end

function SkillDisplayConfig:GetSkillDesc(id,level)
	local cfg = self:GetConfig(id)
	local s = cfg.skillDescription
	local arr = {}
	local skillEffList = War.model:GetSkillWarConf(cfg.skillId)
	for m1,m2 in string.gmatch(s, "{(%d+)}(%%?)") do
		local eff = skillEffList.effectDataList[m1]
		local str = ""
		local persent = ""
		if m2 ~= "" then
			persent = "%"
		end
		str = str .. tostring(eff.data) .. persent

		local growUp = eff.growUp*level
		local _, f = math.modf(growUp)
		if f > 0 then
			growUp = tonumber(string.format("%.2f", growUp))
		end
		if growUp > 0 then
			str = str .. "(<color=#19E059FF>+" .. tostring(growUp) .. persent .."</color>)"
		end
		table.insert(arr, str)
	end
	s = string.gsub(s, "{(%d+)}(%%?)", "%%s")
	return string.format(s, unpack(arr))
end