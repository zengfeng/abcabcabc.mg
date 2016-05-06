BaseWindow = class("BaseWindow", 
{
})

function BaseWindow:ctor()
	self.path = ""
	self.window = nil
	self.transform = nil
end

function BaseWindow:Load()
	if self.transform == nil then
		Coo.assetManager:LuaLoad(self, self.path, function (_, name, obj)
			self:OnLoad(name, obj)

			if self.callback then
				self.callback()
			end

			if self.window then
				self.window:OnOpenSubWindow()
			end
		end)
	else
		if self.callback then
			self.callback()
		end
		if self.window then
			self.window:OnOpenSubWindow()
		end
	end	
end

function BaseWindow:OnCloseWindow()
	if self.window then
		self.window:OnCloseSubWindow()
	end
	self.transform.parent = nil
	destroy(self.transform.gameObject)
end