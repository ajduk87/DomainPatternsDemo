using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Services.StorageServices;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public class StorageController : BaseController
    {
        private readonly IStorageAppService storageAppService;

        public StorageController()
        {
            this.storageAppService = this.registrationAppServices.Instance.Container.Resolve<IStorageAppService>();
        }

        [HttpPost]
        [Route("api/storage")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Insert(StorageCreateModel storageCreateModel)
        {
            StorageDto storageDto = this.mapper.Map<StorageCreateModel, StorageDto>(storageCreateModel);
            this.storageAppService.CreateNewStorage(storageDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/storage")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Update(StorageUpdateModel storageUpdateModel)
        {
            StorageDto storageDto = this.mapper.Map<StorageUpdateModel, StorageDto>(storageUpdateModel);
            this.storageAppService.UpdateExistingStorage(storageDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/storage")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Delete(StorageDeleteModel storageDeleteModel)
        {
            StorageDto storageDto = this.mapper.Map<StorageDeleteModel, StorageDto>(storageDeleteModel);
            this.storageAppService.DeleteExistingStorage(storageDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/product/storage")]
        [ValidateModelStateFilter]
        public HttpResponseMessage AddProductToStorage(ProductStorageCreateModel productStorageCreateModel)
        {
            ProductStorageDto productStorageDto = this.mapper.Map<ProductStorageCreateModel, ProductStorageDto>(productStorageCreateModel);
            this.storageAppService.AddProductInStorage(productStorageDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/product/storage")]
        [ValidateModelStateFilter]
        public HttpResponseMessage DeleteProductFromStorage(ProductStorageDeleteModel productStorageDeleteModel)
        {
            ProductStorageDto productStorageDto = this.mapper.Map<ProductStorageDeleteModel, ProductStorageDto>(productStorageDeleteModel);
            storageAppService.RemoveProductFromStorage(productStorageDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}