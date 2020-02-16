using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Urls
{
    public class ProductUrls : Urls
    {
        public string Product;

        public ProductUrls()
        {
            this.Product = $"{ServerIpAddress}/api/product";
        }
    }
}
