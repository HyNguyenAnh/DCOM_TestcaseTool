using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace dcom.declaration
{
    class SystemVariables
    {
        public static string currentApplicationPath { get; set; }
        public static string dcomtestcasegenerationFileDirectory { get; set; }
        public static string backupFilePath { get; set; }
        public static string backupFileName { get; set; }
        public static bool checkTheFirstLoad { get; set; }
        public static bool dbLoadStatus { get; set; }
        public static bool checkDBVariableDefinitionStatus { get; set; }
        public static string templateFileServerPath { get; set; }
        public static string templateFileLocalPath { get; set; }


        public static string NameOutputDatabase { get; set; }
        public static string DirectoryOutputDatabase { get; set; }
        public static string PathOutputDatabase { get; set; }

    }
}
