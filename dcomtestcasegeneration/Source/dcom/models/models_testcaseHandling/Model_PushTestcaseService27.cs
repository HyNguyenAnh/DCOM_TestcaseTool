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
    class Model_PushTestcaseService27
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "27";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService27.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService27.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService27.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService27.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService27.ElementAt(4);

        // Condition
        public static List<string[]> VehicleSpeedCondition { get; set; }
        public static List<string[]> EngineStatusCondition { get; set; }
        public static List<string[]> VoltageCondition { get; set; }

        public static void PushTestcaseService27(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
                SeedRequestComponent(ws, rowIndex);
                LockCheckComponent(ws, rowIndex);
                InvalidKeyComponent(ws, rowIndex);
                //ConditionCheckComponent(ws, rowIndex);
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
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all allowed diagnostic sessions in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;
                ;


            rowIndex++;
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported addressing mode in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestAddressingModeComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestSuppressBitComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestSuppressBitComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestSuppressBitComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void SeedRequestComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void LockCheckComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void InvalidKeyComponent(Worksheet ws, int startRowIndex)
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

            for (int index = 0; index < VehicleSpeedCondition.Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {VehicleSpeedCondition.ElementAt(index)[0]} ({VehicleSpeedCondition.ElementAt(index)[2]}) condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestVehicleSpeedConditionCheckComponent(VehicleSpeedCondition[index])[2];
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
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestEngineStatusConditionCheckComponent(EngineStatusCondition[index])[2];
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
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService27.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService27.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService27.GetTestRequestVoltageConditionCheckComponent(VoltageCondition[index])[2];
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
    class Model_GetTestRequestService27
    {
        public static string SID = "27";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService27.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService27.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService27.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService27.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService27.ElementAt(4);

        // SubFunction from service
        public static string[] subFunction = Controller_ServiceHandling.GetSubFunctions(Specification);


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
                for (int subIndex = 0; subIndex < subFunction.Length; subIndex++)
                {
                    step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunction[subIndex])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[subIndex], true)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService27(subFunction[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunction[subIndex])]),
                                                                                        suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[Int32.Parse(subFunction[subIndex])]),
                                                                                        addressingMode: true)[index] + "\n"
                    ;
                    TestStepIndex += 4;
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
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
            string[] AllowedSessionList = new string[] { };

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(status: true, timeout: 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subIndex = 0; subIndex < subFunction.Length; subIndex++)
                {
                    step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunction[subIndex])[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[subIndex], true)[index] + "\n"
                    ;
                    TestStepIndex += 3;
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        switch (addressingModeIndex)
                        {
                            case 0: AllowedSessionList = AllowedSessionListInFunctional; break;
                            case 1: AllowedSessionList = AllowedSessionListInPhysical; break;
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[subIndex], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunction[subIndex])]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }

                }
                step =
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(status: false, timeout: 100)[index] + "\n"
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
        public static string[] GetTestRequestSuppressBitComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;
            string[] AllowedSessionList = new string[] { };

            for (int index = 0; index < 3; index++)
            {
                int TestStepIndex = 0;
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(status: true, timeout: 100)[index] + "\n"
                    ;
                for (int subIndex = 0; subIndex < subFunction.Length; subIndex++)
                {
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession(subFunction[subIndex])[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[subIndex], true)[index] + "\n"
                        ;
                    TestStepIndex += 3;
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        switch (addressingModeIndex)
                        {
                            case 0: AllowedSessionList = AllowedSessionListInFunctional; break;
                            case 1: AllowedSessionList = AllowedSessionListInPhysical; break;
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[subIndex], isSubFunctionSupported: true,
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunction[subIndex])]),
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[Int32.Parse(subFunction[subIndex])]),
                                                                                            addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex + 1))[index] + "\n"
                            ;
                        TestStepIndex += 1;
                    }
                }
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestTesterPresent(status: false, timeout: 100)[index] + "\n"
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
                    for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                    {
                        for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                        {
                            for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                        invalidValue: invalidValue, setInvalidValue: invalidValue,
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
                        for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                        {
                            for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                            {
                                for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                                {
                                    step +=
                                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[subFunctionIndex], isSubFunctionSupported: true,
                                                                                                            isSubFunctionSupportedInActiveSession: true,
                                                                                                            suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                            isSIDSupportedInActiveSession: true,
                                                                                                            addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                            setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue),
                                                                                                            conditionIndex: 1, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                        ;
                                    TestStepIndex += 1;
                                }
                            }
                        }
                        step +=
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: 0, timeout: 100)[index] + "\n"
                            ;
                        TestStepIndex += 1;
                        for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                        {
                            for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
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
            int TestStepIndex = 0;
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
                string step = "";
                step +=
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetEngineStatus(invalidValue: invalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                    ;
                TestStepIndex += 1;
                for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                {
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                    invalidValue: invalidValue, setInvalidValue: validValue,
                                                                                                    conditionIndex: 2, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
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
            int TestStepIndex = 0;
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
                    string step = "";
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: setInvalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                    for(int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                    {
                        for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                        {
                            for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                            {
                                step +=
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[subFunctionIndex], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
                                                                                                        invalidValue: invalidValue, setInvalidValue: setInvalidValue,
                                                                                                        conditionIndex: 3, conditionName: conditionGroupTestcase[2], conditionNRC: conditionGroupTestcase[4])[index] + "\n"
                                    ;
                                TestStepIndex += 1;
                            }
                        }
                    }
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
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
                    string step = "";
                    step +=
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: setInvalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    TestStepIndex += 1;
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            step +=
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService27(subFunction: subFunction[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1),
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
