#-*- coding:utf-8 –*-
import sys
import xlsxwriter
import os


def Csv2xlsx_File(infile, outfile):
		print("File")
		print("infile:%s" % infile)
		print("outfile:%s" % outfile)

		workbook = xlsxwriter.Workbook(outfile)
		worksheet = workbook.add_worksheet()

		format_normal = workbook.add_format()
		format_head = workbook.add_format({'bold': True, "font_size":16, "bg_color":"#BBBBFF", "border":1,"border_color":"#BBBBBB"})

		file = open(infile, 'r')
		lines = [ x.strip().split(';') for x in file.readlines() ]
		row = 0
		for line in lines:
			col = 0
			maxlength = 10
			for item in line:
				if maxlength < len(item):
					maxlength = len(item)

				if row < headRow:
					worksheet.write(row, col, unicode(item , 'utf-8'), format_head)
				else:
					worksheet.write(row, col, unicode(item , 'utf-8'))

				col += 1

			row += 1

		workbook.close()

def Csv2xlsx_Dir(intdir, outdir):
	print("Dir")
	print("infile:%s" % infile)
	print("outfile:%s" % outfile)	
		

def printdoc():
	print """
请按格式输入如:
1.文件方式
python csv2xlsx -f test.csv test.xlsx

2.目录方式
python csv2xlsx -d csv xlsx
"""


headRow = 1
isConsole = True

if len(sys.argv) < 4:
	printdoc()

else:
	t = sys.argv[1]
	inpath = sys.argv[2]
	outpath = sys.argv[3]

	if len(sys.argv) > 4:
		headRow = int(sys.argv[4])


	if t == "-f":
		Csv2xlsx_File(inpath, outpath)
	elif t == "-d":
		Csv2xlsx_Dir(inpath, outpath)
	else:
		printdoc()







