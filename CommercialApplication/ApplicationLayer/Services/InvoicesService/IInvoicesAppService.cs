using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;

namespace CommercialApplicationCommand.ApplicationLayer.Services.InvoicesService
{
    public interface IInvoicesAppService
    {
        InvoiceDto GetInvoice(long id);
        void CreateNewInvoice(InvoiceDto invoicesDto);

        void RemoveExistingInvoice(InvoiceDto invoicesDto);
    }
}