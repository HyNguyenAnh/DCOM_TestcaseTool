using dcom.controllers.controllers_middleware;
using dcom.declaration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcom.models.models_systemHandling;

namespace dcom.views.views_ToolBar
{
    public partial class View_Home : UserControl
    {
        public View_Home()
        {
            InitializeComponent();

        }

        private void button_homepage_goToSetting_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show("Would you want to load the last recent database?", "Notice", btn);

            if (res == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;

                //this.button_setting.PerformClick();
                Definition.SystemVariableDefinition();
                Model_SystemInformation.readBackupFile();
                string databasePath = DatabaseVariables.DatabasePath;
                DatabaseVariables.WbDatabase = Controller_ExcelHandling.OpenExcel(databasePath);

                Definition.DatabaseVariableDefinition();

                // Close the database
                Controller_ExcelHandling.CloseExcel(databasePath, DatabaseVariables.WbDatabase);

                Cursor = Cursors.Default;
            }
            else
            {
                // Close the pop-up
            }

            View_MainWindow view_MainWindow = (View_MainWindow)this?.Parent?.Parent?.Parent?.Parent;
            view_MainWindow.button_setting.PerformClick();
        }
    }
}
