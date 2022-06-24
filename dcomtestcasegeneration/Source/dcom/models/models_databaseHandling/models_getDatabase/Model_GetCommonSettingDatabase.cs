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
                for(int columnIndex = startColumnIndexDatabaseTable[0]; ws.Cells[startRowIndexDatabaseTable[0] - 1, columnIndex].Text != ""; columnIndex++)
                {
                    dataRow.Add(ws.Cells[rowIndex, columnIndex].Text);
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

            for (int rowIndex = startRowIndexDatabaseTable[1]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[1]].Text != ""; rowIndex++)
            {
                for (int columnIndex = startColumnIndexDatabaseTable[1]; ws.Cells[startRowIndexDatabaseTable[1] - 1, columnIndex].Text != ""; columnIndex++)
                {
                    dataRow.Add(ws.Cells[rowIndex, columnIndex].Text);
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

            for (int rowIndex = startRowIndexDatabaseTable[2]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[2]].Text != ""; rowIndex++)
            {
                for (int columnIndex = startColumnIndexDatabaseTable[2]; ws.Cells[startRowIndexDatabaseTable[2] - 1, columnIndex].Text != ""; columnIndex++)
                {
                    dataRow.Add(ws.Cells[rowIndex, columnIndex].Text);
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

            for (int rowIndex = startRowIndexDatabaseTable[3]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[3]].Text != ""; rowIndex++)
            {
                for (int columnIndex = startColumnIndexDatabaseTable[3]; ws.Cells[startRowIndexDatabaseTable[3] - 1, columnIndex].Text != ""; columnIndex++)
                {
                    dataRow.Add(ws.Cells[rowIndex, columnIndex].Text);
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

            for (int rowIndex = startRowIndexDatabaseTable[4]; ws.Cells[rowIndex, startColumnIndexDatabaseTable[4]].Text != ""; rowIndex++)
            {
                for (int columnIndex = startColumnIndexDatabaseTable[4]; ws.Cells[startRowIndexDatabaseTable[4] - 1, columnIndex].Text != ""; columnIndex++)
                {
                    dataRow.Add(ws.Cells[rowIndex, columnIndex].Text);
                }
                dataTable.Add(dataRow.ToArray());
                dataRow.Clear();
            }
            return dataTable;
        }
    }
}
