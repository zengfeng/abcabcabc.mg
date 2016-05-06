UIUtils = {}

-- 选择allState中的gameObject，只显示stateName
function UIUtils.SeleteState(allState, stateName)
	for k,v in pairs(allState) do
		v:SetActive(false)
	end
	local obj = allState[stateName]
	if obj then
		obj:SetActive(true)
	end
end

--选择显示transform的其中一个子对象
function UIUtils.SelectTrans(transform, nameOrIndex)
	if not transform then
		return
	end

	for i=0, transform.count - 1 do
		local child = transform:GetChild(i)
		child.gameObject:SetActive(false)
	end

	local child = nil
	if type(nameOrIndex) == "number" then
		child = transform:GetChild(nameOrIndex)
	elseif type(nameOrIndex) == "string" then
		child = transform:FindChild(nameOrIndex)
	end

	if child then
		child.gameObject:SetActive(true)
	end

	return child
end

function UIUtils.ShowTip(trans, visible, isLeft, isInner)
	isLeft = isLeft or false
	if isInner == nil then
		isInner = true
	end

	local tip = trans:FindChild("TipIcon")
	if nil == tip then
		if visible then
			UIUtils.CreateImage("Image/Common/main_deal_tag", trans, function (imageObj)
				imageObj.name = "TipIcon"
				imageObj:SetActive(visible)

				local trans = imageObj.transform
				if not isLeft then
					trans.anchorMin = Vector2.New(1, 1)
					trans.anchorMax = Vector2.New(1, 1)
					if isInner then
						trans.pivot =  Vector2.New(1, 1)
					end
				else
					trans.anchorMin = Vector2.New(0, 1)
					trans.anchorMax = Vector2.New(0, 1)
					if isInner then
						trans.pivot =  Vector2.New(0, 1)
					end
				end
				trans.localScale = Vector2.New(1, 1)
			end)
		end
	else
		tip.gameObject:SetActive(visible)
	end
end

function UIUtils.ShowGreenTip(trans, visible,tipNum, isLeft, isInner)--绿点加数字提示
	isLeft = isLeft or false
	if isInner == nil then
		isInner = true
	end
	local tip = trans:FindChild("GreenTip")
	if nil == tip then		
		if visible then
			Coo.assetManager:LuaLoad(UIUtils, "module/Common/GreenTip", function (_, name, obj)

				obj:SetActive(visible)

				imageObj = newobject(obj).transform
				imageObj.name = "GreenTip"
				imageObj.transform:SetParent(trans.transform, false)	
				
				local trans = imageObj.transform
				local transRect = trans:GetComponent("RectTransform")	
				num = trans:FindChild("Num"):GetComponent("Text")	
				num.text = 	tipNum	
				if not isLeft then
					trans.anchorMin = Vector2.New(1, 1)
					trans.anchorMax = Vector2.New(1, 1)
					if isInner then
						trans.pivot =  Vector2.New(1, 1)
					end
				else
					trans.anchorMin = Vector2.New(0, 1)
					trans.anchorMax = Vector2.New(0, 1)
					if isInner then
						trans.pivot =  Vector2.New(0, 1)
					end
				end
				trans.localScale = Vector2.New(1, 1)
				transRect.anchoredPosition = Vector2.New(0 , 15)
			end)
		end
	else
		num = tip:FindChild("Num"):GetComponent("Text")	
		num.text = 	tipNum
		tip.gameObject:SetActive(visible)
	end
end

function UIUtils.CreateImage(path, parent, callback)
	Coo.assetManager:LuaLoad(UIUtils, path, function (_, name, obj)
			local sprite = toSprite(obj)
			local imageObj = GameObject.New()
			local component = imageObj:AddComponent(Image.GetClassType())
			component.sprite = sprite
			component:SetNativeSize()
			imageObj.transform:SetParent(parent, false)
			if callback then
				callback(imageObj)
			end
	end)
end

function UIUtils.LoadAvatarWithConfig(config, callback)
	if not config then
		error("UIUtils.LoadAvatarWithConfig: config is nil")
		return
	end

	local avatar = nil
	if not config.GetAvatar then
		avatar = ConfigManager.avatar:GetConfig(config.avatar)
		if not avatar then
			error("UIUtils.LoadAvatarWithConfig: config:GetAvatar function or avatar is nil")
			return
		end
	else
		avatar = config:GetAvatar()
	end
	Coo.assetManager:LuaLoad(UIUtils, avatar.icon, function (_, name, obj)
		callback(name, obj)
	 end)
end

function UIUtils.LoadAvatarWithId(image, avatarId)
	local avat = ConfigManager.avatar:GetConfig(avatarId)
	Coo.assetManager:LuaLoad(UIUtils, avat.icon, function (_, name, obj)
		image.sprite = toSprite(obj)
	 end)
end

function UIUtils.LoadAvatarFullWithId(image, avatarId)
	local avat = ConfigManager.avatar:GetConfig(avatarId)
	Coo.assetManager:LuaLoad(UIUtils, avat.full, function (_, name, obj)
		image.sprite = toSprite(obj)
	 end)
end

function UIUtils.LoadCardAvatar(image, id)
	local avat = ConfigManager.card:GetAvatarConfig(id)
	Coo.assetManager:LuaLoad(UIUtils, avat.icon, function (_, name, obj)
		image.sprite = toSprite(obj)
	 end)
end

function UIUtils.FindWindowByChild(child)
	if child == nil then
		return
	end

	local parent = child.parent
	local window = nil
	while parent do
		window = parent:GetComponent("LuaWindow")
		if window ~= nil then
			break
		end
		parent = parent.parent
	end

	return window
end

function UIUtils.UpdateStarList(starsList, starNum)
	for i=0, starsList.childCount-1 do
		local ltype = 1
		local child = starsList:GetChild(i):GetComponent("MultiImage")
		if child == nil then
			child = starsList:GetChild(i):GetComponent("MultiColor")
			ltype = 2
			if child == nil then
				return
			end
		end
		local funcName
		local otherState = 1
		if ltype == 1 then
			funcName = "SetImageIndex"
		elseif ltype == 2 then
			funcName = "SetColorIndex"
			otherState = -1
		end
		if i < starNum then
			child[funcName](child, otherState)
		else
			child[funcName](child, 0)
		end
	end
end

function UIUtils.UpdateProgress(progress, maxValue, value, delay, reset)
	progress.maxValue = maxValue
	if reset then
		progress.value = 0
	end
	Tweener.DOKill(progress, true)
	local t = Tweener.DOValue(progress, value, 0.5, true)
	Tweener.SetEase(t, Ease.OutBack)

	if delay then
		Tweener.SetDelay(t, 0.2)
	end
end

function UIUtils.Bezier(v0, v1, v2, t)
	return v0*(1-t)*(1-t) + v1*2*t*(1-t) + v2*t*t
end