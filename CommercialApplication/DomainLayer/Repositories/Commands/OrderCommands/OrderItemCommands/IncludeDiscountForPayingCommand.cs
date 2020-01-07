using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class IncludeDiscountForPayingCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public void Execute(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            
        }
    }
}
