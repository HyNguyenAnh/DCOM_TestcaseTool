using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.declaration;
using dcom.controllers.controllers_middleware;
using dcom.controllers.controllers_UIcontainer;
using dcom.models.models_databaseHandling;
using dcom.models.models_testcaseHandling;

namespace dcom.models.models_testcaseHandling
{
    class Model_TestcaseKeyword
    {
        public static string[] RequestTesterPresent(bool status, int timeout)
        {
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string TestStepStatus = Controller_ServiceHandling.ConvertFromBoolToString(status);
            int TestStepKeywordStatus = Controller_ServiceHandling.ConvertFromBoolToInt(status);

            // Test step 

            TestStep = "Tester present " + TestStepStatus + "wait" + timeout;

            // Test response
            TestReponse = "-";

            // Test step keyword
            TestStepKeyword = "envvar(EnvTesterPresentOnOff(" + TestStepKeywordStatus + ";" + timeout + "))";

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }
        public static string[] RequestDiagnosticSession(string subFunction)
        {
            // subFunction: 01, 02, 03

            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string session = Controller_ServiceHandling.ConvertFromSubFunctionToDiagnosticSessionDisplayString(subFunction);
            // Test step 

            TestStep = "Change to " + session + " session with service 0x10 " + subFunction;

            // Test response
            TestReponse = "-";

            // Test step keyword
            TestStepKeyword = "DiagSessionCtrl(" + session + ")";

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }
        public static string[] RequestReadCurrentDiagnosticSession(string subFunction, bool responseStatus)
        {
            // subFunction: 01, 02, 03

            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;
            string CurrentSessionDIDCodeString = DatabaseVariables.DatabaseCommonDIDCurrentSession[1];
            string CurrentSessionDIDDisplayString = Controller_ServiceHandling.ConvertFromCodeStringToDisplayString(CurrentSessionDIDCodeString);
            string responseTitle = Controller_ServiceHandling.GetReponseTitle(responseStatus);
            string ResponseDisplayString;
            string ResponseCodeString;

            if (responseStatus)
            {
                ResponseDisplayString = "62 "+ CurrentSessionDIDDisplayString + " " + subFunction;
            }
            else
            {
                ResponseDisplayString = "7F 22 31";
            }
            ResponseCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(ResponseDisplayString);

            // Test step 
            TestStep = "Read active session with service 0x22 " + CurrentSessionDIDDisplayString;

            // Test response
            TestReponse = responseTitle + "0x " + ResponseDisplayString;

            // Test step keyword
            TestStepKeyword = "RequestResponse(22" + CurrentSessionDIDCodeString + "," + ResponseCodeString + ", Equal)";

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }
        public static string[] RequestService10(string subFunction, bool isSubFunctionSupported, bool isSubFunctionSupportedInActiveSession, bool suppressBitEnabledStatus, bool isSuppressBitSupported, bool isSIDSupportedInActiveSession, string expectedValue, bool addressingMode)
        {
            // subFunction: 01, 02, 03
            // suppressBitEnabledStatus: true -> request 1081, false -> request 1001
            // isSuppressBitSupported: true -> 1081 - 5081, false -> 1081 -> 7F1012
            // isSIDSupportedInActiveSession: true -> positive response, false: NRC 7F
            // isSubFunctionSupportedInActiveSession: true -> Positive response, false -> NRC 7E
            // addressing mode: 0: Physical, 1: Functional

            string SID = "10";
            string subFunctionNew;
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string RequestDisplayString;
            string RequestCodeString;

            string ResponseID = Controller_ServiceHandling.GetResponseID(SID);
            string ResponseCodeString = "";


            if (suppressBitEnabledStatus)
            {
                subFunctionNew = Controller_ServiceHandling.GetSuppressBitSubFunction(subFunction);
            }
            else
            {
                subFunctionNew = subFunction;
            }

            // Configure request string
            RequestDisplayString = SID + subFunctionNew;
            RequestDisplayString = Controller_ServiceHandling.ConvertFromCodeStringToDisplayString(RequestDisplayString);
            RequestCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(RequestDisplayString);

            // Configure response string
            if (isSIDSupportedInActiveSession)
            {
                if ((suppressBitEnabledStatus & isSubFunctionSupported & isSuppressBitSupported) | (!suppressBitEnabledStatus & isSubFunctionSupported))
                {
                    if (isSubFunctionSupportedInActiveSession)
                    {
                        switch (suppressBitEnabledStatus)
                        {
                            case true:
                                ResponseCodeString = "";
                                break;
                            case false:
                                ResponseCodeString = ResponseID + subFunctionNew + expectedValue;
                                break;
                        }

                    }
                    else
                    {
                        ResponseCodeString = "7f" + ResponseID + "7e";
                    }
                }
                else
                {
                    ResponseCodeString = "7f" + ResponseID + "12";
                }
            }
            else
            {
                ResponseCodeString = "7f" + ResponseID + "7f";
            }

            ResponseCodeString = Controller_ServiceHandling.GetResponseCodeString(ResponseCodeString, addressingMode: addressingMode, suppressBitEnabledStatus: suppressBitEnabledStatus, isSIDSupportedInActiveSession: isSIDSupportedInActiveSession, isSubFunctionSupportedInActiveSession: isSubFunctionSupportedInActiveSession, isParametterAvailable: true);


            // Test step 
            TestStep = Controller_ServiceHandling.GetTestStep(SID, RequestCodeString, addressingMode);

            // Test response
            TestReponse = Controller_ServiceHandling.GetTestResponse(ResponseCodeString);

            // Test step keyword
            TestStepKeyword = Controller_ServiceHandling.GetTestStepKeyword(RequestCodeString, ResponseCodeString, addressingMode);

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }

        public static string[] RequestService11(string subFunction, bool isSubFunctionSupported,bool isSubFunctionSupportedInActiveSession, bool suppressBitEnabledStatus, bool isSuppressBitSupported, bool isSIDSupportedInActiveSession, bool addressingMode)
        {

            string SID = "11";
            string subFunctionNew;
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string RequestDisplayString;
            string RequestCodeString;

            string ResponseID = Controller_ServiceHandling.GetResponseID(SID);
            string ResponseCodeString = "";


            if (suppressBitEnabledStatus)
            {
                subFunctionNew = Controller_ServiceHandling.GetSuppressBitSubFunction(subFunction);    
            }
            else
            {
                subFunctionNew = subFunction;
            }

            // Configure request string
            RequestDisplayString = SID + subFunctionNew;
            RequestDisplayString = Controller_ServiceHandling.ConvertFromCodeStringToDisplayString(RequestDisplayString);
            RequestCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(RequestDisplayString);

            // Configure response string
            if (isSIDSupportedInActiveSession)
            {
                if ((suppressBitEnabledStatus & isSubFunctionSupported & isSuppressBitSupported) | (!suppressBitEnabledStatus & isSubFunctionSupported))
                {
                    if (isSubFunctionSupportedInActiveSession)
                    {
                        switch (suppressBitEnabledStatus)
                        {
                            case true:
                                ResponseCodeString = "";
                                break;
                            case false:
                                ResponseCodeString = ResponseID + subFunctionNew;
                                break;
                        }

                    }
                    else
                    {
                        ResponseCodeString = "7f" + ResponseID + "7e";
                    }
                }
                else
                {
                    ResponseCodeString = "7f" + ResponseID + "12";
                }
            }
            else
            { 
                ResponseCodeString = "7f" + ResponseID + "7f";
            }

            ResponseCodeString = Controller_ServiceHandling.GetResponseCodeString(ResponseCodeString, addressingMode: addressingMode, suppressBitEnabledStatus: suppressBitEnabledStatus, isSIDSupportedInActiveSession: isSIDSupportedInActiveSession, isSubFunctionSupportedInActiveSession: isSubFunctionSupportedInActiveSession, isParametterAvailable: false);


            // Test step 
            TestStep = Controller_ServiceHandling.GetTestStep(SID, RequestCodeString, addressingMode);

            // Test response
            TestReponse = Controller_ServiceHandling.GetTestResponse(ResponseCodeString);

            // Test step keyword
            TestStepKeyword = Controller_ServiceHandling.GetTestStepKeyword(RequestCodeString, ResponseCodeString, addressingMode);

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }
        public static string[] RequestService3E(string subFunction, bool isSubFunctionSupported, bool isSubFunctionSupportedInActiveSession, bool suppressBitEnabledStatus, bool isSuppressBitSupported, bool isSIDSupportedInActiveSession, bool addressingMode)
        {

            string SID = "3E";
            string subFunctionNew;
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string RequestDisplayString;
            string RequestCodeString;

            string ResponseID = Controller_ServiceHandling.GetResponseID(SID);
            string ResponseCodeString = "";


            if (suppressBitEnabledStatus)
            {
                subFunctionNew = Controller_ServiceHandling.GetSuppressBitSubFunction(subFunction);
            }
            else
            {
                subFunctionNew = subFunction;
            }

            // Configure request string
            RequestDisplayString = SID + subFunctionNew;
            RequestDisplayString = Controller_ServiceHandling.ConvertFromCodeStringToDisplayString(RequestDisplayString);
            RequestCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(RequestDisplayString);

            // Configure response string
            if (isSIDSupportedInActiveSession)
            {
                if ((suppressBitEnabledStatus & isSubFunctionSupported & isSuppressBitSupported) | (!suppressBitEnabledStatus & isSubFunctionSupported))
                {
                    if (isSubFunctionSupportedInActiveSession)
                    {
                        switch (suppressBitEnabledStatus)
                        {
                            case true:
                                ResponseCodeString = "";
                                break;
                            case false:
                                ResponseCodeString = ResponseID + subFunctionNew;
                                break;
                        }

                    }
                    else
                    {
                        ResponseCodeString = "7f" + ResponseID + "7e";
                    }
                }
                else
                {
                    ResponseCodeString = "7f" + ResponseID + "12";
                }
            }
            else
            {
                ResponseCodeString = "7f" + ResponseID + "7f";
            }

            ResponseCodeString = Controller_ServiceHandling.GetResponseCodeString(ResponseCodeString, addressingMode: addressingMode, suppressBitEnabledStatus: suppressBitEnabledStatus, isSIDSupportedInActiveSession: isSIDSupportedInActiveSession, isSubFunctionSupportedInActiveSession: isSubFunctionSupportedInActiveSession, isParametterAvailable: false);


            // Test step 
            TestStep = Controller_ServiceHandling.GetTestStep(SID, RequestCodeString, addressingMode);

            // Test response
            TestReponse = Controller_ServiceHandling.GetTestResponse(ResponseCodeString);

            // Test step keyword
            TestStepKeyword = Controller_ServiceHandling.GetTestStepKeyword(RequestCodeString, ResponseCodeString, addressingMode);

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }

        public static string[] RequestService14(string parametter, bool isSIDSupportedInActiveSession, bool addressingMode)
        {
            // parametter: ffffff
            // isSIDSupportedInActiveSession: true -> Positive response, false -> NRC 7F
            // addressingMode: true -> Physical, false -> Functional

            string SID = "14";
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string RequestCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(SID + parametter);
            

            string ResponseID = Controller_ServiceHandling.GetResponseID(SID);
            string ResponseCodeString;



            // Configure request string

            // Configure response string
            if (isSIDSupportedInActiveSession)
            {
                ResponseCodeString = ResponseID;
            }
            else
            {
                ResponseCodeString = "7f" + SID + "7f";
            }

            ResponseCodeString = Controller_ServiceHandling.GetResponseCodeString(ResponseCodeString, addressingMode: addressingMode, suppressBitEnabledStatus: false, isSIDSupportedInActiveSession: isSIDSupportedInActiveSession, isSubFunctionSupportedInActiveSession: true, isParametterAvailable: false);


            // Test step 
            TestStep = Controller_ServiceHandling.GetTestStep(SID, RequestCodeString, addressingMode);

            // Test response
            TestReponse = Controller_ServiceHandling.GetTestResponse(ResponseCodeString);

            // Test step keyword
            TestStepKeyword = Controller_ServiceHandling.GetTestStepKeyword(RequestCodeString, ResponseCodeString, addressingMode);


            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }

        public static string[] RequestService22(string DID, string expectedValue, bool isAddressingModeSupported, bool isSIDSupportedInActiveSession, bool isParametersupported, bool addressingMode)
        {

            string SID = "22";
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            string RequestCodeString = Controller_ServiceHandling.ConvertFromDisplayStringToCodeString(SID + DID);
            string ResponseID = Controller_ServiceHandling.GetResponseID(SID);
            string ResponseCodeString;

            // Configure response string
            if (addressingMode)
            {
                if (isAddressingModeSupported)
                {
                    if (isSIDSupportedInActiveSession)
                    {
                        if (isParametersupported)
                        {
                            ResponseCodeString = ResponseID + DID + expectedValue;
                        }
                        else
                        {
                            ResponseCodeString = "7f" + SID + "31";
                        }
                    }
                    else
                    {
                        ResponseCodeString = "7f" + SID + "7f";
                    }
                }
                else
                {
                    ResponseCodeString = "7f" + SID + "31";
                }
            }
            else
            {
                if (isAddressingModeSupported)
                {
                    if (isSIDSupportedInActiveSession)
                    {
                        if (isParametersupported)
                        {
                            ResponseCodeString = ResponseID + DID + expectedValue;
                        }
                        else
                        {
                            ResponseCodeString = "7f" + SID + "31";
                        }
                    }
                    else
                    {
                        ResponseCodeString = "";
                    }
                }
                else
                {
                    ResponseCodeString = "";
                }
            }

            //ResponseCodeString = Controller_ServiceHandling.GetResponseCodeString(ResponseCodeString, addressingMode: addressingMode, suppressBitEnabledStatus: false, isSIDSupportedInActiveSession: isSIDSupportedInActiveSession, isSubFunctionSupportedInActiveSession: true, isParametterAvailable: true);


            // Test step 
            TestStep = Controller_ServiceHandling.GetTestStep(SID, RequestCodeString, addressingMode);

            // Test response
            TestReponse = Controller_ServiceHandling.GetTestResponse(ResponseCodeString);

            // Test step keyword
            TestStepKeyword = Controller_ServiceHandling.GetTestStepKeyword(RequestCodeString, ResponseCodeString, addressingMode);

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }
        public static string[] RequestWait(int timeoutMilisecond)
        {
            // Unit: ms
            // Example: 1000 ms
            string[] Data;
            string TestStep;
            string TestReponse;
            string TestStepKeyword;

            // Test step 

            TestStep = "Wait " + timeoutMilisecond + " ms";

            // Test response
            TestReponse = "-";

            // Test step keyword
            TestStepKeyword = "wait("+ timeoutMilisecond + ")";

            Data = new string[]
            {
                TestStep,
                TestReponse,
                TestStepKeyword
            };
            return Data;
        }


    }
}
