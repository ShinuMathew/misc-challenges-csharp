using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CubeCodingChallenge.MethodEngine
{
    class CommonMethodEngine
    {
        public static void CreateSecureServerConnection(String server)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            Variables.CommonVariables.client = new RestClient(server);
        }
    }
}
