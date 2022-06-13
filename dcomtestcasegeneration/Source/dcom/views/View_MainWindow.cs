using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcom.views.views_Service;
using dcom.views.views_ToolBar;
using dcom.controllers.controllers_middleware;
using dcom.controllers.controllers_UIcontainer;
using dcom.declaration;
using System.DirectoryServices.AccountManagement;
using dcom.models.models_systemHandling;

namespace dcom.views
{
    public partial class View_MainWindow : Form
    {
        public static int buttonHoverMargin = 2;
        public static int buttonLeaveMargin = 10;
        public View_MainWindow()
        {
            InitializeComponent();
            SystemVariables.checkTheFirstLoad = true;
            
        }

        private void View_MainWindow_Load(object sender, EventArgs e)
        {
            // Load home page
            View_Home frm = new View_Home();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);
        }
        private void button_service10_MouseHover(object sender, EventArgs e)
        {
            button_service10.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service10_MouseLeave(object sender, EventArgs e)
        {
            button_service10.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service11_MouseHover(object sender, EventArgs e)
        {
            button_service11.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service11_MouseLeave(object sender, EventArgs e)
        {
            button_service11.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service14_MouseHover(object sender, EventArgs e)
        {
            button_service14.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service14_MouseLeave(object sender, EventArgs e)
        {
            button_service14.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service19_MouseHover(object sender, EventArgs e)
        {
            button_service19.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service19_MouseLeave(object sender, EventArgs e)
        {
            button_service19.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service22_MouseHover(object sender, EventArgs e)
        {
            button_service22.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service22_MouseLeave(object sender, EventArgs e)
        {
            button_service22.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service27_MouseHover(object sender, EventArgs e)
        {
            button_service27.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service27_MouseLeave(object sender, EventArgs e)
        {
            button_service27.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service28_MouseHover(object sender, EventArgs e)
        {
            button_service28.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service28_MouseLeave(object sender, EventArgs e)
        {
            button_service28.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service2e_MouseHover(object sender, EventArgs e)
        {
            button_service2e.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service2e_MouseLeave(object sender, EventArgs e)
        {
            button_service2e.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_canTP_MouseHover(object sender, EventArgs e)
        {
            button_canTP.Margin = new Padding(buttonHoverMargin);

        }

        private void button_canTP_MouseLeave(object sender, EventArgs e)
        {
            button_canTP.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service31_MouseHover(object sender, EventArgs e)
        {
            button_service31.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service31_MouseLeave(object sender, EventArgs e)
        {
            button_service31.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service3e_MouseHover(object sender, EventArgs e)
        {
            button_service3e.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service3e_MouseLeave(object sender, EventArgs e)
        {
            button_service3e.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_service85_MouseHover(object sender, EventArgs e)
        {
            button_service85.Margin = new Padding(buttonHoverMargin);

        }

        private void button_service85_MouseLeave(object sender, EventArgs e)
        {
            button_service85.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_play_MouseHover(object sender, EventArgs e)
        {
            button_play.Margin = new Padding(buttonHoverMargin);

        }

        private void button_play_MouseLeave(object sender, EventArgs e)
        {
            button_play.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_save_MouseHover(object sender, EventArgs e)
        {
            button_save.Margin = new Padding(buttonHoverMargin);

        }

        private void button_save_MouseLeave(object sender, EventArgs e)
        {
            button_save.Margin = new Padding(buttonLeaveMargin);

        }

        private void button_setting_MouseHover(object sender, EventArgs e)
        {
            button_setting.Margin = new Padding(buttonHoverMargin);

        }

        private void button_setting_MouseLeave(object sender, EventArgs e)
        {
            button_setting.Margin = new Padding(buttonLeaveMargin);

        }
        private void button_home_MouseHover(object sender, EventArgs e)
        {
            button_home.Margin = new Padding(buttonHoverMargin);
        }

        private void button_home_MouseLeave(object sender, EventArgs e)
        {
            button_home.Margin = new Padding(buttonLeaveMargin);
        }
        private void button_home_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Home frm = new View_Home();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }
        private void button_setting_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (SystemVariables.checkTheFirstLoad == true)
            {
                Model_BackupInformation.BackupInformation();
            }
            View_Setting_Testcase frm = new View_Setting_Testcase();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Controllers_FunctionButton.ButtonExportClick();

            Cursor = Cursors.Default;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            Controllers_FunctionButton.ButtonSaveClick();

            Cursor = Cursors.Default;
        }

        private void button_service10_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service10 frm = new View_Service10();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service11_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service11 frm = new View_Service11();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service14_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service14 frm = new View_Service14();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service19_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service19 frm = new View_Service19();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service22_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service22 frm = new View_Service22();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service27_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service27 frm = new View_Service27();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service28_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service28 frm = new View_Service28();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service2e_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service2E frm = new View_Service2E();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_canTP_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_CanTP frm = new View_CanTP();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service31_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service31 frm = new View_Service31();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service3e_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service3E frm = new View_Service3E();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_service85_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            View_Service85 frm = new View_Service85();
            Controller_UIHandling.ShowUserControl(panel_bodyMain, frm);

            Cursor = Cursors.Default;
        }

        private void button_homepage_goToSetting_Click(object sender, EventArgs e)
        {
            button_setting.PerformClick();
        }

  
    }
}
