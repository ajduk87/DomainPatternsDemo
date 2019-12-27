using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class CustomerSalesChannelControllerUrls : Urls
    {
        public string Url { get; set; }
        public CustomerSalesChannelControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/customer/saleschannel";
        }
    }
}
