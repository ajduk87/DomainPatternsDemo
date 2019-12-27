using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Invoices
{
    public class InvoicesCreateValidator : AbstractValidator<InvoiceCreateModel>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public InvoicesCreateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.customerRepository = RepositoryFactory.CreateCustomerRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(i => i.CustomerId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateCustomerId)
                .WithMessage("The customer specified doesn't exist in the database");
        }

        private bool ValidateCustomerId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.customerRepository.Exists(connection, id);
            }
        }
    }
}