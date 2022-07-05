using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using dcom.declaration;
using dcom.views.views_ToolBar;
using dcom.controllers.controllers_UIcontainer;

namespace dcom.controllers.controllers_middleware
{
    class Controller_UIHandling
    {
        public static void ShowUserControl(Panel baseWindow, UserControl frame)
        {
            frame.Dock = DockStyle.Fill;

            baseWindow.Controls.Clear();
            baseWindow.Controls.Add(frame);
            frame.Show();
        }

        public static string GetFileDialogPath(string previousPath)
        {
            // Open the Dialog  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            // Save the last directory
            openFileDialog.RestoreDirectory = true;

            // Title of Dialog
            openFileDialog.Title = "Browse";

            

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return previousPath;
            }
        }

        public static string GetFolderDialogPath(string previousPath)
        {
            // Open the Dialog  
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                RootFolder = System.Environment.SpecialFolder.MyComputer
            };
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            else
            {
                return previousPath;
            }

        }

        public static Color[] GetColorOfStatusButton(bool status)
        {
            Color[] color; 
            // status = false -> BackColor = Color.ControlLight; ForeColor = Color.Green
            // status = true -> BackColor = Color.Brown; ForeColor = Color.White

            if (status)
            {
                color = new Color[]{
                    Color.Brown,
                    Color.White
                };
            }
            else
            {
                color = new Color[]{
                    SystemColors.ControlLight,
                    Color.Brown
                };
            }


            return color;
        }

        public static string GetNameOfStatusButton(bool status)
        {
            if (status)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }

        public static bool GetDatabaseSource(string source)
        {
            if(source.ToLower() == "local")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void CleanDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
        }

        public static void CutClipboardValue(DataGridView dataGridView)
        {
            //Copy to clipboard
            CopyCellsToClipboard(dataGridView);

            // Delete the selected field
            DeleteCells(dataGridView);
        }
        public static void CopyCellsToClipboard(DataGridView dataGridView)
        {
            //Copy to clipboard
            DataObject dataObj = dataGridView.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
            else
            {
                //
            }
        }

        public static void DeleteCells(DataGridView dataGridView)
        {
            // Delete the selected field
            foreach (DataGridViewCell dgvCell in dataGridView.SelectedCells)
            {
                if(dgvCell.ColumnIndex != 0)
                {
                    dgvCell.Value = string.Empty;
                }

            }
               
        }
        public static void PasteClipboardValue(DataGridView dataGridView)
        {

            if (dataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell", "Paste",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Get the starting Cell
            DataGridViewCell startCell = GetStartCell(dataGridView);
            //Get the clipboard value in a dictionary
            try
            {
                Dictionary<int, Dictionary<int, string>> cbValue = ClipBoardValues(Clipboard.GetText());
                int iRowIndex = startCell.RowIndex;
                foreach (int rowKey in cbValue.Keys)
                {
                    int iColIndex = startCell.ColumnIndex;
                    foreach (int cellKey in cbValue[rowKey].Keys)
                    {
                        //Check if the index is within the limit
                        if (iColIndex > 0 && iColIndex <= dataGridView.Columns.Count - 1
                        && iRowIndex <= dataGridView.Rows.Count - 1)
                        {
                            DataGridViewCell cell = dataGridView[iColIndex, iRowIndex];

                            //Copy to selected cells if 'chkPasteToSelectedCells' is checked

                            cell.Value = cbValue[rowKey][cellKey];
                        }
                        iColIndex++;
                    }
                    iRowIndex++;
                }
            }
            catch
            {
                // Requested Clipboard operation did not succeed.
            }

        }

        // Insert new row in the above of selected row
        public static void InsertBefore(DataGridView dataGridView)
        {
            // Declare
            int selectedRow;

            if (dataGridView.SelectedCells.Count > 1)
            {
                MessageBox.Show("Please select only one cell for insert feature!");
            }
            else
            {
                foreach (DataGridViewCell dataGridViewCell in dataGridView.SelectedCells)
                {
                    // Select the row
                    selectedRow = dataGridViewCell.RowIndex;
                 
                    // Add new row in above of the selected row
                    AddRows(dataGridView, 1, 0);
                }
            }
        }

        // Insert new row in the below of selected row
        public static void InsertAfter(DataGridView dataGridView)
        {
            // Declare
            int selectedRow;

            if (dataGridView.SelectedCells.Count > 1)
            {
                MessageBox.Show("Please select only one row for insert feature!");
            }
            else
            {
                foreach (DataGridViewCell dataGridViewCell in dataGridView.SelectedCells)
                {
                    // Select the row
                    selectedRow = dataGridViewCell.RowIndex;

              

                    // Add new row in below of the selected row
                    AddRows(dataGridView, 1, 1);

                }
            }
        }

        // Add space rows to the specific position
        // rowCount: The number of rows are added in the datagrid
        // addPosition: 0 - before; 1 - after
        public static void AddRows(DataGridView dataGridView, int rowCount, int addPosition)
        {
            foreach (DataGridViewCell dataGridViewCell in dataGridView.SelectedCells)
            {
                int rowPosition = dataGridViewCell.RowIndex + addPosition;
                try
                {
                    dataGridView.Rows.Insert(rowPosition, rowCount);
                }
                catch
                {
                    // Will perform the below command if the selected row is the last row
                    dataGridView.Rows.Add();
                }

                // Update the No column, If new row is inserted, the "No" will update the number
                for (int index = rowPosition; index < dataGridView.Rows.Count - 1; index++)
                {
                    dataGridView.Rows[index].Cells[0].Value = index + 1;
                }
            }
        }

        public static void InitialDataGridRows(DataGridView dataGridView, int initRowCount)
        {
            dataGridView.Rows.Insert(0, initRowCount);

            for (int index = 0; index < initRowCount; index++)
            {
                dataGridView.Rows[index].Cells[0].Value = index + 1;
            }
        }
        public static DataGridViewCell GetStartCell(DataGridView dgView)
        {
            //get the smallest row,column index
            if (dgView.SelectedCells.Count == 0)
                return null;

            int rowIndex = dgView.Rows.Count - 1;
            int colIndex = dgView.Columns.Count - 1;

            foreach (DataGridViewCell dgvCell in dgView.SelectedCells)
            {
                if (dgvCell.RowIndex < rowIndex)
                    rowIndex = dgvCell.RowIndex;
                if (dgvCell.ColumnIndex < colIndex)
                    colIndex = dgvCell.ColumnIndex;
            }

            return dgView[colIndex, rowIndex];
        }

        public static Dictionary<int, Dictionary<int, string>> ClipBoardValues(string clipboardValue)
        {
            Dictionary<int, Dictionary<int, string>>
            copyValues = new Dictionary<int, Dictionary<int, string>>();

            String[] lines = clipboardValue.Split('\n');

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                copyValues[i] = new Dictionary<int, string>();
                String[] lineContent = lines[i].Split('\t');

                //if an empty cell value copied, then set the dictionary with an empty string
                //else Set value to dictionary
                if (lineContent.Length == 0)
                    copyValues[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= lineContent.Length - 1; j++)
                        copyValues[i][j] = lineContent[j];
                }
            }
            return copyValues;
        }


        public static void AddArrayElementToComboBox(ComboBox comboBox, string[] elements)
        {
            // Clear drop down list
            comboBox.Items.Clear();


            for (int index = 0; index < elements.Length; index++)
            {
                comboBox.Items.Add(elements[index]);
            }
        }

        public static void AddArrayElementToDataGridViewComboBoxColumn(DataGridViewComboBoxColumn dataGridViewComboBoxColumn, string[] elements)
        {
            dataGridViewComboBoxColumn.Items.Clear();

            for (int index = 0; index < elements.Length; index++)
            {
                dataGridViewComboBoxColumn.Items.Add(elements[index]);
            }
        }

        public static void PutDatabaseToDataGridView(DataGridView dataGridView, List<string[]> Data)
        {
            // Push data to Grid View
            CleanDataGridView(dataGridView);

            for (int rowIndex = 0; rowIndex < Data?.Count(); rowIndex++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = rowIndex;                                          // ID
                for (int cellIndex = 0; cellIndex < Data?.ElementAt(rowIndex).Count(); cellIndex++)
                {
                    dataGridView.Rows[rowIndex].Cells[cellIndex + 1].Value = Data?.ElementAt(rowIndex)[cellIndex];   // data
                }
            }
        }
        public static void PutDatabaseToDataGridView_SpecialCase(DataGridView dataGridView, List<string[]> stringData, List<bool[]> boolData)
        {
            // Push data to Grid View
            for (int rowIndex = 0; rowIndex < stringData?.Count(); rowIndex++)
            {
                for (int cellIndex = 1; cellIndex < stringData?.ElementAt(0).Length + boolData?.ElementAt(0).Length + 1; cellIndex++)
                {
                    if (cellIndex < stringData.ElementAt(0).Length + 1)
                    {
                        dataGridView.Rows[rowIndex].Cells[cellIndex].Value = stringData?.ElementAt(rowIndex)[cellIndex - 1];
                    }
                    else
                    {
                        dataGridView.Rows[rowIndex].Cells[cellIndex].Value = boolData?.ElementAt(rowIndex)[cellIndex - (stringData.ElementAt(0).Length + 1)];
                    }
                }
            }
        }

        public static void SaveDataGridViewToDatabase(DataGridView dataGridView, List<string[]> Data)
        {
            if (SystemVariables.checkTheFirstLoad == false && Data?.Count > 0)
            {
                // Save data from Grid View
                dataGridView.Update();
                dataGridView.Refresh();
                for (int rowIndex = 0; dataGridView?.Rows[rowIndex].Cells[1].Value != null; rowIndex++)
                {
                    for (int cellIndex = 0; cellIndex < dataGridView?.Columns.Count - 1; cellIndex++)
                    {
                        Data.ElementAt(rowIndex)[cellIndex] = dataGridView.Rows[rowIndex].Cells[cellIndex + 1].Value.ToString();
                    }
                }
            }
        }

        public static void SaveDataGridViewToDatabase_SpecialCase(DataGridView dataGridView, List<string[]> stringData, List<bool[]> boolData)
        {
            if (SystemVariables.checkTheFirstLoad == false && stringData?.Count > 0)
            {
                string[] tempstring = new string[stringData.ElementAt(0).Length];
                bool[] tempbool = new bool[boolData.ElementAt(0).Length];
                // Save data from Grid View
                dataGridView.Update();
                dataGridView.Refresh();
                if(dataGridView.Rows.Count != stringData.Count)
                {
                    stringData.Add(tempstring);
                    boolData.Add(tempbool);
                }
                for (int rowIndex = 0; dataGridView?.Rows[rowIndex].Cells[1].Value != null; rowIndex++)
                {
                    for (int cellIndex = 1; cellIndex < dataGridView?.Columns.Count; cellIndex++)
                    {
                        if (cellIndex < 5)
                        {
                            if (dataGridView.Rows[rowIndex].Cells[cellIndex].Value.ToString() != "null")
                            {
                                stringData.ElementAt(rowIndex)[cellIndex - 1] = dataGridView.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                            }
                            else
                            {
                                stringData.ElementAt(rowIndex)[cellIndex - 1] = "";
                            }
                        }
                        else
                        {
                            boolData.ElementAt(rowIndex)[cellIndex - (stringData.ElementAt(rowIndex).Length + 1)] = Convert.ToBoolean(dataGridView.Rows[rowIndex].Cells[cellIndex].Value);
                        }
                    }
                }                
            }
        }

        public static void SaveDataGridViewNRCToDatabase(DataGridView dataGridView, string[] Data)
        {
            if (SystemVariables.checkTheFirstLoad == false)
            {
                // Save data from Grid View
                dataGridView.Update();
                dataGridView.Refresh();
                for (int cellIndex = 0; cellIndex < Data.Length; cellIndex++)
                {
                    Data[cellIndex] = dataGridView.Rows[0].Cells[cellIndex].Value.ToString();
                }
            }
        }

        public static void MappingFromDatabaseToUI()
        {
            // Common Setting

            Controllers_UISetting_Testcase.UIDefinition_Setting_Testcase();

            // Service 10

            Controllers_UIService.UIDefinition_Service10();

            // Service 11

            Controllers_UIService.UIDefinition_Service11();

            // Service 14

            Controllers_UIService.UIDefinition_Service14();

            // Service 19

            Controllers_UIService.UIDefinition_Service19();

            // Service 22

            Controllers_UIService.UIDefinition_Service22();

            // Service 2E

            Controllers_UIService.UIDefinition_Service2E();

            // Service 27

            Controllers_UIService.UIDefinition_Service27();

            // Service 28

            Controllers_UIService.UIDefinition_Service28();

            // Service 3E

            Controllers_UIService.UIDefinition_Service3E();

            // Service 85

            Controllers_UIService.UIDefinition_Service85();
        }

    }
}
