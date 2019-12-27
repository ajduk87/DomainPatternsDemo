using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    class CommercialistLocationControllerUrls : Urls
    {
        public string Url;
        public CommercialistLocationControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/commercialist/location";
        }
    }
}
