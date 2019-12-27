using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;

namespace CommercialApplicationCommand.ApplicationLayer.Services.InvoicesService
{
    public interface IInvoicesAppService
    {
        void CreateNewInvoice(InvoiceDto invoicesDto);

        void RemoveExistingInvoice(InvoiceDto invoicesDto);
    }
}