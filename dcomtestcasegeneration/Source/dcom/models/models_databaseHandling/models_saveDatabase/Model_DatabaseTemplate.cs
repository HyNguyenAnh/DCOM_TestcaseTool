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
using System.IO;

namespace dcom.models.models_databaseHandling.models_saveDatabase
{
    class Model_DatabaseTemplate
    {
        public static void SaveDatabase()
        {
            // Create a copy file from template file to save requirement database
            if (SystemVariables.PathOutputDatabase != UIVariables.DatabasePath)
            {
                File.Copy(DatabaseVariables.TemplatePath, SystemVariables.PathOutputDatabase, true);
            }

            // Open the requirement database(template) file
            Controller_ExcelHandling.OpenExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);

            // Save data from common setting to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[1];
            Model_SaveDatabaseCommonSetting.SaveCommonSettingDatabase(DatabaseVariables.WsDatabase);

            // Save data from service 10 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[2];
            Model_SaveDatabaseService10.SaveDatabaseService10(DatabaseVariables.WsDatabase);

            //// Save data from service 11 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[3];
            //Model_SaveDatabaseService11.SaveDatabaseService11(DatabaseVariables.WsDatabase);

            //// Save data from service 14 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[4];
            //Model_SaveDatabaseService14.SaveDatabaseService14(DatabaseVariables.WsDatabase);

            //// Save data from service 22 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[6];
            //Model_SaveDatabaseService22.SaveDatabaseService22(DatabaseVariables.WsDatabase);

            //// Save data from service 2E to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[7];
            //Model_SaveDatabaseService2E.SaveDatabaseService2E(DatabaseVariables.WsDatabase);

            //// Save data from service 27 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[8];
            //Model_SaveDatabaseService27.SaveDatabaseService27(DatabaseVariables.WsDatabase);

            //// Save data from service 28 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[9];
            //Model_SaveDatabaseService28.SaveDatabaseService28(DatabaseVariables.WsDatabase);

            //// Save data from service 3E to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[10];
            //Model_SaveDatabaseService3E.SaveDatabaseService3E(DatabaseVariables.WsDatabase);

            //// Save data from service 85 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[11];
            //Model_SaveDatabaseService85.SaveDatabaseService85(DatabaseVariables.WsDatabase);

            // Save the database
            Controller_ExcelHandling.SaveExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);

            // After Handling, close the template file
            Controller_ExcelHandling.CloseExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);

            // Update current database
            Controller_ExcelHandling.OpenExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);
            Definition.DatabaseVariableDefinition();
            Controller_ExcelHandling.CloseExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);
        }
    }
}
