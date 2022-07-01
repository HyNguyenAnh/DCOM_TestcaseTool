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

        public static void PushTestcaseService2E(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
                DIDComponent(ws, rowIndex);
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
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all allowed diagnostic sessions in service 0x" + SID;
            ws.Cells[startRowIndex, TestcaseVariables.TestDescriptionColumnIndex] = "This testcase check all allowed diagnostic session";
            ws.Cells[startRowIndex, TestcaseVariables.TestStepColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAllowSessionComponent()[0];
            ws.Cells[startRowIndex, TestcaseVariables.TestResponseColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAllowSessionComponent()[1];
            ws.Cells[startRowIndex, TestcaseVariables.TestStepKeywordColumnIndex] = Model_GetTestRequestService2E.GetTestRequestAllowSessionComponent()[2];
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[2];
            ws.Cells[startRowIndex, TestcaseVariables.TestStatusColumnIndex] = TestcaseVariables.TestStatus;
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


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
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


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
            ws.Cells[startRowIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;


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
                ws.Cells[startRowIndex + DIDIndex, TestcaseVariables.ProjectColumnIndex] = DatabaseVariables.ProjectName;

                rowIndex++;
                DIDGroupTestcaseTemp.Clear();
            }
        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {
            subRowIndex++;

            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all supported condition in service 0x" + SID;
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
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex(SID) + "." + subRowIndex + " LabT_DCOM: Service " + SID + ":Check all supported NRC in service 0x" + SID;
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
    class Model_GetTestRequestService2E
    {
        public static string SID = "2E";

        public static List<string[]> Specification = DatabaseVariables.DatabaseService2E.ElementAt(0);
        public static List<string[]> AllowSession = DatabaseVariables.DatabaseService2E.ElementAt(1);
        public static List<string[]> NRC = DatabaseVariables.DatabaseService2E.ElementAt(2);
        public static List<string[]> Condition = DatabaseVariables.DatabaseService2E.ElementAt(3);
        public static List<string[]> Optional = DatabaseVariables.DatabaseService2E.ElementAt(4);
        public static List<string[]> SIDSupported = DatabaseVariables.DatabaseService2E.ElementAt(5);

        public static string[] parametters = Controller_ServiceHandling.GetParameters(Specification);
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
                    (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}1", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: true, length: 0, 0, 0)[index] + "\n" +
                    (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                    (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}3", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: true, length: 0, 0, 0)[index] + "\n" +
                    (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                    (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}2", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: true, length: 0, 0, 0)[index] + "\n" +
                    (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                    (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                    (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}1", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: true, length: 0, 0, 0)[index] + "\n" +
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

            int TestStepIndex = 0;

            for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
            {
                for (int index = 0; index < 3; index++)
                {
                    string step =
                        (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 0)[index] + "\n" +
                        (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}1", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), length: 0, 0, 0)[index] + "\n" +
                        (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                        (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}3", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), length: 0, 0, 0)[index] + "\n" +
                        (TestStepIndex + 8) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                        (TestStepIndex + 9) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 10) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}2", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), length: 0, 0, 0)[index] + "\n" +
                        (TestStepIndex + 11) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                        (TestStepIndex + 12) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                        (TestStepIndex + 13) + ") " + Model_TestcaseKeyword.RequestService2E(CurrentSessionDIDCodeString, expectedValue: ".*{1}1", isSIDSupportedInActiveSession: true, isParametersupported: true, addressingMode: Controller_ServiceHandling.ConvertFromIntToBool(addressingModeIndex), length: 0, 0, 0)[index] + "\n" +
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
        public static string[] GetDIDCheckComponentInDefault()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];
            int TestStepIndex = 0;

            for (int DIDVal = 0; DIDVal < Specification.Count; DIDVal++)
            {
                if (DIDVal == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 3;
                }
                if (DIDVal <= Specification.Count - 1)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        for (int index = 0; index < 3; index++)
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
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: Specification.ElementAt(DIDVal)[1],
                                                                                                    expectedValue: expectedValue,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                    isParametersupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowSession.ElementAt(DIDVal)[2]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                    length: Convert.ToInt32(Specification.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
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
                if (DIDVal == Specification.Count - 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestTesterPresent(false, 100)[index] + "\n"
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
        public static string[] GetDIDCheckComponentInExtended(List<string[]> DIDGroupTestcaseSorted)
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];
            int TestStepIndex = 0;
            
            for (int DIDVal = 0; DIDVal < DIDGroupTestcaseSorted.Count; DIDVal++)
            {
                if (DIDVal == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel(Optional.ElementAt(1)[1], true, 1000)[index] + "\n"+
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestEnvLogInLevel(Optional.ElementAt(1)[1], false, 1000)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 7;
                }
                if (DIDVal <= DIDGroupTestcaseSorted.Count - 1)
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        for (int index = 0; index < 3; index++)
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

                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: DIDGroupTestcaseSorted.ElementAt(DIDVal)[1],
                                                                                                    expectedValue: expectedValue,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                    isParametersupported: Controller_ServiceHandling.ConvertFromStringToBool(DIDGroupTestcaseSorted.ElementAt(DIDVal)[8]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                    length: Convert.ToInt32(DIDGroupTestcaseSorted.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
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
                if (DIDVal == DIDGroupTestcaseSorted.Count - 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
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
        public static string[] GetDIDCheckComponentInProgramming()
        {
            string TestStep = "";
            string TestResponse = "";
            string TeststepKeyword = "";
            string[] str = new string[3];
            int TestStepIndex = 0;

            for (int DIDVal = 0; DIDVal < Specification.Count; DIDVal++)
            {
                if (DIDVal == 0)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
                            (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestTesterPresent(true, 100)[index] + "\n" +
                            (TestStepIndex + 2) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("01")[index] + "\n" +
                            (TestStepIndex + 3) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 4) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("03")[index] + "\n" +
                            (TestStepIndex + 5) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n" +
                            (TestStepIndex + 6) + ") " + Model_TestcaseKeyword.RequestDiagnosticSession("02")[index] + "\n" +
                            (TestStepIndex + 7) + ") " + Model_TestcaseKeyword.RequestWait(1000)[index] + "\n"
                            ;
                        switch (index)
                        {
                            case 0: TestStep += step; break;
                            case 1: TestResponse += step; break;
                            case 2: TeststepKeyword += step; break;
                        }
                    }
                    TestStepIndex += 7;
                }
                else
                {
                    for (int addressingModeIndex = 0; addressingModeIndex < 2; addressingModeIndex++)
                    {
                        for (int index = 0; index < 3; index++)
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
                            string step =
                                (TestStepIndex + 1) + ") " + Model_TestcaseKeyword.RequestService2E(DID: Specification.ElementAt(DIDVal)[1],
                                                                                                    expectedValue: expectedValue,
                                                                                                    isSIDSupportedInActiveSession: Controller_ServiceHandling.ConvertFromStringToBool(SIDSupported.ElementAt(addressingModeIndex)[1]),
                                                                                                    isParametersupported: Controller_ServiceHandling.ConvertFromStringToBool(AllowSession.ElementAt(DIDVal)[3]),
                                                                                                    addressingMode: Controller_ServiceHandling.ConvertAddressingModeToBool(addressingModeIndex),
                                                                                                    length: Convert.ToInt32(Specification.ElementAt(DIDVal)[2]), 0, 0)[index] + "\n"
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
                if (DIDVal == Specification.Count - 1)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        string step =
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
