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
            if (SystemVariables.PathOutputDatabase != UIVariables.DatabasePath && !File.Exists(SystemVariables.PathOutputDatabase))
            {
                File.Copy(SystemVariables.templateFileLocalPath, SystemVariables.PathOutputDatabase, true);
            }

            // Open the requirement database(template) file
            Controller_ExcelHandling.OpenExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);

            // Save data from common setting to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[1];
            Model_SaveDatabaseCommonSetting.SaveCommonSettingDatabase(DatabaseVariables.WsDatabase, UIVariables.edited_View[0]);

            // Save data from service 10 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[2];
            Model_SaveDatabaseService10.SaveDatabaseService10(DatabaseVariables.WsDatabase, UIVariables.edited_View[1]);

            // Save data from service 11 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[3];
            Model_SaveDatabaseService11.SaveDatabaseService11(DatabaseVariables.WsDatabase, UIVariables.edited_View[2]);

            // Save data from service 14 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[4];
            Model_SaveDatabaseService14.SaveDatabaseService14(DatabaseVariables.WsDatabase, UIVariables.edited_View[3]);

            //// Save data from service 19 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[5];
            //Model_SaveDatabaseService19.SaveDatabaseService19(DatabaseVariables.WsDatabase, UIVariables.edited_View[4]);

            // Save data from service 22 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[6];
            Model_SaveDatabaseService22.SaveDatabaseService22(DatabaseVariables.WsDatabase, UIVariables.edited_View[5]);

            // Save data from service 2E to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[7];
            Model_SaveDatabaseService2E.SaveDatabaseService2E(DatabaseVariables.WsDatabase, UIVariables.edited_View[6]);

            // Save data from service 27 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[8];
            Model_SaveDatabaseService27.SaveDatabaseService27(DatabaseVariables.WsDatabase, UIVariables.edited_View[7]);

            // Save data from service 28 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[9];
            Model_SaveDatabaseService28.SaveDatabaseService28(DatabaseVariables.WsDatabase, UIVariables.edited_View[8]);

            //// Save data from service 31 to the database
            //DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[10];
            //Model_SaveDatabaseService31.SaveDatabaseService31(DatabaseVariables.WsDatabase, UIVariables.edited_View[9]);

            // Save data from service 3E to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[11];
            Model_SaveDatabaseService3E.SaveDatabaseService3E(DatabaseVariables.WsDatabase, UIVariables.edited_View[10]);

            // Save data from service 85 to the database
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase.Sheets[12];
            Model_SaveDatabaseService85.SaveDatabaseService85(DatabaseVariables.WsDatabase, UIVariables.edited_View[11]);

            // Save the database
            Controller_ExcelHandling.SaveExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);

            Console.WriteLine(SystemVariables.checkDBVariableDefinitionStatus);
            if (!SystemVariables.checkDBVariableDefinitionStatus)
            {
                Controller_UIHandling.MappingFromDatabaseFileToDatabaseVariables();
            }
           

            // After Handling, close the template file
            Controller_ExcelHandling.CloseExcel(SystemVariables.PathOutputDatabase, DatabaseVariables.WbDatabase);
        }
    }
}
