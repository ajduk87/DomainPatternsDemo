using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using CommercialApplicationCommand.ApplicationLayer.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommercialApplicationCommand
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly RegistrationAppServices registrationAppServices;
        private DatabaseConnectionFactory instance = null;
        private readonly object padlock = new object();

        public DatabaseConnectionFactory()
        {
            this.registrationAppServices = new RegistrationAppServices();
        }

        private string LoadConnectionString()
        {
            IConfigurationService configurationService = this.registrationAppServices.Instance.Container.Resolve<IConfigurationService>();
            List<Parameter> parameters = configurationService.GetParameters();

            return parameters.Where(parameter => parameter.Name.Equals("databaseConnectionString")).Single().Value;
        }

        public NpgsqlConnection Create(string connectionStringParam = null)
        {
            string connectionString = String.IsNullOrEmpty(connectionStringParam) ? this.LoadConnectionString() : connectionStringParam;
            return new NpgsqlConnection(connectionString);
        }

        public IDatabaseConnectionFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseConnectionFactory();
                    }
                    return instance;
                }
            }
        }
    }
}