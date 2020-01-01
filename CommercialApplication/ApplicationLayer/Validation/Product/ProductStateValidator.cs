using CommercialApplication.ApplicationLayer.Models.Product;
using CommercialApplicationCommand;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using FluentValidation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Validation.Product
{
    public class ProductStateValidator : AbstractValidator<ProductStateModel>
    {
        private readonly IProductRepository productRepository;
        private readonly IProductStorageRepository productStorageRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public ProductStateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.productRepository = RepositoryFactory.CreateProductRepository();
            this.productStorageRepository = RepositoryFactory.CreateProductStorageRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateProductName)
                .WithMessage("The product specified doesn't exist in the database");

            RuleFor(p => p)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateNotForSoldState)
                .WithMessage("The product can't be set to not for sold state because product is unsold state.")
                .Must(ValidateUnsoldState)
                .WithMessage("The product can't be set to unsold state because product is not for sold state.")
                .Must(ValidateForSoldState)
                .WithMessage("The product can't be set to for sold state because product amount is 0.");
        }

        private bool ValidateProductName(string name)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                long id = this.productRepository.SelectByName(connection, new Name(name)).Id;
                return this.productRepository.Exists(connection, id);
            }
        }

        private bool ValidateNotForSoldState(ProductStateModel productStateModel)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                return !this.productRepository.SelectByName(connection, new Name(productStateModel.Name)).State.Content.Equals("unsold");
            }
        }

        private bool ValidateUnsoldState(ProductStateModel productStateModel)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                return !this.productRepository.SelectByName(connection, new Name(productStateModel.Name)).State.Content.Equals("notforsold");
            }
        }

        private bool ValidateForSoldState(ProductStateModel productStateModel)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                long id = this.productRepository.SelectByName(connection, new Name(productStateModel.Name)).Id;
                IEnumerable<ProductStorage> productItems = this.productStorageRepository.SelectProductFromAllStorages(connection, id);
                return productItems.Select(productItem => productItem.AmountOfProduct.Content).Sum() > 0;
            }
        }
    }
}
