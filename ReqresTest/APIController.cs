using Api;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ReqresTest
{
    public class APIController<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;

        public String MainURL = "https://reqres.in/";

        public String ConstructURL (String endPoint)
        {
            var URL = Path.Combine(MainURL, endPoint);
            return URL;
        }

        public RestClient MakeClient (String url)
        {
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest MakeGRequest ()
        {
            var restRequest = new RestRequest(Method.GET);
            return restRequest;
        }

        public RestRequest MakePostRequest (String body)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("application/json",body,ParameterType.RequestBody);
            return request;
        }

        public IRestResponse GetResponse (RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dTO = JsonConvert.DeserializeObject<DTO>(content);
            return dTO;
        }
    }
}
