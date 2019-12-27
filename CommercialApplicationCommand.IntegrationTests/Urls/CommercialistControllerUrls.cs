using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class CommercialistControllerUrls : Urls
    {
        public readonly string Url;
        public readonly string UrlLocation;

        public CommercialistControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/commercialist";
            this.UrlLocation = $"{this.ServerIpAddress}api/commercialist/location";
        }
    }
}
