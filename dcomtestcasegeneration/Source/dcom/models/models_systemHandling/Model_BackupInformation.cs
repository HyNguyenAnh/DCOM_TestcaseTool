using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.models.models_systemHandling;
using dcom.controllers.controllers_middleware;
using dcom.declaration;
using System.Windows.Forms;
using System.IO;
using dcom.controllers.controllers_UIcontainer;

namespace dcom.models.models_systemHandling
{
    class Model_BackupInformation
    {
        public static void BackupInformation()
        {
            if (File.Exists(SystemVariables.backupFilePath))
            {
                MessageBoxButtons btn = MessageBoxButtons.YesNo;
                DialogResult res = MessageBox.Show("Would you want to load the last recent database?", "Notice", btn);

                if (res == DialogResult.Yes)
                {
                    // Get the last recent database path from backup file
                    Model_SystemInformation.readBackupFile(SystemVariables.backupFilePath);

                    // Load data from database
                    string databasePath = UIVariables.DatabasePath;
                    Controllers_FunctionButton.ButtonLoadDataClick(databasePath);
                    SystemVariables.checkTheFirstLoad = false;

                }
                else
                {
                    SystemVariables.checkTheFirstLoad = false;
                    // Close the pop-up
                }
            }
            else
            {
                MessageBoxButtons btn_ = MessageBoxButtons.OK;
                MessageBox.Show("You don't have backup file", "Notice", btn_);
                SystemVariables.checkTheFirstLoad = false;
                // Close the pop-up
            }
        }
    }
}
