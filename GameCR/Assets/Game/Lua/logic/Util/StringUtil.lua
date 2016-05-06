StringUtil = {}


-----------
-- 填充字符串 
--  @param source 源字符串
--  @param length 填充到长度
--  @param fill  填充字符串
--  @param direction 方向,可选值为1start和-1end
function StringUtil.FillStr(obj,  length, fill, direction) 
	if not length then length = 2 end
	if not fill then fill = "0" end
	if not direction then direction = 1 end

	if not obj then return obj end
	local source = tostring(obj)
	if source == "" then return source end
	if fill == "" then return fill end



	local i = 0
	while string.len(source) < length do
		if direction == 1 then
			source = fill .. source;

		else
			source = source .. fill;
		end

		i = i + 1
		if i > 100000 then break end
	end
	return source;
end

--获取文件名
function StringUtil.StripFileName(path)
	return string.match(path, ".+/([^/]*%.[a-zA-Z0-9%_%-]+)$")
end

--是否文件夹
function StringUtil.IsDirectory(path)
	return StringUtil.StripFileName(path) == nil
end

--获取扩展名
function StringUtil.GetExt(filename)
	return filename:match(".+%.(%w+)$")
end

--去除扩展名
function StringUtil.RemoveExt(filename)
	return filename:match("(.+)%.%w+$")
end

--c# {0}形式的格式化输入
function StringUtil.CSharpFormat(str, ...)
	local format = string.gsub(str, "({.-})", "%%d")
	return string.format(format, ...)
end