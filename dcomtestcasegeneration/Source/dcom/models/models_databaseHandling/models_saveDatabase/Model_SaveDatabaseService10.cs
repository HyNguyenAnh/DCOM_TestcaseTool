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
    class Model_SaveDatabaseService10
    {
        public static void SaveDatabaseService10(Worksheet Ws, bool edited)
        {
            if (edited)
            {
                int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
                int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
                string status;

                // Specification
                for (int index = 0; index < UIVariables.Service10_SubFunction?.Count(); index++)
                {
                    for (int index_ = 0; index_ < UIVariables.Service10_SubFunction?.ElementAt(index).Count(); index_++)
                    {
                        Ws.Cells[rowIndex[5] + index, columnIndex[5] + index_] = UIVariables.Service10_SubFunction.ElementAt(index)[index_];
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
                            Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_ + 1] = status;
                            n++;
                            if ((index == 1) && (index_ == 2))
                            {
                                n = 0;
                            }
                        }
                        else
                        {
                            status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_SessionTransition[n]);
                            Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_ + 1] = status;
                            n++;
                        }
                    }
                }

                // NRC
                for (int index = 0; index < UIVariables.Service10_NRCPriority?.Length; index++)
                {
                    Ws.Cells[rowIndex[7] + index, columnIndex[7] + 1] = UIVariables.Service10_NRCPriority[index];
                }


                // Condition
                for (int index = 0; index < UIVariables.Service10_ButtonStatus_Condition?.Length; index++)
                {
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
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 0] = condition;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = UIVariables.Service10_InvalidValueCondition[index];
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 3] = status;
                            Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = UIVariables.Service10_NRCCondition[index];
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
                        if(status == "1")
                        {
                            for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                            {
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 0] = condition;
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 1] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                                Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 2] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                                if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                                {
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 3] = status;
                                    Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 4] = UIVariables.Service10_NRCCondition[index];
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
                            if(status == "1")
                            {
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 0] = condition;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 1] = UIVariables.Service10_InvalidValueCondition[index + index_];
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 2] = voltageName;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 3] = status;
                                Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 4] = UIVariables.Service10_NRCCondition[index];
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
                for (int index = 0; index < UIVariables.Service10_ButtonStatus_Optional.Length; index++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service10_ButtonStatus_Optional[index]);
                    Ws.Cells[rowIndex[9] + index, columnIndex[9] + 1] = status;
                }
            }
        }
    }
}
