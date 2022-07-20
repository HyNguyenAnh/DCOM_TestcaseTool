using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_testcaseHandling
{
    class Model_TestcaseTemplate
    {

        public static void ExportTestcase()
        {
            // Create a new testcase file if it's not available
            if (Controller_FileHandling.IsFileExisted(TestcaseVariables.PathOutputTestcase) == false)
            {
                TestcaseVariables.WbOutputTestcase = Controller_ExcelHandling.CreateExcel(TestcaseVariables.PathOutputTestcase);
            }

            // Open the testcase file
            Controller_ExcelHandling.OpenExcel(TestcaseVariables.PathOutputTestcase, TestcaseVariables.WbOutputTestcase);
             

            // Select the first sheet to push all data
            TestcaseVariables.WsOutputTestcase = TestcaseVariables.WbOutputTestcase.Sheets[1];

            // Clear all current data in this sheet
            Controller_ExcelHandling.CleanExcelSheet(TestcaseVariables.WsOutputTestcase);

            // Push data to the testcase 
            CreateTestcaseHeader(TestcaseVariables.WsOutputTestcase);
            CreateTestcaseBodyHeader(TestcaseVariables.WsOutputTestcase);
            CreateTestcaseBody(TestcaseVariables.WsOutputTestcase);

            // Push style to the testcase
            CreateTestcaseStyle(TestcaseVariables.WsOutputTestcase);

            // Save the testcase
            Controller_ExcelHandling.SaveExcel(TestcaseVariables.PathOutputTestcase, TestcaseVariables.WbOutputTestcase);

            // After Handling, close the testcase file
            Controller_ExcelHandling.CloseExcel(TestcaseVariables.PathOutputTestcase, TestcaseVariables.WbOutputTestcase);
        }

        public static void CreateTestcaseBody(Worksheet ws)
        {
            Model_PushTestcaseService10.PushTestcaseService10(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[0]);
            Model_PushTestcaseService11.PushTestcaseService11(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[1]);
            //Model_PushTestcaseService14.PushTestcaseService14(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[2]);
            //Model_PushTestcaseService19.PushTestcaseService19(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[3]);
            Model_PushTestcaseService22.PushTestcaseService22(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[4]);
            Model_PushTestcaseService27.PushTestcaseService27(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[5]);
            Model_PushTestcaseService28.PushTestcaseService28(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[6]);
            Model_PushTestcaseService2E.PushTestcaseService2E(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[7]);
            //Model_PushTestcaseService31.PushTestcaseService31(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[8]);
            Model_PushTestcaseService3E.PushTestcaseService3E(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[9]);
            //Model_PushTestcaseService85.PushTestcaseService85(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[10]);
            //Model_PushTestcaseCanTP.PushTestcaseCanTP(ws, TestcaseVariables.ID, UIVariables.SelectedServiceStatus[11]);
        }

        public static void CreateTestcaseHeader(Worksheet Ws)
        {
            TestcaseVariables.ID = 1;
            string[] testcaseColumnsName = TestcaseVariables.TestcaseColumnsName;

            for (int columnIndex = 1; columnIndex <= testcaseColumnsName.Length; columnIndex++)
            {
                Ws.Cells[TestcaseVariables.ID, columnIndex] = testcaseColumnsName[columnIndex - 1];
            }
        }

        public static void CreateTestcaseBodyHeader(Worksheet Ws)
        {
            string[] objectType = TestcaseVariables.ObjectType;

            // 1 st row
            TestcaseVariables.ID++;
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + TestcaseVariables.ID;
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.ComponentColumnIndex] = "2 Tests";
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.ObjectTypeColumnIndex] = objectType[0];

            // 2nd row
            TestcaseVariables.ID++;
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + TestcaseVariables.ID;
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.ComponentColumnIndex] = "2.1 Diagnostic Communication";
            Ws.Cells[TestcaseVariables.ID, TestcaseVariables.ObjectTypeColumnIndex] = objectType[1];

            TestcaseVariables.ID++;
        }

        public static void CreateTestcaseStyle(Worksheet Ws)
        {
            int[] testcaseColumnsWidth = TestcaseVariables.TestcaseColumnsWidth;

            // Columns Width
            for (int columnIndex = 1; columnIndex <= testcaseColumnsWidth.Length; columnIndex++)
            {
                Ws.Columns[columnIndex].ColumnWidth = testcaseColumnsWidth[columnIndex-1];
            }

            // Header style
            Ws.Range[Ws.Cells[1, TestcaseVariables.IDColumnIndex], Ws.Cells[1, TestcaseVariables.ProjectColumnIndex]].Borders.LineStyle = XlLineStyle.xlContinuous;
            Ws.Range[Ws.Cells[1, TestcaseVariables.IDColumnIndex], Ws.Cells[1, TestcaseVariables.ProjectColumnIndex]].Font.Bold = true;
            Ws.Range[Ws.Cells[1, TestcaseVariables.IDColumnIndex], Ws.Cells[1, TestcaseVariables.ProjectColumnIndex]].Interior.Color = System.Drawing.Color.FromArgb(30, 59, 72);
            Ws.Range[Ws.Cells[1, TestcaseVariables.IDColumnIndex], Ws.Cells[1, TestcaseVariables.ProjectColumnIndex]].Font.Color = Color.White;

            // Line style + Font.Bold + Interior.Color
            for (int rowIndex = 2; Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex].Text != ""; rowIndex++)
            {
                Ws.Range[Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex], Ws.Cells[rowIndex, TestcaseVariables.ProjectColumnIndex]].Borders.LineStyle = XlLineStyle.xlContinuous;

                if(Ws.Cells[rowIndex, TestcaseVariables.ObjectTypeColumnIndex].Text == TestcaseVariables.ObjectType[0] | Ws.Cells[rowIndex, TestcaseVariables.ObjectTypeColumnIndex].Text == declaration.TestcaseVariables.ObjectType[1])
                {
                    Ws.Range[Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex], Ws.Cells[rowIndex, TestcaseVariables.ProjectColumnIndex]].Font.Bold = true;
                    Ws.Range[Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex], Ws.Cells[rowIndex, TestcaseVariables.ProjectColumnIndex]].Interior.Color = TestcaseVariables.ColorTestGroupInterior;
                }
                else
                {
                    Ws.Range[Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex], Ws.Cells[rowIndex, TestcaseVariables.ProjectColumnIndex]].Font.Bold = false;
                    Ws.Range[Ws.Cells[rowIndex, TestcaseVariables.IDColumnIndex], Ws.Cells[rowIndex, TestcaseVariables.ProjectColumnIndex]].Interior.Color = TestcaseVariables.ColorTestCaseInterior;
                }
            }
        }
    }
}
