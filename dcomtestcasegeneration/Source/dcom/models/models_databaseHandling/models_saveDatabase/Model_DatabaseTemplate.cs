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
            // Create a copy file from template file to save requirement database
            DatabaseVariables.WbOutputDatabase = Controller_ExcelHandling.OpenExcel(DatabaseVariables.TemplatePath);
            Controller_ExcelHandling.SaveExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);
            Controller_ExcelHandling.CloseExcel(DatabaseVariables.TemplatePath, DatabaseVariables.WbOutputDatabase);

            // Open the requirement database(template) file
            DatabaseVariables.WbOutputDatabase = Controller_ExcelHandling.OpenExcel(DatabaseVariables.PathOutputDatabase);

            // Save data from common setting to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[1];
            Model_SaveDatabaseCommonSetting.SaveCommonSettingDatabase(DatabaseVariables.WsOutputDatabase);

            // Save data from service 10 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[2];
            Model_SaveDatabaseService10.SaveDatabaseService10(DatabaseVariables.WsOutputDatabase);

            // Save data from service 11 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[3];
            Model_SaveDatabaseService11.SaveDatabaseService11(DatabaseVariables.WsOutputDatabase);

            // Save data from service 14 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[4];
            Model_SaveDatabaseService14.SaveDatabaseService14(DatabaseVariables.WsOutputDatabase);

            // Save data from service 22 to the database
            DatabaseVariables.WsOutputDatabase = DatabaseVariables.WbOutputDatabase.Sheets[6];
            Model_SaveDatabaseService22.SaveDatabaseService22(DatabaseVariables.WsOutputDatabase);

            // Save the database
            Controller_ExcelHandling.SaveExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);

            // After Handling, close the template file
            Controller_ExcelHandling.CloseExcel(DatabaseVariables.PathOutputDatabase, DatabaseVariables.WbOutputDatabase);
        }
    }
}
