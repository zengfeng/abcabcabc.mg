ShopProto = class("ShopProto", 
{
})

local this = ShopProto

function ShopProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_BuyShopItem_0x400", this.S_BuyShopItem_0x400, shop_pb.S_BuyShopItem_0x400())
	ProtoUtil.AddLuaProtoCallback("S_RefreshShop_0x401", this.S_RefreshShop_0x401, shop_pb.S_RefreshShop_0x401())
end

-----------------------
-- 购买
-----------------------

function ShopProto.C_BuyShopItem_0x400(pos)
	local msg = shop_pb.C_BuyShopItem_0x400()
	msg.pos = pos

	ProtoUtil.SendMsg(msg, 0x400)
end

function ShopProto.S_BuyShopItem_0x400(msg)
end

-----------------------
-- 刷新商城
-----------------------

function ShopProto.C_RefreshShop_0x401()
	local msg = shop_pb.C_RefreshShop_0x401()
	ProtoUtil.SendMsg(msg, 0x401)
end

function ShopProto.S_RefreshShop_0x401(msg)
end

this.StoC( )