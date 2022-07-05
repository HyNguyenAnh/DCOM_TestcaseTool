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

        public static void PushTestcaseService28(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus) {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
                ActivationComponent(ws, rowIndex);
                ConditionCheckComponent(ws, rowIndex);
                NRCComponent(ws, rowIndex);

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

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all allowed diagnostic sessions in service 0x" + SID;
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
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported addressing mode in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestAddressingModeComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService28.GetTestRequestSuppressBitComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void ActivationComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {

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
                if (subFunctionIndex == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n"
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
                if (subFunctionIndex <= subFunction.Length - 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]),
                                                                                                addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                            (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]),
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]),
                                                                                                addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                            (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                            (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                            (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                            (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                 isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]),
                                                                                                 suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                 isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]),
                                                                                                 addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                            (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 15;
                }
                if (subFunctionIndex == subFunction.Length - 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
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
                str = new string[]
                {
                    TestStep,
                    TestResponse,
                    TeststepKeyword
                };
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

                for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                {
                    if (subFunctionIndex == 0)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
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
                    if (subFunctionIndex <= subFunction.Length - 1)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                               (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                               (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                               (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                   isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                   suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                   isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                   addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                               (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                               (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                               (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                               (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                               (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                   isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                   suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                   isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                   addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                               (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                               (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                               (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                               (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                               (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                    isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                    suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                               (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                               (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
                               ;

                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 15;
                    }
                    if (subFunctionIndex == subFunction.Length - 1)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
                    str = new string[]
                    {
                    TestStep,
                    TestResponse,
                    TeststepKeyword
                    };
                }
            }
            return str;
        }
        public static string[] GetTestRequestSuppressBitComponent()
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

                for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
                {
                    if (subFunctionIndex == 0)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
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
                    if (subFunctionIndex <= subFunction.Length - 1)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                              (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                              (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                              (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]),
                                                                                                  addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                              (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                              (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                              (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                              (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("03", true)[index] + "\n" +
                              (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                  isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                  suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                  isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]),
                                                                                                  addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                              (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                              (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n" +
                              (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                              (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("02", true)[index] + "\n" +
                              (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService28(subFunction[subFunctionIndex], isSubFunctionSupported: Controller_ServiceHandling.ConvertFromStringToBool(Specification.ElementAt(subFunctionIndex)[1]),
                                                                                                   isSubFunctionSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                   suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                                   isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]),
                                                                                                   addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                              (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestWait(7000)[index] + "\n" +
                              (TestStepIndex + 15) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession("01", true)[index] + "\n"
                              ;
                            switch (index)
                            {
                                case 0: TestStep += step; break;
                                case 1: TestResponse += step; break;
                                case 2: TeststepKeyword += step; break;
                            }
                        }
                        TestStepIndex += 15;
                    }
                    if (subFunctionIndex == subFunction.Length - 1)
                    {
                        for (int index = 0; index < 3; index++)
                        {
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
                    str = new string[]
                    {
                    TestStep,
                    TestResponse,
                    TeststepKeyword
                    };




                }
            }

            return str;
        }
        public static string[] GetTestRequestConditionCheckComponent()
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
