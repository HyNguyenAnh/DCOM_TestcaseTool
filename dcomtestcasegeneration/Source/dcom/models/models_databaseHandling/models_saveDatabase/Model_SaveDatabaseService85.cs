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
    class Model_SaveDatabaseService85
    {
        public static void SaveDatabaseService85(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            // Allow session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(1).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService85?.ElementAt(1)[index].Count() - 1; index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_AddressingMode[n]);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_ + 1] = status;
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service85_NRCPriority?.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 1] = UIVariables.Service85_NRCPriority[index];
            }


            // Condition
            for (int index = 0; index < UIVariables.Service85_ButtonStatus_Condition?.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_Condition[index]);
                Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                if (status == "1")
                {
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = UIVariables.Service85_InvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 2] = UIVariables.Service85_NameInvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = UIVariables.Service85_NRCCondition[index];
                }
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(4).Count; index++)
            {
                if (DatabaseVariables.DatabaseService85.ElementAt(4)[index][0].Contains("Suppress"))
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_SuppressBit);
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 1] = status;
                }
                else
                {
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 1] = "0";
                }
            }
        }
    }
}
