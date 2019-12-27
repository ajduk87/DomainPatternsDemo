using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.StorageRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Storage
{
    public class StorageUpdateValidator : AbstractValidator<StorageUpdateModel>
    {
        private readonly IStorageRepository storageRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public StorageUpdateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
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