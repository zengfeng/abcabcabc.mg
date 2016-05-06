ConfigModel = class("ConfigModel")

function ConfigModel:ctor(file)
	self.file = file
	self.ready = false
	self.configs = {}
	self.struct = nil
	self.keyName = "id"

	PreloadFiles.AddFile(self.file)
end

function ConfigModel:Load()
	if self.file == nil then
		error("Config file is null, you must set a path")
		return 
	end

	Coo.assetManager:LuaLoad(self, self.file, self.OnLoad)
end

function ConfigModel:LoadConfig()
	if not self.ready then
		self:Load()
	end
end

function ConfigModel:ReLoad()
	self.ready = false
	self:Load()
	self.ready = true	
end

function ConfigModel:ReLoadConfig()
	self.configs = {}
	self:ReLoad()
end

function ConfigModel:OnLoad(name, obj)

	if name==nil or obj==nil then
		error("load file " .. name .. " error")
	end
	obj = string.gsub(obj, "\r\n", "\n")
	local line = string.split(obj, '\n')

	local keyArr = string.split(line[2], ';')
	local keys = {}
	for k,v in pairs(keyArr) do
		keys[k] = v
	end

	-- 删除配置表中头两行中文，以及最后一行的分割函数产生的空行
	-- 注:由于删除操作会引起表索引的变动，所以先删除第二行，再删除第一行，不可倒过来
	table.remove(line, 2)
	table.remove(line, 1)
	table.remove(line, table.getn(line))

	local clsKey = {}
	for k,v in pairs(self.struct) do
		if type(v) == "table" and v.__cname ~= nil then
			table.insert(clsKey, k)
		end
	end
	
	self.configs = {}

	for i = 1,table.getn(line) do
		csv = string.split(line[i], ';')

		local st = self.struct.New()
		for i,v in ipairs(csv) do
			local keyName = keys[i]
			local val = st[keyName]
			if val ~= nil then
				if type(val) == "table" then
					if not string.isNull(v) then
						if val.__cname == "Pair" then
							st[keyName] = Pair.New(v, self.file, keyName)
						elseif val.__cname == "PairList" then
							st[keyName] = PairList.New(v, self.file, keyName)
						elseif val.__cname == nil then
							st[keyName] = string.split(v, ",")
						end
					end
				elseif type(val) == "number" then
					st[keyName] = tonumber(v)
				elseif type(val) == "string" then
					st[keyName] = v
				end
			else
				for k2,v2 in pairs(clsKey) do
					local val = st[v2]
					if val.__cname == "PropList" then
						local kv = addPopidToValue(keyName, v) -- 添加属性id
						st[v2] = clone(st[v2])
						val = st[v2]
						val:Parse(keyName, kv, self.file)
						-- if self.file == "Config/card" then
						--print("<color=red>----: " .. keyName .. "======: " .. kv .. " --------: " .. self.file .. "</color>")
						-- 	-- print("----: " .. k2 .. "======: " .. v2)
						-- end
					end
				end
			end
		end
		self:ParseSpecial(csv, st)
		local key = st[self.keyName]
		
		if key ~= nil then
			self.configs[key] = st
		else
			table.insert(self.configs, st)
		end
	end
	
	self:ParseComplete()
	self.ready = true
end

-- 添加属性id
function addPopidToValue(keyName, valueStr)
	local par = string.split(valueStr, ",")
	--print("=============value: " .. valueStr .. "[1: " .. par[1] .. " 2:" .. par[2])
	if par == nil or #par >= 2 then
		return valueStr;
	end
	if keyName == "initGainSoldier" then --16
		return PropId.ProduceSpeedAdd .. "," .. valueStr
	elseif keyName == "initBattle" then --50
		return PropId.BattleForceAdd .. "," .. valueStr
	elseif keyName == "initSpeed" then --53
		return PropId.SpeedAtkAdd .. "," .. valueStr
	elseif keyName == "growGainSoldier" then -- 16
		return PropId.ProduceSpeedAdd .. "," .. valueStr
	elseif keyName == "growBattle" then -- 50
		return PropId.BattleForceAdd .. "," .. valueStr
	elseif keyName == "growSpeed" then -- 53
		return PropId.SpeedAtkAdd .. "," .. valueStr
	else
		print("<color=red>cant find keyname: " .. keyName .. "</color>")
		return valueStr
	end
end

function ConfigModel:GetConfig(id)
	return self:DetectConfig(id, self.configs[toInt(id)])
end

function ConfigModel:GetAllConfigs()
	return self.configs
end

function ConfigModel:DetectConfig(id, out)
	if not id then
		local str = "读取错误，id为空\n"
		error(str .. debug.traceback())
		SysmsgManager.LuaExecute(0, {str})
		return
	end
	if not out then
		local str = "读取数据失败，指定id=" .. id .. "数据不存在，于表 " .. self.file .. "\n"
		error(str .. debug.traceback())
		SysmsgManager.LuaExecute(0, {str})
		return
	end
	return out
end

function ConfigModel:ParseSpecial(csv, st)
end

function ConfigModel:ParseProp()
end

function ConfigModel:ParseComplete()
end