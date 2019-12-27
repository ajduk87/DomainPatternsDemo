using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    class LocationControllerUrls : Urls
    {
        public readonly string Url;
        public LocationControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/location";
        }
    }
}
