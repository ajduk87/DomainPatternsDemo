using CommercialApplication.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using FluentValidation;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Order
{
    public class OrderDeleteValidator : AbstractValidator<OrderDeleteModel>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public OrderDeleteValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(o => o.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateOrderId)
                .WithMessage("The order specified doesn't exist in the database.");
        }

        private bool ValidateOrderId(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                return this.orderRepository.Exists(connection, id);
            }
        }
    }
}