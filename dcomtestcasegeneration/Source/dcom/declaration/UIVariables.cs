using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{
    class UIVariables
    {
        // NRC List
        public static string[] NRCs = new string[]
        {
            "11",
            "12",
            "13S",
            "13L",
            "22",
            "24",
            "31P",
            "31V",
            "33",
            "35",
            "36",
            "37",
            "7E",
            "7F",
            "83",
        };


        // Setting
        public static string[] ProjectInformation = new string[] { };
        public static string DBSource = "";
        public static string DBPath = "";
        public static string PublicCANDBC = "";
        public static string PrivateCANDBC = "";
        public static string TestcaseDirectory = "";
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

        // Service 10

        public static bool[] Service10_ButtonStatus_SubFunction = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
        public static bool Service10_ButtonStatus_SuppressBit = false;
        public static bool[] Service10_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
        public static bool[] Service10_ButtonStatus_Condition = new bool[]
        {
            false,
            false
        };
        public static string[] Service10_NRCPriority { get; set; }

        public static string DtoDService10 { get; set; }
        public static string PtoPService10 { get; set; }
        public static string EtoEService10 { get; set; }
        public static string DtoPService10 { get; set; }
        public static string DtoEService10 { get; set; }
        public static string PtoDService10 { get; set; }
        public static string PtoEService10 { get; set; }
        public static string EtoDService10 { get; set; }
        public static string EtoPService10 { get; set; }
        public static string PhysicalDefaultService10 { get; set; }
        public static string PhysicalProgrammingService10 { get; set; }
        public static string PhysicalExtendedService10 { get; set; }
        public static string FunctionalDefaultService10 { get; set; }
        public static string FunctionalProgrammingService10 { get; set; }
        public static string FunctionalExtendedService10 { get; set; }
        public static string SupressBitSevice10 { get; set; }

        public static List<string[]> SaveAllowSessionService10 = new List<string[]> { };
        public static string[] SavePhysicalService10 { get; set; }
        public static string[] SaveFunctionalService10 { get; set; }
        public static string[] SaveDefaultService10 { get; set; }
        public static string[] SaveProgrammingService10 { get; set; }
        public static string[] SaveExtendedService10 { get; set; }

        // Service11

        public static bool[] Service11_ButtonStatus_SubFunction = new bool[]
        {
            false,
            false,
            false
        };
        public static bool Service11_ButtonStatus_SuppressBit = false;
        public static bool[] Service11_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
        public static bool[] Service11_ButtonStatus_Condition = new bool[]
        {
            false,
            false
        };
        public static string[] Service11_NRCPriority { get; set; }
        public static List<string[]> SaveAllowSessionService11 = new List<string[]> { };
        public static string[] SavePhysicalService11 { get; set; }
        public static string[] SaveFunctionalService11 { get; set; }
    }
}
