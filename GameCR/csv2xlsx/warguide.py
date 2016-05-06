#-*- coding:utf-8 –*-
import sys
import xlsxwriter
import os

import csv2xlsx

csv2xlsx.headRow = 2
csv2xlsx.Csv2xlsx_File("./war_guide.csv", "./war_guide.xlsx")