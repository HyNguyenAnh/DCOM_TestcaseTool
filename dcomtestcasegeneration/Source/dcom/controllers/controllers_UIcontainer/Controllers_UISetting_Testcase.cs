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
            UIVariables.CommonSettingFromDatabase = new List<string[]>[]
            {
                Model_GetCommonSettingDatabase.CommonSetting(),
                Model_GetCommonSettingDatabase.CommonDID(),
                Model_GetCommonSettingDatabase.ProjectInformation(),
                Model_GetCommonSettingDatabase.DataPathInformation(),
                Model_GetCommonSettingDatabase.SelectedServiceInformation(),
            };

            UIVariables.DatabaseCommonSetting = UIVariables.CommonSettingFromDatabase.ElementAt(0);


            UIVariables.DatabaseCommonDID = UIVariables.CommonSettingFromDatabase.ElementAt(1);

            // Project Information
            UIVariables.ProjectName = UIVariables.CommonSettingFromDatabase[2].ElementAt(0)[1];
            UIVariables.Variant = UIVariables.CommonSettingFromDatabase[2].ElementAt(1)[1];
            UIVariables.Release = UIVariables.CommonSettingFromDatabase[2].ElementAt(2)[1];
            UIVariables.RC = UIVariables.CommonSettingFromDatabase[2].ElementAt(3)[1];

            // Data Path Information
            UIVariables.DatabaseSource = UIVariables.CommonSettingFromDatabase[3].ElementAt(0)[1];
            UIVariables.LocalDatabaseDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "DB_Requirement")).LocalPath;
            UIVariables.TestcaseDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Testcase")).LocalPath;

            // Selected Service Information
            for (int index = 0; index < UIVariables.CommonSettingFromDatabase[4].Count; index++)
            {
                UIVariables.SelectedServiceStatus[index] = Controller_ServiceHandling.ConvertFromStringToBool(UIVariables.CommonSettingFromDatabase[4].ElementAt(index)[1]);
            }
        }
    }
}
