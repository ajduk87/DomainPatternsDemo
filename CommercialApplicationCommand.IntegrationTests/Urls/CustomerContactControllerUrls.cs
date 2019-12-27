using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class CustomerContactControllerUrls : Urls
    {
        public string Url;

        public CustomerContactControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/customer/contact";
        }
    }
}
