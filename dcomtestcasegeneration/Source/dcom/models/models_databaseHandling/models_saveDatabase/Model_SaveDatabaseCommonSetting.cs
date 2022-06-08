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
    class Model_SaveDatabaseCommonSetting
    {
        public static void SaveCommonSettingDatabase(Worksheet Ws)
        {
            int[] rowIndex = DatabaseVariables.StartRowIndexDatabaseTables;
            int[] columnIndex = DatabaseVariables.StartColumnIndexDatabaseTables;

            // Common Setting
            List<string[]> SaveCommonSetting = new List<string[]>
            {
                DatabaseVariables.DatabaseCommonSettingCreateFault,
                DatabaseVariables.DatabaseCommonSettingVehicleSpeed,
                DatabaseVariables.DatabaseCommonSettingEngineStatus,
                DatabaseVariables.DatabaseCommonSettingPowerMode,
                DatabaseVariables.DatabaseCommonSettingSecurityUnlock,
            };
            for (int index = 0; index < SaveCommonSetting.Count; index++)
            {
                for (int index_ = 0; index_ < SaveCommonSetting.ElementAt(index).Length; index_++)
                {
                    Ws.Cells[rowIndex[0] + index, columnIndex[0] + index_] = SaveCommonSetting.ElementAt(index)[index_];
                }
            }

            // Common DID
            List<string[]> SaveCommonDID = new List<string[]>
            {
                DatabaseVariables.DatabaseCommonDIDCurrentSession,
                DatabaseVariables.DatabaseCommonDIDInvalidCounter,
                DatabaseVariables.DatabaseCommonDIDCurrentVoltage,
            };
            for (int index = 0; index < SaveCommonDID.Count; index++)
            {
                for (int index_ = 0; index_ < SaveCommonDID.ElementAt(index).Length; index_++)
                {
                    Ws.Cells[rowIndex[1] + index, columnIndex[1] + index_] = SaveCommonDID.ElementAt(index)[index_];
                }
            }

            // Project Information
            string[] ProjectInformation = new string[]
            {
                DatabaseVariables.ProjectName,
                DatabaseVariables.Variant,
                DatabaseVariables.Release,
                DatabaseVariables.RC,
            };
            for (int index = 0; index < ProjectInformation.Length; index++)
            {
                Ws.Cells[rowIndex[2] + index, columnIndex[2] + 1] = ProjectInformation[index];
            }

            // Data Path Information
            string[] DataPathInformation = new string[]
            {
                DatabaseVariables.DatabaseSource,
                DatabaseVariables.PathOutputDatabase,
                DatabaseVariables.TestcaseDirectory,
            };
            for(int index = 0; index < DataPathInformation.Length; index++)
            {
                Ws.Cells[rowIndex[3] + index, columnIndex[3] + 1] = DataPathInformation[index];
            }
            

            // Selected Service
            for (int index = 0; index < 12; index++)
            {
                string selectedServiceStatus = Controller_ServiceHandling.ConvertFromBoolToStringBit(DatabaseVariables.SelectedServiceStatus[index]);
                Ws.Cells[rowIndex[4] + index, columnIndex[4] + 1] = selectedServiceStatus;
            }
        }
    }
}
