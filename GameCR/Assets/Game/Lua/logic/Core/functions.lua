--输出日志--
function log(str)
    Util.Log(str);
end

--打印字符串--
function print(...)
	Util.Log(str);
end

--错误日志--
function error(str) 
	Util.LogError(str);
end

--警告日志--
function warn(str) 
	Util.LogWarning(str);
end

--查找对象--
function find(str)
	return GameObject.Find(str);
end

function destroy(obj)
	GameObject.Destroy(obj);
end

function newobject(prefab)
	return GameObject.Instantiate(prefab);
end

function destroyChildren(obj)
	for i=0,obj.childCount-1 do
		--print("obj.childCount=" .. tostring(obj.childCount))
		destroy(obj:GetChild(i).gameObject)
	end
end

--创建面板--
function createPanel(name)
	PanelManager:CreatePanel(name);
end

function child(str)
	return transform:FindChild(str);
end

function subGet(childNode, typeName)		
	return child(childNode):GetComponent(typeName);
end

function findPanel(str) 
	local obj = find(str);
	if obj == nil then
		error(str.." is null");
		return nil;
	end
	return obj:GetComponent("BaseLua");
end


--类型转换--
function toInt(number)
    return math.floor(tonumber(number) or 0)
end

function toBool(str)
	if str == "true" then
		return true
	else
		return false
	end
end

function toSprite(texture)
	return Sprite.Create(texture, Rect.New(0, 0, texture.width, texture.height), Vector2.New(texture.width * 0.5, texture.height * 0.5))
end

--剔除字符串前后的空白符--
function string.trim (s)
	return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end

--字符串分割函数: 传入字符串和分隔符，返回分割后的table--
function string.split(str, delimiter)
	if str==nil or str=='' or delimiter==nil then
		return nil
	end
	
    local result = {}
    for match in (str..delimiter):gmatch("(.-)"..delimiter) do
        table.insert(result, match)
    end
	
    return result
end

function string.isNull(str)
	return str == nil or str == ""
end

function handler(self, func)
	return function(...)
		return func(self, ...)
	end
end

function delayCall(func)
	FrameTimer.New(func, 2, 1):Start()
end

function definePanel(panelName)
	local panel = class(panelName)
	_G[panelName] = panel
	setmetatable(panel, {__index = _G})
	setfenv(2, panel)

	return panel
end

function cloneITable(tabl)
	local t = {}
	for i,v in ipairs(tabl) do
		t[i] = v
	end
	return t
end

function str_table_sp(t, unfold)
  unfold = unfold or ""

  local function recurTable(rt, unfold, prefix)
    unfold = unfold or "__nilFold"

    local cout = ""
    local forward, back = string.match(unfold, "(.-)%.(.+)$")
    if nil == forward or nil == back then
      forward = unfold
      back = nil
    end
    if unfold == "all" then
      back = unfold
    end

    if nil ~= rt then
      for k,v in pairs(rt) do
        if k ~= 'class' and type(v) ~= 'function' then
          cout = cout .. prefix .. tostring(k) .. " = " .. tostring(v) .. "\n"

          --展开
          if type(v) == 'table' and (tostring(k) == forward or "all" == unfold) then
            local nprefix = prefix .. "   "
            cout = cout .. recurTable(v, back, nprefix)
          end
        end
      end
    else
      cout = cout .. "table is a nil value \n"
    end
    return cout
  end

  local out = recurTable(t, unfold, "  ")
  out = string.gsub(out, "{(.-)}", "[[%1]]") --remove {0} for c#

  return out
end

function print_table_sp(t, unfold, pre)
  pre = pre or " "
  local out = str_table_sp(t, unfold)
  print_sp("print table [" .. pre .. "]: \n[[\n\n" .. out .. "\n]]")
end

function print_sp(...)
	local arg = {...}
	local str = "lua print : "
	-- for k,v in pairs(arg) do
	for i=1, select("#", ...) do
		local v = arg[i]
		local out = tostring(v)
		if v == nil then
			out = "nil"
		elseif type(v) == "table" then
			out = "\n[[\n\n" .. str_table_sp(v) .. "\n]]\n"
		end
		str = str .. out .. " "
	end
	Debugger.Log(str)
end

function textFormat(owner, textObj, ...) --保存初始的文字格式以复用
	local arr = {...}
	if owner[textObj] then
		textObj.text = string.format(owner[textObj], ...)
	else
		owner[textObj] = textObj.text
		textObj.text = string.format(owner[textObj], ...)
	end
end

function animatorPlay(animator, callback)
	animatorStop(animator)

	animator.gameObject:SetActive(true)
	animator:Play(animator:GetCurrentAnimatorStateInfo(0).nameHash, 0, 0)
	animator.speed = 1

	if callback then
		animator:GetComponent("AnimatorLua").endCallback = function()
			callback()
		end
	end
end

function animatorStop(animator, active)
	-- animator:SetTime(0)
	animator.speed = 0
	if animator:GetComponent("AnimatorLua") then
		animator:GetComponent("AnimatorLua").endCallback = nil
	end
	animator:Update(1)

	if active ~= nil then
		animator.gameObject:SetActive(active)
	end
end

--List转化为Table数据
function listToTable(listData)
	if type(listDate) == "table" then
		return listData
	end

	local enumerator = listData:GetEnumerator()
	local tab = {}
	local idx = 1
	while enumerator:MoveNext() do
		tab[idx] = enumerator.Current
		idx = idx + 1
	end

	return tab
end

function dictToTable(dict)
	if type(dict) == "table" then
		return dict
	end

	local enumerator = dict:GetEnumerator()
	local tab = {}
	while enumerator:MoveNext() do
		tab[enumerator.Current.Key] = enumerator.Current.Value
	end

	return tab
end
--取位运算i大于等于1
function getBit(int32, i)
	return bit.band(math.pow(2, i-1), int32) / math.pow(2, i-1)
end

print = Debugger.Log
