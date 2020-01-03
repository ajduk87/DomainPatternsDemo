using CommercialApplication.DomainLayer.Repositories.Commands.Customer;
using CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandCustomerCaller
    {
        public Dictionary<string, ICustomerCommand> DictCommands { get; set; }
        public CommandCustomerCaller()
        {
            DictCommands = new Dictionary<string, ICustomerCommand>();
            DictCommands.Add("GetAll", new GetAllCustomerCommand());
            DictCommands.Add("Get", new GetCustomerCommand());
            DictCommands.Add("CreateNewCustomerInfo", new CreateNewCustomerInfoCommand());
            DictCommands.Add("UpdateExistingCustomerInfo", new UpdateExistingCustomerInfoCommand());
            DictCommands.Add("RemoveExistingCustomerInfo", new RemoveExistingCustomerInfoCommand());
        }
    }
}
