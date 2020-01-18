using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Product
{
    public class ProductDeleteValidator : AbstractValidator<ProductDeleteModel>
    {
        private readonly /* IProduct */ AProductRepository productRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public ProductDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.productRepository = RepositoryFactory.CreateProductRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(p => p.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("The product specified doesn't exist in the database");
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.productRepository.Exists(connection, id);
            }
        }
    }
}