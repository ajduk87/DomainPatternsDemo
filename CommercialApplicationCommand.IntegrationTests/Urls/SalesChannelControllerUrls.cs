using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class SalesChannelControllerUrls : Urls
    {
        public string Url;
        public SalesChannelControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/saleschannel";
        }
    }
}
