PairList = class("PairList", 
{
	list = nil,
})

function PairList:ctor(str, csv, keyName)
	self.list = {}
	self.listUnsorted = {}

	if string.isNull(str) then
		return
	end

	local parL = string.split(str, ",")
	for k,v in pairs(parL) do
		local par = Pair.New(v, csv, keyName)
		self.list[par.id] = par
		table.insert(self.listUnsorted, par)
	end
end