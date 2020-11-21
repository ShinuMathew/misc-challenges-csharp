using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using RestChallenge.ResponseClasses;
using RestSharp.Authenticators;

namespace RestChallenge
{
    class HubClass
    {
        private static string access_token;

        static void Main(string[] args)
        {
            GetAccessToken();

        }

        public static void GetUsersList()
        {

            try
            {
                var client = new RestClient(@"https://reqres.in");

                var request = new RestRequest(@"/api/users", Method.GET);

                request.AddParameter("page", "2");

                var response = client.Execute(request);

                String responseContent = response.Content;

                JObject jsonResponse = JObject.Parse(responseContent);

                Console.WriteLine(jsonResponse);

                ListUsers listUsers = new ListUsers();

                listUsers = JsonConvert.DeserializeObject<ListUsers>(responseContent);

                Console.WriteLine(listUsers.page);

                foreach(Data data in listUsers.data)
                {
                    Console.WriteLine(data.id + " : " + data.first_name);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Following exception occured while processing the request: " + ex.StackTrace);
            }

        }

        public static void Createusers()
        {
            try
            {
                var client = new RestClient(@"https://reqres.in");

                var request = new RestRequest(@"/api/users", Method.POST);
                                
                //request.AddParameter("name", "Shinu");
                //request.AddParameter("job", "Tester");

                request.AddParameter("application/json", "{\"name\": \"Shinu\", \"job\": \"Tester\"}", ParameterType.RequestBody);

                var response = client.ExecuteAsPost(request, "POST");

                String responseContent = response.Content;

                JObject jsonResponse = JObject.Parse(responseContent);

                Console.WriteLine(jsonResponse);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Following exception occured while processing the request: " + ex.StackTrace);
            }

        }

        public static void UpdateUser()
        {
            String consumerKey = "";
            String consumerSecret = "";

            try
            {
                var client = new RestClient(@"https://reqres.in")
                {
                    //Authenticator = OAuth2Authenticator.Equals 
                    //OAuth1Authenticator.  ForRequestToken(consumerKey, consumerSecret)
                };

                var request = new RestRequest(@"/api/users", Method.PATCH);

                //request.AddParameter("name", "Shinu");
                //request.AddParameter("job", "Tester");
                //, \"job\": \"Tester\"

                request.AddParameter("application/json", "{\"name\": \"Shinu\"}", ParameterType.RequestBody);

                var response = client.Execute(request);

                String responseContent = response.Content;

                JObject jsonResponse = JObject.Parse(responseContent);

                Console.WriteLine(jsonResponse);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Following exception occured while processing the request: " + ex.StackTrace);
            }

        }

        public static AccessToken GetAccessToken()
        {
            var url = "https://my.api.endpoint/GetToken";
            var apiKey = "api_key";
            var apiPassword = "api_password";

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            //add GetToken() API method parameters
            request.Parameters.Clear();
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", apiKey);
            request.AddParameter("password", apiPassword);

            //make the API request and get the response
            IRestResponse response = client.Execute<AccessToken>(request);

            //return an AccessToken
            return JsonConvert.DeserializeObject<AccessToken>(response.Content);
        }

        public static void UseMyAuthentication()
        {
            var url = "https://my.api.endpoint/DoStuff";

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            //object containing input parameter data for DoStuff() API method
            var apiInput = new { name = "Matt", age = 34 };

            //add parameters and token to request
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + access_token, ParameterType.HttpHeader);

            //make the API request and get a response
            IRestResponse response = client.Execute(request);


            //ApiResponse is a class to model the data we want from the API response
            ApiResponse apiResponse = new ApiResponse(JsonConvert.DeserializeObject<ApiResponse>(response.Content));
        }



    }
}

