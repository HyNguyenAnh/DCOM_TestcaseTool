using dcom.controllers.controllers_middleware;
using dcom.declaration;
using dcom.models.models_databaseHandling.models_getDatabase;
using dcom.models.models_testcaseHandling;
using dcom.models.models_databaseHandling.models_saveDatabase;
using dcom.models.models_systemHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcom.controllers.controllers_UIcontainer
{
    class Controllers_FunctionButton
    {
        public static void ButtonExportClick()
        {
            Definition.TestcaseVariableDefinition();
            Model_SystemInformation.createFolder(UIVariables.TestcaseDirectory);
            
            Model_TestcaseTemplate.ExportTestcase();

        }

        public static void ButtonSaveClick()
        {
            Definition.OutputVariablesDefinition();
            Model_DatabaseTemplate.SaveDatabase();
            Model_SystemInformation.createBackupFile(SystemVariables.backupFilePath);
            Controller_UIHandling.MappingFromUIToDatabase(UIVariables.edited_View);
        }

        public static void ButtonLoadDataClick(string databasePath)
        {
            // Open the database
            Controller_ExcelHandling.OpenExcel(databasePath, DatabaseVariables.WbDatabase);
            try
            {
                Controller_UIHandling.MappingFromDatabaseFileToDatabaseVariables();
                Controller_UIHandling.MappingFromDatabaseToUI();

                // Close the database
                Controller_ExcelHandling.CloseExcel(databasePath, DatabaseVariables.WbDatabase);
            }
            catch(Exception e)
            {
                // Close the database
                Controller_ExcelHandling.CloseExcel(databasePath, DatabaseVariables.WbDatabase);

                MessageBoxButtons btn_ = MessageBoxButtons.OK;
                MessageBox.Show($"{e}", "Notice", btn_, MessageBoxIcon.Warning);
            }
        }
    }
}
