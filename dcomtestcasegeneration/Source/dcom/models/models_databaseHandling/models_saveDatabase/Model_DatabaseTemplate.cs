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
            // Open the database(template) file
            DatabaseVariables.WbOutputDatabase = Controller_ExcelHandling.OpenExcel(DatabaseVariables.TemplatePath);

            // Save data from common setting to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[1];
            Model_SaveDatabaseCommonSetting.SaveCommonSettingDatabase(DatabaseVariables.WsOutputDatabase);

            // Save data from service 10 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[2];
            Model_SaveDatabaseService10.SaveDatabaseService10(DatabaseVariables.WsOutputDatabase);

            // Save data from service 11 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[3];
            Model_SaveDatabaseService11.SaveDatabaseService11(DatabaseVariables.WsOutputDatabase);

            // Save the database
            Controller_ExcelHandling.SaveExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);

            // After Handling, close the testcase file
            Controller_ExcelHandling.CloseExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);
        }
    }
}
