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
        public const string GetAllFruits = "GetAllFruits";
        public const string GetAllVegetables = "GetAllVegetables";
        public const string GetByName = "GetByName";
        public const string Delete = "Delete";
        public const string GetAllProductsFromStorage = "GetAllProductsFromStorage";
        public const string GetProductFromAllStorages = "GetProductFromAllStorages";
        public const string InsertProductInStorage = "InsertProductInStorage";
        public const string DeleteProductFromStorage = "DeleteProductFromStorage";
    }
}
