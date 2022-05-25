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
            DatabaseVariables.DatabaseCommonDIDCurrentVoltage = CommonSettingDatabase[2].ElementAt(2);

            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDCurrentSession);
            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDInvalidCounter);
            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDCurrentVoltage);

            // Project Information
            DatabaseVariables.ProjectName = CommonSettingDatabase[3].ElementAt(0)[1];
            DatabaseVariables.Variant = CommonSettingDatabase[3].ElementAt(1)[1];
            DatabaseVariables.Release = CommonSettingDatabase[3].ElementAt(2)[1];
            DatabaseVariables.RC = CommonSettingDatabase[3].ElementAt(3)[1];

            // Data Path Information
            DatabaseVariables.DatabaseSource = CommonSettingDatabase[4].ElementAt(0)[1];
            DatabaseVariables.PublicCANDBC = CommonSettingDatabase[4].ElementAt(2)[1];
            DatabaseVariables.PrivateCANDBC = CommonSettingDatabase[4].ElementAt(3)[1];
            string[] databasePathSplit = DatabaseVariables.DatabasePath.Split('\\');
            DatabaseVariables.DatabaseDirectory = DatabaseVariables.DatabasePath.Replace(@"\" + databasePathSplit[databasePathSplit.Length - 1], "");
            string[] databaseDirectorySplit = DatabaseVariables.DatabaseDirectory.Split('\\');
            DatabaseVariables.TestcaseDirectory = DatabaseVariables.DatabaseDirectory.Replace(@"\" + databaseDirectorySplit[databaseDirectorySplit.Length - 1], "") + @"\Template";
            DatabaseVariables.TemplatePath = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), @"DB\Template.xlsx")).LocalPath;

            // Selected Service Information
            DatabaseVariables.SelectedServiceStatus = new bool[12];
            for (int index = 0; index < CommonSettingDatabase[5].Count; index++)
            {
                DatabaseVariables.SelectedServiceStatus[index] = Controller_ServiceHandling.ConvertFromStringToBool(CommonSettingDatabase[5].ElementAt(index)[1]);
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
         // Service 10
            // Physiscal
            UIVariables.PhysicalDefaultService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[0][1];
            UIVariables.PhysicalProgrammingService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[0][2];
            UIVariables.PhysicalExtendedService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[0][3];
            
            // Functional
            UIVariables.FunctionalDefaultService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[1][1];
            UIVariables.FunctionalProgrammingService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[1][2];
            UIVariables.FunctionalExtendedService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[1][3];

            // Default
            UIVariables.DtoDService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[2][1] = "1";
            UIVariables.DtoPService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[2][2];
            UIVariables.DtoEService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[2][3];

            // Programming
            UIVariables.PtoDService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[3][1];
            UIVariables.PtoPService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[3][2] = "1";
            UIVariables.PtoEService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[3][3];

            // Extended
            UIVariables.EtoDService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[4][1];
            UIVariables.EtoPService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[4][2];
            UIVariables.EtoEService10 = DatabaseVariables.DatabaseService10.ElementAt(1)[4][3] = "1";

            // SuppressBit
            UIVariables.Service10_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(3)[2][1]);

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(2).Count; index++)
            {
                UIVariables.Service10_NRCPriority[index] = DatabaseVariables.DatabaseService10.ElementAt(2)[index][1];
            }

            // Addressing Mode
            string[] Service10_ButtonStatus_AddressingMode = new string[]
            {
                UIVariables.PhysicalDefaultService10,
                UIVariables.PhysicalProgrammingService10,
                UIVariables.PhysicalExtendedService10,
                UIVariables.FunctionalDefaultService10,
                UIVariables.FunctionalProgrammingService10,
                UIVariables.FunctionalExtendedService10,
            };
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_AddressingMode.Length; index++)
            {
                UIVariables.Service10_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(Service10_ButtonStatus_AddressingMode[index]);
            }

            // Sub Function
            string[] Service10_ButtonStatus_SubFunction = new string[]
            {
                
                UIVariables.DtoPService10,
                UIVariables.DtoEService10,
                UIVariables.PtoDService10,
                UIVariables.PtoEService10,
                UIVariables.EtoDService10,
                UIVariables.EtoPService10,
            };
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_SubFunction.Length; index++)
            {
                UIVariables.Service10_ButtonStatus_SubFunction[index] = Controller_ServiceHandling.ConvertFromStringToBool(Service10_ButtonStatus_SubFunction[index]);
            }

            // Condition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service10_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(4)[index][1]);
            }
            for (int index = 0; index < UIVariables.Service10_NRCCondition.Length; index++)
            {
                UIVariables.Service10_NRCCondition[index] = DatabaseVariables.DatabaseService10.ElementAt(4)[index][2];
            }

            // Service 11
            // Physiscal
            UIVariables.PhysicalDefaultService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[0][1];
            UIVariables.PhysicalProgrammingService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[0][2];
            UIVariables.PhysicalExtendedService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[0][3];

            // Functional
            UIVariables.FunctionalDefaultService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[1][1];
            UIVariables.FunctionalProgrammingService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[1][2];
            UIVariables.FunctionalExtendedService11 = DatabaseVariables.DatabaseService11.ElementAt(1)[1][3];


            UIVariables.Service11_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(3)[2][1]);

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(2).Count; index++)
            {
                UIVariables.Service11_NRCPriority[index] = DatabaseVariables.DatabaseService11.ElementAt(2)[index][1];
            }

            // Addressing Mode
            string[] Service11_ButtonStatus_AddressingMode = new string[]
            {
                UIVariables.PhysicalDefaultService11,
                UIVariables.PhysicalProgrammingService11,
                UIVariables.PhysicalExtendedService11,
                UIVariables.FunctionalDefaultService11,
                UIVariables.FunctionalProgrammingService11,
                UIVariables.FunctionalExtendedService11,
            };
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_AddressingMode.Length; index++)
            {
                UIVariables.Service11_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(Service11_ButtonStatus_AddressingMode[index]);
            }

            // Condition
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service11_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(4)[index][1]);
            }
            for (int index = 0; index < UIVariables.Service11_NRCCondition.Length; index++)
            {
                UIVariables.Service11_NRCCondition[index] = DatabaseVariables.DatabaseService11.ElementAt(4)[index][2];
            }

            // Service 14
            // Physiscal
            UIVariables.PhysicalDefaultService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[0][1];
            UIVariables.PhysicalProgrammingService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[0][2];
            UIVariables.PhysicalExtendedService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[0][3];

            // Functional
            UIVariables.FunctionalDefaultService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[1][1];
            UIVariables.FunctionalProgrammingService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[1][2];
            UIVariables.FunctionalExtendedService14 = DatabaseVariables.DatabaseService14.ElementAt(1)[1][3];

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(2).Count; index++)
            {
                UIVariables.Service14_NRCPriority[index] = DatabaseVariables.DatabaseService14.ElementAt(2)[index][1];
            }

            // Addressing Mode
            string[] Service14_ButtonStatus_AddressingMode = new string[]
            {
                UIVariables.PhysicalDefaultService14,
                UIVariables.PhysicalProgrammingService14,
                UIVariables.PhysicalExtendedService14,
                UIVariables.FunctionalDefaultService14,
                UIVariables.FunctionalProgrammingService14,
                UIVariables.FunctionalExtendedService14,
            };
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_AddressingMode.Length; index++)
            {
                UIVariables.Service14_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(Service14_ButtonStatus_AddressingMode[index]);
            }

            // Condition
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service14_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(4)[index][1]);
            }
            for (int index = 0; index < UIVariables.Service14_NRCCondition.Length; index++)
            {
                UIVariables.Service14_NRCCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(4)[index][2];
            }
        }
    }
}
