using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    class ProductStorageData
    {
        public ProductStorageCreateModel SampleCreate;
        public ProductStorageDeleteModel SampleDelete;
        public ProductStorageData()
        {
            this.SampleCreate = new ProductStorageCreateModel
            {
                AmountOfProduct = 3500
            };

            this.SampleDelete = new ProductStorageDeleteModel();
        }
    }
}
