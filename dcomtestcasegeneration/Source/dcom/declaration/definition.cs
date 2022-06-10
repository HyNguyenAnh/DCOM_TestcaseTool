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

            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingCreateFault);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingVehicleSpeed);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingEngineStatus);
            DatabaseVariables.DatabaseCommonSetting.Add(DatabaseVariables.DatabaseCommonSettingSecurityUnlock);

            // Common DID
            DatabaseVariables.DatabaseCommonDIDCurrentSession = CommonSettingDatabase[1].ElementAt(0);
            DatabaseVariables.DatabaseCommonDIDInvalidCounter = CommonSettingDatabase[1].ElementAt(1);
            DatabaseVariables.DatabaseCommonDIDCurrentVoltage = CommonSettingDatabase[1].ElementAt(2);

            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDCurrentSession);
            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDInvalidCounter);
            DatabaseVariables.DatabaseCommonDID.Add(DatabaseVariables.DatabaseCommonDIDCurrentVoltage);

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

            // Sub Function
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService10.ElementAt(0)[index][1] = "1";
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service10_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service10_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[1][index - 2]);
                }
            }

            // Session Transition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_SessionTransition.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[2][index + 1]);
                }
                else if ((index < 6) && (index > 2))
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[3][index - 2]);
                }
                else
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[4][index - 5]);
                }
            }
            
            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(2).Count; index++)
            {
                UIVariables.Service10_NRCPriority[index] = DatabaseVariables.DatabaseService10.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service10_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(3)[index][2]);
            }
            for (int index = 0; index < UIVariables.Service10_NRCCondition.Length; index++)
            {
                UIVariables.Service10_NRCCondition[index] = DatabaseVariables.DatabaseService10.ElementAt(3)[index][3];
            }
            for (int index = 0; index < UIVariables.Service10_InvalidValueCondition.Length; index++)
            {
                UIVariables.Service10_InvalidValueCondition[index] = DatabaseVariables.DatabaseService10.ElementAt(3)[index][1];
            }

            // SuppressBit
            UIVariables.Service10_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(4)[0][1]);


            // Service 11

            // Sub Function | Reset Mode
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_ResetMode.Length; index++)
            {
                UIVariables.Service11_ButtonStatus_ResetMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(0)[index][1]);
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(2).Count; index++)
            {
                UIVariables.Service11_NRCPriority[index] = DatabaseVariables.DatabaseService11.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service11_InvalidValueCondition[index] = DatabaseVariables.DatabaseService11.ElementAt(3)[index][1];
                UIVariables.Service11_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(3)[index][2]);
                UIVariables.Service11_NRCCondition[index] = DatabaseVariables.DatabaseService11.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service11_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(4)[0][1]);


            // Service 14

            // Sub Function
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService14.ElementAt(0)[index][0] = "ffff";
                DatabaseVariables.DatabaseService14.ElementAt(0)[index][1] = "1";
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service14_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service14_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(2).Count; index++)
            {
                UIVariables.Service14_NRCPriority[index] = DatabaseVariables.DatabaseService14.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service14_InvalidValueCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(3)[index][1];
                UIVariables.Service14_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(3)[index][2]);
                UIVariables.Service14_NRCCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(3)[index][3];
            }
            //for (int index = 0; index < UIVariables.Service14_NRCCondition.Length; index++)
            //{
                
            //}
            //for (int index = 0; index < UIVariables.Service14_InvalidValueCondition.Length; index++)
            //{
            //    try
            //    {
            //        UIVariables.Service14_InvalidValueCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(3)[index][1];
            //    }
            //    catch
            //    {
            //        UIVariables.Service14_InvalidValueCondition[index] = "";
            //    }
            //}

            // Optional
            UIVariables.Service14_ButtonStatus_SuppressBit = false;


            // Service 19



            // Service 22

            // Specification
            for(int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(0).Count; index++)
            {
                UIVariables.Service22_DIDTable_Specification.Add(DatabaseVariables.DatabaseService22.ElementAt(0).ElementAt(index));
            }

            // Addressing Mode
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService22.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(1)[index][index_]));
                }
                UIVariables.Service22_DIDTable_AddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(2).Count; index++)
            {
                UIVariables.Service22_NRCPriority[index] = DatabaseVariables.DatabaseService22.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service22_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service22_InvalidValueCondition[index] = DatabaseVariables.DatabaseService22.ElementAt(3)[index][1];
                UIVariables.Service22_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(3)[index][2]);
                UIVariables.Service22_NRCCondition[index] = DatabaseVariables.DatabaseService22.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service22_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(4)[0][1]);


            // Service 2E

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(0).Count; index++)
            {
                UIVariables.Service2E_DIDTable_Specification.Add(DatabaseVariables.DatabaseService22.ElementAt(0).ElementAt(index));
            }

            // Addressing Mode
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService2E.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(1)[index][index_]));
                }
                UIVariables.Service2E_DIDTable_AddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(2).Count; index++)
            {
                UIVariables.Service2E_NRCPriority[index] = DatabaseVariables.DatabaseService2E.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service2E_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service2E_InvalidValueCondition[index] = DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1];
                UIVariables.Service2E_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(3)[index][2]);
                UIVariables.Service2E_NRCCondition[index] = DatabaseVariables.DatabaseService22.ElementAt(3)[index][3];
            }
            // Optional
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = Controller_ServiceHandling.ConvertFromStringLevelToBool(DatabaseVariables.DatabaseService22.ElementAt(4)[1][1]);


            // Service 27

            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService27.ElementAt(0)[index][1] = "1";
            }

            // Allow Session || Addressing Mode
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service27_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service27_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(2).Count; index++)
            {
                UIVariables.Service27_NRCPrioritySeed[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][1];
                UIVariables.Service27_NRCPriorityKey[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][2];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service27_InvalidValueCondition[index] = DatabaseVariables.DatabaseService27.ElementAt(3)[index][1];
                UIVariables.Service27_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(3)[index][2]);
                UIVariables.Service27_NRCCondition[index] = DatabaseVariables.DatabaseService27.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service27_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(4)[0][1]);
        }
    }
}
