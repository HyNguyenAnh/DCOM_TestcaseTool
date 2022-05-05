using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            View_MainWindow view_MainWindow = (View_MainWindow)this?.Parent?.Parent?.Parent?.Parent;
            view_MainWindow.button_setting.PerformClick();
        }
    }
}
