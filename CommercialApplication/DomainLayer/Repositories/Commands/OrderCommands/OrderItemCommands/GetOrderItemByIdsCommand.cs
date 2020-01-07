using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class GetOrderItemByIdsCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public IEnumerable<OrderItem> Execute(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            return new List<OrderItem>();
        }
    }
}
