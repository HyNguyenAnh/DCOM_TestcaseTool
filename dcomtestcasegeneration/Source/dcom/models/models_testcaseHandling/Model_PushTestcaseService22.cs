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
                NRCComponent(ws, rowIndex);

                // return a current ID
                declaration.TestcaseVariables.ID = rowIndex;
            }
        }

        public static void TestGroupComponent(Worksheet ws, int startRowIndex)
        {
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex("22") + Controller_ServiceHandling.GetServiceTestGroupTitle("22");
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;
        }

        public static void AllowSessionComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all allowed diagnostic sessions in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


            rowIndex++;
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported addressing mode in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported addressing mode";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetTestRequestAddressingModeComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


            rowIndex++;
        }
       
        public static void DIDCheckComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            int subSubRowIndex = 0;
            string GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;

            // Test group : DID Check for service 0x22
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " DID Check for service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;

            // Test case
            startRowIndex++;
            for (int index = 0; index < Specification.Count; index++)
            {
                subSubRowIndex++;
                string DIDName = Specification.ElementAt(index)[0];
                string DID = Specification.ElementAt(index)[1].ToUpper().Replace(" ", "");
                string ExpectedValue = Specification.ElementAt(index)[3].ToLower().Replace(" ", "");
                string TestComponent = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " PRC testcase for DID - 0x" + DID + " - " + DIDName;


                ws.Cells[startRowIndex + index, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
                ws.Cells[startRowIndex + index, TestcaseVariables.ComponentColumnIndex] = TestComponent;
                ws.Cells[startRowIndex + index, TestcaseVariables.TestDescriptionColumnIndex] = "DID - 0x" + DID + " - " + DIDName;
                ws.Cells[startRowIndex + index, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponent(DID, ExpectedValue)[0];
                ws.Cells[startRowIndex + index, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponent(DID, ExpectedValue)[1];
                ws.Cells[startRowIndex + index, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService22.GetDIDCheckComponent(DID, ExpectedValue)[2];
                ws.Cells[startRowIndex + index, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
                ws.Cells[startRowIndex + index, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
                ws.Cells[startRowIndex + index, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


                rowIndex++;
            }
        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported condition in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


            rowIndex++;
        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported NRC in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported NRC";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


            rowIndex++;
        }
    }
    class Model_GetTestRequestService22
    {
        public static string SID = "22";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService22.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService22.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService22.ElementAt(2);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService22.ElementAt(3);
        public static List<string[]> Precondition = DatabaseVariables.DatabaseService22.ElementAt(4);

        public static string[] parametters = Controller_ServiceHandling.GetParameters(Specification);

        // 1: Default, 2: Programming, 3: Extended
        public static string[] AllowedSessionListInPhysical = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, true);
        public static string[] AllowedSessionListInFunctional = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, false);

        
        public static string CurrentSessionDIDCodeString = DatabaseVariables.DatabaseCommonDIDCurrentSession[1];
        public static string[] GetTestRequestAllowSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str;


            int TestStepIndex = 0;

            for (int index = 0; index < 3; index++)
            {
                string step =
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "01", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]), addressingMode: true)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "03", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[3]), addressingMode: true)[index] + "\n" +
                    (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                    (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "02", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[2]), addressingMode: true)[index] + "\n" +
                    (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "01", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionListInPhysical[1]), addressingMode: true)[index] + "\n" +
                    (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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

                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "01", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[addressingModeIndex]), addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "03", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[addressingModeIndex]), addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n" +
                        (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                        (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "02", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[addressingModeIndex]), addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n" +
                        (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService22(CurrentSessionDIDCodeString, expectedValue: "01", isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[addressingModeIndex]), addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n" +
                        (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
        public static string[] GetDIDCheckComponent(string DID, string expectedValue)
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

                for (int index = 0; index < 3; index++)
                {
                    string step =
                         (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService22(DID: DID, expectedValue: expectedValue, isDIDSupported: true, isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[addressingModeIndex]), addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex))[index] + "\n"
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
                TestStepIndex += 1;
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

