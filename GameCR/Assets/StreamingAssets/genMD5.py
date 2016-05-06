#!/usr/bin/python

import os
import sys
import getopt
import string
import shutil
from hashlib import md5

def Usage():
    print "Usage: GenAssets.py [options]"
    print "\n"
    print "Options:"
    print "-h, --help        show help info"
    print "-m, --md5         gen MD5 Assets list"

def GenMD5ForString(str):
    m = md5()
    m.update(str)
    return m.hexdigest()

def GenMD5ForFile(file):
    m = md5()
    a_file = open(file, 'rb')
    m.update(a_file.read())
    a_file.close()
    return m.hexdigest()

def GenMD5ForFolder(dir, MD5File):
    outfile = open(MD5File, 'w')
    for childDir in os.listdir(dir):
        if os.path.isdir(childDir) and childDir != "Platform" :
            for root, subdirs, files in os.walk(childDir):
                for file in files:
                    if os.path.splitext(file)[1] != '.meta' and os.path.splitext(file)[1] != '.manifest':
                        fileFullPath = os.path.join(root, file)
                        md5 = GenMD5ForFile(fileFullPath)
                        fileRelPath = os.path.relpath(fileFullPath, dir)
                        filePath = fileRelPath.replace(os.sep, '/')
                        outfile.write(filePath + ';' + md5 + '\n')
    outfile.close()

def CopyMD5FileForPlatforms():
    shutil.copyfile('files.csv', "Platform/Android/files.csv")
    shutil.copyfile('files.csv', "Platform/IOS/files.csv")
    shutil.copyfile('files.csv', "Platform/Windows/files.csv")
    shutil.copyfile('files.csv', "Platform/OSX/files.csv")
    os.remove('files.csv')

def ChangePlatformVersion( versionFile):
    rvFile = open(versionFile, 'r')
    line = rvFile.readline()
    rvFile.close()

    version = line.split(';')[0]
    url = line.split(';')[1]
    #print(version)
    #print(url)
    last_ver = string.atoi(version.split('.')[2])
    last_ver = last_ver + 1
    new_str = version.split('.')[0] + '.' + version.split('.')[1] + '.' + '%d' % last_ver + ';' + url
    print(versionFile + ": " + new_str)

    wvFile = open(versionFile, 'w')
    wvFile.write(new_str+'\n')
    wvFile.close()

if __name__ == "__main__":
    try:
        opts, args = getopt.getopt(sys.argv[1:], 'h')
    except getopt.GetoptError:
        Usage()
        sys.exit()
        
    for opt, arg in opts:
        if opt in ("-h", "--help"):
            Usage()
            sys.exit()
        elif opt in ("-m", "--md5"):
            print "Gen MD5 files.csv Begin..."
            GenMD5ForFolder(".", 'files.csv')
            print "Gen MD5 files.csv Success"
            sys.exit()
        
    print "Gen MD5 files.csv file Begin..."
    GenMD5ForFolder(".", 'files.csv')
    CopyMD5FileForPlatforms()
    ChangePlatformVersion("Platform/Android/VERSION.txt")
    ChangePlatformVersion("Platform/Windows/VERSION.txt")
    ChangePlatformVersion("Platform/OSX/VERSION.txt")
    print "Gen MD5 files.csv file Success" 
