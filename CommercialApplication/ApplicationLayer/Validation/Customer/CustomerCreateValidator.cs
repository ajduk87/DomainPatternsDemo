using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Customer
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateModel>
    {
        public CustomerCreateValidator()
        {
            RuleFor(c => c.Name)
                .Must(ValidateName)
                .WithMessage("Name must contain only letters");
        }

        private bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"[A-Za-z][a-z]+");
        }
    }
}