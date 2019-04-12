using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ExcelProcess
{
    public class ExcelImportHelper
    {
        /// <summary>
        /// 读取excel里面数据信息
        /// </summary>
        /// <param name="excel">excel文件路径</param>
        /// <returns></returns>
        public static DataTable NPOIReadExcel(string excel)
        {
            FileStream file = new FileStream(excel, FileMode.Open, FileAccess.Read);
            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
            IWorkbook workbook = null;
            if (excel.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(file);
            }
            else if (excel.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(file);
            }
            //获取excel的第一个sheet
            ISheet sheet = workbook.GetSheetAt(0);
            DataTable table = new DataTable();
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号,即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            //最后一列的标号,即总的行数
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
            {
                IRow row = sheet.GetRow(i);

                //这一句很关键，因为没有数据的行默认是null
                if (row == null)
                {
                    continue;
                }
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    object value = null;
                    //同理，没有数据的单元格都默认是null
                    if (cell != null && cell.CellType != CellType.BLANK)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.STRING:
                                string str = cell.StringCellValue;
                                if (!string.IsNullOrEmpty(str))
                                {
                                    value = str.ToString();
                                }
                                else
                                {
                                    value = string.Empty;
                                }
                                break;
                            case CellType.NUMERIC:
                                // Date comes here
                                var iCellStyle = cell.CellStyle;
                                short format = iCellStyle.DataFormat;
                                //日期
                                if (HSSFDateUtil.IsCellDateFormatted(cell))
                                {
                                    value = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else if (format == 20 || format == 32)
                                {
                                    value = cell.DateCellValue.ToString("HH:mm");
                                }
                                else
                                {
                                    value = cell.NumericCellValue;
                                }
                                break;
                            case CellType.BOOLEAN:
                                value = cell.BooleanCellValue;
                                break;
                            case CellType.FORMULA:
                                {
                                    switch (cell.CachedFormulaResultType)
                                    {
                                        case CellType.BOOLEAN:
                                            value = cell.BooleanCellValue;
                                            break;
                                        case CellType.ERROR:
                                            value = ErrorEval.GetText(cell.ErrorCellValue);
                                            break;
                                        case CellType.NUMERIC:
                                            if (DateUtil.IsCellDateFormatted(cell))
                                            {
                                                value = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                            }
                                            else
                                            {
                                                value = cell.NumericCellValue;
                                            }
                                            break;
                                        case CellType.STRING:
                                            string cellstr = cell.StringCellValue;
                                            if (!string.IsNullOrEmpty(cellstr))
                                            {
                                                value = cellstr.ToString();
                                            }
                                            else
                                            {
                                                value = null;
                                            }
                                            break;
                                        case CellType.Unknown:
                                        case CellType.BLANK:
                                            break;
                                        default:
                                            value = string.Empty;
                                            break;
                                    }
                                    break;
                                }
                            default:
                                value = cell.StringCellValue;
                                break;
                        }
                        dataRow[j] = value;
                    }
                }
                table.Rows.Add(dataRow);
            }
            workbook = null;
            sheet = null;
            return table;
        }
    }
}
