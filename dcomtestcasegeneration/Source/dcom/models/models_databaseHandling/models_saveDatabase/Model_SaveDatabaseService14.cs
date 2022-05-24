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
    class Model_SaveDatabaseService14
    {
        public static void SaveDatabaseService14(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status = "";

            string[] SavePhysicalService14 = new string[]
{
                UIVariables.PhysicalDefaultService14,
                UIVariables.PhysicalProgrammingService14,
                UIVariables.PhysicalExtendedService14,
};

            string[] SaveFunctionalService14 = new string[]
            {
                UIVariables.FunctionalDefaultService14,
                UIVariables.FunctionalProgrammingService14,
                UIVariables.FunctionalExtendedService14,
            };

            List<string[]> SaveAllowSessionService14 = new List<string[]>
            {
                SavePhysicalService14,
                SaveFunctionalService14,
            };
            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService14.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService14.ElementAt(0)[index][index_];
                }
            }

            // Allow session
            for (int index = 0; index < SaveAllowSessionService14.Count(); index++)
            {
                for (int index_ = 0; index_ < SaveAllowSessionService14.ElementAt(index).Count(); index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromStatusToString(SaveAllowSessionService14.ElementAt(index)[index_]);
                    Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_] = status;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service14_NRCPriority.Length; index++)
            {
                Ws.Cells[rowIndex[5] + index, columnIndex[5] + 1] = UIVariables.Service14_NRCPriority[index];
            }
        }
    }
}
