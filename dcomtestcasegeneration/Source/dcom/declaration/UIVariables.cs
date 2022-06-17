using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{
    class UIVariables
    {
        public static bool CompletedEdit = false;
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
        public static string[] SecurityUnlockLevel = new string[]
        {
            "1",
            "2",
            "3",
        };
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
        public static string[] Service10_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service10_InvalidValueCondition = new string[]
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
        public static string[] Service11_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service11_InvalidValueCondition = new string[]
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
        public static string[] Service14_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service14_InvalidValueCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };

        // Service 19


        // Service 22
        public static List<string[]> Service22_DIDTable_Specification { get; set; }
        public static List<bool[]> Service22_DIDTable_AllowSessionAddressingMode { get; set; }
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
        public static string[] Service22_InvalidValueCondition = new string[]
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

        // Service 2E
        public static List<string[]> Service2E_DIDTable_Specification { get; set; }
        public static List<bool[]> Service2E_DIDTable_AddressingMode { get; set; }
        public static bool Service2E_ButtonStatus_SecurityUnlock = false;
        public static string Service2E_SecurityUnlockLv;
        public static string[] Service2E_NRCPriority = new string[15]
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
        public static string[] Service2E_InvalidValueCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static bool[] Service2E_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service2E_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };

        // Service 27
        public static bool Service27_ButtonStatus_SuppressBit = false;
        public static bool[] Service27_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false
        };
        public static bool[] Service27_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
            false,
            false,
        };
        public static string[] Service27_NRCPrioritySeed = new string[15]
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
        public static string[] Service27_NRCPriorityKey = new string[15]
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
        public static string[] Service27_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service27_InvalidValueCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };

        // Service 28

        public static bool[] Service28_ButtonStatus_ControlType = new bool[]
        {
            false,
            false,
            false,
            false,
        };
        public static bool[] Service28_ButtonStatus_CommunicationType = new bool[]
        {
            false,
            false,
            false,
        };
        public static bool Service28_ButtonStatus_SuppressBit = false;
        public static bool[] Service28_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
        };
        public static bool[] Service28_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service28_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service28_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service28_NRCPriority = new string[15]
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

        // Service 3E

        public static bool Service3E_ButtonStatus_SuppressBit = false;
        public static bool[] Service3E_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
        };
        public static bool[] Service3E_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service3E_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service3E_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service3E_NRCPriority = new string[15]
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

        // Service 85

        public static bool Service85_ButtonStatus_SuppressBit = false;
        public static bool[] Service85_ButtonStatus_AddressingMode = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
        };
        public static bool[] Service85_ButtonStatus_Condition = new bool[]
        {
            false,
            false,
        };
        public static string[] Service85_NRCCondition = new string[]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service85_InvalidValueCondition = new string[4]
        {
            "",
            "",
            "",
            "",
        };
        public static string[] Service85_NRCPriority = new string[15]
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
    }
}
