using Autofac;
using CommercialApplicationCommand.DomainLayer.Registration.Services;
using System;

namespace CommercialApplicationCommand.DomainLayer.Registration.Containers
{
    public sealed class RegistrationServices
    {
        private ContainerBuilder objContainer { get; set; }
        public Autofac.IContainer Container { get; set; }

        public readonly Lazy<RegistrationServices>
        lazy =
        new Lazy<RegistrationServices>
           (() => new RegistrationServices());

        public RegistrationServices Instance { get { return lazy.Value; } }

        public RegistrationServices()
        {
            this.Register();
        }

        private void Register()
        {
            objContainer = new ContainerBuilder();
            objContainer.RegisterModule<RegistrationModule>();
            Container = objContainer.Build();
        }
    }
}