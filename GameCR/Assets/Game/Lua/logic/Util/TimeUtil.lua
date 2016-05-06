TimeObject = class("TimeObject",
{
	d=0, h=0, m=0, s=0
})

TimeUtil = {className="TimeUtil"}
local this = TimeUtil

-- 转换成d:h:m:s
function TimeUtil.ToDHMS(time)--[return:TimeObject]
	local obj = TimeObject.New();
	local d = math.floor(time / 86400);
	local h = math.floor((time - d * 86400) / 3600);
	local m = math.floor((time - d * 86400 - h * 3600) / 60);
	local s = time - d * 86400 - h * 3600 - m * 60;

	
	obj.d = d;
	obj.h  = h;
	obj.m  = m;
	obj.s = math.floor(s);
	return obj;
end


-- 转换成h:m:s
function TimeUtil.ToHMS(time)--[return:TimeObject]
	local obj = TimeObject.New();
	local h = math.floor(time / 3600);
	local m = math.floor((time - h * 3600) / 60);
	local s = time - h * 3600 - m * 60;
	
	obj.h = h;
	obj.m = m;
	obj.s = math.floor(s);
	return obj;
end



-- 转换成m:s
function TimeUtil.ToMS(time)--[return:TimeObject]
	local obj = TimeObject.New();
	local m = math.floor(time / 60);
	local s = time - m * 60;
	
	obj.m = m;
	obj.s = math.floor(s);
	return obj;
end





-- 转换成 DD天HH时MM分SS秒，
function TimeUtil.ToDHMSS(time, showCount)
	showCount = showCount or 2

	local obj = this.ToDHMS(time);
	local d = ""
	local h = ""
	local m = ""
	local s = ""
	local count = 0
	if obj.d > 0 then
		d = obj.d .. "天"
		count = count + 1
	end
	if obj.h > 0 then
		h = obj.h .. "时"
		count = count + 1
	end
	if obj.m > 0 and count < showCount then
		m = StringUtil.FillStr(obj.m, 2) .. "分" 
		count = count + 1
	end
	if count < showCount and obj.s > 0 then
		s = StringUtil.FillStr(obj.s, 2) .. "秒"
	end
	return d .. h .. m .. s;
end


-- 转换成 hh:mm:ss
function TimeUtil.ToHHMMSS(time)
	local obj = this.ToHMS(time);
	return StringUtil.FillStr(obj.h, 2) .. ":" .. StringUtil.FillStr(obj.m, 2) .. ":" .. StringUtil.FillStr(obj.s, 2);
end

	
-- 转换成 hh:mm
function TimeUtil.ToHHMM(time)
	local obj = this.ToHMS(time);
	return StringUtil.FillStr(obj.h, 2) .. ":" .. StringUtil.FillStr(obj.m, 2) ;
end	
		
-- 转换成mm:ss 
function TimeUtil.ToMMSS(time)
	local obj = this.ToHMS(time);

	if obj.h > 0 then
		return StringUtil.FillStr(obj.h, 2) .. ":" .. StringUtil.FillStr(obj.m, 2) ..  ":"  ..  StringUtil.FillStr(obj.s, 2);
	end
	
	return StringUtil.FillStr(obj.m, 2) .. ":" .. StringUtil.FillStr(obj.s, 2) ;
end	