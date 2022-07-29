using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.controllers;
using dcom.models.models_databaseHandling.models_getDatabase;
using dcom.models.models_databaseHandling.models_saveDatabase;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using dcom.controllers.controllers_middleware;
using dcom.controllers.controllers_UIcontainer;

namespace dcom.declaration
{
    public class Definition
    {

        public static void TemplateVariableDefinition()
        {
            

        }

        public static void DatabaseVariableDefinition()
        {
            DatabaseVariables.StartRowIndexDatabaseTables = new int[]
            {
                2,  // Common Setting
                21, // Common DID
                31, // Project Information
                41, // Data Path Information
                51, // Selected Service
                3,  // Specification
                3,  // Allow session
                3,  // NRC
                3,  // Condition
                3,  // Optional
                3,  // SIDSupported
            };
            DatabaseVariables.StartColumnIndexDatabaseTables = new int[]
            {   1,  // Common Setting
                1,  // Common DID
                1,  // Project Information
                1,  // Data Path Information
                1,  // Selected Service
                1,  // Specification
                6,  // Allow session
                11, // NRC
                14, // Condition
                20, // Optional
                24,  // SIDSupported
            };


            // Service 10
            DatabaseVariables.DatabaseService10 = new List<List<string[]>>();
            DatabaseVariables.DatabaseService10.Add(Controller_UIHandling.addListArray(3, 2));
            DatabaseVariables.DatabaseService10.Add(Controller_UIHandling.addListArray(5, 4));
            DatabaseVariables.DatabaseService10.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService10.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService10.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 11
            DatabaseVariables.DatabaseService11 = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService11.Add(Controller_UIHandling.addListArray(1, 2));
            DatabaseVariables.DatabaseService11.Add(Controller_UIHandling.addListArray(2, 4));
            DatabaseVariables.DatabaseService11.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService11.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService11.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 14
            DatabaseVariables.DatabaseService14 = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService14.Add(Controller_UIHandling.addListArray(5, 2));
            DatabaseVariables.DatabaseService14.Add(Controller_UIHandling.addListArray(2, 4));
            DatabaseVariables.DatabaseService14.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService14.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService14.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 19
            //DatabaseVariables.DatabaseService19 = new List<List<string[]>> { };
            //DatabaseVariables.DatabaseService19.Add(Controller_UIHandling.addListArray(3, 2));
            //DatabaseVariables.DatabaseService19.Add(Controller_UIHandling.addListArray(5, 4));
            //DatabaseVariables.DatabaseService19.Add(Controller_UIHandling.addListArray(15, 2));
            //DatabaseVariables.DatabaseService19.Add(Controller_UIHandling.addListArray(4, 5));
            //DatabaseVariables.DatabaseService19.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 22
            DatabaseVariables.DatabaseService22 = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(100, 4));
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(100, 5));
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(2, 2));
            DatabaseVariables.DatabaseService22.Add(Controller_UIHandling.addListArray(3, 2));

            // Service 27
            DatabaseVariables.DatabaseService27 = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService27.Add(Controller_UIHandling.addListArray(2, 2));
            DatabaseVariables.DatabaseService27.Add(Controller_UIHandling.addListArray(2, 4));
            DatabaseVariables.DatabaseService27.Add(Controller_UIHandling.addListArray(15, 3));
            DatabaseVariables.DatabaseService27.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService27.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 28
            DatabaseVariables.DatabaseService28 = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService28.Add(Controller_UIHandling.addListArray(4, 4));
            DatabaseVariables.DatabaseService28.Add(Controller_UIHandling.addListArray(2, 4));
            DatabaseVariables.DatabaseService28.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService28.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService28.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 2E
            DatabaseVariables.DatabaseService2E = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(100, 5));
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(100, 5));
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(2, 2));
            DatabaseVariables.DatabaseService2E.Add(Controller_UIHandling.addListArray(3, 2));

            // Service 31
            //DatabaseVariables.DatabaseService31 = new List<List<string[]>> { };
            //DatabaseVariables.DatabaseService31.Add(Controller_UIHandling.addListArray(3, 2));
            //DatabaseVariables.DatabaseService31.Add(Controller_UIHandling.addListArray(5, 4));
            //DatabaseVariables.DatabaseService31.Add(Controller_UIHandling.addListArray(15, 2));
            //DatabaseVariables.DatabaseService31.Add(Controller_UIHandling.addListArray(4, 5));
            //DatabaseVariables.DatabaseService31.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 3E
            DatabaseVariables.DatabaseService3E = new List<List<string[]>> { };
            DatabaseVariables.DatabaseService3E.Add(Controller_UIHandling.addListArray(1, 2));
            DatabaseVariables.DatabaseService3E.Add(Controller_UIHandling.addListArray(2, 4));
            DatabaseVariables.DatabaseService3E.Add(Controller_UIHandling.addListArray(15, 2));
            DatabaseVariables.DatabaseService3E.Add(Controller_UIHandling.addListArray(4, 5));
            DatabaseVariables.DatabaseService3E.Add(Controller_UIHandling.addListArray(2, 2));

            // Service 85
            //DatabaseVariables.DatabaseService85 = new List<List<string[]>> { };
            //DatabaseVariables.DatabaseService85.Add(Controller_UIHandling.addListArray(3, 2));
            //DatabaseVariables.DatabaseService85.Add(Controller_UIHandling.addListArray(5, 4));
            //DatabaseVariables.DatabaseService85.Add(Controller_UIHandling.addListArray(15, 2));
            //DatabaseVariables.DatabaseService85.Add(Controller_UIHandling.addListArray(4, 5));
            //DatabaseVariables.DatabaseService85.Add(Controller_UIHandling.addListArray(2, 2));

            // Can TP
            //DatabaseVariables.DatabaseCanTP = new List<List<string[]>> { };
            //DatabaseVariables.DatabaseCanTP.Add(Controller_UIHandling.addListArray(3, 2));
            //DatabaseVariables.DatabaseCanTP.Add(Controller_UIHandling.addListArray(5, 4));
            //DatabaseVariables.DatabaseCanTP.Add(Controller_UIHandling.addListArray(15, 2));
            //DatabaseVariables.DatabaseCanTP.Add(Controller_UIHandling.addListArray(4, 5));
            //DatabaseVariables.DatabaseCanTP.Add(Controller_UIHandling.addListArray(2, 2));

        }

        public static void TestcaseVariableDefinition()
        {
            TestcaseVariables.DirectoryOutputTestcase = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Testcase")).LocalPath;
            TestcaseVariables.NameOutputTestcase = "Testcase_" + UIVariables.ProjectName + "_" + UIVariables.Variant + "_" + UIVariables.Release + "_DCOM.xlsx";
            TestcaseVariables.PathOutputTestcase = TestcaseVariables.DirectoryOutputTestcase + @"\" + TestcaseVariables.NameOutputTestcase;
            TestcaseVariables.SubID = TestcaseVariables.NameOutputTestcase.Remove(TestcaseVariables.NameOutputTestcase.Length - 5) + "_";
            
            TestcaseVariables.TestcaseColumnsName = new string[]
            {
                "ID",                 //0
                "MDC DCOM Tests",     //1
                "Test Description",   //2
                "TestSteps",          //3
                "Test Response",      //4
                "Teststep keywords",  //5
                "ObjectType",         //6
                "TestStatus",         //7
                "Project"             //8
            };

            TestcaseVariables.TestcaseColumnsWidth = new int[]
            {
                20, // "ID",                 //0
                50, // "MDC DCOM Tests",     //1
                20, // "Test Description",   //2
                50, // "TestSteps",          //3
                50, // "Test Response",      //4
                50, // "Teststep keywords",  //5
                10, // "ObjectType",         //6
                10, // "TestStatus",         //7
                10  // "Project"             //8
            };

            TestcaseVariables.ObjectType = new string[]
            {
                "Description",       // 0
                "Test group",        // 1
                "Automated Testcase",// 2
                "Manual Testcase"    // 3
            };

            TestcaseVariables.TestStatus = "implemented";
            TestcaseVariables.ServiceTestgroupIndex = new string[]
            {
                "2.1.1 ", // Service 10
                "2.1.2 ", // Service 11
                "2.1.3 ", // Service 19
                "2.1.4 ", // Service 22
                "2.1.5 ", // Service 27
                "2.1.6 ", // Service 28
                "2.1.7 ", // Service 2E
                "2.1.8 ", // Service 2F
                "2.1.9 ", // Service 31
                "2.1.10", // Service 3E
                "2.1.11"  // Service 85
            };

            TestcaseVariables.IDColumnIndex = 1;
            TestcaseVariables.ComponentColumnIndex = 2;
            TestcaseVariables.TestDescriptionColumnIndex = 3;
            TestcaseVariables.TestStepColumnIndex = 4;
            TestcaseVariables.TestResponseColumnIndex = 5;
            TestcaseVariables.TestStepKeywordColumnIndex = 6;
            TestcaseVariables.ObjectTypeColumnIndex = 7;
            TestcaseVariables.TestStatusColumnIndex = 8;
            TestcaseVariables.ProjectColumnIndex = 9;


            TestcaseVariables.ColorTestGroupInterior = System.Drawing.Color.FromArgb(200, 222, 232);
            TestcaseVariables.ColorTestCaseInterior = System.Drawing.Color.White;

            TestcaseVariables.isFaultEnable = false;
            TestcaseVariables.isFaultDisable = false;
            TestcaseVariables.isClearDTC = false;
        }
        
        public static void SystemVariableDefinition()
        {
            SystemVariables.dbLoadStatus = false;
            SystemVariables.checkDBVariableDefinitionStatus = false;
            SystemVariables.currentApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            SystemVariables.backupFileName = "BackupFile.txt";
            SystemVariables.backupFilePath = new Uri(Path.Combine(SystemVariables.currentApplicationPath, SystemVariables.backupFileName)).LocalPath;
            SystemVariables.templateFileServerPath = @"\\bosch.com\dfsrb\DfsVN\LOC\Hc\RBVH\20_EDA\04_External\00_Common\02_EDA2\db_BGSV_EDA2_Automation_Tool\DCOM\DB_Template\Template.xlsx";
            SystemVariables.templateFileLocalPath = new Uri(Path.Combine(SystemVariables.currentApplicationPath, @"DB_Template\Template.xlsx")).LocalPath;

            SystemVariables.NameOutputDatabase = "RequirementDB_" + UIVariables.ProjectName + "_" + UIVariables.Variant + "_" + UIVariables.Release + "_DCOM.xlsx";
            SystemVariables.DirectoryOutputDatabase = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "DB_Requirement")).LocalPath;
            SystemVariables.PathOutputDatabase = SystemVariables.DirectoryOutputDatabase + @"\" + SystemVariables.NameOutputDatabase;
        }
        
        public static void UIVariableDefinition()
        {

            UIVariables.edited_View = new bool[13]
            {
                true,  // View Setting
                true,  // View Service 10
                true,  // View Service 11
                true,  // View Service 14
                false,  // View Service 19
                true,  // View Service 22
                true,  // View Service 2E
                true,  // View Service 27
                true,  // View Service 28
                false,  // View Service 31
                true,  // View Service 3E
                false,  // View Service 85
                false,  // View CanTP
            };
            UIVariables.CompletedEdit = false;
            UIVariables.NRCs = new string[]
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
            UIVariables.SecurityUnlockLevel = new string[]
            {
                "1",
                "2",
                "3",
            };

            // Setting
            UIVariables.ProjectInformation = new string[] { };
            UIVariables.DatabaseSource = "Local";
            UIVariables.DatabasePath = "";
            UIVariables.LocalDatabaseDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), @"DB_Requirement\")).LocalPath;
            UIVariables.ServerDatabaseDirectory = @"\\bosch.com\dfsrb\DfsVN\LOC\Hc\RBVH\20_EDA\04_External\00_Common\02_EDA2\db_BGSV_EDA2_Automation_Tool\DCOM\DB_Requirement\";
            UIVariables.DBPath_LocalList = Directory.GetFiles(UIVariables.LocalDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);
            UIVariables.DBPath_ServerList = Directory.GetFiles(UIVariables.ServerDatabaseDirectory, "*.xlsx", SearchOption.AllDirectories);
            UIVariables.TestcaseDirectory = "";
            UIVariables.SelectedServiceStatus = new bool[]
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

            UIVariables.CommonSettingDatabase = new List<string[]>[] { };
            // Common Setting
            UIVariables.DatabaseCommonSettingCreateFault = new string[] { };
            UIVariables.DatabaseCommonSettingVehicleSpeed = new string[] { };
            UIVariables.DatabaseCommonSettingEngineStatus = new string[] { };
            UIVariables.DatabaseCommonSettingSecurityUnlock = new string[] { };

            // Common DID
            UIVariables.DatabaseCommonDIDCurrentSession = new string[] { };
            UIVariables.DatabaseCommonDIDInvalidCounter = new string[] { };
            UIVariables.DatabaseCommonDIDCurrentVoltage = new string[] { };


            // Project Information
            UIVariables.ProjectName = "";
            UIVariables.Variant = "";
            UIVariables.Release = "";
            UIVariables.RC = "";


            // Service 10
            UIVariables.Service10_ButtonStatus_SessionTransition = new bool[]
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
            UIVariables.Service10_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service10_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
            UIVariables.Service10_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service10_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service10_SubFunction = new List<string[]> { };
            UIVariables.Service10_NRCPriority = new string[15]
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

            UIVariables.Service10_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };

            UIVariables.Service10_ValidValueCondition = "";

            UIVariables.Service10_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };


            // Service 11

            UIVariables.Service11_ButtonStatus_ResetMode = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service11_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service11_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
            UIVariables.Service11_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service11_NRCPriority = new string[15]
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

            UIVariables.Service11_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };

            UIVariables.Service11_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service11_ValidValueCondition = "";
            UIVariables.Service11_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };


            // Service 14

            UIVariables.Service14_SubFunction = new List<string[]> { };
            UIVariables.Service14_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service14_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
            UIVariables.Service14_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service14_NRCPriority = new string[15]
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
            UIVariables.Service14_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service14_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service14_ValidValueCondition = "";
            UIVariables.Service14_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };

            // Service 19


            // Service 22

            UIVariables.Service22_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service22_NRCPriority = new string[15]
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
            UIVariables.Service22_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service22_ValidValueCondition = "";
            UIVariables.Service22_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service22_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service22_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service22_ButtonStatus_AllowSession = new bool[]
            {
                false,
                false,
                false,
            };

            // Service 2E

            UIVariables.Service2E_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service2E_SecurityUnlockLv = "";
            UIVariables.Service2E_NRCPriority = new string[15]
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

            UIVariables.Service2E_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service2E_ValidValueCondition = "";
            UIVariables.Service2E_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service2E_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service2E_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service2E_ButtonStatus_AllowSession = new bool[]
            {
                false,
                false,
                false,
            };

            // Service 27

            UIVariables.Service27_SubFunction = new List<string[]> { };
            UIVariables.Service27_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service27_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
            UIVariables.Service27_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service27_NRCPrioritySeed = new string[15]
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
            UIVariables.Service27_NRCPriorityKey = new string[15]
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
            UIVariables.Service27_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service27_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service27_ValidValueCondition = "";
            UIVariables.Service27_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };

            // Service 28

            UIVariables.Service28_ButtonStatus_ControlType = new bool[]
            {
                false,
                false,
                false,
                false,
            };
            UIVariables.Service28_ButtonStatus_CommunicationType = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service28_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            }; ;
            UIVariables.Service28_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false,
            };
            UIVariables.Service28_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service28_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service28_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service28_ValidValueCondition = "";
            UIVariables.Service28_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service28_NRCPriority = new string[15]
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

            UIVariables.Service3E_SubFunction = new List<string[]> { };
            UIVariables.Service3E_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service3E_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false,
            };
            UIVariables.Service3E_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service3E_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service3E_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service3E_ValidValueCondition = "";
            UIVariables.Service3E_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service3E_NRCPriority = new string[15]
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

            UIVariables.Service85_SubFunction = new List<string[]> { };
            UIVariables.Service85_ButtonStatus_Optional = new bool[]
            {
                false,
                false,
            };
            UIVariables.Service85_ButtonStatus_AddressingMode = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false,
            };
            UIVariables.Service85_ButtonStatus_Condition = new bool[]
            {
                false,
                false,
                false,
            };
            UIVariables.Service85_NRCCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service85_InvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service85_ValidValueCondition = "";
            UIVariables.Service85_NameInvalidValueCondition = new string[]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };
            UIVariables.Service85_NRCPriority = new string[15]
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
}
