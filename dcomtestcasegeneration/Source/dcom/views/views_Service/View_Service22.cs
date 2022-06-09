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
        public static Button ButtonStatus_SuppressBit;
        public static DataGridView DIDTable;
        public static Button[] ButtonStatus_Condition;
        public static ComboBox[] ComboBox_ConditionNRCs;
        public static DataGridViewComboBoxColumn[] DataGridViewComboBoxColumn_NRCPriority;
        public static TextBox[] InvalidValue_Condition;
        public View_Service22()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            // Definition

            DIDTable = dataGridView_DIDTable;

            // Load data to DataGridView
            List<string[]> DIDTable_AllowSession = UIVariables.Service22_DIDTable_AllowSession;
            List<bool[]> DIDTable_AddressingMode = UIVariables.Service22_DIDTable_AddressingMode;
            Controller_UIHandling.PutDatabaseToDataGridView_SpecialCase(DIDTable, DIDTable_AllowSession, DIDTable_AddressingMode, 1);
            Controller_UIHandling.PutDatabaseToDataGridView_SpecialCase(DIDTable, DIDTable_AllowSession, DIDTable_AddressingMode, 5);
        }
        private void View_Service22_Load(object sender, EventArgs e)
        {
            // Initial 100 empty row for the DID table
            Controller_UIHandling.InitialDataGridRows(dataGridView_DIDTable, 100);
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
    }
}
