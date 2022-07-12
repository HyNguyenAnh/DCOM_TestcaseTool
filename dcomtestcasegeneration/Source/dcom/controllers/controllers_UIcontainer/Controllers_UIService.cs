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
        public static void UIDefinition_Service10()
        {

            // Sub Function
            UIVariables.Service10_SubFunction = new List<string[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService10?.ElementAt(0).Count; index++)
            {
                UIVariables.Service10_SubFunction.Add(DatabaseVariables.DatabaseService10.ElementAt(0).ElementAt(index));
                UIVariables.Service10_SubFunction.ElementAt(index)[1] = "1";
            }

            // Addressing Mode
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_AddressingMode?.Length; index++)
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
            for (int index = 0; index < UIVariables.Service10_ButtonStatus_SessionTransition?.Length; index++)
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
            for (int index = 0; index < DatabaseVariables.DatabaseService10?.ElementAt(2).Count; index++)
            {
                UIVariables.Service10_NRCPriority[index] = DatabaseVariables.DatabaseService10.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service10_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service10_EngineStatusCondition = new List<string[]>();
            UIVariables.Service10_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService10?.ElementAt(3).Count; index++)
            {
                if(DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service10_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService10.ElementAt(3)[index]);
                }
                else if(DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service10_EngineStatusCondition.Add(DatabaseVariables.DatabaseService10.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service10_VoltageCondition.Add(DatabaseVariables.DatabaseService10.ElementAt(3)[index]);
                }
            }
            UIVariables.Service10_InvalidValueCondition = new string[4];
            UIVariables.Service10_ButtonStatus_Condition = new bool[3];
            UIVariables.Service10_NRCCondition = new string[3];
            UIVariables.Service10_InvalidValueCondition[0] = UIVariables.Service10_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service10_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service10_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service10_NRCCondition[0] = UIVariables.Service10_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service10_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service10_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service10_InvalidValueCondition[1] += $"{UIVariables.Service10_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service10_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service10_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service10_ValidValueCondition = UIVariables.Service10_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service10_NRCCondition[1] = UIVariables.Service10_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service10_InvalidValueCondition[1] = UIVariables.Service10_InvalidValueCondition[1].Remove(UIVariables.Service10_InvalidValueCondition[1].Length - 2);
                UIVariables.Service10_ButtonStatus_Condition[1] = true;
            }
            else 
            { 
                UIVariables.Service10_InvalidValueCondition[1] = "";
                UIVariables.Service10_ValidValueCondition = "";
                UIVariables.Service10_ButtonStatus_Condition[1] = false;
                UIVariables.Service10_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service10_VoltageCondition?.Count; index++)
            {
                UIVariables.Service10_InvalidValueCondition[index + 2] = UIVariables.Service10_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service10_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service10_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service10_NRCCondition[2] = UIVariables.Service10_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService10?.ElementAt(4).Count; index++)
            {
                UIVariables.Service10_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService10.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service11()
        {
            // Sub Function | Reset Mode
            for (int index = 0; index < UIVariables.Service11_ButtonStatus_ResetMode?.Length; index++)
            {
                UIVariables.Service11_ButtonStatus_ResetMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(0)[index][1]);
            }

            // Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(2).Count; index++)
            {
                UIVariables.Service11_NRCPriority[index] = DatabaseVariables.DatabaseService11.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service11_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service11_EngineStatusCondition = new List<string[]>();
            UIVariables.Service11_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service11_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService11.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service11_EngineStatusCondition.Add(DatabaseVariables.DatabaseService11.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service11_VoltageCondition.Add(DatabaseVariables.DatabaseService11.ElementAt(3)[index]);
                }
            }
            UIVariables.Service11_InvalidValueCondition = new string[4];
            UIVariables.Service11_ButtonStatus_Condition = new bool[3];
            UIVariables.Service11_NRCCondition = new string[3];
            UIVariables.Service11_InvalidValueCondition[0] = UIVariables.Service11_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service11_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service11_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service11_NRCCondition[0] = UIVariables.Service11_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service11_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service11_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service11_InvalidValueCondition[1] += $"{UIVariables.Service11_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service11_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service11_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service11_ValidValueCondition = UIVariables.Service11_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service11_NRCCondition[1] = UIVariables.Service11_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service11_InvalidValueCondition[1] = UIVariables.Service11_InvalidValueCondition[1].Remove(UIVariables.Service11_InvalidValueCondition[1].Length - 2);
                UIVariables.Service11_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service11_InvalidValueCondition[1] = "";
                UIVariables.Service11_ValidValueCondition = "";
                UIVariables.Service11_ButtonStatus_Condition[1] = false;
                UIVariables.Service11_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service11_VoltageCondition?.Count; index++)
            {
                UIVariables.Service11_InvalidValueCondition[index + 2] = UIVariables.Service11_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service11_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service11_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service11_NRCCondition[2] = UIVariables.Service11_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(4).Count; index++)
            {
                UIVariables.Service11_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService11.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service14()
        {
            // Sub Function
            UIVariables.Service14_SubFunction = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService14?.ElementAt(0).Count; index++)
            {
                UIVariables.Service14_SubFunction.Add(DatabaseVariables.DatabaseService14?.ElementAt(0)?.ElementAt(index));
                UIVariables.Service14_SubFunction.ElementAt(index)[1] = "ffff";
                UIVariables.Service14_SubFunction.ElementAt(index)[1] = "1";
            }

            // Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService14?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService14?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service14_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService14.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService14?.ElementAt(2).Count; index++)
            {
                UIVariables.Service14_NRCPriority[index] = DatabaseVariables.DatabaseService14.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service14_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service14_EngineStatusCondition = new List<string[]>();
            UIVariables.Service14_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService14?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service14_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService14.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service14_EngineStatusCondition.Add(DatabaseVariables.DatabaseService14.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service14_VoltageCondition.Add(DatabaseVariables.DatabaseService14.ElementAt(3)[index]);
                }
            }
            UIVariables.Service14_InvalidValueCondition = new string[4];
            UIVariables.Service14_ButtonStatus_Condition = new bool[3];
            UIVariables.Service14_NRCCondition = new string[3];
            UIVariables.Service14_InvalidValueCondition[0] = UIVariables.Service14_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service14_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service14_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service14_NRCCondition[0] = UIVariables.Service14_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service14_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service14_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service14_InvalidValueCondition[1] += $"{UIVariables.Service14_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service14_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service14_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service14_ValidValueCondition = UIVariables.Service14_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service14_NRCCondition[1] = UIVariables.Service14_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service14_InvalidValueCondition[1] = UIVariables.Service14_InvalidValueCondition[1].Remove(UIVariables.Service14_InvalidValueCondition[1].Length - 2);
                UIVariables.Service14_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service14_InvalidValueCondition[1] = "";
                UIVariables.Service14_ValidValueCondition = "";
                UIVariables.Service14_ButtonStatus_Condition[1] = false;
                UIVariables.Service14_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service14_VoltageCondition?.Count; index++)
            {
                UIVariables.Service14_InvalidValueCondition[index + 2] = UIVariables.Service14_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service14_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service14_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service14_NRCCondition[2] = UIVariables.Service14_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService14?.ElementAt(4).Count; index++)
            {
                UIVariables.Service14_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService14.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service19()
        {

        }

        public static void UIDefinition_Service22()
        {
            // Specification
            UIVariables.Service22_DIDTable_Specification = new List<string[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService22?.ElementAt(0).Count; index++)
            {
                UIVariables.Service22_DIDTable_Specification.Add(DatabaseVariables.DatabaseService22.ElementAt(0).ElementAt(index));
            }

            // Allow Session & Addressing Mode
            UIVariables.Service22_DIDTable_AllowSessionAddressingMode = new List<bool[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService22?.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService22?.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(1)[index][index_]));
                }
                UIVariables.Service22_DIDTable_AllowSessionAddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService22?.ElementAt(2).Count; index++)
            {
                UIVariables.Service22_NRCPriority[index] = DatabaseVariables.DatabaseService22.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service22_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service22_EngineStatusCondition = new List<string[]>();
            UIVariables.Service22_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService22?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service22_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService22.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service22_EngineStatusCondition.Add(DatabaseVariables.DatabaseService22.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service22_VoltageCondition.Add(DatabaseVariables.DatabaseService22.ElementAt(3)[index]);
                }
            }
            UIVariables.Service22_InvalidValueCondition = new string[4];
            UIVariables.Service22_ButtonStatus_Condition = new bool[3];
            UIVariables.Service22_NRCCondition = new string[3];
            UIVariables.Service22_InvalidValueCondition[0] = UIVariables.Service22_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service22_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service22_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service22_NRCCondition[0] = UIVariables.Service22_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service22_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service22_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service22_InvalidValueCondition[1] += $"{UIVariables.Service22_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service22_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service22_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service22_ValidValueCondition = UIVariables.Service22_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service22_NRCCondition[1] = UIVariables.Service22_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service22_InvalidValueCondition[1] = UIVariables.Service22_InvalidValueCondition[1].Remove(UIVariables.Service22_InvalidValueCondition[1].Length - 2);
                UIVariables.Service22_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service22_InvalidValueCondition[1] = "";
                UIVariables.Service22_ValidValueCondition = "";
                UIVariables.Service22_ButtonStatus_Condition[1] = false;
                UIVariables.Service22_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service22_VoltageCondition?.Count; index++)
            {
                UIVariables.Service22_InvalidValueCondition[index + 2] = UIVariables.Service22_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service22_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service22_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service22_NRCCondition[2] = UIVariables.Service22_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService22?.ElementAt(4).Count; index++)
            {
                UIVariables.Service22_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService22.ElementAt(4)[index][1]);
            }

            // Allow Session
            for (int index = 0; index < UIVariables.Service22_ButtonStatus_AllowSession?.Length; index++)
            {
                UIVariables.Service22_ButtonStatus_AllowSession[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService22.ElementAt(5)[index][1]);
            }
        }

        public static void UIDefinition_Service2E()
        {
            // Specification
            UIVariables.Service2E_DIDTable_Specification = new List<string[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(0).Count; index++)
            {
                UIVariables.Service2E_DIDTable_Specification.Add(DatabaseVariables.DatabaseService2E.ElementAt(0).ElementAt(index));
            }

            // Addressing Mode
            UIVariables.Service2E_DIDTable_AllowSessionAddressingMode = new List<bool[]> { };
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(1).Count; index++)
            {
                List<bool> dataRow = new List<bool>();
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService2E.ElementAt(1)[index].Length; index_++)
                {
                    dataRow.Add(Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(1)[index][index_]));
                }
                UIVariables.Service2E_DIDTable_AllowSessionAddressingMode.Add(dataRow.ToArray());
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(2).Count; index++)
            {
                UIVariables.Service2E_NRCPriority[index] = DatabaseVariables.DatabaseService2E?.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service2E_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service2E_EngineStatusCondition = new List<string[]>();
            UIVariables.Service2E_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service2E_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService2E.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service2E_EngineStatusCondition.Add(DatabaseVariables.DatabaseService2E.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service2E_VoltageCondition.Add(DatabaseVariables.DatabaseService2E.ElementAt(3)[index]);
                }
            }
            UIVariables.Service2E_InvalidValueCondition = new string[4];
            UIVariables.Service2E_ButtonStatus_Condition = new bool[3];
            UIVariables.Service2E_NRCCondition = new string[3];
            UIVariables.Service2E_InvalidValueCondition[0] = UIVariables.Service2E_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service2E_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service2E_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service2E_NRCCondition[0] = UIVariables.Service2E_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service2E_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service2E_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service2E_InvalidValueCondition[1] += $"{UIVariables.Service2E_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service2E_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service2E_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service2E_ValidValueCondition = UIVariables.Service2E_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service2E_NRCCondition[1] = UIVariables.Service2E_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service2E_InvalidValueCondition[1] = UIVariables.Service2E_InvalidValueCondition[1].Remove(UIVariables.Service2E_InvalidValueCondition[1].Length - 2);
                UIVariables.Service2E_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service2E_InvalidValueCondition[1] = "";
                UIVariables.Service2E_ValidValueCondition = "";
                UIVariables.Service2E_ButtonStatus_Condition[1] = false;
                UIVariables.Service2E_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service2E_VoltageCondition?.Count; index++)
            {
                UIVariables.Service2E_InvalidValueCondition[index + 2] = UIVariables.Service2E_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service2E_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service2E_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service2E_NRCCondition[2] = UIVariables.Service2E_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(4).Count; index++)
            {
                UIVariables.Service2E_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService2E.ElementAt(4)[index][1]);
            }
            UIVariables.Service2E_SecurityUnlockLv = DatabaseVariables.DatabaseService2E.ElementAt(4)[1][1];

            // Allow Session
            for (int index = 0; index < UIVariables.Service2E_ButtonStatus_AllowSession?.Length; index++)
            {
                UIVariables.Service2E_ButtonStatus_AllowSession[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(5)[index][1]);
            }
        }

        public static void UIDefinition_Service27()
        {
            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService27?.ElementAt(0).Count; index++)
            {
                UIVariables.Service27_SubFunction.Add(DatabaseVariables.DatabaseService27.ElementAt(0)[index]);
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService27?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService27?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service27_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService27.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService27?.ElementAt(2).Count; index++)
            {
                UIVariables.Service27_NRCPrioritySeed[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][1];
                UIVariables.Service27_NRCPriorityKey[index] = DatabaseVariables.DatabaseService27.ElementAt(2)[index][2];
            }

            // Condition
            UIVariables.Service27_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service27_EngineStatusCondition = new List<string[]>();
            UIVariables.Service27_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService27?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service27_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService27.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service27_EngineStatusCondition.Add(DatabaseVariables.DatabaseService27.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service27_VoltageCondition.Add(DatabaseVariables.DatabaseService27.ElementAt(3)[index]);
                }
            }
            UIVariables.Service27_InvalidValueCondition = new string[4];
            UIVariables.Service27_ButtonStatus_Condition = new bool[3];
            UIVariables.Service27_NRCCondition = new string[3];
            UIVariables.Service27_InvalidValueCondition[0] = UIVariables.Service27_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service27_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service27_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service27_NRCCondition[0] = UIVariables.Service27_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service27_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service27_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service27_InvalidValueCondition[1] += $"{UIVariables.Service27_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service27_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service27_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service27_ValidValueCondition = UIVariables.Service27_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service27_NRCCondition[1] = UIVariables.Service27_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service27_InvalidValueCondition[1] = UIVariables.Service27_InvalidValueCondition[1].Remove(UIVariables.Service27_InvalidValueCondition[1].Length - 2);
                UIVariables.Service27_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service27_InvalidValueCondition[1] = "";
                UIVariables.Service27_ValidValueCondition = "";
                UIVariables.Service27_ButtonStatus_Condition[1] = false;
                UIVariables.Service27_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service27_VoltageCondition?.Count; index++)
            {
                UIVariables.Service27_InvalidValueCondition[index + 2] = UIVariables.Service27_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service27_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service27_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service27_NRCCondition[2] = UIVariables.Service27_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService27?.ElementAt(4).Count; index++)
            {
                UIVariables.Service27_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService27.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service28()
        {
            // Control Type
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_ControlType?.Length; index++)
            {
                UIVariables.Service28_ButtonStatus_ControlType[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(0)[index][1]);
            }

            // Communication Type
            for (int index = 0; index < UIVariables.Service28_ButtonStatus_CommunicationType?.Length; index++)
            {
                UIVariables.Service28_ButtonStatus_CommunicationType[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(0)[index][3]);
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService28?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService28?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service28_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService28.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService28?.ElementAt(2).Count; index++)
            {
                UIVariables.Service28_NRCPriority[index] = DatabaseVariables.DatabaseService28.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service28_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service28_EngineStatusCondition = new List<string[]>();
            UIVariables.Service28_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService28?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service28_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService28.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service28_EngineStatusCondition.Add(DatabaseVariables.DatabaseService28.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service28_VoltageCondition.Add(DatabaseVariables.DatabaseService28.ElementAt(3)[index]);
                }
            }
            UIVariables.Service28_InvalidValueCondition = new string[4];
            UIVariables.Service28_ButtonStatus_Condition = new bool[3];
            UIVariables.Service28_NRCCondition = new string[3];
            UIVariables.Service28_InvalidValueCondition[0] = UIVariables.Service28_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service28_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service28_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service28_NRCCondition[0] = UIVariables.Service28_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service28_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service28_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service28_InvalidValueCondition[1] += $"{UIVariables.Service28_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service28_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service28_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service28_ValidValueCondition = UIVariables.Service28_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service28_NRCCondition[1] = UIVariables.Service28_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service28_InvalidValueCondition[1] = UIVariables.Service28_InvalidValueCondition[1].Remove(UIVariables.Service28_InvalidValueCondition[1].Length - 2);
                UIVariables.Service28_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service28_InvalidValueCondition[1] = "";
                UIVariables.Service28_ValidValueCondition = "";
                UIVariables.Service28_ButtonStatus_Condition[1] = false;
                UIVariables.Service28_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service28_VoltageCondition?.Count; index++)
            {
                UIVariables.Service28_InvalidValueCondition[index + 2] = UIVariables.Service28_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service28_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service28_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service28_NRCCondition[2] = UIVariables.Service28_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService28?.ElementAt(4).Count; index++)
            {
                UIVariables.Service28_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService28.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service3E()
        {
            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService3E?.ElementAt(0).Count; index++)
            {
                UIVariables.Service3E_SubFunction.Add(DatabaseVariables.DatabaseService3E.ElementAt(0)[index]);
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService3E?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService3E?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service3E_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService3E.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService3E?.ElementAt(2).Count; index++)
            {
                UIVariables.Service3E_NRCPriority[index] = DatabaseVariables.DatabaseService3E.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service3E_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service3E_EngineStatusCondition = new List<string[]>();
            UIVariables.Service3E_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService3E?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service3E_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService3E.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service3E_EngineStatusCondition.Add(DatabaseVariables.DatabaseService3E.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service3E_VoltageCondition.Add(DatabaseVariables.DatabaseService3E.ElementAt(3)[index]);
                }
            }
            UIVariables.Service3E_InvalidValueCondition = new string[4];
            UIVariables.Service3E_ButtonStatus_Condition = new bool[3];
            UIVariables.Service3E_NRCCondition = new string[3];
            UIVariables.Service3E_InvalidValueCondition[0] = UIVariables.Service3E_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service3E_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service3E_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service3E_NRCCondition[0] = UIVariables.Service3E_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service3E_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service3E_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service3E_InvalidValueCondition[1] += $"{UIVariables.Service3E_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service3E_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service3E_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service3E_ValidValueCondition = UIVariables.Service3E_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service3E_NRCCondition[1] = UIVariables.Service3E_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service3E_InvalidValueCondition[1] = UIVariables.Service3E_InvalidValueCondition[1].Remove(UIVariables.Service3E_InvalidValueCondition[1].Length - 2);
                UIVariables.Service3E_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service3E_InvalidValueCondition[1] = "";
                UIVariables.Service3E_ValidValueCondition = "";
                UIVariables.Service3E_ButtonStatus_Condition[1] = false;
                UIVariables.Service3E_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service3E_VoltageCondition?.Count; index++)
            {
                UIVariables.Service3E_InvalidValueCondition[index + 2] = UIVariables.Service3E_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service3E_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service3E_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service3E_NRCCondition[2] = UIVariables.Service3E_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService3E?.ElementAt(4).Count; index++)
            {
                UIVariables.Service3E_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService3E.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service85()
        {
            // Specification
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(0).Count; index++)
            {
                UIVariables.Service85_SubFunction.Add(DatabaseVariables.DatabaseService85.ElementAt(0)[index]);
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService85?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service85_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService85.ElementAt(1)[index][index_ + 1]);
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(2).Count; index++)
            {
                UIVariables.Service85_NRCPriority[index] = DatabaseVariables.DatabaseService85.ElementAt(2)[index][1];
            }

            // Condition
            UIVariables.Service85_VehicleSpeedCondition = new List<string[]>();
            UIVariables.Service85_EngineStatusCondition = new List<string[]>();
            UIVariables.Service85_VoltageCondition = new List<string[]>();
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(3).Count; index++)
            {
                if (DatabaseVariables.DatabaseService85.ElementAt(3)[index][0] == "Vehicle_Speed")
                {
                    UIVariables.Service85_VehicleSpeedCondition.Add(DatabaseVariables.DatabaseService85.ElementAt(3)[index]);
                }
                else if (DatabaseVariables.DatabaseService85.ElementAt(3)[index][0] == "Engine_Status")
                {
                    UIVariables.Service85_EngineStatusCondition.Add(DatabaseVariables.DatabaseService85.ElementAt(3)[index]);
                }
                else
                {
                    UIVariables.Service85_VoltageCondition.Add(DatabaseVariables.DatabaseService85.ElementAt(3)[index]);
                }
            }
            UIVariables.Service85_InvalidValueCondition = new string[4];
            UIVariables.Service85_ButtonStatus_Condition = new bool[3];
            UIVariables.Service85_NRCCondition = new string[3];
            UIVariables.Service85_InvalidValueCondition[0] = UIVariables.Service85_VehicleSpeedCondition.ElementAt(0)[1];
            UIVariables.Service85_ButtonStatus_Condition[0] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service85_VehicleSpeedCondition.ElementAt(0)[3]);
            UIVariables.Service85_NRCCondition[0] = UIVariables.Service85_VehicleSpeedCondition.ElementAt(0)[4];
            if (UIVariables.Service85_EngineStatusCondition.Count > 1)
            {
                for (int index = 0; index < UIVariables.Service85_EngineStatusCondition?.Count; index++)
                {
                    UIVariables.Service85_InvalidValueCondition[1] += $"{UIVariables.Service85_EngineStatusCondition.ElementAt(index)[1]}({UIVariables.Service85_EngineStatusCondition.ElementAt(index)[2]}); ";
                    if (UIVariables.Service85_EngineStatusCondition.ElementAt(index)[3] == "0")
                    {
                        UIVariables.Service85_ValidValueCondition = UIVariables.Service85_EngineStatusCondition.ElementAt(index)[1];
                    }
                    else
                    {
                        UIVariables.Service85_NRCCondition[1] = UIVariables.Service85_EngineStatusCondition.ElementAt(index)[4];
                    }
                }
                UIVariables.Service85_InvalidValueCondition[1] = UIVariables.Service85_InvalidValueCondition[1].Remove(UIVariables.Service85_InvalidValueCondition[1].Length - 2);
                UIVariables.Service85_ButtonStatus_Condition[1] = true;
            }
            else
            {
                UIVariables.Service85_InvalidValueCondition[1] = "";
                UIVariables.Service85_ValidValueCondition = "";
                UIVariables.Service85_ButtonStatus_Condition[1] = false;
                UIVariables.Service85_NRCCondition[1] = "";
            }
            for (int index = 0; index < UIVariables.Service85_VoltageCondition?.Count; index++)
            {
                UIVariables.Service85_InvalidValueCondition[index + 2] = UIVariables.Service85_VoltageCondition.ElementAt(index)[1];
                UIVariables.Service85_ButtonStatus_Condition[2] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.Service85_VoltageCondition.ElementAt(index)[3]);
                UIVariables.Service85_NRCCondition[2] = UIVariables.Service85_VoltageCondition.ElementAt(index)[4];
            }

            // Optional
            for (int index = 0; index < DatabaseVariables.DatabaseService85?.ElementAt(4).Count; index++)
            {
                UIVariables.Service85_ButtonStatus_Optional[index] = Controller_ServiceHandling.ConvertFromStringOptionalToBool(DatabaseVariables.DatabaseService85.ElementAt(4)[index][1]);
            }
        }

        public static void UIDefinition_Service31()
        {

        }

        public static void UIDefinition_CanTP()
        {

        }
    }
}
