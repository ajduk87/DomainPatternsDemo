using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class CustomerLocationControllerUrls : Urls
    {
        public string Url;
        public CustomerLocationControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/customer/location";
        }
    }
}
