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
    class Model_SaveDatabaseService10
    {
        public static void SaveDatabaseService10(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService10.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService10.ElementAt(0)[index][index_];
                }
            }

            // Allow session
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(1).Count(); index++) //5
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService10.ElementAt(1)[index].Count() - 1; index_++) //3
                {
                    if (index < 2)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_AddressingMode[n]);
                        Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_ + 1] = status;
                        n++;
                        if((index == 1) && (index_ == 2))
                        {
                            n = 0;
                        }
                    }
                    else
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_SessionTransition[n]);
                        Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_ + 1] = status;
                        n++;
                    }
                }
            }

            // NRC
            for(int index = 0; index < UIVariables.Service10_NRCPriority.Length; index++)
            {
                Ws.Cells[rowIndex[5] + index, columnIndex[5] + 1] = UIVariables.Service10_NRCPriority[index];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService10.ElementAt(3)[index][0].Contains("Suppress"))
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_SuppressBit);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + 1] = status;
                }
                else
                {
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + 1] = "0";
                }
            }

            // Condition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_Condition[index]);
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = status;
                if (status == "1")
                {
                    Ws.Cells[rowIndex[7] + index, columnIndex[7] + 1] = UIVariables.Service10_InvalidValueCondition[index];
                    Ws.Cells[rowIndex[7] + index, columnIndex[7] + 3] = UIVariables.Service10_NRCCondition[index];
                }
            }
        }
    }
}
