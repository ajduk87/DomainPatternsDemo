using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Order
{
    internal class OrderUpdateValidator : AbstractValidator<OrderUpdateModel>
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public OrderUpdateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
            this.customerRepository = RepositoryFactory.CreateCustomerRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(o => o.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateOrderId)
                .WithMessage("Order specified doesn't exist in the database");

            RuleFor(o => o.CustomerId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateCustomerId)
                .WithMessage("The customer specified doesn't exist in the database");
        }

        private bool ValidateOrderId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                bool exists = this.orderRepository.Exists(connection, id);
                return exists;
            }
        }

        private bool ValidateCustomerId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                bool exists = this.customerRepository.Exists(connection, id);
                return exists;
            }
        }
    }
}