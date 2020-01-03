using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.InvoicesRepositories
{
    public abstract class InvoiceBaseRepository
    {
        protected readonly CommandInvoiceCaller commandInvoiceCaller;

        public InvoiceBaseRepository()
        {
            this.commandInvoiceCaller = new CommandInvoiceCaller();
        }
    }
}
