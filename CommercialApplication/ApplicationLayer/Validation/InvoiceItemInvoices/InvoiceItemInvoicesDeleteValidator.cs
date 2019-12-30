using CommercialApplication.ApplicationLayer.Models.InvoiceItemInvoices;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.InvoiceItemInvoices
{
    public class InvoiceItemInvoicesDeleteValidator : AbstractValidator<InvoiceItemInvoicesDeleteModel>
    {
        private readonly IInvoiceItemInvoicesRepository invoiceItemInvoicesRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public InvoiceItemInvoicesDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.invoiceItemInvoicesRepository = RepositoryFactory.CreateInvoiceItemInvoicesRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(iii => iii.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("The order item for the order specified doesn't exist in the database");
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.invoiceItemInvoicesRepository.Exists(connection, id);
            }
        }
    }
}