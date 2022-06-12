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

namespace dcom.views.views_Service
{
    public partial class View_Service2E : UserControl
    {
        public static Button ButtonStatus_SecurityUnlock;
        public static ComboBox ComboBox_SecurityUnlock;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriority;
        public static TextBox[] InvalidValue_Condition;
        public View_Service2E()
        {
            InitializeComponent();
        }

        private void View_Service2E_Load(object sender, EventArgs e)
        {
            // Initial 100 empty row for the DID table
            Controller_UIHandling.InitialDataGridRows(dataGridView_DIDTable, 100);
            // Definition

            ButtonStatus_Condition = new Button[]
            {
                button_ConditionVehicleSpeed,
                button_ConditionEngine,
            };

            ComboBox_ConditionNRCs = new ComboBox[]
            {
                comboBox_ConditionVehicle_NRC,
                comboBox_ConditionEngine_NRC,
            };

            DataGridViewComboBoxColumn_NRCPriority = new DataGridViewComboBoxColumn[]
            {
                Column1,
                Column2,
                Column3,
                Column4,
                Column5,
                Column6,
                Column7,
                Column8,
                Column9,
                Column10,
                Column11,
                Column12,
                Column13,
                Column14,
                Column15,
            };

            InvalidValue_Condition = new TextBox[]
            {
                vehicleSpeedValue_Text,
            };

            ButtonStatus_SecurityUnlock = button_SecurityUnlock;
            ComboBox_SecurityUnlock = comboBox_SecurityUnlock;

            // Load elements to comboBox
            string[] NRCs = UIVariables.NRCs;
            for (int index = 0; index < ComboBox_ConditionNRCs.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToComboBox(ComboBox_ConditionNRCs[index], NRCs);
                ComboBox_ConditionNRCs[index].Text = UIVariables.Service2E_NRCCondition[index];
            }

            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPriority.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPriority[index], NRCs);
                dataGridView_NRCPriority.Rows[0].Cells[index].Value = UIVariables.Service2E_NRCPriority[index];
            }

            // Load Condition
            for (int index = 0; index < ButtonStatus_Condition.Length; index++)
            {
                ButtonStatus_Condition[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[index])[0];
                ButtonStatus_Condition[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[index])[1];
                ButtonStatus_Condition[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[index]);
            }

            // Load Invalid Value Condition
            for (int index = 0; index < InvalidValue_Condition.Length; index++)
            {
                InvalidValue_Condition[index].Text = UIVariables.Service2E_InvalidValueCondition[index];
            }

            // Load Security Unlock

            ButtonStatus_SecurityUnlock.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[0];
            ButtonStatus_SecurityUnlock.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[1];
            ButtonStatus_SecurityUnlock.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock);
            Controller_UIHandling.AddArrayElementToComboBox(ComboBox_SecurityUnlock, UIVariables.SecurityUnlockLevel);

            // Load data to DataGridView
            Controller_UIHandling.PutDatabaseToDataGridView_SpecialCase(dataGridView_DIDTable, UIVariables.Service2E_DIDTable_Specification, UIVariables.Service2E_DIDTable_AddressingMode);

            comboBox_ConditionEngine_NRC.Enabled = UIVariables.Service2E_ButtonStatus_Condition[1];
            comboBox_ConditionVehicle_NRC.Enabled = UIVariables.Service2E_ButtonStatus_Condition[0];
            comboBox_SecurityUnlock.Enabled = UIVariables.Service2E_ButtonStatus_SecurityUnlock;
            vehicleSpeedValue_Text.Enabled = UIVariables.Service2E_ButtonStatus_Condition[0];
            dataGridView_DIDTable.Enabled = true;
            dataGridView_NRCPriority.Enabled = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.CutClipboardValue(dataGridView_DIDTable);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.CopyCellsToClipboard(dataGridView_DIDTable);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.PasteClipboardValue(dataGridView_DIDTable);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.DeleteCells(dataGridView_DIDTable);
        }

        private void insertBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.InsertBefore(dataGridView_DIDTable);
        }

        private void insertAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller_UIHandling.InsertAfter(dataGridView_DIDTable);
        }

        private void button_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_Condition[0] = !UIVariables.Service2E_ButtonStatus_Condition[0];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[0])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[0])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[0]);
        }

        private void button_ConditionEngine_Click(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_Condition[1] = !UIVariables.Service2E_ButtonStatus_Condition[1];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[1])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[1])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_Condition[1]);
        }
        private void button_SecurityUnlock_Click(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = !UIVariables.Service2E_ButtonStatus_SecurityUnlock;

            button_SecurityUnlock.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[0];
            button_SecurityUnlock.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[1];
            button_SecurityUnlock.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock);
        }

        private void dataGridView_NRCPriority_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_SecurityUnlock_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = Controller_ServiceHandling.ConvertFromStatusToBool(button_SecurityUnlock.Text);
            if (UIVariables.Service2E_ButtonStatus_SecurityUnlock == true)
            {
                comboBox_SecurityUnlock.Enabled = true;
                comboBox_SecurityUnlock.Text = UIVariables.Service2E_SecurityUnlockLv;
            }
            else
            {
                comboBox_SecurityUnlock.Enabled = false;
                comboBox_SecurityUnlock.Text = "Level";
            }
        }

        private void button_ConditionVehicleSpeed_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVehicleSpeed.Text);
            if (UIVariables.Service2E_ButtonStatus_Condition[0] == true)
            {
                comboBox_ConditionVehicle_NRC.Enabled = true;
                vehicleSpeedValue_Text.Enabled = true;
                comboBox_ConditionVehicle_NRC.Text = UIVariables.Service2E_NRCCondition[0];
                vehicleSpeedValue_Text.Text = UIVariables.Service2E_InvalidValueCondition[0];
            }
            else
            {
                comboBox_ConditionVehicle_NRC.Enabled = false;
                vehicleSpeedValue_Text.Enabled = false;
                comboBox_ConditionVehicle_NRC.Text = "NRC";
                vehicleSpeedValue_Text.Text = "...km/h";
            }
        }
        private void button_ConditionEngine_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_Condition[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionEngine.Text);
            if (UIVariables.Service2E_ButtonStatus_Condition[1] == true)
            {
                comboBox_ConditionEngine_NRC.Enabled = true;
                comboBox_ConditionEngine_NRC.Text = UIVariables.Service2E_NRCCondition[1];
            }
            else
            {
                comboBox_ConditionEngine_NRC.Enabled = false;
                comboBox_ConditionEngine_NRC.Text = "NRC";
            }
        }
        private void comboBox_SecurityUnlock_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_SecurityUnlock == true)
            {
                UIVariables.Service2E_SecurityUnlockLv = comboBox_SecurityUnlock.Text;
                UIVariables.Service2E_ButtonStatus_SecurityUnlock = Controller_ServiceHandling.ConvertFromStringLevelToBool(comboBox_SecurityUnlock.Text);
            }
        }
        private void comboBox_ConditionVehicle_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service2E_NRCCondition[0] = comboBox_ConditionVehicle_NRC.Text;
            }
        }
        private void vehicleSpeedValue_Text_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service2E_InvalidValueCondition[0] = vehicleSpeedValue_Text.Text;
            }
        }

        private void comboBox_ConditionEngine_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service2E_NRCCondition[1] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void dataGridView_NRCPriority_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_NRCPriority.Enabled == true)
            {
                Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriority, UIVariables.Service2E_NRCPriority);
            }
        }

        private void dataGridView_DIDTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_DIDTable.Enabled == true)
            {
                Controller_UIHandling.SaveDataGridViewToDatabase_SpecialCase(dataGridView_DIDTable, UIVariables.Service2E_DIDTable_Specification, UIVariables.Service2E_DIDTable_AddressingMode);
            }
        }
    }
}
