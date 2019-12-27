using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class OrderControllerUrls : Urls
    {
        public string Url;
        public OrderControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/order";
        }
    }
}
