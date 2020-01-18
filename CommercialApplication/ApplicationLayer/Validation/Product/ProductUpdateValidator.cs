using CommercialApplication.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Product
{
    internal class ProductUpdateValidator : AbstractValidator<ProductUpdateModel>
    {
        private readonly /* IProduct */ AProductRepository productRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public ProductUpdateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.productRepository = RepositoryFactory.CreateProductRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(p => p.UnitCost)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateUnitCost)
                .WithMessage("Unit cost must be a positive number");

            RuleFor(p => p.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateId)
                .WithMessage("The product specified doesn't exist in database.");
        }

        private bool ValidateUnitCost(UnitCostModel unitCost)
        {
            return unitCost.Value > 0;
        }

        private bool ValidateId(long id)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                return this.productRepository.Exists(connection, id);
            }
        }
    }
}