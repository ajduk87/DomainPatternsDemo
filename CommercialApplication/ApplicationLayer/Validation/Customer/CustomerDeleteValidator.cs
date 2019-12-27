using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Customer
{
    internal class CustomerDeleteValidator : AbstractValidator<CustomerDeleteModel>
    {
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;
        private readonly ICustomerRepository customerRepository;
        public CustomerDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.customerRepository = RepositoryFactory.CreateCustomerRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("The customer specified doesn't exist in the database");
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.customerRepository.Exists(connection, id);
            }
        }
    }
}