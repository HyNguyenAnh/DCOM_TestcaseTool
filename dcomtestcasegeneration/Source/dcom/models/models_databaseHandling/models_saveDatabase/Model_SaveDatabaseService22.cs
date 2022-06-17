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
    class Model_SaveDatabaseService22
    {
        public static void SaveDatabaseService22(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService22.ElementAt(0)[index].Count(); index_++)
                {
                    status = UIVariables.Service22_DIDTable_Specification[index][index_];
                    Ws.Cells[rowIndex[5] + index, columnIndex[5] + index_] = status;
                }
            }

            // Allow session
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(1).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService22.ElementAt(1)[index].Count(); index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_DIDTable_AllowSessionAddressingMode[index][index_]);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_] = status;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service22_NRCPriority.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = UIVariables.Service22_NRCPriority[index];
            }


            // Condition
            for (int index = 0; index < UIVariables.Service22_ButtonStatus_Condition.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_Condition[index]);
                Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                if (status == "1")
                {
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 2] = UIVariables.Service22_InvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = UIVariables.Service22_NRCCondition[index];
                }
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(4).Count; index++)
            {
                if (DatabaseVariables.DatabaseService22.ElementAt(4)[index][0].Contains("Suppress"))
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_SuppressBit);
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
