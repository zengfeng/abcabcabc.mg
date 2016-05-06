PreloadFiles = { }
local  this = PreloadFiles
this.isDontWaitFrame = false;
this.DevelopMode = false;
this.files = {}
-- this.loadBar


function this.AddFile(file)
	table.insert(this.files, file)
end

-- 加载资源
function this.LoadResource(  )

	this.DevelopMode = GameConst.DevelopMode

	if this.DevelopMode == false then
		this.Final()
	else
		this.loadBar.gameObject:SetActive(true)
		this.loadBar:SetInfo("加载资源", false, 0, "Config")
		Coo.assetManager:LuaLoad(this, "Config/preload", this.OnLoadPreloadConfig)
	end

	


	-- this.loadBar.State = "加载资源"
	-- this.loadBar.showFileBar = false
	-- this.loadBar.totalProgress = 0
	-- this.loadBar.File = "Config/preload"
end


function this.OnLoadPreloadConfig(t, name, obj)
	local text = tostring(obj)

	if text == "" or not text then
	else
		local list = string.split(text, "\n")
		for k, v in pairs(list) do
			this.AddFile(v)
		end
	end

	this.PreloadBegin()

end

function this.PreloadBegin()

	if not this.files then
		this.Final()
		return
	end


	this.count = table.maxn(this.files)
	this.index = 1


	this.LoadItem()
end



function  this.LoadItem(  )
	local line = this.files[this.index]
	-- print(this.index .. " " .. line)
	if string.trim(line) == '' then
		this.OnLoadItem()
		return
	end

	if this.DevelopMode == false then
		if string.find(line, "Config") then
			this.OnLoadItem()
			return
		end
	end



	local csv = string.split(line, ";")
	local path = csv[1]
	path = (string.gsub(path, ".csv", ""))
	-- this.loadBar.File = path;
	-- this.loadBar.totalProgress = this.index / this.count
	this.isDontWaitFrame = false;
	this.loadBar:SetProgress(this.index / this.count, path)
	Coo.assetManager:LuaLoad(this, path, this.OnLoadItem)
end

function  this.OnLoadItem(table, name , obj )
	--print("~~~~~~~~~~~~~this.OnLoadItem name=" .. tostring(name))
	this.index = this.index + 1
	if this.index <= this.count then
		if this.isDontWaitFrame then
			this.LoadItem()
		else
			Coo.callUtil:LuaAddFrameOnce( this.LoadItem)
		end
	else
		this.Final()
	end

	-- print(this.index .. "/" .. this.count)
end


function this.Final( ... )
	-- print("加载完成")
	
	GameManager.InitConfig()
	--destroy(this.loadBar.gameObject.transform.parent.gameObject)
end
