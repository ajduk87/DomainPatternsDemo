using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class SellingProgramControllerUrls : Urls
    {
        public string Url;

        public SellingProgramControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/sellingprogram";
        }
    }
}
