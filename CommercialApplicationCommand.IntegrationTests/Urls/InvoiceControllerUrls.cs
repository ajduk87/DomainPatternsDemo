using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class InvoiceControllerUrls : Urls
    {
        public string Url;
        public InvoiceControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/invoice";
        }
    }
}
