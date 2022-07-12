using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcom.controllers;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using ExcelWorkbook = Microsoft.Office.Interop.Excel.Workbook;
using ExcelWorksheet = Microsoft.Office.Interop.Excel.Worksheet;


namespace dcom.controllers.controllers_middleware
{
    class Controller_ExcelHandling
    {
        public static ExcelApplication app = new ExcelApplication();

        public static ExcelWorkbook CreateExcel(string excelPath)
        {
            ExcelWorkbook wb;

            app.Visible = false;
            app.DisplayAlerts = false;
            wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

          
            SaveExcel(excelPath, wb);
            CloseExcel(excelPath, wb);
            return wb;
        }
        public static void OpenExcel(string excelPath, ExcelWorkbook wb)
        {
            string excelFileName = excelPath?.Substring(excelPath.LastIndexOf(@"\") + 1);
            excelFileName = excelFileName?.Remove(excelFileName.Length - 5);
            Console.WriteLine(excelFileName);
            if (Controller_FileHandling.IsFileLocked(excelPath))
            {
                CloseExcel(excelPath, wb);
                
            }

            try
            {
                wb = app.Workbooks.Open(excelPath);
                if (excelFileName.Contains("RequirementDB"))
                {
                    DatabaseVariables.WbDatabase = wb;
                }
                else if (excelFileName.Contains("Testcase"))
                {
                    TestcaseVariables.WbOutputTestcase = wb;
                }

            }
            catch
            {
                app = new ExcelApplication();
                wb = app.Workbooks.Open(excelPath);

            }
        }


        public static void SaveExcel(string excelPath, ExcelWorkbook wb)
        {
            string excelFileName = excelPath.Substring(excelPath.LastIndexOf(@"\") + 1);
            excelFileName = excelFileName.Remove(excelFileName.Length - 5);

            app.DisplayAlerts = false; // to avoid the "replace" warning

            try
            {
                wb.SaveAs(excelPath);
            }
            catch
            {
                foreach (var process in Process.GetProcessesByName("excel")) //whatever you need to close 
                {
                    if (process.MainWindowTitle.Contains(excelFileName))
                    {
                        process.Kill();
                        break;
                    }
                }
            }
        }

        public static void CloseExcel(string excelPath, ExcelWorkbook wb)
        {
            string excelFileName = excelPath.Substring(excelPath.LastIndexOf(@"\") + 1);
            excelFileName = excelFileName.Remove(excelFileName.Length - 5);

            app.Visible = false;
            app.DisplayAlerts = false;
            try
            {
                wb?.Close(0);
            }
            catch
            {
                foreach (var process in Process.GetProcessesByName("excel")) //whatever you need to close 
                {
                    if (process.MainWindowTitle.Contains(excelFileName))
                    {
                        process.Kill();
                        break;
                    }
                }
            }
        }

        public static void CleanExcelSheet(ExcelWorksheet ws)
        {
            ws.Cells.Clear();
        }
    }
}
