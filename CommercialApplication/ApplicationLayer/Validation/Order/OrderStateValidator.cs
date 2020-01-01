using CommercialApplication.ApplicationLayer.Models.Order;
using CommercialApplicationCommand;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using FluentValidation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Validation.Order
{
    public class OrderStateValidator : AbstractValidator<OrderStateModel>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public OrderStateValidator(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
            this.databaseConnectionFactory = databaseConnectionFactory;

            RuleFor(o => o.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateOrderId)
                .WithMessage("The order specified doesn't exist in the database");

            RuleFor(p => p)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateOpenState)
                .WithMessage("The order can't be set to open state because product is closed or closedandempty state.")
                .Must(ValidatePausedState)
                .WithMessage("The order can't be set to paused state because product is not open state.")
                .Must(ValidateClosedState)
                .WithMessage("The order can't be set to closed state because product is in paused state.")
                .Must(ValidateClosedAndEmptyState)
                .WithMessage("The order can't be set to closed and empty state because product is in paused state.");
        }

        private bool ValidateOrderId(long orderid)
        {
            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                return this.orderRepository.Exists(connection, orderid);
            }
        }

        private bool ValidateOpenState(OrderStateModel orderStateModel)
        {
            if (!orderStateModel.State.Equals("open"))
            {
                return true;
            }

            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                string currentState = this.orderRepository.SelectById(connection, orderStateModel.Id).State.Content;
                return currentState.Equals("paused");
            }
        }

        private bool ValidatePausedState(OrderStateModel orderStateModel)
        {
            if (!orderStateModel.State.Equals("paused"))
            {
                return true;
            }

            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                string currentState = this.orderRepository.SelectById(connection, orderStateModel.Id).State.Content;
                return currentState.Equals("open");
            }
        }

        private bool ValidateClosedState(OrderStateModel orderStateModel)
        {
            if (!orderStateModel.State.Equals("closed"))
            {
                return true;
            }

            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                string currentState = this.orderRepository.SelectById(connection, orderStateModel.Id).State.Content;
                return !currentState.Equals("paused");
            }
        }

        private bool ValidateClosedAndEmptyState(OrderStateModel orderStateModel)
        {
            if (!orderStateModel.State.Equals("closedandempty"))
            {
                return true;
            }

            using (NpgsqlConnection connection = databaseConnectionFactory.Instance.Create())
            {
                string currentState = this.orderRepository.SelectById(connection, orderStateModel.Id).State.Content;
                return !currentState.Equals("paused");
            }
        }
    }
}
