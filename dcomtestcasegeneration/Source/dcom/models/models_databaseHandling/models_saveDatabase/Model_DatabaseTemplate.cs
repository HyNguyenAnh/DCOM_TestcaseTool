using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.views.views_ToolBar;

namespace dcom.models.models_databaseHandling.models_saveDatabase
{
    class Model_DatabaseTemplate
    {
        public static void SaveDatabase()
        {

            // Open the database_template file
            DatabaseVariables.WbOutputDatabase = Controller_ExcelHandling.OpenExcel(DatabaseVariables.TemplatePath);

            // Select the first sheet to push all data
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[1];

            // Push data to the database
            FillCommonSettingDatabase(DatabaseVariables.WsOutputDatabase);
            

            // Save the database
            Controller_ExcelHandling.SaveExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);

            // After Handling, close the testcase file
            Controller_ExcelHandling.CloseExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);

        }

        public static void FillCommonSettingDatabase(Worksheet Ws)
        {
            int ID = 0;
            int rowIndex = DatabaseVariables.StartRowIndexDatabaseTables[ID];
            int columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables[ID] + 1;

            // Project Information
            ID = 8;
            Ws.Cells[rowIndex, columnIndex] = DatabaseVariables.ProjectName;
            Ws.Cells[rowIndex + 1, columnIndex] = DatabaseVariables.Variant;
            Ws.Cells[rowIndex + 2, columnIndex] = DatabaseVariables.Release;
            Ws.Cells[rowIndex + 3, columnIndex] = DatabaseVariables.RC;

            // Data Path Information
            ID = 9;
            Ws.Cells[rowIndex, columnIndex] = DatabaseVariables.DatabaseSource;
            Ws.Cells[rowIndex + 1, columnIndex] = DatabaseVariables.PathOutputDatabase;
            Ws.Cells[rowIndex + 4, columnIndex] = TestcaseVariables.DirectoryOutputTestcase;
            Ws.Cells[rowIndex + 5, columnIndex] = DatabaseVariables.TemplatePath;
            Ws.Cells[rowIndex + 6, columnIndex] = DatabaseVariables.DirectoryOutputDatabase;

            // Selected Service
            //DatabaseVariables.ID++;

        }
    }
}
