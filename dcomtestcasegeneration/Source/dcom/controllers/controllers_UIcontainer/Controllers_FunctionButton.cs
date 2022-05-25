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
            Model_TestcaseTemplate.ExportTestcase();

            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show("The test case the exported successfully!\nWould you like to open the testcase excel file?", "Notice", btn);
            
            if(res == DialogResult.Yes)
            {
                Process.Start(TestcaseVariables.PathOutputTestcase);
            }
            else
            {
                // Close the pop-up
            }
        }

        public static void ButtonSaveClick()
        {
            Definition.TemplateVariableDefinition();
            Definition.SystemVariableDefinition();
            Model_DatabaseTemplate.SaveDatabase();
            Model_SystemInformation.createBackupFile();
            
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show("The database updated successfully!\nWould you like to open the database excel file?", "Notice", btn);

            if (res == DialogResult.Yes)
            {
                Process.Start(DatabaseVariables.PathOutputDatabase);
            }
            else
            {
                // Close the pop-up
            }
        }

        public static void ButtonLoadDataClick()
        {
            string databasePath = DatabaseVariables.DatabasePath;
            
            // Open the database
            DatabaseVariables.WbDatabase = Controller_ExcelHandling.OpenExcel(databasePath);

            Definition.DatabaseVariableDefinition();
            Definition.UIVariableDefinition();

            // Close the database
            Controller_ExcelHandling.CloseExcel(databasePath, DatabaseVariables.WbDatabase);
        }
    }
}
