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
            string[] dataRow;
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[3]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[3]].Text != ""; rowIndex++)
            {
                dataRow = new string[]
                {
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[3]    ].Text, // Sub_Function
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[3] + 1].Text, // Parameter
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[3] + 2].Text, // Record data
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[3] + 3].Text  // Expected value
                };

                dataTable.Add(dataRow);
            }
            return dataTable;
        }

        public static List<string[]> AllowSession(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            string[] dataRow;
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[4]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[4]].Text != ""; rowIndex++)
            {
                dataRow = new string[]
                {
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[4]    ].Text, // Default
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[4] + 1].Text, // Programming
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[4] + 2].Text, // Extended
                };

                dataTable.Add(dataRow);
            }

            return dataTable;
        }

        public static List<string[]> NRC(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            string[] dataRow;
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[5]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[5]].Text != ""; rowIndex++)
            {
                dataRow = new string[]
                {
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[5]     ].Text,     // Priority
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[5] + 1 ].Text,     // NRC
                };

                dataTable.Add(dataRow);
            }
            return dataTable;
        }

        public static List<string[]> Optional(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            string[] dataRow;
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[6]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[6]].Text != ""; rowIndex++)
            {
                dataRow = new string[]
                {
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[6]    ].Text,  // Optional
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[6] + 1].Text,  // Status
                };

                dataTable.Add(dataRow);
            }
            return dataTable;
        }

        public static List<string[]> Precondition(string SID)
        {
            List<string[]> dataTable = new List<string[]>();
            string[] dataRow;
            string sheetName = Controller_ServiceHandling.GetSheetNameOfService(SID);

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[7]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[7]].Text != ""; rowIndex++)
            {
                dataRow = new string[]
                {
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[7]    ].Text,  // NRC
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[7] + 1].Text,  // Request
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[7] + 2].Text,  // Response
                    ws.Cells[rowIndex, startColumnIndexDatabaseTable[7] + 3].Text,  // Comment
                };

                dataTable.Add(dataRow);
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
            data.Add(Precondition(SID));

            return data;

            
        }
    }
}
