cd protocol
for %%i in (*.proto) do (
echo %%i
"..\protoc.exe" --plugin=protoc-gen-lua="..\plugin\protoc-gen-lua.bat" --lua_out=. %%i
)
for %%j in (*.*) do (
copy %%j ..\..\Assets\Game\Lua\3rd\pblua\
)
echo end 
pause