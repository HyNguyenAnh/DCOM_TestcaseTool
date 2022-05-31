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

            string[] SavePhysicalService10 = new string[]
            {
                UIVariables.PhysicalDefaultService10,
                UIVariables.PhysicalProgrammingService10,
                UIVariables.PhysicalExtendedService10,
            };

            string[] SaveFunctionalService10 = new string[]
            {
                UIVariables.FunctionalDefaultService10,
                UIVariables.FunctionalProgrammingService10,
                UIVariables.FunctionalExtendedService10,
            };

            string[] SaveDefaultService10 = new string[]
            {
                UIVariables.DtoDService10,
                UIVariables.DtoPService10,
                UIVariables.DtoEService10,
            };

            string[] SaveProgrammingService10 = new string[]
            {
                UIVariables.PtoDService10,
                UIVariables.PtoPService10,
                UIVariables.PtoEService10,
            };

            string[] SaveExtendedService10 = new string[]
            {
                UIVariables.EtoDService10,
                UIVariables.EtoPService10,
                UIVariables.EtoEService10,
            };
            List<string[]> SaveAllowSessionService10 = new List<string[]>
            {
                SavePhysicalService10,
                SaveFunctionalService10,
                SaveDefaultService10,
                SaveProgrammingService10,
                SaveExtendedService10,
            };

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService10.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService10.ElementAt(0)[index][index_];
                }
            }

            // Allow session
            for (int index = 0; index < SaveAllowSessionService10.Count(); index++)
            {
                for (int index_ = 0; index_ < SaveAllowSessionService10[index].Count(); index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromStatusToString(SaveAllowSessionService10[index].ElementAt(index_).ToString());
                    Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_ + 1] = status;
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
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 3] = UIVariables.Service10_NRCCondition[index];
            }
        }
    }
}
