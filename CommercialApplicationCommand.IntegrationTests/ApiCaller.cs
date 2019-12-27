using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{
    public class ApiCaller : IApiCaller
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;

        public ApiCaller()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }


        private RestRequest CreateRequest(Method methodVerb)
        {
            RestRequest Request = new RestRequest(methodVerb);

            Request.AddHeader("cache-control", "no-cache");
            Request.AddHeader("content-type", "application/json");
            return Request;
        }

        public IRestResponse Post<T>(string url, T parameter)
        {
            RestClient client = new RestClient(url);
            RestRequest request = CreateRequest(Method.POST);

            var json = JsonConvert.SerializeObject(parameter, this.jsonSerializerSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response;
        }
        public IRestResponse Put<T>(string url, T parameter)
        {
            RestClient client = new RestClient(url);
            RestRequest request = CreateRequest(Method.PUT);

            var json = JsonConvert.SerializeObject(parameter, this.jsonSerializerSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse Delete<T>(string url, T parameter)
        {
            RestClient client = new RestClient(url);
            RestRequest request = CreateRequest(Method.DELETE);

            var json = JsonConvert.SerializeObject(parameter, this.jsonSerializerSettings);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
