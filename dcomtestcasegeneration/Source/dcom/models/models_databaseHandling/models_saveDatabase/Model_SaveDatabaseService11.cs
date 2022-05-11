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

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(0).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11.ElementAt(0)[0].Count(); index_++)
                {
                    Ws.Cells[rowIndex[3] + index, columnIndex[3] + index_] = DatabaseVariables.DatabaseService11.ElementAt(0)[index][index_];
                }
            }

            // Allow session
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(1).Count(); index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11.ElementAt(1)[0].Count(); index_++)
                {
                    if (DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_] == "ON")
                    {
                        status = "1";
                    }
                    else if (DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_] == "OFF")
                    {
                        status = "0";
                    }
                    else
                    {
                        status = DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_];
                    }
                    Ws.Cells[rowIndex[4] + index, columnIndex[4] + index_] = status;
                }
            }
        }
        //public static void ConvertStatusToBinary(int index, int index_, string status)
        //{
        //    if (DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_] == "ON")
        //    {
        //        status = "1";
        //    }
        //    else if (DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_] == "OFF")
        //    {
        //        status = "0";
        //    }
        //    else
        //    {
        //        status = DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_];
        //    }
        //}
    }
}
