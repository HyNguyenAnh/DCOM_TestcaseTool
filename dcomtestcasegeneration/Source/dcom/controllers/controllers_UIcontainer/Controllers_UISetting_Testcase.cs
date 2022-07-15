using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dcom.controllers.controllers_middleware;
using dcom.declaration;
using dcom.models.models_databaseHandling.models_getDatabase;

namespace dcom.controllers.controllers_UIcontainer
{
    class Controllers_UISetting_Testcase
    {
        public static void UIDefinition_Setting_Testcase()
        {
            // Get data from database
            UIVariables.CommonSettingDatabase = new List<string[]>[]
            {
                Model_GetCommonSettingDatabase.CommonSetting(),
                Model_GetCommonSettingDatabase.CommonDID(),
                Model_GetCommonSettingDatabase.ProjectInformation(),
                Model_GetCommonSettingDatabase.DataPathInformation(),
                Model_GetCommonSettingDatabase.SelectedServiceInformation(),
            };

            // Common Setting
            UIVariables.DatabaseCommonSettingCreateFault = UIVariables.CommonSettingDatabase[0].ElementAt(0);
            UIVariables.DatabaseCommonSettingVehicleSpeed = UIVariables.CommonSettingDatabase[0].ElementAt(1);
            UIVariables.DatabaseCommonSettingEngineStatus = UIVariables.CommonSettingDatabase[0].ElementAt(2);
            UIVariables.DatabaseCommonSettingSecurityUnlock = UIVariables.CommonSettingDatabase[0].ElementAt(3);

            UIVariables.DatabaseCommonSetting = new List<string[]>
            {
                UIVariables.DatabaseCommonSettingCreateFault,
                UIVariables.DatabaseCommonSettingVehicleSpeed,
                UIVariables.DatabaseCommonSettingEngineStatus,
                UIVariables.DatabaseCommonSettingSecurityUnlock,
            };

            // Common DID
            UIVariables.DatabaseCommonDIDCurrentSession = UIVariables.CommonSettingDatabase[1].ElementAt(0);
            UIVariables.DatabaseCommonDIDInvalidCounter = UIVariables.CommonSettingDatabase[1].ElementAt(1);
            UIVariables.DatabaseCommonDIDCurrentVoltage = UIVariables.CommonSettingDatabase[1].ElementAt(2);

            UIVariables.DatabaseCommonDID = new List<string[]>
            {
                UIVariables.DatabaseCommonDIDCurrentSession,
                UIVariables.DatabaseCommonDIDInvalidCounter,
                UIVariables.DatabaseCommonDIDCurrentVoltage,
            };

            // Project Information
            UIVariables.ProjectName = UIVariables.CommonSettingDatabase[2].ElementAt(0)[1];
            UIVariables.Variant = UIVariables.CommonSettingDatabase[2].ElementAt(1)[1];
            UIVariables.Release = UIVariables.CommonSettingDatabase[2].ElementAt(2)[1];
            UIVariables.RC = UIVariables.CommonSettingDatabase[2].ElementAt(3)[1];

            // Data Path Information
            UIVariables.DatabaseSource = UIVariables.CommonSettingDatabase[3].ElementAt(0)[1];
            UIVariables.LocalDatabaseDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "DB_Requirement")).LocalPath;
            UIVariables.TestcaseDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Testcase")).LocalPath;

            // Selected Service Information
            for (int index = 0; index < UIVariables.CommonSettingDatabase[4].Count; index++)
            {
                UIVariables.SelectedServiceStatus[index] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.CommonSettingDatabase[4].ElementAt(index)[1]);
            }
        }
    }
}
