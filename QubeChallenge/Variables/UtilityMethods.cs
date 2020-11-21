using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace CubeCodingChallenge.Variables
{
    class UtilityMethods
    {
        public static void GenerateToken()
        {
            CommonVariables.hosttokenID = ConfigurationManager.AppSettings.Get("HostTokenID");
            CommonVariables.guesttokenID = ConfigurationManager.AppSettings.Get("GuestTokenID");
        }

        public static DateTime GetCurrentDate()
        {            
            try
            {
                CommonVariables.date = DateTime.Now;                   
            }
            catch(Exception ex)
            {
                Console.WriteLine("Following exception occured when trying to fetch the date {1}", ex.StackTrace);
            }
            return CommonVariables.date;
        }

        public static String GetName()
        {
            try
            {
                CommonVariables.userName = ConfigurationManager.AppSettings.Get("name");
                List<String> names = new List<string>();
                int count = CommonVariables.userName.Split('|').Count();

                for(int i=0; i<count;i++)
                {
                    names.Add(CommonVariables.userName.Split('|')[i]);
                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Following exception occured when trying to fetch a random name {1}", ex.StackTrace);
            }
            return CommonVariables.userName;
        }
        
    }
}
