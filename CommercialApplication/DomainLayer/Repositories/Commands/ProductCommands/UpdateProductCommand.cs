using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class UpdateProductCommand : IProductCommand
    {
        public void Execute(IDbConnection connection, Product product, IDbTransaction transaction = null)
        {

        }
    }
}
