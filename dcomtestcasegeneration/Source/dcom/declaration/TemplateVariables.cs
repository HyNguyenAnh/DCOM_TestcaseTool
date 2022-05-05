using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace dcom.declaration
{
    class TemplateVariables
    {
        public static Workbook WbOutputDatabase { get; set; }
        public static Worksheet WsOutputDatabase { get; set; }

        public static string NameOutputDatabase { get; set; }
        public static string DirectoryOutputDatabase { get; set; }
        public static string PathOutputDatabase { get; set; }
    }
}
