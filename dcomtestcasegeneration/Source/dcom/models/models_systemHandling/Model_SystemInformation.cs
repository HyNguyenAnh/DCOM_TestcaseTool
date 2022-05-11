using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.declaration;
using System.IO;

namespace dcom.models.models_systemHandling
{
    class Model_SystemInformation
    {
        public static void createBackupFile()
        {
            if (File.Exists(SystemVariables.backupFilePath))
            {
                // Delete current backup file
                File.Delete(SystemVariables.backupFilePath);

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(SystemVariables.backupFilePath))
                {
                    sw.WriteLine(DatabaseVariables.DatabasePath);
                    sw.WriteLine(DateTime.Now);
                }
            }
        }

        public static void readBackupFile()
        {
            string backupFilePath = SystemVariables.backupFilePath;
            using (StreamReader sr = File.OpenText(backupFilePath))
            {
                DatabaseVariables.DatabasePath = sr.ReadLine().ToString();
            }
        }

    }
}
