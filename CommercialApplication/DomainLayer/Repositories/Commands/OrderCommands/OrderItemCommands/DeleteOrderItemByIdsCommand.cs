using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class DeleteOrderItemByIdsCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public void Execute(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {

        }
    }
}
