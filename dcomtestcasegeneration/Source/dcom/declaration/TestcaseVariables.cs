using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{
    class TestcaseVariables
    {
        public static Workbook WbOutputTestcase { get; set; }
        public static Worksheet WsOutputTestcase { get; set; }

        
        public static string NameOutputTestcase { get; set; }
        public static string DirectoryOutputTestcase { get; set; }
        public static string PathOutputTestcase { get; set; } 

        public static string[] TestcaseColumnsName { get; set; }
        public static int IDColumnIndex { get; set; }
        public static int ComponentColumnIndex { get; set; }
        public static int TestDescriptionColumnIndex { get; set; }
        public static int TestStepColumnIndex { get; set; }
        public static int TestResponseColumnIndex { get; set; }
        public static int TestStepKeywordColumnIndex { get; set; }
        public static int ObjectTypeColumnIndex { get; set; }
        public static int TestStatusColumnIndex { get; set; }
        public static int ProjectColumnIndex { get; set; }

        public static int[] TestcaseColumnsWidth { get; set; }

        public static string[] ObjectType { get; set; }
        public static string TestStatus { get; set; }
        public static int ID { get; set; }
        public static string SubID { get; set; }
        public static string[] ServiceTestgroupIndex { get; set; }

        public static Color ColorTestGroupInterior { get; set; }
        public static Color ColorTestCaseInterior { get; set; }

        public static bool isFaultEnable { get; set; }
        public static bool isFaultDisable { get; set; }
        public static bool isClearDTC { get; set; }

    }
}
