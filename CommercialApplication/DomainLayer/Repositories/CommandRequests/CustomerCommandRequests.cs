using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.CommandRequests
{
    public static class CustomerCommandRequests
    {
        public const string GetAll = "GetAll";
        public const string Get = "Get";
        public const string CreateNewCustomerInfo = "CreateNewCustomerInfo";
        public const string UpdateExistingCustomerInfo = "UpdateExistingCustomerInfo";
        public const string RemoveExistingCustomerInfo = "RemoveExistingCustomerInfo";
        public const string IsCustomerExist = "IsCustomerExist";
    }
}
