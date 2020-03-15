using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Urls
{
    public class OrderUrls : Urls
    {
        public string Order { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }

        public OrderUrls()
        {
            this.Order = $"{ServerIpAddress}/api/order";
            this.Product = $"{ServerIpAddress}/api/product";
            this.Customer = $"{ServerIpAddress}/api/customer";
        }
    }
}
