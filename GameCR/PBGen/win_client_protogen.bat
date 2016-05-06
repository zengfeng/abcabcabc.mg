@protoc -I../LuaProtoGen/protocol ../LuaProtoGen/protocol/hall.proto -oPackets.bin 
clientgen\protogen.exe -i:Packets.bin -o:../Assets/Game/Scripts/CC/Runtime/Services/Packet.cs -ns:CC.Runtime.PB -p:detectMissing
::@handlegen ..\Packets.cs .. S ..\ProtoMap.cs
::@typemapgen ..\Packets.cs C ..\PacketTypeMap.cs