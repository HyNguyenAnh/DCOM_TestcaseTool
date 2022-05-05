using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.controllers.controllers_middleware
{
    class Controller_FileHandling
    {
        public static bool IsFileLocked(string path)
        {
            FileInfo file = new FileInfo(path);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Close();
                }

                //file is not locked
                return false;
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
  
        }

        public static bool IsFileExisted(string path)
        {
            return File.Exists(path);
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
