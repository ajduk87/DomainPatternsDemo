using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class CustomerControllerUrls : Urls
    {
        public string Url;
        public CustomerControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/customer";
        }
    }
}
