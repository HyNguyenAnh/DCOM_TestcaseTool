using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_testcaseHandling
{
    class Model_PushTestcaseService2E
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "2E";
        public static List<string[]> DIDTableData = new List<string[]>();
        public static string[] DIDGroup;
        public static string currentDID;
        public static List<string[]> DIDGroupTestcaseTemp = new List<string[]>();
        public static List<List<string[]>> DIDGroupTestcaseSorted = new List<List<string[]>>();

        public static List<string[]> Specification = DatabaseVariables.DatabaseService2E.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService2E.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService2E.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService2E.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService2E.ElementAt(4);

        // Condition
        public static List<string[]> VehicleSpeedCondition { get; set; }
        public static List<string[]> EngineStatusCondition { get; set; }
        public static List<string[]> VoltageCondition { get; set; }

        public static void PushTestcaseService2E(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                //SuppressBitComponent(ws, rowIndex);
                DIDComponent(ws, rowIndex);
                ConditionCheckComponent(ws, rowIndex);
                //NRCComponent(ws, rowIndex);

                // return a current ID
                declaration.TestcaseVariables.ID = rowIndex;
            }

        }

        public static void TestGroupComponent(Worksheet ws, int startRowIndex)
        {
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + Controller_ServiceHandling.GetServiceTestGroupTitle(SID);
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;
        }
        public static void AllowSessionComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;
            string GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check all allowed diagnostic sessions";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all supported addressing mode in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAddressingModeComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void SuppressBitComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check suppress bit in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check suppress bit";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService11.GetTestRequestSuppressBitComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService11.GetTestRequestSuppressBitComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService11.GetTestRequestSuppressBitComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void DIDComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;
            
            DIDGroup = new string[DatabaseVariables.DatabaseService2E.ElementAt(0).Count];
            for(int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(0).Count ; index++)
            {
                DIDTableData.Add(DatabaseVariables.DatabaseService2E.ElementAt(0)[index].Concat(DatabaseVariables.DatabaseService2E.ElementAt(1)[index]).ToArray());
                DIDGroup[index] = DatabaseVariables.DatabaseService2E.ElementAt(0)[index][1];
            }
            DIDGroup = new HashSet<string>(DIDGroup).ToArray();

            for (int DIDIndex = 0; DIDIndex < DIDGroup.Length; DIDIndex++)
            {
                currentDID = DIDGroup[DIDIndex];
                for (int index = 0; index < DIDTableData.Count; index++)
                {
                    if (DIDTableData.ElementAt(index)[1] == currentDID)
                    {
                        DIDGroupTestcaseTemp.Add(DIDTableData.ElementAt(index).ToArray());
                    }
                    else
                    {
                        //
                    }
                }
                

                // Test group : DID Check in Extended SS
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " LabT_DCOM:Service " + SID + ":Default DID in Extended Session" + DIDGroup[DIDIndex];
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.TestDescriptionColumnIndex] = "DID - Extended";
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetDIDCheckComponentInExtended(DIDGroupTestcaseTemp)[0];
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetDIDCheckComponentInExtended(DIDGroupTestcaseTemp)[1];
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetDIDCheckComponentInExtended(DIDGroupTestcaseTemp)[2];
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                DIDGroupTestcaseTemp.Clear();
            }
        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;

            VehicleSpeedCondition = new List<string[]>();
            EngineStatusCondition = new List<string[]>();
            VoltageCondition = new List<string[]>();

            // Get groups of Condition
            for (int index = 0; index < Condition.Count; index++)
            {
                if (Condition[index][0] == "Vehicle_Speed")
                {
                    VehicleSpeedCondition.Add(Condition[index]);
                }
                else if (Condition[index][0] == "Engine_Status")
                {
                    EngineStatusCondition.Add(Condition[index]);
                }
                else
                {
                    VoltageCondition.Add(Condition[index]);
                }
            }


            if (UIVariables.DatabaseCommonSetting[1][1] != "")
            {
                for (int index = 0; index < VehicleSpeedCondition.Count; index++)
                {
                    subRowIndex++;

                    GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service 0x{SID}: Check {VehicleSpeedCondition.ElementAt(index)[0]} condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[0];
                    ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[1];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[2];
                    ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                    ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                    rowIndex++;
                    startRowIndex++;
                }
            }
            else { }
            if (UIVariables.DatabaseCommonSetting[2][1] != "")
            {
                for (int index = 0; index < EngineStatusCondition.Count; index++)
                {
                    subRowIndex++;

                    GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service 0x{SID}: Check {EngineStatusCondition.ElementAt(index)[0]} ({EngineStatusCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                    ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[0];
                    ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[1];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[2];
                    ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                    ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                    rowIndex++;
                    startRowIndex++;
                }
            }
            else { }
            for (int index = 0; index < VoltageCondition.Count; index++)
            {
                subRowIndex++;

                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service 0x{SID}: Check {VoltageCondition.ElementAt(index)[0]} ({VoltageCondition.ElementAt(index)[2]}) condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                startRowIndex++;
            }
        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all supported NRC in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported NRC";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
    }
    class Model_GetTestRequestService2E
    {
        public static string SID = "2E";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService2E.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService2E.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService2E.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService2E.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService2E.ElementAt(4);
        public static List<string[]> SIDSupported = DatabaseVariables.DatabaseService2E.ElementAt(5);

        // SubFuntion Mode
        public static string[] subFunctionMode = new string[3]
        {
            "03",
            "02",
            "01",
        };

        public static string[] parametters = Controller_ServiceHandling.GetParameters(Specification);
        public static string CurrentSessionDIDCodeString = UIVariables.DatabaseCommonDID[0][1];
        public static string[] GetTestRequestAllowSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            int securityAccessLevel = 1;

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length; subFunctionModeIndex++)
                {
                    step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: $".*{{1}}{Int32.Parse(subFunctionMode[subFunctionModeIndex])}",
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(Int32.Parse(subFunctionMode[subFunctionModeIndex]) - 1)[1]),
                                                                                        isParameterSupported: true, addressingMode: true,
                                                                                        length: 0)[index] + "\n"
                    ;
                    TestStepIndex += 3;
                    if (securityAccessLevel <= Int32.Parse(Optional.ElementAt(1)[1]))
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel($"{securityAccessLevel}", status: true, timeout: 1000)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel($"{securityAccessLevel}", status: false, timeout: 1000)[index] + "\n"
                            ;
                        TestStepIndex += 2;
                        securityAccessLevel++;
                    }
                }
                step +=
                   (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[2])[index] + "\n" +
                   (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                   (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
                   ;

                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }

            }
            str = new string[]
            {
                    TestStep,
                    TestResponse,
                    TeststepKeyword
            };

            return str;
        }
        public static string[] GetTestRequestAddressingModeComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            int securityAccessLevel = 1;


            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                        ;
                    TestStepIndex += 2;
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: $".*{{1}}{Int32.Parse(subFunctionMode[subFunctionModeIndex])}",
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(Int32.Parse(subFunctionMode[subFunctionModeIndex]) - 1)[1]),
                                                                                        isParameterSupported: true, addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                        length: 0)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        if (securityAccessLevel <= Int32.Parse(Optional.ElementAt(1)[1]))
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel($"{securityAccessLevel}", status: true, timeout: 1000)[index] + "\n" +
                                (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel($"{securityAccessLevel}", status: false, timeout: 1000)[index] + "\n"
                                ;
                            TestStepIndex += 2;
                            securityAccessLevel++;
                        }
                    }
                }

                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[2])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
                    ;

                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            str = new string[3]
            {
                TestStep,
                TestResponse,
                TeststepKeyword
            };

            return str;
        }
        public static string[] GetDIDCheckComponentInExtended(List<string[]> DIDGroupTestcaseSorted)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel(Optional.ElementAt(1)[1], true, 1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel(Optional.ElementAt(1)[1], false, 1000)[index] + "\n"
                    ;
                TestStepIndex += 7;
                for (int DIDVal = 0; DIDVal < DIDGroupTestcaseSorted.Count; DIDVal++)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        // Expected value with empty case
                        string expectedValue;
                        if (DIDGroupTestcaseSorted.ElementAt(DIDVal)[1].ToLower() == "f1fd")
                        {
                            expectedValue = "{" + (Convert.ToInt32(DIDGroupTestcaseSorted.ElementAt(DIDVal)[2]) * 2 - 1) + "}3";
                        }
                        else
                        {
                            expectedValue = DIDGroupTestcaseSorted.ElementAt(DIDVal)[3];
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: DIDGroupTestcaseSorted.ElementAt(DIDVal)[1],
                                                                                                expectedValue: expectedValue,
                                                                                                isSIDSupportedInActiveSession: (Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(2)[1]) && Controller_ServiceHandling.ConvertFromStringToBool(DIDGroupTestcaseSorted.ElementAt(DIDVal)[9])),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(DIDGroupTestcaseSorted.ElementAt(DIDVal)[5 + addressingModeIndex]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                length: Convert.ToInt32(DIDGroupTestcaseSorted.ElementAt(DIDVal)[2]))[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
                    ;
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            str = new string[3]
            {
                TestStep,
                TestResponse,
                TeststepKeyword
            };
            return str;
        }
        public static string[] GetTestRequestVehicleSpeedConditionCheckComponent(string[] conditionGroupTestcase)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            double invalidValue;

            if (Controller_ServiceHandling.ConvertFromStringToBool(conditionGroupTestcase[3]))
            {
                invalidValue = Convert.ToDouble(conditionGroupTestcase[1]);
            }
            else
            {
                invalidValue = 0;
            }
            if ((invalidValue <= 0) | (invalidValue == 10))
            {
                for (int index = 0; index < 3; index++)
                {
                    int TestStepIndex = 0;
                    string step = "";
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: invalidValue, timeout: 100)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                length: 0,
                                                                                                invalidValue: invalidValue, setInvalidValue: invalidValue,
                                                                                                conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < 3; index++)
                {
                    int TestStepIndex = 0;
                    string step = "";
                    for (double vehicleValue = 0; vehicleValue < 3; vehicleValue++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue), timeout: 100)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                    isSIDSupportedInActiveSession: true,
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                    length: 0,
                                                                                                    setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue),
                                                                                                    conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                ;
                            TestStepIndex += 1;
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: 0, timeout: 100)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                    isSIDSupportedInActiveSession: true,
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                    length: 0,
                                                                                                    invalidValue: invalidValue, setInvalidValue: 0,
                                                                                                    conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                ;
                            TestStepIndex += 1;
                        }
                    }
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
            }

            str = new string[3]
            {
                TestStep,
                TestResponse,
                TeststepKeyword
            };

            return str;
        }
        public static string[] GetTestRequestEngineStatusConditionCheckComponent(string[] conditionGroupTestcase)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            double invalidValue;
            double validValue;

            if (Controller_ServiceHandling.ConvertFromStringToBool(conditionGroupTestcase[3]))
            {
                invalidValue = Convert.ToDouble(conditionGroupTestcase[1]);
                validValue = 0;
            }
            else
            {
                invalidValue = 0;
                validValue = Convert.ToDouble(conditionGroupTestcase[1]);
            }

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetEngineStatus(invalidValue: invalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                            isSIDSupportedInActiveSession: true,
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                            length: 0,
                                                                                            invalidValue: invalidValue, setInvalidValue: validValue,
                                                                                            conditionIndex: 2, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                        ;
                    TestStepIndex += 1;
                }
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            str = new string[]{
                TestStep,
                TestResponse,
                TeststepKeyword
            };

            return str;
        }
        public static string[] GetTestRequestVoltageConditionCheckComponent(string[] conditionGroupTestcase)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            double invalidValue = 12;
            double setInvalidValue;

            if (Controller_ServiceHandling.ConvertFromStringToBool(conditionGroupTestcase[3]))
            {
                setInvalidValue = Convert.ToDouble(conditionGroupTestcase[1]);
            }
            else
            {
                setInvalidValue = 0;
            }
            if (setInvalidValue != 0)
            {
                for (int index = 0; index < 3; index++)
                {
                    int TestStepIndex = 0;
                    string step = "";
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: setInvalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                length: 0,
                                                                                                invalidValue: invalidValue, setInvalidValue: setInvalidValue,
                                                                                                conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                length: 0,
                                                                                                invalidValue: invalidValue, setInvalidValue: invalidValue,
                                                                                                conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < 3; index++)
                {
                    int TestStepIndex = 0;
                    string step = "";
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: setInvalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                length: 0,
                                                                                                invalidValue: invalidValue, setInvalidValue: invalidValue,
                                                                                                conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
            }
            str = new string[]{
                TestStep,
                TestResponse,
                TeststepKeyword
            };

            return str;
        }
        public static string[] GetTestRequestNRCComponent()
        {
            string TestStep;
            string TestResponse;
            string TeststepKeyword;
            string[] str;

            TestStep = "";


            TestResponse = "";


            TeststepKeyword = "";

            str = new string[]{
                TestStep,
                TestResponse,
                TeststepKeyword
            };

            return str;
        }
    }
}
