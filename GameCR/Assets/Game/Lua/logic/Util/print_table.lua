function print_table2(t, tname, has)
  has = has or {}
  if has[t] then
    return
  end
  
  has[t] = true
  for k, v in pairs(t) do
    print(tname..'.'..tostring(k)..'='..tostring(v))
  end
  
  print("")
  for k, v in pairs(t) do
    if type(v) == "table" then
        print_table(v, tname..'.'..tostring(k), has)
    end
  end
end

function print_table_n(t, tname, has, n, i)
  has = has or {}
 
  
  
  
  i = i or 0
  n = n or 0
  
  for k, v in pairs(t) do
    if i == n then
       if not has[t] then
          if not v then
            print(tname..'.'..tostring(k)..'=' .. tostring(v))
          else
            print(tname..'.'..tostring(k)..'='..(has[v] and "[table]" .. has[v] or  tostring(v)))
          end
       end
    elseif i < n then
      if type(v) == "table" then
        local newtname = tname..'.'..tostring(k)
        print_table_n(v, newtname, has, n, i + 1)
      end
    end
  end
  
  if not has[t] then
    print(" ")
  end
  has[t] = tname
end

function print_table(t, tname, has)
  has = has or {}
  
  for i = 0, 10 do
    print_table_n(t, tname, has, i)
  end

end


function str_table_n(t, tname, has, n, i)
  has = has or {}
 
  
  
  
  i = i or 0
  n = n or 0
  
  local str = "";
  for k, v in pairs(t) do
    if i == n then
       if not has[t] then
          if not v then
            str = str .. (tname..'.'..tostring(k)..'=' .. tostring(v)) .. "\n"
          else
            str = str .. (tname..'.'..tostring(k)..'='..(has[v] and "[table]" .. has[v] or  tostring(v))) .. "\n"
          end
       end
    elseif i < n then
      if type(v) == "table" then
        local newtname = tname..'.'..tostring(k)
        str = str .. str_table_n(v, newtname, has, n, i + 1)
      end
    end
  end
  
  if not has[t] then
    str = str .. "\n"
  end
  has[t] = tname
  return str;
end

function str_table(t, tname, has)
  has = has or {}
  local str = ""
  for i = 0, 10 do
    str =  str .. str_table_n(t, tname, has, i)
  end
  
  return str

end
--print(str_table(_G, "_G"))