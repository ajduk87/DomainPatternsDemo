using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using FluentValidation;
using System.Linq;

namespace CommercialApplicationCommand.ApplicationLayer.Validation.Product
{
    internal class ProductCreateValidator : AbstractValidator<ProductCreateModel>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.UnitCost)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateUnitCost)
                .WithMessage("Unit cost must be a positive number");
        }

        private bool ValidateUnitCost(UnitCostModel unitCost)
        {
            return unitCost.Value > 0;
        }
    }
}