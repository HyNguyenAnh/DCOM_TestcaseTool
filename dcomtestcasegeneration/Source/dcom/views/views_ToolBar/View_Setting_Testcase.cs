using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcom.controllers.controllers_middleware;
using dcom.controllers.controllers_UIcontainer;
using dcom.declaration;

namespace dcom.views.views_ToolBar
{
    public partial class View_Setting_Testcase : UserControl
    {
        public static DataGridView[] Setting_Testcase;
        public static DataGridView[] ServiceTestcaseTemp;
        public static DataGridView[] SelectedService;
        public static Button[] SelectedServiceInformation;
        public static DataGridView[] CommonKeywordInformation;
        public static TextBox[] ProjectInformation;
        public View_Setting_Testcase()
        {
            InitializeComponent();
            button_LoadDB.Enabled = false;

            LoadData();
        }
        public void LoadData()
        {
            // Definition
            ProjectInformation = new TextBox[]{
                textBox_ProjectName,
                textBox_Variant,
                textBox_Release,
                textBox_RC
            };


            SelectedServiceInformation = new Button[]{
                button_SelectService10,
                button_SelectService11,
                button_SelectService14,
                button_SelectService19,
                button_SelectService22,
                button_SelectService27,
                button_SelectService28,
                button_SelectService2E,
                button_SelectService2F,
                button_SelectService31,
                button_SelectService3E,
                button_SelectService85,
            };

            CommonKeywordInformation = new DataGridView[]{
                dataGridView_CommonSetting,
                dataGridView_CommonCommand,
                dataGridView_CommonDID
            };

            // Load Project Information

            DatabaseVariables.ProjectInformation = new string[]
            {
                DatabaseVariables.ProjectName,
                DatabaseVariables.Variant,
                DatabaseVariables.Release,
                DatabaseVariables.RC,

            };
            for (int ProjectInformationIndex = 0; ProjectInformationIndex < ProjectInformation.Length; ProjectInformationIndex++)
            {
                ProjectInformation[ProjectInformationIndex].Text = DatabaseVariables.ProjectInformation[ProjectInformationIndex];
            }

            // Load Data Path Information
            radioButton_DBSourceLocal.Checked = Controller_UIHandling.GetDatabaseSource(DatabaseVariables.DatabaseSource);
            radioButton_DBSourceServer.Checked = !Controller_UIHandling.GetDatabaseSource(DatabaseVariables.DatabaseSource);
            comboBox_DBPath.Text = DatabaseVariables.DatabasePath;
            textBox_PublicCANDBC.Text = DatabaseVariables.PublicCANDBC;
            textBox_PrivateCANDBC.Text = DatabaseVariables.PrivateCANDBC;
            textBox_TestcaseDirectory.Text = DatabaseVariables.TestcaseDirectory;


            // Load Selected Service

            for (int selectedServiceIndex = 0; selectedServiceIndex < DatabaseVariables.SelectedServiceStatus.Length; selectedServiceIndex++)
            {
                Console.WriteLine(DatabaseVariables.SelectedServiceStatus[selectedServiceIndex]);
                SelectedServiceInformation[selectedServiceIndex].BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[selectedServiceIndex])[0];
                SelectedServiceInformation[selectedServiceIndex].ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[selectedServiceIndex])[1];
            }

            // Load Common Keyword Information
            List<string[]> DatabaseCommonSetting = DatabaseVariables.DatabaseCommonSetting;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonSetting, DatabaseCommonSetting);

            List<string[]> DatabaseCommonCommand = DatabaseVariables.DatabaseCommonCommand;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonCommand, DatabaseCommonCommand);

            List<string[]> DatabaseCommonDID = DatabaseVariables.DatabaseCommonDID;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonDID, DatabaseCommonDID);
        }
    }
}
