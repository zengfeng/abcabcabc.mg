#-*- coding:utf-8 –*-
import sys
import xlsxwriter
import os

import csv2xlsx

csv2xlsx.headRow = 2
csv2xlsx.Csv2xlsx_File("../Assets/Game/Config/stage.csv", "../../../document/程序录入/stage.xlsx")
csv2xlsx.Csv2xlsx_File("../Assets/Game/Config/stage_position.csv", "../../../document/程序录入/stage_position.xlsx")






