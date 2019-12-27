using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Services.OrderServices;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderAppService orderAppService;

        public OrderController()
        {
            this.orderAppService = this.registrationAppServices.Container.Resolve<IOrderAppService>();
        }

        [HttpPost]
        [Route("api/order")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Insert(OrderCreateModel orderCreateModel)
        {
            OrderDto orderDto = this.mapper.Map<OrderDto>(orderCreateModel);
            this.orderAppService.CreateNewOrder(orderDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/order")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Update(OrderUpdateModel orderUpdateModel)
        {
            OrderDto orderDto = this.mapper.Map<OrderDto>(orderUpdateModel);
            this.orderAppService.UpdateExistingOrder(orderDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/order")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Delete(OrderDeleteModel orderDeleteModel)
        {
            this.orderAppService.DeleteExistingOrder(orderDeleteModel.Id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}