VideoProto = class("VideoProto", 
{
})

local this = VideoProto

function VideoProto.StoC( )
	ProtoUtil.AddLuaProtoCallback("S_UploadBattleVideo_0x550", this.S_UploadBattleVideo_0x550, video_pb.S_UploadBattleVideo_0x550())
	ProtoUtil.AddLuaProtoCallback("S_GetEliteVideoList_0x551", this.S_GetEliteVideoList_0x551, video_pb.S_GetEliteVideoList_0x551())
	ProtoUtil.AddLuaProtoCallback("S_ViewBattleVideo_0x552", this.S_ViewBattleVideo_0x552, video_pb.S_ViewBattleVideo_0x552())
	ProtoUtil.AddLuaProtoCallback("S_ViewSelfVideo_0x553", this.S_ViewSelfVideo_0x553, video_pb.S_ViewSelfVideo_0x553())

end

-----------------------
-- 分享上传
-----------------------

function VideoProto.C_UploadBattleVideo_0x550(uploadType,shareVideo)
	local msg = video_pb.C_UploadBattleVideo_0x550()
	msg.upload_type = uploadType
	msg.share_video = shareVideo
	ProtoUtil.SendMsg(msg, 0x550)
end

function VideoProto.S_UploadBattleVideo_0x550(msg)
end

-----------------------
-- 获取精选视频列表
-----------------------

function VideoProto.C_GetEliteVideoList_0x551()
	local msg = video_pb.C_GetEliteVideoList_0x551()
	ProtoUtil.SendMsg(msg, 0x551)
end

function VideoProto.S_GetEliteVideoList_0x551(msg)
end

-----------------------
-- 视频观看次数
-----------------------
function VideoProto.C_ViewBattleVideo_0x552(videoType,uuid)
	local msg = video_pb.C_ViewBattleVideo_0x552()
	msg.video_type = videoType
	msg.uuid = uuid
	ProtoUtil.SendMsg(msg, 0x552)
end

function VideoProto.S_ViewBattleVideo_0x552(msg)
end

-----------------------
-- 本地视频观看次数
-----------------------
function VideoProto.C_ViewSelfVideo_0x553()
	local msg = video_pb.C_ViewSelfVideo_0x553()
	ProtoUtil.SendMsg(msg, 0x553)
end

function VideoProto.S_ViewSelfVideo_0x553(msg)
	--print("统计本地视频观看次数")
end
this.StoC( )