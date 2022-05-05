using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.declaration
{
    public class specification
    {
 
        public string subFunctionl_str { get; set; }
        public string parameter_str { get; set; }
        public string record_str { get; set; }
        public string expected_value_str { get; set; }

        public specification()
        {
            subFunctionl_str = "";
            parameter_str = "";
            record_str = "";
            expected_value_str = "";
        }

    }
    public class allow_session
    {
        public string default_str { get; set; }
        public string programming_str { get; set; }
        public string extended_str { get; set; }
        public allow_session()
        {
            default_str = "";
            programming_str = "";
            extended_str = "";
        }
    }

    public class additionalREQ
    {
        public bool FunctionalADD_b { get; set; }
        public bool SuppressSP_b { get; set; }
        public bool SecurityAccess_b { get; set; }
        public additionalREQ()
        {
            FunctionalADD_b = false;
            SuppressSP_b = false;
            SecurityAccess_b = false;
        }
    }
    public class NRCprecondition
    {
        public string NRC { get; set; }
        public List<String> request_li = new List<String>();
        public List<String> response_li = new List<String>();
        public NRCprecondition()
        {
            NRC = "";
        }
    }



    // AnKaito - definition
    public static class Service11_ListCollection
    {
        public static List<Specification_Service11> SpecificationSer11_list = new List<Specification_Service11>();
        public static List<AllowSession_Service11> AllowSessionSer11_list = new List<AllowSession_Service11>();
        public static List<Optional_Service11> OptionalSer11_list = new List<Optional_Service11>();
        public static List<Precondition_Service11> PreconditionSer11_list = new List<Precondition_Service11>();
        public static List<NRC_Service11> NRCSer11_list = new List<NRC_Service11>();
    }
    
    public class Specification_Service11
    {
        public string SubFunction { get; set; }
        public string Parameter { get; set; }
        public string Record { get; set; }
        public string ExpectedValue { get; set; }
        public Specification_Service11(string subFunction, string parameter, string record, string expectedValue)
        {
            SubFunction = subFunction;
            Parameter = parameter;
            Record = record;
            ExpectedValue = expectedValue;
        }
    }

    public class AllowSession_Service11
    {
        public string Default { get; set; }
        public string Programming { get; set; }
        public string Extended { get; set; }
        public AllowSession_Service11(string defaultSession, string programmingSession, string extendedSession)
        {
            Default = defaultSession;
            Programming = programmingSession;
            Extended = extendedSession;
        }
    }

    public class Optional_Service11
    {
        public string Optional { get; set; }
        public string Status { get; set; }
        public Optional_Service11(string optional, string status)
        {
            Optional = optional;
            Status = status;
        }
    }

    public class Precondition_Service11
    {
        public string NRC { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Comment { get; set; }
        public Precondition_Service11(string nrc, string request, string response, string comment)
        {
            NRC = nrc;
            Request = request;
            Response = response;
            Comment = comment;
        }
    }
    public class NRC_Service11
    {
        public string Header { get; set; }
        public string Priority { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }
        public string P11 { get; set; }
        public string P12 { get; set; }
        public string P13 { get; set; }
        public string NRC_len { get; set; }
        public NRC_Service11(string header, string priority, string priority1, string priority2, string priority3, string priority4, string priority5, string priority6, string priority7, string priority8, string priority9, string priority10, string priority11, string priority12, string priority13, string nrc_len)
        {
            Header = header;
            Priority = priority;
            P1 = priority1;
            P2 = priority2;
            P3 = priority3;
            P4 = priority4;
            P5 = priority5;
            P6 = priority6;
            P7 = priority7;
            P8 = priority8;
            P9 = priority9;
            P10 = priority10;
            P11 = priority11;
            P12 = priority12;
            P13 = priority13;
            NRC_len = nrc_len;
        }
    }


    public class ServiceVariables
    {
        public static List<string[]> service11_specification { get; set; }
        public static List<string[]> service11_allowSession { get; set; }
        public static List<string[]> service11_NRC{ get; set; }
        public static List<string[]> service11_optional { get; set; }
        public static List<string[]> service11_precondition { get; set; }
    }
}
