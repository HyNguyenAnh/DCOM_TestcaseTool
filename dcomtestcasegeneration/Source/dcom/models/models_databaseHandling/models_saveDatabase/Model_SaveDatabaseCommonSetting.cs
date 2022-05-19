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

            // Common Command
            List<string[]> SaveCommonCommand = new List<string[]>
            {
                DatabaseVariables.DatabaseCommonCommandReadDTCStatusActive,
                DatabaseVariables.DatabaseCommonCommandReadDTCStatusPassive,
                DatabaseVariables.DatabaseCommonCommandReadDTCStatusNoDTC,
            };
            for (int index = 0; index < SaveCommonCommand.Count; index++)
            {
                for (int index_ = 0; index_ < SaveCommonCommand.ElementAt(index).Length; index_++)
                {
                    Ws.Cells[rowIndex[1] + index, columnIndex[1] + index_] = SaveCommonCommand.ElementAt(index)[index_];
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
                    Ws.Cells[rowIndex[2] + index, columnIndex[2] + index_] = SaveCommonDID.ElementAt(index)[index_];
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
                Ws.Cells[rowIndex[8] + index, columnIndex[8] + 1] = ProjectInformation[index];
            }

            // Data Path Information
            string[] DataPathInformation = new string[]
            {
                DatabaseVariables.DatabaseSource,
                DatabaseVariables.PathOutputDatabase,
                "",
                "",
                DatabaseVariables.TestcaseDirectory,
                DatabaseVariables.TemplatePath,
                DatabaseVariables.DirectoryOutputDatabase,
            };
            for(int index = 0; index < DataPathInformation.Length; index++)
            {
                Ws.Cells[rowIndex[9] + index, columnIndex[9] + 1] = DataPathInformation[index];
            }
            

            // Selected Service
            for (int index = 0; index < 12; index++)
            {
                string selectedServiceStatus = Controller_ServiceHandling.ConvertFromBoolToStringBit(DatabaseVariables.SelectedServiceStatus[index]);
                Ws.Cells[rowIndex[10] + index, columnIndex[10] + 1] = selectedServiceStatus;
            }
        }
    }
}
