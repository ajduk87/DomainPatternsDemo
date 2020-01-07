using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandOrderCaller
    {
        public Dictionary<string, IOrderCommand> DictCommands { get; set; }
        public CommandOrderCaller()
        {
            DictCommands = new Dictionary<string, IOrderCommand>();
            DictCommands.Add("Insert", new InsertOrderItemCommand());
        }
    }
}
