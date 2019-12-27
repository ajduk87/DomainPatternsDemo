using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{
    public class DatabaseParameters
    {
        public readonly string ConnectionString;

        public DatabaseParameters()
        {
            this.ConnectionString = "Server=127.0.0.1;Port=5432;Database=commercialApplicationDb;User Id=postgres;Password=postgres;";
        }
    }
}
