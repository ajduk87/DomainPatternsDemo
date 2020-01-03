using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands
{
    public abstract class CommandBase
    {
        protected NpgsqlConnection connection;

        public CommandBase()
        {
            this.connection = new NpgsqlConnection();
        }
    }
}
