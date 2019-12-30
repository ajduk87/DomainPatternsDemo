using CommercialApplication.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Invoices
{
    public class InvoicesDeleteValidator : AbstractValidator<InvoiceDeleteModel>
    {
        private readonly IInvoiceRepository invoicesRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public InvoicesDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.invoicesRepository = RepositoryFactory.CreateInvoiceRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(i => i.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("Invoice specified doesn't exist in the database");
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.invoicesRepository.Exists(connection, id);
            }
        }
    }
}