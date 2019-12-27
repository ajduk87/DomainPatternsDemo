using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class StorageControllerUrls : Urls
    {
        public string Url;
        public StorageControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/storage";
        }
    }
}
