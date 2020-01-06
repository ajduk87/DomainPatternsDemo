using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class GetAllVegetablesCommand
    {
        public IEnumerable<Product> Execute(IDbConnection connection, IDbTransaction transaction = null)
        {
            return new List<Product>();
        }
    }
}
