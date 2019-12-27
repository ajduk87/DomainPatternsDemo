using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class StorageData
    {
        public StorageCreateModel SampleCreate;
        public StorageUpdateModel SampleUpdate;
        public StorageDeleteModel SampleDelete;

        public StorageData()
        {
            this.SampleCreate = new StorageCreateModel
            {
                Name = "StorageCreate",
                Location = "LocationCreate"
            };

            this.SampleUpdate = new StorageUpdateModel
            { 
                Name = "StorageUpdated",
                Location = "LocationUpdated"
            };

            this.SampleDelete = new StorageDeleteModel();
        }
    }
}
