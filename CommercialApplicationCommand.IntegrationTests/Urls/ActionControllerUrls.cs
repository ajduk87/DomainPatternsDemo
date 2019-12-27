using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.Urls
{
    public class ActionControllerUrls : Urls
    {
        public string Url;
        public string UrlForUpdatingByCustomerId;
        public string UrlForUpdatingBySalesChannelId;
        public ActionControllerUrls()
        {
            this.Url = $"{this.ServerIpAddress}api/action";
            this.UrlForUpdatingByCustomerId = $"{this.ServerIpAddress}api/action/customer";
            this.UrlForUpdatingBySalesChannelId = $"{this.ServerIpAddress}api/action/saleschannel";
        }
    }
}
