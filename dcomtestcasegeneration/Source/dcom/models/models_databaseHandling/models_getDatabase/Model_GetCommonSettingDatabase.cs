using dcom.declaration;
using dcom.controllers.controllers_middleware;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_databaseHandling.models_getDatabase
{
    class Model_GetCommonSettingDatabase
    {
        public static int[] startRowIndexDatabaseTable = DatabaseVariables.StartRowIndexDatabaseTables;
        public static int[] startColumnIndexDatabaseTable = DatabaseVariables.StartColumnIndexDatabaseTables;

        public static string sheetName = Controller_ServiceHandling.GetSheetNameOfService("0");

        public static List<string[]> CommonSetting()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[0]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[0]].Text != ""; rowIndex++)
            {
                for(int index = 0; ws.Cells[startRowIndexDatabaseTable[0] - 1, startColumnIndexDatabaseTable[0] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[0] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }

            return dataTable;
        }

        public static List<string[]> CommonCommand()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[1]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[1]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[1] - 1, startColumnIndexDatabaseTable[1] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[1] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> CommonDID()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[2]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[2]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[2] - 1, startColumnIndexDatabaseTable[2] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[2] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> ProjectInformation()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[8]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[8]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[8] - 1, startColumnIndexDatabaseTable[8] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[8] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> DataPathInformation()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[9]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[9]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[9] - 1, startColumnIndexDatabaseTable[9] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[9] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }

        public static List<string[]> SelectedServiceInformation()
        {
            List<string[]> dataTable = new List<string[]>();
            List<string> dataRow = new List<string>();

            // Definition worksheet
            DatabaseVariables.WsDatabase = DatabaseVariables.WbDatabase?.Sheets[sheetName];
            Worksheet ws = DatabaseVariables.WsDatabase;

            for (int rowIndex = startRowIndexDatabaseTable[10]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[10]].Text != ""; rowIndex++)
            {
                for (int index = 0; ws.Cells[startRowIndexDatabaseTable[10] - 1, startColumnIndexDatabaseTable[10] + index].Text != ""; index++)
                {
                    dataRow.Add(ws.Cells[rowIndex, startColumnIndexDatabaseTable[10] + index].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }
    }
}
