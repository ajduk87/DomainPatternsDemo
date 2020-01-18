using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using FluentValidation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Action
{
    public class ActionUpdateByCustomerValidator : AbstractValidator<ActionCustomerUpdateModel>
    {
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository productRepository;

        public ActionUpdateByCustomerValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.customerRepository = RepositoryFactory.CreateCustomerRepository();
            this.productRepository = RepositoryFactory.CreateProductRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(a => a.CustomerId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateCustomerId)
                .WithMessage("Customer specified doesn't exist in the database");

            RuleFor(a => a.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateProductId)
                .WithMessage("Product specified doesn't exist in the database");
        }

        private bool ValidateCustomerId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.customerRepository.Exists(connection, id);
            }
        }

        private bool ValidateProductId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.productRepository.Exists(connection, id);
            }
        }
    }
}
