using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.CommandRequests
{
    public static class StorageCommandRequests
    {
        public const string GetAll = "GetAll";
        public const string Get = "Get";
        public const string Insert = "Insert";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string GetStorageContent = "GetStorageContent";
        public const string AddProductToStorage = "AddProductToStorage";
        public const string DeleteProductFromStorage = "DeleteProductFromStorage";
    }
}
