using CommercialClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Services
{
    public interface IProductService
    {
        void Insert(Product product);
        void Update(Product product);
        Product Get(string name);
    }
}
