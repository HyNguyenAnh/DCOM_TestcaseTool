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
        public static Workbook WbOutputDatabase { get; set; }
        public static Worksheet WsOutputDatabase { get; set; }

        public static string NameOutputDatabase { get; set; }
        public static string DirectoryOutputDatabase { get; set; }
        public static string PathOutputDatabase { get; set; }

        public static Workbook WbDatabase { get; set; }
        public static Worksheet WsDatabase { get; set; }

        public static string DatabasePath { get; set; }
        public static string PublicCANDBC { get; set; }
        public static string PrivateCANDBC { get; set; }
        public static string TestcaseDirectory { get; set; }
        public static string DatabaseDirectory { get; set; }
        public static string TemplatePath { get; set; }
        public static string DatabaseSource = "Local";

        public static int[] StartRowIndexDatabaseTables { get; set; }
        public static int[] StartColumnIndexDatabaseTables { get; set; }
        public static string ProjectName { get; set; }
        public static string Variant { get; set; }
        public static string Release { get; set; }
        public static string RC { get; set; }

        public static List<List<string[]>> DatabaseService10 { get; set; }
        public static List<List<string[]>> DatabaseService11 { get; set; }
        public static List<List<string[]>> DatabaseService14 { get; set; }
        public static List<List<string[]>> DatabaseService19 { get; set; }
        public static List<List<string[]>> DatabaseService22 { get; set; }
        public static List<List<string[]>> DatabaseService27 { get; set; }
        public static List<List<string[]>> DatabaseService28 { get; set; }
        public static List<List<string[]>> DatabaseService2E { get; set; }
        public static List<List<string[]>> DatabaseService2F { get; set; }
        public static List<List<string[]>> DatabaseService31 { get; set; }
        public static List<List<string[]>> DatabaseService3E { get; set; }
        public static List<List<string[]>> DatabaseService85 { get; set; }

        public static List<string[]> DatabaseCommonSetting = new List<string[]> { };
        public static List<string[]> DatabaseCommonCommand = new List<string[]> { };
        public static List<string[]> DatabaseCommonDID = new List<string[]> { };

        public static string[] DatabaseCommonSettingCreateFault { get; set; }
        public static string[] DatabaseCommonSettingVehicleSpeed { get; set; }
        public static string[] DatabaseCommonSettingEngineStatus { get; set; }
        public static string[] DatabaseCommonSettingPowerMode { get; set; }
        public static string[] DatabaseCommonSettingSecurityUnlock{ get; set; }

        public static string[] DatabaseCommonCommandReadDTCStatusActive { get; set; }
        public static string[] DatabaseCommonCommandReadDTCStatusPassive { get; set; }
        public static string[] DatabaseCommonCommandReadDTCStatusNoDTC { get; set; }
        public static string[] DatabaseCommonCommandReadInvalidCounter { get; set; }
        public static string[] DatabaseCommonCommandReadSession { get; set; }
        public static string[] DatabaseCommonDIDCurrentSession { get; set; }
        public static string[] DatabaseCommonDIDInvalidCounter { get; set; }

        public static List<string[]> DatabaseSelectedService { get; set; }


        public static bool[] SelectedServiceStatus = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,

        };
        public static string[] ProjectInformation { get; set; }
        public static string[] DataPathInformation { get; set; }
        public static int ID { get; set; }

        public static string [] AllowSession_Physical { get; set; }
        public static string[] AllowSession_Functional { get; set; }
    }
}
