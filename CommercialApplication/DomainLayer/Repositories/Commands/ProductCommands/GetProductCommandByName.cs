using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class GetProductCommandByName : IProductCommand
    {
        public Product Execute(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return new Product();
        }
    }
}
