PreinstanceMenu = { }
local  this = PreinstanceMenu
this.menuIds = {}--{MenuType.MainUI}
-- this.menuIds = {}
this.index = 0
this.count = 0

-- 加载资源
function this.Begin(  )

	this.loadBar.gameObject:SetActive(true)

	this.loadBar:SetInfo("初始化模块", false, 0, "")


	this.count = table.maxn(this.menuIds)
	this.index = 0


	this.CheckNext()
end




function  this.LoadItem(  )
	local menuId = this.menuIds[this.index];
	Coo.menuManager:LuaOpenMenuPreInstance(menuId, this, this.CheckNext)
	this.loadBar:SetProgress(this.index / this.count, "")
end


function  this.CheckNext(... )
	this.index = this.index + 1
	if this.index <= this.count then
		this.LoadItem()
	else
		this.Final()
	end
end

function this.Final(  )
	GameManager.EnterMainScene()
	destroy(this.loadBar.gameObject.transform.parent.gameObject)
end
