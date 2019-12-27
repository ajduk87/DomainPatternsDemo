using Autofac;
using CommercialApplicationCommand.DomainLayer.Mappings;

namespace CommercialApplicationCommand.DomainLayer.Registration.Mappers
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<DtoToEntityMapper>()
                        .As<IMapper>();

            base.Load(objContainer);
        }
    }
}