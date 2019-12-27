using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class ContactControllerUrls : Urls 
    {
        public string Url;

        public ContactControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/contact";
        }
    }
}
