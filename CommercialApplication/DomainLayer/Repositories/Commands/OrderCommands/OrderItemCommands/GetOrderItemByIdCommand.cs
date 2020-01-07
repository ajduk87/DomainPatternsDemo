using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class GetOrderItemByIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public OrderItem Execute(IDbConnection connection, long orderId, IDbTransaction transaction = null)
        {
            return new OrderItem();
        }
    }
}
