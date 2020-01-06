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
    public class GetProductCommand : IProductCommand
    {
        public Product Execute(IDbConnection connection, Id id, IDbTransaction transaction = null)
        {
            return new Product();
        }
    }
}
