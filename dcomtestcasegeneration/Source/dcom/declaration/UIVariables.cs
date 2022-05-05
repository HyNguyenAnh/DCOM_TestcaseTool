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
       
    }
}
