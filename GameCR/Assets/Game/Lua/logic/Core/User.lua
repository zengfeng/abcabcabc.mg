User = {
	session_id = "",
	id = 0,
	server = {id=1, name="localhost", ip_addr="127.0.0.1", port=8888, status=2}
}


function User.Print( ... )
	print("User.server id=" .. tostring(User.server.id )
		.. "  name=".. tostring(User.server.name)
		.. "  ip_addr=".. tostring(User.server.ip_addr)
		.. "  port=".. tostring(User.server.port)
		.. "  status=".. tostring(User.server.status)
		)
end