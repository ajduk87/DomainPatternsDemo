using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using FluentValidation;
using System;

namespace CommercialApplicationCommand.ApplicationLayer.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly RegistrationAppServices registrationAppServices;

        public ValidatorFactory()
        {
            this.registrationAppServices = new RegistrationAppServices();
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = this.registrationAppServices.Instance.Container.ResolveKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}