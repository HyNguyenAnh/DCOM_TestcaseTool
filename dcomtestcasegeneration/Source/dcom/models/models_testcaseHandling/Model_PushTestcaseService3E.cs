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
    class Model_PushTestcaseService3E
    {
        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "3E";
        public static string[] conditionGroup;
        public static string currentCondition;
        public static List<string[]> conditionGroupTestcaseTemp = new List<string[]>();
        public static List<List<string[]>> conditionGroupTestcaseSorted = new List<List<string[]>>();

        public static List<string[]> Specification = DatabaseVariables.DatabaseService3E.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService3E.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService3E.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService3E.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService3E.ElementAt(4);

        public static void PushTestcaseService3E(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
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
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all allowed diagnostic sessions in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAllowSessionComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestAddressingModeComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }

        public static void SuppressBitComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{Controller_ServiceHandling.GetServiceTestGroupIndex(SID)}.{subRowIndex}Check suppress bit in service 0x{SID}";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check suppress bit";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestSuppressBitComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestSuppressBitComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestSuppressBitComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {
            string GetSubServiceTestGroupIndex;
            conditionGroup = new string[Condition.Count];
            for (int index = 0; index < Condition.Count; index++)
            {
                conditionGroup[index] = Condition.ElementAt(index)[0];
            }
            conditionGroup = new HashSet<string>(conditionGroup).ToArray();

            conditionGroupTestcaseSorted = new List<List<string[]>>();
            for (int conditionIndex = 0; conditionIndex < conditionGroup.Length; conditionIndex++)
            {
                conditionGroupTestcaseTemp = new List<string[]>();
                currentCondition = conditionGroup[conditionIndex];
                for (int index = 0; index < Condition.Count; index++)
                {
                    if (Condition.ElementAt(index)[0] == currentCondition)
                    {
                        conditionGroupTestcaseTemp.Add(Condition.ElementAt(index).ToArray());
                    }
                    else
                    {
                        //
                    }
                }
                conditionGroupTestcaseSorted.Add(conditionGroupTestcaseTemp);
            }
            for (int index = 0; index < conditionGroupTestcaseSorted.ElementAt(0).Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {conditionGroupTestcaseSorted.ElementAt(0).ElementAt(index)[0]} {conditionGroupTestcaseSorted.ElementAt(0).ElementAt(index)[2]} condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVehicleSpeedConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(0)[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVehicleSpeedConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(0)[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVehicleSpeedConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(0)[index])[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
            }
            startRowIndex++;
            for (int index = 0; index < conditionGroupTestcaseSorted.ElementAt(1).Count; index++)
            {
                subRowIndex++;
                GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {conditionGroupTestcaseSorted.ElementAt(1).ElementAt(index)[0]} {conditionGroupTestcaseSorted.ElementAt(1).ElementAt(index)[2]} condition in service 0x{SID}";
                ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestEngineStatusConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(1)[index])[0];
                ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestEngineStatusConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(1)[index])[1];
                ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestEngineStatusConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(1)[index])[2];
                ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                rowIndex++;
            }
            if (conditionGroupTestcaseSorted.Count > 2)
            {
                startRowIndex++;
                for (int index = 0; index < conditionGroupTestcaseSorted.ElementAt(2).Count; index++)
                {
                    subRowIndex++;
                    GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                    ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = $"{GetSubServiceTestGroupIndex}.{subRowIndex}: Check {conditionGroupTestcaseSorted.ElementAt(2).ElementAt(index)[0]} {conditionGroupTestcaseSorted.ElementAt(2).ElementAt(index)[2]} condition in service 0x{SID}";
                    ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVoltageConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(2)[index])[0];
                    ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVoltageConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(2)[index])[1];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestVoltageConditionCheckComponent(conditionGroupTestcaseSorted.ElementAt(2)[index])[2];
                    ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                    ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                    ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

                    rowIndex++;
                }
            }
        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported NRC in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported NRC";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService3E.GetTestRequestNRCComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService3E.GetTestRequestNRCComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService3E.GetTestRequestNRCComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;
        }
    }

    class Model_GetTestRequestService3E
    {
        public static string SID = "3E";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService3E.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService3E.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService3E.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService3E.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService3E.ElementAt(4);
        

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
            string[] str = new string[3];
            int TestStepIndex = 0;


            for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
            {
                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction[subFunctionIndex], isSubFunctionSupported: true, 
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]), 
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                            isParameterSupported: true, addressingMode: true, 0, 0)[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                        (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction[subFunctionIndex], isSubFunctionSupported: true, 
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]), 
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]),
                                                                                            isParameterSupported: true, addressingMode: true, 0, 0)[index] + "\n" +
                        (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                        (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                        (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction[subFunctionIndex], isSubFunctionSupported: true, 
                                                                                            isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]), 
                                                                                            suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                            isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]),
                                                                                            isParameterSupported: true, addressingMode: true, 0, 0)[index] + "\n" +
                        (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
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

                TestStepIndex += 14;


            }
            return str;
        }
        public static string[] GetTestRequestAddressingModeComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];
            string[] AllowedSessionList = new string[] { };

            int TestStepIndex = 0;

            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
            {
                switch (addressingModeIndex)
                {
                    case 0: AllowedSessionList = AllowedSessionListInFunctional; break;
                    case 1: AllowedSessionList = AllowedSessionListInPhysical; break;
                }

                if (addressingModeIndex < 2)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]), 
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                            (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                            (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                            (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                isParameterSupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n"
                            ;

                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 12;
                }
                if (addressingModeIndex == 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
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
                    TestStepIndex += 2;
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
        public static string[] GetTestRequestSuppressBitComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";

            int TestStepIndex = 0;

            
            for (int index = 0; index < 3; index++)
            {
                string step =
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true, 
                                                                                        isSubFunctionSupportedInActiveSession: true, 
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInFunctional[1]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: false, 0, 0)[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                    (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInFunctional[3]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: false, 0, 0)[index] + "\n" +
                    (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                    (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                    (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInFunctional[2]),
                                                                                        isParameterSupported: true,
                                                                                        addressingMode: false, 0, 0)[index] + "\n" +
                    (TestStepIndex + 16) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 17) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
                    ;
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            string[] str = new string[3]
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
            int TestStepIndex = 0;
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
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: invalidValue, timeout: 100)[index] + "\n"
                        ;
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
                TestStepIndex += 1;
                for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                {
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue, 
                                                                                                    setInvalidValue: invalidValue)[index] + "\n"
                        ;
                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 1;
                    }
                }
            }
            else
            {
                for (double vehicleValue = 0; vehicleValue < 3; vehicleValue ++)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue), timeout: 100)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 1;
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            for (int index = 0; index < 3; index++)
                            {
                                string step =
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                        isParameterSupported: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue, 
                                                                                                        setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue))[index] + "\n"
                            ;
                                switch (index)
                                {
                                    case 0: TestStep += step; break;
                                    case 1: TestResponse += step; break;
                                    case 2: TeststepKeyword += step; break;
                                }
                            }
                            TestStepIndex += 1;
                        }
                    }
                }
                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVehicleSpeed(setInvalidValue: 0, timeout: 100)[index] + "\n"
                        ;
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
                TestStepIndex += 1;
                for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                {
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                    setInvalidValue: 0)[index] + "\n"
                        ;
                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 1;
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
        public static string[] GetTestRequestEngineStatusConditionCheckComponent(string[] conditionGroupTestcase)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            int TestStepIndex = 0;
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
            
            for (int index = 0; index < 3; index++)
            {
                string step =
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetEngineStatus(setInvalidValue: invalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                    ;
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            TestStepIndex += 1;
            for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
            {
                for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                isSubFunctionSupportedInActiveSession: true,
                                                                                                suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                isParameterSupported: true,
                                                                                                addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                setInvalidValue: invalidValue)[index] + "\n"
                    ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 1;
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
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: invalidValue, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
                TestStepIndex += 1;
                for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                {
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                    setInvalidValue: invalidValue)[index] + "\n"
                        ;
                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 1;
                    }
                }
            }
            else
            {
                for (double vehicleValue = 0; vehicleValue < 3; vehicleValue++)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue), name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 1;
                    for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                    {
                        for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                        {
                            for (int index = 0; index < 3; index++)
                            {
                                string step =
                                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                        isSubFunctionSupportedInActiveSession: true,
                                                                                                        suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                        isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                        isParameterSupported: true,
                                                                                                        addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                        setInvalidValue: invalidValue - 0.2 + (0.2 * vehicleValue))[index] + "\n"
                            ;
                                switch (index)
                                {
                                    case 0: TestStep += step; break;
                                    case 1: TestResponse += step; break;
                                    case 2: TeststepKeyword += step; break;
                                }
                            }
                            TestStepIndex += 1;
                        }
                    }
                }
                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.SetVoltage(setInvalidValue: 0, name: conditionGroupTestcase[2], timeout: 100)[index] + "\n"
                        ;
                    switch (index)
                    {
                        case 0: TestStep += step; break;
                        case 1: TestResponse += step; break;
                        case 2: TeststepKeyword += step; break;
                    }
                }
                TestStepIndex += 1;
                for (int suppressBitStatus = 0; suppressBitStatus < 2; suppressBitStatus++)
                {
                    for (int addressingModeStauts = 0; addressingModeStauts < 2; addressingModeStauts++)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService3E(subFunction: Specification.ElementAt(0)[0], isSubFunctionSupported: true,
                                                                                                    isSubFunctionSupportedInActiveSession: true,
                                                                                                    suppressBitEnabledStatus: Controller_ServiceHandling.ConvertFromIntToBool(suppressBitStatus), isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                    isParameterSupported: true,
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeStauts + 1), invalidValue: invalidValue,
                                                                                                    setInvalidValue: 0)[index] + "\n"
                        ;
                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 1;
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
