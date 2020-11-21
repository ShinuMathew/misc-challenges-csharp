using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeCodingChallenge.ResponseClasses;
using System.Configuration;

namespace CubeCodingChallenge.Variables
{
    class CommonVariables
    {
        public static String createdFileID = "";
        public static Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static String guesttokenID = "6f38f7b7-a650-4c67-85b1-3ec9ee2df65c";
        public static String hosttokenID = "6f38f7b7-a650-4c67-85b1-3ec9ee2df65c";

        public static GetFilesResponse getFilesResponse = new GetFilesResponse();

        public static DateTime date = DateTime.MinValue;
        public static String methodName = "";

        public static String userName="";

        public static String serverName = "";

        public static RestSharp.RestClient client;

        public static String exceptionType;


    }
    
}
