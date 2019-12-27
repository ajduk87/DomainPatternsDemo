using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using CommercialApplicationCommand.DomainLayer.Mappings;
using CommercialApplicationCommand.DomainLayer.Registration.Containers;

namespace CommercialApplicationCommand.ApplicationLayer.Services
{
    public abstract class BaseAppService
    {
        private readonly RegistrationMappers registrationMappers;
        protected readonly IMapper dtoToEntityMapper;
        protected readonly RegistrationServices registrationServices;
        protected readonly RegistrationAppServices registrationAppServices;

        protected readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public BaseAppService()
        {
            this.registrationMappers = new RegistrationMappers();
            this.dtoToEntityMapper = this.registrationMappers.Container.Resolve<IMapper>();
            this.registrationServices = new RegistrationServices();
            this.registrationAppServices = new RegistrationAppServices();

            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
        }
    }
}