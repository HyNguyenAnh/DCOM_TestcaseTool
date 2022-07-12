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
    public partial class View_Service27 : UserControl
    {
        public static Button[] ButtonStatus_SubFunction;
        public static Button[] ButtonStatus_AddressingMode;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPrioritySeed;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriorityKey;
        public static TextBox[] InvalidValue_Condition;
        public View_Service27()
        {
            InitializeComponent();
        }

        private void View_Service27_Load(object sender, EventArgs e)
        {
            // Definition

            ButtonStatus_AddressingMode = new Button[]
            {
                button_PhysicalDefault,
                button_PhysicalProgramming,
                button_PhysicalExtended,
                button_FunctionalDefault,
                button_FunctionalProgramming,
                button_FunctionalExtended,
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

            DataGridViewComboBoxColumn_NRCPrioritySeed = new DataGridViewComboBoxColumn[]
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

            DataGridViewComboBoxColumn_NRCPriorityKey = new DataGridViewComboBoxColumn[]
            {
                dataGridViewComboBoxColumn1,
                dataGridViewComboBoxColumn2,
                dataGridViewComboBoxColumn3,
                dataGridViewComboBoxColumn4,
                dataGridViewComboBoxColumn5,
                dataGridViewComboBoxColumn6,
                dataGridViewComboBoxColumn7,
                dataGridViewComboBoxColumn8,
                dataGridViewComboBoxColumn9,
                dataGridViewComboBoxColumn10,
                dataGridViewComboBoxColumn11,
                dataGridViewComboBoxColumn12,
                dataGridViewComboBoxColumn13,
                dataGridViewComboBoxColumn14,
                dataGridViewComboBoxColumn15,
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
                ComboBox_ConditionNRCs[index].Text = UIVariables.Service27_NRCCondition[index];
                ComboBox_ConditionNRCs[index].Enabled = UIVariables.Service27_ButtonStatus_Condition[index];
            }

            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPrioritySeed.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPrioritySeed[index], NRCs);
                dataGridView_NRCPrioritySeed.Rows[0].Cells[index].Value = UIVariables.Service27_NRCPrioritySeed[index];
            }
            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPriorityKey.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPriorityKey[index], NRCs);
                dataGridView_NRCPriorityKey.Rows[0].Cells[index].Value = UIVariables.Service27_NRCPriorityKey[index];
            }

            // Load Addressing Mode

            for (int index = 0; index < ButtonStatus_AddressingMode.Length; index++)
            {
                ButtonStatus_AddressingMode[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[index])[0];
                ButtonStatus_AddressingMode[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[index])[1];
                ButtonStatus_AddressingMode[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[index]);
            }

            // Load Suppress bit

            button_SupressBit.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0])[0];
            button_SupressBit.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0])[1];
            button_SupressBit.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0]);

            // Load Condition

            for (int index = 0; index < InvalidValue_Condition.Length; index++)
            {
                InvalidValue_Condition[index].Text = UIVariables.Service27_InvalidValueCondition[index];
            }
            textBox_ConditionEngine_ValidValue.Text = UIVariables.Service27_ValidValueCondition;
            for (int index = 0; index < ButtonStatus_Condition.Length; index++)
            {
                ButtonStatus_Condition[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[index])[0];
                ButtonStatus_Condition[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[index])[1];
                ButtonStatus_Condition[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[index]);
            }

            // Set initial
            textBox_ConditionVehicle.Enabled = UIVariables.Service27_ButtonStatus_Condition[0];
            textBox_ConditionEngine_InvalidValue.Enabled = UIVariables.Service27_ButtonStatus_Condition[1];
            textBox_ConditionEngine_ValidValue.Enabled = UIVariables.Service27_ButtonStatus_Condition[1];
            textBox_ConditionVoltage_Low.Enabled = UIVariables.Service27_ButtonStatus_Condition[2];
            textBox_ConditionVoltage_High.Enabled = UIVariables.Service27_ButtonStatus_Condition[2];
        }
        private void button_PhysicalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[0] = !UIVariables.Service27_ButtonStatus_AddressingMode[0];

            button_PhysicalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[0])[0];
            button_PhysicalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[0])[1];
            button_PhysicalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[0]);

        }

        private void button_PhysicalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[1] = !UIVariables.Service27_ButtonStatus_AddressingMode[1];

            button_PhysicalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[1])[0];
            button_PhysicalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[1])[1];
            button_PhysicalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[1]);

        }

        private void button_PhysicalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[2] = !UIVariables.Service27_ButtonStatus_AddressingMode[2];

            button_PhysicalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[2])[0];
            button_PhysicalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[2])[1];
            button_PhysicalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[2]);
        }

        private void button_FunctionalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[3] = !UIVariables.Service27_ButtonStatus_AddressingMode[3];

            button_FunctionalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[3])[0];
            button_FunctionalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[3])[1];
            button_FunctionalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[3]);

        }

        private void button_FunctionalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[4] = !UIVariables.Service27_ButtonStatus_AddressingMode[4];

            button_FunctionalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[4])[0];
            button_FunctionalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[4])[1];
            button_FunctionalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[4]);

        }

        private void button_FunctionalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[5] = !UIVariables.Service27_ButtonStatus_AddressingMode[5];

            button_FunctionalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[5])[0];
            button_FunctionalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[5])[1];
            button_FunctionalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_AddressingMode[5]);

        }

        private void button_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Condition[0] = !UIVariables.Service27_ButtonStatus_Condition[0];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[0])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[0])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[0]);

        }

        private void button_ConditionEngine_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Condition[1] = !UIVariables.Service27_ButtonStatus_Condition[1];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[1])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[1])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[1]);
        }

        private void button_ConditionVoltage_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Condition[2] = !UIVariables.Service27_ButtonStatus_Condition[2];

            button_ConditionVoltage.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[2])[0];
            button_ConditionVoltage.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[2])[1];
            button_ConditionVoltage.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Condition[2]);
        }

        private void button_SupressBit_Click(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Optional[0] = !UIVariables.Service27_ButtonStatus_Optional[0];

            button_SupressBit.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0])[0];
            button_SupressBit.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0])[1];
            button_SupressBit.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service27_ButtonStatus_Optional[0]);

        }

        private void dataGridView_CommonSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_PhysicalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_PhysicalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalProgramming.Text);
        }

        private void button_PhysicalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalExtended.Text);
        }

        private void button_FunctionalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[3] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalDefault.Text);
        }

        private void button_FunctionalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[4] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalProgramming.Text);
        }

        private void button_FunctionalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_AddressingMode[5] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalExtended.Text);
        }

        private void dataGridView_NRCPrioritySeed_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPrioritySeed, UIVariables.Service27_NRCPrioritySeed);
        }
        private void dataGridView_NRCPriorityKey_SelectionChanged(object sender, EventArgs e)
        {
            Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriorityKey, UIVariables.Service27_NRCPriorityKey);
        }

        private void button_ConditionVehicleSpeed_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVehicleSpeed.Text);
            if (UIVariables.Service27_ButtonStatus_Condition[0] == true)
            {
                comboBox_ConditionVehicle_NRC.Enabled = true;
                textBox_ConditionVehicle.Enabled = true;
                comboBox_ConditionVehicle_NRC.Text = UIVariables.Service27_NRCCondition[0];
                textBox_ConditionVehicle.Text = UIVariables.Service27_InvalidValueCondition[0];
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
            UIVariables.Service27_ButtonStatus_Condition[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionEngine.Text);
            if (UIVariables.Service27_ButtonStatus_Condition[1] == true)
            {
                comboBox_ConditionEngine_NRC.Enabled = true;
                comboBox_ConditionEngine_NRC.Text = UIVariables.Service27_NRCCondition[1];
                textBox_ConditionEngine_InvalidValue.Enabled = true;
                textBox_ConditionEngine_InvalidValue.Text = UIVariables.Service27_InvalidValueCondition[1];
                textBox_ConditionEngine_ValidValue.Enabled = true;
                textBox_ConditionEngine_ValidValue.Text = UIVariables.Service27_ValidValueCondition;
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
            UIVariables.Service27_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVoltage.Text);
            if (UIVariables.Service27_ButtonStatus_Condition[2] == true)
            {
                comboBox_ConditionVoltage_NRC.Enabled = true;
                textBox_ConditionVoltage_Low.Enabled = true;
                textBox_ConditionVoltage_High.Enabled = true;
                comboBox_ConditionVoltage_NRC.Text = UIVariables.Service27_NRCCondition[2];
                textBox_ConditionVoltage_Low.Text = UIVariables.Service27_InvalidValueCondition[2];
                textBox_ConditionVoltage_High.Text = UIVariables.Service27_InvalidValueCondition[3];
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
            if (UIVariables.Service27_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service27_NRCCondition[0] = comboBox_ConditionVehicle_NRC.Text;
            }
        }

        private void comboBox_ConditionEngine_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service27_NRCCondition[1] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void comboBox_ConditionVoltage_NRC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ConditionVehicle_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service27_InvalidValueCondition[0] = textBox_ConditionVehicle.Text;
            }
        }

        private void textBox_ConditionEngine_InvalidValue_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service27_InvalidValueCondition[1] = textBox_ConditionEngine_InvalidValue.Text;
            }
        }

        private void textBox_ConditionEngine_ValidValue_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service27_ValidValueCondition = textBox_ConditionEngine_ValidValue.Text;
            }
        }

        private void textBox_ConditionVoltage_Low_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[2] == true)
            {
                UIVariables.Service27_InvalidValueCondition[2] = textBox_ConditionVoltage_Low.Text;
            }
        }

        private void textBox_ConditionVoltage_High_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service27_ButtonStatus_Condition[2] == true)
            {
                UIVariables.Service27_InvalidValueCondition[3] = textBox_ConditionVoltage_High.Text;
            }
        }

        private void button_SupressBit_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service27_ButtonStatus_Optional[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_SupressBit.Text);
        }

        private void dataGridView_NRCPrioritySeed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_NRCPriorityKey_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
