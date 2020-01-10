using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands
{
    public class InsertOrderCustomerCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";
        public void  Execute(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {

        }
    }
}
