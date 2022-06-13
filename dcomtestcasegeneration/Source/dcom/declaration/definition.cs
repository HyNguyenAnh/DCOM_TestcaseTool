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
            DatabaseVariables.NameOutputDatabase = "RequirementDB_" + DatabaseVariables.ProjectName + "_" + DatabaseVariables.Variant + "_" + DatabaseVariables.Release + "_DCOM.xlsx";
            DatabaseVariables.DirectoryOutputDatabase = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "RequirementDB")).LocalPath;
            DatabaseVariables.PathOutputDatabase = DatabaseVariables.DirectoryOutputDatabase + @"\" + DatabaseVariables.NameOutputDatabase;

            DatabaseVariables.StartRowIndexDatabaseTables = new int[]
            {   2,  // Common Setting
                21, // Common DID
                31, // Project Information
                41, // Data Path Information
                51, // Selected Service
                3,  // Specification
                3,  // Allow session
                3,  // NRC
                3,  // Condition
                3,  // Optional
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
                19, // Optional
            };

        }

        public static void DatabaseVariableDefinition()
        {

            DatabaseVariables.StartRowIndexDatabaseTables = new int[]
            {   2,  // Common Setting
                21, // Common DID
                31, // Project Information
                41, // Data Path Information
                51, // Selected Service
                3,  // Specification
                3,  // Allow session
                3,  // NRC
                3,  // Condition
                3,  // Optional
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
                19, // Optional
            };


            // Get data from database
            List<string[]>[] CommonSettingDatabase = new List<string[]>[]{
                Model_GetCommonSettingDatabase.CommonSetting(),
                Model_GetCommonSettingDatabase.CommonDID(),
                Model_GetCommonSettingDatabase.ProjectInformation(),
                Model_GetCommonSettingDatabase.DataPathInformation(),
                Model_GetCommonSettingDatabase.SelectedServiceInformation(),
            };
            // Common Setting
            DatabaseVariables.DatabaseCommonSettingCreateFault = CommonSettingDatabase[0].ElementAt(0);
            DatabaseVariables.DatabaseCommonSettingVehicleSpeed = CommonSettingDatabase[0].ElementAt(1);
            DatabaseVariables.DatabaseCommonSettingEngineStatus = CommonSettingDatabase[0].ElementAt(2);
            DatabaseVariables.DatabaseCommonSettingSecurityUnlock = CommonSettingDatabase[0].ElementAt(3);

            DatabaseVariables.DatabaseCommonSetting = new List<string[]>
            {
                DatabaseVariables.DatabaseCommonSettingCreateFault,
                DatabaseVariables.DatabaseCommonSettingVehicleSpeed,
                DatabaseVariables.DatabaseCommonSettingEngineStatus,
                DatabaseVariables.DatabaseCommonSettingSecurityUnlock,
            };

            // Common DID
            DatabaseVariables.DatabaseCommonDIDCurrentSession = CommonSettingDatabase[1].ElementAt(0);
            DatabaseVariables.DatabaseCommonDIDInvalidCounter = CommonSettingDatabase[1].ElementAt(1);
            DatabaseVariables.DatabaseCommonDIDCurrentVoltage = CommonSettingDatabase[1].ElementAt(2);

            DatabaseVariables.DatabaseCommonDID = new List<string[]>
            {
                DatabaseVariables.DatabaseCommonDIDCurrentSession,
                DatabaseVariables.DatabaseCommonDIDInvalidCounter,
                DatabaseVariables.DatabaseCommonDIDCurrentVoltage,
            };

            // Project Information
            DatabaseVariables.ProjectName = CommonSettingDatabase[2].ElementAt(0)[1];
            DatabaseVariables.Variant = CommonSettingDatabase[2].ElementAt(1)[1];
            DatabaseVariables.Release = CommonSettingDatabase[2].ElementAt(2)[1];
            DatabaseVariables.RC = CommonSettingDatabase[2].ElementAt(3)[1];

            // Data Path Information
            DatabaseVariables.DatabaseSource = CommonSettingDatabase[3].ElementAt(0)[1];
            string[] databasePathSplit = DatabaseVariables.DatabasePath.Split('\\');
            DatabaseVariables.DatabaseDirectory = DatabaseVariables.DatabasePath.Replace(@"\" + databasePathSplit[databasePathSplit.Length - 1], "");
            string[] databaseDirectorySplit = DatabaseVariables.DatabaseDirectory.Split('\\');
            DatabaseVariables.TestcaseDirectory = DatabaseVariables.DatabaseDirectory.Replace(@"\" + databaseDirectorySplit[databaseDirectorySplit.Length - 1], "") + @"\Template";
            DatabaseVariables.TemplatePath = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), @"DB\Template.xlsx")).LocalPath;

            // Selected Service Information
            for (int index = 0; index < CommonSettingDatabase[4].Count; index++)
            {
                DatabaseVariables.SelectedServiceStatus[index] = Controller_ServiceHandling.ConvertFromStringToBool(CommonSettingDatabase[4].ElementAt(index)[1]);
            }


            // Service 10
            DatabaseVariables.DatabaseService10 = Model_GetServiceDatabase.DatabaseService("10");

            // Service 11
            DatabaseVariables.DatabaseService11 = Model_GetServiceDatabase.DatabaseService("11");
            
            // Service 14
            DatabaseVariables.DatabaseService14 = Model_GetServiceDatabase.DatabaseService("14");

            // Service 19
            DatabaseVariables.DatabaseService19 = Model_GetServiceDatabase.DatabaseService("19");

            // Service 22
            DatabaseVariables.DatabaseService22 = Model_GetServiceDatabase.DatabaseService("22");

            // Service 27
            DatabaseVariables.DatabaseService27 = Model_GetServiceDatabase.DatabaseService("27");

            // Service 28
            DatabaseVariables.DatabaseService28 = Model_GetServiceDatabase.DatabaseService("28");

            // Service 2E
            DatabaseVariables.DatabaseService2E = Model_GetServiceDatabase.DatabaseService("2E");

            // Service 31
            DatabaseVariables.DatabaseService31 = Model_GetServiceDatabase.DatabaseService("31");

            // Service 3E
            DatabaseVariables.DatabaseService3E = Model_GetServiceDatabase.DatabaseService("3E");

            // Service 85
            DatabaseVariables.DatabaseService85 = Model_GetServiceDatabase.DatabaseService("85");

            // Can TP
            DatabaseVariables.DatabaseCanTP = Model_GetServiceDatabase.DatabaseService("CanTP");

        }
        
        public static void TestcaseVariableDefinition()
        {

            TestcaseVariables.NameOutputTestcase = DatabaseVariables.ProjectName + "_" + DatabaseVariables.Variant + "_" + DatabaseVariables.Release + "_DCOM.xlsx";
            TestcaseVariables.DirectoryOutputTestcase = DatabaseVariables.TestcaseDirectory;
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


            TestcaseVariables.ColorTestGroupInterior = System.Drawing.Color.FromArgb(169, 208, 142);
            TestcaseVariables.ColorTestCaseInterior = System.Drawing.Color.White;

        }
        
        public static void SystemVariableDefinition()
        {
            SystemVariables.currentApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            SystemVariables.backupFileName = "BackupFile.txt";
            SystemVariables.backupFilePath = new Uri(Path.Combine(SystemVariables.currentApplicationPath, SystemVariables.backupFileName)).LocalPath;
            
        }
        
        public static void UIVariableDefinition()
        {
            // Service 10

            Controllers_UIService.LoadUI_Service10();

            // Service 11

            Controllers_UIService.LoadUI_Service11();

            // Service 14

            Controllers_UIService.LoadUI_Service14();

            // Service 19

            Controllers_UIService.LoadUI_Service19();

            // Service 22

            Controllers_UIService.LoadUI_Service22();

            // Service 2E

            Controllers_UIService.LoadUI_Service2E();

            // Service 27

            Controllers_UIService.LoadUI_Service27();

            // Service 28

            Controllers_UIService.LoadUI_Service28();

            // Service 3E

            Controllers_UIService.LoadUI_Service3E();

            // Service 85

            Controllers_UIService.LoadUI_Service85();
        }
    }
}
