using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class ProductControllerUrls : Urls
    {
        public string Url;
        public ProductControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/product";
        }
    }
}
