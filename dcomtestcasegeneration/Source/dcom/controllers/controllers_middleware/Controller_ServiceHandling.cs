﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.controllers.controllers_middleware
{
    class Controller_ServiceHandling
    {
        public static string GetServiceTestGroupIndex(string SID)
        {
            string index;
            
            switch (SID)
            {
                case "10": index = "2.1"; break;
                case "11": index = "2.2"; break;
                case "14": index = "2.3"; break;
                case "19": index = "2.4"; break;
                case "22": index = "2.5"; break;
                case "27": index = "2.6"; break;
                case "28": index = "2.7"; break;
                case "2E": index = "2.8"; break;
                case "31": index = "2.9"; break;
                case "3E": index = "2.10"; break;
                case "85": index = "2.11"; break;
                case "CanTP": index = "2.12"; break;
                default  : index = "3"; break;
            }

            return index;
        }

        public static string GetServiceTestGroupTitle(string SID)
        {
            string title;

            switch (SID)
            {
                case "10": title = " Service 10h - Diagnostic Session Control"; break;
                case "11": title = " Service 11h - ECU Reset"; break;
                case "14": title = " Service 14h - Clear Diagnostic Information"; break;
                case "19": title = " Service 19h - ReadDTCInformation"; break;
                case "22": title = " Service 22h - Read Data By Identifier"; break;
                case "27": title = " Service 27h - Security Access"; break;
                case "28": title = " Service 28h - Communication Control"; break;
                case "2E": title = " Service 2Eh - Write Data by Identifier"; break;
                case "31": title = " Service 31h - Routine Control"; break;
                case "3E": title = " Service 3Eh - Tester Present"; break;
                case "85": title = " Service 85h - Control DTC Setting"; break;
                case "CanTP": title = " CanTP - Input Output Control By Identifier"; break;
                default: title = ""; break;
            }

            return title;
        }

        public static string GetSheetNameOfService(string SID)
        {
            // SID  = "0" => Sheet Name = "Common_settings"
            // SID != "0" => Sheet Name = "Service_" + SID :: Example: Service_10, Service_2E

            if (SID != "0" && SID != "CanTP")
            {
                return "Service_" + SID.ToUpper();
            }
            if(SID == "CanTP")
            {
                return SID;
            }
            else
            {
                return "Common_settings";
            }

        }

        public static List<string[]> GetControlType(List<string[]> Specification)
        {
            List<string[]> controlType = new List<string[]>();
            for(int index = 0; index < Specification.Count; index++)
            {
                string[] row = new string[2];
                for (int index_ = 0; index_ < 2; index_++)
                {
                    row[index_] = Specification.ElementAt(index)[index_];
                }
                controlType.Add(row);
            }
            return controlType;
        }
        public static List<string[]> GetCommunicationType(List<string[]> Specification)
        {
            List<string[]> communicationType = new List<string[]>();
            for (int index = 0; index < Specification.Count - 1; index++)
            {
                string[] row = new string[2];
                for (int index_ = 0; index_ < 2; index_++)
                {
                    row[index_] = Specification.ElementAt(index)[index_ + 2];
                }
                communicationType.Add(row);
            }
            return communicationType;
        }

        public static string[] GetSubFunctions(List<string[]> Specification)
        {
            string[] SubFunction = new string[Specification.Count];

            for (int index = 0; index < Specification.Count; index++)
            {
                SubFunction[index] = Specification.ElementAt(index)[0];
            }

            return SubFunction;
        }
        public static string[] GetParameters(List<string[]> Specification)
        {
            string[] SubFunction = new string[Specification.Count];

            for (int index = 0; index < Specification.Count; index++)
            {
                SubFunction[index] = Specification.ElementAt(index)[1];
            }

            return SubFunction;
        }
        public static string[] GetAllowedSessionList(List<string[]> AllowSession, bool addressingMode)
        {
            // addressingMode = true: Physical
            // addressingMode = false: Functional

            if (addressingMode)
            {
                return AllowSession.ElementAt(0);
            }
            else
            {
                return AllowSession.ElementAt(1);
            }

        }

        public static string ConvertFromCodeStringToDisplayString(string CodeString)
        {
            // Example: 22f189 -> 22 F1 89
            string DisplayString = CodeString.ToUpper();
            DisplayString = DisplayString.Replace(" ", "");
 
            for (int charIndex = 2; charIndex < DisplayString.Length; charIndex += 3)
            {
                DisplayString = DisplayString.Insert(charIndex, " ");
            }


            return DisplayString;
        }

        public static bool ConvertFromExpectedValueToBool(string expectedValue)
        {
            // Example: 7f1112 -> false; 5101 -> true
            if (expectedValue.ToLower().Contains("7f"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string ConvertFromBoolToExpectedValue(bool value, string SID, string errorNRC, string modeID)
        {
            string expectedValue;
            // Example: false -> 117f12; true -> 5101
            if (value)
            {
                expectedValue = Controller_ServiceHandling.GetResponseID(SID) + "0" + modeID;
            }
            else
            {
                expectedValue = $"7f{SID}{errorNRC}";
            }
            return expectedValue;
        }

        public static string ConvertFromDisplayStringToCodeString(string DisplayString)
        {
            // Example: 22 F1 89 -> 22f189
            string CodeString = DisplayString.ToLower();

            CodeString = CodeString.Replace(" ", "");

            return CodeString;
        }

        public static int ConvertFromBoolToInt(bool value)
        {
            // Example: true -> 1; false -> 0
            if (value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static string ConvertFromBoolToStringBit(bool value)
        {
            // Example: true -> "1"; false -> "0"
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static bool ConvertFromIntToBool(int value)
        {
            // Example: 1 -> true; 0 -> false
            if (value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ConvertAddressingModeToBool(int value)
        {
            // Example: 0 -> true; 1 -> false
            if (value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ConvertFromStringToBool(string value)
        {
            // "0" -> false
            // "1" -> true
            if (value == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ConvertFromStringOptionalToBool(string value)
        {
            // "0" -> false
            // "1" -> true
            if (value == "0" | value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string ConvertFromBoolToString(bool value)
        {
            // Example: 1 -> ON; 0 -> OFF
            if (value)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }
        public static bool ConvertFromStatusToBool(string value)
        {
            // Example: "ON" -> 1; "OFF" -> 0
            if(value == "ON" | value == "Brown")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ConvertFromStatusToString(string value)
        {
            // Example: "ON" | "Brown" | "1" -> "1"; "OFF" -> "0"
            if(value == "ON" | value == "Brown" | value == "1")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static string ConvertFromSubFunctionToDiagnosticSessionDisplayString(string subFunction)
        {
            // Example: 01 -> Default, 02 -> Programming, 03 -> Extended

            string data;
            switch (subFunction)
            {
                case "01":
                    data = "Default";
                    break;
                case "02":
                    data = "Programming";
                    break;
                case "03":
                    data = "Extended";
                    break;
                default:
                    data = "Default";
                    break;
            }


            return data;
        }

        public static string GetReponseTitle(bool responseStatus)
        {
            // Example: true -> "Positive response is received:"; false -> "Negative response is received:"

            if (responseStatus)
            {
                return "Positive response is received:";
            }
            else
            {
                return "Negative response is received:";
            }

        }

        
        public static string GetRequestResponseMethod(bool addressingMode)
        {
            // Physical addressing mode: true -> "RequestResponse"
            // Functional addressing mode: false -> "FunctionalMessage"
            if (addressingMode)
            {
                return "RequestResponse";
            }
            else
            {
                return "FunctionalMessage";
            }
        }
       
        public static string GetResponseCodeString(string orgResponseCodeString, bool addressingMode, bool suppressBitEnabledStatus, bool isSIDSupportedInActiveSession, bool isSubFunctionSupportedInActiveSession, bool isParametterAvailable)
        {
            // addressingMode: true: Physical, false -> Functional 
            // suppressBitEnabledStatus: true: request supress bit in sub-function, false: normal subfunction

            string data = "";
            switch (addressingMode)
            {
                case true: // Physical Addressing Mode
                    if(suppressBitEnabledStatus & isSIDSupportedInActiveSession & isSubFunctionSupportedInActiveSession & isParametterAvailable)
                    {
                        if (orgResponseCodeString.ToLower().Contains("7f"))
                        {
                            data = orgResponseCodeString;
                        }
                        else
                        {
                            data = "";
                        }
                    }
                    else
                    {
                         data = orgResponseCodeString;
                    }
                    break;
                case false: // Functional Addressing Mode
                    if (isSIDSupportedInActiveSession)
                    {
                        if (isSubFunctionSupportedInActiveSession)
                        {
                            if (isParametterAvailable)
                            {
                                if (orgResponseCodeString.ToLower().Contains("7f"))
                                {
                                    data = orgResponseCodeString;
                                }
                                else
                                {
                                    if (suppressBitEnabledStatus)
                                    {
                                        data = orgResponseCodeString;
                                    }
                                    else
                                    {
                                        data = "";
                                    }
                                }
                            }
                            else
                            {
                                data = "";
                            }
                        }
                        else
                        {
                            data = "";

                        }
                    }
                    else
                    {
                        data = "";
                    }
                    
                    break;
            }

            return data.ToLower();
        }

        public static string GetResponseCodeStringCondtion(int condtionIndex, double invalidValue, double setInvalidValue, string orgResponseCodeString, string ResponseID, string conditionNRC, string conditionName)
        {
            string data = "";
            switch (condtionIndex)
            {
                case 0:
                    data = orgResponseCodeString;
                    break;
                case 1:
                    if (((setInvalidValue <= invalidValue) & (setInvalidValue >= 0)) || setInvalidValue == 0 || setInvalidValue == 10)
                    {
                        data = orgResponseCodeString;
                    }
                    else
                    {
                        data = $"7f{ResponseID}{conditionNRC}";
                    }
                    break;
                case 2:
                    if((invalidValue == 0) || (invalidValue == 0 && setInvalidValue != 0))
                    {
                        data = orgResponseCodeString;
                    }
                    else
                    {
                        data = $"7f{ResponseID}{conditionNRC}";
                    }
                    break;
                case 3:
                    if (((setInvalidValue <= invalidValue) & (setInvalidValue > 0) & (conditionName == "Low")) | ((setInvalidValue >= invalidValue) & (setInvalidValue <= 18) & (conditionName == "High")))
                    {
                        data = orgResponseCodeString;
                    }
                    else
                    {
                        data = $"7f{ResponseID}{conditionNRC}";
                    }
                    break;
            }

            return data.ToLower();
        }


        public static string GetResponseID(string SID)
        {
            // Example: SID = 2E -> Response ID = SID + 40h = 6Eh
            // 10 -> 50
            // 11 -> 51
            // 14 -> 54
            // 19 -> 59
            // 22 -> 62
            // 27 -> 67
            // 28 -> 68
            // 2E -> 6E
            // 2F -> 6F
            // 31 -> 71
            // 3E -> 7E
            // 85 -> C5
            string data;
            int dec = int.Parse(SID, System.Globalization.NumberStyles.HexNumber) + int.Parse("40", System.Globalization.NumberStyles.HexNumber);


            data = dec.ToString("X");


            return data;
        }

        public static string GetSuppressBitSubFunction(string subFunction)
        {
            // Example: SubFunction 01 -> 81

            string data;
            int dec = int.Parse(subFunction, System.Globalization.NumberStyles.HexNumber) + int.Parse("80", System.Globalization.NumberStyles.HexNumber);


            data = dec.ToString("X");


            return data;
        }

        public static string GetTestStep(string SID, string requestCodeString, bool addressingMode)
        {
            string data = "";
            string TestStepTitleAddressingMode;
            string RequestDisplayString = ConvertFromCodeStringToDisplayString(requestCodeString);

            // Physical addressing mode: true -> "Physical Addressing Mode"
            // Functional addressing mode: false -> "Functional Addressing Mode"
            if (addressingMode)
            {
                TestStepTitleAddressingMode = "Physical Addressing Mode";
            }
            else
            {
                TestStepTitleAddressingMode = "Functional Addressing Mode";
            }

            switch (SID)
            {
                case "10": data = $"Request change the diagnostic session with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "11": data = $"Request reset the camera with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "14": data = $"Request clear DTC with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "19": data = $"Request read DTC with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "22": data = $"Send {RequestDisplayString} Using {TestStepTitleAddressingMode}"; break;
                case "27": data = $"Request security access with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "28": data = $"Request communication control with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "2E": data = $"Send {RequestDisplayString} Using {TestStepTitleAddressingMode}"; break;
                case "2F": data = $"Request input output control by identier with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "31": data = $"Request routine control with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "3E": data = $"Request tester present with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
                case "85": data = $"Request control DTC setting with service 0x{RequestDisplayString} in {TestStepTitleAddressingMode}"; break;
            }
            return data;
        }

        public static string GetTestResponse(string responseCodeString)
        {
            if (responseCodeString == "")
            {
                return $"No response is received";
            }
            else if (responseCodeString.Contains("7f"))
            {
                return $"Negative response is received: 0x{ConvertFromCodeStringToDisplayString(responseCodeString)}";
            }
            else
            {
                return $"Positive response is received: 0x{ConvertFromCodeStringToDisplayString(responseCodeString)}";
            }
        }
        public static string GetTestStepKeyword(string requestCodeString, string responseCodeString, bool addressingMode)
        {

            string RequestResponseMethod;
            string CompareMethod;
            // Physical addressing mode: true -> "RequestResponse"
            // Functional addressing mode: false -> "FunctionalMessage"
            if (addressingMode)
            {
                RequestResponseMethod = "RequestResponse";
            }
            else
            {
                RequestResponseMethod = "FunctionalMessage";
            }

            if (responseCodeString == "")
            {
                CompareMethod = "None";
            }
            else if (responseCodeString.Contains(".") | responseCodeString.Contains("*")| responseCodeString.Contains("{") | responseCodeString.Contains("}"))
            {
                CompareMethod = "Regexp";
            }
            else
            {
                CompareMethod = "Equal";
            }

            return $"{RequestResponseMethod}({requestCodeString.ToLower()}, {responseCodeString.ToLower()}, { CompareMethod})"; //RequestResponse(1101, 5101, Equal)


        }

    }
}
