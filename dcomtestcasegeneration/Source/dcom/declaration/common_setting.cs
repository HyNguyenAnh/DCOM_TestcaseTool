using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{

    // AnKaito definition
    public static class CommonSetting_ListCollection
    {
        public static List<CommonSettings> CommonSetting_list = new List<CommonSettings>();
        public static List<CommonCommands> CommonCommand_list = new List<CommonCommands>();
    }
    public class CommonSettings
    {
        public string CommonSetting { get; set; }
        public string Variable { get; set; }
        public string Value { get; set; }
        public string Timeout { get; set; }
        public string Comment { get; set; }
        public CommonSettings(string commonSetting, string variable, string value, string timeout, string comment)
        {
            CommonSetting = commonSetting;
            Variable = variable;
            Value = value;
            Timeout = timeout;
            Comment = comment;
        }
    }
    public class CommonCommands
    {
        public string CommonCommand { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string TypeCheck { get; set; }
        public string Comment { get; set; }
        public CommonCommands(string commonCommand, string request, string response, string typeCheck, string comment)
        {
            CommonCommand = commonCommand;
            Request = request;
            Response = response;
            TypeCheck = typeCheck;
            Comment = comment;
        }
    }

}
