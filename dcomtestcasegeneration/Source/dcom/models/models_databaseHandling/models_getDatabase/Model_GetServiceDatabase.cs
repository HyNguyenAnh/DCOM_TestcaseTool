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
            Console.WriteLine(sheetName);
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

        public static List<string[]> AllowSession(string SID)
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

        public static List<string[]> NRC(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);
            int startColumnIndexDatabaseTable_except;
            if(SID == "22" || SID == "2E")
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[7] + 1;
            }
            else
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[7];
            }

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[7]; ws.Cells[rowIndex, startColumnIndexDatabaseTable_except].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[7] - 1, startColumnIndexDatabaseTable_except + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable_except + index].Text);
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
            int startColumnIndexDatabaseTable_except;
            if (SID == "22" || SID == "2E" || SID == "27")
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[8] + 1;
            }
            else
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[8];
            }

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[8]; ws.Cells[rowIndex, startColumnIndexDatabaseTable_except].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[8] - 1, startColumnIndexDatabaseTable_except + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable_except + index].Text);
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
            int startColumnIndexDatabaseTable_except;
            if (SID == "22" || SID == "2E" || SID == "27")
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[9] + 1;
            }
            else
            {
                startColumnIndexDatabaseTable_except = startColumnIndexDatabaseTable[9];
            }

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[9]; ws.Cells[rowIndex, startColumnIndexDatabaseTable_except].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[9] - 1, startColumnIndexDatabaseTable_except + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable_except + index].Text);
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
            data.Add(Condition(SID));
            data.Add(Optional(SID));

            return data;

            
        }
    }
}
