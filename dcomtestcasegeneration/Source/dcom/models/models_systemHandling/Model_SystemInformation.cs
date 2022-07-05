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
        public static void createFolder(string path_folder)
        {
            try
            {
                if (Directory.Exists(path_folder))
                {
                    //The code will execute if the folder exists
                }
                else
                {
                    //The below code will create a folder if the folder is not exists        
                    DirectoryInfo folder = Directory.CreateDirectory(path_folder);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }
        public static void createBackupFile()
        {
            if (File.Exists(SystemVariables.backupFilePath))
            {
                // Delete current backup file
                File.Delete(SystemVariables.backupFilePath);

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(SystemVariables.backupFilePath))
                {
                    sw.WriteLine(DatabaseVariables.PathOutputDatabase);
                    sw.WriteLine(DateTime.Now);
                }
            }
        }

        public static void readBackupFile()
        {
            string backupFilePath = SystemVariables.backupFilePath;
            using (StreamReader sr = File.OpenText(backupFilePath))
            {
                UIVariables.DatabasePath = sr.ReadLine().ToString();
            }
        }

    }
}
