using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Services.InvoicesService;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public class InvoicesController : BaseController
    {
        private readonly IInvoicesAppService invoicesAppService;

        public InvoicesController()
        {
            this.invoicesAppService = this.registrationAppServices.Instance.Container.Resolve<IInvoicesAppService>();
        }

        [HttpPost]
        [Route("api/invoice")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Insert(InvoiceCreateModel invoiceCreateModel)
        {
            InvoiceDto invoicesDto = this.mapper.Map<InvoiceCreateModel, InvoiceDto>(invoiceCreateModel);
            this.invoicesAppService.CreateNewInvoice(invoicesDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/invoice")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Delete(InvoiceDeleteModel invoicesDeleteModel)
        {
            InvoiceDto invoicesDto = this.mapper.Map<InvoiceDeleteModel, InvoiceDto>(invoicesDeleteModel);
            this.invoicesAppService.RemoveExistingInvoice(invoicesDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}