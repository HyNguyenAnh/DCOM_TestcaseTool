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
    class Model_SaveDatabaseService27
    {
        public static void SaveDatabaseService27(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;
            string status;

            // Specification
            for (int index = 0; index < UIVariables.Service27_SubFunction?.Count(); index++)
            {
                for (int index_ = 0; index_ < UIVariables.Service27_SubFunction?.ElementAt(index).Length; index_++)
                {
                    Ws.Cells[rowIndex[5] + index, columnIndex[5] + index_] = UIVariables.Service27_SubFunction.ElementAt(index)[index_];
                }
            }

            // Allow Session || Addressing Mode
            int n = 0;
            for (int index = 0; index < 2; index++)
            {
                for (int index_ = 0; index_ < 3; index_++)
                {
                    status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_AddressingMode[n]);
                    Ws.Cells[rowIndex[6] + index, columnIndex[6] + index_ + 1] = status;
                    n++;
                }
            }

            // NRC
            for (int index = 0; index < UIVariables.Service27_NRCPrioritySeed?.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 1] = UIVariables.Service27_NRCPrioritySeed[index];
            }
            for (int index = 0; index < UIVariables.Service27_NRCPriorityKey?.Length; index++)
            {
                Ws.Cells[rowIndex[7] + index, columnIndex[7] + 2] = UIVariables.Service27_NRCPriorityKey[index];
            }

            // Condition
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_Condition?.Length; index++)
            {
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

                if (index == 0 && status == "1")
                {
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = condition;
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 2] = UIVariables.Service27_InvalidValueCondition[index];
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = status;
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 5] = UIVariables.Service27_NRCCondition[index];
                }
                else if (index == 1 && status == "1")
                {
                    for (int index_ = 0; index_ < engineStatusConditionSplit.Length; index_++)
                    {
                        Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 1] = condition;
                        Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 2] = engineStatusConditionSplit[index_].Trim().Split('(')[0];
                        Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 3] = engineStatusConditionSplit[index_].Trim().Split('(')[1].Split(')')[0];
                        if (engineStatusConditionSplit[index_].Trim().Split('(')[0] != "0")
                        {
                            Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 4] = status;
                            Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 5] = UIVariables.Service27_NRCCondition[index];
                        }
                        else
                        {
                            Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 4] = "0";
                            Ws.Cells[rowIndex[8] + index + index_, columnIndex[8] + 5] = "";
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
                        Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 1] = condition;
                        Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 2] = UIVariables.Service27_InvalidValueCondition[index + index_];
                        Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 3] = voltageName;
                        Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 4] = status;
                        Ws.Cells[rowIndex[8] + index + index_ + engineStatusConditionSplit.Length - 1, columnIndex[8] + 5] = UIVariables.Service27_NRCCondition[index];
                    }
                }
                else
                {
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = condition;
                    Ws.Cells[rowIndex[8] + index, columnIndex[8] + 4] = status;
                    if (index == UIVariables.Service27_ButtonStatus_Condition?.Length - 1)
                    {
                        Ws.Cells[rowIndex[8] + index + 1, columnIndex[8] + 4] = status;
                    }
                }
            }

            // Optional
            for (int index = 0; index < UIVariables.Service27_ButtonStatus_Optional.Length; index++)
            {
                status = Controller_ServiceHandling.ConvertFromBoolToStringBit(UIVariables.Service27_ButtonStatus_Optional[index]);
                Ws.Cells[rowIndex[9] + index, columnIndex[9] + 2] = status;
            }
        }
    }
}
