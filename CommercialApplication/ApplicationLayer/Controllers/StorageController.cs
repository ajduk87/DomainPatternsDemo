using Autofac;
using CommercialApplication.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Services.StorageServices;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("api/storage")]
        public IEnumerable<StorageViewModel> GetAll()
        {
            IEnumerable<StorageDto> storageDtoes = storageAppService.GetAll();
            IEnumerable<StorageViewModel> storageViewModels = this.mapper.Map<IEnumerable<StorageViewModel>>(storageDtoes);
            return storageViewModels;
        }

        [HttpGet]
        [Route("api/storage")]
        public StorageViewModel Get(string name)
        {
            StorageDto storageDto = storageAppService.Get(name);
            StorageViewModel storageViewModel = this.mapper.Map<StorageViewModel>(storageDto);
            return storageViewModel;
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