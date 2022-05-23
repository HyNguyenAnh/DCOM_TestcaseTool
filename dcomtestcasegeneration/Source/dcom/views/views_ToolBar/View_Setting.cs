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
    public partial class View_Setting : UserControl
    {
        public static TextBox[] ProjectInformation;
        public static Button[] SelectedServiceInformation;
        public static DataGridView[] CommonKeywordInformation;
        public View_Setting()
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
        private void panel_DBPathBrowse_Click(object sender, EventArgs e)
        {
            comboBox_DBPath.Text = Controller_UIHandling.GetFileDialogPath(comboBox_DBPath.Text);
        }

        private void panel_PublicCANDBCBrowse_Click(object sender, EventArgs e)
        {
            textBox_PublicCANDBC.Text = Controller_UIHandling.GetFileDialogPath(textBox_PublicCANDBC.Text);
        }

        private void panel_PrivateCANDBCBrowse_Click(object sender, EventArgs e)
        {
            textBox_PrivateCANDBC.Text = Controller_UIHandling.GetFileDialogPath(textBox_PrivateCANDBC.Text);
        }

        private void panel_TestcaseDirectoryBrowse_Click(object sender, EventArgs e)
        {
            textBox_TestcaseDirectory.Text = Controller_UIHandling.GetFolderDialogPath(textBox_TestcaseDirectory.Text);
        }
        
        private void button_LoadDB_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            DatabaseVariables.DatabasePath = comboBox_DBPath.Text;
          
            // Get data in databases
            Controllers_FunctionButton.ButtonLoadDataClick();

            // Push data to Project Information
            textBox_ProjectName.Text = DatabaseVariables.ProjectName;
            textBox_Variant.Text = DatabaseVariables.Variant;
            textBox_Release.Text = DatabaseVariables.Release;
            textBox_RC.Text = DatabaseVariables.RC;

            // Push data to Data Path Information
            radioButton_DBSourceLocal.Checked = Controller_UIHandling.GetDatabaseSource(DatabaseVariables.DatabaseSource);
            radioButton_DBSourceServer.Checked = !Controller_UIHandling.GetDatabaseSource(DatabaseVariables.DatabaseSource);

            textBox_PublicCANDBC.Text = DatabaseVariables.PublicCANDBC;
            textBox_PrivateCANDBC.Text = DatabaseVariables.PrivateCANDBC;
            textBox_TestcaseDirectory.Text = DatabaseVariables.TestcaseDirectory;

            // Push data to Selected Service Information

            button_SelectService10.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[0])[0];
            button_SelectService10.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[0])[1];

            button_SelectService11.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[1])[0];
            button_SelectService11.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[1])[1];

            button_SelectService14.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[2])[0];
            button_SelectService14.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[2])[1];

            button_SelectService19.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[3])[0];
            button_SelectService19.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[3])[1];

            button_SelectService22.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[4])[0];
            button_SelectService22.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[4])[1];

            button_SelectService27.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[5])[0];
            button_SelectService27.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[5])[1];

            button_SelectService28.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[6])[0];
            button_SelectService28.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[6])[1];

            button_SelectService2E.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[7])[0];
            button_SelectService2E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[7])[1];

            button_SelectService2F.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[8])[0];
            button_SelectService2F.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[8])[1];

            button_SelectService31.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[9])[0];
            button_SelectService31.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[9])[1];

            button_SelectService3E.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[10])[0];
            button_SelectService3E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[10])[1];

            button_SelectService85.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[11])[0];
            button_SelectService85.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[11])[1];



            // Push data to Common Setting
            List<string[]> DatabaseCommonSetting = DatabaseVariables.DatabaseCommonSetting;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonSetting, DatabaseCommonSetting);

            // Push data to Common Command
            List<string[]> DatabaseCommonCommand = DatabaseVariables.DatabaseCommonCommand;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonCommand, DatabaseCommonCommand);
            
            // Push data to Common DID
            List<string[]> DatabaseCommonDID = DatabaseVariables.DatabaseCommonDID;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonDID, DatabaseCommonDID);

            Cursor = Cursors.Default;
            MessageBox.Show("The database is loaded successfully");
        }


        private void button_SelectService10_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[0] = !DatabaseVariables.SelectedServiceStatus[0];
            button_SelectService10.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[0])[0];
            button_SelectService10.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[0])[1];
        }

        private void button_SelectService11_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[1] = !DatabaseVariables.SelectedServiceStatus[1];
            button_SelectService11.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[1])[0];
            button_SelectService11.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[1])[1];
        }

        private void button_SelectService14_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[2] = !DatabaseVariables.SelectedServiceStatus[2];

            button_SelectService14.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[2])[0];
            button_SelectService14.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[2])[1];
        }

        private void button_SelectService19_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[3] = !DatabaseVariables.SelectedServiceStatus[3];

            button_SelectService19.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[3])[0];
            button_SelectService19.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[3])[1];
        }

        private void button_SelectService22_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[4] = !DatabaseVariables.SelectedServiceStatus[4];

            button_SelectService22.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[4])[0];
            button_SelectService22.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[4])[1];
        }

        private void button_SelectService27_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[5] = !DatabaseVariables.SelectedServiceStatus[5];

            button_SelectService27.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[5])[0];
            button_SelectService27.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[5])[1];
        }

        private void button_SelectService28_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[6] = !DatabaseVariables.SelectedServiceStatus[6];

            button_SelectService28.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[6])[0];
            button_SelectService28.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[6])[1];
        }

        private void button_SelectService2E_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[7] = !DatabaseVariables.SelectedServiceStatus[7];

            button_SelectService2E.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[7])[0];
            button_SelectService2E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[7])[1];
        }

        private void button_SelectService2F_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[8] = !DatabaseVariables.SelectedServiceStatus[8];

            button_SelectService2F.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[8])[0];
            button_SelectService2F.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[8])[1];
        }

        private void button_SelectService31_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[9] = !DatabaseVariables.SelectedServiceStatus[9];

            button_SelectService31.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[9])[0];
            button_SelectService31.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[9])[1];
        }

        private void button_SelectService3E_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[10] = !DatabaseVariables.SelectedServiceStatus[10];

            button_SelectService3E.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[10])[0];
            button_SelectService3E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[10])[1];

        }

        private void button_SelectService85_Click(object sender, EventArgs e)
        {
            DatabaseVariables.SelectedServiceStatus[11] = !DatabaseVariables.SelectedServiceStatus[11];

            button_SelectService85.BackColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[11])[0];
            button_SelectService85.ForeColor = Controller_UIHandling.GetColorOfStatusButton(DatabaseVariables.SelectedServiceStatus[11])[1];
        }

        private void comboBox_DBPath_TextChanged(object sender, EventArgs e)
        {
            button_LoadDB.Enabled = Controller_FileHandling.IsFileExisted(comboBox_DBPath.Text) & comboBox_DBPath.Text.Contains(".xls");
        }

        private void textBox_ProjectName_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.ProjectName = textBox_ProjectName.Text;
        }

        private void textBox_Variant_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.Variant = textBox_Variant.Text;

        }

        private void textBox_Release_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.Release = textBox_Release.Text;

        }

        private void textBox_RC_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.RC = textBox_RC.Text;

        }

        private void radioButton_DBSourceLocal_CheckedChanged(object sender, EventArgs e)
        {
            DatabaseVariables.DatabaseSource = "Local";
        }

        private void radioButton_DBSourceServer_CheckedChanged(object sender, EventArgs e)
        {
            DatabaseVariables.DatabaseSource = "Server";
        }

        private void textBox_PublicCANDBC_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.PublicCANDBC = textBox_PublicCANDBC.Text;
        }

        private void textBox_PrivateCANDBC_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.PrivateCANDBC = textBox_PrivateCANDBC.Text;
        }

        private void textBox_TestcaseDirectory_TextChanged(object sender, EventArgs e)
        {
            DatabaseVariables.TestcaseDirectory = textBox_TestcaseDirectory.Text;
        }

        private void dataGridView_CommonSetting_SelectionChanged(object sender, EventArgs e)
        {
            //Controller_UIHandling.SaveDataGridViewToDatabase(dataGridView_CommonSetting, DatabaseVariables.DatabaseCommonSetting, 5, 4);
        }

        private void dataGridView_CommonCommand_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewToDatabase(dataGridView_CommonCommand, DatabaseVariables.DatabaseCommonCommand, 3, 3);
        }

        private void dataGridView_CommonDID_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewToDatabase(dataGridView_CommonDID, DatabaseVariables.DatabaseCommonDID, 3, 2);
        }
    }
}
