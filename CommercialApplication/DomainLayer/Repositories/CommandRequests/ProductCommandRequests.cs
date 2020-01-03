using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.CommandRequests
{
    public static class ProductCommandRequests
    {
        public const string GetAll = "GetAll";
        public const string Get = "Get";
        public const string Insert = "Insert";
        public const string Update = "Update";
        public const string DecreaseUnitcostFruits = "DecreaseUnitcostFruits";
        public const string DecreaseUnitcostVegetables = "DecreaseUnitcostVegetables";
        public const string SetState = "SetState";
        public const string Delete = "Delete";
    }
}
