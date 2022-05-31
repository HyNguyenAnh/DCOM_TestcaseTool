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
    class Model_SaveDatabaseService11
    {
        public static void SaveDatabaseService11(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            string[] SavePhysicalService11 = new string[]
{
                UIVariables.PhysicalDefaultService11,
                UIVariables.PhysicalProgrammingService11,
                UIVariables.PhysicalExtendedService11,
};

            string[] SaveFunctionalService11 = new string[]
            {
                UIVariables.FunctionalDefaultService11,
                UIVariables.FunctionalProgrammingService11,
                UIVariables.FunctionalExtendedService11,
            };

            List<string[]> SaveAllowSessionService11 = new List<string[]>
            {
                SavePhysicalService11,
                SaveFunctionalService11,
            };

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11.ElementAt(0)[index].Count() - 1; index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService11.ElementAt(0)[index][index_];
                }
                Ws.Cells[rowIndex[3] + index, columnIndex[3] + 3] = Controller_ServiceHandling.ConvertFromBoolToExpectedValue(UIVariables.Service11_ButtonStatus_SubFunction[index], "11", "12", (index + 1).ToString());
            }

            // Allow session
            for (int index = 0; index < SaveAllowSessionService11.Count(); index++)
            {
                for (int index_ = 0; index_ < SaveAllowSessionService11.ElementAt(index).Count(); index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromStatusToString(SaveAllowSessionService11.ElementAt(index)[index_]);
                    Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_ + 1] = status;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service11_NRCPriority.Length; index++)
            {
                Ws.Cells[rowIndex[5] + index, columnIndex[5] + 1] = UIVariables.Service11_NRCPriority[index];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(3).Count; index++)
            {   if (DatabaseVariables.DatabaseService11.ElementAt(3)[index][0].Contains("Suppress"))
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_SuppressBit);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + 1] = status;
                }
                else
                {
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + 1] = "0";
                }
            }

            // Condition
            for(int index = 0; index < UIVariables.Service11_ButtonStatus_Condition.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_Condition[index]);
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = status;
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 3] = UIVariables.Service11_NRCCondition[index];
            }
        }
    }
}
