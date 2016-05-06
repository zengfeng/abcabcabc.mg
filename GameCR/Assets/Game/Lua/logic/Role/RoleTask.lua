RoleTask = class("RoleTask", 
{
	taskId = 0,
	taskType = 0,
	taskProgress = 0,
	status = 0, --0:未开放  1:进行中  2.完成未领奖  3.完成已领奖
})

function RoleTask:ctor(taskProto)
	self.taskId = taskProto.task_id
	self.taskType = taskProto.task_type
	self.taskProgress = taskProto.task_progress
	self.status = taskProto.status
end