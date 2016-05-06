RoleTaskManager = class("RoleTaskManager", 
{
	tasksList = nil,
})

function RoleTaskManager:ctor(tasksProto)
	self.tasksList = {}

	for k,v in ipairs(tasksProto) do
		local task = RoleTask.New(v)
		self.tasksList[task.taskId] = task
	end
end

function RoleTaskManager:UpdateTask(taskId, taskProto)
	local task = nil
	if taskProto then
		task = RoleTask.New(taskProto)
	end
	self.tasksList[taskId] = task
end

function RoleTaskManager:HasFinish()
	local ret = false
	for i,v in pairs(self.tasksList) do
		if v.status == 2 then
			ret = true
			break
		end
	end
	return ret
end