GradeIcon = class("GradeIcon", 
{
})

function GradeIcon:ctor(transform)
	self.transform = transform
	self.image = transform:GetComponent("MultiImage")
end

function GradeIcon:SetGrade(grade)
	self.image:SetImageIndex(grade-1)
end