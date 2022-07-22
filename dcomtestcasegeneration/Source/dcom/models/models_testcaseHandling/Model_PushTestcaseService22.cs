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
    class Model_PushTestcaseService22
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "22";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService22.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService22.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService22.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService22.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService22.ElementAt(4);

        // Condition
        public static List<string[]> VehicleSpeedCondition { get; set; }
        public static List<string[]> EngineStatusCondition { get; set; }
        public static List<string[]> VoltageCondition { get; set; }

        public static void PushTestcaseService22(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                DIDCheckComponent(ws, rowIndex);
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

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all allowed diagnostic sessions in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }   
        public static void DIDCheckComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;

            // Test group : DID Check in Default SS
            subRowIndex++;
            GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " LabT_DCOM:Service " + SID + ":Default DID in Default Session";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "DID - Default";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInDefault()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInDefault()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInDefault()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Test group : DID Check in Extended SS
            subRowIndex++;
            GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
            ws.Cells[startRowIndex + 1, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex + 1, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " LabT_DCOM:Service " + SID + ":Default DID in Extended Session";
            ws.Cells[startRowIndex + 1, TestcaseVariables.TestDescriptionColumnIndex] = "DID - Extended";
            ws.Cells[startRowIndex + 1, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInExtended()[0];
            ws.Cells[startRowIndex + 1, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInExtended()[1];
            ws.Cells[startRowIndex + 1, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInExtended()[2];
            ws.Cells[startRowIndex + 1, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex + 1, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex + 1, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Test group : DID Check in Programming SS
            subRowIndex++;
            GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
            ws.Cells[startRowIndex + 2, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex + 2, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " LabT_DCOM:Service " + SID + ":Default DID in Programming Session";
            ws.Cells[startRowIndex + 2, TestcaseVariables.TestDescriptionColumnIndex] = "DID - Programming";
            ws.Cells[startRowIndex + 2, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInProgramming()[0];
            ws.Cells[startRowIndex + 2, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInProgramming()[1];
            ws.Cells[startRowIndex + 2, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponentInProgramming()[2];
            ws.Cells[startRowIndex + 2, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex + 2, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex + 2, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;
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

            for (int index = 0; index < VehicleSpeedCondition.Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {VehicleSpeedCondition.ElementAt(index)[0]} ({VehicleSpeedCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                startRowIndex++;
            }
            for (int index = 0; index < EngineStatusCondition.Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {EngineStatusCondition.ElementAt(index)[0]} ({EngineStatusCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                startRowIndex++;
            }
            for (int index = 0; index < VoltageCondition.Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {VoltageCondition.ElementAt(index)[0]} ({VoltageCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[2];
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
    class Model_GetTestRequestService22
    {
        public static string SID = "22";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService22.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService22.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService22.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService22.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService22.ElementAt(4);
        public static List<string[]> SIDSupported = DatabaseVariables.DatabaseService22.ElementAt(5);

        // SubFuntion Mode
        public static string[] subFunctionMode = new string[3]
        {
            "01",
            "03",
            "02",
        };

        public static string[] parametters = Controller_ServiceHandling.GetParameters(Specification);
        public static string CurrentSessionDIDCodeString = UIVariables.DatabaseCommonDIDCurrentSession[1];
        public static string[] GetTestRequestAllowSessionComponent()
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
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" 
                    ;
                TestStepIndex += 1;
                for (int subFunctionIndex = 0; subFunctionIndex < subFunctionMode.Length; subFunctionIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: ".*{1}" + Int32.Parse(subFunctionMode[subFunctionIndex]), 
                                                                                            isSIDSupportedInActiveSession: true, isParameterSupported: true, 
                                                                                            addressingMode: true, length: 0)[index] + "\n" 
                        ;
                    TestStepIndex += 3;
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: ".*{1}1", 
                                                                                        isSIDSupportedInActiveSession: true, isParameterSupported: true, 
                                                                                        addressingMode: true, length: 0)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
        public static string[] GetTestRequestAddressingModeComponent()
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
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionIndex = 0; subFunctionIndex < subFunctionMode.Length; subFunctionIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                        ;
                    TestStepIndex += 2;
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: ".*{1}" + Int32.Parse(subFunctionMode[subFunctionIndex]),
                                                                                            isSIDSupportedInActiveSession: true, 
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                            length: 0)[index] + "\n"
                        ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                    ;
                TestStepIndex += 2;
                for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: ".*{1}1",
                                                                                            isSIDSupportedInActiveSession: true, 
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: true, 
                                                                                            length: 0)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                }
                    step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
        public static string[] GetDIDCheckComponentInDefault()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                    ;
                TestStepIndex += 3;
                for (int DIDVal = 0; DIDVal < Specification.Count; DIDVal++)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        string expectedValue;
                        if (Specification.ElementAt(DIDVal)[1].ToLower() == "f1fd")
                        {
                            expectedValue = "{" + (Convert.ToInt32(Specification.ElementAt(DIDVal)[2]) * 2 - 1) + "}1";
                        }
                        else
                        {
                            expectedValue = Specification.ElementAt(DIDVal)[3];
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: Specification.ElementAt(DIDVal)[1],
                                                                                                expectedValue: expectedValue,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowSession.ElementAt(DIDVal)[2]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                length: Convert.ToInt32(Specification.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
                    ;
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
                str = new string[]
                {
                TestStep,
                TestResponse,
                TeststepKeyword
                };
            }
            return str;
        }
        public static string[] GetDIDCheckComponentInExtended()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;

            for(int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                    ;
                TestStepIndex += 5;
                for (int DIDVal = 0; DIDVal < Specification.Count; DIDVal++)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        string expectedValue;
                        if (Specification.ElementAt(DIDVal)[1].ToLower() == "f1fd")
                        {
                            expectedValue = "{" + (Convert.ToInt32(Specification.ElementAt(DIDVal)[2]) * 2 - 1) + "}3";
                        }
                        else
                        {
                            expectedValue = Specification.ElementAt(DIDVal)[3];
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: Specification.ElementAt(DIDVal)[1],
                                                                                                expectedValue: expectedValue,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowSession.ElementAt(DIDVal)[4]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                length: Convert.ToInt32(Specification.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
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
        public static string[] GetDIDCheckComponentInProgramming()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            for(int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                        ;
                TestStepIndex += 7;
                for (int DIDVal = 0; DIDVal < Specification.Count; DIDVal++)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        string expectedValue;
                        if (Specification.ElementAt(DIDVal)[1].ToLower() == "f1fd")
                        {
                            expectedValue = "{" + (Convert.ToInt32(Specification.ElementAt(DIDVal)[2]) * 2 - 1) + "}2";
                        }
                        else
                        {
                            expectedValue = Specification.ElementAt(DIDVal)[3];
                        }
                        step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: Specification.ElementAt(DIDVal)[1],
                                                                                                expectedValue: expectedValue,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowSession.ElementAt(DIDVal)[3]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                length: Convert.ToInt32(Specification.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                length:0,
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
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: CurrentSessionDIDCodeString, expectedValue: ".*{1}",
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

