using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItemInvoices;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.InvoiceItemInvoices
{
    public class InvoiceItemInvoicesCreateValidator : AbstractValidator<InvoiceItemInvoicesCreateModel>
    {
        private readonly IInvoiceItemRepository invoiceItemRepository;
        private readonly IInvoiceRepository invoicesRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public InvoiceItemInvoicesCreateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.invoicesRepository = RepositoryFactory.CreateInvoiceRepository();
            this.invoiceItemRepository = RepositoryFactory.CreateInvoiceItemRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(iii => iii.InvoiceId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateInvoiceId)
                .WithMessage("The invoice specified doesn't exist in the database");

            RuleFor(iii => iii.InvoiceItemId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateInvoiceItemId)
                .WithMessage("Invoice item specified doesn't exist in the database");
        }

        private bool ValidateInvoiceId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.invoicesRepository.Exists(connection, id);
            }
        }

        private bool ValidateInvoiceItemId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.invoiceItemRepository.Exists(connection, id);
            }
        }
    }
}