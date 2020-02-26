using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Urls
{
    public class OrderUrls : Urls
    {
        public string Order;

        public OrderUrls()
        {
            this.Order = $"{ServerIpAddress}/api/order";
        }
    }
}
