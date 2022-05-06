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
            //for (int ID = 0; ID = )
            int [] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int [] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;

            // Project Information
            
            Ws.Cells[rowIndex[8], columnIndex[8] + 1] = DatabaseVariables.ProjectName;
            Ws.Cells[rowIndex[8] + 1, columnIndex[8] + 1] = DatabaseVariables.Variant;
            Ws.Cells[rowIndex[8] + 2, columnIndex[8] + 1] = DatabaseVariables.Release;
            Ws.Cells[rowIndex[8] + 3, columnIndex[8] + 1] = DatabaseVariables.RC;

            // Data Path Information
            
            Ws.Cells[rowIndex[9], columnIndex[9] + 1] = DatabaseVariables.DatabaseSource;
            Ws.Cells[rowIndex[9] + 1, columnIndex[9] + 1] = DatabaseVariables.PathOutputDatabase;
            Ws.Cells[rowIndex[9] + 4, columnIndex[9] + 1] = DatabaseVariables.TestcaseDirectory;
            Ws.Cells[rowIndex[9] + 5, columnIndex[9] + 1] = DatabaseVariables.TemplatePath;
            Ws.Cells[rowIndex[9] + 6, columnIndex[9] + 1] = DatabaseVariables.DirectoryOutputDatabase;

            // Selected Service
            //DatabaseVariables.ID++;

        }
    }
}
