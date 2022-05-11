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

namespace dcom.declaration
{
    public class Definition
    {
        public static void VariableDefinition()
        {
            DatabaseVariableDefinition();
            TestcaseVariableDefinition();
            TemplateVariableDefinition();
            SystemVariableDefinition();
        }

        public static void TemplateVariableDefinition()
        {
            DatabaseVariables.NameOutputDatabase = "DB_" + DatabaseVariables.ProjectName + "_" + DatabaseVariables.Variant + "_" + DatabaseVariables.Release + "_DCOM.xlsx";
            DatabaseVariables.DirectoryOutputDatabase = DatabaseVariables.DatabaseDirectory;
            DatabaseVariables.PathOutputDatabase = DatabaseVariables.DirectoryOutputDatabase + @"\" + DatabaseVariables.NameOutputDatabase;

            DatabaseVariables.StartRowIndexDatabaseTables = new int[]
            {   2, // Common Setting
                11,// Common command
                21,// Common DID
                3, // Specification
                3, // Allow session
                4, // NRC
                101,// Optional
                112, // Precondition
                31, // Project Information
                41, // Data Path Information
                51  // Selected Service

            };
            DatabaseVariables.StartColumnIndexDatabaseTables = new int[]
            {   1, // Common Setting
                1, // Common command
                1, // Common DID
                1, // Specification
                6, // Allow session
                11,// NRC
                1, // Optional
                1, // Precondition
                1, // Project Information
                1, // Data Path Information
                1  // Selected Service
            };

        }

        public static void DatabaseVariableDefinition()
        {

            DatabaseVariables.StartRowIndexDatabaseTables = new int[]
            {   2, // Common Setting
                11,// Common command
                21,// Common DID
                3, // Specification
                3, // Allow session
                4, // NRC
                101,// Optional
                112, // Precondition
                31, // Project Information
                41, // Data Path Information
                51  // Selected Service

            };
            DatabaseVariables.StartColumnIndexDatabaseTables = new int[]
            {   1, // Common Setting
                1, // Common command
                1, // Common DID
                1, // Specification
                6, // Allow session
                11,// NRC
                1, // Optional
                1, // Precondition
                1, // Project Information
                1, // Data Path Information
                1  // Selected Service
            };

            // Get data from database
            List<string[]>[] CommonSettingDatabase = new List<string[]>[]{
                Model_GetCommonSettingDatabase.CommonSetting(),
                Model_GetCommonSettingDatabase.CommonCommand(),
                Model_GetCommonSettingDatabase.CommonDID(),
                Model_GetCommonSettingDatabase.ProjectInformation(),
                Model_GetCommonSettingDatabase.DataPathInformation(),
                Model_GetCommonSettingDatabase.SelectedServiceInformation(),
            };
            // Common Setting
            DatabaseVariables.DatabaseCommonSettingCreateFault = CommonSettingDatabase[0].ElementAt(0);
            DatabaseVariables.DatabaseCommonSettingVehicleSpeed = CommonSettingDatabase[0].ElementAt(1);
            DatabaseVariables.DatabaseCommonSettingEngineStatus = CommonSettingDatabase[0].ElementAt(2);
            DatabaseVariables.DatabaseCommonSettingPowerMode = CommonSettingDatabase[0].ElementAt(3);
            DatabaseVariables.DatabaseCommonSettingSecurityUnlock = CommonSettingDatabase[0].ElementAt(4);

            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingCreateFault);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingVehicleSpeed);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingEngineStatus);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingPowerMode);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingSecurityUnlock);


            // Common Command
            DatabaseVariables.DatabaseCommonCommandReadDTCStatusActive = CommonSettingDatabase[1].ElementAt(0);
            DatabaseVariables.DatabaseCommonCommandReadDTCStatusPassive = CommonSettingDatabase[1].ElementAt(1);
            DatabaseVariables.DatabaseCommonCommandReadDTCStatusNoDTC = CommonSettingDatabase[1].ElementAt(2);

            DatabaseVariables.DatabaseCommonCommand.Add(DatabaseVariables.DatabaseCommonCommandReadDTCStatusActive);
            DatabaseVariables.DatabaseCommonCommand.Add(DatabaseVariables.DatabaseCommonCommandReadDTCStatusPassive);
            DatabaseVariables.DatabaseCommonCommand.Add(DatabaseVariables.DatabaseCommonCommandReadDTCStatusNoDTC);

            // Common DID
            DatabaseVariables.DatabaseCommonDIDCurrentSession = CommonSettingDatabase[2].ElementAt(0);
            DatabaseVariables.DatabaseCommonDIDInvalidCounter = CommonSettingDatabase[2].ElementAt(1);

            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDCurrentSession);
            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDInvalidCounter);

            // Project Information
            DatabaseVariables.ProjectName = CommonSettingDatabase[3].ElementAt(0)[1];
            DatabaseVariables.Variant = CommonSettingDatabase[3].ElementAt(1)[1];
            DatabaseVariables.Release = CommonSettingDatabase[3].ElementAt(2)[1];
            DatabaseVariables.RC = CommonSettingDatabase[3].ElementAt(3)[1];

            // Data Path Information
            DatabaseVariables.DatabaseSource = CommonSettingDatabase[4].ElementAt(0)[1];
            DatabaseVariables.PublicCANDBC = CommonSettingDatabase[4].ElementAt(2)[1];
            DatabaseVariables.PrivateCANDBC = CommonSettingDatabase[4].ElementAt(3)[1];
            DatabaseVariables.TestcaseDirectory = CommonSettingDatabase[4].ElementAt(4)[1];
            DatabaseVariables.TemplatePath = CommonSettingDatabase[4].ElementAt(5)[1];
            DatabaseVariables.DatabaseDirectory = CommonSettingDatabase[4].ElementAt(6)[1];

            // Selected Service Information
            DatabaseVariables.SelectedServiceStatus = new bool[12];
            for (int index = 0; index < CommonSettingDatabase[5].Count; index++)
            {
                DatabaseVariables.SelectedServiceStatus[index] = controllers.controllers_middleware.Controller_ServiceHandling.ConvertFromStringToBool(CommonSettingDatabase[5].ElementAt(index)[1]);
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

            // Service 2F
            DatabaseVariables.DatabaseService2F = Model_GetServiceDatabase.DatabaseService("2F");

            // Service 31
            DatabaseVariables.DatabaseService31 = Model_GetServiceDatabase.DatabaseService("31");

            // Service 3E
            DatabaseVariables.DatabaseService3E = Model_GetServiceDatabase.DatabaseService("3E");

            // Service 85
            DatabaseVariables.DatabaseService85 = Model_GetServiceDatabase.DatabaseService("85");

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
            //
        }
    }
}
