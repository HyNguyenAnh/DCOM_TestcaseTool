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
            string status = "";

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
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService11.ElementAt(0)[index][index_];
                }
            }

            // Allow session
            for (int index = 0; index < SaveAllowSessionService11.Count(); index++)
            {
                for (int index_ = 0; index_ < SaveAllowSessionService11.ElementAt(index).Count(); index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromStatusToString(SaveAllowSessionService11.ElementAt(index)[index_]);
                    Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_] = status;
                }
            }

            // Optional
            status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_SuppressBit);
            Ws.Cells[rowIndex[6] + 2, columnIndex[6] + 1] = status;
        }
    }
}
