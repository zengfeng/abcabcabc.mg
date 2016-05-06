import os
import json
import sublime
import codecs
import re
try:
    import utils
except ImportError:
    from . import utils

class BuildDefinition:

    def __init__(self):
        self.dir = sublime.packages_path() + "/User/LuaComplete/"
        self.path = self.dir + "definition.json"
        self.defi = {}

    def loadCache(self):
        if os.path.exists(self.path):
            f = open(self.path)
            data = f.read()
            self.defi = json.loads(data)

    def build(self, dirs):
        self.defi = {}

        def recurDir(d):
            for item in os.listdir(d):
                path = os.path.join(d, item)
                if os.path.isdir(path):
                    recurDir(path)
                elif utils.isLuaFile(path):
                    f = codecs.open(path, "r", "utf-8")
                    s = f.read()
                    self.parseLua(s)

        recurDir(dirs)

    def parseLua(self, strg):
        m = re.match("Config", strg, re.MULTILINE)

        # get Class = class("classname", {
        #   val = valCls
        # }
        # like
        mat = re.finditer(
            "^([\w\d]+)\s*=\s*class.+,\s*\n*\{(\n+[^\}]*){1,}\}\)", strg, re.MULTILINE)

        for item in mat:
            cls = item.group(1)
            vals = utils.findValues("", item.group(2))
            if not cls in self.defi:
                self.defi[cls] = {}
            for key, val in vals.items():
                self.defi[cls][key] = val

        # function block
        mat = re.finditer(
            "^function\s+([\w\d]+)[\:\.]([\w\d]+\s*\(.*\))(.*)$(?:\n+.+){1,}?\nend", strg, re.MULTILINE)

        for item in mat:
            cls = item.group(1)
            func = item.group(2)
            if cls == "this":
                continue

            if not cls in self.defi:
                self.defi[cls] = {}

            # get "function () --[return:returnValue]" like
            funcWithNote = item.group(2) + item.group(3)
            funcMat = re.search("(.+)\s*--\[return:(.+)\]", funcWithNote)
            if funcMat:
                self.defi[cls][funcMat.group(1)] = "func:" + funcMat.group(2)
            else:
                self.defi[cls][func] = "func:nil"

            # get "self.val" like
            vals = utils.findValues("self\.", item.group(0))
            for key, val in vals.items():
                self.defi[cls][key] = val
                # valMat = re.finditer(
                #     "self\.([\w\d]+)\s*=\s*(.+)", item.group(0), re.MULTILINE)
                # for valItem in valMat:
                #     val = valItem.group(1).encode("utf-8")
                #     itemMat = re.match("([\w\d]+)\.New.+", valItem.group(2))
                #     if itemMat:
                #         self.defi[cls][val] = "val:" + itemMat.group(1)
                #     else:
                #         self.defi[cls][val] = "val:nil"

        # get super like "class("ClassName", Super)"
        mat = re.finditer(
            "^([\w\d]+)\s*=\s*class\(.+,\s*([\w\d]+)\)", strg, re.MULTILINE)
        for item in mat:
            cls = item.group(1)
            sup = item.group(2)
            if not cls in self.defi:
                self.defi[cls] = {}

            self.defi[cls]["::super"] = sup

    def save(self):
        res = json.dumps(self.defi, indent=4)

        if not os.path.exists(self.dir):
            os.makedirs(self.dir)

        f = open(self.path, "w+")
        f.write(res)
        f.close()

    def delete(self, path, root):
        if not os.path.exists(path):
            return
        if os.path.isfile(path):
            try:
                os.remove(path)
            except Exception:
                pass
        elif os.path.isdir(path):
            for item in os.listdir(path):
                itemSrc = os.path.join(path, item)
                delete(itemSrc, root)
            if path != root:
                try:
                    os.rmdir(path)
                except Exception:
                    pass
