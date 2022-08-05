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
    class Model_PushTestcaseService85
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "85";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService85.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService85.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService85.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService85.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService85.ElementAt(4);

        // Condition
        public static List<string[]> VehicleSpeedCondition { get; set; }
        public static List<string[]> EngineStatusCondition { get; set; }
        public static List<string[]> VoltageCondition { get; set; }

        public static void PushTestcaseService85(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;

            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
            {
                string addressingMode = "";
                switch (addressingModeIndex)
                {
                    case 0:
                        addressingMode = "Physical";
                        break;
                    case 1:
                        addressingMode = "Fuctional";
                        break;
                }
                subRowIndex++;

                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check all supported in {addressingMode} addressing modes";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestAddressingModeComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestAddressingModeComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestAddressingModeComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


                rowIndex++;
                startRowIndex++;
            }
        }
        public static void SuppressBitComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;

            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
            {
                string addressingMode = "";
                switch (addressingModeIndex)
                {
                    case 0:
                        addressingMode = "Physical";
                        break;
                    case 1:
                        addressingMode = "Fuctional";
                        break;
                }
                subRowIndex++;

                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check suppress bit in {addressingMode}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check suppress bit";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestSuppressBitComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestSuppressBitComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestSuppressBitComponent(addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
                startRowIndex++;
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


            if (UIVariables.DatabaseCommonSetting[1][1] != "")
            {
                for (int index = 0; index < VehicleSpeedCondition.Count; index++)
                {
                    subRowIndex++;

                    GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check {VehicleSpeedCondition.ElementAt(index)[0]} condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[0];
                    ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[1];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[2];
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
                    ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check {EngineStatusCondition.ElementAt(index)[0]} ({EngineStatusCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                    ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[0];
                    ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[1];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[2];
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
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex} LabT_DCOM: Service {SID}: Check {VoltageCondition.ElementAt(index)[0]} ({VoltageCondition.ElementAt(index)[2]}) condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService85.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService85.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService85.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[2];
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
    class Model_GetTestRequestService85
    {
        public static string SID = "85";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService85.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService85.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService85.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService85.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService85.ElementAt(4);

        // SubFuntion
        public static string[] subFunction = Controller_ServiceHandling.GetSubFunctions(Specification);
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
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                        ;
                    TestStepIndex += 3;
                    for (int subFunctionIndex = subFunction.Length - 1; subFunctionIndex >= 0; subFunctionIndex--)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[subFunctionIndex], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[subFunctionModeIndex + 1]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[subFunctionModeIndex + 1]),
                                                                                            addressingMode: true)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
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
        public static string[] GetTestRequestAddressingModeComponent(bool addressingMode)
        {
            // addressingMode
            // - true : Physical mode
            // - false : Functional mode
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";

            TestcaseVariables.isFaultEnable = false;
            TestcaseVariables.isFaultDisable = false;
            TestcaseVariables.isClearDTC = false;

            string[] str;
            string[] AllowedSessionList = new string[] { };
            switch (addressingMode)
            {
                case false: AllowedSessionList = AllowedSessionListInFunctional; break;
                case true: AllowedSessionList = AllowedSessionListInPhysical; break;
            }
            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length - 1; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService14("ffffff", isSIDSupportedInActiveSession: true,
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: true)[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestCreateFault(false, 100)[index] + "\n" +
                        (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestCreateFault(true, 5000)[index] + "\n" +
                        (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 16) + ") " + Model_TestcaseKeyword.RequestService14("ffffff", isSIDSupportedInActiveSession: true,
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: true)[index] + "\n" +
                        (TestStepIndex + 17) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n"
                        ;
                    TestStepIndex += 17;
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[2])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                  suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                  addressingMode: addressingMode)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  addressingMode: addressingMode)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
        public static string[] GetTestRequestSuppressBitComponent(bool addressingMode)
        {
            // addressingMode
            // - true : Physical mode
            // - false : Functional mode
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";

            TestcaseVariables.isFaultEnable = false;
            TestcaseVariables.isFaultDisable = false;
            TestcaseVariables.isClearDTC = false;

            string[] str;
            string[] AllowedSessionList = new string[] { };
            switch (addressingMode)
            {
                case false: AllowedSessionList = AllowedSessionListInFunctional; break;
                case true: AllowedSessionList = AllowedSessionListInPhysical; break;
            }
            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionModeIndex = 0; subFunctionModeIndex < subFunctionMode.Length - 1; subFunctionModeIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[subFunctionModeIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunctionMode[subFunctionModeIndex], true)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService14("ffffff", isSIDSupportedInActiveSession: true,
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: true)[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestCreateFault(false, 100)[index] + "\n" +
                        (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestCreateFault(true, 5000)[index] + "\n" +
                        (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[1],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunctionMode[subFunctionModeIndex])]),
                                                                                            addressingMode: addressingMode)[index] + "\n" +
                        (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n" +
                        (TestStepIndex + 16) + ") " + Model_TestcaseKeyword.RequestService14("ffffff", isSIDSupportedInActiveSession: true,
                                                                                            isParameterSupported: true,
                                                                                            addressingMode: true)[index] + "\n" +
                        (TestStepIndex + 17) + ") " + Model_TestcaseKeyword.ReadDTCStatus(UIVariables.DatabaseCommonSetting[0][2], subFunction: subFunction[0],
                                                                                        isFaultEnable: TestcaseVariables.isFaultEnable, isFaultDisable: TestcaseVariables.isFaultDisable,
                                                                                        isClearDTC: TestcaseVariables.isClearDTC)[index] + "\n"
                        ;
                    TestStepIndex += 17;
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[2])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[1], isSubFunctionSupported: true,
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                  suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                  addressingMode: addressingMode)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService85(subFunction[0], isSubFunctionSupported: true,
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  addressingMode: addressingMode)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunctionMode[0])[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                    invalidValue: invalidValue, setInvalidValue: invalidValue,
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
                        for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                        {
                            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1), invalidValue: invalidValue,
                                                                                                        setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue),
                                                                                                        conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                    ;
                                TestStepIndex += 1;
                            }
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: 0, timeout: 100)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                        {
                            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                        invalidValue: invalidValue, setInvalidValue: 0,
                                                                                                        conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                    ;
                                TestStepIndex += 1;
                            }
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
                for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                invalidValue: invalidValue, setInvalidValue: validValue,
                                                                                                conditionIndex: 2, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
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
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                    invalidValue: invalidValue, setInvalidValue: setInvalidValue,
                                                                                                    conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                ;
                            TestStepIndex += 1;
                        }
                    }
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                    invalidValue: invalidValue, setInvalidValue: invalidValue,
                                                                                                    conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
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
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService85(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1),
                                                                                                    invalidValue: invalidValue, setInvalidValue: invalidValue,
                                                                                                    conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
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
