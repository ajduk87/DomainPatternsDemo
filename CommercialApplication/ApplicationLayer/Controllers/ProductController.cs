using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Services.ProductServices;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductAppService productAppService;

        public ProductController()
        {
            this.productAppService = this.registrationAppServices.Instance.Container.Resolve<IProductAppService>();
        }

        [HttpPost]
        [Route("api/product")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Insert(ProductCreateModel productCreateModel)
        {
            ProductDto productDto = this.mapper.Map<ProductCreateModel, ProductDto>(productCreateModel);
            this.productAppService.CreateNewProduct(productDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/product")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Update(ProductUpdateModel productUpdateModel)
        {
            ProductDto productDto = this.mapper.Map<ProductUpdateModel, ProductDto>(productUpdateModel);
            this.productAppService.UpdateExistingProduct(productDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [ValidateModelStateFilter]
        [Route("api/product")]
        public HttpResponseMessage Delete(ProductDeleteModel productDeleteModel)
        {
            ProductDto productDto = this.mapper.Map<ProductDeleteModel, ProductDto>(productDeleteModel);
            this.productAppService.RemoveExistingProduct(productDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}