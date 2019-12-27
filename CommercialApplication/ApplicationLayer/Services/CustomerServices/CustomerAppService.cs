using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Services.CustomerServices;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Services.CustomerServices
{
    public class CustomerAppService : BaseAppService, ICustomerAppService
    {
        private readonly ICustomerService customerService;

        public CustomerAppService()
        {
            this.customerService = this.registrationServices.Instance.Container.Resolve<ICustomerService>();
        }

        public void CreateNewCustomerInfo(CustomerDto customerDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Customer customer = this.dtoToEntityMapper.Map<CustomerDto, Customer>(customerDto);
                this.customerService.Insert(connection, customer);
            }
        }

        public void UpdateExistingCustomerInfo(CustomerDto customerDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Customer customer = this.dtoToEntityMapper.Map<CustomerDto, Customer>(customerDto); ;
                this.customerService.Update(connection, customer);
            }
        }

        public void RemoveExistingCustomerInfo(CustomerDto customerDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Customer customer = this.dtoToEntityMapper.Map<CustomerDto, Customer>(customerDto);
                this.customerService.Delete(connection, customer);
            }
        }
    }
}
