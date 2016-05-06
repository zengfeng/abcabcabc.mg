import sublime
import sublime_plugin
import re

try:
    import buildDefinition
    import utils
except ImportError:
    from . import buildDefinition
    from . import utils

global cache
global builder


def init():
    global cache, builder
    builder = buildDefinition.BuildDefinition()
    builder.loadCache()

    cache = {}
    for key, val in builder.defi.items():
        cache[key] = val


class LuaBuildDefinitionCommand(sublime_plugin.TextCommand):

    def run(self, edit, dirs):
        global builder
        builder.build(dirs[0])
        builder.save()

        global cache
        cache = {}
        for key, val in builder.defi.items():
            cache[key] = val

    def is_enabled(self, dirs):
        return len(dirs) == 1

    def is_visible(self, dirs):
        return self.is_enabled(dirs)


class LuaAutoCompleteCommand(sublime_plugin.TextCommand):

    def run(self, edit, characters):
        for region in self.view.sel():
            self.view.insert(edit, region.end(), characters)

        self.view.run_command("hide_auto_complete")
        sublime.set_timeout(self.delayed_complete, 1)

    def delayed_complete(self):
        self.view.run_command("auto_complete")


class LuaAutoComplete(sublime_plugin.EventListener):

    def appendMember(self, clsName, lst):
        global cache

        if clsName != None and clsName in cache:
            obj = cache[clsName]
            sup = None
            for key, val in obj.items():
                if "::" in key:
                    if key == "::super":
                        sup = val
                    continue
                if "ctor" in key:
                    continue
                lst.append((key + "\t" + clsName +
                            "-" + val.split(":")[0], key))

            if sup != None:
                self.appendMember(sup, lst)

    def iterMemberClass(self, valArr, firstCls):
        global cache

        cls = None
        if valArr[0] in cache:
            cls = firstCls
            clsDic = None
            for x in range(1, len(valArr)):
                item = valArr[x]
                clsDic = cache[cls]
                if not clsDic:
                    break

                if item in clsDic:
                    cls = clsDic[item].split(":")[1]
                    clsDic = cache[cls]
                else:
                    func = self.getFunc(clsDic, item)
                    if func != None:
                        cls = func.split(":")[1]
                    else:
                        cls = None
                        break

        return cls

    def getFunc(self, dic, funcName):
        for key, val in dic.items():
            # print funcName, key
            if re.search(funcName + "\(.*\)", key) != None:
                return val

        return None

    def on_query_completions(self, view, prefix, locations):
        global cache

        line = view.substr(sublime.Region(
            view.line(locations[0]).begin(), locations[0]))
        match = re.search("([\w\d\.]+)[\.\:]$", line)
        
        if match != None:
            memList = []
            val = match.group(1)
            valArr = val.split(".")
            if valArr[0] in cache:
                cls = self.iterMemberClass(valArr, valArr[0])
                self.appendMember(cls, memList)
            else:
                content = view.substr(sublime.Region(0, view.size()))
                match = re.search(
                    "^\s*" + val + "\s*=\s*(.+)", content, re.MULTILINE)
                if match != None:
                    matCls = re.search("([\w\d]+)\.New\(.+", match.group(1))
                    if matCls != None:  # mark Cls.New()
                        self.appendMember(matCls.group(1), memList)
                    else:  # mark Func()--[crt:ClsName]
                        matFunc = re.search(
                            "[\w\d]+([\.\:][\w\d]+\(.*\)){1,}", match.group(1))
                        if matFunc != None:
                            funcName = match.group(1)
                            firstIndex = funcName.find("(")
                            funcArr = []
                            startIndex = 0
                            # mark bracket
                            while firstIndex > 0:
                                funcSub = funcName[firstIndex:]
                                braCount = 1
                                curIndex = firstIndex
                                for i in range(1, len(funcSub)):
                                    ch = funcSub[i]
                                    if ch == ")":
                                        braCount -= 1
                                    elif ch == "(":
                                        braCount += 1
                                    curIndex = firstIndex + i
                                    if braCount <= 0:
                                        break

                                curIndex += 1
                                nextStr = funcName[curIndex:]
                                funcArr.append(funcName[startIndex:firstIndex])
                                startIndex = curIndex
                                firstIndex = nextStr.find("(")
                                if firstIndex > 0:
                                    firstIndex += curIndex

                            resolve = ""
                            for item in funcArr:
                                resolve += item

                            valArr = re.split("[\.\:]", resolve)
                            # like ConfigManager.avatar, ConfigManager is class
                            if valArr[0] in cache:
                                cls = self.iterMemberClass(valArr, valArr[0])
                                self.appendMember(cls, memList)
                            else:  # TODO : support var by recur
                                pass

            return (memList, sublime.INHIBIT_WORD_COMPLETIONS | sublime.INHIBIT_EXPLICIT_COMPLETIONS)

        return []


# st3
def plugin_loaded():
    sublime.set_timeout(init, 200)

# st2
if not utils.isST3():
    init()
