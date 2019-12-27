using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.ApplicationLayer.Services.CustomerServices;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService customerAppService;

        private CustomerController()
        {
            this.customerAppService = this.registrationAppServices.Instance.Container.Resolve<ICustomerAppService>();
        }

        [HttpPost]
        [Route("api/customer")]
        [ValidateModelStateFilter]
        public HttpResponseMessage CreateNewCustomerInfo(CustomerCreateModel customerCreateModel)
        {
            CustomerDto customerDto = this.mapper.Map<CustomerCreateModel, CustomerDto>(customerCreateModel);
            this.customerAppService.CreateNewCustomerInfo(customerDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/customer")]
        [ValidateModelStateFilter]
        public HttpResponseMessage UpdateExistingCustomerInfo(CustomerUpdateModel customerUpdateModel)
        {
            CustomerDto customerDto = this.mapper.Map<CustomerUpdateModel, CustomerDto>(customerUpdateModel);
            this.customerAppService.UpdateExistingCustomerInfo(customerDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/customer")]
        [ValidateModelStateFilter]
        public HttpResponseMessage RemoveExistingCustomerInfo(CustomerDeleteModel customerDeleteModel)
        {
            CustomerDto customerDto = this.mapper.Map<CustomerDeleteModel, CustomerDto>(customerDeleteModel);
            this.customerAppService.RemoveExistingCustomerInfo(customerDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}