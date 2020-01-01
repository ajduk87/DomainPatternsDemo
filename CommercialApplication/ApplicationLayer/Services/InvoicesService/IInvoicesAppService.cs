using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using System;

namespace CommercialApplicationCommand.ApplicationLayer.Services.InvoicesService
{
    public interface IInvoicesAppService
    {
        InvoiceDto GetInvoice(long id);
        void CreateNewInvoice(InvoiceDto invoicesDto);

        void RemoveExistingInvoice(InvoiceDto invoicesDto);
        InvoiceDto GetMaxSumValueInvoiceForDay(DateTime day);
        InvoiceDto GetMinSumValueInvoiceForDay(DateTime day);
    }
}