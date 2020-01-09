using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands
{
    public class InsertOrderItemOrderCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public void Execute(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null)
        {

        }
    }
}
