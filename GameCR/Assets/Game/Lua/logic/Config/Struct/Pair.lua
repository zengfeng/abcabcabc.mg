Pair = class("Pair")

function Pair:ctor(str, csv, keyName)
	if str == nil then
		return
	end

	local par = string.split(str, ",")
	if par[2] == nil then
		par = string.split(str, ":")
	end
	if par == nil or par[2] == nil then
		-- error("Pair创建失败\n" .. "于表" .. tostring(csv) .. "于属性" .. tostring(keyName) .. debug.traceback())
		-- return
		par[2] = 0
	end
	
	self.id = tonumber(par[1])
	self.value = par[2]
end

function Pair:IsNull()
	return self.id == nil or self.value == nil
end