using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.ProductRepositories
{
    public abstract class ProductBaseRepository
    {
        protected readonly CommandProductCaller commandProductCaller;

        public ProductBaseRepository()
        {
            this.commandProductCaller = new CommandProductCaller();
        }
    }
}
