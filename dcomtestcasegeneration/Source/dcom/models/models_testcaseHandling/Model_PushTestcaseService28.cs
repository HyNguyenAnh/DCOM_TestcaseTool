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
    class Model_PushTestcaseService28
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "28";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService28.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService28.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService28.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService28.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService28.ElementAt(4);

        // Condition
        public static List<string[]> VehicleSpeedCondition { get; set; }
        public static List<string[]> EngineStatusCondition { get; set; }
        public static List<string[]> VoltageCondition { get; set; }

        // Control Type && Communication Type
        public static List<string[]> ControlType = Controller_ServiceHandling.GetControlType(Specification);
        public static List<string[]> CommunicationType = Controller_ServiceHandling.GetCommunicationType(Specification);

        public static void PushTestcaseService28(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus) {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                //SuppressBitComponent(ws, rowIndex);
                //ActivationComponent(ws, rowIndex);
                ConditionCheckComponent(ws, rowIndex);
                //NRCComponent(ws, rowIndex);

                // return a current ID
                declaration.TestcaseVariables.ID = rowIndex;
            }
            
        }

        public static void TestGroupComponent(Worksheet ws, int startRowIndex)
        {
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex("28") + Controller_ServiceHandling.GetServiceTestGroupTitle("28");
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;
            string whichAddressingMode = "";


            for (int communicationTypeindex = 0; communicationTypeindex < CommunicationType.Count; communicationTypeindex++)
            {
                if (Controller_ServiceHandling.ConvertFromStringToBool(CommunicationType[communicationTypeindex][1]))
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        switch (addressingModeIndex)
                        {
                            case 0: whichAddressingMode = "Physical";   break;
                            case 1: whichAddressingMode = "Functional"; break;
                        }

                        subRowIndex++;

                        GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM:Service {SID}: Communication Type 0x{CommunicationType[communicationTypeindex][0]} Check the service using {whichAddressingMode} addressing modes";
                        ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[0];
                        ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[1];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[2];
                        ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                        ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                        rowIndex++;
                        startRowIndex++;
                    }
                }
            }
        }
        public static void SuppressBitComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;
            string whichAddressingMode = "";


            for (int communicationTypeindex = 0; communicationTypeindex < CommunicationType.Count; communicationTypeindex++)
            {
                if (Controller_ServiceHandling.ConvertFromStringToBool(CommunicationType[communicationTypeindex][1]))
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        switch (addressingModeIndex)
                        {
                            case 0: whichAddressingMode = "Physical"; break;
                            case 1: whichAddressingMode = "Functional"; break;
                        }

                        subRowIndex++;

                        GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM:Service {SID}: Communication Type 0x{CommunicationType[communicationTypeindex][0]} Check suppress bit in {whichAddressingMode} addressing modes";
                        ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[0];
                        ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[1];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent(CommunicationType.ElementAt(communicationTypeindex), Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[2];
                        ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                        ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                        rowIndex++;
                        startRowIndex++;
                    }
                }
            }
        }
        public static void ActivationComponent(Worksheet ws, int startRowIndex)
        {

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


            if ((UIVariables.DatabaseCommonSettingVehicleSpeed[1] != "") || (UIVariables.DatabaseCommonSettingVehicleSpeed[1] != null))
            {
                for (int communicationTypeindex = 0; communicationTypeindex < CommunicationType.Count; communicationTypeindex++)
                {
                    if (Controller_ServiceHandling.ConvertFromStringToBool(CommunicationType[communicationTypeindex][1]))
                    {
                        subRowIndex++;

                        GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                        ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Communication Type 0x{CommunicationType[communicationTypeindex][0]} Check {VehicleSpeedCondition.ElementAt(0)[0]} condition";
                        ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[0], CommunicationType.ElementAt(communicationTypeindex),  true)[0];
                        ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[0], CommunicationType.ElementAt(communicationTypeindex), true)[1];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[0], CommunicationType.ElementAt(communicationTypeindex), true)[2];
                        ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                        ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                        ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                        rowIndex++;
                        startRowIndex++;
                    }
                }
            }
            if ((UIVariables.DatabaseCommonSettingEngineStatus[1] != "") || (UIVariables.DatabaseCommonSettingEngineStatus[1] != null))
            {
                for (int index = 0; index < EngineStatusCondition.Count; index++)
                {
                    for (int communicationTypeindex = 0; communicationTypeindex < CommunicationType.Count; communicationTypeindex++)
                    {
                        if (Controller_ServiceHandling.ConvertFromStringToBool(CommunicationType[communicationTypeindex][1]))
                        {
                            subRowIndex++;

                            GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Communication Type 0x{CommunicationType[communicationTypeindex][0]} Check {EngineStatusCondition.ElementAt(index)[0]} ({EngineStatusCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index], CommunicationType.ElementAt(communicationTypeindex), true)[0];
                            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index], CommunicationType.ElementAt(communicationTypeindex), true)[1];
                            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index], CommunicationType.ElementAt(communicationTypeindex), true)[2];
                            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                            rowIndex++;
                            startRowIndex++;
                        }
                    }
                }
            }
            for (int index = 0; index < VoltageCondition.Count; index++)
            {
                subRowIndex++;

                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check {VoltageCondition.ElementAt(index)[0]} ({VoltageCondition.ElementAt(index)[2]}) condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index], CommunicationType.ElementAt(2), true)[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index], CommunicationType.ElementAt(2), true)[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index], CommunicationType.ElementAt(2), true)[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                startRowIndex++;
            }
        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {

        }
    }
    class Model_GetTestRequestService28
    {
        public static string SID = "28";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService28.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService28.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService28.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService28.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService28.ElementAt(4);

        // Control Type && Communication Type
        public static List<string[]> ControlType = Controller_ServiceHandling.GetControlType(Specification);
        public static List<string[]> CommunicationType = Controller_ServiceHandling.GetCommunicationType(Specification);

        // SubFuntion Mode
        public static string[] subFunctionMode = new string[3]
        {
            "01",
            "03",
            "02",
        };

        // 1: Default, 2: Programming, 3: Extended
        public static string[] AllowedSessionListInPhysical = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, true);
        public static string[] AllowedSessionListInFunctional = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, false);

        // Is Suppress bit support ?
        public static bool IsSuppressBitSupport = Controller_ServiceHandling.ConvertFromStringToBool(Optional.ElementAt(0)[1]);

        public static string[] GetTestRequestAllowSessionComponent()
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
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length - 1; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n"
                        ;
                    TestStepIndex += 3;
                    for (int controlCommunicationTypeIndex = 0; controlCommunicationTypeIndex < CommunicationType.Count; controlCommunicationTypeIndex++)
                    {
                        for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                        {
                            if (Controller_ServiceHandling.ConvertFromStringToBool(CommunicationType.ElementAt(controlCommunicationTypeIndex)[1]))
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0], 
                                                                                                        communicationType: CommunicationType[controlCommunicationTypeIndex][1], 
                                                                                                        isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                        isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                        suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                        isParameterSupported: true, addressingMode: true)[index] + "\n"
                                    ;
                                TestStepIndex += 1;
                            }
                        }
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 1000)[index] + "\n"
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
        public static string[] GetTestRequestAddressingModeComponent(string[] communicationType, bool addressingMode)
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
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n"
                        ;
                    TestStepIndex += 3;
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                isParameterSupported: true, addressingMode: addressingMode)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 1000)[index] + "\n"
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
        public static string[] GetTestRequestSuppressBitComponent(string[] communicationType, bool addressingMode)
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
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n"
                        ;
                    TestStepIndex += 3;
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                                isParameterSupported: true, addressingMode: addressingMode)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(2000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 1000)[index] + "\n"
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
        public static string[] GetTestRequestVehicleSpeedConditionCheckComponent(string[] conditionGroupTestcase, string[] communicationType, bool addressingMode)
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
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: addressingMode,
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
                        for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                    communicationType: communicationType[1],
                                                                                                    isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                    isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                    suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: addressingMode,
                                                                                                    setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue),
                                                                                                    conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                ;
                            TestStepIndex += 1;
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: 0, timeout: 100)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                    communicationType: communicationType[1],
                                                                                                    isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                    isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                    suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: addressingMode,
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
        public static string[] GetTestRequestEngineStatusConditionCheckComponent(string[] conditionGroupTestcase, string[] communicationType, bool addressingMode)
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
                for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                            communicationType: communicationType[1],
                                                                                            isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: addressingMode,
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
        public static string[] GetTestRequestVoltageConditionCheckComponent(string[] conditionGroupTestcase, string[] communicationType, bool addressingMode)
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
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: addressingMode,
                                                                                                invalidValue: invalidValue, setInvalidValue: setInvalidValue,
                                                                                                conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: addressingMode,
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
                    for (int controlTypeIndex = 0; controlTypeIndex < ControlType.Count; controlTypeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService28(controlType: ControlType.ElementAt(controlTypeIndex)[0],
                                                                                                communicationType: communicationType[1],
                                                                                                isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(ControlType.ElementAt(controlTypeIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunctionMode[2])]),
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: addressingMode,
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
            str = new string[3]
            {
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
