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
            "31",
            "33",
            "35",
            "36",
            "37",
            "7E",
            "7F",
            "83",
        };

        public static List<ValueType[]> data { get; set; }
        // Setting
        public static string[] ProjectInformation = new string[] { };
        public static string DBSource = "";
        public static string DBPath = "";
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
        
        public static bool[] Service10_ButtonStatus_SessionTransition = new bool[]
        {
            false,
            false,
            false,
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
            false,
        };
        public static string[] Service10_NRCCondition = new string[2]
        {
            "",
            "",
        };
        public static string[] Service10_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service10_NRCPriority = new string[15]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };


        // Service 11

        public static bool[] Service11_ButtonStatus_ResetMode = new bool[]
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
            false,
        };
        public static string[] Service11_NRCPriority = new string[15]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        public static string[] Service11_NRCCondition = new string[2]
        {
            "",
            "",
        };
        public static string[] Service11_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };

        // Service 14

        public static bool[] Service14_ButtonStatus_SubFunction = new bool[]
        {
            false,
            false,
            false
        };
        public static bool Service14_ButtonStatus_SuppressBit = false;
        public static bool[] Service14_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
        public static bool[] Service14_ButtonStatus_Condition = new bool[]
        {
            false,
            false
        };
        public static string[] Service14_NRCPriority = new string[15]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        public static string[] Service14_NRCCondition = new string[2]
        {
            "",
            "",
        };
        public static string[] Service14_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };

        // Service 19


        // Service 22
        public static List<string[]> Service22_DIDTable_AllowSession = new List<string[]> { };
        public static List<bool[]> Service22_DIDTable_AddressingMode = new List<bool[]> { };
        public static bool Service22_ButtonStatus_SuppressBit = false;
        public static string[] Service22_NRCPriority = new string[15]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };       
        public static string[] Service22_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static bool[] Service22_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service22_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };

        // Service 2e
        public static List<string[]> Service2e_DIDTable_AllowSession = new List<string[]> { };
        public static List<bool[]> Service2e_DIDTable_AddressingMode = new List<bool[]> { };
        public static bool Service2e_ButtonStatus_SuppressBit = false;
        public static string[] Service2e_NRCPriority = new string[15]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        public static string[] Service2e_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static bool[] Service2e_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service2e_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
    }
}
