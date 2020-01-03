using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands
{
    public class UpdateExistingCustomerInfoCommand : CommandBase, ICustomerCommand
    {
        public void Execute(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {

        }
    }
}
