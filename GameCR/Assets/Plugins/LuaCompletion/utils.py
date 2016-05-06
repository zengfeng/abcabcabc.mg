import os
import re
import sublime


def isLuaFile(file):
    ext = os.path.splitext(file)[1][1:]
    return ext == "lua"


# find all value with "val = v" like
def findValues(prefix, strg):
    vals = {}
    valMat = re.finditer(prefix + "([\w\d]+)\s*=\s*(.+)", strg, re.MULTILINE)
    for valItem in valMat:
        val = valItem.group(1)
        itemMat = re.match("([\w\d]+)\.New.+", valItem.group(2))
        if itemMat:
            vals[val] = "val:" + itemMat.group(1)
        else:
            vals[val] = "val:nil"

    return vals


def isST3():
    return sublime.version()[0] == '3'
