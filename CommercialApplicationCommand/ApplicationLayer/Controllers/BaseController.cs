using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Mappings;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using System.Web.Http;

namespace CommercialApplicationCommand.ApplicationLayer.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly IMapper mapper;
        protected readonly RegistrationAppServices registrationAppServices;

        public BaseController()
        {
            this.mapper = GenerateMapper();
            this.registrationAppServices = new RegistrationAppServices();
        }

        private IMapper GenerateMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<CustomerProfile>();
                cfg.AddProfile<StorageProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<InvoiceProfile>();
                cfg.AddProfile<ActionProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}