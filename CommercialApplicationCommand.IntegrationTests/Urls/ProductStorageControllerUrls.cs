using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    class ProductStorageControllerUrls : Urls
    {
        public string Url;
        public ProductStorageControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/product/storage";
        }
    }
}
