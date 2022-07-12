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
    public partial class View_Service22 : UserControl
    {
        public static Button[] ButtonStatus_AllowSession;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriority;
        public static TextBox[] InvalidValue_Condition;
        public View_Service22()
        {
            InitializeComponent();
        }

        private void View_Service22_Load(object sender, EventArgs e)
        {
            // Initial 100 empty row for the DID table
            Controller_UIHandling.InitialDataGridRows(dataGridView_DIDTable, 100);

            // Definition

            ButtonStatus_AllowSession = new Button[]
            {
                button_AllowDefault,
                button_AllowProgramming,
                button_AllowExtended,
            };

            ButtonStatus_Condition = new Button[]
            {
                button_ConditionVehicleSpeed,
                button_ConditionEngine,
                button_ConditionVoltage,
            };

            ComboBox_ConditionNRCs = new ComboBox[]
            {
                comboBox_ConditionVehicle_NRC,
                comboBox_ConditionEngine_NRC,
                comboBox_ConditionVoltage_NRC,
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
                textBox_ConditionEngine_InvalidValue,
                textBox_ConditionVoltage_Low,
                textBox_ConditionVoltage_High,
            };

            // Load elements to comboBox
            string[] NRCs = UIVariables.NRCs;
            for (int index = 0; index < ComboBox_ConditionNRCs.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToComboBox(ComboBox_ConditionNRCs[index], NRCs);
                ComboBox_ConditionNRCs[index].Text = UIVariables.Service22_NRCCondition[index];
                ComboBox_ConditionNRCs[index].Enabled = UIVariables.Service22_ButtonStatus_Condition[index];
            }

            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPriority.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPriority[index], NRCs);
                dataGridView_NRCPriority.Rows[0].Cells[index].Value = UIVariables.Service22_NRCPriority[index];
            }

            // Load Allow Session
            for (int index = 0; index < ButtonStatus_AllowSession.Length; index++)
            {
                ButtonStatus_AllowSession[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[index])[0];
                ButtonStatus_AllowSession[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[index])[1];
                ButtonStatus_AllowSession[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[index]);
            }

            // Load Condition

            for (int index = 0; index < InvalidValue_Condition.Length; index++)
            {
                InvalidValue_Condition[index].Text = UIVariables.Service22_InvalidValueCondition[index];
            }
            textBox_ConditionEngine_ValidValue.Text = UIVariables.Service22_ValidValueCondition;
            for (int index = 0; index < ButtonStatus_Condition.Length; index++)
            {
                ButtonStatus_Condition[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[index])[0];
                ButtonStatus_Condition[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[index])[1];
                ButtonStatus_Condition[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[index]);
            }

            // Load data to DataGridView
            Controller_UIHandling.PutDatabaseToDataGridView_SpecialCase(dataGridView_DIDTable, UIVariables.Service22_DIDTable_Specification, UIVariables.Service22_DIDTable_AllowSessionAddressingMode);

            // Set initial
            textBox_ConditionVehicle.Enabled = UIVariables.Service22_ButtonStatus_Condition[0];
            textBox_ConditionEngine_InvalidValue.Enabled = UIVariables.Service22_ButtonStatus_Condition[1];
            textBox_ConditionEngine_ValidValue.Enabled = UIVariables.Service22_ButtonStatus_Condition[1];
            textBox_ConditionVoltage_Low.Enabled = UIVariables.Service22_ButtonStatus_Condition[2];
            textBox_ConditionVoltage_High.Enabled = UIVariables.Service22_ButtonStatus_Condition[2];
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

        private void button_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[0] = !UIVariables.Service22_ButtonStatus_Condition[0];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[0])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[0])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[0]);

        }

        private void button_ConditionEngine_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[1] = !UIVariables.Service22_ButtonStatus_Condition[1];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[1])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[1])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[1]);
        }

        private void button_ConditionVoltage_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[2] = !UIVariables.Service22_ButtonStatus_Condition[2];

            button_ConditionVoltage.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[2])[0];
            button_ConditionVoltage.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[2])[1];
            button_ConditionVoltage.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_Condition[2]);
        }

        private void button_AllowDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[0] = !UIVariables.Service22_ButtonStatus_AllowSession[0];

            button_AllowDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[0])[0];
            button_AllowDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[0])[1];
            button_AllowDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[0]);
        }

        private void button_AllowProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[1] = !UIVariables.Service22_ButtonStatus_AllowSession[1];

            button_AllowProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[1])[0];
            button_AllowProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[1])[1];
            button_AllowProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[1]);
        }

        private void button_AllowExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[2] = !UIVariables.Service22_ButtonStatus_AllowSession[2];

            button_AllowExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[2])[0];
            button_AllowExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[2])[1];
            button_AllowExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service22_ButtonStatus_AllowSession[2]);
        }

        private void dataGridView_NRCPriority_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_AllowDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_AllowDefault.Text);
        }

        private void button_AllowProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_AllowProgramming.Text);
        }

        private void button_AllowExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_AllowSession[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_AllowExtended.Text);
        }

        private void button_ConditionVehicleSpeed_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVehicleSpeed.Text);
            if (UIVariables.Service22_ButtonStatus_Condition[0] == true)
            {
                comboBox_ConditionVehicle_NRC.Enabled = true;
                textBox_ConditionVehicle.Enabled = true;
                comboBox_ConditionVehicle_NRC.Text = UIVariables.Service22_NRCCondition[0];
                textBox_ConditionVehicle.Text = UIVariables.Service22_InvalidValueCondition[0];
            }
            else
            {
                comboBox_ConditionVehicle_NRC.Enabled = false;
                textBox_ConditionVehicle.Enabled = false;
                comboBox_ConditionVehicle_NRC.Text = "NRC";
                textBox_ConditionVehicle.Text = "...km/h";
            }
        }

        private void button_ConditionEngine_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionEngine.Text);
            if (UIVariables.Service22_ButtonStatus_Condition[1] == true)
            {
                comboBox_ConditionEngine_NRC.Enabled = true;
                comboBox_ConditionEngine_NRC.Text = UIVariables.Service22_NRCCondition[1];
                textBox_ConditionEngine_InvalidValue.Enabled = true;
                textBox_ConditionEngine_InvalidValue.Text = UIVariables.Service22_InvalidValueCondition[1];
                textBox_ConditionEngine_ValidValue.Enabled = true;
                textBox_ConditionEngine_ValidValue.Text = UIVariables.Service22_ValidValueCondition;
            }
            else
            {
                comboBox_ConditionEngine_NRC.Enabled = false;
                comboBox_ConditionEngine_NRC.Text = "NRC";
                textBox_ConditionEngine_InvalidValue.Enabled = false;
                textBox_ConditionEngine_InvalidValue.Text = "Example: 1(Crank); 2(Running); 3(Reverse); 0(Stop)...";
                textBox_ConditionEngine_ValidValue.Enabled = false;
                textBox_ConditionEngine_ValidValue.Text = "...";
            }
        }

        private void button_ConditionVoltage_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service22_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVoltage.Text);
            if (UIVariables.Service22_ButtonStatus_Condition[2] == true)
            {
                comboBox_ConditionVoltage_NRC.Enabled = true;
                textBox_ConditionVoltage_Low.Enabled = true;
                textBox_ConditionVoltage_High.Enabled = true;
                comboBox_ConditionVoltage_NRC.Text = UIVariables.Service22_NRCCondition[2];
                textBox_ConditionVoltage_Low.Text = UIVariables.Service22_InvalidValueCondition[2];
                textBox_ConditionVoltage_High.Text = UIVariables.Service22_InvalidValueCondition[3];
            }
            else
            {
                comboBox_ConditionVoltage_NRC.Enabled = false;
                textBox_ConditionVoltage_Low.Enabled = false;
                textBox_ConditionVoltage_High.Enabled = false;
                comboBox_ConditionVoltage_NRC.Text = "NRC";
                textBox_ConditionVoltage_Low.Text = "...V";
                textBox_ConditionVoltage_High.Text = "...V";
            }
        }

        private void comboBox_ConditionVehicle_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service22_NRCCondition[0] = comboBox_ConditionVehicle_NRC.Text;
            }
        }

        private void comboBox_ConditionEngine_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service22_NRCCondition[1] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void comboBox_ConditionVoltage_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[2] == true)
            {
                UIVariables.Service22_NRCCondition[2] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void textBox_ConditionVehicle_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service22_InvalidValueCondition[0] = textBox_ConditionVehicle.Text;
            }
        }

        private void textBox_ConditionEngine_InvalidValue_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service22_InvalidValueCondition[1] = textBox_ConditionEngine_InvalidValue.Text;
            }
        }

        private void textBox_ConditionEngine_ValidValue_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service22_ValidValueCondition = textBox_ConditionEngine_ValidValue.Text;
            }
        }

        private void textBox_ConditionVoltage_Low_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[2] == true)
            {
                UIVariables.Service22_InvalidValueCondition[2] = textBox_ConditionVoltage_Low.Text;
            }
        }

        private void textBox_ConditionVoltage_High_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service22_ButtonStatus_Condition[2] == true)
            {
                UIVariables.Service22_InvalidValueCondition[3] = textBox_ConditionVoltage_High.Text;
            }
        }

        private void dataGridView_NRCPriority_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriority, UIVariables.Service22_NRCPriority);
        }

        private void dataGridView_DIDTable_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewToDatabase_SpecialCase(dataGridView_DIDTable, UIVariables.Service22_DIDTable_Specification, UIVariables.Service22_DIDTable_AllowSessionAddressingMode);
        }

    }
}
