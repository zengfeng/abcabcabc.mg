LeagueCreate = class("LeagueCreate", 
{
})


function LeagueCreate:ctor(transform, window)
	self.type = {Lang.LeagueType1, Lang.LeagueType2, Lang.LeagueType3}
	self.transform = transform
	self.btnLogo = transform:FindChild("Logo/BtnChangeLogo")
	window:AddClick(self.btnLogo.gameObject, handler(self, self.OnLogoClick))

	self.btnSure = transform:FindChild("Text5/BtnSure")
	window:AddClick(self.btnSure.gameObject, handler(self, self.OnCreateClick))
	self.btnSureMaterial = self.btnSure.gameObject:GetComponent("ImageSetMaterial")

	self.nameText = transform:FindChild("InputFieldName/Text"):GetComponent("Text")
	self.desText = transform:FindChild("InputFieldDes/Text"):GetComponent("Text")

	self.coinText = transform:FindChild("Text5/Text"):GetComponent("Text")
	self.enoughCoins = false

	self.typeText = transform:FindChild("ImgCondition/type/textType"):GetComponent("Text")
	self.typeText = self.type[1]

	self.desCountText = transform:FindChild("ImgCondition/prize/textType"):GetComponent("Text")
	self.desCountText = "0"

	self:init()
end

function LeagueCreate:init( ... )
	-- body
	print("========coins: " .. Role.coins)
	if Role.coins > 1000 then
		self.enoughCoins = true
		self.coinText.text = string.format("<color=white>"..self.coinText.text.."</color>")
		self.btnSureMaterial:SetMaterial(1)
	else
		self.enoughCoins = false
		self.coinText.text = string.format("<color=red>"..self.coinText.text.."</color>")
		self.btnSureMaterial:SetMaterial(0)
	end
end

function LeagueCreate:OnLogoClick()
	print("==============OnLogoClick==============")

end

function LeagueCreate:OnCreateClick()
	print("==============OnCreateClick==============")
	if self.enoughCoins == false then
		return
	end
	print("=name: " .. self.nameText.text .. " des:" .. self.desText.text)
	LeagueProto.C_CreateLeague_0x700(self.nameText.text, 1, self.desText.text, 1, 500)
end