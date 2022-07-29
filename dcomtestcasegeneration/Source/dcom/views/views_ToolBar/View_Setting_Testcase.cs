using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcom.controllers.controllers_middleware;
using dcom.controllers.controllers_UIcontainer;
using dcom.declaration;
using dcom.views.views_ToolBar.views_TestcaseTemp;

namespace dcom.views.views_ToolBar
{
    public partial class View_Setting_Testcase : UserControl
    {
        public static int buttonHoverMargin = 2;
        public static int buttonLeaveMargin = 10;
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
        }

        private void InitialDataGridViewCommonSetting()
        {
            Controller_UIHandling.InitialDataGridRows(dataGridView_CommonSetting, 4);
            dataGridView_CommonSetting.Rows[0].Cells[1].Value = "Create_Fault";
            dataGridView_CommonSetting.Rows[1].Cells[1].Value = "Vehicle_Speed";
            dataGridView_CommonSetting.Rows[2].Cells[1].Value = "Engine_Status";
            dataGridView_CommonSetting.Rows[3].Cells[1].Value = "Security_Access";

            dataGridView_CommonSetting.Rows[3].Cells[2].Value = "EnvLogInLevel";

        }

        private void InitialDataGridViewCommonDID()
        {
            Controller_UIHandling.InitialDataGridRows(dataGridView_CommonDID, 3);
            dataGridView_CommonDID.Rows[0].Cells[1].Value = "Current_Session";
            dataGridView_CommonDID.Rows[1].Cells[1].Value = "Invalid_Counter";
            dataGridView_CommonDID.Rows[2].Cells[1].Value = "Current_Voltage";
        }

        private void View_Setting_Testcase_Load(object sender, EventArgs e)
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
                button_SelectService31,
                button_SelectService3E,
                button_SelectService85,
                button_SelectCANTP,
            };

            CommonKeywordInformation = new DataGridView[]{
                dataGridView_CommonSetting,
                dataGridView_CommonDID,
            };

            // Load Project Information
            UIVariables.ProjectInformation = new string[]
            {
                UIVariables.ProjectName,
                UIVariables.Variant,
                UIVariables.Release,
                UIVariables.RC,

            };
            for (int ProjectInformationIndex = 0; ProjectInformationIndex < ProjectInformation.Length; ProjectInformationIndex++)
            {
                ProjectInformation[ProjectInformationIndex].Text = UIVariables.ProjectInformation[ProjectInformationIndex];
            }

            // Load Data Path Information
            radioButton_DBSourceLocal.Checked = Controller_UIHandling.GetDatabaseSource(UIVariables.DatabaseSource);
            radioButton_DBSourceServer.Checked = !Controller_UIHandling.GetDatabaseSource(UIVariables.DatabaseSource);
            if (UIVariables.DatabaseSource.ToLower() == "local")
            {
                if (UIVariables.DBPath_LocalList != null)
                {
                    comboBox_DBPath.Items.Clear();
                    for(int index = 0; index < UIVariables.DBPath_LocalList.Length; index++)
                    {
                        comboBox_DBPath.Items.Add(UIVariables.DBPath_LocalList[index].Split('\\')[UIVariables.DBPath_LocalList[index].Split('\\').Length - 1]);
                    }
                }
                else
                {
                    comboBox_DBPath.Items.Clear();
                }
            }
            else
            {
                if (UIVariables.DBPath_ServerList != null)
                {
                    comboBox_DBPath.Items.Clear();
                    for (int index = 0; index < UIVariables.DBPath_ServerList.Length; index++)
                    {
                        comboBox_DBPath.Items.Add(UIVariables.DBPath_ServerList[index].Split('\\')[UIVariables.DBPath_ServerList[index].Split('\\').Length - 1]);
                    }
                }
                else
                {
                    comboBox_DBPath.Items.Clear();
                }
            }
            comboBox_DBPath.Text = UIVariables.DatabasePath;
            textBox_TestcaseDirectory.Text = UIVariables.TestcaseDirectory;


            // Load Selected Service

            for (int selectedServiceIndex = 0; selectedServiceIndex < UIVariables.SelectedServiceStatus.Length; selectedServiceIndex++)
            {
                SelectedServiceInformation[selectedServiceIndex].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[selectedServiceIndex])[0];
                SelectedServiceInformation[selectedServiceIndex].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[selectedServiceIndex])[1];
            }

            // Load Common Keyword Information
            List<string[]> DatabaseCommonSetting = UIVariables.DatabaseCommonSetting;
            List<string[]> DatabaseCommonDID = UIVariables.DatabaseCommonDID;

            if (DatabaseCommonSetting != null)
            {
                Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonSetting, DatabaseCommonSetting);
            }
            else
            {
                InitialDataGridViewCommonSetting();
            }

            if (DatabaseCommonDID != null)
            {
                Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonDID, DatabaseCommonDID);
            }
            else
            {
                InitialDataGridViewCommonDID();
            }


        }

        private void panel_DBPathBrowse_Click(object sender, EventArgs e)
        {
            comboBox_DBPath.Text = Controller_UIHandling.GetFileDialogPath(comboBox_DBPath.Text);
        }

        private void panel_TestcaseDirectoryBrowse_Click(object sender, EventArgs e)
        {
            textBox_TestcaseDirectory.Text = Controller_UIHandling.GetFolderDialogPath(textBox_TestcaseDirectory.Text);
        }

        private void button_LoadDB_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Get data in databases
            Controllers_FunctionButton.ButtonLoadDataClick(UIVariables.DatabasePath);

            // Push data to Project Information
            textBox_ProjectName.Text = UIVariables.ProjectName;
            textBox_Variant.Text = UIVariables.Variant;
            textBox_Release.Text = UIVariables.Release;
            textBox_RC.Text = UIVariables.RC;

            // Push data to Data Path Information
            radioButton_DBSourceLocal.Checked = Controller_UIHandling.GetDatabaseSource(UIVariables.DatabaseSource);
            radioButton_DBSourceServer.Checked = !Controller_UIHandling.GetDatabaseSource(UIVariables.DatabaseSource);
            textBox_TestcaseDirectory.Text = UIVariables.TestcaseDirectory;

            // Push data to Selected Service Information

            button_SelectService10.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[0])[0];
            button_SelectService10.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[0])[1];

            button_SelectService11.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[1])[0];
            button_SelectService11.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[1])[1];

            button_SelectService14.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[2])[0];
            button_SelectService14.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[2])[1];

            button_SelectService19.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[3])[0];
            button_SelectService19.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[3])[1];

            button_SelectService22.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[4])[0];
            button_SelectService22.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[4])[1];

            button_SelectService27.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[5])[0];
            button_SelectService27.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[5])[1];

            button_SelectService28.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[6])[0];
            button_SelectService28.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[6])[1];

            button_SelectService2E.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[7])[0];
            button_SelectService2E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[7])[1];

            button_SelectCANTP.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[8])[0];
            button_SelectCANTP.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[8])[1];

            button_SelectService31.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[9])[0];
            button_SelectService31.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[9])[1];

            button_SelectService3E.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[10])[0];
            button_SelectService3E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[10])[1];

            button_SelectService85.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[11])[0];
            button_SelectService85.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[11])[1];



            // Push data to Common Setting
            
            List<string[]> DatabaseCommonSetting = UIVariables.DatabaseCommonSetting;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonSetting, DatabaseCommonSetting);
            
            // Push data to Common DID
            List<string[]> DatabaseCommonDID = UIVariables.DatabaseCommonDID;
            Controller_UIHandling.PutDatabaseToDataGridView(dataGridView_CommonDID, DatabaseCommonDID);

            dataGridView_CommonSetting.Enabled = true;
            dataGridView_CommonDID.Enabled = true;
            SystemVariables.dbLoadStatus = true;

            Cursor = Cursors.Default;
            MessageBox.Show("The database is loaded successfully");
        }


        private void button_SelectService10_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[0] = !UIVariables.SelectedServiceStatus[0];
            button_SelectService10.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[0])[0];
            button_SelectService10.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[0])[1];
        }

        private void button_SelectService11_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[1] = !UIVariables.SelectedServiceStatus[1];
            button_SelectService11.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[1])[0];
            button_SelectService11.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[1])[1];
        }

        private void button_SelectService14_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[2] = !UIVariables.SelectedServiceStatus[2];

            button_SelectService14.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[2])[0];
            button_SelectService14.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[2])[1];
        }

        private void button_SelectService19_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[3] = !UIVariables.SelectedServiceStatus[3];

            button_SelectService19.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[3])[0];
            button_SelectService19.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[3])[1];
        }

        private void button_SelectService22_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[4] = !UIVariables.SelectedServiceStatus[4];

            button_SelectService22.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[4])[0];
            button_SelectService22.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[4])[1];
        }

        private void button_SelectService27_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[5] = !UIVariables.SelectedServiceStatus[5];

            button_SelectService27.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[5])[0];
            button_SelectService27.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[5])[1];
        }

        private void button_SelectService28_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[6] = !UIVariables.SelectedServiceStatus[6];

            button_SelectService28.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[6])[0];
            button_SelectService28.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[6])[1];
        }

        private void button_SelectService2E_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[7] = !UIVariables.SelectedServiceStatus[7];

            button_SelectService2E.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[7])[0];
            button_SelectService2E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[7])[1];
        }

        private void button_SelectService31_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[8] = !UIVariables.SelectedServiceStatus[8];

            button_SelectService31.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[8])[0];
            button_SelectService31.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[8])[1];
        }

        private void button_SelectService3E_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[9] = !UIVariables.SelectedServiceStatus[9];

            button_SelectService3E.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[9])[0];
            button_SelectService3E.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[9])[1];

        }

        private void button_SelectService85_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[10] = !UIVariables.SelectedServiceStatus[10];

            button_SelectService85.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[10])[0];
            button_SelectService85.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[10])[1];
        }

        private void button_SelectCANTP_Click(object sender, EventArgs e)
        {
            UIVariables.SelectedServiceStatus[11] = !UIVariables.SelectedServiceStatus[11];

            button_SelectCANTP.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[11])[0];
            button_SelectCANTP.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.SelectedServiceStatus[11])[1];
        }

        private void comboBox_DBPath_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.DatabaseSource == "Local" && comboBox_DBPath.Text.Split('\\').Length == 1)
            {
                button_LoadDB.Enabled = Controller_FileHandling.IsFileExisted(string.Concat(UIVariables.LocalDatabaseDirectory, $@"\{comboBox_DBPath.Text}")) & comboBox_DBPath.Text.Contains(".xls");
                UIVariables.DatabasePath = string.Concat(UIVariables.LocalDatabaseDirectory, $@"\{comboBox_DBPath.Text}");
            }
            else if (UIVariables.DatabaseSource == "Server" && comboBox_DBPath.Text.Split('\\').Length == 1)
            {
                button_LoadDB.Enabled = Controller_FileHandling.IsFileExisted(string.Concat(UIVariables.ServerDatabaseDirectory, $@"\{comboBox_DBPath.Text}")) & comboBox_DBPath.Text.Contains(".xls");
                UIVariables.DatabasePath = string.Concat(UIVariables.ServerDatabaseDirectory, $@"\{comboBox_DBPath.Text}");
            }
            else
            {
                button_LoadDB.Enabled = Controller_FileHandling.IsFileExisted(comboBox_DBPath.Text) & comboBox_DBPath.Text.Contains(".xls");
                UIVariables.DatabasePath = comboBox_DBPath.Text;
            }
        }

        private void textBox_ProjectName_TextChanged(object sender, EventArgs e)
        {
            UIVariables.ProjectName = textBox_ProjectName.Text;
        }

        private void textBox_Variant_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Variant = textBox_Variant.Text;

        }

        private void textBox_Release_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Release = textBox_Release.Text;

        }

        private void textBox_RC_TextChanged(object sender, EventArgs e)
        {
            UIVariables.RC = textBox_RC.Text;

        }

        private void textBox_TestcaseDirectory_TextChanged(object sender, EventArgs e)
        {
            UIVariables.TestcaseDirectory = textBox_TestcaseDirectory.Text;
            TestcaseVariables.DirectoryOutputTestcase = textBox_TestcaseDirectory.Text;
        }

        private void dataGridView_CommonSetting_SelectionChanged(object sender, EventArgs e)
        {
            if (SystemVariables.dbLoadStatus)
            {
                Console.WriteLine("complete save dtgv");
                Controller_UIHandling.SaveDataGridViewToDatabase(dataGridView_CommonSetting, UIVariables.DatabaseCommonSetting);
            }
        }

        private void dataGridView_CommonDID_SelectionChanged(object sender, EventArgs e)
        {
            if (SystemVariables.dbLoadStatus)
            {
                Controller_UIHandling.SaveDataGridViewToDatabase(dataGridView_CommonDID, UIVariables.DatabaseCommonDID);
            }
        }

        private void button_service10_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service11_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service11_Tc frm = new View_Service11_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service14_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service19_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service22_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service27_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service28_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service2e_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service31_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service3e_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service85_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_canTP_tc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //View_Service10_Tc frm = new View_Service10_Tc();
            //Controller_UIHandling.ShowUserControl(panel_bodyTestcase, frm);

            Cursor = Cursors.Default;
        }

        private void button_service10_tc_MouseHover(object sender, EventArgs e)
        {
            button_service10_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service11_tc_MouseHover(object sender, EventArgs e)
        {
            button_service11_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service14_tc_MouseHover(object sender, EventArgs e)
        {
            button_service14_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service19_tc_MouseHover(object sender, EventArgs e)
        {
            button_service19_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service22_tc_MouseHover(object sender, EventArgs e)
        {
            button_service22_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service27_tc_MouseHover(object sender, EventArgs e)
        {
            button_service27_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service28_tc_MouseHover(object sender, EventArgs e)
        {
            button_service28_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service2e_tc_MouseHover(object sender, EventArgs e)
        {
            button_service2e_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service31_tc_MouseHover(object sender, EventArgs e)
        {
            button_service31_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service3e_tc_MouseHover(object sender, EventArgs e)
        {
            button_service3e_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service85_tc_MouseHover(object sender, EventArgs e)
        {
            button_service85_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_canTP_tc_MouseHover(object sender, EventArgs e)
        {
            button_canTP_tc.Margin = new Padding(buttonHoverMargin);
        }

        private void button_service10_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service10_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service11_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service11_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service14_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service14_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service19_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service19_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service22_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service22_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service27_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service27_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service28_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service28_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service2e_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service2e_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service31_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service31_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service3e_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service3e_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_service85_tc_MouseLeave(object sender, EventArgs e)
        {
            button_service85_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void button_canTP_tc_MouseLeave(object sender, EventArgs e)
        {
            button_canTP_tc.Margin = new Padding(buttonLeaveMargin);
        }

        private void radioButton_DBSourceLocal_Click(object sender, EventArgs e)
        {
            UIVariables.DatabaseSource = "Local";
            UIVariables.DBPath_LocalList = Directory.GetFiles(UIVariables.LocalDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);
            LoadDBPath(UIVariables.DBPath_LocalList);
        }

        private void radioButton_DBSourceServer_Click(object sender, EventArgs e)
        {
            UIVariables.DatabaseSource = "Server";
            UIVariables.DBPath_ServerList = Directory.GetFiles(UIVariables.ServerDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);
            LoadDBPath(UIVariables.DBPath_ServerList);
        }

        private void comboBox_DBPath_Click(object sender, EventArgs e)
        {

            UIVariables.DBPath_LocalList = Directory.GetFiles(UIVariables.LocalDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);
            UIVariables.DBPath_ServerList = Directory.GetFiles(UIVariables.ServerDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);

            if (UIVariables.DatabaseSource == "Local")
            {
                LoadDBPath(UIVariables.DBPath_LocalList);
            }
            else
            {
                LoadDBPath(UIVariables.DBPath_ServerList);
            }
        }

        private void LoadDBPath(string[] pathList)
        {
            comboBox_DBPath.Items.Clear();
            if (pathList != null)
            {
                comboBox_DBPath.Text = "";
                for (int index = 0; index < pathList.Length; index++)
                {
                    if (!pathList[index].Contains("~$"))
                    {
                        comboBox_DBPath.Items.Add(pathList[index].Split('\\')[pathList[index].Split('\\').Length - 1]);
                    }
                }
            }
        }

    }
}
