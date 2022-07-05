﻿using dcom.controllers.controllers_middleware;
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
            Model_SystemInformation.createFolder(UIVariables.TestcaseDirectory);
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
            Model_SystemInformation.createFolder(DatabaseVariables.DirectoryOutputDatabase);
            Model_DatabaseTemplate.SaveDatabase();
            Model_SystemInformation.createBackupFile();
        }

        public static void ButtonLoadDataClick()
        {
            string databasePath = UIVariables.DatabasePath;
            
            // Open the database
            DatabaseVariables.WbDatabase = Controller_ExcelHandling.OpenExcel(databasePath);

            Definition.DatabaseVariableDefinition();
            Definition.UIVariableDefinition();
            Controller_UIHandling.MappingFromDatabaseToUI();

            // Close the database
            Controller_ExcelHandling.CloseExcel(databasePath, DatabaseVariables.WbDatabase);
        }
    }
}
