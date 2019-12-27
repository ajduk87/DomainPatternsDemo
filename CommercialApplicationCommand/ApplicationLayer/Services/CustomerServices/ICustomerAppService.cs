using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;

namespace CommercialApplicationCommand.ApplicationLayer.Services.CustomerServices
{
    public interface ICustomerAppService
    {
        void CreateNewCustomerInfo(CustomerDto customerDto);

        void UpdateExistingCustomerInfo(CustomerDto customerDto);

        void RemoveExistingCustomerInfo(CustomerDto customerDto);
    }
}