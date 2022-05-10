using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dcom.declaration;
using System.IO;

namespace dcom.models.models_databaseHandling
{
    class Model_UIInformation
    {
        string backupTxtFilePath = SystemVariables.currentApplicationPath.Remove(SystemVariables.currentApplicationPath.Length - 8, 8) + "BackupFile.txt";
        
    }
}
