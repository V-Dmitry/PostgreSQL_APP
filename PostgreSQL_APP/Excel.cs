using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace PostgreSQL_APP
{
    class Excel: IExcel
    {
        ExcelPackage ep = null;
        DataTable dt = null;
        string sheetTitle = null;

        public Excel()
        {
            ep = new ExcelPackage();
        }

        public void CreateSheet(string sheetName, DataTable dataSource)
        {
            ep.Workbook.Worksheets.Add(sheetName);
            sheetTitle = sheetName;
            dt = dataSource; ;
        }

        public void CreateCells(string sheetName)
        {
            for (int i = 0; i < dt.Columns.Count; i++) 
            {
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Font.Bold = true;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].Style.Font.Size = 12;
                ep.Workbook.Worksheets[sheetName].Cells[1, i + 1].AutoFitColumns();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    ep.Workbook.Worksheets[sheetName].Cells[j + 2, i + 1].Value = dt.Rows[j][i];
                    ep.Workbook.Worksheets[sheetName].Cells[j + 2, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    ep.Workbook.Worksheets[sheetName].Cells[j + 2, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    ep.Workbook.Worksheets[sheetName].Cells[j + 2, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ep.Workbook.Worksheets[sheetName].Cells[j + 2, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                }
            }
        }

        public void WriteToFile(string fileName)
        {
            if (ep != null)
            {
                var bin = ep.GetAsByteArray();
                File.WriteAllBytes(fileName + ".xlsx", bin);
            }
        }
    }
}
