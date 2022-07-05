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
    class Model_PushTestcaseService10
    {

        public static int rowIndex;
        public static int subRowIndex = 0;
        public static string SID = "10";

        public static void PushTestcaseService10(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                SessionTransitionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
                //ConditionCheckComponent(ws, rowIndex);
                //FlashBootloaderComponent(ws, rowIndex);
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void SessionTransitionComponent(Worksheet ws, int startRowIndex)
        {
            int subSubRowIndex = 0;
            subRowIndex++;

            string GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;

            // Test group : Session transitions
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " Session transitions";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;

            // Session transitions - From Default Session
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Session transitions - From Default Session";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all diagnostic sessions can be transited from Default session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromDefaultSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromDefaultSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromDefaultSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Session transitions - From Programming Session
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Session transitions - From Programming Session";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all diagnostic sessions can be transited from Programming session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromProgrammingSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromProgrammingSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromProgrammingSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Session transitions - From Extended Session
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Session transitions - From Extended Session";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all diagnostic sessions can be transited from Extended session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromExtendedSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromExtendedSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetSessionTransitionFromExtendedSessionComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetTestRequestAddressingModeComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestAddressingModeComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestAddressingModeComponent()[2];
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
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetTestRequestSuppressBitComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestSuppressBitComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestSuppressBitComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported condition in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported condition";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10.GetTestRequestConditionCheckComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestConditionCheckComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestConditionCheckComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
        public static void FlashBootloaderComponent(Worksheet ws, int startRowIndex)
        {
            int subSubRowIndex = 0;
            subRowIndex++;

            string GetSubServiceTestGroupIndex = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex;

            // Test group : Flashbootloader Transition during failure in pre-programming conditions
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + " Flashbootloader Transition during failure in pre-programming conditions";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;

            // Flashbootloader Transition is not fulfilled because of vehicle speed
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Flashbootloader Transition is not fulfilled because of vehicle speed";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "Flashbootloader Transition is not fulfilled because of vehicle speed";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Flashbootloader Transition is not fulfilled because of engine is running
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Flashbootloader Transition is not fulfilled because of engine is running";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "Flashbootloader Transition is not fulfilled because of engine is running";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Flashbootloader Transition is not fulfilled because of security access
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Flashbootloader Transition is not fulfilled because of security access";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "Flashbootloader Transition is not fulfilled because of security access";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

            // Flashbootloader Transition is not fulfilled because of security access
            subSubRowIndex++;
            startRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = GetSubServiceTestGroupIndex + "." + subSubRowIndex + " Flashbootloader Transition is not fulfilled because of programming attempts";
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "Flashbootloader Transition is not fulfilled because of programming attempts";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = "";
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;

            rowIndex++;

        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " Check all supported NRC in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all supported NRC";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService10  .GetTestRequestNRCComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService10.GetTestRequestNRCComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService10.GetTestRequestNRCComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = UIVariables.ProjectName;


            rowIndex++;
        }
    }
    class Model_GetTestRequestService10
    {
        public static string SID = "10";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService10.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService10.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService10.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService10.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService10.ElementAt(4);

        public static string[] subFunction = Controller_ServiceHandling.GetSubFunctions(Specification);

        // 1: Default, 2: Programming, 3: Extended
        public static string[] AllowedSessionListInPhysical = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, true);      // 0
        public static string[] AllowedSessionListInFunctional = Controller_ServiceHandling.GetAllowedSessionList(AllowSession, false);   // 1
        public static string[] SessionTransitionFromDefaultSession = AllowSession.ElementAt(2);                                          // 2
        public static string[] SessionTransitionFromProgrammingSession = AllowSession.ElementAt(3);                                      // 3
        public static string[] SessionTransitionFromExtendedSession = AllowSession.ElementAt(4);                                         // 4
        // Is Suppress bit support ?
        public static bool IsSuppressBitSupport = Controller_ServiceHandling.ConvertFromStringToBool(Optional.ElementAt(0)[1]);

        public static string[] GetTestRequestAllowSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];
            int TestStepIndex = 0;

            
            for (int index = 0; index < 3; index++)
            {
                string step =
                    (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: true, expectedValue: ".{1}1", addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[2], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: true, expectedValue: ".{1}3", addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[2], true)[index] + "\n" +
                    (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[1], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true,
                                                                                        suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                        isSIDSupportedInActiveSession: true, expectedValue: ".{1}2", addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[1], true)[index] + "\n" +
                    (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true,
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport,
                                                                                            isSIDSupportedInActiveSession: true, expectedValue: ".{1}1", addressingMode: true, 0, 0)[index] + "\n" +
                    (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                    (TestStepIndex + 14) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
                    ;
                switch (index)
                {
                    case 0: TestStep += step; break;
                    case 1: TestResponse += step; break;
                    case 2: TeststepKeyword += step; break;
                }
            }
            TestStepIndex += 14;
                
            str = new string[]
            {
                TestStep,
                TestResponse,
                TeststepKeyword
            };
            
            
            return str;
        }
        public static string[] GetSessionTransitionFromDefaultSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";

            bool[] SessionTransitionFromDefaultSessionStatus = new bool[]
            {
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromDefaultSession[1]), // To Default 
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromDefaultSession[2]), // To Programming
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromDefaultSession[3]), // To Extended
            };

            string[] str = new string[] { };
            int TestStepIndex = 0;

            for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
            {
                int tempSubFunctionIndex;
                if (SessionTransitionFromDefaultSessionStatus[subFunctionIndex])
                {
                    tempSubFunctionIndex = subFunctionIndex;
                }
                else
                {
                    tempSubFunctionIndex = 0;
                }
                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                            isSIDSupportedInActiveSession: true, expectedValue: ".{1}1", addressingMode: true, 0, 0)[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[subFunctionIndex], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: SessionTransitionFromDefaultSessionStatus[subFunctionIndex], 
                                                                                            suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                            isSIDSupportedInActiveSession: true, expectedValue: ".{1}1", addressingMode: true, 0, 0)[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[tempSubFunctionIndex], true)[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 0)[index] + "\n"
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
                TestStepIndex += 6;
            }

            
            return str;
        }
        public static string[] GetSessionTransitionFromProgrammingSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";


            bool[] SessionTransitionFromProgrammingSessionStatus = new bool[]
            {
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromProgrammingSession[1]), // To Default 
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromProgrammingSession[2]), // To Programming
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromProgrammingSession[3]), // To Extended
            };

            string[] str = new string[] { };
            int TestStepIndex = 0;

            for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
            {
                int tempSubFunctionIndex;
                if (SessionTransitionFromProgrammingSessionStatus[subFunctionIndex])
                {
                    tempSubFunctionIndex = subFunctionIndex;
                }
                else
                {
                    tempSubFunctionIndex = 1;
                }
                if(subFunctionIndex == 0)
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, isSIDSupportedInActiveSession: true, 
                                                                                                expectedValue: ".{1}2", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[1], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, isSIDSupportedInActiveSession: true, 
                                                                                                expectedValue: ".{1}2", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[1], true)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[subFunctionIndex], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: SessionTransitionFromProgrammingSessionStatus[subFunctionIndex], 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, isSIDSupportedInActiveSession: true, 
                                                                                                expectedValue: ".{1}2", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[tempSubFunctionIndex], true)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 6;
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
            return str;
        }
        public static string[] GetSessionTransitionFromExtendedSessionComponent()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";


            bool[] SessionTransitionFromExtendedSessionStatus = new bool[]
            {
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromExtendedSession[1]), // To Default 
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromExtendedSession[2]), // To Programming
                Controller_ServiceHandling.ConvertFromStringToBool(SessionTransitionFromExtendedSession[3]), // To Extended
            };

            string[] str = new string[] { };
            int TestStepIndex = 0;

            for (int subFunctionIndex = 0; subFunctionIndex < subFunction.Length; subFunctionIndex++)
            {
                int tempSubFunctionIndex;
                if (SessionTransitionFromExtendedSessionStatus[subFunctionIndex])
                {
                    tempSubFunctionIndex = subFunctionIndex;
                }
                else
                {
                    tempSubFunctionIndex = 2;
                }
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
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: true, expectedValue: ".{1}3", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[2], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: true, expectedValue: ".{1}3", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[2], true)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[subFunctionIndex], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: SessionTransitionFromExtendedSessionStatus[subFunctionIndex], 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: true, expectedValue: ".{1}3", addressingMode: true, 0, 0)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[tempSubFunctionIndex], true)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }

                    }
                    TestStepIndex += 6;
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
                if(addressingModeIndex == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]), 
                                                                                                expectedValue: ".{1}1", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 4;
                }
                if (addressingModeIndex <= 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[2], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]), 
                                                                                                expectedValue: ".{1}3", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[2], true)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[1], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]), 
                                                                                                expectedValue: ".{1}2", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[1], true)[index] + "\n" +
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: false, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]), 
                                                                                                expectedValue: ".{1}1", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" 
                           ;

                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 9;
                }
                if (addressingModeIndex == 1)
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
                if(addressingModeIndex == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]), 
                                                                                                expectedValue: ".{1}1", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 4;
                }
                if (addressingModeIndex <= 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[2], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[3]), 
                                                                                                expectedValue: ".{1}3", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[2], true)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[1], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[2]), 
                                                                                                expectedValue: ".{1}2", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[1], true)[index] + "\n" +
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService10(subFunction[0], isSubFunctionSupported: true, isSubFunctionSupportedInActiveSession: true, 
                                                                                                suppressBitEnabledStatus: true, isSuppressBitSupported: IsSuppressBitSupport, 
                                                                                                isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(AllowedSessionList[1]), 
                                                                                                expectedValue: ".{1}1", addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), 0, 0)[index] + "\n" +
                            (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestReadCurrentDiagnosticSession(subFunction[0], true)[index] + "\n"
                           ;

                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 9;
                }
                if (addressingModeIndex == 1)
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

                TestStepIndex += 14;
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
