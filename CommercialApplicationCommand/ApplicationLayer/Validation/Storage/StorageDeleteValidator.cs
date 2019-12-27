using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.StorageRepositories;
using FluentValidation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Storage
{
    public class StorageDeleteValidator : AbstractValidator<StorageDeleteModel>
    {
        private readonly IStorageRepository storageRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;
        public StorageDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.storageRepository = RepositoryFactory.CreateStorageRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(s => s.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("The storage specified doesn't exist in the database");
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.storageRepository.Exists(connection, id);
            }
        }
    }
}
