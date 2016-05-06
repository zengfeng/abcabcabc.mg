TaskProto = class("TaskProto", 
{
})

local this = TaskProto

function TaskProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_TaskList_0x500", this.S_TaskList_0x500, task_pb.S_TaskList_0x500())
	ProtoUtil.AddLuaProtoCallback("S_TaskInfoNotify_0x501", this.S_TaskInfoNotify_0x501, task_pb.S_TaskInfoNotify_0x501())
	ProtoUtil.AddLuaProtoCallback("S_GetTaskAward_0x502", this.S_GetTaskAward_0x502, task_pb.S_GetTaskAward_0x502())
end

-----------------------
-- 刷新
-----------------------

function TaskProto.C_TaskList_0x500()
	local msg = task_pb.C_TaskList_0x500()
	ProtoUtil.SendMsg(msg, 0x500)
end

function TaskProto.S_TaskList_0x500(msg)
end

-----------------------
-- 通知
-----------------------

function TaskProto.S_TaskInfoNotify_0x501(msg)
	Role.taskManager:UpdateTask(msg.task_info.task_id, msg.task_info)
end

-----------------------
-- 领取奖励
-----------------------

function TaskProto.C_GetTaskAward_0x502(taskId)
	local msg = task_pb.C_GetTaskAward_0x502()
	msg.task_id = taskId
	ProtoUtil.SendMsg(msg, 0x502)
end

function TaskProto.S_GetTaskAward_0x502(msg)
	Role.taskManager:UpdateTask(msg.task_id, nil)

	if msg:HasField("task_info") then
		Role.taskManager:UpdateTask(msg.task_info.task_id, msg.task_info)
	end
end

this.StoC()