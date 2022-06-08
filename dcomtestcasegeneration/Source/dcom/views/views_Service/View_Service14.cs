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
    public partial class View_Service14 : UserControl
    {
        public static Button[] ButtonStatus_SubFunction;
        public static Button ButtonStatus_SuppressBit;
        public static Button[] ButtonStatus_AddressingMode;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriority;
        public static TextBox[] InvalidValue_Condition;
        public View_Service14()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            // Definition

            ButtonStatus_AddressingMode = new Button[]{
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
                VehicleSpeedValue_Text,
            };

            // Load elements to comboBox
            string[] NRCs = UIVariables.NRCs;
            for (int index = 0; index < ComboBox_ConditionNRCs.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToComboBox(ComboBox_ConditionNRCs[index], NRCs);
                ComboBox_ConditionNRCs[index].Text = UIVariables.Service14_NRCCondition[index];
            }

            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPriority.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPriority[index], UIVariables.Service14_NRCPriority);
                dataGridView_NRCPriority.Rows[0].Cells[index].Value = UIVariables.Service14_NRCPriority[index];
            }

            // Load Addressing Mode

            for (int index = 0; index < ButtonStatus_AddressingMode.Length; index++)
            {
                ButtonStatus_AddressingMode[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[index])[0];
                ButtonStatus_AddressingMode[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[index])[1];
                ButtonStatus_AddressingMode[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[index]);
            }

            // Load Condition

            for (int index = 0; index < ButtonStatus_Condition.Length; index++)
            {
                ButtonStatus_Condition[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[index])[0];
                ButtonStatus_Condition[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[index])[1];
                ButtonStatus_Condition[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[index]);
            }

            // Load Invalid Value Condition
            VehicleSpeedValue_Text.Text = UIVariables.Service14_InvalidValueCondition[0];

            comboBox_ConditionEngine_NRC.Enabled = UIVariables.Service14_ButtonStatus_Condition[1];
            comboBox_ConditionVehicle_NRC.Enabled = UIVariables.Service14_ButtonStatus_Condition[0];
            VehicleSpeedValue_Text.Enabled = UIVariables.Service14_ButtonStatus_Condition[0];
            dataGridView_NRCPriority.Enabled = true;
        }
        private void button_Service14_PhysicalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[0] = !UIVariables.Service14_ButtonStatus_AddressingMode[0];

            button_PhysicalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[0])[0];
            button_PhysicalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[0])[1];
            button_PhysicalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[0]);

        }

        private void button_Service14_PhysicalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[1] = !UIVariables.Service14_ButtonStatus_AddressingMode[1];

            button_PhysicalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[1])[0];
            button_PhysicalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[1])[1];
            button_PhysicalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[1]);

        }

        private void button_Service14_PhysicalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[2] = !UIVariables.Service14_ButtonStatus_AddressingMode[2];

            button_PhysicalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[2])[0];
            button_PhysicalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[2])[1];
            button_PhysicalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[2]);
        }

        private void button_Service14_FunctionalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[3] = !UIVariables.Service14_ButtonStatus_AddressingMode[3];

            button_FunctionalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[3])[0];
            button_FunctionalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[3])[1];
            button_FunctionalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[3]);

        }

        private void button_Service14_FunctionalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[4] = !UIVariables.Service14_ButtonStatus_AddressingMode[4];

            button_FunctionalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[4])[0];
            button_FunctionalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[4])[1];
            button_FunctionalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[4]);

        }

        private void button_Service14_FunctionalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[5] = !UIVariables.Service14_ButtonStatus_AddressingMode[5];

            button_FunctionalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[5])[0];
            button_FunctionalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[5])[1];
            button_FunctionalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_AddressingMode[5]);

        }

        private void button_Service14_ConditionEngine_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_Condition[1] = !UIVariables.Service14_ButtonStatus_Condition[1];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1]);

        }

        private void button_Service14_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_Condition[0] = !UIVariables.Service14_ButtonStatus_Condition[0];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0]);

        }

        private void dataGridView_CommonSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Service14_PhysicalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_Service14_PhysicalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_Service14_PhysicalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_Service14_FunctionalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[3] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_Service14_FunctionalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[4] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_Service14_FunctionalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_AddressingMode[5] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void dataGridView_NRCPriority_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_NRCPriority.Enabled == true)
            {
                Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriority, UIVariables.Service14_NRCPriority);
            }
        }

        private void button_ConditionEngine_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_Condition[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionEngine.Text);
            if (UIVariables.Service14_ButtonStatus_Condition[1] == true)
            {
                comboBox_ConditionEngine_NRC.Enabled = true;
                comboBox_ConditionEngine_NRC.Text = UIVariables.Service10_NRCCondition[1];
            }
            else
            {
                comboBox_ConditionEngine_NRC.Enabled = false;
                comboBox_ConditionEngine_NRC.Text = "NRC";
            }
        }

        private void button_ConditionVehicleSpeed_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVehicleSpeed.Text);
            if (UIVariables.Service14_ButtonStatus_Condition[0] == true)
            {
                comboBox_ConditionVehicle_NRC.Enabled = true;
                VehicleSpeedValue_Text.Enabled = true;
                comboBox_ConditionVehicle_NRC.Text = UIVariables.Service14_NRCCondition[0];
                VehicleSpeedValue_Text.Text = UIVariables.Service14_InvalidValueCondition[0];
            }
            else
            {
                comboBox_ConditionVehicle_NRC.Enabled = false;
                VehicleSpeedValue_Text.Enabled = false;
                comboBox_ConditionVehicle_NRC.Text = "NRC";
                VehicleSpeedValue_Text.Text = "...km/h";
            }
        }

        private void comboBox_ConditionEngine_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service14_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service14_NRCCondition[1] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void comboBox_ConditionVehicle_NRC_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service14_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service14_NRCCondition[0] = comboBox_ConditionVehicle_NRC.Text;
            }
        }

        private void VehicleSpeedValue_Text_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service14_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service14_InvalidValueCondition[0] = VehicleSpeedValue_Text.Text;
            }
        }
    }
}
