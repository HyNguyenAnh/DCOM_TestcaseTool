using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.controllers.controllers_middleware;
using dcom.declaration;

namespace dcom.controllers.controllers_UIcontainer
{
    class Controllers_UIService
    {
        public static void LoadUI_Service10()
        {
            // Sub Function
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService10.ElementAt(0)[index][1] = "1";
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service10_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service10_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[1][index - 2]);
                }
            }

            // Session Transition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_SessionTransition.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[2][index + 1]);
                }
                else if ((index < 6) && (index > 2))
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[3][index - 2]);
                }
                else
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[4][index - 5]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(2).Count; index++)
            {
                UIVariables.Service10_NRCPriority[index] = DatabaseVariables.DatabaseService10.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service10_InvalidValueCondition[index] = DatabaseVariables.DatabaseService10.ElementAt(3)[index][1];
                UIVariables.Service10_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(3)[index][2]);
                UIVariables.Service10_NRCCondition[index] = DatabaseVariables.DatabaseService10.ElementAt(3)[index][3];
            }

            // SuppressBit
            UIVariables.Service10_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service11()
        {
            // Sub Function | Reset Mode
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_ResetMode.Length; index++)
            {
                UIVariables.Service11_ButtonStatus_ResetMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(0)[index][1]);
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService11.ElementAt(2).Count; index++)
            {
                UIVariables.Service11_NRCPriority[index] = DatabaseVariables.DatabaseService11.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service11_InvalidValueCondition[index] = DatabaseVariables.DatabaseService11.ElementAt(3)[index][1];
                UIVariables.Service11_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(3)[index][2]);
                UIVariables.Service11_NRCCondition[index] = DatabaseVariables.DatabaseService11.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service11_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service14()
        {
            // Sub Function
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService14.ElementAt(0)[index][0] = "ffff";
                DatabaseVariables.DatabaseService14.ElementAt(0)[index][1] = "1";
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service14_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service14_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService14.ElementAt(2).Count; index++)
            {
                UIVariables.Service14_NRCPriority[index] = DatabaseVariables.DatabaseService14.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service14_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service14_InvalidValueCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(3)[index][1];
                UIVariables.Service14_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(3)[index][2]);
                UIVariables.Service14_NRCCondition[index] = DatabaseVariables.DatabaseService14.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service14_ButtonStatus_SuppressBit = false;
        }

        public static void LoadUI_Service19()
        {

        }

        public static void LoadUI_Service22()
        {
            // Specification
            UIVariables.Service22_DIDTable_Specification = new List<string[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(0).Count; index++)
            {
                UIVariables.Service22_DIDTable_Specification.Add(DatabaseVariables.DatabaseService22.ElementAt(0).ElementAt(index));
            }

            // Addressing Mode
            UIVariables.Service22_DIDTable_AllowSessionAddressingMode = new List<bool[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService22.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(1)[index][index_]));
                }
                UIVariables.Service22_DIDTable_AllowSessionAddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService22.ElementAt(2).Count; index++)
            {
                UIVariables.Service22_NRCPriority[index] = DatabaseVariables.DatabaseService22.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service22_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service22_InvalidValueCondition[index] = DatabaseVariables.DatabaseService22.ElementAt(3)[index][1];
                UIVariables.Service22_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(3)[index][2]);
                UIVariables.Service22_NRCCondition[index] = DatabaseVariables.DatabaseService22.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service22_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(4)[0][1]);

            // Allow Session
            for(int index = 0; index < UIVariables.Service22_ButtonStatus_AllowSession.Length; index++)
            {
                UIVariables.Service22_ButtonStatus_AllowSession[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(5)[index][1]);
            }
        }

        public static void LoadUI_Service2E()
        {
            // Specification
            UIVariables.Service2E_DIDTable_Specification = new List<string[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(0).Count; index++)
            {
                UIVariables.Service2E_DIDTable_Specification.Add(DatabaseVariables.DatabaseService2E.ElementAt(0).ElementAt(index));
            }

            // Addressing Mode
            UIVariables.Service2E_DIDTable_AddressingMode = new List<bool[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService2E.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(1)[index][index_]));
                }
                UIVariables.Service2E_DIDTable_AddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService2E.ElementAt(2).Count; index++)
            {
                UIVariables.Service2E_NRCPriority[index] = DatabaseVariables.DatabaseService2E.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service2E_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service2E_InvalidValueCondition[index] = DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1];
                UIVariables.Service2E_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(3)[index][2]);
                UIVariables.Service2E_NRCCondition[index] = DatabaseVariables.DatabaseService2E.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service2E_ButtonStatus_SecurityUnlock = Controller_ServiceHandling.ConvertFromStringLevelToBool(DatabaseVariables.DatabaseService2E.ElementAt(4)[1][1]);
            UIVariables.Service2E_SecurityUnlockLv = DatabaseVariables.DatabaseService2E.ElementAt(4)[1][1];

            // Allow Session
            for (int index = 0; index < UIVariables.Service2E_ButtonStatus_AllowSession.Length; index++)
            {
                UIVariables.Service2E_ButtonStatus_AllowSession[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(5)[index][1]);
            }
        }

        public static void LoadUI_Service27()
        {
            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(0).Count; index++)
            {
                DatabaseVariables.DatabaseService27.ElementAt(0)[index][1] = "1";
            }

            // Allow Session || Addressing Mode
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service27_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service27_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService27.ElementAt(2).Count; index++)
            {
                UIVariables.Service27_NRCPrioritySeed[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][1];
                UIVariables.Service27_NRCPriorityKey[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][2];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service27_InvalidValueCondition[index] = DatabaseVariables.DatabaseService27.ElementAt(3)[index][1];
                UIVariables.Service27_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(3)[index][2]);
                UIVariables.Service27_NRCCondition[index] = DatabaseVariables.DatabaseService27.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service27_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service28()
        {
            // Control Type
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_ControlType.Length; index++)
            {
                UIVariables.Service28_ButtonStatus_ControlType[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(0)[index][1]);
            }

            // Communication Type
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_CommunicationType.Length; index++)
            {
                UIVariables.Service28_ButtonStatus_CommunicationType[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(0)[index][3]);
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service28_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service28_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService28.ElementAt(2).Count; index++)
            {
                UIVariables.Service28_NRCPriority[index] = DatabaseVariables.DatabaseService28.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service28_InvalidValueCondition[index] = DatabaseVariables.DatabaseService28.ElementAt(3)[index][1];
                UIVariables.Service28_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(3)[index][2]);
                UIVariables.Service28_NRCCondition[index] = DatabaseVariables.DatabaseService28.ElementAt(3)[index][3];
            }

            // SuppressBit
            UIVariables.Service28_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service3E()
        {
            // Addressing Mode
            for (int index = 0; index < UIVariables.Service3E_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service3E_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService3E.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service3E_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService3E.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService3E.ElementAt(2).Count; index++)
            {
                UIVariables.Service3E_NRCPriority[index] = DatabaseVariables.DatabaseService3E.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service3E_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service3E_InvalidValueCondition[index] = DatabaseVariables.DatabaseService3E.ElementAt(3)[index][1];
                UIVariables.Service3E_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService3E.ElementAt(3)[index][2]);
                UIVariables.Service3E_NRCCondition[index] = DatabaseVariables.DatabaseService3E.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service3E_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService3E.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service85()
        {
            // Addressing Mode
            for (int index = 0; index < UIVariables.Service85_ButtonStatus_AddressingMode.Length; index++)
            {
                if (index < 3)
                {
                    UIVariables.Service85_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService85.ElementAt(1)[0][index + 1]);
                }
                else
                {
                    UIVariables.Service85_ButtonStatus_AddressingMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService85.ElementAt(1)[1][index - 2]);
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService85.ElementAt(2).Count; index++)
            {
                UIVariables.Service85_NRCPriority[index] = DatabaseVariables.DatabaseService85.ElementAt(2)[index][1];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service85_ButtonStatus_Condition.Length; index++)
            {
                UIVariables.Service85_InvalidValueCondition[index] = DatabaseVariables.DatabaseService85.ElementAt(3)[index][1];
                UIVariables.Service85_ButtonStatus_Condition[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService85.ElementAt(3)[index][2]);
                UIVariables.Service85_NRCCondition[index] = DatabaseVariables.DatabaseService85.ElementAt(3)[index][3];
            }

            // Optional
            UIVariables.Service85_ButtonStatus_SuppressBit = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService85.ElementAt(4)[0][1]);
        }

        public static void LoadUI_Service31()
        {

        }

        public static void LoadUI_CanTP()
        {

        }
    }
}
