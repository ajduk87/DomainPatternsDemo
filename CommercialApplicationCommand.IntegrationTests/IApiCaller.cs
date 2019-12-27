using CommercialApplicationCommand.DomainLayer.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{
    public interface IApiCaller
    {
        IRestResponse Post<T>(string url, T parameter);
        IRestResponse Put<T>(string url, T parameter);
        IRestResponse Delete<T>(string url, T parameter);
    }
}
