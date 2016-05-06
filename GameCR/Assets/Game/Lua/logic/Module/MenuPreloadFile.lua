MenuPreloadFile={}

local  this = MenuPreloadFile

function this.GetPreloadFiles( menuId, parameter )
	print("[MenuPreloadFile.GetPreloadFiles] menuId = "..tostring(menuId).."  parameter = "..tostring(parameter))
	if menuId == MenuType.MainScene then
		-- return this.TestPreload(parameter)
	end
end

function this.OnPreloadFile( menuId, filename, obj )
	print("[MenuPreloadFile.OnPreloadFile] menuId = "..tostring(menuId).."  filename = "..tostring(filename).."  obj = "..tostring(obj))
end



function this.TestPreload( parameter )
	return unpack {"UI/Home/HomePanel", "Image/Map/Province/0_0", "Image/Map/Province/0_1", "Image/Map/Province/1_0", "Image/Map/Province/1_1", "Image/Map/Province/2_2"}
end