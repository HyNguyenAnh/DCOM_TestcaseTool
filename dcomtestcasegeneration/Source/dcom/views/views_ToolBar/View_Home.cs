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
            Cursor = Cursors.WaitCursor;
            Definition.SystemVariableDefinition();
            Model_SystemInformation.createFolder(OutputVariables.DirectoryOutputDatabase);
            Model_SystemInformation.checkTemplateFile(SystemVariables.templateFileLocalPath, SystemVariables.templateFileServerPath);
            

            if (SystemVariables.checkTheFirstLoad == true)
            {
                Model_BackupInformation.BackupInformation();
            }
            tableLayoutPanel_pointerRight.Visible = true;
            tableLayoutPanel_pointerLeft.Visible = true;
            View_MainWindow view_MainWindow = (View_MainWindow)this?.Parent?.Parent?.Parent?.Parent;
            view_MainWindow.tableLayoutPanel_bodyLeft.Show();
            view_MainWindow.tableLayoutPanel_bodyRight.Show();


            view_MainWindow.button_setting.PerformClick();
            SystemVariables.dbLoadStatus = true;
            Cursor = Cursors.Default;
        }

        private void View_Home_Load(object sender, EventArgs e)
        {
            View_MainWindow view_MainWindow = (View_MainWindow)this?.Parent?.Parent?.Parent?.Parent;
            view_MainWindow.tableLayoutPanel_bodyLeft.Hide();
            view_MainWindow.tableLayoutPanel_bodyRight.Hide();
            tableLayoutPanel_pointerRight.Visible = false;
        }
    }
}
