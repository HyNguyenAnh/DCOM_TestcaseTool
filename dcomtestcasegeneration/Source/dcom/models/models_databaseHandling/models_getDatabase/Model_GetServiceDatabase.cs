using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_databaseHandling.models_getDatabase
{
    class Model_GetServiceDatabase
    {
        public static int[] startRowIndexDatabaseTable =DatabaseVariables.StartRowIndexDatabaseTables;

        public static int[] startColumnIndexDatabaseTable =DatabaseVariables.StartColumnIndexDatabaseTables;



        public static List<string[]> Specification(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[3]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[3]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[3] - 1, startColumnIndexDatabaseTable[3] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[3] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> AllowSession(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[4]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[4]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[4] - 1, startColumnIndexDatabaseTable[4] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[4] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }

            return dataTable;
        }

        public static List<string[]> NRC(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[5]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[5]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[5] - 1, startColumnIndexDatabaseTable[5] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[5] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> Optional(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[6]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[6]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[6] - 1, startColumnIndexDatabaseTable[6] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[6] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> Condition(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[7]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[7]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[7] - 1, startColumnIndexDatabaseTable[7] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[7] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }

            return dataTable;
        }

        public static List<List<string[]>> DatabaseService(string SID)
        {
            List<List<string[]>> data = new List<List<string[]>> { };
            data.Add(Specification(SID));
            data.Add(AllowSession(SID));
            data.Add(NRC(SID));
            data.Add(Optional(SID));
            data.Add(Condition(SID));

            return data;

            
        }
    }
}
