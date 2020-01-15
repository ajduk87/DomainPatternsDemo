using CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandActionCaller
    {
        public Dictionary<string, IActionCommand> DictCommands { get; set; }

        public CommandActionCaller()
        {
            DictCommands = new Dictionary<string, IActionCommand>();
            DictCommands.Add("GetAll", new GetActionCommand());
            DictCommands.Add("Get", new GetActionCommand());
            DictCommands.Add("Insert", new InsertActionCommand());
            DictCommands.Add("Update", new UpdateActionCommand());
            DictCommands.Add("UpdateActionByCustomerId", new UpdateActionCommandByCustomerId());
            DictCommands.Add("Delete", new DeleteActionCommand());
            DictCommands.Add("IsActionExist", new IsActionExistCommand());
        }
    }
}
