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

            ButtonStatus_Condition = new Button[]{
                button_ConditionEngine,
                button_ConditionVehicleSpeed,
            };

            ComboBox_ConditionNRCs = new ComboBox[]
            {
                comboBox_ConditionEngine_NRC,
                comboBox_ConditionVehicle_NRC,
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



            // Load elements to comboBox
            string[] NRCs = UIVariables.NRCs;
            for (int index = 0; index < ComboBox_ConditionNRCs.Length; index++)
            {
                Controller_UIHandling.AddArrayElementToComboBox(ComboBox_ConditionNRCs[index], NRCs);

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
            UIVariables.Service14_ButtonStatus_Condition[0] = !UIVariables.Service14_ButtonStatus_Condition[0];

            button_ConditionEngine.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0])[0];
            button_ConditionEngine.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0])[1];
            button_ConditionEngine.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[0]);

        }

        private void button_Service14_ConditionVehicleSpeed_Click(object sender, EventArgs e)
        {
            UIVariables.Service14_ButtonStatus_Condition[1] = !UIVariables.Service14_ButtonStatus_Condition[1];

            button_ConditionVehicleSpeed.BackColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1])[0];
            button_ConditionVehicleSpeed.ForeColor = Controller_UIHandling.GetColorOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1])[1];
            button_ConditionVehicleSpeed.Text = Controller_UIHandling.GetNameOfStatusButton(UIVariables.Service14_ButtonStatus_Condition[1]);

        }

        private void dataGridView_CommonSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Service14_PhysicalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.PhysicalDefaultService14 = button_PhysicalDefault.Text;
        }

        private void button_Service14_PhysicalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.PhysicalProgrammingService14 = button_PhysicalProgramming.Text;
        }

        private void button_Service14_PhysicalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.PhysicalExtendedService14 = button_PhysicalExtended.Text;
        }

        private void button_Service14_FunctionalDefault_TextChanged(object sender, EventArgs e)
        {
            UIVariables.FunctionalDefaultService14 = button_FunctionalDefault.Text;
        }

        private void button_Service14_FunctionalProgramming_TextChanged(object sender, EventArgs e)
        {
            UIVariables.FunctionalProgrammingService14 = button_FunctionalProgramming.Text;
        }

        private void button_Service14_FunctionalExtended_TextChanged(object sender, EventArgs e)
        {
            UIVariables.FunctionalExtendedService14 = button_FunctionalExtended.Text;
        }

        private void dataGridView_NRCPriority_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_NRCPriority.Enabled == true)
            {
                Controller_UIHandling.SaveDataGridViewNRCToDatabase(dataGridView_NRCPriority, UIVariables.Service14_NRCPriority);
            }
        }
    }
}
