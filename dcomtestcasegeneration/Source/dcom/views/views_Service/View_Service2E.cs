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
            UIVariables.CompletedEdit = false;
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
                textBox_ConditionVehicle,
            };

            ButtonStatus_SecurityUnlock = button_SecurityUnlock;
            ComboBox_SecurityUnlock = comboBox_SecurityUnlockLevel;

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
            comboBox_SecurityUnlockLevel.Enabled = UIVariables.Service2E_ButtonStatus_SecurityUnlock;
            textBox_ConditionVehicle.Enabled = UIVariables.Service2E_ButtonStatus_Condition[0];
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

        private void button_SecurityUnlock_Click(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = !UIVariables.Service2E_ButtonStatus_SecurityUnlock;

            button_SecurityUnlock.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[0];
            button_SecurityUnlock.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock)[1];
            button_SecurityUnlock.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service2E_ButtonStatus_SecurityUnlock);
        }

        private void button_SecurityUnlock_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = Controller_ServiceHandling.ConvertFromStatusToBool(button_SecurityUnlock.Text);
            Console.WriteLine(button_SecurityUnlock.Text);
            if (UIVariables.Service2E_ButtonStatus_SecurityUnlock == true)
            {
                comboBox_SecurityUnlockLevel.Enabled = true;
                comboBox_SecurityUnlockLevel.Text = UIVariables.Service2E_SecurityUnlockLv;
            }
            else
            {
                comboBox_SecurityUnlockLevel.Enabled = false;
                comboBox_SecurityUnlockLevel.Text = "Level";
            }
        }

        private void textBox_ConditionVehicle_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service2E_InvalidValueCondition[0] = textBox_ConditionVehicle.Text;
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

        private void dataGridView_DIDTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.ThrowException = true;
            //if (e.Exception.Message == "DataGridView Default Error Dialog")
            //{
            //    object value = dataGridView_DIDTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    if (!((DataGridViewCheckBoxColumn)dataGridView_DIDTable.Columns[e.ColumnIndex]).Items.Contains(value))
            //    {

            //    }
            //}
            //e.Cancel = true;
        }

        private void comboBox_SecurityUnlockLevel_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service2E_ButtonStatus_SecurityUnlock == true)
            {
                UIVariables.Service2E_SecurityUnlockLv = comboBox_SecurityUnlockLevel.Text;
            }
        }

    }
}
