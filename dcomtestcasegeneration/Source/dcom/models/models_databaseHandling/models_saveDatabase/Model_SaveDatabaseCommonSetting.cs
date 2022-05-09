using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_databaseHandling.models_saveDatabase
{
    class Model_SaveDatabaseCommonSetting
    {
        public static void SaveCommonSettingDatabase(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;

            // Project Information
            Ws.Cells[rowIndex[8], columnIndex[8] + 1] = DatabaseVariables.ProjectName;
            Ws.Cells[rowIndex[8] + 1, columnIndex[8] + 1] = DatabaseVariables.Variant;
            Ws.Cells[rowIndex[8] + 2, columnIndex[8] + 1] = DatabaseVariables.Release;
            Ws.Cells[rowIndex[8] + 3, columnIndex[8] + 1] = DatabaseVariables.RC;

            // Data Path Information
            Ws.Cells[rowIndex[9], columnIndex[9] + 1] = DatabaseVariables.DatabaseSource;
            Ws.Cells[rowIndex[9] + 1, columnIndex[9] + 1] = DatabaseVariables.PathOutputDatabase;
            Ws.Cells[rowIndex[9] + 4, columnIndex[9] + 1] = DatabaseVariables.TestcaseDirectory;
            Ws.Cells[rowIndex[9] + 5, columnIndex[9] + 1] = DatabaseVariables.TemplatePath;
            Ws.Cells[rowIndex[9] + 6, columnIndex[9] + 1] = DatabaseVariables.DirectoryOutputDatabase;

            // Selected Service
            for (int index = 0; index < 12; index++)
            {
                string selectedServiceStatus;
                if (DatabaseVariables.SelectedServiceStatus[index] == true)
                {
                    selectedServiceStatus = "1";
                }
                else
                {
                    selectedServiceStatus = "0";
                }
                Ws.Cells[rowIndex[10] + index, columnIndex[10] + 1] = selectedServiceStatus;
            }
        }
    }
}
