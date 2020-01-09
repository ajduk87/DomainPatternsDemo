using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands
{
    public class GetOrderItemsOrderByOrderIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public IEnumerable<long> Execute(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return new List<long>();
        }
    }
}
