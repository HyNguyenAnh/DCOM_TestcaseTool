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
    class Model_SaveDatabaseService27
    {
        public static void SaveDatabaseService27(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService27.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[5] + index, columnIndex[5] + index_] = DatabaseVariables.DatabaseService27.ElementAt(0)[index][index_];
                }
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(1).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService27.ElementAt(1)[index].Count() - 1; index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_AddressingMode[n]);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_ + 1] = status;
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service27_NRCPrioritySeed.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 1] = UIVariables.Service27_NRCPrioritySeed[index];
            }
            for (int index = 0; index < UIVariables.Service27_NRCPriorityKey.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = UIVariables.Service27_NRCPriorityKey[index];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_Condition.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_Condition[index]);
                Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = status;
                if (status == "1")
                {
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 2] = UIVariables.Service27_InvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = UIVariables.Service27_NameInvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 5] = UIVariables.Service27_NRCCondition[index];
                }
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(4).Count; index++)
            {
                if (DatabaseVariables.DatabaseService27.ElementAt(4)[index][0].Contains("Suppress"))
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_SuppressBit);
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 2] = status;
                }
                else
                {
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 2] = "0";
                }
            }
        }
    }
}
