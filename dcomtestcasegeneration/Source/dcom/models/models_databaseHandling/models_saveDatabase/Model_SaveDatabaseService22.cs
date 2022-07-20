using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_databaseHandling.models_saveDatabase
{
    class Model_SaveDatabaseService22
    {
        public static void SaveDatabaseService22(Worksheet Ws, bool edited)
        {
            if (edited)
            {
                int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
                int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service22_DIDTable_Specification?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service22_DIDTable_Specification?.ElementAt(index).Length; index_++)
                    {
                        status = UIVariables.Service22_DIDTable_Specification[index][index_];
                        Ws.Cells[rowIndex[5] + index, columnIndex[5] + index_] = status;
                    }
                }

                // Allow Session & Addressing Mode
                for (int index = 0; index < UIVariables.Service22_DIDTable_AllowSessionAddressingMode?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service22_DIDTable_AllowSessionAddressingMode?.ElementAt(index).Length; index_++)
                    {
                        status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_DIDTable_AllowSessionAddressingMode[index][index_]);
                        Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_] = status;
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service22_NRCPriority?.Length; index++)
                {
                    Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = UIVariables.Service22_NRCPriority[index];
                }

                // Condition
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_Condition?.Length; index++)
                {
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
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 0] = condition;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = UIVariables.Service22_InvalidValueCondition[index];
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = UIVariables.Service22_NRCCondition[index];
                        }
                        else
                        {
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 0] = condition;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = "";
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = "";
                        }
                    }
                    else if (index == 1)
                    {
                        if (status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 0] = condition;
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 3] = status;
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 4] = UIVariables.Service22_NRCCondition[index];
                                }
                                else
                                {
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 3] = "0";
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 4] = "";
                                }
                            }
                        }
                        else
                        {
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 0] = condition;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = "0";
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 2] = "Stop";
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = "";
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
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 0] = condition;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 1] = UIVariables.Service22_InvalidValueCondition[index + index_];
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 2] = voltageName;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 3] = status;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 4] = UIVariables.Service22_NRCCondition[index];
                            }
                            else
                            {
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 0] = condition;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 1] = "";
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 2] = voltageName;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 3] = status;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 4] = "";
                            }
                        }
                        for (int index_ = 0; index_ < 5; index_++)
                        {
                            Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length + 1, columnIndex[8] + 0] = "";
                            Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length + 1, columnIndex[8] + 1] = "";
                            Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length + 1, columnIndex[8] + 2] = "";
                            Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length + 1, columnIndex[8] + 3] = "";
                            Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length + 1, columnIndex[8] + 4] = "";
                        }
                    }
                }

                // Optional
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service14_ButtonStatus_Optional[index]);
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 2] = status;
                }

                // Allow Session
                for (int index = 0; index < UIVariables.Service22_ButtonStatus_AllowSession?.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service22_ButtonStatus_AllowSession[index]);
                    Ws.Cells[rowIndex[10] + index, columnIndex[10] + 1] = status;
                }
            }
        }
    }
}
