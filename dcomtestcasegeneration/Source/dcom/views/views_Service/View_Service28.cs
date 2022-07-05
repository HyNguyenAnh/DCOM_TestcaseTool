﻿using System;
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
    public partial class View_Service28 : UserControl
    {
        public static Button[] ButtonStatus_ControlType;
        public static Button[] ButtonStatus_CommunicationType;
        public static Button ButtonStatus_SuppressBit;
        public static Button[] ButtonStatus_AddressingMode;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriority;
        public static TextBox[] InvalidValue_Condition;
        public View_Service28()
        {
            InitializeComponent();
        }

        private void View_Service28_Load(object sender, EventArgs e)
        {
            // Definition

            ButtonStatus_ControlType = new Button[]
            {
                button_ControlType00,
                button_ControlType01,
                button_ControlType02,
                button_ControlType03,
            };

            ButtonStatus_CommunicationType = new Button[]
            {
                button_CommunicationType01,
                button_CommunicationType02,
                button_CommunicationType03,
            };

            ButtonStatus_SuppressBit = button_SupressBit;

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


            // Load elements to comboBox
            string[] NRCs = UIVariables.NRCs;
            for (int index = 0; index < ComboBox_ConditionNRCs.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToComboBox(ComboBox_ConditionNRCs[index], NRCs);
                ComboBox_ConditionNRCs[index].Text = UIVariables.Service28_NRCCondition[index];
            }

            for (int index = 0; index < DataGridViewComboBoxColumn_NRCPriority.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn_NRCPriority[index], NRCs);
                dataGridView_NRCPriority.Rows[0].Cells[index].Value = UIVariables.Service28_NRCPriority[index];
            }

            // Load Control Type
            for(int index = 0; index < ButtonStatus_ControlType.Length; index++)
            {
                ButtonStatus_ControlType[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[index])[0];
                ButtonStatus_ControlType[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[index])[1];
                ButtonStatus_ControlType[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[index]);
            }

            // Load Communication Type
            for (int index = 0; index < ButtonStatus_CommunicationType.Length; index++)
            {
                ButtonStatus_CommunicationType[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[index])[0];
                ButtonStatus_CommunicationType[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[index])[1];
                ButtonStatus_CommunicationType[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[index]);
            }

            // Load Suppress bit

            ButtonStatus_SuppressBit.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit)[0];
            ButtonStatus_SuppressBit.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit)[1];
            ButtonStatus_SuppressBit.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit);

            // Load Addressing Mode

            for (int index = 0; index < ButtonStatus_AddressingMode.Length; index++)
            {
                ButtonStatus_AddressingMode[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[index])[0];
                ButtonStatus_AddressingMode[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[index])[1];
                ButtonStatus_AddressingMode[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[index]);
            }

            // Load Condition

            for (int index = 0; index < ButtonStatus_Condition.Length; index++)
            {
                ButtonStatus_Condition[index].BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[index])[0];
                ButtonStatus_Condition[index].ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[index])[1];
                ButtonStatus_Condition[index].Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[index]);
            }

            // Load Invalid Value Condition
            textBox_ConditionVehicle.Text = UIVariables.Service28_InvalidValueCondition[0];

            comboBox_ConditionEngine_NRC.Enabled = UIVariables.Service28_ButtonStatus_Condition[1];
            comboBox_ConditionVehicle_NRC.Enabled = UIVariables.Service28_ButtonStatus_Condition[0];
            textBox_ConditionVehicle.Enabled = UIVariables.Service28_ButtonStatus_Condition[0];
            dataGridView_NRCPriority.Enabled = true;
        }

        private void button_ControlType00_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[0] = !UIVariables.Service28_ButtonStatus_ControlType[0];

            button_ControlType00.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[0])[0];
            button_ControlType00.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[0])[1];
            button_ControlType00.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[0]);
        }

        private void button_ControlType01_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[1] = !UIVariables.Service28_ButtonStatus_ControlType[1];

            button_ControlType01.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[1])[0];
            button_ControlType01.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[1])[1];
            button_ControlType01.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[1]);
        }

        private void button_ControlType02_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[2] = !UIVariables.Service28_ButtonStatus_ControlType[2];

            button_ControlType02.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[2])[0];
            button_ControlType02.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[2])[1];
            button_ControlType02.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[2]);
        }

        private void button_ControlType03_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[3] = !UIVariables.Service28_ButtonStatus_ControlType[3];

            button_ControlType03.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[3])[0];
            button_ControlType03.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[3])[1];
            button_ControlType03.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_ControlType[3]);
        }

        private void button_CommunicationType01_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[0] = !UIVariables.Service28_ButtonStatus_CommunicationType[0];

            button_CommunicationType01.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[0])[0];
            button_CommunicationType01.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[0])[1];
            button_CommunicationType01.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[0]);
        }

        private void button_CommunicationType02_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[1] = !UIVariables.Service28_ButtonStatus_CommunicationType[1];

            button_CommunicationType02.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[1])[0];
            button_CommunicationType02.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[1])[1];
            button_CommunicationType02.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[1]);
        }

        private void button_CommunicationType03_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[2] = !UIVariables.Service28_ButtonStatus_CommunicationType[2];

            button_CommunicationType03.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[2])[0];
            button_CommunicationType03.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[2])[1];
            button_CommunicationType03.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_CommunicationType[2]);
        }
        private void button_SupressBit_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_SuppressBit = !UIVariables.Service28_ButtonStatus_SuppressBit;

            button_SupressBit.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit)[0];
            button_SupressBit.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit)[1];
            button_SupressBit.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_SuppressBit);

        }

        private void button_PhysicalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[0] = !UIVariables.Service28_ButtonStatus_AddressingMode[0];

            button_PhysicalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[0])[0];
            button_PhysicalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[0])[1];
            button_PhysicalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[0]);

        }

        private void button_PhysicalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[1] = !UIVariables.Service28_ButtonStatus_AddressingMode[1];

            button_PhysicalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[1])[0];
            button_PhysicalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[1])[1];
            button_PhysicalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[1]);

        }

        private void button_PhysicalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[2] = !UIVariables.Service28_ButtonStatus_AddressingMode[2];

            button_PhysicalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[2])[0];
            button_PhysicalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[2])[1];
            button_PhysicalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[2]);
        }

        private void button_FunctionalDefault_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[3] = !UIVariables.Service28_ButtonStatus_AddressingMode[3];

            button_FunctionalDefault.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[3])[0];
            button_FunctionalDefault.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[3])[1];
            button_FunctionalDefault.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[3]);

        }

        private void button_FunctionalProgramming_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[4] = !UIVariables.Service28_ButtonStatus_AddressingMode[4];

            button_FunctionalProgramming.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[4])[0];
            button_FunctionalProgramming.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[4])[1];
            button_FunctionalProgramming.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[4]);

        }

        private void button_FunctionalExtended_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[5] = !UIVariables.Service28_ButtonStatus_AddressingMode[5];

            button_FunctionalExtended.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[5])[0];
            button_FunctionalExtended.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[5])[1];
            button_FunctionalExtended.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_AddressingMode[5]);

        }

        private void button_ConditionEngine_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_Condition[1] = !UIVariables.Service28_ButtonStatus_Condition[1];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[1])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[1])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[1]);

        }

        private void button_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_Condition[0] = !UIVariables.Service28_ButtonStatus_Condition[0];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[0])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[0])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service28_ButtonStatus_Condition[0]);

        }

        private void dataGridView_CommonSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_PhysicalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalDefault.Text);
        }

        private void button_PhysicalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalProgramming.Text);
        }

        private void button_PhysicalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_PhysicalExtended.Text);
        }

        private void button_FunctionalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[3] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalDefault.Text);
        }

        private void button_FunctionalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[4] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalProgramming.Text);
        }

        private void button_FunctionalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_AddressingMode[5] = Controller_ServiceHandling.ConvertFromStatusToBool(button_FunctionalExtended.Text);
        }

        private void button_ControlType00_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ControlType00.Text);
        }

        private void button_ControlType01_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ControlType01.Text);
        }

        private void button_ControlType02_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ControlType02.Text);
        }

        private void button_ControlType03_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_ControlType[3] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ControlType03.Text);
        }

        private void button_CommunicationType01_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_CommunicationType01.Text);
        }

        private void button_CommunicationType02_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_CommunicationType02.Text);
        }

        private void button_CommunicationType03_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_CommunicationType[2] = Controller_ServiceHandling.ConvertFromStatusToBool(button_CommunicationType03.Text);
        }
        private void button_SupressBit_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStatusToBool(button_SupressBit.Text);
        }

        private void dataGridView_NRCPriority_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_NRCPriority.Enabled == true)
            {
                Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriority, UIVariables.Service28_NRCPriority);
            }
        }
        private void button_ConditionEngine_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_Condition[1] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionEngine.Text);
            if (UIVariables.Service28_ButtonStatus_Condition[1] == true)
            {
                comboBox_ConditionEngine_NRC.Enabled = true;
                comboBox_ConditionEngine_NRC.Text = UIVariables.Service28_NRCCondition[1];
            }
            else
            {
                comboBox_ConditionEngine_NRC.Enabled = false;
                comboBox_ConditionEngine_NRC.Text = "NRC";
            }
        }

        private void button_ConditionVehicleSpeed_TextChanged(object sender, EventArgs e)
        {
            UIVariables.Service28_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStatusToBool(button_ConditionVehicleSpeed.Text);
            if (UIVariables.Service28_ButtonStatus_Condition[0] == true)
            {
                comboBox_ConditionVehicle_NRC.Enabled = true;
                textBox_ConditionVehicle.Enabled = true;
                comboBox_ConditionVehicle_NRC.Text = UIVariables.Service28_NRCCondition[0];
                textBox_ConditionVehicle.Text = UIVariables.Service28_InvalidValueCondition[0];
            }
            else
            {
                comboBox_ConditionVehicle_NRC.Enabled = false;
                textBox_ConditionVehicle.Enabled = false;
                comboBox_ConditionVehicle_NRC.Text = "NRC";
                textBox_ConditionVehicle.Text = "...km/h";
            }
        }

        private void textBox_ConditionVehicle_TextChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service28_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service28_InvalidValueCondition[0] = textBox_ConditionVehicle.Text;
            }
        }
        private void comboBox_ConditionEngine_NRC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service28_ButtonStatus_Condition[1] == true)
            {
                UIVariables.Service28_NRCCondition[1] = comboBox_ConditionEngine_NRC.Text;
            }
        }

        private void comboBox_ConditionVehicle_NRC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UIVariables.Service28_ButtonStatus_Condition[0] == true)
            {
                UIVariables.Service28_NRCCondition[0] = comboBox_ConditionVehicle_NRC.Text;
            }
        }

        private void comboBox_ConditionVoltage_NRC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button_ConditionVoltage_Click(object sender, EventArgs e)
        {

        }

        private void button_ConditionVoltage_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
