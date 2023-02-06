using Api;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqresTest
{
    public class Main
    {
        public UsersDTO GetUsers()
        {
            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("api/users?page=2", Method.GET);
          

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<UsersDTO>(content);
            return users;
            
        }
      
    }
}
