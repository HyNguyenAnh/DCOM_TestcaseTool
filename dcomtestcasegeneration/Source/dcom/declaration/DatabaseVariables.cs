using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace dcom.declaration
{
    class DatabaseVariables
    {
        public static Workbook WbDatabase { get; set; }
        public static Worksheet WsDatabase { get; set; }


        public static int[] StartRowIndexDatabaseTables { get; set; }
        public static int[] StartColumnIndexDatabaseTables { get; set; }

        public static List<List<string[]>> DatabaseService10 { get; set; }
        public static List<List<string[]>> DatabaseService11 { get; set; }
        public static List<List<string[]>> DatabaseService14 { get; set; }
        public static List<List<string[]>> DatabaseService19 { get; set; }
        public static List<List<string[]>> DatabaseService22 { get; set; }
        public static List<List<string[]>> DatabaseService27 { get; set; }
        public static List<List<string[]>> DatabaseService28 { get; set; }
        public static List<List<string[]>> DatabaseService2E { get; set; }
        public static List<List<string[]>> DatabaseCanTP { get; set; }
        public static List<List<string[]>> DatabaseService31 { get; set; }
        public static List<List<string[]>> DatabaseService3E { get; set; }
        public static List<List<string[]>> DatabaseService85 { get; set; }

    }
}
