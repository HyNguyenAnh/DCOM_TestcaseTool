using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.declaration;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace dcom.models.models_systemHandling
{
    class Model_SystemInformation
    {
        public static void createFolder(string directoryFolder)
        {
            try
            {
                if (Directory.Exists(directoryFolder))
                {
                    //The code will execute if the folder exists
                }
                else
                {
                    //The below code will create a folder if the folder is not exists        
                    DirectoryInfo folder = Directory.CreateDirectory(directoryFolder);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}");
            }
            finally
            {

            }
        }
        public static void createBackupFile(string backupFilePath)
        {
            if (File.Exists(backupFilePath))
            {
                // Delete current backup file
                File.Delete(backupFilePath);
            }
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(backupFilePath))
            {
                sw.WriteLine(SystemVariables.PathOutputDatabase);
                sw.WriteLine(DateTime.Now);
            }
        }

        public static void readBackupFile(string backupFilePath)
        {
            using (StreamReader sr = File.OpenText(backupFilePath))
            {
                UIVariables.DatabasePath = sr.ReadLine().ToString();
            }
        }
        public static void checkTemplateFile(string templateFileLocalPath, string templateFileServerPath)
        {
            if (!File.Exists(templateFileLocalPath))
            {
                string templateDirectory = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "DB_Template")).LocalPath;
                createFolder(templateDirectory);
                try
                {
                    File.Copy(templateFileServerPath, templateFileLocalPath, true);
                }
                catch(IOException iox)
                {
                    MessageBox.Show($"{iox}");
                }
                finally
                {
                    //
                }
            }
            else
            {
                //
            }
        }
    }
}
