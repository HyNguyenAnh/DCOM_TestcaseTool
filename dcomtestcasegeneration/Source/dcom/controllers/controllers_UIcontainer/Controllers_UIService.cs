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
        // Definite data from database to UI
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
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService10.ElementAt(1).Count - 3; index++)
            {
                for (int index_ = 1; index_ < DatabaseVariables.DatabaseService10.ElementAt(1)[index].Length; index_++)
                {
                    UIVariables.Service10_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[index][index_]);
                    n++;
                }
            }

            // Session Transition
            n = 0;
            for (int index = 2; index < DatabaseVariables.DatabaseService10.ElementAt(1).Count; index++)
            {
                for (int index_ = 1; index_ < DatabaseVariables.DatabaseService10.ElementAt(1)[index].Length; index_++)
                {
                    UIVariables.Service10_ButtonStatus_SessionTransition[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService10.ElementAt(1)[index][index_]);
                    n++;
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
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(0)?.Count; index++)
            {
                UIVariables.Service11_ButtonStatus_ResetMode[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11.ElementAt(0)[index][1]);
            }

            // Addressing Mode
            int n = 0;
            for (int index = 0; index < DatabaseVariables.DatabaseService11?.ElementAt(1).Count; index++)
            {
                for (int index_ = 0; index_ < DatabaseVariables.DatabaseService11?.ElementAt(1)[index].Length - 1; index_++)
                {
                    UIVariables.Service11_ButtonStatus_AddressingMode[n] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService11?.ElementAt(1)[index][index_ + 1]);
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
            for (int index = 0; index < DatabaseVariables.DatabaseService2E?.ElementAt(5).Count; index++)
            {
                UIVariables.Service2E_ButtonStatus_AllowSession[index] = Controller_ServiceHandling.ConvertFromStringToBool(DatabaseVariables.DatabaseService2E.ElementAt(5)[index][1]);
            }
        }

        public static void UIDefinition_Service27()
        {
            // Specification
            UIVariables.Service27_SubFunction = new List<string[]>();
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
            UIVariables.Service3E_SubFunction = new List<string[]>();
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
            UIVariables.Service85_SubFunction = new List<string[]>();
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

        // Update data of database from UI

        public static void UpdateDB_Service10(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service10_SubFunction?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service10_SubFunction?.ElementAt(index).Count(); index_++)
                    {
                        DatabaseVariables.DatabaseService10.ElementAt(0)[index][index_] = UIVariables.Service10_SubFunction.ElementAt(index)[index_];
                    }
                }

                // Allow session & Addressing mode
                int n = 0;
                for (int index = 0; index < 5; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        if (index < 2)
                        {
                            status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_AddressingMode[n]);
                            DatabaseVariables.DatabaseService10.ElementAt(1)[index][index_ + 1] = status;
                            n++;
                            if ((index == 1) && (index_ == 2))
                            {
                                n = 0;
                            }
                        }
                        else
                        {
                            status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_SessionTransition[n]);
                            DatabaseVariables.DatabaseService10.ElementAt(1)[index][index_ + 1] = status;
                            n++;
                        }
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service10_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService10.ElementAt(2)[index][1] = UIVariables.Service10_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService10.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service10_InvalidValueCondition[1].Contains(UIVariables.Service10_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service10_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service10_InvalidValueCondition[1], "; " + UIVariables.Service10_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][1] = UIVariables.Service10_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][4] = UIVariables.Service10_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_][4] = UIVariables.Service10_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService10.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service10_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service10_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService10.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService10.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service10_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService10.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[1] = false;
            }
        }

        public static void UpdateDB_Service11(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service11_ButtonStatus_ResetMode?.Count(); index++)
                {
                    DatabaseVariables.DatabaseService11.ElementAt(0)[index][1] = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_ResetMode[index]);
                }

                // Allow session & Addressing mode
                int n = 0;
                for (int index = 0; index < 2; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_AddressingMode[n]);
                        DatabaseVariables.DatabaseService11.ElementAt(1)[index][index_ + 1] = status;
                        n++;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service11_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService11.ElementAt(2)[index][1] = UIVariables.Service11_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService11.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service11_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service11_InvalidValueCondition[1].Contains(UIVariables.Service11_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service11_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service11_InvalidValueCondition[1], "; " + UIVariables.Service11_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][1] = UIVariables.Service11_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][4] = UIVariables.Service11_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_][4] = UIVariables.Service11_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService11.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service11_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service11_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService11.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService11.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service11_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service11_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService11.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[2] = false;
            }
        }

        public static void UpdateDB_Service14(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service14_SubFunction?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service14_SubFunction?.ElementAt(index).Count(); index_++)
                    {
                        DatabaseVariables.DatabaseService14.ElementAt(0)[index][index_] = UIVariables.Service14_SubFunction.ElementAt(index)[index_];
                    }
                }

                // Allow session & Addressing mode
                int n = 0;
                for (int index = 0; index < 2; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service14_ButtonStatus_AddressingMode[n]);
                        DatabaseVariables.DatabaseService14.ElementAt(1)[index][index_ + 1] = status;
                        n++;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service14_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService14.ElementAt(2)[index][1] = UIVariables.Service14_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService14.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service14_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service14_InvalidValueCondition[1].Contains(UIVariables.Service14_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service14_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service14_InvalidValueCondition[1], "; " + UIVariables.Service14_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service14_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][1] = UIVariables.Service14_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][4] = UIVariables.Service14_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_][4] = UIVariables.Service14_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService14.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service14_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service14_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService14.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService14.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service14_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service14_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService14.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[3] = false;
            }
        }

        //public static void UpdateDB_Service19(bool flag)
        //{
        //    string status;

        //    // Specification
        //    for (int index = 0; index < UIVariables.Service19_SubFunction?.Count(); index++)
        //    {
        //        for (int index_ = 0; index_ < UIVariables.Service19_SubFunction?.ElementAt(index).Count(); index_++)
        //        {
        //            DatabaseVariables.DatabaseService19.ElementAt(0)[index][index_] = UIVariables.Service19_SubFunction.ElementAt(index)[index_];
        //        }
        //    }

        //    // Allow session & Addressing mode
        //    int n = 0;
        //    for (int index = 0; index < 5; index++)
        //    {
        //        for (int index_ = 0; index_ < 3; index_++)
        //        {
        //            if (index < 2)
        //            {
        //                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service19_ButtonStatus_AddressingMode[n]);
        //                DatabaseVariables.DatabaseService19.ElementAt(1)[index][index_ + 1] = status;
        //                n++;
        //                if ((index == 1) && (index_ == 2))
        //                {
        //                    n = 0;
        //                }
        //            }
        //            else
        //            {
        //                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service19_ButtonStatus_SessionTransition[n]);
        //                DatabaseVariables.DatabaseService19.ElementAt(1)[index][index_ + 1] = status;
        //                n++;
        //            }
        //        }
        //    }

        //    // NRC
        //    for (int index = 0; index < UIVariables.Service19_NRCPriority?.Length; index++)
        //    {
        //        DatabaseVariables.DatabaseService19.ElementAt(2)[index][1] = UIVariables.Service19_NRCPriority[index];
        //    }


        //    // Condition
        //    for (int index = 0; index < UIVariables.Service19_ButtonStatus_Condition?.Length; index++)
        //    {
        //        string condition = "";
        //        switch (index)
        //        {
        //            case 0: condition = "Vehicle_Speed"; break;
        //            case 1: condition = "Engine_Status"; break;
        //            case 2: condition = "Voltage"; break;
        //        }
        //        string[] engineStatusConditionSplit;
        //        if (UIVariables.Service19_InvalidValueCondition[1].Contains(UIVariables.Service19_ValidValueCondition))
        //        {
        //            engineStatusConditionSplit = UIVariables.Service19_InvalidValueCondition[1].Split(';');
        //        }
        //        else
        //        {
        //            engineStatusConditionSplit = string.Concat(UIVariables.Service19_InvalidValueCondition[1], "; " + UIVariables.Service19_ValidValueCondition).Split(';');
        //        }
        //        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service19_ButtonStatus_Condition[index]);

        //        if (index == 0 && status == "1")
        //        {
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][0] = condition;
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][1] = UIVariables.Service19_InvalidValueCondition[index];
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][3] = status;
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][4] = UIVariables.Service19_NRCCondition[index];
        //        }
        //        else if (index == 1 && status == "1")
        //        {
        //            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
        //            {
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index][0] = condition;
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
        //                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
        //                {
        //                    DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_][3] = status;
        //                    DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_][4] = UIVariables.Service19_NRCCondition[index];
        //                }
        //                else
        //                {
        //                    DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_][3] = "0";
        //                    DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_][4] = "";
        //                }
        //            }
        //        }
        //        else if (index == 2 && status == "1")
        //        {
        //            for (int index_ = 0; index_ < 2; index_++)
        //            {
        //                string voltageName = "";
        //                switch (index_)
        //                {
        //                    case 0: voltageName = "Low"; break;
        //                    case 1: voltageName = "High"; break;
        //                }
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service19_InvalidValueCondition[index + index_];
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = status;
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service19_NRCCondition[index];
        //            }
        //        }
        //        else
        //        {
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][0] = condition;
        //            DatabaseVariables.DatabaseService19.ElementAt(3)[index][3] = status;
        //            if (index == UIVariables.Service19_ButtonStatus_Condition?.Length - 1)
        //            {
        //                DatabaseVariables.DatabaseService19.ElementAt(3)[index + 1][3] = status;
        //            }
        //        }
        //    }

        //    // Optional
        //    for (int index = 0; index < UIVariables.Service19_ButtonStatus_Optional.Length; index++)
        //    {
        //        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service19_ButtonStatus_Optional[index]);
        //        DatabaseVariables.DatabaseService19.ElementAt(4)[index][1] = status;
        //    }
        //}

        public static void UpdateDB_Service22(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service22_DIDTable_Specification?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service22_DIDTable_Specification?.ElementAt(index).Count(); index_++)
                    {
                        status = UIVariables.Service22_DIDTable_Specification[index][index_];
                        DatabaseVariables.DatabaseService22.ElementAt(0)[index][index_] = status;
                    }
                }

                // Allow Session & Addressing Mode
                for (int index = 0; index < UIVariables.Service22_DIDTable_AllowSessionAddressingMode?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service22_DIDTable_AllowSessionAddressingMode?.ElementAt(index).Length; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_DIDTable_AllowSessionAddressingMode[index][index_]);
                        DatabaseVariables.DatabaseService22.ElementAt(1)[index][index_] = status;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service22_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService22.ElementAt(2)[index][1] = UIVariables.Service22_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService22.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service22_InvalidValueCondition[1].Contains(UIVariables.Service22_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service22_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service22_InvalidValueCondition[1], "; " + UIVariables.Service22_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][1] = UIVariables.Service22_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][4] = UIVariables.Service22_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_][4] = UIVariables.Service22_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService22.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service22_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service22_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService22.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService22.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService22.ElementAt(4)[index][1] = status;
                }

                // Allow Session
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_AllowSession?.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_AllowSession[index]);
                    DatabaseVariables.DatabaseService22.ElementAt(5)[index][1] = status;
                }

                //UIVariables.edited_View[5] = false;
            }
        }

        public static void UpdateDB_Service2E(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service2E_DIDTable_Specification?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service2E_DIDTable_Specification?.ElementAt(index).Count(); index_++)
                    {
                        status = UIVariables.Service2E_DIDTable_Specification[index][index_];
                        DatabaseVariables.DatabaseService2E.ElementAt(0)[index][index_] = status;
                    }
                }

                // Allow session & Addressing Mode
                for (int index = 0; index < UIVariables.Service2E_DIDTable_AllowSessionAddressingMode?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service2E_DIDTable_AllowSessionAddressingMode?.ElementAt(index).Length; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service2E_DIDTable_AllowSessionAddressingMode[index][index_]);
                        DatabaseVariables.DatabaseService2E.ElementAt(1)[index][index_] = status;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service2E_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService2E.ElementAt(2)[index][1] = UIVariables.Service2E_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService2E.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service2E_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service2E_InvalidValueCondition[1].Contains(UIVariables.Service2E_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service2E_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service2E_InvalidValueCondition[1], "; " + UIVariables.Service2E_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service2E_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1] = UIVariables.Service2E_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][4] = UIVariables.Service2E_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_][4] = UIVariables.Service2E_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService2E.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service2E_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service2E_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService2E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService2E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service2E_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service2E_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService2E.ElementAt(4)[index][1] = status;
                }

                // Allow Session (SID support)
                for (int index = 0; index < UIVariables.Service2E_ButtonStatus_AllowSession?.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service2E_ButtonStatus_AllowSession[index]);
                    DatabaseVariables.DatabaseService2E.ElementAt(5)[index][1] = status;
                }

                //UIVariables.edited_View[6] = false;
            }
        }

        public static void UpdateDB_Service27(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service27_SubFunction?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service27_SubFunction?.ElementAt(index).Count(); index_++)
                    {
                        DatabaseVariables.DatabaseService27.ElementAt(0)[index][index_] = UIVariables.Service27_SubFunction.ElementAt(index)[index_];
                    }
                }

                // Allow Session || Addressing Mode
                int n = 0;
                for (int index = 0; index < 2; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_AddressingMode[n]);
                        DatabaseVariables.DatabaseService27.ElementAt(1)[index][index_ + 1] = status;
                        n++;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service27_NRCPrioritySeed?.Length; index++)
                {
                    DatabaseVariables.DatabaseService27.ElementAt(2)[index][1] = UIVariables.Service27_NRCPrioritySeed[index];
                }
                for (int index = 0; index < UIVariables.Service27_NRCPriorityKey?.Length; index++)
                {
                    DatabaseVariables.DatabaseService27.ElementAt(2)[index][2] = UIVariables.Service27_NRCPriorityKey[index];
                }

                // Condition
                DatabaseVariables.DatabaseService27.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service27_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service27_InvalidValueCondition[1].Contains(UIVariables.Service27_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service27_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service27_InvalidValueCondition[1], "; " + UIVariables.Service27_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][1] = UIVariables.Service27_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][4] = UIVariables.Service27_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_][4] = UIVariables.Service27_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService27.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service27_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service27_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService27.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService27.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service27_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService27.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[7] = false;
            }
        }

        public static void UpdateDB_Service28(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service28_ButtonStatus_ControlType?.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service28_ButtonStatus_ControlType[index]);
                    DatabaseVariables.DatabaseService28.ElementAt(0)[index][1] = status;
                }
                for (int index = 0; index < UIVariables.Service28_ButtonStatus_CommunicationType?.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service28_ButtonStatus_CommunicationType[index]);
                    DatabaseVariables.DatabaseService28.ElementAt(0)[index][3] = status;
                }

                // Allow session & Addressing mode
                int n = 0;
                for (int index = 0; index < 2; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service28_ButtonStatus_AddressingMode[n]);
                        DatabaseVariables.DatabaseService28.ElementAt(1)[index][index_ + 1] = status;
                        n++;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service28_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService28.ElementAt(2)[index][1] = UIVariables.Service28_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService28.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service28_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service28_InvalidValueCondition[1].Contains(UIVariables.Service28_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service28_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service28_InvalidValueCondition[1], "; " + UIVariables.Service28_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service28_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][1] = UIVariables.Service28_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][4] = UIVariables.Service28_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_][4] = UIVariables.Service28_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService28.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service28_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service28_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService28.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService28.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service28_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service28_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService28.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[8] = false;
            }
        }

        //public static void UpdateDB_Service31(bool flag)
        //{
        //    string status;

        //    // Specification
        //    for (int index = 0; index < UIVariables.Service31_SubFunction?.Count(); index++)
        //    {
        //        for (int index_ = 0; index_ < UIVariables.Service31_SubFunction?.ElementAt(index).Count(); index_++)
        //        {
        //            DatabaseVariables.DatabaseService31.ElementAt(0)[index][index_] = UIVariables.Service31_SubFunction.ElementAt(index)[index_];
        //        }
        //    }

        //    // Allow session & Addressing mode
        //    int n = 0;
        //    for (int index = 0; index < 5; index++)
        //    {
        //        for (int index_ = 0; index_ < 3; index_++)
        //        {
        //            if (index < 2)
        //            {
        //                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service31_ButtonStatus_AddressingMode[n]);
        //                DatabaseVariables.DatabaseService31.ElementAt(1)[index][index_ + 1] = status;
        //                n++;
        //                if ((index == 1) && (index_ == 2))
        //                {
        //                    n = 0;
        //                }
        //            }
        //            else
        //            {
        //                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service31_ButtonStatus_SessionTransition[n]);
        //                DatabaseVariables.DatabaseService31.ElementAt(1)[index][index_ + 1] = status;
        //                n++;
        //            }
        //        }
        //    }

        //    // NRC
        //    for (int index = 0; index < UIVariables.Service31_NRCPriority?.Length; index++)
        //    {
        //        DatabaseVariables.DatabaseService31.ElementAt(2)[index][1] = UIVariables.Service31_NRCPriority[index];
        //    }


        //    // Condition
        //    for (int index = 0; index < UIVariables.Service31_ButtonStatus_Condition?.Length; index++)
        //    {
        //        string condition = "";
        //        switch (index)
        //        {
        //            case 0: condition = "Vehicle_Speed"; break;
        //            case 1: condition = "Engine_Status"; break;
        //            case 2: condition = "Voltage"; break;
        //        }
        //        string[] engineStatusConditionSplit;
        //        if (UIVariables.Service31_InvalidValueCondition[1].Contains(UIVariables.Service31_ValidValueCondition))
        //        {
        //            engineStatusConditionSplit = UIVariables.Service31_InvalidValueCondition[1].Split(';');
        //        }
        //        else
        //        {
        //            engineStatusConditionSplit = string.Concat(UIVariables.Service31_InvalidValueCondition[1], "; " + UIVariables.Service31_ValidValueCondition).Split(';');
        //        }
        //        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service31_ButtonStatus_Condition[index]);

        //        if (index == 0 && status == "1")
        //        {
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][0] = condition;
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][1] = UIVariables.Service31_InvalidValueCondition[index];
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][3] = status;
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][4] = UIVariables.Service31_NRCCondition[index];
        //        }
        //        else if (index == 1 && status == "1")
        //        {
        //            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
        //            {
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index][0] = condition;
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
        //                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
        //                {
        //                    DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_][3] = status;
        //                    DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_][4] = UIVariables.Service31_NRCCondition[index];
        //                }
        //                else
        //                {
        //                    DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_][3] = "0";
        //                    DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_][4] = "";
        //                }
        //            }
        //        }
        //        else if (index == 2 && status == "1")
        //        {
        //            for (int index_ = 0; index_ < 2; index_++)
        //            {
        //                string voltageName = "";
        //                switch (index_)
        //                {
        //                    case 0: voltageName = "Low"; break;
        //                    case 1: voltageName = "High"; break;
        //                }
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service31_InvalidValueCondition[index + index_];
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = status;
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service31_NRCCondition[index];
        //            }
        //        }
        //        else
        //        {
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][0] = condition;
        //            DatabaseVariables.DatabaseService31.ElementAt(3)[index][3] = status;
        //            if (index == UIVariables.Service31_ButtonStatus_Condition?.Length - 1)
        //            {
        //                DatabaseVariables.DatabaseService31.ElementAt(3)[index + 1][3] = status;
        //            }
        //        }
        //    }

        //    // Optional
        //    for (int index = 0; index < UIVariables.Service31_ButtonStatus_Optional.Length; index++)
        //    {
        //        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service31_ButtonStatus_Optional[index]);
        //        DatabaseVariables.DatabaseService31.ElementAt(4)[index][1] = status;
        //    }
        //}

        public static void UpdateDB_Service85(bool flag)
        {
            string status;

            // Specification
            for (int index = 0; index < UIVariables.Service85_SubFunction?.Count(); index++)
            {
                for (int index_ = 0; index_ < UIVariables.Service85_SubFunction?.ElementAt(index).Count(); index_++)
                {
                    DatabaseVariables.DatabaseService85.ElementAt(0)[index][index_] = UIVariables.Service85_SubFunction.ElementAt(index)[index_];
                }
            }

            // Allow session & Addressing mode
            int n = 0;
            for (int index = 0; index < 5; index++)
            {
                for (int index_ = 0; index_ < 3; index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_AddressingMode[n]);
                    DatabaseVariables.DatabaseService85.ElementAt(1)[index][index_ + 1] = status;
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service85_NRCPriority?.Length; index++)
            {
                DatabaseVariables.DatabaseService85.ElementAt(2)[index][1] = UIVariables.Service85_NRCPriority[index];
            }


            // Condition
            for (int index = 0; index < UIVariables.Service85_ButtonStatus_Condition?.Length; index++)
            {
                string condition = "";
                switch (index)
                {
                    case 0: condition = "Vehicle_Speed"; break;
                    case 1: condition = "Engine_Status"; break;
                    case 2: condition = "Voltage"; break;
                }
                string[] engineStatusConditionSplit;
                if (UIVariables.Service85_InvalidValueCondition[1].Contains(UIVariables.Service85_ValidValueCondition))
                {
                    engineStatusConditionSplit = UIVariables.Service85_InvalidValueCondition[1].Split(';');
                }
                else
                {
                    engineStatusConditionSplit = string.Concat(UIVariables.Service85_InvalidValueCondition[1], "; " + UIVariables.Service85_ValidValueCondition).Split(';');
                }
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_Condition[index]);

                if (index == 0 && status == "1")
                {
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][0] = condition;
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][1] = UIVariables.Service85_InvalidValueCondition[index];
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][3] = status;
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][4] = UIVariables.Service85_NRCCondition[index];
                }
                else if (index == 1 && status == "1")
                {
                    for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                    {
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index][0] = condition;
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                        if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                        {
                            DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_][3] = status;
                            DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_][4] = UIVariables.Service85_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_][3] = "0";
                            DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_][4] = "";
                        }
                    }
                }
                else if (index == 2 && status == "1")
                {
                    for (int index_ = 0; index_ < 2; index_++)
                    {
                        string voltageName = "";
                        switch (index_)
                        {
                            case 0: voltageName = "Low"; break;
                            case 1: voltageName = "High"; break;
                        }
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service85_InvalidValueCondition[index + index_];
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = status;
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service85_NRCCondition[index];
                    }
                }
                else
                {
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][0] = condition;
                    DatabaseVariables.DatabaseService85.ElementAt(3)[index][3] = status;
                    if (index == UIVariables.Service85_ButtonStatus_Condition?.Length - 1)
                    {
                        DatabaseVariables.DatabaseService85.ElementAt(3)[index + 1][3] = status;
                    }
                }
            }

            // Optional
            for (int index = 0; index < UIVariables.Service85_ButtonStatus_Optional.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service85_ButtonStatus_Optional[index]);
                DatabaseVariables.DatabaseService85.ElementAt(4)[index][1] = status;
            }
        }

        public static void UpdateDB_Service3E(bool flag)
        {
            if (flag)
            {
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service3E_SubFunction?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service3E_SubFunction?.ElementAt(index).Count(); index_++)
                    {
                        DatabaseVariables.DatabaseService3E.ElementAt(0)[index][index_] = UIVariables.Service3E_SubFunction.ElementAt(index)[index_];
                    }
                }

                // Allow session & Addressing mode
                int n = 0;
                for (int index = 0; index < 2; index++)
                {
                    for (int index_ = 0; index_ < 3; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service3E_ButtonStatus_AddressingMode[n]);
                        DatabaseVariables.DatabaseService3E.ElementAt(1)[index][index_ + 1] = status;
                        n++;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service3E_NRCPriority?.Length; index++)
                {
                    DatabaseVariables.DatabaseService3E.ElementAt(2)[index][1] = UIVariables.Service3E_NRCPriority[index];
                }


                // Condition
                DatabaseVariables.DatabaseService3E.ElementAt(3).Clear();
                for (int index = 0; index < UIVariables.Service3E_ButtonStatus_Condition?.Length; index++)
                {
                    string[] empty = new string[5];
                    string condition = "";
                    switch (index)
                    {
                        case 0: condition = "Vehicle_Speed"; break;
                        case 1: condition = "Engine_Status"; break;
                        case 2: condition = "Voltage"; break;
                    }
                    string[] engineStatusConditionSplit;
                    if (UIVariables.Service3E_InvalidValueCondition[1].Contains(UIVariables.Service3E_ValidValueCondition))
                    {
                        engineStatusConditionSplit = UIVariables.Service3E_InvalidValueCondition[1].Split(';');
                    }
                    else
                    {
                        engineStatusConditionSplit = string.Concat(UIVariables.Service3E_InvalidValueCondition[1], "; " + UIVariables.Service3E_ValidValueCondition).Split(';');
                    }
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service3E_ButtonStatus_Condition[index]);

                    if (index == 0)
                    {
                        if (status == "1")
                        {
                            DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][1] = UIVariables.Service3E_InvalidValueCondition[index];
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][4] = UIVariables.Service3E_NRCCondition[index];
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][1] = "";
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] = condition;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index][1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index][2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_][3] = status;
                                    DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_][4] = UIVariables.Service3E_NRCCondition[index];
                                }
                                else
                                {
                                    DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_][3] = "0";
                                    DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_][4] = "";
                                }
                            }
                        }
                        else
                        {
                            DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][0] = condition;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][1] = "0";
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][2] = "Stop";
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][3] = status;
                            DatabaseVariables.DatabaseService3E.ElementAt(3)[index][4] = "";
                        }
                    }
                    else
                    {
                        for (int index_ = 0; index_ < 2; index_++)
                        {
                            string voltageName = "";
                            switch (index_)
                            {
                                case 0: voltageName = "Low"; break;
                                case 1: voltageName = "High"; break;
                            }

                            if (status == "1")
                            {
                                DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = UIVariables.Service3E_InvalidValueCondition[index + index_];
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][4] = UIVariables.Service3E_NRCCondition[index];
                            }
                            else
                            {
                                DatabaseVariables.DatabaseService3E.ElementAt(3).Add(empty);
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][0] = condition;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][2] = voltageName;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][3] = status;
                                DatabaseVariables.DatabaseService3E.ElementAt(3)[index + index_ + engineStatusConditionSplit.Length - 1][1] = "";
                            }
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service3E_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service3E_ButtonStatus_Optional[index]);
                    DatabaseVariables.DatabaseService3E.ElementAt(4)[index][1] = status;
                }

                //UIVariables.edited_View[10] = false;
            }
        }

    }
}
