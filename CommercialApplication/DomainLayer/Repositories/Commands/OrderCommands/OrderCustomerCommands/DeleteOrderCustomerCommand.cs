using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands
{
    public class DeleteOrderCustomerCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public void Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {

        }
    }
}
