﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{
    class UIVariables
    {
        public static bool CompletedEdit { get; set; }
        // NRC List
        public static string[] NRCs { get; set; }
        public static string[] SecurityUnlockLevel { get; set; }
        // Common Setting
        public static string DatabasePath { get; set; }
        public static string TestcaseDirectory { get; set; }
        public static string DatabaseDirectory { get; set; }
        public static string TemplatePath { get; set; }
        public static string DatabaseSource { get; set; }

        public static string[] ProjectInformation { get; set; }
        
        public static bool[] SelectedServiceStatus { get; set; }

        public static string ProjectName { get; set; }
        public static string Variant { get; set; }
        public static string Release { get; set; }
        public static string RC { get; set; }

        public static List<string[]>[] CommonSettingDatabase { get; set; }
        public static string[] DatabaseCommonSettingCreateFault { get; set; }
        public static string[] DatabaseCommonSettingVehicleSpeed { get; set; }
        public static string[] DatabaseCommonSettingEngineStatus { get; set; }
        public static string[] DatabaseCommonSettingSecurityUnlock { get; set; }

        public static string[] DatabaseCommonDIDCurrentSession { get; set; }
        public static string[] DatabaseCommonDIDInvalidCounter { get; set; }
        public static string[] DatabaseCommonDIDCurrentVoltage { get; set; }

        public static List<string[]> DatabaseCommonSetting { get; set; }
        public static List<string[]> DatabaseCommonDID { get; set; }



        // Service 10 *****************************************************************************************************************

        public static List<string[]> Service10_SubFunction { get; set; }
        public static bool[] Service10_ButtonStatus_SessionTransition { get; set; }
        public static bool Service10_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service10_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service10_ButtonStatus_Condition { get; set; }
        public static string[] Service10_NRCCondition { get; set; }
        public static string[] Service10_InvalidValueCondition { get; set; }
        public static string[] Service10_NameInvalidValueCondition { get; set; }
        public static string[] Service10_NRCPriority { get; set; }

        // Service 11 *****************************************************************************************************************

        public static bool[] Service11_ButtonStatus_ResetMode{ get; set; }
        public static bool Service11_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service11_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service11_ButtonStatus_Condition { get; set; }
        public static string[] Service11_NRCPriority { get; set; }
        public static string[] Service11_NRCCondition { get; set; }
        public static string[] Service11_InvalidValueCondition { get; set; }
        public static string[] Service11_NameInvalidValueCondition { get; set; }

        // Service 14 *****************************************************************************************************************

        public static bool[] Service14_ButtonStatus_SubFunction { get; set; }
        public static bool Service14_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service14_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service14_ButtonStatus_Condition { get; set; }
        public static string[] Service14_NRCPriority { get; set; }
        public static string[] Service14_NRCCondition { get; set; }
        public static string[] Service14_InvalidValueCondition { get; set; }
        public static string[] Service14_NameInvalidValueCondition { get; set; }

        // Service 19 *****************************************************************************************************************


        // Service 22 *****************************************************************************************************************
        public static List<string[]> Service22_DIDTable_Specification { get; set; }
        public static List<bool[]> Service22_DIDTable_AllowSessionAddressingMode { get; set; }
        public static bool Service22_ButtonStatus_SuppressBit { get; set; }
        public static string[] Service22_NRCPriority { get; set; }
        public static string[] Service22_InvalidValueCondition { get; set; }
        public static string[] Service22_NameInvalidValueCondition { get; set; }
        public static bool[] Service22_ButtonStatus_Condition { get; set; }
        public static string[] Service22_NRCCondition { get; set; }
        public static bool[] Service22_ButtonStatus_AllowSession { get; set; }

        // Service 2E *****************************************************************************************************************
        public static List<string[]> Service2E_DIDTable_Specification { get; set; }
        public static List<bool[]> Service2E_DIDTable_AddressingMode { get; set; }
        public static bool Service2E_ButtonStatus_SecurityUnlock { get; set; }
        public static string Service2E_SecurityUnlockLv { get; set; }
        public static string[] Service2E_NRCPriority { get; set; }
        public static string[] Service2E_InvalidValueCondition { get; set; }
        public static string[] Service2E_NameInvalidValueCondition { get; set; }
        public static bool[] Service2E_ButtonStatus_Condition { get; set; }
        public static string[] Service2E_NRCCondition { get; set; }
        public static bool[] Service2E_ButtonStatus_AllowSession { get; set; }

        // Service 27 *****************************************************************************************************************
        public static bool Service27_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service27_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service27_ButtonStatus_Condition { get; set; }
        public static string[] Service27_NRCPrioritySeed { get; set; }
        public static string[] Service27_NRCPriorityKey { get; set; }
        public static string[] Service27_NRCCondition { get; set; }
        public static string[] Service27_InvalidValueCondition { get; set; }
        public static string[] Service27_NameInvalidValueCondition { get; set; }

        // Service 28 *****************************************************************************************************************

        public static bool[] Service28_ButtonStatus_ControlType { get; set; }
        public static bool[] Service28_ButtonStatus_CommunicationType { get; set; }
        public static bool Service28_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service28_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service28_ButtonStatus_Condition { get; set; }
        public static string[] Service28_NRCCondition { get; set; }
        public static string[] Service28_InvalidValueCondition { get; set; }
        public static string[] Service28_NameInvalidValueCondition { get; set; }
        public static string[] Service28_NRCPriority { get; set; }

        // Service 3E *****************************************************************************************************************

        public static bool Service3E_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service3E_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service3E_ButtonStatus_Condition { get; set; }
        public static string[] Service3E_NRCCondition { get; set; }
        public static string[] Service3E_InvalidValueCondition { get; set; }
        public static string[] Service3E_NameInvalidValueCondition { get; set; }
        public static string[] Service3E_NRCPriority { get; set; }

        // Service 85 *****************************************************************************************************************

        public static bool Service85_ButtonStatus_SuppressBit { get; set; }
        public static bool[] Service85_ButtonStatus_AddressingMode { get; set; }
        public static bool[] Service85_ButtonStatus_Condition { get; set; }
        public static string[] Service85_NRCCondition { get; set; }
        public static string[] Service85_InvalidValueCondition { get; set; }
        public static string[] Service85_NameInvalidValueCondition { get; set; }
        public static string[] Service85_NRCPriority { get; set; }
    }
}
