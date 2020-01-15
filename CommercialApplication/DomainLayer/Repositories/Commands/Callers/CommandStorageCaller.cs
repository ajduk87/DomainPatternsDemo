using CommercialApplication.DomainLayer.Repositories.Commands.StorageCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandStorageCaller
    {
        public Dictionary<string, IStorageCommand> DictCommands { get; set; }
        public CommandStorageCaller()
        {
            DictCommands = new Dictionary<string, IStorageCommand>();
            DictCommands.Add("GetAll", new GetAllStorageCommand());
            DictCommands.Add("GetByName", new GetStorageByNameCommand());
            DictCommands.Add("Insert", new InsertStorageCommand());
            DictCommands.Add("Update", new UpdateStorageCommand());
            DictCommands.Add("Delete", new DeleteStorageCommand());
            DictCommands.Add("IsStorageExist", new IsStorageExistCommand());
        }
    }
}
